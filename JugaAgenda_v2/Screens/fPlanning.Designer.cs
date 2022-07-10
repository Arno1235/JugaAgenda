namespace JugaAgenda_v2.Screens
{
    partial class fPlanning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nuWeeks = new System.Windows.Forms.NumericUpDown();
            this.lbComponents = new System.Windows.Forms.ListBox();
            this.btComponentsReady = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.nuWeeks)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aantal weken om vooruit te kijken";
            // 
            // nuWeeks
            // 
            this.nuWeeks.Location = new System.Drawing.Point(347, 6);
            this.nuWeeks.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuWeeks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuWeeks.Name = "nuWeeks";
            this.nuWeeks.Size = new System.Drawing.Size(75, 35);
            this.nuWeeks.TabIndex = 1;
            this.nuWeeks.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nuWeeks.ValueChanged += new System.EventHandler(this.nuWeeks_ValueChanged);
            // 
            // lbComponents
            // 
            this.lbComponents.FormattingEnabled = true;
            this.lbComponents.ItemHeight = 30;
            this.lbComponents.Location = new System.Drawing.Point(13, 47);
            this.lbComponents.Name = "lbComponents";
            this.lbComponents.Size = new System.Drawing.Size(712, 844);
            this.lbComponents.TabIndex = 2;
            this.lbComponents.DoubleClick += new System.EventHandler(this.lbComponents_DoubleClick);
            // 
            // btComponentsReady
            // 
            this.btComponentsReady.Location = new System.Drawing.Point(428, 3);
            this.btComponentsReady.Name = "btComponentsReady";
            this.btComponentsReady.Size = new System.Drawing.Size(297, 40);
            this.btComponentsReady.TabIndex = 3;
            this.btComponentsReady.Text = "Onderdelen zijn op voorraad";
            this.btComponentsReady.UseVisualStyleBackColor = true;
            this.btComponentsReady.Click += new System.EventHandler(this.btComponentsReady_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1327, 1089);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btComponentsReady);
            this.tabPage1.Controls.Add(this.nuWeeks);
            this.tabPage1.Controls.Add(this.lbComponents);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1319, 1046);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Onderdelen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1319, 1046);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 1089);
            this.Controls.Add(this.tabControl1);
            this.Name = "fPlanning";
            this.Text = "fPlanning";
            ((System.ComponentModel.ISupportInitialize)(this.nuWeeks)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuWeeks;
        private System.Windows.Forms.ListBox lbComponents;
        private System.Windows.Forms.Button btComponentsReady;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}