using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using JugaAgenda_v2.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
            loadWork();

            dtpWeekPlanningStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday).AddDays(7);
            dtpWeekPlanningEnd.Value = dtpWeekPlanningStart.Value.AddDays(6);
        }

        private void fAvailability_Closed(object sender, EventArgs e)
        {
            this.mainScreen.clearPlanningScreen();
        }

        public void loadComponents()
        {
            lbComponents.Items.Clear();
            foreach (Work work in mainScreen.getWorkWithNoAvailableComponents(DateTime.Now, DateTime.Now.AddDays(Convert.ToDouble(nuWeeks.Value) * 7)))
                lbComponents.Items.Add(work);
        }

        public void loadWork()
        {
            lbWorkNotFinished.Items.Clear();
            foreach (Work work in mainScreen.getWorkNotFinished())
                lbWorkNotFinished.Items.Add(work);
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
                    mainScreen.openCalendarScreen(mainScreen.getGoogleEventById(selectedWork.getId()), this);
                }
            }
        }

        private void lbWorkNotFinished_DoubleClick(object sender, EventArgs e)
        {
            Work selectedWork = (Work)lbWorkNotFinished.SelectedItem;
            if (selectedWork != null)
            {
                if (mainScreen.getCalendarScreenAlreadyOpen())
                {
                    MessageBox.Show("Sluit het extra agenda scherm en probeer opnieuw.");
                }
                else
                {
                    mainScreen.openCalendarScreen(mainScreen.getGoogleEventById(selectedWork.getId()), this);
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

        private void pdfTest()
        {
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter("planning.pdf");
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            //Add paragraph to the document
            document.Add(new Paragraph("Hello World!"));
            //Close document
            document.Close();
        }

        private void createPlanningOverview(DateTime startDate, DateTime endDate)
        {
            /*String filename = "planning.pdf";

            FileInfo file = new FileInfo(filename);
            file.Directory.Create();
            
            PdfWriter writer = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4.Rotate());
            //document.SetMargins(20, 20, 20, 20);

            Paragraph title = 
                new Paragraph("Planning - Van " + startDate.customToString() + " tot en met " + endDate.customToString())
                .SetFontSize(24)
                .SetBold();

            Paragraph subTitle =
                new Paragraph("Gemaakt op " + DateTime.Now.customToString())
                .SetFontSize(12);

            document
                .Add(title)
                .Add(subTitle);*/
















            // TODO generate list
            //List<Tuple<DateTime, Technician>> techs = new List<Tuple<DateTime, Technician>>();

            foreach (CustomDay day in mainScreen.getWorkBetweenDates(startDate, endDate))
            {
                List<Technician> techs = day.getTechnicianList();

                // TODO generate list
                //List<Tuple<Work, decimal, List<Technician>>> works = new List<Tuple<Work, decimal, List<Technician>>>();
                List<Tuple<Work, Technician>> works = new List<Tuple<Work, Technician>>();
                foreach (Work work in day.getWorkList())
                {
                    if (work.getTechnicianList().Count <= 0)
                    {
                        for (int i = 0; i < (work.getDuration() - work.getHoursDone()) * 2; i++) // *2 for half hours
                            works.Add(new Tuple<Work, Technician>(work, null));
                    }
                    else
                    {
                        decimal hoursTally = work.getDuration() - work.getHoursDone();
                        foreach (Technician tech in work.getTechnicianList())
                        {
                            for (int i = 0; i < tech.getHours() * 2; i++) // *2 for half hours
                                works.Add(new Tuple<Work, Technician>(work, tech));
                            hoursTally -= tech.getHours();
                        }
                        for (int i = 0; i < hoursTally * 2; i++) // *2 for half hours
                            works.Add(new Tuple<Work, Technician>(work, null));
                    }
                }

                List<List<int>> permutations = allPermutationAmounts(works.Count() * 2, techs.Count() * 2); // *2 for half hours

                int bestScore = int.MaxValue;
                int index = -1;

                for (int i = 0; i < permutations.Count; i++)
                {
                    List<int> order = permutations[i];

                    // check if is possible
                    Boolean possible = true;
                    for (int j = 0; j < order.Count(); j++)
                    {
                        if (order[j] == -1) continue;
                        if (works[order[j]].Item2 != null &&
                            !works[order[j]].Item2.getName().Equals(techs[j].getName()))
                            possible = false;
                    }
                    if (!possible) continue;

                    // calculate score
                    int score = 2 * order.Where(x => x == -1).Count();

                    List<String> uniqueWorkTechPairs = new List<String>();
                    foreach (int j in order)
                    {
                        if (j == -1) continue;
                        String pair = works[order[j]].Item1.getId() + techs[j].getName();
                        if (!uniqueWorkTechPairs.Contains(pair)) uniqueWorkTechPairs.Add(pair);
                    }
                    score += uniqueWorkTechPairs.Count();

                    if (score < bestScore)
                    {
                        bestScore = score;
                        index = i;
                    }
                }

                // TODO: format/layout
                /*List list =
                        new List()
                        .SetSymbolIndent(12)
                        .SetListSymbol("\u2022")
                        .SetFontSize(12)
                        .SetMarginLeft(32);*/

                for (int i = 0; i < permutations[index].Count(); i++)
                {
                    //list.Add(new ListItem("Tech: " + techs[i].getName() + " - Work: " + works[permutations[index][i]].Item1.getTitle()));
                    MessageBox.Show("Tech: " + techs[i].getName() + " - Work: " + works[permutations[index][i]].Item1.getTitle());
                }

                /*document.Add(list);*/

            }















            /*List listTitle =
                    new List()
                    .SetSymbolIndent(12)
                    .SetListSymbol("\u2022")
                    .SetFontSize(12)
                    .SetBold()
                    .Add(new ListItem(day.getDate().customToString()));

            List list =
                new List()
                .SetSymbolIndent(12)
                .SetListSymbol("\u2022")
                .SetFontSize(12)
                .SetMarginLeft(32);



            document
                .Add(listTitle)
                .Add(list);*/


            //document.Close();

        }

        public List<List<int>> allPermutationAmounts(int maxAmount, int length)
        {
            List<List<int>> results = new List<List<int>> ();
            for (int i = 1; i <= maxAmount; i++) results.AddRange(permutationAmount(i, length));
            return results;
        }

        public List<List<int>> permutationAmount(int amount, int length)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < amount; i++) a.Add(i);

            if (amount < length)
            {
                for (int i = 0; i < length - amount; i++) a.Add(-1);
                amount = length;
            }
            
            List<List<int>> permutations = permutation(a);

            List<List<int>> results = new List<List<int>>();
            List<String> temp = new List<String>();

            for (int i = 0; i < permutations.Count; i++)
            {
                permutations[i].RemoveRange(length, amount - length);
                
                String tempStr = "";
                foreach(int j in permutations[i]) tempStr += j.ToString();

                if (!temp.Contains(tempStr))
                {
                    temp.Add(tempStr);
                    results.Add(permutations[i]);
                }
            }

            return results;
        }

        private List<List<int>> permutation(List<int> a, int k = 0, List<List<int>> results = null)
        {
            if (results == null) results = new List<List<int>>();
            if (k.Equals(a.Count())) results.Add(new List<int>(a));
            else
            {
                for(int i = k; i < a.Count(); i++)
                {
                    (a[k], a[i]) = (a[i], a[k]);
                    results = permutation(a, k + 1, results);
                    (a[k], a[i]) = (a[i], a[k]);
                }
            }
            return results;
        }

        private void btGeneratePDF_Click(object sender, EventArgs e)
        {
            //pdfTest();
            MessageBox.Show("Nog niet klaar");
            //foreach(List<int> lists in allPermutationAmounts(2, 4)) MessageBox.Show(lists[0].ToString() + lists[1].ToString() + lists[2].ToString() + lists[3].ToString());
            //createPlanningOverview(dtpWeekPlanningStart.Value, dtpWeekPlanningEnd.Value);
        }

    }

}

