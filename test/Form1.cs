using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            if (monthView1.SelectionStart < calendar1.ViewStart)
            {
                calendar1.ViewStart = monthView1.SelectionStart;
                calendar1.ViewEnd = monthView1.SelectionEnd;
            } else
            {
                calendar1.ViewEnd = monthView1.SelectionEnd;
                calendar1.ViewStart = monthView1.SelectionStart;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Manual");
            comboBox1.Items.Add("Day");
            comboBox1.Items.Add("Week");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthView1.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.Manual;
        }

        private void calendar1_LoadItems(object sender, System.Windows.Forms.Calendar.CalendarLoadEventArgs e)
        {

        }

        private void calendar1_CreateItem(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            MessageBox.Show(e.Item.Text.ToString());
        }

    }
}
