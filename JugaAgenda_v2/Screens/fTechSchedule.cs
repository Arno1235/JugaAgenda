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
        private Technician technician;
        private int day;

        public fTechSchedule(fHome mainScreen, Technician technician = null, int day = -1)
        {
            this.mainScreen = mainScreen;
            this.technician = technician;
            this.day = day;

            InitializeComponent();

            loadTechnicians();

            if (day >= 0) cbDay.SelectedIndex = day;
            
            if (technician != null)
            {
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
            if (technician == null)
            {
                if (mainScreen.createTechSchedule())
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
            else
            {
                if (mainScreen.updateTechSchedule())
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
                if (mainScreen.deleteTechSchedule())
                    this.Close();
                else
                    MessageBox.Show("Er is iets fout gelopen.");
            }
        }


    }
}
