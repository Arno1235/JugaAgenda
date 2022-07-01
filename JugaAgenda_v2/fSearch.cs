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
    public partial class fSearch : Form
    {
        private fHome mainScreen;
        public fSearch(fHome mainScreen)
        {
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fSearch_Closed);

            InitializeComponent();

            this.mainScreen = mainScreen;

        }

        private void btSearch_Click(object sender, EventArgs e)
        {

            lbSearchResults.Items.Clear();

            String clientName = tbClientName.Text;
            String phoneNumber = tbPhoneNumber.Text;
            String orderNumber = tbOrderNumber.Text;
            String description = tbDescription.Text;


            List<Work> works = mainScreen.searchWork(clientName, phoneNumber, orderNumber, description, btAndOr.Text.Equals("Of"));

            foreach (Work work in works)
            {
                this.lbSearchResults.Items.Add(work);
            }

        }

        private void fSearch_Closed(object sender, EventArgs e)
        {
            this.mainScreen.clear_search_screen();
        }

        private void btAndOr_Click(object sender, EventArgs e)
        {
            if (btAndOr.Text.Equals("En"))
            {
                btAndOr.Text = "Of";
            } else
            {
                btAndOr.Text = "En";
            }
        }

        private void lbSearchResults_DoubleClick(object sender, EventArgs e)
        {
            Work selectedWork = (Work) lbSearchResults.SelectedItem;
            if (selectedWork != null)
            {
                if (mainScreen.getCalendarScreenAlreadyOpen())
                {
                    MessageBox.Show("Sluit het extra agenda scherm en probeer opnieuw.");
                } else
                {
                    mainScreen.openCalendarScreen(mainScreen.getGoogleEventById(selectedWork.getId()));
                }
            }
        }
    }
}
