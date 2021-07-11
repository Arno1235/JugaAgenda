
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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange6 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange7 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange8 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange9 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange10 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.msHome = new System.Windows.Forms.MenuStrip();
            this.calendarSelectionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workweekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcHome = new System.Windows.Forms.TabControl();
            this.tpCalendar = new System.Windows.Forms.TabPage();
            this.calHome = new System.Windows.Forms.Calendar.Calendar();
            this.mvHome = new System.Windows.Forms.Calendar.MonthView();
            this.msHome.SuspendLayout();
            this.tcHome.SuspendLayout();
            this.tpCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // msHome
            // 
            this.msHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarSelectionModeToolStripMenuItem});
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
            // tcHome
            // 
            this.tcHome.Controls.Add(this.tpCalendar);
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
            this.calHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calHome.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            calendarHighlightRange6.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange6.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange6.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange7.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange7.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange7.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange8.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange8.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange8.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange9.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange9.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange9.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange10.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange10.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange10.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calHome.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange6,
        calendarHighlightRange7,
        calendarHighlightRange8,
        calendarHighlightRange9,
        calendarHighlightRange10};
            this.calHome.Location = new System.Drawing.Point(230, 3);
            this.calHome.MaximumFullDays = 7;
            this.calHome.Name = "calHome";
            this.calHome.Size = new System.Drawing.Size(959, 559);
            this.calHome.TabIndex = 1;
            this.calHome.Text = "calendar1";
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
            this.mvHome.SelectionChanged += new System.EventHandler(this.mvHome_SelectionChanged);
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
    }
}

