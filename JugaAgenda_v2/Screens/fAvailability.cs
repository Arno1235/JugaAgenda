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
    public partial class fAvailability : Form
    {
        private fHome mainScreen;
        private fCalendarEvent calendarScreen;
        private List<DateTime> dates;
        public fAvailability(fHome mainScreen, fCalendarEvent calendarScreen, decimal hours = 0)
        {
            InitializeComponent();

            dates = new List<DateTime>();

            this.mainScreen = mainScreen;
            this.calendarScreen = calendarScreen;
            this.nuHours.Value = hours;

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fAvailability_Closed);
        }

        private void fAvailability_Closed(object sender, EventArgs e)
        {
            this.calendarScreen.clearAvailabilityScreen();
        }

        private void nuHours_ValueChanged(object sender, EventArgs e)
        {
            showAvailability(nuHours.Value);
        }

        private void showAvailability(decimal hours)
        {
            lbAvailableResults.Items.Clear();

            foreach (DateTime date in mainScreen.checkAvailability(hours))
            {
                lbAvailableResults.Items.Add(date.customToString());
                dates.Add(date);
            }
        }
        
        private void lbAvailableResults_DoubleClick(object sender, EventArgs e)
        {
            if (calendarScreen != null)
            {
                calendarScreen.setHours(nuHours.Value);
                calendarScreen.setDates(dates[lbAvailableResults.SelectedIndex]);
                this.Close();
            }
        }

        private void fAvailability_Resize(object sender, EventArgs e)
        {
            lbAvailableResults.Height = this.Size.Height-125;
            lbAvailableResults.Width = this.Size.Width-50;
        }
    }
}
