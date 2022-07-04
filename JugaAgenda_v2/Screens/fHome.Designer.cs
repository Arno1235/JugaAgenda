
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.msHome = new System.Windows.Forms.MenuStrip();
            this.addWorkEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fiveMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fifteenMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirtyMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixtyMinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workweekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcHome = new System.Windows.Forms.TabControl();
            this.tpCalendar = new System.Windows.Forms.TabPage();
            this.calHome = new System.Windows.Forms.Calendar.Calendar();
            this.mvHome = new System.Windows.Forms.Calendar.MonthView();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpCalendarSettings = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCalendarPerspective = new System.Windows.Forms.ComboBox();
            this.cbCalendarTimeScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCalendarSelectionMode = new System.Windows.Forms.ComboBox();
            this.tpGoogleSettings = new System.Windows.Forms.TabPage();
            this.btTestGoogleConnection = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.newDayTimer = new System.Windows.Forms.Timer(this.components);
            this.msHome.SuspendLayout();
            this.tcHome.SuspendLayout();
            this.tpCalendar.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tcSettings.SuspendLayout();
            this.tpCalendarSettings.SuspendLayout();
            this.tpGoogleSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // msHome
            // 
            this.msHome.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.msHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWorkEventToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.planningToolStripMenuItem});
            this.msHome.Location = new System.Drawing.Point(0, 0);
            this.msHome.Name = "msHome";
            this.msHome.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.msHome.Size = new System.Drawing.Size(2057, 42);
            this.msHome.TabIndex = 0;
            this.msHome.Text = "menuStrip1";
            // 
            // addWorkEventToolStripMenuItem
            // 
            this.addWorkEventToolStripMenuItem.Name = "addWorkEventToolStripMenuItem";
            this.addWorkEventToolStripMenuItem.Size = new System.Drawing.Size(131, 34);
            this.addWorkEventToolStripMenuItem.Text = "Niew Werk";
            this.addWorkEventToolStripMenuItem.Click += new System.EventHandler(this.addWorkEventToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(99, 34);
            this.searchToolStripMenuItem.Text = "Zoeken";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            this.planningToolStripMenuItem.Size = new System.Drawing.Size(112, 34);
            this.planningToolStripMenuItem.Text = "Planning";
            this.planningToolStripMenuItem.Click += new System.EventHandler(this.planningToolStripMenuItem_Click);
            // 
            // fiveMinutesToolStripMenuItem
            // 
            this.fiveMinutesToolStripMenuItem.Name = "fiveMinutesToolStripMenuItem";
            this.fiveMinutesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // sixMinutesToolStripMenuItem
            // 
            this.sixMinutesToolStripMenuItem.Name = "sixMinutesToolStripMenuItem";
            this.sixMinutesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // tenMinutesToolStripMenuItem
            // 
            this.tenMinutesToolStripMenuItem.Name = "tenMinutesToolStripMenuItem";
            this.tenMinutesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // fifteenMinutesToolStripMenuItem
            // 
            this.fifteenMinutesToolStripMenuItem.Name = "fifteenMinutesToolStripMenuItem";
            this.fifteenMinutesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // thirtyMinutesToolStripMenuItem
            // 
            this.thirtyMinutesToolStripMenuItem.Name = "thirtyMinutesToolStripMenuItem";
            this.thirtyMinutesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // sixtyMinutesToolStripMenuItem
            // 
            this.sixtyMinutesToolStripMenuItem.Name = "sixtyMinutesToolStripMenuItem";
            this.sixtyMinutesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // oneMonthToolStripMenuItem
            // 
            this.oneMonthToolStripMenuItem.Name = "oneMonthToolStripMenuItem";
            this.oneMonthToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // twoMonthsToolStripMenuItem
            // 
            this.twoMonthsToolStripMenuItem.Name = "twoMonthsToolStripMenuItem";
            this.twoMonthsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // threeMonthsToolStripMenuItem
            // 
            this.threeMonthsToolStripMenuItem.Name = "threeMonthsToolStripMenuItem";
            this.threeMonthsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // fourMonthsToolStripMenuItem
            // 
            this.fourMonthsToolStripMenuItem.Name = "fourMonthsToolStripMenuItem";
            this.fourMonthsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // sixMonthsToolStripMenuItem
            // 
            this.sixMonthsToolStripMenuItem.Name = "sixMonthsToolStripMenuItem";
            this.sixMonthsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // workweekToolStripMenuItem
            // 
            this.workweekToolStripMenuItem.Name = "workweekToolStripMenuItem";
            this.workweekToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // weekToolStripMenuItem
            // 
            this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
            this.weekToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // tcHome
            // 
            this.tcHome.Controls.Add(this.tpCalendar);
            this.tcHome.Controls.Add(this.tpSettings);
            this.tcHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcHome.Location = new System.Drawing.Point(0, 42);
            this.tcHome.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tcHome.Name = "tcHome";
            this.tcHome.SelectedIndex = 0;
            this.tcHome.Size = new System.Drawing.Size(2057, 1192);
            this.tcHome.TabIndex = 1;
            // 
            // tpCalendar
            // 
            this.tpCalendar.Controls.Add(this.calHome);
            this.tpCalendar.Controls.Add(this.mvHome);
            this.tpCalendar.Location = new System.Drawing.Point(4, 39);
            this.tpCalendar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpCalendar.Name = "tpCalendar";
            this.tpCalendar.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpCalendar.Size = new System.Drawing.Size(2049, 1149);
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
            this.calHome.Location = new System.Drawing.Point(394, 6);
            this.calHome.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.calHome.MaximumFullDays = 7;
            this.calHome.Name = "calHome";
            this.calHome.Size = new System.Drawing.Size(1650, 1137);
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
            this.mvHome.Location = new System.Drawing.Point(5, 6);
            this.mvHome.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mvHome.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.mvHome.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.mvHome.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mvHome.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.mvHome.Name = "mvHome";
            this.mvHome.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Week;
            this.mvHome.Size = new System.Drawing.Size(389, 1137);
            this.mvHome.TabIndex = 0;
            this.mvHome.Text = "monthView1";
            this.mvHome.TodayBorderColor = System.Drawing.Color.Maroon;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.tcSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 39);
            this.tpSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpSettings.Size = new System.Drawing.Size(2049, 1149);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Instellingen";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpCalendarSettings);
            this.tcSettings.Controls.Add(this.tpGoogleSettings);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(5, 6);
            this.tcSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(2039, 1137);
            this.tcSettings.TabIndex = 0;
            // 
            // tpCalendarSettings
            // 
            this.tpCalendarSettings.Controls.Add(this.label3);
            this.tpCalendarSettings.Controls.Add(this.label2);
            this.tpCalendarSettings.Controls.Add(this.cbCalendarPerspective);
            this.tpCalendarSettings.Controls.Add(this.cbCalendarTimeScale);
            this.tpCalendarSettings.Controls.Add(this.label1);
            this.tpCalendarSettings.Controls.Add(this.cbCalendarSelectionMode);
            this.tpCalendarSettings.Location = new System.Drawing.Point(4, 39);
            this.tpCalendarSettings.Name = "tpCalendarSettings";
            this.tpCalendarSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpCalendarSettings.Size = new System.Drawing.Size(2031, 1094);
            this.tpCalendarSettings.TabIndex = 1;
            this.tpCalendarSettings.Text = "Calendar";
            this.tpCalendarSettings.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Calendar Perspective";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Calendar Time Scale";
            // 
            // cbCalendarPerspective
            // 
            this.cbCalendarPerspective.Location = new System.Drawing.Point(6, 184);
            this.cbCalendarPerspective.Name = "cbCalendarPerspective";
            this.cbCalendarPerspective.Size = new System.Drawing.Size(245, 38);
            this.cbCalendarPerspective.TabIndex = 3;
            this.cbCalendarPerspective.SelectedIndexChanged += new System.EventHandler(this.cbCalendarPerspective_SelectedIndexChanged);
            // 
            // cbCalendarTimeScale
            // 
            this.cbCalendarTimeScale.Location = new System.Drawing.Point(6, 110);
            this.cbCalendarTimeScale.Name = "cbCalendarTimeScale";
            this.cbCalendarTimeScale.Size = new System.Drawing.Size(245, 38);
            this.cbCalendarTimeScale.TabIndex = 2;
            this.cbCalendarTimeScale.SelectedIndexChanged += new System.EventHandler(this.cbCalendarTimeScale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calendar Selection Mode";
            // 
            // cbCalendarSelectionMode
            // 
            this.cbCalendarSelectionMode.Location = new System.Drawing.Point(6, 36);
            this.cbCalendarSelectionMode.Name = "cbCalendarSelectionMode";
            this.cbCalendarSelectionMode.Size = new System.Drawing.Size(245, 38);
            this.cbCalendarSelectionMode.TabIndex = 0;
            this.cbCalendarSelectionMode.SelectedIndexChanged += new System.EventHandler(this.cbCalendarSelectionMode_SelectedIndexChanged);
            // 
            // tpGoogleSettings
            // 
            this.tpGoogleSettings.Controls.Add(this.btTestGoogleConnection);
            this.tpGoogleSettings.Location = new System.Drawing.Point(4, 39);
            this.tpGoogleSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpGoogleSettings.Name = "tpGoogleSettings";
            this.tpGoogleSettings.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tpGoogleSettings.Size = new System.Drawing.Size(2031, 1094);
            this.tpGoogleSettings.TabIndex = 0;
            this.tpGoogleSettings.Text = "Google";
            this.tpGoogleSettings.UseVisualStyleBackColor = true;
            // 
            // btTestGoogleConnection
            // 
            this.btTestGoogleConnection.Location = new System.Drawing.Point(12, 14);
            this.btTestGoogleConnection.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btTestGoogleConnection.Name = "btTestGoogleConnection";
            this.btTestGoogleConnection.Size = new System.Drawing.Size(183, 46);
            this.btTestGoogleConnection.TabIndex = 0;
            this.btTestGoogleConnection.Text = "Test Connection";
            this.btTestGoogleConnection.UseVisualStyleBackColor = true;
            this.btTestGoogleConnection.Click += new System.EventHandler(this.btTestGoogleConnection_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // newDayTimer
            // 
            this.newDayTimer.Tick += new System.EventHandler(this.newDayTimer_Tick);
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2057, 1234);
            this.Controls.Add(this.tcHome);
            this.Controls.Add(this.msHome);
            this.MainMenuStrip = this.msHome;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "fHome";
            this.Text = "Juga Agenda v2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msHome.ResumeLayout(false);
            this.msHome.PerformLayout();
            this.tcHome.ResumeLayout(false);
            this.tpCalendar.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tcSettings.ResumeLayout(false);
            this.tpCalendarSettings.ResumeLayout(false);
            this.tpCalendarSettings.PerformLayout();
            this.tpGoogleSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msHome;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workweekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem;
        private System.Windows.Forms.TabControl tcHome;
        private System.Windows.Forms.TabPage tpCalendar;
        private System.Windows.Forms.Calendar.Calendar calHome;
        private System.Windows.Forms.Calendar.MonthView mvHome;
        private System.Windows.Forms.ToolStripMenuItem fiveMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fifteenMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thirtyMinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixtyMinutesToolStripMenuItem;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpGoogleSettings;
        private System.Windows.Forms.Button btTestGoogleConnection;
        private System.Windows.Forms.ToolStripMenuItem oneMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWorkEventToolStripMenuItem;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.TabPage tpCalendarSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCalendarSelectionMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCalendarPerspective;
        private System.Windows.Forms.ComboBox cbCalendarTimeScale;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.Timer newDayTimer;
        private System.Windows.Forms.ToolStripMenuItem planningToolStripMenuItem;
    }
}

