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
            this.lbWorkNotFinished = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtpWeekPlanning = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nuWeeks)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage2.Controls.Add(this.lbWorkNotFinished);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1319, 1046);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Werk nog niet klaar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbWorkNotFinished
            // 
            this.lbWorkNotFinished.FormattingEnabled = true;
            this.lbWorkNotFinished.ItemHeight = 30;
            this.lbWorkNotFinished.Location = new System.Drawing.Point(8, 6);
            this.lbWorkNotFinished.Name = "lbWorkNotFinished";
            this.lbWorkNotFinished.Size = new System.Drawing.Size(695, 1024);
            this.lbWorkNotFinished.TabIndex = 0;
            this.lbWorkNotFinished.DoubleClick += new System.EventHandler(this.lbWorkNotFinished_DoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtpWeekPlanning);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1319, 1046);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Werk Planning";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtpWeekPlanning
            // 
            this.dtpWeekPlanning.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWeekPlanning.Location = new System.Drawing.Point(29, 75);
            this.dtpWeekPlanning.Name = "dtpWeekPlanning";
            this.dtpWeekPlanning.Size = new System.Drawing.Size(237, 35);
            this.dtpWeekPlanning.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 1089);
            this.Controls.Add(this.tabControl1);
            this.Name = "fPlanning";
            this.Text = "Planning";
            ((System.ComponentModel.ISupportInitialize)(this.nuWeeks)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox lbWorkNotFinished;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpWeekPlanning;
    }
}