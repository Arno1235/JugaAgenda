using JugaAgenda_v2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Text.RegularExpressions;

namespace JugaAgenda_v2
{

    public partial class fHome : Form
    {

        public GoogleCalendar googleCalendar;
        private List<CustomDay> techniciansWorkWeekList;
        private List<CustomDay> technicianLeaveList;
        private List<CustomDay> workList;
        private fCalendarEvent calendarEventScreen = null;
        private fSearch searchScreen = null;

        #region TODO

        // - When adding or changing work show when there is place
        // - Add/Edit/Remove/Show tech leave
        // - Add/Edit/Remove/Show tech schedule
        // - Add list of basic work with duration and price

        #endregion

        #region InitializationFunctions

        public fHome()
        {

            InitializeComponent();

            googleCalendar = new GoogleCalendar();

            mvHome.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            mvHome.SelectionEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            mvHome.MaxSelectionCount = calHome.MaximumViewDays;

            mvHome.SelectionChanged += new System.EventHandler(mvHome_SelectionChanged);

            calHome.TimeScale = CalendarTimeScale.SixtyMinutes;

            loadStyleComponents();

            loadEverything();

        }

        public void loadEverything()
        {
            refresh();

            mvHome_SelectionChanged(null, null);
        }

        private void loadStyleComponents()
        {

            cbCalendarSelectionMode.Items.Add("Manueel");
            cbCalendarSelectionMode.Items.Add("Dag");
            cbCalendarSelectionMode.Items.Add("Werk Week");
            cbCalendarSelectionMode.Items.Add("Week");
            cbCalendarSelectionMode.Items.Add("Maand");
            cbCalendarSelectionMode.SelectedIndex = 4;
            cbCalendarSelectionMode.DropDownStyle = ComboBoxStyle.DropDownList;

            cbCalendarTimeScale.Items.Add("5 minuten");
            cbCalendarTimeScale.Items.Add("6 minuten");
            cbCalendarTimeScale.Items.Add("10 minuten");
            cbCalendarTimeScale.Items.Add("15 minuten");
            cbCalendarTimeScale.Items.Add("30 minuten");
            cbCalendarTimeScale.Items.Add("60 minuten");
            cbCalendarTimeScale.SelectedIndex = 5;
            cbCalendarTimeScale.DropDownStyle = ComboBoxStyle.DropDownList;

            cbCalendarPerspective.Items.Add("1 maand");
            cbCalendarPerspective.Items.Add("2 maanden");
            cbCalendarPerspective.Items.Add("3 maanden");
            cbCalendarPerspective.Items.Add("4 maanden");
            cbCalendarPerspective.Items.Add("5 maanden");
            cbCalendarPerspective.SelectedIndex = 0;
            cbCalendarPerspective.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        #endregion

        #region CalendarSynchronizationFunctions

        public void refresh()
        {
            testConnection();
            loadTechniciansWorkWeek();
            loadTechnicianLeave();
            loadWork();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            
            syncCalendar();

        }

        public void syncCalendar()
        {
            // Can be more efficient
            IList<Google.Apis.Calendar.v3.Data.Event> syncList = googleCalendar.sync();
            if (syncList != null)
            {
                foreach (Google.Apis.Calendar.v3.Data.Event item in syncList)
                {
                    bool found = false;
                    foreach (CustomDay day in workList)
                    {
                        List<Work> dayWorkList = day.getWorkList();
                        for (int i = dayWorkList.Count - 1; i >= 0; i--)
                        {
                            Work work = dayWorkList[i];

                            if (work.getId() == item.Id)
                            {
                                if (item.Summary != null && checkTitleMessageBox(item))
                                {
                                    work.updateValues(item);
                                }
                                else
                                {
                                    day.getWorkList().RemoveAt(i);
                                }
                                found = true;
                                break;
                            }

                        }
                        if (found) break;
                    }
                    if (!found) addWorkItem(item);
                }
                // Can be more efficient
                mvHome_SelectionChanged(null, null);
            }
        }

        #endregion

        #region LoadCalendarFunctions

        // Can be more efficient
        private void loadTechniciansWorkWeek()
        {
            if (techniciansWorkWeekList == null) techniciansWorkWeekList = new List<CustomDay>();
            techniciansWorkWeekList.Clear();

            for (int i = 1; i <= 7; i++) techniciansWorkWeekList.Add(new CustomDay(new DateTime(2021, 2, i)));

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getTechnicianEvents().Items)
            {
                DateTime date = Convert.ToDateTime(item.Start.Date);
                if (date.Day > 7) continue;

                Regex regex = new Regex("[a-zA-Z ]+ [0-9,.]+u", RegexOptions.IgnoreCase);
                if (!regex.IsMatch(item.Summary))
                {
                    MessageBox.Show("There seems to be something wrong in the technician schedule.", "Error");
                    continue;
                }

                CustomDay day = techniciansWorkWeekList[date.Day];

                String name = item.Summary.Remove(item.Summary.Length - item.Summary.Split(' ').Last().Length - 1);
                decimal hours = Convert.ToDecimal(item.Summary.Split(' ').Last().Split('u')[0].Replace(',', '.'));
                day.addTechnicianList(new Technician(name, hours));
            }

            /*foreach (CustomDay day in techniciansWorkWeekList)
            {
                foreach (Technician tech in day.getTechnicianList())
                {
                    MessageBox.Show(day.getDate().ToString() + " " + tech.getName() + " " + tech.getHours().ToString());
                }
            }*/
        }

