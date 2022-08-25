using System;
using System.Text.RegularExpressions;
using System.Drawing;
using JugaAgenda_v2.Classes;
using System.Collections.Generic;
using Google.Apis.Calendar.v3.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace JugaAgenda_v2
{
    public class Work
    {
        public enum Status
        {
            wachten_op_onderdelen, // null = white
            onderdelen_op_voorraad, // 5 = yellow 2groen
            bezig, // 9 = blue 5geel
            klaar, // 2 = green 8grijs
            geannuleerd, // 8 = gray 9blauw
            niet_komen_opdagen, // 3 = purple
            onderdelen_niet_op_tijd, // 6 = orange
        }

        private String id;
        private String description;
        private Decimal duration;
        private String clientName;
        private String phoneNumber;
        private String orderNumber;
        private Status status;
        private Decimal hours_done;
        private List<Technician> technicianList = new List<Technician>();
        private Google.Apis.Calendar.v3.Data.Event calendarEvent;

        // Example: 2.5u Arno Van Eetvelde +32 490 11 17 78 B2020/123
        private String[] titleRegexParts = {"[0-9.,]+u", "[a-zA-Z ]+", "[+]?[0-9 ]+", "B[0-9/]+"};

        public Work() {}

        public Work(Google.Apis.Calendar.v3.Data.Event item)
        {
            updateValues(item);
            if (!checkValues())
                calendarEvent = null;
        }

        public Work( // Full day
            String id,
            String description,
            Decimal duration,
            String clientName,
            String phoneNumber,
            String orderNumber,
            Status status,
            Decimal hours_done,
            IList<Technician> technicianList,
            String startDate,
            String endDate)
        {
            this.id = id;
            this.description = description;
            this.duration = duration;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.orderNumber = orderNumber;
            this.status = status;
            this.hours_done = hours_done;
            this.technicianList = technicianList as List<Technician>;

            if (checkValues())
                this.createFullDayCalendarEvent(startDate, endDate);
        }

        public Work(
            String id,
            String description,
            Decimal duration,
            String clientName,
            String phoneNumber,
            String orderNumber,
            Status status,
            Decimal hours_done,
            IList<Technician> technicianList,
            DateTime startDate,
            DateTime endDate)
        {
            this.id = id;
            this.description = description;
            this.duration = duration;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.orderNumber = orderNumber;
            this.status = status;
            this.hours_done = hours_done;
            this.technicianList = technicianList as List<Technician>;

            if (checkValues())
                this.createCalendarEvent(startDate, endDate);
        }

        public void createFullDayCalendarEvent(String startDate, String endDate)
        {
            this.calendarEvent = new Event();

            this.calendarEvent.Start = new EventDateTime();
            this.calendarEvent.Start.Date = startDate;
            this.calendarEvent.Start.DateTime = null;
            this.calendarEvent.End = new EventDateTime();
            this.calendarEvent.End.Date = endDate;
            this.calendarEvent.End.DateTime = null;

            updateCalendarEvent();
        }

        public void createCalendarEvent(DateTime startDate, DateTime endDate)
        {
            this.calendarEvent = new Event();

            this.calendarEvent.Start = new EventDateTime();
            this.calendarEvent.Start.DateTime = startDate;
            this.calendarEvent.End = new EventDateTime();
            this.calendarEvent.End.DateTime = endDate;

            updateCalendarEvent();
        }

        public Boolean checkValues()
        {
            Regex regex;

            regex = new Regex("^" + titleRegexParts[0] + "$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(getDuration().ToString() + "u"))
            {
                MessageBox.Show("Duration is incorrect.");
                return false;
            }

            regex = new Regex("^" + titleRegexParts[1] + "$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(getClientName()))
            {
                MessageBox.Show("Client name is incorrect.");
                return false;
            }

            regex = new Regex("^" + titleRegexParts[2] + "$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(getPhoneNumber()))
            {
                MessageBox.Show("Phone number is incorrect.");
                return false;
            }

            if (getOrderNumber() == "" || getOrderNumber() == null) setOrderNumber("B0");

            regex = new Regex("^" + titleRegexParts[3] + "$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(getOrderNumber()))
            {
                MessageBox.Show("Order number is incorrect.");
                return false;
            }

            return true;

        }

        public bool check_title(String title)
        {
            String regexPattern = "";

            foreach(String regexPart in titleRegexParts)
            {
                regexPattern += regexPart + " ";
            }
            regexPattern = regexPattern.Remove(regexPattern.Length - 1);

            Regex regex = new Regex("^" + regexPattern + "$", RegexOptions.IgnoreCase);
            return regex.IsMatch(title);
        }

        public void updateCalendarEvent()
        {
            this.calendarEvent.Id = this.getId();
            this.calendarEvent.Description = this.getDescription();
            this.calendarEvent.Summary = this.getTitle();
            this.calendarEvent.ColorId = this.getColorID().ToString();

            this.calendarEvent.ExtendedProperties = new Event.ExtendedPropertiesData();
            this.calendarEvent.ExtendedProperties.Shared = new Dictionary<String, String>();

            foreach (KeyValuePair<String, String> property in this.calendarEvent.ExtendedProperties.Shared)
                this.calendarEvent.ExtendedProperties.Shared[property.Key] = null;

            this.calendarEvent.ExtendedProperties.Shared["hours_done"] = this.getHoursDone().ToString();

            foreach (Technician tech in this.getTechnicianList())
                this.calendarEvent.ExtendedProperties.Shared["tech-" + tech.getName()] = tech.getHours().ToString();

        }

        #region getters

        public Google.Apis.Calendar.v3.Data.Event getCalendarEvent()
        {
            return calendarEvent;
        }
        public string getId()
        {
            return id;
        }
        public string getDescription()
        {
            return description;
        }
        public Decimal getDuration()
        {
            return duration;
        }
        public string getClientName()
        {
            return clientName;
        }
        public string getPhoneNumber()
        {
            return phoneNumber;
        }
        public string getOrderNumber()
        {
            return orderNumber;
        }
        public Status getStatus()
        {
            return status;
        }

        public int getColorID()
        {
            return this.status_to_colorID(status);
        }

        public Color getColor()
        {
            switch (this.status)
            {
                case Status.onderdelen_op_voorraad:
                    return Color.Green;
                case Status.bezig:
                    return Color.Yellow;
                case Status.klaar:
                    return Color.Gray;
                case Status.geannuleerd:
                    return Color.Blue;
                case Status.niet_komen_opdagen:
                    return Color.Purple;
                case Status.onderdelen_niet_op_tijd:
                    return Color.Orange;
                default:
                    return Color.White;
            }
        }

        public String getTitle()
        {
            return this.getDuration().ToString() + "u " + this.getClientName() + " " + this.getPhoneNumber() + " " + this.getOrderNumber();
        }

        public Status colorID_to_status(int colorID)
        {
            switch (colorID)
            {
                case 5:
                    return Status.bezig;
                case 9:
                    return Status.geannuleerd;
                case 2:
                    return Status.onderdelen_op_voorraad;
                case 8:
                    return Status.klaar;
                case 3:
                    return Status.niet_komen_opdagen;
                case 6:
                    return Status.onderdelen_niet_op_tijd;
                default:
                    return Status.wachten_op_onderdelen;
            }
        }

        public int status_to_colorID(Status status)
        {
            switch (status)
            {
                case Status.onderdelen_op_voorraad:
                    return 2;
                case Status.bezig:
                    return 5;
                case Status.klaar:
                    return 8;
                case Status.geannuleerd:
                    return 9;
                case Status.niet_komen_opdagen:
                    return 3;
                case Status.onderdelen_niet_op_tijd:
                    return 6;
                default:
                    return 0;
            }
        }

        public Decimal getHoursDone()
        {
            return hours_done;
        }

        public List<Technician> getTechnicianList()
        {
            return technicianList;
        }

        public Boolean isWorkOpen()
        {
            return
                this.getStatus() != Work.Status.klaar &&
                this.getStatus() != Work.Status.geannuleerd &&
                this.getStatus() != Work.Status.niet_komen_opdagen &&
                this.getStatus() != Work.Status.onderdelen_niet_op_tijd &&
                this.getDuration() - this.getHoursDone() > 0;
        }

        public Boolean isWorkReady()
        {
            return
                this.getStatus() != Work.Status.wachten_op_onderdelen &&
                this.getStatus() != Work.Status.onderdelen_niet_op_tijd;
        }

        #endregion

        #region setters

        public void setCalendarEvent(Google.Apis.Calendar.v3.Data.Event calendarEvent)
        {
            this.calendarEvent = calendarEvent;
        }
        public void setId(string id)
        {
            this.id = id;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        public void setDuration(Decimal duration)
        {
            this.duration = duration;
        }
        public void setClientName(string clientName)
        {
            this.clientName = clientName;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void setOrderNumber(string orderNumber)
        {
            this.orderNumber = orderNumber;
        }
        public void setStatus(Status status)
        {
            this.status = status;
        }
        public void setHoursDone(Decimal hoursDone)
        {
            this.hours_done = hoursDone;
        }

        public void updateValues(Google.Apis.Calendar.v3.Data.Event item, Boolean checkTitle = true)
        {
            if (checkTitle)
            {
                String tempTitle = item.Summary;
                for (int i = 0; i < titleRegexParts.Length - 1; i++)
                {
                    String regexPattern = "";
                    for (int j = i + 1; j < titleRegexParts.Length; j++)
                    {
                        regexPattern += " " + titleRegexParts[j];
                    }

                    String titlePart = Regex.Split(tempTitle, regexPattern, RegexOptions.IgnoreCase)[0];
                    int length = titlePart.Length;

                    if (titlePart[0].Equals(' ')) titlePart = titlePart.Substring(1);
                    if (titlePart[titlePart.Length-1].Equals(' ')) titlePart = titlePart.Substring(0, titlePart.Length-1);

                    if (i == 0) this.duration = Decimal.Parse(titlePart.Replace('.', ',').Replace("u", String.Empty), new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    if (i == 1) this.clientName = titlePart;
                    if (i == 2) this.phoneNumber = titlePart;

                    tempTitle = tempTitle.Remove(0, length);

                }

                if (tempTitle[0].Equals(' ')) tempTitle = tempTitle.Substring(1);
                if (tempTitle[tempTitle.Length - 1].Equals(' ')) tempTitle = tempTitle.Substring(0, tempTitle.Length - 1);
                this.orderNumber = tempTitle;
            }

            this.id = item.Id;
            this.description = item.Description;
            this.status = colorID_to_status((int)Convert.ToInt64(item.ColorId));
            this.calendarEvent = item;

            if (item.ExtendedProperties != null && item.ExtendedProperties.Shared != null)
            {
                IDictionary<String, String> properties = item.ExtendedProperties.Shared;

                if (properties["hours_done"] != null)
                    this.hours_done = Decimal.Parse(properties["hours_done"], new NumberFormatInfo() { NumberDecimalSeparator = "," });

                foreach (KeyValuePair<String, String> property in properties)
                {
                    if (property.Key.Substring(0, 4).Equals("tech"))
                        technicianList.Add(new Technician(property.Key.Substring(5), Decimal.Parse(property.Value.Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," })));
                }

            }

        }

        #endregion
        
        public override string ToString()
        {
            return getTitle();
        }

    }
}
