using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugaAgenda_v2
{
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
            
            mvHome.SelectionStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday).Date;
            mvHome.SelectionEnd = DateTime.Now.EndOfWeek(DayOfWeek.Sunday);
            mvHome.MaxSelectionCount = calHome.MaximumViewDays;

            calHome.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
        }

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

        private void mvHome_SelectionChanged(object sender, EventArgs e)
        {
            if ((mvHome.SelectionEnd - mvHome.SelectionStart).Days > -1 && (mvHome.SelectionEnd - mvHome.SelectionStart).Days < calHome.MaximumViewDays)
            {
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
            }
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
            int diff = (7 + (dt.DayOfWeek - endOfWeek)) % 7;
            return dt.AddDays(diff).Date;
        }
    }

}
