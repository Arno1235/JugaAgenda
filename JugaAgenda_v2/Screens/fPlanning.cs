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
    public partial class fPlanning : Form
    {
        public fPlanning()
        {
            InitializeComponent();

            lbComponents.Items.Add("test");
            lbComponents.Items.Add("test2");
        }
    }

    public class ComponentsListBox : ListBox
    {
        private System.Windows.Forms.Button btSearch;

        public ComponentsListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 18;

            this.btSearch = new System.Windows.Forms.Button();

            this.btSearch.Location = new System.Drawing.Point(474, 236);
            this.btSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(129, 46);
            this.btSearch.TabIndex = 27;
            this.btSearch.Text = "Zoeken";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

            if (e.Index >= 0)
            {
                e.DrawBackground();

                var textRect = e.Bounds;
                textRect.X += 20;
                textRect.Width -= 20;
                string itemText = DesignMode ? "AddressListBox" : Items[e.Index].ToString();
                TextRenderer.DrawText(e.Graphics, itemText, e.Font, textRect, e.ForeColor, flags);

                var butRect = e.Bounds;
                butRect.X += 60;
                butRect.Width -= 80;

                ButtonRenderer.DrawButton(e.Graphics, butRect, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                //ButtonRenderer.DrawButton(this.btSearch);
                

                e.DrawFocusRectangle();
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click");
        }
    }
}
