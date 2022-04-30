using JugaAgenda_v2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //TODO Edit work event, Add work event, Edit Leave, Add Leave, Edit Schedule, Add schedule, Search function

        public fHome()
        {
            InitializeComponent();

            googleCalendar = new GoogleCalendar();

            mvHome.SelectionStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday).Date;
            mvHome.SelectionEnd = DateTime.Now.EndOfWeek(DayOfWeek.Sunday);
            mvHome.MaxSelectionCount = calHome.MaximumViewDays;

            mvHome.SelectionChanged += new System.EventHandler(mvHome_SelectionChanged);

            calHome.TimeScale = CalendarTimeScale.SixtyMinutes;

            loadEverything();

        }

        public void loadEverything()
        {
            refresh();

            mvHome_SelectionChanged(null, null);
        }

        public void refresh()
        {
            testConnection();
            loadTechniciansWorkWeek();
            loadTechnicianLeave();
            loadWork();
        }

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
            
            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getWorkEvents().Items)
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

                    foreach (Technician tech in techniciansWorkWeekList[(int) date.DayOfWeek].getTechnicianList())
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
                        MessageBox.Show("Please change the title.");
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        private void testConnection(bool print_if_successfull=false)
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
                } else
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
                    calHome.ViewStart = mvHome.SelectionStart;
                    calHome.ViewEnd = mvHome.SelectionEnd;
                }
                else
                {
                    calHome.ViewEnd = mvHome.SelectionEnd;
                    calHome.ViewStart = mvHome.SelectionStart;
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

            } else
            {
                MessageBox.Show("The selection has to be at least 1 day and can't be more than " + calHome.MaximumViewDays.ToString() + " days.");
            }
            

        }

        // TODO
        private void calHome_ItemDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(calHome.GetSelectedItems().First().Text.ToString());
            

            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this, calHome.GetSelectedItems().First().getCalendarEvent());
                calendarEventScreen.Show();
            }

        }

        public void clear_calendar_screen()
        {
            calendarEventScreen = null;
        }

        #region SimpleButtonFunctions
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Manual;
        }

        private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Day;
        }

        private void workweekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.WorkWeek;
        }

        private void weekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Week;
        }

        private void monthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month;
        }

        private void fiveMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FiveMinutes;
        }

        private void sixMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixMinutes;
        }

        private void tenMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.TenMinutes;
        }

        private void fifteenMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FifteenMinutes;
        }

        private void thirtyMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.ThirtyMinutes;
        }

        private void sixtyMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
        }

        private void btTestGoogleConnection_Click(object sender, EventArgs e)
        {
            testConnection(true);
        }
        private void oneMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            googleCalendar.setPerspectiveMonths(1);
        }
        private void twoMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            googleCalendar.setPerspectiveMonths(2);
        }
        private void threeMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            googleCalendar.setPerspectiveMonths(3);
        }
        private void fourMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            googleCalendar.setPerspectiveMonths(4);
        }
        private void sixMonthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            googleCalendar.setPerspectiveMonths(6);
        }
        private void addWorkEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (calendarEventScreen == null)
            {
                calendarEventScreen = new fCalendarEvent(this);
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

}
