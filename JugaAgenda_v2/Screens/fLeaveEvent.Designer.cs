namespace JugaAgenda_v2.Screens
{
    partial class fLeaveEvent
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
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cbTechnicians = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTechName = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(197, 15);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(356, 35);
            this.dtpStart.TabIndex = 3;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(197, 62);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(358, 35);
            this.dtpEnd.TabIndex = 4;
            // 
            // cbTechnicians
            // 
            this.cbTechnicians.FormattingEnabled = true;
            this.cbTechnicians.Location = new System.Drawing.Point(197, 153);
            this.cbTechnicians.Name = "cbTechnicians";
            this.cbTechnicians.Size = new System.Drawing.Size(358, 38);
            this.cbTechnicians.TabIndex = 38;
            this.cbTechnicians.SelectedIndexChanged += new System.EventHandler(this.cbTechnicians_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 30);
            this.label3.TabIndex = 34;
            this.label3.Text = "Naam Technieker";
            // 
            // tbTechName
            // 
            this.tbTechName.Location = new System.Drawing.Point(197, 109);
            this.tbTechName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbTechName.Name = "tbTechName";
            this.tbTechName.Size = new System.Drawing.Size(358, 35);
            this.tbTechName.TabIndex = 33;
            // 
            // btDelete
            // 
            this.btDelete.ForeColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(14, 209);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(173, 40);
            this.btDelete.TabIndex = 37;
            this.btDelete.Text = "VERWIJDEREN";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Visible = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(426, 203);
            this.btSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(129, 46);
            this.btSave.TabIndex = 36;
            this.btSave.Text = "Opslaan";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(287, 203);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(129, 46);
            this.btCancel.TabIndex = 35;
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
            this.label1.Size = new System.Drawing.Size(96, 30);
            this.label1.TabIndex = 39;
            this.label1.Text = "Start dag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 30);
            this.label2.TabIndex = 40;
            this.label2.Text = "Eind dag";
            // 
            // fLeaveEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 263);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTechnicians);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTechName);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dtpEnd);
            this.Name = "fLeaveEvent";
            this.Text = "Verlof";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fLeaveEvent_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cbTechnicians;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTechName;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}