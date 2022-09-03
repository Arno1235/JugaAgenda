﻿
using JugaAgenda_v2.Classes;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Linq;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.IO;
using System.Drawing;

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

            lbComponents.DrawMode = DrawMode.OwnerDrawFixed;

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

            lbCompORCamperNotInTime.Items.Clear();
            foreach (Work work in mainScreen.getWorkWithComponentsORCamperNotInTime())
                lbCompORCamperNotInTime.Items.Add(work);
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
                    mainScreen.setLastOpenedIndex(lbComponents.SelectedIndex);
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

            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Draw the text.
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));
            //Save the document.

            using (FileStream fs = File.Create("test.pdf"))
            {
                document.Save(fs);
            }
            
            //Close the document.
            document.Close(true);

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













            /*var Renderer = new IronPdf.ChromePdfRenderer();

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


                *//*// TODO generate list
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

                break;*//*

            }

            MessageBox.Show("test");

            using var pdf = Renderer.RenderHtmlAsPdf(html);

            pdf.SaveAs("planning.pdf");*/













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

            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont fontTitle = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont fontSubTitle = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
            PdfFont paragraphFont = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

            int YLoc = 0;

            string text = startDate.customToString() + " tot " + endDate.customToString();
            YLoc = writeString(text, fontTitle, graphics, YLoc);

            CustomTech currentTech = null;
            foreach (Object item in lbTechAvailable.Items)
            {
                if (item.GetType() == typeof(CustomDayItem))
                {
                    text = ((CustomDayItem)item).getDate().customToString();
                    YLoc = writeString(text, fontSubTitle, graphics, YLoc, new Tuple<int, int>(6, 3));
                }
                else if (item.GetType() == typeof(CustomTech))
                {
                    currentTech = (CustomTech)item;
                    text = currentTech.getTech().getName();
                    YLoc = writeString(text, font, graphics, YLoc, new Tuple<int, int>(3, 0), 6);
                }
                else if (item.GetType() == typeof(CustomWork))
                {
                    text = ((CustomWork)item).ToString();
                    YLoc = writeString(text, font, graphics, YLoc, null, 12);

                    text = ((CustomWork)item).getWork().getDescription();
                    YLoc = writeString(text, paragraphFont, graphics, YLoc, new Tuple<int, int>(0, 3), 36);
                }
            }

            try
            {

                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/planning.pdf"))
                {
                    document.Save(fs);
                }
                document.Close(true);

                MessageBox.Show("PDF gegenereerd!");
            } catch {
                MessageBox.Show("Er is iets fout gelopen tijdens het opslaan van de planning");
            }

        }

        private int writeString(string text, PdfFont font, PdfGraphics graphics, int YLoc, Tuple<int, int> marginTopBottom = null, int indent = 0)
        {
            if (marginTopBottom != null)
                YLoc += marginTopBottom.Item1;
            graphics.DrawString(text, font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(indent, YLoc));
            if (marginTopBottom != null)
                YLoc += marginTopBottom.Item2;

            Syncfusion.Drawing.SizeF size = font.MeasureString(text);

            YLoc += (int)size.Height;

            return YLoc;
        }

        private void fPlanning_Resize(object sender, EventArgs e)
        {
            lbComponents.Width = this.Width - 50;
            lbComponents.Height = this.Height - 175;
            /*lbWorkNotFinished.Width = this.Width - 50;
            lbWorkNotFinished.Height = this.Height - 125;
            lbWorkNoHours.Width = this.Width - 50;
            lbWorkNoHours.Height = this.Height - 125;*/
            lbWorkToPlan.Height = this.Height - 150;
            lbWorkToPlan.Width = this.Width/2 - 50;
            lbTechAvailable.Height = this.Height - 150;
            lbTechAvailable.Width = this.Width / 2 - 50;
            lbTechAvailable.Location = new System.Drawing.Point(this.Width / 2 - 25, lbTechAvailable.Location.Y);
        }

        private void loadManualWorkAndTech(DateTime startDate, DateTime endDate)
        {
            List<CustomDay> workAndTechList = mainScreen.getWorkBetweenDates(startDate, endDate);
            workAndTechList.Sort((x, y) => x.getDate().CompareTo(y.getDate()));

            lbWorkToPlan.Items.Clear();
            lbTechAvailable.Items.Clear();

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

        private void lbWorkNoHours_DoubleClick(object sender, EventArgs e)
        {
            Work selectedWork = (Work)lbWorkNoHours.SelectedItem;
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




        private void lbWorkToPlan_MouseDown(object sender, MouseEventArgs e)
        {

            if (lbWorkToPlan.Items.Count == 0)
                return;

            int index = lbWorkToPlan.IndexFromPoint(e.X, e.Y);

            if (lbWorkToPlan.Items[index].GetType() == typeof(CustomWork))
            {

                CustomWork customWork = (CustomWork)lbWorkToPlan.Items[index];

                DragDropEffects dde1 = DoDragDrop(customWork, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    if (nuWorkToPlanHours.Value.Equals(0) || nuWorkToPlanHours.Value.Equals(customWork.getWork().getDuration()))
                    {
                        lbWorkToPlan.Items.RemoveAt(index);
                        lbTechAvailable.Items.Insert(lbTechAvailable.SelectedIndex + 1, customWork);
                    } else
                    {
                        CustomWork copyCustomWork = new CustomWork(customWork.getWork(), customWork.getDay(), nuWorkToPlanHours.Value);
                        lbTechAvailable.Items.Insert(lbTechAvailable.SelectedIndex + 1, copyCustomWork);
                        nuWorkToPlanHours.Value = 0;

                        int currentIndex = lbTechAvailable.SelectedIndex + 1;

                        while (currentIndex > 0)
                        {
                            if (lbTechAvailable.Items[currentIndex].GetType() == typeof(CustomTech))
                            {
                                copyCustomWork.assignTech((CustomTech)lbTechAvailable.Items[currentIndex]);
                                break;
                            }
                            currentIndex--;
                        }
                    }
                    
                } else if (dde1 == DragDropEffects.None)
                    lbWorkToPlan_SelectedIndexChanged(null, null);
            }

        }

        private void lbTechAvailable_DragOver(object sender, DragEventArgs e)
        {
            
            int index = lbTechAvailable.IndexFromPoint(lbTechAvailable.PointToClient(new System.Drawing.Point(e.X, e.Y)));

            if (lbTechAvailable.Items[index].GetType() != typeof(CustomTech) && lbTechAvailable.Items[index].GetType() != typeof(CustomWork) && !e.Data.GetDataPresent(typeof(CustomWork)))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.All;

            lbTechAvailable.SelectedIndex = index;
        }

        private void lbTechAvailable_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CustomWork)))
            {

                int index = lbTechAvailable.IndexFromPoint(lbTechAvailable.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                if (index == -1) index = lbTechAvailable.Items.Count - 1;

                if (lbTechAvailable.Items[index].GetType() != typeof(CustomTech) && lbTechAvailable.Items[index].GetType() != typeof(CustomWork))
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                CustomWork customWork = (CustomWork)e.Data
                    .GetData(typeof(CustomWork));

                int currentIndex = index;
                
                while(currentIndex > 0)
                {
                    if (lbTechAvailable.Items[currentIndex].GetType() == typeof(CustomTech))
                    {
                        customWork.assignTech((CustomTech)lbTechAvailable.Items[currentIndex]);
                        break;
                    }
                    currentIndex--;
                }

                //lbTechAvailable.Items.Insert(index + 1, customWork);

                lbTechAvailable.SelectedIndex = index;

            }
        }

        private void lbTechAvailable_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbTechAvailable.Items.Count == 0)
                return;

            int index = lbTechAvailable.IndexFromPoint(e.X, e.Y);

            if (lbTechAvailable.Items[index].GetType() == typeof(CustomWork))
            {

                CustomWork customWork = (CustomWork)lbTechAvailable.Items[index];

                DragDropEffects dde2 = DoDragDrop(customWork, DragDropEffects.All);

                if (dde2 == DragDropEffects.All && index != lbTechAvailable.SelectedIndex)
                {
                    lbTechAvailable.Items.RemoveAt(index);
                    lbTechAvailable.Items.Insert(lbTechAvailable.SelectedIndex + 1, customWork);
                } else if (dde2 == DragDropEffects.Move)
                    lbTechAvailable.Items.RemoveAt(index);
            }
        }

        private void lbWorkToPlan_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CustomWork)) && ((CustomWork) e.Data.GetData(typeof(CustomWork))).getTech() != null)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lbWorkToPlan_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CustomWork)) && ((CustomWork)e.Data.GetData(typeof(CustomWork))).getTech() != null)
            {

                CustomWork customWork = (CustomWork)e.Data
                    .GetData(typeof(CustomWork));

                customWork.unAssignTech();

                int index = lbWorkToPlan.Items.IndexOf(customWork.getDay()) + 1;
                lbWorkToPlan.Items.Insert(index, customWork);
                lbWorkToPlan.SelectedIndex = index;

            }
        }

        private void lbCompNotInTime_DoubleClick(object sender, EventArgs e)
        {
            Work selectedWork = (Work)lbCompORCamperNotInTime.SelectedItem;
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

        private void lbComponents_DrawItem(object sender, DrawItemEventArgs e)
        {
            String text = lbComponents.Items[e.Index].ToString();
            if (e.Index.Equals(mainScreen.getLastOpenedIndex()))
                text = "-> " + text;

            e.DrawBackground();
            e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
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
        Decimal hours;

        public CustomWork(Work work, CustomDayItem day, Decimal hours = -1)
        {
            this.work = work;
            this.assignedTech = null;
            this.day = day;
            this.hours = hours;
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
            String output;
            if (hours == -1)
                output = work.getDuration().ToString();
            else
                output = hours.ToString();

            output += "u " + work.getClientName();

            for (int i = 0; i < work.getTechnicianList().Count; i++)
            {
                if (i == 0)
                    output += " (";

                Technician tech = work.getTechnicianList()[i];
                output += tech.getName() + " " + tech.getHours().ToString() + "u";

                if (i < work.getTechnicianList().Count - 1)
                    output += "; ";
                else
                    output += ")";
            }

            if (assignedTech != null)
                return "   -> " + output;
            return output;
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
