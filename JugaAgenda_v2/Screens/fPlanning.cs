using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JugaAgenda_v2.Screens
{
    public partial class fPlanning : Form
    {

        private fHome mainScreen;

        public fPlanning(fHome mainScreen)
        {
            InitializeComponent();

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fAvailability_Closed);

            this.mainScreen = mainScreen;

            loadComponents();
        }

        private void fAvailability_Closed(object sender, EventArgs e)
        {
            this.mainScreen.clearPlanningScreen();
        }

        private void loadComponents()
        {
            lbComponents.Items.Clear();
            foreach (Work work in mainScreen.getWorkWithNoAvailableComponents(DateTime.Now, DateTime.Now.AddDays(Convert.ToDouble(nuWeeks.Value) * 7)))
            {
                lbComponents.Items.Add(work);
            }
        }

        private void nuWeeks_ValueChanged(object sender, EventArgs e)
        {
            loadComponents();
        }

        private void lbComponents_DoubleClick(object sender, EventArgs e)
        {
            Work selectedWork = (Work)lbComponents.SelectedItem;
            if (selectedWork != null)
            {
                if (mainScreen.getCalendarScreenAlreadyOpen())
                {
                    MessageBox.Show("Sluit het extra agenda scherm en probeer opnieuw.");
                }
                else
                {
                    mainScreen.openCalendarScreen(mainScreen.getGoogleEventById(selectedWork.getId()));
                }
            }
        }

        private void btComponentsReady_Click(object sender, EventArgs e)
        {
            if (lbComponents.SelectedItem == null) return;

            Work selectedWork = (Work)lbComponents.SelectedItem;
            selectedWork.setStatus(Work.Status.onderdelen_op_voorraad);
            selectedWork.updateCalendarEvent();
            mainScreen.googleCalendar.editWorkEvent(selectedWork.getCalendarEvent());
            loadComponents();
        }

    }

}

