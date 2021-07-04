using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugaAgenda
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butWerkToevoegen_Click(object sender, EventArgs e)
        {
            if (checkWerkGegevens(textWerkBeschrijving.Text, numWerkUren.Value))
            {
                Werk newWerk = new Werk(textWerkBeschrijving.Text, numWerkUren.Value, checkWerkPrioriteit.Checked);
                
                if (checkWerkPrioriteit.Checked)
                {
                    int index = 0;
                    foreach (Werk werk in listWerk.Items)
                    {
                        if (!werk.getPrioriteit())
                        {
                            break;
                        }
                        index++;
                    }
                    listWerk.Items.Insert(index, newWerk);
                } else
                {
                    listWerk.Items.Add(newWerk);
                }
                

                textWerkBeschrijving.Text = "";
                numWerkUren.Value = 0;
                checkWerkPrioriteit.Checked = false;
            }
            
        }

        private bool checkWerkGegevens(string beschrijving, decimal uren)
        {
            if (beschrijving.Equals(""))
            {
                MessageBox.Show("Vul een beschrijving in.", "Error");
            }
            else if (uren == 0)
            {
                MessageBox.Show("Het aantal uren moet groter zijn dan 0.", "Error");
            }
            else
            {
                return true;
            }
            return false;
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            updateAgenda();
        }

        private void updateAgenda()
        {
            int currentDay = 0;
            List <ListBox> listBoxList = new List<ListBox>() { listMaandag, listDinsdag, listWoensdag, listDonderdag, listVrijdag, listZaterdag, listZondag };
            List<NumericUpDown> numericList = new List<NumericUpDown>() { numMaandagUren, numDinsdagUren, numWoensdagUren, numDonderdagUren, numVrijdagUren, numZaterdagUren, numZondagUren };

            foreach (ListBox listBox in listBoxList)
            {
                listBox.Items.Clear();
            }
            listExtra.Items.Clear();

            foreach (Werk werk in listWerk.Items)
            {
                decimal timeOver = werk.getUren();
                while (timeOver > 0)
                {
                    if (currentDay < listBoxList.Count())
                    {
                        decimal timeToFillIn = numericList[currentDay].Value;
                        foreach (Werk dagWerk in listBoxList[currentDay].Items)
                        {
                            timeToFillIn -= dagWerk.getUren();
                        }
                        if (timeOver < timeToFillIn)
                        {
                            listBoxList[currentDay].Items.Add(new Werk(werk.getBeschrijving(), timeOver, werk.getPrioriteit()));
                            timeOver = 0;
                            break;
                        }
                        else if (timeOver == timeToFillIn)
                        {
                            listBoxList[currentDay].Items.Add(new Werk(werk.getBeschrijving(), timeOver, werk.getPrioriteit()));
                            currentDay++;
                            timeOver = 0;
                            break;
                        }
                        else
                        {
                            if (timeToFillIn > 0)
                            {
                                listBoxList[currentDay].Items.Add(new Werk(werk.getBeschrijving(), timeToFillIn, werk.getPrioriteit()));
                                timeOver -= timeToFillIn;
                            }
                            currentDay++;
                        }
                    } else
                    {
                        listExtra.Items.Add(new Werk(werk.getBeschrijving(), timeOver, werk.getPrioriteit()));
                        timeOver = 0;
                        break;
                    }
                }
            }
            decimal totalExtraTime = 0;
            foreach (Werk werk in listExtra.Items)
            {
                totalExtraTime += werk.getUren();
            }
            listExtra.Items.Add("Totaal: " + totalExtraTime.ToString() + "u");
            if (totalExtraTime == 0)
            {
                for (int i = 0; i < listBoxList.Count(); i++)
                {
                    decimal timeToFillIn = numericList[i].Value;
                    foreach (Werk dagWerk in listBoxList[i].Items)
                    {
                        timeToFillIn -= dagWerk.getUren();
                    }
                    if (timeToFillIn > 0)
                    {
                        listBoxList[i].Items.Add("Uren nog in te vullen: " + timeToFillIn.ToString() + "u");
                    }
                }
            }
        }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gemaakt door Arno ;)", "Info");
        }

        private void listWerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWerk.SelectedItem != null)
            {
                Werk selectedItem = (Werk)listWerk.SelectedItem;
                textBewBeschrijving.Text = selectedItem.getBeschrijving();
                numBewUren.Value = selectedItem.getUren();
                numBewIndex.Value = listWerk.SelectedIndex;
                checkBewPrioriteit.Checked = selectedItem.getPrioriteit();
                butBewerken.Enabled = true;
                butVerwijderen.Enabled = true;
            }
        }

        private void butBewerken_Click(object sender, EventArgs e)
        {
            if (checkWerkGegevens(textBewBeschrijving.Text, numBewUren.Value))
            {
                Werk werk = (Werk) listWerk.SelectedItem;

                werk.setBeschrijving(textBewBeschrijving.Text);
                werk.setUren(numBewUren.Value);
                werk.setPrioriteit(checkBewPrioriteit.Checked);

                int index = listWerk.SelectedIndex;
                listWerk.Items.RemoveAt(index);

                if (numBewIndex.Value > listWerk.Items.Count)
                {
                    listWerk.Items.Add(werk);
                } else
                {
                    listWerk.Items.Insert((int)numBewIndex.Value, werk);
                }

                textBewBeschrijving.Text = "";
                numBewUren.Value = 0;
                numBewIndex.Value = 0;
                checkBewPrioriteit.Checked = false;
                butBewerken.Enabled = false;
                butVerwijderen.Enabled = false;
            }
        }

        private void butVerwijderen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Zeker dat je het geselecteerde wilt verwijderen?", "Verwijderen", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                listWerk.Items.RemoveAt(listWerk.SelectedIndex);
                textBewBeschrijving.Text = "";
                numBewUren.Value = 0;
                numBewIndex.Value = 0;
                checkBewPrioriteit.Checked = false;
                butBewerken.Enabled = false;
                butVerwijderen.Enabled = false;
            }
        }
    }
    public class Werk
    {

        String beschrijving;
        decimal uren;
        bool prioriteit;

        public Werk(string beschrijving, decimal uren, bool prioriteit)
        {
            this.beschrijving = beschrijving;
            this.uren = uren;
            this.prioriteit = prioriteit;
        }

        public string getBeschrijving()
        {
            return this.beschrijving;
        }
        public decimal getUren()
        {
            return this.uren;
        }
        public bool getPrioriteit()
        {
            return this.prioriteit;
        }
        public void setBeschrijving(string beschrijving)
        {
            this.beschrijving = beschrijving;
        }
        public void setUren(decimal uren)
        {
            this.uren = uren;
        }
        public void setPrioriteit(bool prioriteit)
        {
            this.prioriteit = prioriteit;
        }

        public override string ToString()
        {
            string returnString = this.uren.ToString() + "u - " + this.beschrijving;
            if (this.prioriteit)
            {
                returnString += " - Prioriteit";
            }
            return  returnString;
        }
    }

}

