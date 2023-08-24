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
            dtpStart = new System.Windows.Forms.DateTimePicker();
            dtpEnd = new System.Windows.Forms.DateTimePicker();
            cbTechnicians = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            tbTechName = new System.Windows.Forms.TextBox();
            btDelete = new System.Windows.Forms.Button();
            btSave = new System.Windows.Forms.Button();
            btCancel = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Location = new System.Drawing.Point(164, 12);
            dtpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new System.Drawing.Size(297, 31);
            dtpStart.TabIndex = 3;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new System.Drawing.Point(164, 52);
            dtpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new System.Drawing.Size(299, 31);
            dtpEnd.TabIndex = 4;
            // 
            // cbTechnicians
            // 
            cbTechnicians.FormattingEnabled = true;
            cbTechnicians.Location = new System.Drawing.Point(164, 128);
            cbTechnicians.Margin = new System.Windows.Forms.Padding(2);
            cbTechnicians.Name = "cbTechnicians";
            cbTechnicians.Size = new System.Drawing.Size(299, 33);
            cbTechnicians.TabIndex = 38;
            cbTechnicians.SelectedIndexChanged += cbTechnicians_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 93);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(145, 25);
            label3.TabIndex = 34;
            label3.Text = "Naam Technieker";
            // 
            // tbTechName
            // 
            tbTechName.Location = new System.Drawing.Point(164, 91);
            tbTechName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbTechName.Name = "tbTechName";
            tbTechName.Size = new System.Drawing.Size(299, 31);
            tbTechName.TabIndex = 33;
            // 
            // btDelete
            // 
            btDelete.ForeColor = System.Drawing.Color.Red;
            btDelete.Location = new System.Drawing.Point(12, 174);
            btDelete.Margin = new System.Windows.Forms.Padding(2);
            btDelete.Name = "btDelete";
            btDelete.Size = new System.Drawing.Size(144, 33);
            btDelete.TabIndex = 37;
            btDelete.Text = "VERWIJDEREN";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Visible = false;
            btDelete.Click += btDelete_Click;
            // 
            // btSave
            // 
            btSave.Location = new System.Drawing.Point(355, 169);
            btSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btSave.Name = "btSave";
            btSave.Size = new System.Drawing.Size(108, 38);
            btSave.TabIndex = 36;
            btSave.Text = "Opslaan";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new System.Drawing.Point(239, 169);
            btCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btCancel.Name = "btCancel";
            btCancel.Size = new System.Drawing.Size(108, 38);
            btCancel.TabIndex = 35;
            btCancel.Text = "Annuleer";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 25);
            label1.TabIndex = 39;
            label1.Text = "Start dag";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 55);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 25);
            label2.TabIndex = 40;
            label2.Text = "Eind dag";
            // 
            // fLeaveEvent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(477, 219);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbTechnicians);
            Controls.Add(label3);
            Controls.Add(tbTechName);
            Controls.Add(btDelete);
            Controls.Add(btSave);
            Controls.Add(btCancel);
            Controls.Add(dtpStart);
            Controls.Add(dtpEnd);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "fLeaveEvent";
            Text = "Verlof";
            FormClosed += fLeaveEvent_FormClosed;
            ResumeLayout(false);
            PerformLayout();
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