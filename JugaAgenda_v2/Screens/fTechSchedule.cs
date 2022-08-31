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

namespace JugaAgenda_v2.Screens
{
    public partial class fTechSchedule : Form
    {

        private fHome mainScreen;
        private Google.Apis.Calendar.v3.Data.Event calendarEvent;

        public fTechSchedule(fHome mainScreen, int day = -1, Google.Apis.Calendar.v3.Data.Event calendarEvent = null)
        {
            this.mainScreen = mainScreen;
            this.calendarEvent = calendarEvent;

            InitializeComponent();

            loadTechnicians();

            if (day >= 0) cbDay.SelectedIndex = day;
            
            if (this.calendarEvent != null)
            {
                Technician technician = new Technician(this.calendarEvent.Summary, true);
                tbTechName.Text = technician.getName();
                foreach (Technician tech in cbTechnicians.Items)
                {
                    if (tech.getName() == technician.getName())
                    {
                        cbTechnicians.SelectedItem = tech;
                        break;
                    }
                }
                nuHours.Value = technician.getHours();
                btDelete.Show();
            }
            
        }

        private void loadTechnicians()
        {
            foreach(Technician tech in mainScreen.getTechnicianList())
                cbTechnicians.Items.Add(tech);
        }

        private void fTechSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainScreen.closeScheduleScreen();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbDay.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer een dag");
                return;
            }
            if (calendarEvent == null)
            {
                if (mainScreen.createTechSchedule(new Technician(tbTechName.Text, nuHours.Value).createCalendarEvent(cbDay.SelectedIndex)))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
            else
            {
                if (mainScreen.updateTechSchedule(new Technician(tbTechName.Text, nuHours.Value).createCalendarEvent(cbDay.SelectedIndex, calendarEvent.Id)))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Weet je zeker dat je het agenda item wilt verwijderen?", "Opgelet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                if (mainScreen.deleteTechSchedule(calendarEvent.Id))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }


    }
}
