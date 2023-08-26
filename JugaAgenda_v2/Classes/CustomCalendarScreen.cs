using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace JugaAgenda_v2.Classes
{
    public class CustomCalendarScreen
    {

        protected Calendar mainCalendarView;
        protected MonthView monthView;
        protected Calendar detailCalendarView;
        protected Button todayButton;

        protected fHome homeForm;

        protected Func<int, bool, int> convert_pixel_coordinates;

        private System.Drawing.Point prevMouseCoo;
        protected Boolean mouseMoved = false;
        private Boolean mouseDown = false;

        ToolTip calendarToolTip;

        private bool monthViewSelectionChanging = false;

        public CustomCalendarScreen(Calendar mainCalendarView, MonthView monthView, Calendar detailCalendarView, Button todayButton, fHome homeForm) {

            this.mainCalendarView = mainCalendarView;
            this.monthView = monthView;
            this.detailCalendarView = detailCalendarView;
            this.todayButton = todayButton;

            this.homeForm = homeForm;

            this.convert_pixel_coordinates = this.homeForm.convert_pixel_coordinates;

            this.initialize_style();
            this.add_event_handlers();

            this.loadCalendarData();

        }

        private void add_event_handlers()
        {
            this.monthView.SelectionChanged += new EventHandler(this.monthView_SelectionChanged);
            this.mainCalendarView.MouseDown += new MouseEventHandler(this.mainCalendarView_MouseDown);
            this.mainCalendarView.MouseMove += new MouseEventHandler(this.mainCalendarView_MouseMove);
            this.mainCalendarView.MouseUp += new MouseEventHandler(this.mainCalendarView_MouseUp);
            this.mainCalendarView.LoadItems += new Calendar.CalendarLoadEventHandler(this.mainCalendarView_LoadItems);
            this.mainCalendarView.ItemDoubleClick += new Calendar.CalendarItemEventHandler(this.mainCalendarView_ItemDoubleClick);
            this.todayButton.Click += new EventHandler(this.todayButton_Click);
            this.mainCalendarView.ItemCreating += new Calendar.CalendarItemCancelEventHandler(this.mainCalendarView_ItemCreating);
            this.mainCalendarView.ItemDatesChanged += new Calendar.CalendarItemEventHandler(this.maindCalendarView_ItemDatesChanged);
        }

        private void initialize_style()
        {

            int left_width = 320;
            this.todayButton.Width = left_width;
            this.monthView.Width = left_width;
            this.detailCalendarView.Width = left_width;

            this.todayButton.Location = new System.Drawing.Point(convert_pixel_coordinates(8, false), convert_pixel_coordinates(8, true));
            this.monthView.Location = new System.Drawing.Point(convert_pixel_coordinates(8, false), convert_pixel_coordinates(48, true));
            this.mainCalendarView.Location = new System.Drawing.Point(left_width + convert_pixel_coordinates(18, false), convert_pixel_coordinates(8, true));

            this.monthView.FirstDayOfWeek = DayOfWeek.Monday;
            this.mainCalendarView.FirstDayOfWeek = DayOfWeek.Monday;

            this.monthView.SelectionMode = MonthView.MonthViewSelection.Month;
            this.monthView.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.monthView.SelectionEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            
            this.mainCalendarView.MaximumViewDays = 70;
            this.monthView.MaxSelectionCount = this.mainCalendarView.MaximumViewDays;

            this.monthView_SelectionChanged(null, null);

            // TODO: bad code
            foreach (CalendarDay calDay in this.mainCalendarView.Days)
                if (calDay.Date == new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                {
                    this.mainCalendarView.SelectedElementStart = calDay;
                    this.mainCalendarView.SelectedElementEnd = calDay;
                    break;
                }

            this.loadCalendarData();

            this.updateDetailCalendarItems();

            calendarToolTip = new ToolTip();
            calendarToolTip.AutoPopDelay = 5000;
            calendarToolTip.InitialDelay = 1000;
            calendarToolTip.ReshowDelay = 500;
            calendarToolTip.ShowAlways = true;
            calendarToolTip.SetToolTip(this.mainCalendarView, null);

            this.resize();

        }

        public void resize()
        {
            this.mainCalendarView.Width = this.homeForm.Width - this.monthView.Width - convert_pixel_coordinates(64, false);
            this.mainCalendarView.Height = this.homeForm.Height - convert_pixel_coordinates(148, true);

            this.update_calDetail_monthView_height();
        }

        private void update_calDetail_monthView_height()
        {
            this.detailCalendarView.Height = (int)Math.Max(((this.detailCalendarView.Items.Count() + 1) * convert_pixel_coordinates(32, true)), convert_pixel_coordinates(300, true));
            this.detailCalendarView.Location = new System.Drawing.Point(this.detailCalendarView.Location.X, this.homeForm.Height - this.detailCalendarView.Height - convert_pixel_coordinates(142, true));

            this.monthView.Height = this.homeForm.Height - this.detailCalendarView.Height - convert_pixel_coordinates(200, true);
        }

        public void loadCalendarData()
        {
            monthView_SelectionChanged(null, null);
        }

        public virtual void loadCalendarData(DateTime start, DateTime end)
        {
            MessageBox.Show("Something went wrong. You have to override the loadCalendarData function!");
        }

        // TODO: Multiple days and not full days events
        private void monthView_SelectionChanged(object sender, EventArgs e)
        {

            this.monthViewSelectionChanging = true;
            if ((this.monthView.SelectionEnd - this.monthView.SelectionStart).Days > -1 && (this.monthView.SelectionEnd - this.monthView.SelectionStart).Days < this.mainCalendarView.MaximumViewDays)
            {
                int oldMaximumViewDays = this.mainCalendarView.MaximumViewDays;
                DateTime end;
                DateTime start;
                if (this.monthView.SelectionEnd > this.mainCalendarView.ViewEnd)
                {
                    end = this.monthView.SelectionEnd;
                }
                else
                {
                    end = this.mainCalendarView.ViewEnd;
                }
                if (this.monthView.SelectionStart < this.mainCalendarView.ViewStart)
                {
                    start = this.monthView.SelectionStart;
                }
                else
                {
                    start = this.mainCalendarView.ViewStart;
                }
                this.mainCalendarView.MaximumViewDays = (int)Math.Ceiling((double)(end - start).Days / 7) * 7 + 7;
                if (this.monthView.SelectionStart <= this.mainCalendarView.ViewEnd)
                {
                    if (this.monthView.SelectionMode == System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month)
                    {
                        this.mainCalendarView.ViewStart = this.monthView.SelectionStart.StartOfWeek(DayOfWeek.Monday);
                        this.mainCalendarView.ViewEnd = this.monthView.SelectionEnd.EndOfWeek(DayOfWeek.Sunday);
                    }
                    else
                    {
                        this.mainCalendarView.ViewStart = this.monthView.SelectionStart;
                        this.mainCalendarView.ViewEnd = this.monthView.SelectionEnd;
                    }

                }
                else
                {
                    if (this.monthView.SelectionMode == System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Month)
                    {
                        this.mainCalendarView.ViewEnd = this.monthView.SelectionEnd.EndOfWeek(DayOfWeek.Sunday);
                        this.mainCalendarView.ViewStart = this.monthView.SelectionStart.StartOfWeek(DayOfWeek.Monday);
                    }
                    else
                    {
                        this.mainCalendarView.ViewEnd = this.monthView.SelectionEnd;
                        this.mainCalendarView.ViewStart = this.monthView.SelectionStart;
                    }
                }
                this.mainCalendarView.MaximumViewDays = oldMaximumViewDays;

                this.loadCalendarData(start, end);

            }
            else
            {
                MessageBox.Show("The selection has to be at least 1 day and can't be more than " + this.mainCalendarView.MaximumViewDays.ToString() + " days. It is " + (this.monthView.SelectionEnd - this.monthView.SelectionStart).Days.ToString() + " days.");
            }
            this.monthViewSelectionChanging = false;

        }

        private void mainCalendarView_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            if (this.monthViewSelectionChanging)
                return;

            DateTime start = this.mainCalendarView.ViewStart;
            DateTime end = this.mainCalendarView.ViewEnd;

            this.mainCalendarView.SelectionStart = start;
            this.mainCalendarView.SelectionEnd = end;
        }

        private void updateDetailCalendarItems()
        {

            if (this.mainCalendarView.SelectedElementStart == null)
                return;

            this.detailCalendarView.Items.Clear();

            DateTime newDate = this.mainCalendarView.SelectedElementStart.Date;

            if (newDate < this.detailCalendarView.ViewStart)
            {
                this.detailCalendarView.MaximumViewDays = (int)Math.Ceiling((double)((this.detailCalendarView.ViewEnd - newDate).Days / 7)) * 7 + 7;
                this.detailCalendarView.ViewStart = newDate;
                this.detailCalendarView.ViewEnd = newDate;
            }
            else if (newDate > this.detailCalendarView.ViewEnd)
            {
                this.detailCalendarView.MaximumViewDays = (int)Math.Ceiling((double)((newDate - this.detailCalendarView.ViewStart).Days / 7)) * 7 + 7;
                this.detailCalendarView.ViewEnd = newDate;
                this.detailCalendarView.ViewStart = newDate;
            }
            else
            {
                this.detailCalendarView.ViewStart = newDate;
                this.detailCalendarView.ViewEnd = newDate;
            }

            foreach (CalendarItem calItem in this.mainCalendarView.Items)
            {
                if (calItem.StartDate <= newDate && calItem.EndDate >= newDate)
                {
                    this.detailCalendarView.Items.Add(new CalendarItem(this.detailCalendarView, calItem.StartDate, calItem.EndDate, calItem.Text));
                }
            }

            this.update_calDetail_monthView_height();

        }

        private void mainCalendarView_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.mouseMoved = false;
            this.prevMouseCoo = e.Location;
        }

        private void mainCalendarView_MouseMove(object sender, MouseEventArgs e)
        {

            if (!this.mouseMoved && this.mouseDown &&
                Math.Sqrt((Math.Pow(prevMouseCoo.X - e.X, 2) + Math.Pow(prevMouseCoo.Y - e.Y, 2))) > 20)
                mouseMoved = true;

            CalendarItem calItem = this.mainCalendarView.ItemAt(new System.Drawing.Point(e.X, e.Y));
            if (calItem == null)
                calendarToolTip.SetToolTip(this.mainCalendarView, null);
            else
                calendarToolTip.SetToolTip(this.mainCalendarView, calItem.Text + "\n" + calItem.getCalendarEvent().Description);

        }

        private void mainCalendarView_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;

            this.updateDetailCalendarItems();

        }

        public virtual void mainCalendarView_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            MessageBox.Show("Something went wrong. You have to override the mainCalendarView_ItemDoubleClick function!");
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            DateTime newSelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime newSelectionEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            int oldMaxSelectionCount = this.monthView.MaxSelectionCount;
            int oldMaxViewDays = this.mainCalendarView.MaximumViewDays;
            DateTime end;
            DateTime start;

            if (this.monthView.SelectionEnd > newSelectionEnd)
            {
                end = this.monthView.SelectionEnd;
            }
            else
            {
                end = newSelectionEnd;
            }
            if (this.monthView.SelectionStart < newSelectionStart)
            {
                start = this.monthView.SelectionStart;
            }
            else
            {
                start = newSelectionStart;
            }

            this.monthView.MaxSelectionCount = (end - start).Days + 7 - ((end - start).Days % 7);
            this.mainCalendarView.MaximumViewDays = (end - start).Days + 7 - ((end - start).Days % 7);

            if (this.monthView.SelectionEnd < newSelectionEnd)
            {
                this.monthView.SelectionEnd = newSelectionEnd;
                this.monthView.SelectionStart = newSelectionStart;
            }
            else
            {
                this.monthView.SelectionStart = newSelectionStart;
                this.monthView.SelectionEnd = newSelectionEnd;
            }

            this.monthView.ViewStart = newSelectionStart;

            this.monthView.MaxSelectionCount = oldMaxSelectionCount;
            this.mainCalendarView.MaximumViewDays = oldMaxViewDays;


            foreach (CalendarDay calDay in this.mainCalendarView.Days)
                if (calDay.Date == new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                {
                    this.mainCalendarView.SelectedElementStart = calDay;
                    this.mainCalendarView.SelectedElementEnd = calDay;
                    break;
                }

            this.mainCalendarView_MouseUp(null, null);
        }

        public virtual void mainCalendarView_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            MessageBox.Show("Something went wrong. You have to override the mainCalendarView_ItemCreating function!");
        }

        public virtual void maindCalendarView_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            MessageBox.Show("Something went wrong. You have to override the maindCalendarView_ItemDatesChanged function!");
        }

    }

    public class WorkCalendarScreen : CustomCalendarScreen
    {
        public WorkCalendarScreen(Calendar mainCalendarView, MonthView monthView, Calendar detailCalendarView, Button todayButton, fHome homeForm)
            : base(mainCalendarView, monthView, detailCalendarView, todayButton, homeForm)
        {

        }

        public override void loadCalendarData(DateTime start, DateTime end)
        {

            if (this.homeForm.workList != null)
            {
                foreach (CustomDay day in this.homeForm.workList)
                {
                    DateTime date = day.getDate();

                    if (date < this.mainCalendarView.ViewEnd)
                    {
                        foreach (Work work in day.getWorkList())
                        {
                            CalendarItem newItem;

                            if (work.isMultipleDays())
                            {
                                Tuple<DateTime, DateTime> dates = work.getMultipleDaysDates();

                                if (dates.Item2 < this.mainCalendarView.ViewStart)
                                    continue;

                                newItem = new CalendarItem(this.mainCalendarView,
                                        dates.Item1,
                                        dates.Item2.AddSeconds(-1),
                                        work.getTitle());
                                newItem.ApplyColor(work.getColor());
                                newItem.setCalendarEvent(work.getCalendarEvent());

                                this.mainCalendarView.Items.Add(newItem);

                            }
                            else if (date >= this.mainCalendarView.ViewStart)
                            {
                                newItem = new CalendarItem(this.mainCalendarView,
                                    date,
                                    date.AddDays(1).AddSeconds(-1),
                                    work.getTitle());

                                newItem.ApplyColor(work.getColor());
                                newItem.setCalendarEvent(work.getCalendarEvent());

                                this.mainCalendarView.Items.Add(newItem);
                            }

                        }
                    }
                }
            }

        }

        public override void mainCalendarView_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            this.homeForm.openCalendarScreen_editItem(e.Item.getCalendarEvent());
        }

        public override void mainCalendarView_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            this.homeForm.openCalendarScreen_createItem(e.Item.Date);
            e.Cancel = true;
        }

        public override void maindCalendarView_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            if (!mouseMoved)
                return;

            Google.Apis.Calendar.v3.Data.Event calendarEvent = e.Item.getCalendarEvent();

            if (calendarEvent.Start.Date.Equals(e.Item.StartDate.ToString("yyyy-MM-dd")) &&
                calendarEvent.End.Date.Equals(e.Item.EndDate.AddDays(1).ToString("yyyy-MM-dd")))
                return;

            calendarEvent.Start.Date = e.Item.StartDate.ToString("yyyy-MM-dd");
            calendarEvent.End.Date = e.Item.EndDate.AddDays(1).ToString("yyyy-MM-dd");

            calendarEvent.Start.DateTime = null;
            calendarEvent.End.DateTime = null;

            this.homeForm.googleCalendar.editWorkEvent(calendarEvent);
        }

    }

    public class LeaveCalendarScreen : CustomCalendarScreen
    {
        public LeaveCalendarScreen(Calendar mainCalendarView, MonthView monthView, Calendar detailCalendarView, Button todayButton, fHome homeForm)
            : base(mainCalendarView, monthView, detailCalendarView, todayButton, homeForm)
        {

        }

        public override void loadCalendarData(DateTime start, DateTime end)
        {

            if (this.homeForm.technicianLeaveList != null)
            {
                foreach (CustomDay day in this.homeForm.technicianLeaveList)
                {
                    DateTime date = day.getDate();

                    if (date < this.mainCalendarView.ViewEnd)
                    {
                        foreach (Technician tech in day.getTechnicianList())
                        {

                            DateTime endDate;
                            if (tech.getCalendarEvent().End.DateTime != null)
                            {
                                endDate = (DateTime)tech.getCalendarEvent().End.DateTime;
                                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day + 1, 0, 0, 0, 0);
                            }
                            else
                            {
                                endDate = Convert.ToDateTime(tech.getCalendarEvent().End.Date);
                            }

                            if (endDate < this.mainCalendarView.ViewStart)
                                continue;

                            if (endDate.Equals(date))
                                endDate = endDate.AddDays(1);

                            CalendarItem newItem;

                            newItem = new CalendarItem(this.mainCalendarView,
                                date,
                                endDate.AddSeconds(-1),
                                tech.getName());

                            newItem.setCalendarEvent(tech.getCalendarEvent());

                            this.mainCalendarView.Items.Add(newItem);

                        }

                    }
                }
            }

        }

        public override void mainCalendarView_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            this.homeForm.openLeaveScreen_editItem(e.Item.getCalendarEvent());
        }

        public override void mainCalendarView_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            this.homeForm.openLeaveScreen_createItem(e.Item.Date);
            e.Cancel = true;
        }

        public override void maindCalendarView_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            if (!mouseMoved)
                return;

            Google.Apis.Calendar.v3.Data.Event calendarEvent = e.Item.getCalendarEvent();

            if (calendarEvent.Start.Date.Equals(e.Item.StartDate.ToString("yyyy-MM-dd")) &&
                calendarEvent.End.Date.Equals(e.Item.EndDate.AddDays(1).ToString("yyyy-MM-dd")))
                return;

            calendarEvent.Start.Date = e.Item.StartDate.ToString("yyyy-MM-dd");
            calendarEvent.End.Date = e.Item.EndDate.AddDays(1).ToString("yyyy-MM-dd");

            calendarEvent.Start.DateTime = null;
            calendarEvent.End.DateTime = null;

            this.homeForm.googleCalendar.editLeaveEvent(calendarEvent);
        }

    }

}