        private void loadTechnicianLeave()
        {
            if (technicianLeaveList == null) technicianLeaveList = new List<CustomDay>();
            technicianLeaveList.Clear();

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getLeaveEvents().Items)
            {

                Regex regex = new Regex("[a-zA-Z ]+ verlof", RegexOptions.IgnoreCase);
                if (!regex.IsMatch(item.Summary))
                {
                    MessageBox.Show("There seems to be something wrong in the technician leave schedule.", "Error");
                    continue;
                }

                DateTime date = Convert.ToDateTime(item.Start.Date);

                CustomDay day = null;
                foreach (CustomDay listday in technicianLeaveList)
                {
                    if (DateTime.Compare(listday.getDate(), date) == 0)
                    {
                        day = listday;
                        break;
                    }
                }
                if (day == null)
                {
                    day = new CustomDay(date);

                    technicianLeaveList.Add(day);
                }

                day.addTechnicianList(new Technician(item.Summary.Remove(item.Summary.Length-7), 0));

            }

            /*foreach (CustomDay day in technicianLeaveList)
            {
                foreach (Technician tech in day.getTechnicianList())
                {
                    MessageBox.Show(day.getDate().ToString() + " " + tech.getName() + " " + tech.getHours().ToString());
                }
            }*/
        }

        // No support for non all-day and multiple days events yet
        // Can be more efficient
        private void loadWork()
        {
            if (workList == null) workList = new List<CustomDay>();
            workList.Clear();
            
            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getWorkEvents())
            {
                addWorkItem(item);
            }
            /*foreach (CustomDay day in workList)
            {
                MessageBox.Show(day.getDate().ToString(), "Date");
                foreach (Work work in day.getWorkList())
                {
                    MessageBox.Show(work.getClientName() + " " + work.getDescription() + " " + work.getDuration().ToString() + " " + work.getOrderNumber() + " " + work.getPhoneNumber() + " " + work.getStatus().ToString());
                    *//*MessageBox.Show(work.getClientName(), "Client name");
                    MessageBox.Show(work.getDescription(), "Description");
                    MessageBox.Show(work.getDuration().ToString(), "Duration");
                    MessageBox.Show(work.getOrderNumber(), "Order number");
                    MessageBox.Show(work.getPhoneNumber(), "Phone number");
                    MessageBox.Show(work.getStatus().ToString(), "Status");*//*
                }
                foreach (Technician tech in day.getTechnicianList())
                {
                    MessageBox.Show(day.getDate().ToString() + " " + tech.getName() + " " + tech.getHours().ToString());
                }
            }*/
        }

        #endregion

        // TODO
        #region ExtraPrimaryFunctions

        private void mvHome_SelectionChanged(object sender, EventArgs e)
        {
            if ((mvHome.SelectionEnd - mvHome.SelectionStart).Days > -1 && (mvHome.SelectionEnd - mvHome.SelectionStart).Days < calHome.MaximumViewDays)
            {
                int oldMaximumViewDays = calHome.MaximumViewDays;
                DateTime end;
                DateTime start;
                if (mvHome.SelectionEnd > calHome.ViewEnd)
                {
                    end = mvHome.SelectionEnd;
                }
                else
                {
                    end = calHome.ViewEnd;
                }
                if (mvHome.SelectionStart < calHome.ViewStart)
                {
                    start = mvHome.SelectionStart;
                }
                else
                {
                    start = calHome.ViewStart;
                }
                calHome.MaximumViewDays = (int)Math.Ceiling((double)(end - start).Days / 7) * 7 + 7;
                if (mvHome.SelectionStart <= calHome.ViewEnd)
                {
                    if (mvHome.SelectionMode == System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month)
                    {
                        calHome.ViewStart = mvHome.SelectionStart.StartOfWeek(DayOfWeek.Monday);
                        calHome.ViewEnd = mvHome.SelectionEnd.EndOfWeek(DayOfWeek.Sunday);
                    } else
                    {
                        calHome.ViewStart = mvHome.SelectionStart;
                        calHome.ViewEnd = mvHome.SelectionEnd;
                    }

                }
                else
                {
                    if (mvHome.SelectionMode == System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month)
                    {
                        calHome.ViewEnd = mvHome.SelectionEnd.EndOfWeek(DayOfWeek.Sunday);
                        calHome.ViewStart = mvHome.SelectionStart.StartOfWeek(DayOfWeek.Monday);
                    }
                    else
                    {
                        calHome.ViewEnd = mvHome.SelectionEnd;
                        calHome.ViewStart = mvHome.SelectionStart;
                    }
                }
                calHome.MaximumViewDays = oldMaximumViewDays;

                if (workList != null)
                {
                    foreach (CustomDay day in workList)
                    {
                        DateTime date = day.getDate();

                        if (date >= calHome.ViewStart && date < calHome.ViewEnd)
                        {
                            foreach (Work work in day.getWorkList())
                            {
                                CalendarItem newItem = new CalendarItem(calHome,
                                    date,
                                    date.AddDays(1).AddSeconds(-1),
                                    work.getTitle());

                                newItem.ApplyColor(work.getColor());
                                newItem.setCalendarEvent(work.getCalendarEvent());

                                calHome.Items.Add(newItem);
                            }
                        }
                    }
                }


                /*foreach (Google.Apis.Calendar.v3.Data.Event eventItem in googleCalendar.getWorkEvents().Items)
                {
                    if (eventItem.Start.DateTime != null)
                    {
                        if ((eventItem.Start.DateTime > calHome.ViewStart && eventItem.Start.DateTime < calHome.ViewEnd) ||
                            (eventItem.End.DateTime < calHome.ViewEnd && eventItem.End.DateTime > calHome.ViewStart))
                        {
                            CalendarItem newItem = new CalendarItem(calHome,
                                (DateTime)eventItem.Start.DateTime,
                                (DateTime)eventItem.End.DateTime,
                                eventItem.Summary);

                            calHome.Items.Add(newItem);
                        }
                    }
                    else
                    {
                        DateTime startDate = Convert.ToDateTime(eventItem.Start.Date);
                        DateTime endDate = Convert.ToDateTime(eventItem.End.Date);
                        if ((startDate > calHome.ViewStart && startDate < calHome.ViewEnd) ||
                            (endDate < calHome.ViewEnd && endDate > calHome.ViewStart))
                        {
                            CalendarItem newItem = new CalendarItem(calHome,
                                startDate,
                                endDate.AddSeconds(-1),
                                eventItem.Summary);

                            calHome.Items.Add(newItem);
                        }
                    }
                }*/

            }
            else
            {
                MessageBox.Show("The selection has to be at least 1 day and can't be more than " + calHome.MaximumViewDays.ToString() + " days.");
            }


        }

        private void addWorkItem(Google.Apis.Calendar.v3.Data.Event item)
        {

            DateTime date;
            if (item.Start.DateTime != null)
            {
                date = (DateTime) item.Start.DateTime;
                date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            } else
            {
                date = Convert.ToDateTime(item.Start.Date);
            }
            CustomDay day = null;
            foreach (CustomDay listday in workList)
            {
                if (DateTime.Compare(listday.getDate(), date) == 0)
                {
                    day = listday;
                    break;
                }
            }
            if (day == null)
            {
                day = new CustomDay(date);

                foreach (Technician tech in techniciansWorkWeekList[(int)date.DayOfWeek].getTechnicianList())
                {
                    bool tech_has_leave = false;
                    foreach (CustomDay leave_day in technicianLeaveList)
                    {
                        if (DateTime.Compare(day.getDate(), leave_day.getDate()) == 0)
                        {
                            foreach (Technician leave_tech in leave_day.getTechnicianList())
                            {
                                if (tech.getName().Equals(leave_tech.getName())) tech_has_leave = true;
                            }
                            // if (!tech_has_leave) MessageBox.Show("There seems to be a wrong name or date in the technician leave schedule", "Error");
                        }
                    }

                    if (!tech_has_leave) day.addTechnicianList(tech);
                }

                workList.Add(day);
            }
            if (checkTitleMessageBox(item))
            {
                Work new_work = new Work(item);
                day.addWorkList(new_work);
            }
        }

        public bool deleteWorkItem(String eventId)
        {
            return googleCalendar.deleteWorkEvent(eventId);
        }

        public List<Work> searchWork(String clientName, String phoneNumber, String orderNumber, String description, Boolean OR = true)
        {
            List<Work> results = new List<Work>();

            foreach (CustomDay day in workList)
            {
                foreach (Work work in day.getWorkList())
                {
                    if (OR)
                    {
                        if (
                            (clientName != null && clientName != "" && work.getClientName() != null && work.getClientName().Contains(clientName, StringComparison.OrdinalIgnoreCase)) ||
                            (phoneNumber != null && phoneNumber != "" && work.getPhoneNumber() != null && work.getPhoneNumber().Contains(phoneNumber, StringComparison.OrdinalIgnoreCase)) ||
                            (orderNumber != null && orderNumber != "" && work.getOrderNumber() != null && work.getOrderNumber().Contains(orderNumber, StringComparison.OrdinalIgnoreCase)) ||
                            (description != null && description != "" && work.getDescription() != null && work.getDescription().Contains(description, StringComparison.OrdinalIgnoreCase))
                            )
                        {
                            results.Add(work);
                        }
                    }
                    else
                    {
                        if (
                            (clientName == null || clientName == "" || work.getClientName() == null || work.getClientName().Contains(clientName, StringComparison.OrdinalIgnoreCase)) &&
                            (phoneNumber == null || phoneNumber == "" || work.getPhoneNumber() == null || work.getPhoneNumber().Contains(phoneNumber, StringComparison.OrdinalIgnoreCase)) &&
                            (orderNumber == null || orderNumber == "" || work.getOrderNumber() == null || work.getOrderNumber().Contains(orderNumber, StringComparison.OrdinalIgnoreCase)) &&
                            (description == null || description == "" || work.getDescription() == null || work.getDescription().Contains(description, StringComparison.OrdinalIgnoreCase)) &&
                            !(
                            (clientName == null || clientName == "" || work.getClientName() == null) &&
                            (phoneNumber == null || phoneNumber == "" || work.getPhoneNumber() == null) &&
                            (orderNumber == null || orderNumber == "" || work.getOrderNumber() == null) &&
                            (description == null || description == "" || work.getDescription() == null)
                            )
                            )
                        {
                            results.Add(work);
                        }
                    }
                }
            }

            return results;
        }

        // TODO
        public List<DateTime> checkAvailability(decimal duration)
        {
            List<DateTime> results = new List<DateTime>();

            foreach (CustomDay day in workList)
            {
                foreach (Work work in day.getWorkList())
                {

                }
            }

            return results;
        }

        #endregion

        #region ExtraSecondaryFunctions

        private bool checkTitleMessageBox(Google.Apis.Calendar.v3.Data.Event item)
        {
            if (!new Work().check_title(item.Summary))
            {
                while (true)
                {
                    String new_title = Microsoft.VisualBasic.Interaction.InputBox("Please change the title of this event.", "Wrong event title", item.Summary);
                    if (!new_title.Equals("") && new_title != null)
                    {
                        if (!new Work().check_title(new_title))
                        {
                            MessageBox.Show("The new title is still incorrect.");
                            continue;
                        }
                        item.Summary = new_title;
                        if (!googleCalendar.editWorkEvent(item, item.Id))
                        {
                            MessageBox.Show("Something went wrong when updating event to calendar.");
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("Please change the title.");
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        private void testConnection(bool print_if_successfull = false)
        {
            if (googleCalendar.testConnection())
            {
                if (print_if_successfull) MessageBox.Show("Google Calendar Connection Succesfull");
            }
            else
            {
                MessageBox.Show("Google Calendar Connection Error");
                this.Close();
            }
        }

        // Can be more efficient
        public Google.Apis.Calendar.v3.Data.Event getGoogleEventById(String id)
        {

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getWorkEvents())
            {
                if (item.Id.Equals(id)) return item;
            }
            return null;
        }

        #endregion

        #region SecondaryScreensFunctions

        public void clear_calendar_screen()
        {
            calendarEventScreen = null;
        }

        public void clear_search_screen()
        {
            searchScreen = null;
        }

        public Boolean getCalendarScreenAlreadyOpen()
        {
            return this.calendarEventScreen != null;
        }

        public void openCalendarScreen(Google.Apis.Calendar.v3.Data.Event item)
        {
            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this, item);
                calendarEventScreen.Show();
            }
        }

        private void openSearchScreen()
        {
            if (searchScreen == null)
            {
                searchScreen = new fSearch(this);
                searchScreen.Show();
            }
        }

        #endregion

        #region SimpleButtonFunctions

        private void cbCalendarSelectionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCalendarSelectionMode.SelectedIndex)
            {
                case 0:
                    mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Manual;
                    break;
                case 1:
                    mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Day;
                    break;
                case 2:
                    mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.WorkWeek;
                    break;
                case 3:
                    mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Week;
                    break;
                case 4:
                    mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month;
                    break;
                default:
                    mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month;
                    break;
            }
        }

        private void cbCalendarTimeScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCalendarTimeScale.SelectedIndex)
            {
                case 0:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FiveMinutes;
                    break;
                case 1:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixMinutes;
                    break;
                case 2:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.TenMinutes;
                    break;
                case 3:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FifteenMinutes;
                    break;
                case 4:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.ThirtyMinutes;
                    break;
                case 5:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
                    break;
                default:
                    calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
                    break;
            }
        }

        private void cbCalendarPerspective_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCalendarPerspective.SelectedIndex)
            {
                case 0:
                    googleCalendar.setPerspectiveMonths(1);
                    break;
                case 1:
                    googleCalendar.setPerspectiveMonths(2);
                    break;
                case 2:
                    googleCalendar.setPerspectiveMonths(3);
                    break;
                case 3:
                    googleCalendar.setPerspectiveMonths(4);
                    break;
                case 4:
                    googleCalendar.setPerspectiveMonths(6);
                    break;
                default:
                    googleCalendar.setPerspectiveMonths(1);
                    break;
            }
        }

        private void btTestGoogleConnection_Click(object sender, EventArgs e)
        {
            testConnection(true);
        }

        private void addWorkEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCalendarScreen(null);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSearchScreen();
        }

        private void calHome_ItemDoubleClick(object sender, EventArgs e)
        {

            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this, calHome.GetSelectedItems().First().getCalendarEvent());
                calendarEventScreen.Show();
            }

        }

        #endregion

    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek)
        {
            int diff = (7 - (dt.DayOfWeek - endOfWeek)) % 7;
            return dt.AddDays(diff).Date;
        }
    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }

}
