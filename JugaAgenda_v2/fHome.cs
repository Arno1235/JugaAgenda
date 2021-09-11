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

namespace JugaAgenda_v2
{

    public partial class fHome : Form
    {

        public GoogleCalendar googleCalendar;
        private List<Technician> technicianList;
        private List<CustomDay> techniciansWorkWeekList;
        private List<CustomDay> workList;
        private List<CustomDay> technicianLeaveList;
        private fCalendarEvent calendarEventScreen = null;

        //TODO Search function!

        public fHome()
        {
            InitializeComponent();

            googleCalendar = new GoogleCalendar();

            mvHome.SelectionStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday).Date;
            mvHome.SelectionEnd = DateTime.Now.EndOfWeek(DayOfWeek.Sunday);
            mvHome.MaxSelectionCount = calHome.MaximumViewDays;
            this.mvHome.SelectionChanged += new System.EventHandler(this.mvHome_SelectionChanged);

            calHome.TimeScale = CalendarTimeScale.SixtyMinutes;

            loadEverything();

        }

        private void loadEverything()
        {
            testConnection(false);
            loadTechnicians();
            loadTechniciansWorkWeek();
            //loadWork();
            //loadTechnicianLeave();

            checkWorkEvents();
        }

        private void loadTechnicians()
        {
            technicianList = new List<Technician>();
            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getTechnicianEvents().Items)
            {
                String new_name = item.Summary.Split(' ')[0];
                bool exists = false;
                foreach (Technician tech in technicianList)
                {
                    if (tech.getName().Equals(new_name)) exists = true;
                }
                if (!exists) technicianList.Add(new Technician(new_name));
            }
        }
        // TODO: check title name + check if tech exists
        private void loadTechniciansWorkWeek()
        {
            techniciansWorkWeekList = new List<CustomDay>();
            Google.Apis.Calendar.v3.Data.Events technicianEvents = googleCalendar.getTechnicianEvents();
            for (int i = 1; i <= 7; i++)
            {
                CustomDay new_day = new CustomDay(new DateTime(2021, 2, i));
                foreach (Google.Apis.Calendar.v3.Data.Event item in technicianEvents.Items)
                {
                    if (DateTime.Compare(Convert.ToDateTime(item.Start.Date), new_day.getDate()) == 0)
                    {
                        String tech_name = item.Summary.Split(' ')[0];
                        foreach (Technician tech in technicianList)
                        {
                            if (tech_name.Equals(tech.getName())) new_day.addTechnicianList(new Technician(tech_name, Convert.ToDecimal(item.Summary.Split(' ')[1].Split('u')[0].Replace('.', ','))));
                        }
                    }
                }
                techniciansWorkWeekList.Add(new_day);
            }
            /*foreach (CustomDay day in techniciansWorkWeekList)
            {
                foreach (Technician tech in day.getTechnicianList())
                {
                    MessageBox.Show(day.getDate().ToString() + tech.getName() + tech.getHours().ToString());
                }
            }*/
        }
        // TODO: check title format
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
                    workList.Add(day);
                }
                Work new_work = new Work(item.Summary.Split(' '), item.Description, (int) Convert.ToInt64(item.ColorId));
                day.addWorkList(new_work);
            }
            /*foreach (CustomDay day in workList)
            {
                foreach (Work work in day.getWorkList())
                {
                    MessageBox.Show(work.getClientName() + work.getDescription() + work.getDuration().ToString() + work.getOrderNumber() + work.getPhoneNumber() + work.getStatus().ToString());
                }
            }*/
        }

        private void checkWorkEvents()
        {
            foreach (Google.Apis.Calendar.v3.Data.Event item in googleCalendar.getWorkEvents().Items)
            {
                DateTime date;
                if (item.Start.DateTime != null)
                {
                    date = (DateTime)item.Start.DateTime;
                }
                else
                {
                    date = Convert.ToDateTime(item.Start.Date);
                }

                if (!new Work().check_title(item.Summary))
                {
                    while(true)
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
                            if (!googleCalendar.editWorkEvent(item, item.Id)) MessageBox.Show("Something went wrong when updating event to calendar.");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Please change the title.");
                            break;
                        }
                    }
                }
            }
        }

        private void loadTechnicianLeave()
        {

        }

        private void testConnection(bool print_if_successfull)
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

        // TODO
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

                foreach (Google.Apis.Calendar.v3.Data.Event eventItem in googleCalendar.getWorkEvents().Items)
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
                    } else
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
                }

            } else
            {
                MessageBox.Show("The selection has to be at least 1 day and can't be more than " + calHome.MaximumViewDays.ToString() + " days.");
            }
            

        }

        // TODO
        private void calHome_ItemDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(calHome.GetSelectedItems().ToList()[0].Text.ToString());
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
