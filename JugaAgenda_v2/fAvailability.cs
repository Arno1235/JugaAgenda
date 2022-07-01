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
        private decimal hours;
        public fAvailability(fHome mainScreen, fCalendarEvent calendarScreen, decimal hours = 0)
        {
            this.mainScreen = mainScreen;
            this.calendarScreen = calendarScreen;
            this.hours = hours;

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fAvailability_Closed);

            InitializeComponent();

            nuHours.Value = hours;
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
                lbAvailableResults.Items.Add(date.ToString());
            }
        }
    }
}
