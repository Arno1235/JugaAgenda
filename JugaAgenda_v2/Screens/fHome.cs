﻿using JugaAgenda_v2.Classes;
using JugaAgenda_v2.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace JugaAgenda_v2
{

    public partial class fHome : Form
    {

        public GoogleCalendar googleCalendar { get; private set; }
        private List<CustomDay> techniciansWorkWeekList;
        public List<CustomDay> technicianLeaveList { get; private set; }
        public List<CustomDay> workList { get; private set; }
        public IList<Google.Apis.Calendar.v3.Data.Event> extraEventsList { get; private set; }
        public IList<Google.Apis.Calendar.v3.Data.Event> holidaysList { get; private set; }

        private List<Tuple<DateTime, String, Decimal>> openWorkHoursList;
        private List<Technician> technicianList;

        private fCalendarEvent calendarEventScreen = null;
        private fSearch searchScreen = null;
        private fPlanning planningScreen = null;
        private fTechSchedule scheduleScreen = null;
        private fLeaveEvent leaveEventScreen = null;
        private fExtraEvent extraEventScreen = null;

        private Google.Apis.Calendar.v3.Data.Event wrongTitleSelected = null;

        private Boolean focussed = true;
        private int unfocusCounter = 0;
        private int lastOpenedIndex = 0;

        private CustomCalendarScreen homeCustomCalendarScreen;
        private CustomCalendarScreen workCustomCalendarScreen;
        private CustomCalendarScreen leaveCustomCalendarScreen;

        #region TODO

        // - Translate
        // - Close shop (festivities)
        // - Planning creation
        // - Info calendar
        // - custom 2 week screen? (automatisch grote aanpassen als het niet op 1 dag past)
        // - form in form ? (https://www.codeproject.com/Articles/3553/Introduction-to-MDI-Forms-with-C)
        // - double click multiple day item
        // - test different screen sizes (change all resizing code)
        // - double click cal detail and add tooltip to cal detail
        // - set width of detail calendar that you can read whole title

        // - Code could break if the technician workweek can't be loaded in anymore because it's too old.

        #endregion

        #region InitializationFunctions

        public fHome()
        {

            InitializeComponent();

            // Load the google calendar connection

            googleCalendar = new GoogleCalendar();

            if (googleCalendar.getSuccess() != null)
            {
                MessageBox.Show(googleCalendar.getSuccess(), "Error");
                this.Close();
                return;
            }

            // Load the calendar views

            homeCustomCalendarScreen = new HomeCalendarScreen(calMain, mvMain, calDetailMain, btTodayMain, this);
            workCustomCalendarScreen = new WorkCalendarScreen(calHome, mvHome, calDetail, btWorkToday, this);
            leaveCustomCalendarScreen = new LeaveCalendarScreen(calLeave, mvLeave, calDetailLeave, btLeaveToday, this);

            // ------

            DateTime now = DateTime.Now;
            newDayTimer.Interval = 1000 - now.Millisecond + (59 - now.Second) * 1000 + (59 - now.Minute) * 1000 * 60 + (23 - now.Hour) * 1000 * 60 * 60 + 1 * 60 * 1000;
            newDayTimer.Enabled = true;

            // Initialize work schedule

            calWorkSchedule.TimeScale = CalendarTimeScale.SixtyMinutes;

            int days = (int)Math.Ceiling((double)((now - new DateTime(2021, 2, 1)).Days / 7)) * 7 + 7;

            calWorkSchedule.MaximumViewDays = days + 49;

            calWorkSchedule.ViewStart = new DateTime(2021, 2, 1);
            calWorkSchedule.ViewEnd = new DateTime(2021, 2, 7);

            // ------

            loadStyleComponents();
            loadEverything();

        }

        public void loadEverything()
        {
            refresh();

            loadHolidays();

            homeCustomCalendarScreen.loadCalendarData();
            workCustomCalendarScreen.loadCalendarData();
            leaveCustomCalendarScreen.loadCalendarData();

            homeCustomCalendarScreen.updateDetailCalendarItems();
            workCustomCalendarScreen.updateDetailCalendarItems();
            leaveCustomCalendarScreen.updateDetailCalendarItems();

            refreshTimer.Enabled = true;
        }

        private void loadHolidays()
        {
            holidaysList = googleCalendar.holidaysCalendar.getEvents();
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
            cbCalendarPerspective.Items.Add("6 maanden");
            cbCalendarPerspective.SelectedIndex = 4;
            cbCalendarPerspective.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (Work.Status status in Enum.GetValues(typeof(Work.Status))) cbStatus.Items.Add(status);
            cbStatus.SelectedIndex = 0;

            nuHoursDone.Maximum = 0;

        }

        #endregion

        #region CalendarSynchronizationFunctions

        public void refresh()
        {
            testConnection();
            loadTechniciansWorkWeek();
            loadWork();
            loadTechnicianLeave();
            loadExtraCalendar();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {

            if (focussed) unfocusCounter = 0;
            else if (unfocusCounter < 10)
                unfocusCounter++;

            if (unfocusCounter < 10)
            {
                try
                {
                    syncAllCalendars();
                }
                catch
                {
                    refreshTimer.Enabled = false;
                    MessageBox.Show("Er is iets fout gelopen tijdens het synchroniseren van de agenda.");
                    refreshTimer.Enabled = true;
                }
            }

        }

        // Can be more efficient
        // TODO: Update correctly when changing dates
        public void syncAllCalendars()
        {
            syncWorkCalendar();
            syncLeaveCalendar();
            syncTechnicianCalendar();
            syncExtraCalendar();
        }

        public void syncTechnicianCalendar()
        {
            IList<Google.Apis.Calendar.v3.Data.Event> syncList = googleCalendar.technicianCalendar.sync();
            if (syncList != null)
            {

                foreach (Google.Apis.Calendar.v3.Data.Event item in syncList)
                {
                    // Can happen:
                    // - date changed
                    // - name (summary) changed
                    // - delete
                    // - create

                    // Find the item
                    bool found = false;
                    foreach (CustomDay day in techniciansWorkWeekList)
                    {
                        foreach (Technician tech in day.getTechnicianList())
                        {
                            if (tech.getCalendarEvent().Id == item.Id)
                            {
                                // Item found
                                found = true;

                                if (item.Summary == null)
                                {
                                    // Item deleted
                                    day.getTechnicianList().Remove(tech);
                                }
                                else
                                {
                                    // Item edited
                                    day.getTechnicianList().Remove(tech);
                                    addTechnicianWorkWeekItem(item);
                                }

                                break;
                            }
                        }

                        if (found) break;
                    }

                    if (!found)
                    {
                        // New item created
                        addTechnicianWorkWeekItem(item);
                    }

                }

                // Can be more efficient
                loadTechnicianScheduleScreen();
                homeCustomCalendarScreen.loadCalendarData();

            }
        }

        public void syncWorkCalendar()
        {
            IList<Google.Apis.Calendar.v3.Data.Event> syncList = googleCalendar.workCalendar.sync();
            if (syncList != null)
            {

                foreach (Google.Apis.Calendar.v3.Data.Event item in syncList)
                {
                    // Can happen:
                    // - date changed
                    // - name (summary) changed
                    // - delete
                    // - create

                    // Find the item
                    bool found = false;
                    foreach (CustomDay day in workList)
                    {
                        foreach (Work work in day.getWorkList())
                        {
                            if (work.getCalendarEvent().Id == item.Id)
                            {
                                // Item found
                                found = true;

                                if (item.Summary == null)
                                {
                                    // Item deleted
                                    day.getWorkList().Remove(work);
                                }
                                else
                                {
                                    // Item edited
                                    day.getWorkList().Remove(work);
                                    addWorkItem(item);
                                }

                                break;
                            }
                        }

                        if (found) break;
                    }

                    if (!found)
                    {
                        // New item created
                        addWorkItem(item);
                    }

                }

                // Can be more efficient
                workCustomCalendarScreen.loadCalendarData();
                homeCustomCalendarScreen.loadCalendarData();

            }
        }

        public void syncLeaveCalendar()
        {
            IList<Google.Apis.Calendar.v3.Data.Event> syncList = googleCalendar.leaveCalendar.sync();
            if (syncList != null)
            {

                foreach (Google.Apis.Calendar.v3.Data.Event item in syncList)
                {
                    // Can happen:
                    // - date changed
                    // - name (summary) changed
                    // - delete
                    // - create

                    // Find the item
                    bool found = false;
                    foreach (CustomDay day in technicianLeaveList)
                    {
                        foreach (Technician tech in day.getTechnicianList())
                        {
                            if (tech.getCalendarEvent().Id == item.Id)
                            {
                                // Item found
                                found = true;

                                if (item.Summary == null)
                                {
                                    // Item deleted
                                    day.getTechnicianList().Remove(tech);
                                }
                                else
                                {
                                    // Item edited
                                    day.getTechnicianList().Remove(tech);
                                    addLeaveItem(item);
                                }

                                break;
                            }
                        }

                        if (found) break;
                    }

                    if (!found)
                    {
                        // New item created
                        addLeaveItem(item);
                    }

                }

                // Can be more efficient
                leaveCustomCalendarScreen.loadCalendarData();
                homeCustomCalendarScreen.loadCalendarData();

            }
        }

        public void syncExtraCalendar()
        {
            IList<Google.Apis.Calendar.v3.Data.Event> syncList = googleCalendar.extraCalendar.sync();
            if (syncList != null)
            {

                foreach (Google.Apis.Calendar.v3.Data.Event item in syncList)
                {
                    // Can happen:
                    // - date changed
                    // - name (summary) changed
                    // - delete
                    // - create

                    // Find the item
                    bool found = false;

                    foreach(Google.Apis.Calendar.v3.Data.Event extraItem in extraEventsList)
                    {
                        if (extraItem.Id == item.Id)
                        {
                            // Item found
                            found = true;

                            if (item.Summary == null)
                            {
                                // Item deleted
                                extraEventsList.Remove(extraItem);
                            }
                            else
                            {
                                // Item edited
                                extraEventsList.Remove(extraItem);
                                extraEventsList.Add(item);
                            }

                            break;
                        }
                    }

                    if (!found)
                    {
                        // New item created
                        extraEventsList.Add(item);
                    }

                }

                // Can be more efficient
                homeCustomCalendarScreen.loadCalendarData();

            }
        }


        #endregion

        #region LoadCalendarFunctions

        // Can be more efficient
        private void loadTechniciansWorkWeek()
        {
            if (techniciansWorkWeekList == null) techniciansWorkWeekList = new List<CustomDay>();
            techniciansWorkWeekList.Clear();

            if (technicianList == null) technicianList = new List<Technician>();
            technicianList.Clear();

            for (int i = 1; i <= 7; i++) techniciansWorkWeekList.Add(new CustomDay(new DateTime(2021, 2, i)));

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.technicianCalendar.getEvents())
            {
                addTechnicianWorkWeekItem(item);
            }

            loadTechnicianScheduleScreen();

        }

        private void loadTechnicianScheduleScreen()
        {
            calWorkSchedule.Items.Clear();

            foreach (CustomDay day in techniciansWorkWeekList)
            {
                foreach (Technician tech in day.getTechnicianList())
                {
                    CalendarItem newItem = new CalendarItem(calWorkSchedule,
                        day.getDate(),
                        day.getDate().AddDays(1).AddSeconds(-1),
                        tech.ToString());

                    newItem.setCalendarEvent(tech.getCalendarEvent());

                    calWorkSchedule.Items.Add(newItem);
                }
            }
        }

        private void addTechnicianWorkWeekItem(Google.Apis.Calendar.v3.Data.Event item)
        {
            DateTime date = Convert.ToDateTime(item.Start.Date);
            if (date.Day > 7) return;

            if (checkTitleWithRegex(item, "^[a-zA-Z ]+ [0-9,.]+u$", true))
            {
                CustomDay day = techniciansWorkWeekList[date.Day - 1];

                Technician tech = new Technician(item.Summary, true);
                tech.setCalendarEvent(item);
                day.addTechnicianList(tech);

                Technician technician = new Technician(tech.getName());
                if (!technicianList.Contains(technician)) technicianList.Add(technician);
            }
        }

        private void loadTechnicianLeave(Boolean askForTitleChange = false)
        {
            if (technicianLeaveList == null) technicianLeaveList = new List<CustomDay>();
            technicianLeaveList.Clear();

            if (workList != null)
            {
                foreach (CustomDay day in workList)
                {
                    foreach (Technician tech in day.getTechnicianList())
                    {
                        tech.setHasLeave(false);
                    }
                }
            }

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.leaveCalendar.getEvents())
            {
                addLeaveItem(item);
            }

        }

        private void addLeaveItem(Google.Apis.Calendar.v3.Data.Event item)
        {

            DateTime date;
            if (item.Start.DateTime != null)
            {
                date = (DateTime)item.Start.DateTime;
                date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            }
            else
            {
                date = Convert.ToDateTime(item.Start.Date);
            }

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

            Technician tech = new Technician(item);
            day.addTechnicianList(tech);
        }

        // No support for non all-day and multiple days events yet
        private void loadWork()
        {
            if (workList == null) workList = new List<CustomDay>();
            workList.Clear();

            if (openWorkHoursList == null) openWorkHoursList = new List<Tuple<DateTime, String, Decimal>>();
            openWorkHoursList.Clear();

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.workCalendar.getEvents())
            {
                addWorkItem(item);
            }

            if (nuWrongTitles.Value > 0)
            {
                MessageBox.Show("Er zijn " + nuWrongTitles.Value.ToString() + " titels fout.");
            }

        }

        // Work.Status.onderdelen_niet_op_tijd ook voor availability?
        // Can be more efficient
        private void addWorkItem(Google.Apis.Calendar.v3.Data.Event item)
        {

            DateTime date;
            if (item.Start.DateTime != null)
            {
                date = (DateTime)item.Start.DateTime;
                date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            }
            else
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

                workList.Add(day);
            }

            if (checkTitleMessageBox(item, false))
            {
                Work new_work = new Work(item);
                day.addWorkList(new_work);
                if (new_work.getStatus() == Work.Status.bezig ||
                    date <= DateTime.Now &&
                    new_work.isWorkOpen())
                    openWorkHoursList.Add(new Tuple<DateTime, string, Decimal>(date, new_work.getId(), new_work.getDuration() - new_work.getHoursDone()));
            }
            else
            {
                addWrongTitles(item);
            }

        }

        private void loadExtraCalendar()
        {
            extraEventsList = googleCalendar.extraCalendar.getEvents();
        }

        #endregion

        // TODO
        #region ExtraPrimaryFunctions

        public bool deleteWorkItem(String eventId)
        {
            return googleCalendar.workCalendar.deleteEvent(eventId);
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

        public List<DateTime> checkAvailability(Decimal duration)
        {
            List<DateTime> results = new List<DateTime>();

            DateTime date = DateTime.Today.StartOfWeek(DayOfWeek.Monday);
            Decimal hoursTally = 0;

            openWorkHoursList.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            foreach (Tuple<DateTime, String, Decimal> item in openWorkHoursList)
            {
                if (item.Item1 >= date)
                {
                    break;
                }
                hoursTally -= item.Item3;
            }

            while (results.Count < 3)
            {
                hoursTally += techHoursAvailable(date);
                hoursTally -= workHoursOnDay(date);

                if (hoursTally <= int.MinValue) break;

                if (hoursTally >= duration)
                {
                    results.Add(date);
                    hoursTally = 0; // ???
                }

                date = date.AddDays(1);
            }

            return results;
        }

        private Decimal techHoursAvailable(DateTime date)
        {
            Decimal hoursTally = 0;

            IEnumerable<CustomDay> workDays = techniciansWorkWeekList.Where(x => x.getDate().DayOfWeek.Equals(date.DayOfWeek));
            if (workDays.Count() > 0)
            {
                List<Technician> techs = workDays.First().getTechnicianList();
                foreach (Technician tech in techs)
                {
                    hoursTally += tech.getHours();
                }
            }

            IEnumerable<CustomDay> leaveDays = technicianLeaveList.Where(x => x.getDate().Equals(date));
            if (leaveDays.Count() > 0)
            {
                List<Technician> techLeaves = leaveDays.First().getTechnicianList();
                foreach (Technician tech in techLeaves)
                {
                    hoursTally -= tech.getHours();
                }
            }

            return hoursTally;
        }

        // TODO: check if work isn't already done
        private Decimal workHoursOnDay(DateTime date)
        {
            Decimal hoursTally = 0;

            IEnumerable<CustomDay> days = workList.Where(x => x.getDate().Equals(date));
            if (days.Count() > 0)
            {
                List<Work> workHours = days.First().getWorkList();
                foreach (Work work in workHours)
                {
                    if (work.isWorkOpen()) hoursTally += work.getDuration() - work.getHoursDone();
                }
            }

            return hoursTally;
        }

        public List<Work> getWorkWithNoAvailableComponents(DateTime start, DateTime end)
        {
            List<Work> results = new List<Work>();

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                IEnumerable<CustomDay> workDays = workList.Where(x => x.getDate().Year.Equals(date.Year) && x.getDate().Month.Equals(date.Month) && x.getDate().Day.Equals(date.Day));

                if (workDays.Count() > 0)
                {
                    List<Work> works = workDays.First().getWorkList();
                    foreach (Work work in works)
                    {
                        if (!work.isWorkReady())
                        {
                            results.Add(work);
                        }
                    }
                }
            }

            return results;
        }

        public List<Work> getWorkWithComponentsORCamperNotInTime()
        {
            List<Work> results = new List<Work>();

            foreach (CustomDay day in workList)
            {
                foreach (Work work in day.getWorkList())
                {
                    if (work.getStatus() == Work.Status.onderdelen_niet_op_tijd ||
                        !work.isWorkReady() && day.getDate() < DateTime.Now)
                        results.Add(work);
                }
            }

            return results;
        }

        public List<Work> getWorkNotFinished()
        {
            List<Work> results = new List<Work>();

            foreach (Tuple<DateTime, String, Decimal> work in openWorkHoursList)
            {
                IEnumerable<CustomDay> workDayList = workList.Where(x => x.getDate().Equals(work.Item1));
                if (workDayList.Count() > 0)
                {
                    IEnumerable<Work> works = workDayList.First().getWorkList().Where(x => x.getId().Equals(work.Item2));
                    if (works.Count() > 0)
                        results.Add(works.First());
                }
            }

            return results;
        }

        public List<Work> getWorkNoHours()
        {
            List<Work> results = new List<Work>();

            foreach (CustomDay day in workList)
            {
                foreach (Work work in day.getWorkList())
                {
                    if (work.getDuration() <= 0 &&
                        (day.getDate() >= DateTime.Now || (!work.isWorkReady() || work.getStatus() == Work.Status.bezig)))
                        results.Add(work);
                }
            }

            return results;
        }

        public List<CustomDay> getWorkBetweenDates(DateTime startDate, DateTime endDate)
        {
            List<CustomDay> results = new List<CustomDay>();

            foreach (Tuple<DateTime, String, Decimal> work in openWorkHoursList)
            {

                CustomDay customDay = new CustomDay(work.Item1);
                if (results.Contains(customDay))
                {
                    customDay = results.Where(x => x.getDate().Year.Equals(work.Item1.Year) && x.getDate().Month.Equals(work.Item1.Month) && x.getDate().Day.Equals(work.Item1.Day)).First();
                }
                else
                {
                    results.Add(customDay);
                }

                IEnumerable<CustomDay> workDayList = workList.Where(x => x.getDate().Equals(work.Item1));
                if (workDayList.Count() > 0)
                {
                    IEnumerable<Work> works = workDayList.First().getWorkList().Where(x => x.getId().Equals(work.Item2));
                    if (works.Count() > 0)
                        customDay.addWorkList(works.First());
                }

            }

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                IEnumerable<CustomDay> days = workList.Where(x => x.getDate().Year.Equals(date.Year) && x.getDate().Month.Equals(date.Month) && x.getDate().Day.Equals(date.Day));

                if (days.Count() > 0)
                {
                    CustomDay customDay = days.First();

                    foreach (Technician tech in techniciansWorkWeekList[customDay.getDate().DayOfWeekStartingMonday()].getTechnicianList())
                    {
                        IEnumerable<CustomDay> techLeaveList = technicianLeaveList.Where(x => x.getDate().Date <= date);
                        if (techLeaveList.Count() == 0)
                            customDay.addTechnicianList(tech);
                        else
                        {
                            foreach (CustomDay techDay in techLeaveList)
                            {
                                //techDay.getTechnicianList().Where(x => x.getCalendarEvent());
                            }
                        }
                    }

                    results.Add(customDay);
                }

            }

            return results;
        }

        #endregion

        // TODO
        #region ExtraSecondaryFunctions

        // TODO: Change this to be completely implemented in work class
        private bool checkTitleMessageBox(Google.Apis.Calendar.v3.Data.Event item, Boolean askForTitleChange)
        {
            if (!askForTitleChange) return new Work().check_title(item.Summary);
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
                        if (!googleCalendar.workCalendar.editEvent(item))
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

        private bool checkTitleWithRegex(Google.Apis.Calendar.v3.Data.Event item, String regexString, Boolean trueForScheduleFalseForLeave, Boolean askForTitleChange = true)
        {
            Regex regex = new Regex(regexString, RegexOptions.IgnoreCase);

            if (!askForTitleChange)
                return regex.IsMatch(item.Summary);

            if (!regex.IsMatch(item.Summary))
            {
                while (true)
                {
                    String new_title;

                    if (trueForScheduleFalseForLeave)
                        new_title = Microsoft.VisualBasic.Interaction.InputBox("Please change the title.", "Wrong schedule event title", item.Summary);
                    else
                        new_title = Microsoft.VisualBasic.Interaction.InputBox("Please change the title.", "Wrong leave event title", item.Summary);

                    if (!new_title.Equals("") && new_title != null)
                    {
                        if (!regex.IsMatch(new_title))
                        {
                            MessageBox.Show("The new title is still incorrect.");
                            continue;
                        }
                        item.Summary = new_title;
                        if (trueForScheduleFalseForLeave)
                        {
                            if (!googleCalendar.technicianCalendar.editEvent(item))
                            {
                                MessageBox.Show("Something went wrong when updating event to calendar.");
                                return false;
                            }
                            else return true;
                        }
                        else if (!trueForScheduleFalseForLeave)
                        {
                            if (!googleCalendar.leaveCalendar.editEvent(item))
                            {
                                MessageBox.Show("Something went wrong when updating event to calendar.");
                                return false;
                            }
                            else return true;
                        }

                        //return true;
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

            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.workCalendar.getEvents())
            {
                if (item.Id.Equals(id)) return item;
            }
            return null;
        }

        private void newDayTimer_Tick(object sender, EventArgs e)
        {
            loadEverything();
        }

        #endregion

        #region SecondaryScreensFunctions

        public void clear_calendar_screen()
        {
            calendarEventScreen = null;
            syncWorkCalendar();
        }

        public void clear_extra_calendar_screen()
        {
            extraEventScreen = null;
            syncExtraCalendar();
        }

        public void clear_search_screen()
        {
            searchScreen = null;
        }

        public Boolean getCalendarScreenAlreadyOpen()
        {
            return this.calendarEventScreen != null;
        }

        public void openCalendarScreen(Google.Apis.Calendar.v3.Data.Event item, fPlanning planningScreen = null)
        {
            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this, item, planningScreen);
                calendarEventScreen.Show();
            }
        }

        public void openCalendarScreen_createItem(DateTime date)
        {
            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this, date);
                calendarEventScreen.Show();
            }
        }

        public void openCalendarScreen_editItem(Google.Apis.Calendar.v3.Data.Event item)
        {
            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this, item);
                calendarEventScreen.Show();
            }
        }

        public void openLeaveScreen_createItem(DateTime date)
        {
            if (leaveEventScreen == null)
            {
                leaveEventScreen = new fLeaveEvent(this, null, date);
                leaveEventScreen.Show();
            }
        }

        public void openLeaveScreen_editItem(Google.Apis.Calendar.v3.Data.Event item)
        {
            if (leaveEventScreen == null)
            {
                leaveEventScreen = new fLeaveEvent(this, item);
                leaveEventScreen.Show();
            }
        }

        public void openExtraScreen_createItem(DateTime date)
        {
            if (extraEventScreen == null)
            {
                extraEventScreen = new fExtraEvent(this, null, date);
                extraEventScreen.Show();
            }
        }

        public void openExtraScreen_editItem(Google.Apis.Calendar.v3.Data.Event item)
        {
            if (extraEventScreen == null)
            {
                extraEventScreen = new fExtraEvent(this, item);
                extraEventScreen.Show();
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

        public void clearPlanningScreen()
        {
            planningScreen = null;
        }

        public void lbWrongTitles_SizeChanged()
        {
            nuWrongTitles.Value = lbWrongTitles.Items.Count;
        }

        private void fHome_Resize(object sender, EventArgs e)
        {
            if (homeCustomCalendarScreen != null)
                homeCustomCalendarScreen.resize();
            if (workCustomCalendarScreen != null)
                workCustomCalendarScreen.resize();
            if (leaveCustomCalendarScreen != null)
                leaveCustomCalendarScreen.resize();

            lbWrongTitles.Height = this.Height - convert_pixel_coordinates(162, true);
            lbWrongTitles.Width = this.Width - gbWrongTitlesControl.Width - convert_pixel_coordinates(66, false);

            gbWrongTitlesControl.Location = new System.Drawing.Point(this.Width - gbWrongTitlesControl.Width - convert_pixel_coordinates(40, false), gbWrongTitlesControl.Location.Y);

        }

        private void updateNUTechHours()
        {
            nuHoursDone.Maximum = nuHours.Value;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (wrongTitleSelected == null) return;

            DialogResult answer = MessageBox.Show("Weet je zeker dat je het agenda item wilt verwijderen?", "Opgelet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                if (deleteWorkItem(wrongTitleSelected.Id))
                {
                    clearWrongTitlesControl();
                }
                else
                {
                    MessageBox.Show("Er is iets fout gelopen.");
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (wrongTitleSelected == null) return;

            Work work = new Work();
            work.updateValues(wrongTitleSelected, false);

            work.setStatus((Work.Status)cbStatus.SelectedItem);
            work.setDuration(nuHours.Value);
            work.setClientName(tbClientName.Text);
            work.setPhoneNumber(tbPhoneNumber.Text);
            work.setOrderNumber(tbOrderNumber.Text);
            work.setDescription(rtbDescription.Text);
            work.setHoursDone(nuHoursDone.Value);

            if (!work.checkValues()) return;

            work.updateCalendarEvent();

            if (googleCalendar.workCalendar.editEvent(work.getCalendarEvent()))
            {
                clearWrongTitlesControl();
                syncWorkCalendar();
            }
            else
            {
                MessageBox.Show("Something went wrong when updating the event to the calendar.");
            }
        }

        public void addWrongTitles(Google.Apis.Calendar.v3.Data.Event item)
        {
            lbWrongTitles.Items.Add(new WrongTitleObject(item));
            lbWrongTitles_SizeChanged();
        }

        public void removeWrongTitles(String id)
        {
            foreach (WrongTitleObject wrongTitleObject in lbWrongTitles.Items)
            {
                if (wrongTitleObject.getId().Equals(id))
                {
                    lbWrongTitles.Items.Remove(wrongTitleObject);
                    lbWrongTitles_SizeChanged();
                    return;
                }
            }
        }

        public void loadWrongTitlesControl()
        {
            WrongTitleObject wrongTitleObject = (WrongTitleObject)lbWrongTitles.SelectedItem;

            if (wrongTitleObject == null) return;

            wrongTitleSelected = wrongTitleObject.getEvent();

            tbOldTitle.Text = wrongTitleObject.getEvent().Summary;

            Work work = new Work();
            work.updateValues(wrongTitleObject.getEvent(), false);

            cbStatus.SelectedItem = work.getStatus();
            nuHours.Value = work.getDuration();
            tbClientName.Text = work.getClientName();
            tbPhoneNumber.Text = work.getPhoneNumber();
            tbOrderNumber.Text = work.getOrderNumber();
            rtbDescription.Text = work.getDescription();
            nuHoursDone.Maximum = nuHours.Value;
            nuHoursDone.Value = work.getHoursDone();
        }

        public void clearWrongTitlesControl()
        {

            wrongTitleSelected = null;

            tbOldTitle.Text = null;
            cbStatus.SelectedItem = null;
            nuHours.Value = 0;
            tbClientName.Text = null;
            tbPhoneNumber.Text = null;
            tbOrderNumber.Text = null;
            rtbDescription.Text = null;
            nuHoursDone.Maximum = 0;
            nuHoursDone.Value = 0;
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
                    googleCalendar.setPerspectiveMonths(5);
                    break;
                case 5:
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

        private void planningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planningScreen == null)
            {
                planningScreen = new fPlanning(this);
                planningScreen.Show();
            }
        }

        private void lbWrongTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadWrongTitlesControl();
        }

        private void nuHours_ValueChanged(object sender, EventArgs e)
        {
            updateNUTechHours();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            clearWrongTitlesControl();
        }

        #endregion

        #region Getters

        public List<Technician> getTechnicianList()
        {
            return technicianList;
        }

        public int getLastOpenedIndex()
        {
            return lastOpenedIndex;
        }

        #endregion

        #region Setters

        public void setLastOpenedIndex(int lastOpenedIndex)
        {
            this.lastOpenedIndex = lastOpenedIndex;
        }

        #endregion

        private void fHome_Activated(object sender, EventArgs e)
        {
            focussed = true;
            if (calendarEventScreen != null)
                calendarEventScreen.Focus();
        }

        private void fHome_Deactivate(object sender, EventArgs e)
        {
            focussed = false;
        }

        public void closeScheduleScreen()
        {
            scheduleScreen = null;
            syncTechnicianCalendar();
        }

        private void calWorkSchedule_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            if (scheduleScreen == null)
            {
                fTechSchedule techSchedule = new fTechSchedule(this, e.Item.Date.DayOfWeekStartingMonday(), e.Item.getCalendarEvent());
                scheduleScreen = techSchedule;
                scheduleScreen.Show();
            }
        }

        public Boolean deleteTechSchedule(string eventID)
        {
            return googleCalendar.technicianCalendar.deleteEvent(eventID);
        }

        public Boolean updateTechSchedule(Google.Apis.Calendar.v3.Data.Event newEvent)
        {
            return googleCalendar.technicianCalendar.editEvent(newEvent);
        }

        public Boolean createTechSchedule(Google.Apis.Calendar.v3.Data.Event newEvent)
        {
            return googleCalendar.technicianCalendar.addEvent(newEvent);
        }

        private void calWorkSchedule_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            e.Cancel = true;
            if (scheduleScreen == null)
            {
                fTechSchedule techSchedule = new fTechSchedule(this, e.Item.Date.DayOfWeekStartingMonday());
                scheduleScreen = techSchedule;
                scheduleScreen.Show();
            }
        }

        public Tuple<DateTime, DateTime> convertEventDateTime(Google.Apis.Calendar.v3.Data.Event calendarEvent)
        {
            DateTime startDate;
            if (calendarEvent.Start.DateTime != null)
            {
                startDate = (DateTime)calendarEvent.Start.DateTime;
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0);
            }
            else
            {
                startDate = Convert.ToDateTime(calendarEvent.Start.Date);
            }
            DateTime endDate;
            if (calendarEvent.End.DateTime != null)
            {
                endDate = (DateTime)calendarEvent.End.DateTime;
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0, 0);
            }
            else
            {
                endDate = Convert.ToDateTime(calendarEvent.End.Date);
            }
            return Tuple.Create(startDate, endDate);
        }

        public void closeLeaveEventScreen()
        {
            leaveEventScreen = null;
            syncLeaveCalendar();
        }

        public Boolean deleteLeaveEvent(string eventID)
        {
            return googleCalendar.leaveCalendar.deleteEvent(eventID);
        }

        public Boolean deleteExtraEvent(string eventID)
        {
            return googleCalendar.extraCalendar.deleteEvent(eventID);
        }

        public Boolean updateLeaveEvent(Google.Apis.Calendar.v3.Data.Event newEvent)
        {
            return googleCalendar.leaveCalendar.editEvent(newEvent);
        }

        public Boolean addLeaveEvent(Google.Apis.Calendar.v3.Data.Event newEvent)
        {
            return googleCalendar.leaveCalendar.addEvent(newEvent);
        }

        public Boolean updateExtraEvent(Google.Apis.Calendar.v3.Data.Event newEvent)
        {
            return googleCalendar.extraCalendar.editEvent(newEvent);
        }

        public Boolean addExtraEvent(Google.Apis.Calendar.v3.Data.Event newEvent)
        {
            return googleCalendar.extraCalendar.addEvent(newEvent);
        }

        // TODO: wtf is s?
        private void s_Click(object sender, EventArgs e)
        {
            loadTechnicianLeave(true);
            leaveCustomCalendarScreen.loadCalendarData();
        }

        private void fHome_Shown(object sender, EventArgs e)
        {
            fHome_Resize(sender, e);
        }

        public int convert_pixel_coordinates(int pixel_coordinate_144px, bool is_height = false)
        {
            if (is_height)
                return (int)(pixel_coordinate_144px * this.CreateGraphics().DpiY / 144);
            else
                return (int)(pixel_coordinate_144px * this.CreateGraphics().DpiX / 144);
        }

    }

    #region ExtraObjects

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

        public static String customToString(this DateTime dt)
        {
            return dt.DayOfWeek.ToString() + " " + dt.Day.ToString() + " " + dt.ToString("MMMM");
        }

        public static int DayOfWeekStartingMonday(this DateTime dt)
        {
            int customDayOfWeek = (int)dt.Date.DayOfWeek - 1;
            if (customDayOfWeek == -1) customDayOfWeek = 6;
            return customDayOfWeek;
        }

    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }

        public static string CapitalizeFirst(this string input)
        {
            return char.ToUpper(input[0]) + input[1..];
        }

        public static string CapitalizeAll(this string input)
        {
            var words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CapitalizeFirst(words[i]);
            }

            return string.Join(' ', words);
        }

    }

    public class WrongTitleObject
    {
        private Google.Apis.Calendar.v3.Data.Event eventItem;

        public WrongTitleObject(Google.Apis.Calendar.v3.Data.Event item)
        {
            eventItem = item;
        }

        public String getId()
        {
            return eventItem.Id;
        }

        public Google.Apis.Calendar.v3.Data.Event getEvent()
        {
            return eventItem;
        }

        public override string ToString()
        {
            return eventItem.Summary.ToString();
        }

    }

    #endregion


}