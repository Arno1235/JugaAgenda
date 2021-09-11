
namespace JugaAgenda_v2
{
    partial class fHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.msHome = new System.Windows.Forms.MenuStrip();
            this.calendarSelectionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workweekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarTimeScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fiveMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fifteenMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirtyMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixtyMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcHome = new System.Windows.Forms.TabControl();
            this.tpCalendar = new System.Windows.Forms.TabPage();
            this.calHome = new System.Windows.Forms.Calendar.Calendar();
            this.mvHome = new System.Windows.Forms.Calendar.MonthView();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpGoogleCalendar = new System.Windows.Forms.TabPage();
            this.btTestGoogleConnection = new System.Windows.Forms.Button();
            this.addWorkEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msHome.SuspendLayout();
            this.tcHome.SuspendLayout();
            this.tpCalendar.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tcSettings.SuspendLayout();
            this.tpGoogleCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // msHome
            // 
            this.msHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarSelectionModeToolStripMenuItem,
            this.calendarTimeScaleToolStripMenuItem,
            this.perspectiveToolStripMenuItem,
            this.addWorkEventToolStripMenuItem});
            this.msHome.Location = new System.Drawing.Point(0, 0);
            this.msHome.Name = "msHome";
            this.msHome.Size = new System.Drawing.Size(1200, 24);
            this.msHome.TabIndex = 0;
            this.msHome.Text = "menuStrip1";
            // 
            // calendarSelectionModeToolStripMenuItem
            // 
            this.calendarSelectionModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.dayToolStripMenuItem,
            this.workweekToolStripMenuItem,
            this.weekToolStripMenuItem,
            this.monthToolStripMenuItem});
            this.calendarSelectionModeToolStripMenuItem.Name = "calendarSelectionModeToolStripMenuItem";
            this.calendarSelectionModeToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.calendarSelectionModeToolStripMenuItem.Text = "Calendar Selection Mode";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.dayToolStripMenuItem.Text = "Day";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.dayToolStripMenuItem_Click);
            // 
            // workweekToolStripMenuItem
            // 
            this.workweekToolStripMenuItem.Name = "workweekToolStripMenuItem";
            this.workweekToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.workweekToolStripMenuItem.Text = "Work week";
            this.workweekToolStripMenuItem.Click += new System.EventHandler(this.workweekToolStripMenuItem_Click);
            // 
            // weekToolStripMenuItem
            // 
            this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
            this.weekToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.weekToolStripMenuItem.Text = "Week";
            this.weekToolStripMenuItem.Click += new System.EventHandler(this.weekToolStripMenuItem_Click);
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.monthToolStripMenuItem.Text = "Month";
            this.monthToolStripMenuItem.Click += new System.EventHandler(this.monthToolStripMenuItem_Click);
            // 
            // calendarTimeScaleToolStripMenuItem
            // 
            this.calendarTimeScaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fiveMinutesToolStripMenuItem,
            this.sixMinutesToolStripMenuItem,
            this.tenMinutesToolStripMenuItem,
            this.fifteenMinutesToolStripMenuItem,
            this.thirtyMinutesToolStripMenuItem,
            this.sixtyMinutesToolStripMenuItem});
            this.calendarTimeScaleToolStripMenuItem.Name = "calendarTimeScaleToolStripMenuItem";
            this.calendarTimeScaleToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.calendarTimeScaleToolStripMenuItem.Text = "Calendar Time Scale";
            // 
            // fiveMinutesToolStripMenuItem
            // 
            this.fiveMinutesToolStripMenuItem.Name = "fiveMinutesToolStripMenuItem";
            this.fiveMinutesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fiveMinutesToolStripMenuItem.Text = "Five Minutes";
            this.fiveMinutesToolStripMenuItem.Click += new System.EventHandler(this.fiveMinutesToolStripMenuItem_Click);
            // 
            // sixMinutesToolStripMenuItem
            // 
            this.sixMinutesToolStripMenuItem.Name = "sixMinutesToolStripMenuItem";
            this.sixMinutesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sixMinutesToolStripMenuItem.Text = "Six Minutes";
            this.sixMinutesToolStripMenuItem.Click += new System.EventHandler(this.sixMinutesToolStripMenuItem_Click);
            // 
            // tenMinutesToolStripMenuItem
            // 
            this.tenMinutesToolStripMenuItem.Name = "tenMinutesToolStripMenuItem";
            this.tenMinutesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.tenMinutesToolStripMenuItem.Text = "Ten Minutes";
            this.tenMinutesToolStripMenuItem.Click += new System.EventHandler(this.tenMinutesToolStripMenuItem_Click);
            // 
            // fifteenMinutesToolStripMenuItem
            // 
            this.fifteenMinutesToolStripMenuItem.Name = "fifteenMinutesToolStripMenuItem";
            this.fifteenMinutesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fifteenMinutesToolStripMenuItem.Text = "Fifteen Minutes";
            this.fifteenMinutesToolStripMenuItem.Click += new System.EventHandler(this.fifteenMinutesToolStripMenuItem_Click);
            // 
            // thirtyMinutesToolStripMenuItem
            // 
            this.thirtyMinutesToolStripMenuItem.Name = "thirtyMinutesToolStripMenuItem";
            this.thirtyMinutesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.thirtyMinutesToolStripMenuItem.Text = "Thirty Minutes";
            this.thirtyMinutesToolStripMenuItem.Click += new System.EventHandler(this.thirtyMinutesToolStripMenuItem_Click);
            // 
            // sixtyMinutesToolStripMenuItem
            // 
            this.sixtyMinutesToolStripMenuItem.Name = "sixtyMinutesToolStripMenuItem";
            this.sixtyMinutesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sixtyMinutesToolStripMenuItem.Text = "Sixty Minutes";
            this.sixtyMinutesToolStripMenuItem.Click += new System.EventHandler(this.sixtyMinutesToolStripMenuItem_Click);
            // 
            // perspectiveToolStripMenuItem
            // 
            this.perspectiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneMonthToolStripMenuItem,
            this.twoMonthsToolStripMenuItem,
            this.threeMonthsToolStripMenuItem,
            this.fourMonthsToolStripMenuItem,
            this.sixMonthsToolStripMenuItem});
            this.perspectiveToolStripMenuItem.Name = "perspectiveToolStripMenuItem";
            this.perspectiveToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.perspectiveToolStripMenuItem.Text = "Perspective";
            // 
            // oneMonthToolStripMenuItem
            // 
            this.oneMonthToolStripMenuItem.Name = "oneMonthToolStripMenuItem";
            this.oneMonthToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.oneMonthToolStripMenuItem.Text = "One month";
            this.oneMonthToolStripMenuItem.Click += new System.EventHandler(this.oneMonthToolStripMenuItem_Click);
            // 
            // twoMonthsToolStripMenuItem
            // 
            this.twoMonthsToolStripMenuItem.Name = "twoMonthsToolStripMenuItem";
            this.twoMonthsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.twoMonthsToolStripMenuItem.Text = "Two months";
            this.twoMonthsToolStripMenuItem.Click += new System.EventHandler(this.twoMonthsToolStripMenuItem_Click);
            // 
            // threeMonthsToolStripMenuItem
            // 
            this.threeMonthsToolStripMenuItem.Name = "threeMonthsToolStripMenuItem";
            this.threeMonthsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.threeMonthsToolStripMenuItem.Text = "Three months";
            this.threeMonthsToolStripMenuItem.Click += new System.EventHandler(this.threeMonthsToolStripMenuItem_Click);
            // 
            // fourMonthsToolStripMenuItem
            // 
            this.fourMonthsToolStripMenuItem.Name = "fourMonthsToolStripMenuItem";
            this.fourMonthsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fourMonthsToolStripMenuItem.Text = "Four months";
            this.fourMonthsToolStripMenuItem.Click += new System.EventHandler(this.fourMonthsToolStripMenuItem_Click);
            // 
            // sixMonthsToolStripMenuItem
            // 
            this.sixMonthsToolStripMenuItem.Name = "sixMonthsToolStripMenuItem";
            this.sixMonthsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.sixMonthsToolStripMenuItem.Text = "Six months";
            this.sixMonthsToolStripMenuItem.Click += new System.EventHandler(this.sixMonthsToolStripMenuItem_Click);
            // 
            // tcHome
            // 
            this.tcHome.Controls.Add(this.tpCalendar);
            this.tcHome.Controls.Add(this.tpSettings);
            this.tcHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcHome.Location = new System.Drawing.Point(0, 24);
            this.tcHome.Name = "tcHome";
            this.tcHome.SelectedIndex = 0;
            this.tcHome.Size = new System.Drawing.Size(1200, 593);
            this.tcHome.TabIndex = 1;
            // 
            // tpCalendar
            // 
            this.tpCalendar.Controls.Add(this.calHome);
            this.tpCalendar.Controls.Add(this.mvHome);
            this.tpCalendar.Location = new System.Drawing.Point(4, 24);
            this.tpCalendar.Name = "tpCalendar";
            this.tpCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.tpCalendar.Size = new System.Drawing.Size(1192, 565);
            this.tpCalendar.TabIndex = 0;
            this.tpCalendar.Text = "Calendar View";
            this.tpCalendar.UseVisualStyleBackColor = true;
            // 
            // calHome
            // 
            this.calHome.AllowItemEdit = false;
            this.calHome.AllowItemResize = false;
            this.calHome.AllowNew = false;
            this.calHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calHome.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("18:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("09:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("18:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("09:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("18:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("09:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("18:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("09:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Saturday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("09:00:00");
            this.calHome.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calHome.Location = new System.Drawing.Point(230, 3);
            this.calHome.MaximumFullDays = 7;
            this.calHome.Name = "calHome";
            this.calHome.Size = new System.Drawing.Size(959, 559);
            this.calHome.TabIndex = 1;
            this.calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
            this.calHome.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calHome_ItemDoubleClick);
            // 
            // mvHome
            // 
            this.mvHome.ArrowsColor = System.Drawing.SystemColors.Window;
            this.mvHome.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.mvHome.DayBackgroundColor = System.Drawing.Color.Empty;
            this.mvHome.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.mvHome.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.mvHome.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.mvHome.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.mvHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.mvHome.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.mvHome.ItemPadding = new System.Windows.Forms.Padding(2);
            this.mvHome.Location = new System.Drawing.Point(3, 3);
            this.mvHome.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.mvHome.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.mvHome.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mvHome.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.mvHome.Name = "mvHome";
            this.mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Week;
            this.mvHome.Size = new System.Drawing.Size(227, 559);
            this.mvHome.TabIndex = 0;
            this.mvHome.Text = "monthView1";
            this.mvHome.TodayBorderColor = System.Drawing.Color.Maroon;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.tcSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1192, 565);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpGoogleCalendar);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(3, 3);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(1186, 559);
            this.tcSettings.TabIndex = 0;
            // 
            // tpGoogleCalendar
            // 
            this.tpGoogleCalendar.Controls.Add(this.btTestGoogleConnection);
            this.tpGoogleCalendar.Location = new System.Drawing.Point(4, 24);
            this.tpGoogleCalendar.Name = "tpGoogleCalendar";
            this.tpGoogleCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.tpGoogleCalendar.Size = new System.Drawing.Size(1178, 531);
            this.tpGoogleCalendar.TabIndex = 0;
            this.tpGoogleCalendar.Text = "Google Calendar";
            this.tpGoogleCalendar.UseVisualStyleBackColor = true;
            // 
            // btTestGoogleConnection
            // 
            this.btTestGoogleConnection.Location = new System.Drawing.Point(7, 7);
            this.btTestGoogleConnection.Name = "btTestGoogleConnection";
            this.btTestGoogleConnection.Size = new System.Drawing.Size(107, 23);
            this.btTestGoogleConnection.TabIndex = 0;
            this.btTestGoogleConnection.Text = "Test Connection";
            this.btTestGoogleConnection.UseVisualStyleBackColor = true;
            this.btTestGoogleConnection.Click += new System.EventHandler(this.btTestGoogleConnection_Click);
            // 
            // addWorkEventToolStripMenuItem
            // 
            this.addWorkEventToolStripMenuItem.Name = "addWorkEventToolStripMenuItem";
            this.addWorkEventToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.addWorkEventToolStripMenuItem.Text = "Add Work Event";
            this.addWorkEventToolStripMenuItem.Click += new System.EventHandler(this.addWorkEventToolStripMenuItem_Click);
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 617);
            this.Controls.Add(this.tcHome);
            this.Controls.Add(this.msHome);
            this.MainMenuStrip = this.msHome;
            this.Name = "fHome";
            this.Text = "Juga Agenda v2";
            this.msHome.ResumeLayout(false);
            this.msHome.PerformLayout();
            this.tcHome.ResumeLayout(false);
            this.tpCalendar.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tcSettings.ResumeLayout(false);
            this.tpGoogleCalendar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msHome;
        private System.Windows.Forms.ToolStripMenuItem calendarSelectionModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workweekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem;
        private System.Windows.Forms.TabControl tcHome;
        private System.Windows.Forms.TabPage tpCalendar;
        private System.Windows.Forms.Calendar.Calendar calHome;
        private System.Windows.Forms.Calendar.MonthView mvHome;
        private System.Windows.Forms.ToolStripMenuItem calendarTimeScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fiveMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fifteenMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thirtyMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixtyMinutesToolStripMenuItem;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpGoogleCalendar;
        private System.Windows.Forms.Button btTestGoogleConnection;
        private System.Windows.Forms.ToolStripMenuItem perspectiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWorkEventToolStripMenuItem;
    }
}

