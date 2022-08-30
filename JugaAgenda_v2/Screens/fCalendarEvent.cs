using JugaAgenda_v2.Classes;
using JugaAgenda_v2.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugaAgenda_v2
{
    public partial class fCalendarEvent : Form
    {
        private DateTime prevDate;
        private fHome mainScreen;
        private Google.Apis.Calendar.v3.Data.Event oldWorkEvent;
        private fAvailability availabilityScreen;
        private fPlanning planningScreen;

        public fCalendarEvent(fHome mainScreen, Google.Apis.Calendar.v3.Data.Event oldWorkEvent = null, fPlanning planningScreen = null)
        {
            this.mainScreen = mainScreen;
            this.oldWorkEvent = oldWorkEvent;
            this.planningScreen = planningScreen;

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fCalendarEvent_Closed);

            InitializeComponent();
            loadComponents();

            if (oldWorkEvent != null)
            {
                btDelete.Show();
                loadWorkEvent();
            }

            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);

            int titleHeight = screenRectangle.Top - this.Top;

            this.Size = new System.Drawing.Size(this.Size.Width, this.btSave.Location.Y + this.btSave.Height*2 + titleHeight + this.Padding.Top + this.Padding.Bottom);

        }

        public fCalendarEvent(fHome mainScreen, DateTime date)
        {
            this.mainScreen = mainScreen;
            this.oldWorkEvent = null;
            this.planningScreen = null;

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fCalendarEvent_Closed);

            InitializeComponent();
            loadComponents();

            if (oldWorkEvent != null)
            {
                btDelete.Show();
                loadWorkEvent();
            }

            dtpStart.Value = date;
        }

        private void loadComponents()
        {
            cbFullDays.Checked = true;

            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            prevDate = dtpStart.Value;

            for (int i = 0; i < 24; i++) cbHourStart.Items.Add(i);
            cbHourStart.SelectedIndex = 0;
            cbHourStart.Enabled = false;
            for (int i = 0; i < 60; i += 5) cbMinuteStart.Items.Add(i);
            cbMinuteStart.SelectedIndex = 0;
            cbMinuteStart.Enabled = false;
            for (int i = 0; i < 24; i++) cbHourEnd.Items.Add(i);
            cbHourEnd.SelectedIndex = 0;
            cbHourEnd.Enabled = false;
            for (int i = 0; i < 60; i += 5) cbMinuteEnd.Items.Add(i);
            cbMinuteEnd.SelectedIndex = 0;
            cbMinuteEnd.Enabled = false;

            foreach (Work.Status status in Enum.GetValues(typeof(Work.Status))) cbStatus.Items.Add(status);
            cbStatus.SelectedIndex = 0;

            foreach (Technician technician in mainScreen.getTechnicianList())
            {
                cbTechnician.Items.Add(technician);
            }
            nuTechHours.Value = 0;
            nuTechHours.Maximum = 0;
            nuHoursDone.Maximum = 0;

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Dakraam plaatsen", 4));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Zijraam plaatsen", 4));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Luifel plaatsen", 3));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("MaxxFan plaatsen", 5));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Viesa plaatsen", 6));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Airco plaatsen", 5));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Batterij vervangen", 2));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Zonnepaneel plaatsen", 5));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Omvormer plaatsen", 3));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Achteruitrijcamera plaatsen", 5));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Fietsendrager plaatsen", 2));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Fietslift plaatsen", 5));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Garage bars plaatsen", 1));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Veiligheidsloten plaatsen", 4));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("LPG (1 fles) installatie plaatsen", 1.5m));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("LPG (2 flessen) installatie plaatsen", 2));
            
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Sateliet plaatsen", 5));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Mave poten plaatsen", 16));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Tesa poten plaatsen", 12));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Manuele poten plaatsen", 2));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Mover plaatsen", 4));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Caravan onderhoud", 3));

            cbWorkHoursList.Items.Add(new WorkHoursListItem("Frigo nakijken", 1.5m));
            cbWorkHoursList.Items.Add(new WorkHoursListItem("Prul nakijken", 1));

        }

        private void loadWorkEvent()
        {

            if (oldWorkEvent.Start.DateTime != null)
            {
                cbFullDays.Checked = false;
                dtpStart.Value = (DateTime)oldWorkEvent.Start.DateTime;
                dtpEnd.Value = (DateTime)oldWorkEvent.End.DateTime;
                cbHourStart.SelectedIndex = ((DateTime)oldWorkEvent.Start.DateTime).Hour;
                cbHourEnd.SelectedIndex = ((DateTime)oldWorkEvent.End.DateTime).Hour;
                cbMinuteStart.SelectedIndex = Convert.ToInt32(Math.Floor((Decimal)((DateTime)oldWorkEvent.Start.DateTime).Minute / 5));
                cbMinuteEnd.SelectedIndex = Convert.ToInt32(Math.Floor((Decimal)((DateTime)oldWorkEvent.End.DateTime).Minute / 5));
                cbHourStart.Enabled = true;
                cbMinuteStart.Enabled = true;
                cbHourEnd.Enabled = true;
                cbMinuteEnd.Enabled = true;
            } else
            {
                cbFullDays.Checked = true;
                dtpStart.Value = Convert.ToDateTime(oldWorkEvent.Start.Date);
                dtpEnd.Value = Convert.ToDateTime(oldWorkEvent.End.Date).AddDays(-1);
                cbHourStart.Enabled = false;
                cbMinuteStart.Enabled = false;
                cbHourEnd.Enabled = false;
                cbMinuteEnd.Enabled = false;
            }

            Work work = new Work(oldWorkEvent);

            cbStatus.SelectedItem = work.getStatus();
            nuHours.Value = work.getDuration();
            tbClientName.Text = work.getClientName();
            tbPhoneNumber.Text = work.getPhoneNumber();
            tbOrderNumber.Text = work.getOrderNumber();
            rtbDescription.Text = work.getDescription();
            nuHoursDone.Maximum = nuHours.Value;
            nuHoursDone.Value = work.getHoursDone();

            foreach (Technician technician in work.getTechnicianList())
            {
                lbTechnicians.Items.Add(technician);
                cbTechnician.Items.Remove(new Technician(technician.getName()));
            }

            updateNUTechHours();
        }

        private void cbFullDays_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFullDays.Checked)
            {
                cbHourStart.Enabled = false;
                cbMinuteStart.Enabled = false;
                cbHourEnd.Enabled = false;
                cbMinuteEnd.Enabled = false;
            } else
            {
                cbHourStart.Enabled = true;
                cbMinuteStart.Enabled = true;
                cbHourEnd.Enabled = true;
                cbMinuteEnd.Enabled = true;
            }
        }

        // TODO: put this in the work class?
        private bool checkValues()
        {
            if (DateTime.Compare(dtpStart.Value.Date, dtpEnd.Value.Date) > 0)
            {
                MessageBox.Show("Dates are incorrect.");
                return false;
            }
            if (!cbFullDays.Checked && DateTime.Compare(dtpStart.Value.Date.AddHours(Convert.ToInt64(cbHourStart.SelectedItem)).AddMinutes(Convert.ToInt64(cbMinuteStart.SelectedItem)), dtpEnd.Value.Date.AddHours(Convert.ToInt64(cbHourEnd.SelectedItem)).AddMinutes(Convert.ToInt64(cbMinuteEnd.SelectedItem))) >= 0)
            {
                MessageBox.Show("Times are incorrect.");
                return false;
            }
            return true;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value += (dtpStart.Value - prevDate);
            prevDate = dtpStart.Value;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkValues())
            {
                if (this.oldWorkEvent == null)
                {

                    if (cbFullDays.Checked)
                    {

                        Work new_work = new Work(
                            null,
                            rtbDescription.Text.ToString(),
                            Decimal.Parse(nuHours.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            tbClientName.Text.ToString(),
                            tbPhoneNumber.Text.ToString(),
                            tbOrderNumber.Text.ToString(),
                            (Work.Status)cbStatus.SelectedItem,
                            Decimal.Parse(nuHoursDone.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            (IList<Technician>)lbTechnicians.Items.Cast<Technician>().ToList(),
                            dtpStart.Value.ToString("yyyy-MM-dd"),
                            dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd")
                            );

                        if (new_work.getCalendarEvent() != null)
                        {

                            if (mainScreen.googleCalendar.addWorkEvent(new_work.getCalendarEvent()))
                            {
                                mainScreen.syncCalendar();
                                this.Close();
                            } else
                            {
                                MessageBox.Show("Something went wrong when adding new event to calendar.");
                            }
                        }

                    }
                    else
                    {

                        Work new_work = new Work(
                            null,
                            rtbDescription.Text.ToString(),
                            Decimal.Parse(nuHours.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            tbClientName.Text.ToString(),
                            tbPhoneNumber.Text.ToString(),
                            tbOrderNumber.Text.ToString(),
                            (Work.Status)cbStatus.SelectedItem,
                            Decimal.Parse(nuHoursDone.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            (IList<Technician>)lbTechnicians.Items.Cast<Technician>().ToList(),
                            dtpStart.Value.Date.AddHours(Convert.ToInt64(cbHourStart.SelectedItem)).AddMinutes(Convert.ToInt64(cbMinuteStart.SelectedItem)),
                            dtpEnd.Value.Date.AddHours(Convert.ToInt64(cbHourEnd.SelectedItem)).AddMinutes(Convert.ToInt64(cbMinuteEnd.SelectedItem))
                            );

                        if (new_work.getCalendarEvent() != null)
                        {

                            if (mainScreen.googleCalendar.addWorkEvent(new_work.getCalendarEvent()))
                            {
                                mainScreen.syncCalendar();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong when adding new event to calendar.");
                            }
                        }

                    }

                } else
                {

                    if (cbFullDays.Checked)
                    {

                        Work new_work = new Work(
                            oldWorkEvent.Id,
                            rtbDescription.Text.ToString(),
                            Decimal.Parse(nuHours.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            tbClientName.Text.ToString(),
                            tbPhoneNumber.Text.ToString(),
                            tbOrderNumber.Text.ToString(),
                            (Work.Status)cbStatus.SelectedItem,
                            Decimal.Parse(nuHoursDone.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            (IList<Technician>)lbTechnicians.Items.Cast<Technician>().ToList(),
                            dtpStart.Value.ToString("yyyy-MM-dd"),
                            dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd")
                            );

                        if (new_work.getCalendarEvent() != null)
                        {

                            if (mainScreen.googleCalendar.editWorkEvent(new_work.getCalendarEvent()))
                            {
                                mainScreen.syncCalendar();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong when adding new event to calendar.");
                            }
                        }

                    }
                    else
                    {

                        Work new_work = new Work(
                            oldWorkEvent.Id,
                            rtbDescription.Text.ToString(),
                            Decimal.Parse(nuHours.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            tbClientName.Text.ToString(),
                            tbPhoneNumber.Text.ToString(),
                            tbOrderNumber.Text.ToString(),
                            (Work.Status)cbStatus.SelectedItem,
                            Decimal.Parse(nuHoursDone.Value.ToString().Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            (IList<Technician>)lbTechnicians.Items.Cast<Technician>().ToList(),
                            dtpStart.Value.Date.AddHours(Convert.ToInt64(cbHourStart.SelectedItem)).AddMinutes(Convert.ToInt64(cbMinuteStart.SelectedItem)),
                            dtpEnd.Value.Date.AddHours(Convert.ToInt64(cbHourEnd.SelectedItem)).AddMinutes(Convert.ToInt64(cbMinuteEnd.SelectedItem))
                            );

                        if (new_work.getCalendarEvent() != null)
                        {

                            if (mainScreen.googleCalendar.editWorkEvent(new_work.getCalendarEvent()))
                            {
                                mainScreen.syncCalendar();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong when adding new event to calendar.");
                            }
                        }

                    }

                }

            }
        }

        private void fCalendarEvent_Closed(object sender, EventArgs e)
        {
            if (availabilityScreen != null)
            {
                availabilityScreen.Close();
                availabilityScreen = null;
            }

            if (planningScreen != null)
            {
                planningScreen.loadComponents();
                planningScreen.loadWork();
            }

            this.mainScreen.clear_calendar_screen();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Weet je zeker dat je het agenda item wilt verwijderen?", "Opgelet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (answer == DialogResult.Yes)
            {
                if (this.mainScreen.deleteWorkItem(oldWorkEvent.Id))
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }

        private void btAvailability_Click(object sender, EventArgs e)
        {
            if (availabilityScreen == null)
            {
                availabilityScreen = new fAvailability(mainScreen, this, nuHours.Value);
                availabilityScreen.Show();
            }
        }

        public void clearAvailabilityScreen()
        {
            availabilityScreen = null;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (cbTechnician.SelectedIndex == -1) return;
            if (nuTechHours.Value <= 0) return;

            lbTechnicians.Items.Add(new Technician(((Technician)cbTechnician.SelectedItem).getName(), nuTechHours.Value));
            cbTechnician.Items.Remove(cbTechnician.SelectedItem);

            updateNUTechHours();
        }

        private void nuHours_ValueChanged(object sender, EventArgs e)
        {
            updateNUTechHours();
        }

        private void updateNUTechHours()
        {

            nuHoursDone.Maximum = nuHours.Value;
            
            nuTechHours.Maximum = nuHours.Value;
            nuTechHours.Value = nuHours.Value;

            foreach (Technician technician in lbTechnicians.Items)
            {
                nuTechHours.Value = Math.Max(nuTechHours.Value - technician.getHours(), 0);
                nuTechHours.Maximum = Math.Max(nuTechHours.Maximum - technician.getHours(), 0);
            }
        }

        private void lbTechnicians_DoubleClick(object sender, EventArgs e)
        {
            cbTechnician.Items.Add(new Technician(((Technician)lbTechnicians.SelectedItem).getName()));
            lbTechnicians.Items.Remove(lbTechnicians.SelectedItem);
            updateNUTechHours();
        }

        public void setHours(Decimal hours)
        {
            nuHours.Value = hours;
        }

        public void setDates(DateTime date)
        {
            dtpStart.Value = date;
            dtpEnd.Value = date;
        }

        private void cbWorkHoursList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWorkHoursList.SelectedIndex == -1) return;
            nuHours.Value = ((WorkHoursListItem)cbWorkHoursList.SelectedItem).getHours();
        }
    }
}

public class WorkHoursListItem
{
    private String name;
    private Decimal hours;

    public WorkHoursListItem(string name, Decimal hours)
    {
        this.name = name;
        this.hours = hours;
    }

    public Decimal getHours()
    {
        return hours;
    }

    public override string ToString()
    {
        return name.ToString() + " - " + hours.ToString() + "u";
    }
}
