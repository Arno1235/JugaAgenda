namespace JugaAgenda_v2.Screens
{
    partial class fExtraEvent
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
            label1 = new System.Windows.Forms.Label();
            tbTitle = new System.Windows.Forms.TextBox();
            rtbDescription = new System.Windows.Forms.RichTextBox();
            label2 = new System.Windows.Forms.Label();
            cbClosed = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            dtpStart = new System.Windows.Forms.DateTimePicker();
            dtpEnd = new System.Windows.Forms.DateTimePicker();
            btDelete = new System.Windows.Forms.Button();
            btSave = new System.Windows.Forms.Button();
            btCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 91);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 25);
            label1.TabIndex = 0;
            label1.Text = "Titel:";
            // 
            // tbTitle
            // 
            tbTitle.Location = new System.Drawing.Point(68, 88);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new System.Drawing.Size(542, 31);
            tbTitle.TabIndex = 1;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new System.Drawing.Point(14, 185);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new System.Drawing.Size(596, 276);
            rtbDescription.TabIndex = 2;
            rtbDescription.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(14, 157);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(199, 25);
            label2.TabIndex = 3;
            label2.Text = "Beschrijving (optioneel):";
            // 
            // cbClosed
            // 
            cbClosed.AutoSize = true;
            cbClosed.Location = new System.Drawing.Point(145, 132);
            cbClosed.Name = "cbClosed";
            cbClosed.Size = new System.Drawing.Size(22, 21);
            cbClosed.TabIndex = 4;
            cbClosed.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(14, 128);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(125, 25);
            label3.TabIndex = 5;
            label3.Text = "Winkel sluiten:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(13, 48);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 25);
            label4.TabIndex = 44;
            label4.Text = "Eind dag:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(13, 9);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(88, 25);
            label5.TabIndex = 43;
            label5.Text = "Start dag:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new System.Drawing.Point(109, 9);
            dtpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new System.Drawing.Size(499, 31);
            dtpStart.TabIndex = 41;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new System.Drawing.Point(109, 49);
            dtpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new System.Drawing.Size(501, 31);
            dtpEnd.TabIndex = 42;
            // 
            // btDelete
            // 
            btDelete.ForeColor = System.Drawing.Color.Red;
            btDelete.Location = new System.Drawing.Point(14, 466);
            btDelete.Margin = new System.Windows.Forms.Padding(2);
            btDelete.Name = "btDelete";
            btDelete.Size = new System.Drawing.Size(144, 33);
            btDelete.TabIndex = 47;
            btDelete.Text = "VERWIJDEREN";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Visible = false;
            btDelete.Click += btDelete_Click;
            // 
            // btSave
            // 
            btSave.Location = new System.Drawing.Point(502, 463);
            btSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btSave.Name = "btSave";
            btSave.Size = new System.Drawing.Size(108, 38);
            btSave.TabIndex = 46;
            btSave.Text = "Opslaan";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new System.Drawing.Point(386, 463);
            btCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btCancel.Name = "btCancel";
            btCancel.Size = new System.Drawing.Size(108, 38);
            btCancel.TabIndex = 45;
            btCancel.Text = "Annuleer";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // fExtraEvent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(626, 512);
            Controls.Add(btDelete);
            Controls.Add(btSave);
            Controls.Add(btCancel);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(dtpStart);
            Controls.Add(dtpEnd);
            Controls.Add(label3);
            Controls.Add(cbClosed);
            Controls.Add(label2);
            Controls.Add(rtbDescription);
            Controls.Add(tbTitle);
            Controls.Add(label1);
            Name = "fExtraEvent";
            Text = "fExtraEvent";
            FormClosed += fExtraEvent_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbClosed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
    }
}