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
    public partial class fLeaveEvent : Form
    {
        private fHome mainScreen;
        private Google.Apis.Calendar.v3.Data.Event calendarEvent;

        private DateTime prevStartDate;

        public fLeaveEvent(fHome mainScreen, Google.Apis.Calendar.v3.Data.Event calendarEvent = null, DateTime dateTime = default)
        {
            this.mainScreen = mainScreen;
            this.calendarEvent = calendarEvent;

            InitializeComponent();

            loadTechnicians();

            prevStartDate = dtpStart.Value;

            if (this.calendarEvent != null)
            {
                Tuple<DateTime, DateTime> dates = mainScreen.convertEventDateTime(calendarEvent);
                dtpStart.Value = dates.Item1;
                dtpEnd.Value = dates.Item2.AddDays(-1);
                if (dtpEnd.Value < dtpStart.Value)
                    dtpEnd.Value = dtpStart.Value;

                tbTechName.Text = new Technician(this.calendarEvent).getName();
                foreach (Technician tech in cbTechnicians.Items)
                {
                    if (tech.getName().Equals(tbTechName.Text))
                    {
                        cbTechnicians.SelectedItem = tech;
                        break;
                    }
                }
                btDelete.Show();
            }
            else
            {
                dtpStart.Value = dateTime;
                dtpEnd.Value = dateTime;
            }

            prevStartDate = dtpStart.Value;
        }

        private void loadTechnicians()
        {
            foreach (Technician tech in mainScreen.getTechnicianList())
                cbTechnicians.Items.Add(tech);
        }

        private void fLeaveEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainScreen.closeLeaveEventScreen();
        }

        private void cbTechnicians_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbTechName.Text = cbTechnicians.SelectedItem.ToString();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Weet je zeker dat je het agenda item wilt verwijderen?", "Opgelet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                if (mainScreen.deleteLeaveEvent(calendarEvent.Id))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("De start en eind data zijn fout ingegeven");
                return;
            }
            if (calendarEvent == null)
            {
                if (mainScreen.addLeaveEvent(new Technician(tbTechName.Text, 0).createCalendarLeaveEvent(dtpStart.Value, dtpEnd.Value.AddDays(1))))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
            else
            {
                if (mainScreen.updateLeaveEvent(new Technician(tbTechName.Text, 0).createCalendarLeaveEvent(dtpStart.Value, dtpEnd.Value.AddDays(1), calendarEvent.Id)))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value += dtpStart.Value - prevStartDate;

            prevStartDate = dtpStart.Value;
        }

    }
}
