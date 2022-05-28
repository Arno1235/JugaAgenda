using System;
using System.Text.RegularExpressions;
using System.Drawing;

namespace JugaAgenda_v2
{
    class Work
    {
        public enum Status
        {
            wachten_op_onderdelen, // null = white
            onderdelen_op_voorraad, // 5 = yellow
            bezig, // 9 = blue
            klaar, // 2 = green
            geannuleerd, // 8 = gray
            niet_komen_opdagen, // 3 = purple
            onderdelen_niet_op_tijd, // 6 = orange
        }

        private string id;
        private string description;
        private decimal duration;
        private string clientName;
        private string phoneNumber;
        private string orderNumber;
        private Status status;
        private Google.Apis.Calendar.v3.Data.Event calendarEvent;

        // Example: 2.5u Arno Van Eetvelde +32 490 11 17 78 B2020/123
        private String[] titleRegexParts = {"[0-9.,]+u", "[a-zA-Z ]+", "[+]?[0-9 ]+", "B[0-9/]+"};


        public Work()
        {

        }
        public Work(string id, decimal duration, string clientName, string phoneNumber, string orderNumber, string description, Status status)
        {
            this.id = id;
            this.description = description;
            this.duration = duration;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.orderNumber = orderNumber;
            this.status = status;
        }

        // FOUT
        /*public Work(string[] title, string description, Status status)
        {
            for (int i = 0; i < title.Length; i++)
            {
                if (i == 0) this.duration = Convert.ToDecimal(title[i].Split('u')[0].Replace(',', '.'));
                if (i == 1) this.clientName = title[i];
                if (i == 1) this.phoneNumber = title[i];
                if (i == 1) this.orderNumber = title[i];
            }

            this.description = description;
            this.status = status;
        }

        // FOUT
        public Work(string[] title, string description, int colorID)
        {
            for (int i = 0; i < title.Length; i++)
            {
                if (i == 0) this.duration = Convert.ToDecimal(title[i].Split('u')[0].Replace(',', '.'));
                if (i == 1) this.clientName = title[i];
                if (i == 2) this.phoneNumber = title[i];
                if (i == 3) this.orderNumber = title[i];
            }

            this.description = description;

            this.status = colorID_to_status(colorID);
        }*/

        public Work(Google.Apis.Calendar.v3.Data.Event item)
        {
            updateValues(item);
        }

        public void updateValues(Google.Apis.Calendar.v3.Data.Event item)
        {
            String tempTitle = item.Summary;
            for (int i = 0; i < titleRegexParts.Length - 1; i ++)
            {
                String regexPattern = "";
                for (int j = i + 1; j < titleRegexParts.Length; j ++)
                {
                    regexPattern += " " + titleRegexParts[j];
                }

                String titlePart = Regex.Split(tempTitle, regexPattern, RegexOptions.IgnoreCase)[0];

                if (i == 0) this.duration = Convert.ToDecimal(titlePart.Replace(',', '.').Replace("u", String.Empty));
                if (i == 1) this.clientName = titlePart;
                if (i == 2) this.phoneNumber = titlePart;

                tempTitle = tempTitle.Remove(0, titlePart.Length);

            }

            this.orderNumber = tempTitle;

            this.id = item.Id;
            this.description = item.Description;
            this.status = colorID_to_status((int)Convert.ToInt64(item.ColorId));
            this.calendarEvent = item;
        }

        public Status colorID_to_status(int colorID)
        {
            switch (colorID)
            {
                case 5:
                    return Status.onderdelen_op_voorraad;
                case 9:
                    return Status.bezig;
                case 2:
                    return Status.klaar;
                case 8:
                    return Status.geannuleerd;
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
                    return 5;
                case Status.bezig:
                    return 9;
                case Status.klaar:
                    return 2;
                case Status.geannuleerd:
                    return 8;
                case Status.niet_komen_opdagen:
                    return 3;
                case Status.onderdelen_niet_op_tijd:
                    return 6;
                default:
                    return 0;
            }
        }

        public bool check_title(String title)
        {
            String regexPattern = "";

            foreach(String regexPart in titleRegexParts)
            {
                regexPattern += regexPart + " ";
            }
            regexPattern = regexPattern.Remove(regexPattern.Length - 1);

            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(title);

            /*String[] titleArray = title.Split(' ');
            if (titleArray.Length < 3 || titleArray.Length > 4) return false;
            
            try
            {
                if (!titleArray[0].Substring(titleArray[0].Length - 1).Equals("u")) return false;
                foreach (char c in titleArray[0].Split('u')[0]) if (!"0123456789.,".Contains(c.ToString())) return false;
            } catch
            {
                return false;
            }
            

            return true;*/
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
        public decimal getDuration()
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
                    return Color.Yellow;
                case Status.bezig:
                    return Color.Blue;
                case Status.klaar:
                    return Color.Green;
                case Status.geannuleerd:
                    return Color.Gray;
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
        public void setDuration(decimal duration)
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
    #endregion

    }
}
