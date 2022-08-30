namespace JugaAgenda_v2.Screens
{
    partial class fTechSchedule
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
            this.nuHours = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTechName = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.cbTechnicians = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).BeginInit();
            this.SuspendLayout();
            // 
            // nuHours
            // 
            this.nuHours.DecimalPlaces = 1;
            this.nuHours.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuHours.Location = new System.Drawing.Point(104, 109);
            this.nuHours.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nuHours.Name = "nuHours";
            this.nuHours.Size = new System.Drawing.Size(81, 35);
            this.nuHours.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 30);
            this.label5.TabIndex = 25;
            this.label5.Text = "Uren";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 30);
            this.label3.TabIndex = 24;
            this.label3.Text = "Naam Technieker";
            // 
            // tbTechName
            // 
            this.tbTechName.Location = new System.Drawing.Point(195, 62);
            this.tbTechName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbTechName.Name = "tbTechName";
            this.tbTechName.Size = new System.Drawing.Size(358, 35);
            this.tbTechName.TabIndex = 22;
            // 
            // btDelete
            // 
            this.btDelete.ForeColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(12, 162);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(173, 40);
            this.btDelete.TabIndex = 28;
            this.btDelete.Text = "VERWIJDEREN";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Visible = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(424, 156);
            this.btSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(129, 46);
            this.btSave.TabIndex = 27;
            this.btSave.Text = "Opslaan";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(285, 156);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(129, 46);
            this.btCancel.TabIndex = 26;
            this.btCancel.Text = "Annuleer";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 30);
            this.label1.TabIndex = 30;
            this.label1.Text = "Dag";
            // 
            // cbDay
            // 
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] {
            "Maandag",
            "Dinsdag",
            "Woensdag",
            "Donderdag",
            "Vrijdag",
            "Zaterdag",
            "Zondag"});
            this.cbDay.Location = new System.Drawing.Point(195, 12);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(358, 38);
            this.cbDay.TabIndex = 31;
            // 
            // cbTechnicians
            // 
            this.cbTechnicians.FormattingEnabled = true;
            this.cbTechnicians.Location = new System.Drawing.Point(195, 106);
            this.cbTechnicians.Name = "cbTechnicians";
            this.cbTechnicians.Size = new System.Drawing.Size(358, 38);
            this.cbTechnicians.TabIndex = 32;
            // 
            // fTechSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 222);
            this.Controls.Add(this.cbTechnicians);
            this.Controls.Add(this.cbDay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuHours);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTechName);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btCancel);
            this.Name = "fTechSchedule";
            this.Text = "Technieker Werk Schema";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fTechSchedule_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nuHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTechName;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.ComboBox cbTechnicians;
    }
}