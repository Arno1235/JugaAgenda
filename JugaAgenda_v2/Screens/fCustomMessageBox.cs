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
    public partial class fCustomMessageBox : Form
    {

        private Func<int, Object, int> callback_function;
        private Func<int> form_closed;
        private Object extra_var;

        public fCustomMessageBox(String title, String message, String bt1_text, String bt2_text, String bt3_text, Func<int, Object, int> callback_function, Func<int> form_closed, Object extra_var)
        {
            this.callback_function = callback_function;
            this.form_closed = form_closed;
            this.extra_var = extra_var;

            InitializeComponent();

            this.Text = title;
            labMessage.Text = message;
            bt1.Text = bt1_text;
            bt2.Text = bt2_text;
            bt3.Text = bt3_text;

        }

        private void bt1_Click(object sender, EventArgs e)
        {
            callback_function(1, extra_var);
            this.Close();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            callback_function(2, extra_var);
            this.Close();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            callback_function(3, extra_var);
            this.Close();
        }

        private void fCustomMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_closed();
        }
    }
}
