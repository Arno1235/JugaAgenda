using JugaAgenda_v2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugaAgenda_v2.Screens
{
    public partial class fExtraEvent : Form
    {
        private fHome mainScreen;
        private Google.Apis.Calendar.v3.Data.Event calendarEvent;

        private DateTime prevStartDate;

        public fExtraEvent(fHome mainScreen, Google.Apis.Calendar.v3.Data.Event calendarEvent = null, DateTime dateTime = default)
        {
            this.mainScreen = mainScreen;
            this.calendarEvent = calendarEvent;

            InitializeComponent();

            prevStartDate = dtpStart.Value;

            if (this.calendarEvent != null)
            {
                Tuple<DateTime, DateTime> dates = mainScreen.convertEventDateTime(calendarEvent);
                dtpStart.Value = dates.Item1;
                dtpEnd.Value = dates.Item2.AddSeconds(-1);
                if (dtpEnd.Value < dtpStart.Value)
                    dtpEnd.Value = dtpStart.Value;

                tbTitle.Text = calendarEvent.Summary;
                cbClosed.Checked = calendarEvent.ColorId == "8";
                rtbDescription.Text = calendarEvent.Description;

                btDelete.Show();
            }
            else
            {
                dtpStart.Value = dateTime;
                dtpEnd.Value = dateTime;
            }

            prevStartDate = dtpStart.Value;
        }

        private void fExtraEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainScreen.clear_extra_calendar_screen();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Weet je zeker dat je het agenda item wilt verwijderen?", "Opgelet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                if (mainScreen.deleteExtraEvent(calendarEvent.Id))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (mainScreen.addExtraEvent(createEvent()))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
            else
            {
                if (mainScreen.updateExtraEvent(createEvent(calendarEvent.Id)))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }

        private Google.Apis.Calendar.v3.Data.Event createEvent(string eventID = null)
        {
            Google.Apis.Calendar.v3.Data.Event newEvent = new Google.Apis.Calendar.v3.Data.Event();

            newEvent.Start = new Google.Apis.Calendar.v3.Data.EventDateTime();
            newEvent.Start.Date = dtpStart.Value.Year.ToString() + "-" + dtpStart.Value.Month.ToString() + "-" + dtpStart.Value.Day.ToString();
            newEvent.Start.DateTime = null;
            newEvent.End = new Google.Apis.Calendar.v3.Data.EventDateTime();
            newEvent.End.Date = dtpEnd.Value.Year.ToString() + "-" + dtpEnd.Value.Month.ToString() + "-" + (dtpEnd.Value.Day + 1).ToString();
            newEvent.End.DateTime = null;

            newEvent.Summary = tbTitle.Text;
            newEvent.Description = rtbDescription.Text;

            if (cbClosed.Checked)
            {
                newEvent.ColorId = "8";
            }
            else
            {
                newEvent.ColorId = null;
            }


            if (eventID != null)
                newEvent.Id = eventID;

            return newEvent;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value += dtpStart.Value - prevStartDate;

            prevStartDate = dtpStart.Value;
        }
    }
}
