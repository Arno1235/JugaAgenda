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
            if (checkWerkGegevens())
            {
                Werk test = new Werk(textWerkBeschrijving.Text, numWerkUren.Value, checkWerkPrioriteit.Checked);
                
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
                    listWerk.Items.Insert(index, test);
                } else
                {
                    listWerk.Items.Add(test);
                }
                

                textWerkBeschrijving.Text = "";
                numWerkUren.Value = 0;
                checkWerkPrioriteit.Checked = false;
            }
            
        }

        private bool checkWerkGegevens()
        {
            if (textWerkBeschrijving.Text.Equals(""))
            {
                MessageBox.Show("Vul een beschrijving in.", "Error");
            }
            else if (numWerkUren.Value == 0)
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
        
    }
    public class Werk
    {

        String beschrijving;
        decimal uren;
        bool prioriteit;

        public Werk(String beschrijving, decimal uren, bool prioriteit)
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

        public override string ToString()
        {
            String returnString = this.uren.ToString() + "u - " + this.beschrijving;
            if (this.prioriteit)
            {
                returnString += " - Prioriteit";
            }
            return  returnString;
        }
    }

}

