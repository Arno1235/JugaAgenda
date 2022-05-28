
namespace JugaAgenda_v2
{
    partial class fCalendarEvent
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMinuteEnd = new System.Windows.Forms.ComboBox();
            this.cbMinuteStart = new System.Windows.Forms.ComboBox();
            this.cbFullDays = new System.Windows.Forms.CheckBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cbHourStart = new System.Windows.Forms.ComboBox();
            this.cbHourEnd = new System.Windows.Forms.ComboBox();
            this.nuHours = new System.Windows.Forms.NumericUpDown();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.nuHours);
            this.groupBox1.Controls.Add(this.tbOrderNumber);
            this.groupBox1.Controls.Add(this.tbPhoneNumber);
            this.groupBox1.Controls.Add(this.tbClientName);
            this.groupBox1.Controls.Add(this.rtbDescription);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(639, 822);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btDelete
            // 
            this.btDelete.ForeColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(22, 763);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(131, 40);
            this.btDelete.TabIndex = 21;
            this.btDelete.Text = "DELETE";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Visible = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(487, 760);
            this.btSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(129, 46);
            this.btSave.TabIndex = 20;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(348, 760);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(129, 46);
            this.btCancel.TabIndex = 19;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 708);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "Order number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 30);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 650);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Phone number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 592);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 30);
            this.label3.TabIndex = 15;
            this.label3.Text = "Client name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 346);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 294);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbMinuteEnd);
            this.groupBox2.Controls.Add(this.cbMinuteStart);
            this.groupBox2.Controls.Add(this.cbFullDays);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.cbHourStart);
            this.groupBox2.Controls.Add(this.cbHourEnd);
            this.groupBox2.Location = new System.Drawing.Point(21, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(595, 232);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date and Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(466, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 30);
            this.label8.TabIndex = 8;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(466, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = ":";
            // 
            // cbMinuteEnd
            // 
            this.cbMinuteEnd.FormattingEnabled = true;
            this.cbMinuteEnd.Location = new System.Drawing.Point(494, 154);
            this.cbMinuteEnd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbMinuteEnd.Name = "cbMinuteEnd";
            this.cbMinuteEnd.Size = new System.Drawing.Size(88, 38);
            this.cbMinuteEnd.TabIndex = 6;
            // 
            // cbMinuteStart
            // 
            this.cbMinuteStart.FormattingEnabled = true;
            this.cbMinuteStart.Location = new System.Drawing.Point(494, 94);
            this.cbMinuteStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbMinuteStart.Name = "cbMinuteStart";
            this.cbMinuteStart.Size = new System.Drawing.Size(88, 38);
            this.cbMinuteStart.TabIndex = 5;
            // 
            // cbFullDays
            // 
            this.cbFullDays.AutoSize = true;
            this.cbFullDays.Location = new System.Drawing.Point(10, 44);
            this.cbFullDays.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbFullDays.Name = "cbFullDays";
            this.cbFullDays.Size = new System.Drawing.Size(119, 34);
            this.cbFullDays.TabIndex = 1;
            this.cbFullDays.Text = "Full days";
            this.cbFullDays.UseVisualStyleBackColor = true;
            this.cbFullDays.CheckedChanged += new System.EventHandler(this.cbFullDays_CheckedChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(10, 94);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(340, 35);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(12, 154);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(340, 35);
            this.dtpEnd.TabIndex = 2;
            // 
            // cbHourStart
            // 
            this.cbHourStart.FormattingEnabled = true;
            this.cbHourStart.Location = new System.Drawing.Point(365, 94);
            this.cbHourStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbHourStart.Name = "cbHourStart";
            this.cbHourStart.Size = new System.Drawing.Size(88, 38);
            this.cbHourStart.TabIndex = 3;
            // 
            // cbHourEnd
            // 
            this.cbHourEnd.FormattingEnabled = true;
            this.cbHourEnd.Location = new System.Drawing.Point(365, 154);
            this.cbHourEnd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbHourEnd.Name = "cbHourEnd";
            this.cbHourEnd.Size = new System.Drawing.Size(88, 38);
            this.cbHourEnd.TabIndex = 4;
            // 
            // nuHours
            // 
            this.nuHours.DecimalPlaces = 1;
            this.nuHours.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuHours.Location = new System.Drawing.Point(525, 288);
            this.nuHours.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nuHours.Name = "nuHours";
            this.nuHours.Size = new System.Drawing.Size(81, 35);
            this.nuHours.TabIndex = 11;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(178, 702);
            this.tbOrderNumber.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(434, 35);
            this.tbOrderNumber.TabIndex = 9;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(178, 644);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(434, 35);
            this.tbPhoneNumber.TabIndex = 8;
            // 
            // tbClientName
            // 
            this.tbClientName.Location = new System.Drawing.Point(178, 586);
            this.tbClientName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(434, 35);
            this.tbClientName.TabIndex = 7;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(21, 382);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(592, 188);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.Text = "";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(99, 288);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(335, 38);
            this.cbStatus.TabIndex = 5;
            // 
            // fCalendarEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 822);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "fCalendarEvent";
            this.Text = "Calendar Event";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbHourEnd;
        private System.Windows.Forms.ComboBox cbHourStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox cbFullDays;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nuHours;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.TextBox tbClientName;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMinuteEnd;
        private System.Windows.Forms.ComboBox cbMinuteStart;
        private System.Windows.Forms.Button btDelete;
    }
}