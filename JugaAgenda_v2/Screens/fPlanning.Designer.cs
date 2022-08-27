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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lbWorkNoHours = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nuWorkToPlanHours = new System.Windows.Forms.NumericUpDown();
            this.btReset = new System.Windows.Forms.Button();
            this.lbTechAvailable = new System.Windows.Forms.ListBox();
            this.btRemoveWorkFromTech = new System.Windows.Forms.Button();
            this.btAddWorkToTech = new System.Windows.Forms.Button();
            this.lbWorkToPlan = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpWeekPlanningEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpWeekPlanningStart = new System.Windows.Forms.DateTimePicker();
            this.btGeneratePDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nuWeeks)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuWorkToPlanHours)).BeginInit();
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
            this.tabControl1.Controls.Add(this.tabPage4);
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbWorkNoHours);
            this.tabPage4.Location = new System.Drawing.Point(4, 39);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1319, 1046);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Werk zonder uren";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbWorkNoHours
            // 
            this.lbWorkNoHours.FormattingEnabled = true;
            this.lbWorkNoHours.ItemHeight = 30;
            this.lbWorkNoHours.Location = new System.Drawing.Point(8, 6);
            this.lbWorkNoHours.Name = "lbWorkNoHours";
            this.lbWorkNoHours.Size = new System.Drawing.Size(695, 1024);
            this.lbWorkNoHours.TabIndex = 1;
            this.lbWorkNoHours.DoubleClick += new System.EventHandler(this.lbWorkNoHours_DoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nuWorkToPlanHours);
            this.tabPage3.Controls.Add(this.btReset);
            this.tabPage3.Controls.Add(this.lbTechAvailable);
            this.tabPage3.Controls.Add(this.btRemoveWorkFromTech);
            this.tabPage3.Controls.Add(this.btAddWorkToTech);
            this.tabPage3.Controls.Add(this.lbWorkToPlan);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dtpWeekPlanningEnd);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.dtpWeekPlanningStart);
            this.tabPage3.Controls.Add(this.btGeneratePDF);
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1319, 1046);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Werk Planning";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nuWorkToPlanHours
            // 
            this.nuWorkToPlanHours.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuWorkToPlanHours.Location = new System.Drawing.Point(323, 50);
            this.nuWorkToPlanHours.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nuWorkToPlanHours.Name = "nuWorkToPlanHours";
            this.nuWorkToPlanHours.ReadOnly = true;
            this.nuWorkToPlanHours.Size = new System.Drawing.Size(90, 35);
            this.nuWorkToPlanHours.TabIndex = 10;
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(517, 5);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(131, 40);
            this.btReset.TabIndex = 9;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // lbTechAvailable
            // 
            this.lbTechAvailable.AllowDrop = true;
            this.lbTechAvailable.FormattingEnabled = true;
            this.lbTechAvailable.ItemHeight = 30;
            this.lbTechAvailable.Location = new System.Drawing.Point(684, 93);
            this.lbTechAvailable.Name = "lbTechAvailable";
            this.lbTechAvailable.Size = new System.Drawing.Size(569, 724);
            this.lbTechAvailable.TabIndex = 8;
            this.lbTechAvailable.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbTechAvailable_DragDrop);
            this.lbTechAvailable.DragOver += new System.Windows.Forms.DragEventHandler(this.lbTechAvailable_DragOver);
            // 
            // btRemoveWorkFromTech
            // 
            this.btRemoveWorkFromTech.Location = new System.Drawing.Point(476, 47);
            this.btRemoveWorkFromTech.Name = "btRemoveWorkFromTech";
            this.btRemoveWorkFromTech.Size = new System.Drawing.Size(309, 40);
            this.btRemoveWorkFromTech.TabIndex = 7;
            this.btRemoveWorkFromTech.Text = "Remove Work From Technician";
            this.btRemoveWorkFromTech.UseVisualStyleBackColor = true;
            this.btRemoveWorkFromTech.Click += new System.EventHandler(this.btRemoveWorkFromTech_Click);
            // 
            // btAddWorkToTech
            // 
            this.btAddWorkToTech.Location = new System.Drawing.Point(8, 47);
            this.btAddWorkToTech.Name = "btAddWorkToTech";
            this.btAddWorkToTech.Size = new System.Drawing.Size(309, 40);
            this.btAddWorkToTech.TabIndex = 6;
            this.btAddWorkToTech.Text = "Add Work To Technician";
            this.btAddWorkToTech.UseVisualStyleBackColor = true;
            this.btAddWorkToTech.Click += new System.EventHandler(this.btAddWorkToTech_Click);
            // 
            // lbWorkToPlan
            // 
            this.lbWorkToPlan.FormattingEnabled = true;
            this.lbWorkToPlan.ItemHeight = 30;
            this.lbWorkToPlan.Location = new System.Drawing.Point(8, 93);
            this.lbWorkToPlan.Name = "lbWorkToPlan";
            this.lbWorkToPlan.Size = new System.Drawing.Size(588, 724);
            this.lbWorkToPlan.TabIndex = 5;
            this.lbWorkToPlan.SelectedIndexChanged += new System.EventHandler(this.lbWorkToPlan_SelectedIndexChanged);
            this.lbWorkToPlan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbWorkToPlan_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Finish";
            // 
            // dtpWeekPlanningEnd
            // 
            this.dtpWeekPlanningEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWeekPlanningEnd.Location = new System.Drawing.Point(329, 6);
            this.dtpWeekPlanningEnd.Name = "dtpWeekPlanningEnd";
            this.dtpWeekPlanningEnd.Size = new System.Drawing.Size(182, 35);
            this.dtpWeekPlanningEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start";
            // 
            // dtpWeekPlanningStart
            // 
            this.dtpWeekPlanningStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWeekPlanningStart.Location = new System.Drawing.Point(69, 6);
            this.dtpWeekPlanningStart.Name = "dtpWeekPlanningStart";
            this.dtpWeekPlanningStart.Size = new System.Drawing.Size(182, 35);
            this.dtpWeekPlanningStart.TabIndex = 1;
            // 
            // btGeneratePDF
            // 
            this.btGeneratePDF.Location = new System.Drawing.Point(654, 5);
            this.btGeneratePDF.Name = "btGeneratePDF";
            this.btGeneratePDF.Size = new System.Drawing.Size(131, 40);
            this.btGeneratePDF.TabIndex = 0;
            this.btGeneratePDF.Text = "Genereer PDF";
            this.btGeneratePDF.UseVisualStyleBackColor = true;
            this.btGeneratePDF.Click += new System.EventHandler(this.btGeneratePDF_Click);
            // 
            // fPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 1089);
            this.Controls.Add(this.tabControl1);
            this.Name = "fPlanning";
            this.Text = "Planning";
            this.Resize += new System.EventHandler(this.fPlanning_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nuWeeks)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuWorkToPlanHours)).EndInit();
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
        private System.Windows.Forms.Button btGeneratePDF;
        private System.Windows.Forms.DateTimePicker dtpWeekPlanningStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpWeekPlanningEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbTechAvailable;
        private System.Windows.Forms.Button btRemoveWorkFromTech;
        private System.Windows.Forms.Button btAddWorkToTech;
        private System.Windows.Forms.ListBox lbWorkToPlan;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.NumericUpDown nuWorkToPlanHours;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lbWorkNoHours;
    }
}