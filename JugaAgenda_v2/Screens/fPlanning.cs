
using JugaAgenda_v2.Classes;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Linq;

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

            fPlanning_Resize(null, null);

            loadComponents();
            loadWork();

            dtpWeekPlanningStart.Value = DateTime.Now.StartOfWeek(DayOfWeek.Monday).AddDays(7);
            dtpWeekPlanningEnd.Value = dtpWeekPlanningStart.Value.AddDays(6);

            loadManualWorkAndTech(dtpWeekPlanningStart.Value, dtpWeekPlanningEnd.Value);
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

            lbWorkNoHours.Items.Clear();
            foreach (Work work in mainScreen.getWorkNoHours())
                lbWorkNoHours.Items.Add(work);
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

            var Renderer = new IronPdf.ChromePdfRenderer();

            using var pdf = Renderer.RenderHtmlAsPdf("<h1>Hello World</h1><ul><li>test</li><li>qsdf</li></ul>");

            pdf.SaveAs("planning.pdf");

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













            var Renderer = new IronPdf.ChromePdfRenderer();

            String html = "<h1>Planning for " + startDate.customToString() + " until " + endDate.customToString() + "</h1>";

            // TODO generate list
            //List<Tuple<DateTime, Technician>> techs = new List<Tuple<DateTime, Technician>>();

            List<CustomDay> workAndTechList = mainScreen.getWorkBetweenDates(startDate, endDate);
            workAndTechList.Sort((x, y) => x.getDate().CompareTo(y.getDate()));

            List<Work> workToDo = new List<Work>();

            foreach (CustomDay day in workAndTechList)
            {
                List<Technician> techs = day.getTechnicianList();
                workToDo.AddRange(new List<Work>(day.getWorkList()));

                //MessageBox.Show(day.getDate().customToString() + " works: " + day.getWorkList().Count().ToString() + " techs: " + techs.Count().ToString());

                if (techs.Count() <= 0)
                    continue;

                foreach (Work work in workToDo)
                {
                    
                }


                /*// TODO generate list
                //List<Tuple<Work, Decimal, List<Technician>>> works = new List<Tuple<Work, Decimal, List<Technician>>>();
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
                        Decimal hoursTally = work.getDuration() - work.getHoursDone();
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

                if (works.Count() <= 0 || techs.Count() <= 0) continue;

                MessageBox.Show(works.Count().ToString() + " " + techs.Count().ToString());

                List<List<int>> permutations = allPermutationAmounts(works.Count() * 2, techs.Count() * 2); // *2 for half hours

                int bestScore = int.MaxValue;
                int index = -1;

                for (int i = 0; i < permutations.Count; i++)
                {
                    MessageBox.Show(i.ToString() + " / " + permutations.Count.ToString());

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
                *//*List list =
                        new List()
                        .SetSymbolIndent(12)
                        .SetListSymbol("\u2022")
                        .SetFontSize(12)
                        .SetMarginLeft(32);*//*

                html += "<h2>" + day.getDate().customToString() + "</li>";

                html += "<ul>";

                for (int i = 0; i < permutations[index].Count(); i++)
                {
                    html += "<li>" + "Tech: " + techs[i].getName() + " - Work: " + works[permutations[index][i]].Item1.getTitle() + "</li>";
                    //list.Add(new ListItem("Tech: " + techs[i].getName() + " - Work: " + works[permutations[index][i]].Item1.getTitle()));
                    //MessageBox.Show("Tech: " + techs[i].getName() + " - Work: " + works[permutations[index][i]].Item1.getTitle());
                }

                html += "</ul>";

                *//*document.Add(list);*//*

                break;*/

            }

            MessageBox.Show("test");

            using var pdf = Renderer.RenderHtmlAsPdf(html);

            pdf.SaveAs("planning.pdf");













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
            for (int i = 1; i <= maxAmount; i++) 
            {
                results.AddRange(permutationAmount(i, length));
                MessageBox.Show(i.ToString() + "/" + maxAmount.ToString());
            }

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
            //MessageBox.Show("Nog niet klaar");

            /*foreach (List<int> lists in allPermutationAmounts(32, 32))
            {
                String test = "";
                foreach (int list in lists) test += list.ToString() + " ";
                MessageBox.Show(test);
            }*/

            //createPlanningOverview(dtpWeekPlanningStart.Value, dtpWeekPlanningEnd.Value);
            generatePDF(dtpWeekPlanningStart.Value, dtpWeekPlanningEnd.Value);
        }

        private void generatePDF(DateTime startDate, DateTime endDate)
        {
            var Renderer = new IronPdf.ChromePdfRenderer();

            String html = "<h1>Planning for " + startDate.customToString() + " until " + endDate.customToString() + "</h1>";

            CustomTech currentTech = null;
            foreach (Object item in lbTechAvailable.Items)
            {
                if (item.GetType() == typeof(CustomDayItem))
                    html += "<h2>" + ((CustomDayItem)item).getDate().customToString() + "</h2>";
                else if (item.GetType() == typeof(CustomTech))
                    currentTech = (CustomTech)item;
                else if (item.GetType() == typeof(CustomWork))
                    html += "<li>" + "Tech: " + currentTech.getTech().getName() + " - Work: " + ((CustomWork)item).ToString() + " - " + ((CustomWork)item).getWork().getDescription() + "</li>";

            }
            html += "</ul>";


            using var pdf = Renderer.RenderHtmlAsPdf(html);

            pdf.SaveAs("planning.pdf");

            MessageBox.Show("PDF gegenereerd!");
        }

        private void fPlanning_Resize(object sender, EventArgs e)
        {
            lbComponents.Width = this.Width - 50;
            lbComponents.Height = this.Height - 175;
            lbWorkNotFinished.Width = this.Width - 50;
            lbWorkNotFinished.Height = this.Height - 125;
            lbWorkNoHours.Width = this.Width - 50;
            lbWorkNoHours.Height = this.Height - 125;
            lbWorkToPlan.Height = this.Height - 200;
            lbWorkToPlan.Width = this.Width/2 - 50;
            lbTechAvailable.Height = this.Height - 200;
            lbTechAvailable.Width = this.Width / 2 - 50;
            lbTechAvailable.Location = new System.Drawing.Point(this.Width / 2 - 25, lbTechAvailable.Location.Y);
        }

        private void loadManualWorkAndTech(DateTime startDate, DateTime endDate)
        {
            List<CustomDay> workAndTechList = mainScreen.getWorkBetweenDates(startDate, endDate);
            workAndTechList.Sort((x, y) => x.getDate().CompareTo(y.getDate()));

            foreach (CustomDay day in workAndTechList)
            {
                List<Technician> techs = day.getTechnicianList();
                List<Work> works = day.getWorkList();

                if (works.Count > 0)
                {
                    CustomDayItem customDayItem = new CustomDayItem(day.getDate());
                    lbWorkToPlan.Items.Add(customDayItem);
                    foreach(Work work in works) lbWorkToPlan.Items.Add(new CustomWork(work, customDayItem));
                }

                if (techs.Count > 0)
                {
                    lbTechAvailable.Items.Add(new CustomDayItem(day.getDate()));
                    foreach (Technician tech in techs) lbTechAvailable.Items.Add(new CustomTech(tech));
                }

            }

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            loadManualWorkAndTech(dtpWeekPlanningStart.Value, dtpWeekPlanningEnd.Value);
        }

        private void btAddWorkToTech_Click(object sender, EventArgs e)
        {
            if (lbWorkToPlan.SelectedItem == null || lbWorkToPlan.SelectedItem.GetType() != typeof(CustomWork))
            {
                MessageBox.Show("Geen werk geselecteerd.");
                return;
            }
            if (lbTechAvailable.SelectedItem == null || lbTechAvailable.SelectedItem.GetType() != typeof(CustomTech))
            {
                MessageBox.Show("Geen technieker geselecteerd.");
                return;
            }            
            
            CustomWork work = (CustomWork) lbWorkToPlan.SelectedItem;
            CustomTech tech = (CustomTech)lbTechAvailable.SelectedItem;

            if (tech.getAvailableHours() >= work.getWork().getDuration() ||
                MessageBox.Show("Het werk duurt langer dan de technieker tijd heeft.", "Opgepast", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                    lbWorkToPlan.Items.Remove(work);

                    work.assignTech(tech);
                    lbTechAvailable.Items.Insert(lbTechAvailable.SelectedIndex + 1, work);

                    lbTechAvailable.Items.Remove(tech);
                    lbTechAvailable.Items.Insert(lbTechAvailable.Items.IndexOf(work), tech);
            }
        }

        private void btRemoveWorkFromTech_Click(object sender, EventArgs e)
        {
            if (lbTechAvailable.SelectedItem == null || lbTechAvailable.SelectedItem.GetType() != typeof(CustomWork))
            {
                MessageBox.Show("Geen werk geselecteerd.");
                return;
            }

            CustomWork work = (CustomWork)lbTechAvailable.SelectedItem;
            CustomTech tech = work.getTech();
            work.unAssignTech();
            lbTechAvailable.Items.Remove(tech);
            lbTechAvailable.Items.Insert(lbTechAvailable.Items.IndexOf(work), tech);
            lbTechAvailable.Items.Remove(work);
            lbWorkToPlan.Items.Insert(lbWorkToPlan.Items.IndexOf(work.getDay()) + 1, work);

            
        }

        private void lbWorkToPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbWorkToPlan.SelectedItem == null || lbWorkToPlan.SelectedItem.GetType() != typeof(CustomWork))
            {
                nuWorkToPlanHours.Value = 0;
                nuWorkToPlanHours.Maximum = 0;
            } else
            {
                nuWorkToPlanHours.Maximum = ((CustomWork)lbWorkToPlan.SelectedItem).getWork().getDuration();
                nuWorkToPlanHours.Value = ((CustomWork)lbWorkToPlan.SelectedItem).getWork().getDuration(); ;
            }

        }
    }

    public class CustomDayItem
    {
        DateTime date;

        public CustomDayItem(DateTime date)
        {
            this.date = date;
        }

        public DateTime getDate()
        {
            return date;
        }

        public override string ToString()
        {
            return " --- " + date.customToString() + " --- ";
        }
    }

    public class CustomWork
    {
        Work work;
        CustomTech assignedTech;
        CustomDayItem day;

        public CustomWork(Work work, CustomDayItem day)
        {
            this.work = work;
            this.assignedTech = null;
            this.day = day;
        }

        public void assignTech(CustomTech tech)
        {
            this.assignedTech = tech;
            assignedTech.decreaseHoursAvailable(work.getDuration());
        }

        public void unAssignTech()
        {
            assignedTech.increaseHoursAvailable(work.getDuration());
            this.assignedTech = null;
        }

        public CustomTech getTech()
        {
            return assignedTech;
        }

        public Work getWork()
        {
            return work;
        }

        public CustomDayItem getDay()
        {
            return day;
        }

        public override string ToString()
        {
            if (assignedTech != null)
                return "   -> " + work.getDuration().ToString() + "u " + work.getClientName();

            return work.getDuration().ToString() + "u " + work.getClientName();
        }
    }

    public class CustomTech
    {
        Technician tech;
        Decimal hoursAvailable;
        public CustomTech(Technician tech)
        {
            this.tech = tech;
            hoursAvailable = tech.getHours();
        }

        public void increaseHoursAvailable(Decimal hours)
        {
            hoursAvailable += hours;
        }

        public void decreaseHoursAvailable(Decimal hours)
        {
            hoursAvailable -= hours;
        }

        public Decimal getAvailableHours()
        {
            return hoursAvailable;
        }

        public Technician getTech()
        {
            return tech;
        }

        public override string ToString()
        {
            return tech.getName() + ": " + hoursAvailable.ToString() + "u";
        }
    }

}
