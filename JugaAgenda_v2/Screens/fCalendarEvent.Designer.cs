
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbTechnicians = new System.Windows.Forms.ListBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.cbTechnician = new System.Windows.Forms.ComboBox();
            this.nuTechHours = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btAvailability = new System.Windows.Forms.Button();
            this.nuHours = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
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
            this.nuHoursDone = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTechHours)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHoursDone)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(639, 1045);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbTechnicians);
            this.groupBox4.Controls.Add(this.btAdd);
            this.groupBox4.Controls.Add(this.cbTechnician);
            this.groupBox4.Controls.Add(this.nuTechHours);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(21, 757);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(595, 224);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Technicians";
            // 
            // lbTechnicians
            // 
            this.lbTechnicians.FormattingEnabled = true;
            this.lbTechnicians.ItemHeight = 30;
            this.lbTechnicians.Location = new System.Drawing.Point(12, 84);
            this.lbTechnicians.Name = "lbTechnicians";
            this.lbTechnicians.Size = new System.Drawing.Size(570, 124);
            this.lbTechnicians.TabIndex = 22;
            this.lbTechnicians.DoubleClick += new System.EventHandler(this.lbTechnicians_DoubleClick);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(509, 29);
            this.btAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(73, 46);
            this.btAdd.TabIndex = 21;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // cbTechnician
            // 
            this.cbTechnician.FormattingEnabled = true;
            this.cbTechnician.Location = new System.Drawing.Point(12, 34);
            this.cbTechnician.Name = "cbTechnician";
            this.cbTechnician.Size = new System.Drawing.Size(320, 38);
            this.cbTechnician.TabIndex = 20;
            // 
            // nuTechHours
            // 
            this.nuTechHours.DecimalPlaces = 1;
            this.nuTechHours.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuTechHours.Location = new System.Drawing.Point(418, 35);
            this.nuTechHours.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nuTechHours.Name = "nuTechHours";
            this.nuTechHours.Size = new System.Drawing.Size(81, 35);
            this.nuTechHours.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 30);
            this.label9.TabIndex = 19;
            this.label9.Text = "Hours";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nuHoursDone);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cbStatus);
            this.groupBox3.Controls.Add(this.btAvailability);
            this.groupBox3.Controls.Add(this.nuHours);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rtbDescription);
            this.groupBox3.Controls.Add(this.tbClientName);
            this.groupBox3.Controls.Add(this.tbOrderNumber);
            this.groupBox3.Controls.Add(this.tbPhoneNumber);
            this.groupBox3.Location = new System.Drawing.Point(21, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 513);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Main Information";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(87, 38);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(495, 38);
            this.cbStatus.TabIndex = 5;
            // 
            // btAvailability
            // 
            this.btAvailability.Location = new System.Drawing.Point(175, 83);
            this.btAvailability.Name = "btAvailability";
            this.btAvailability.Size = new System.Drawing.Size(134, 40);
            this.btAvailability.TabIndex = 22;
            this.btAvailability.Text = "Availability";
            this.btAvailability.UseVisualStyleBackColor = true;
            this.btAvailability.Click += new System.EventHandler(this.btAvailability_Click);
            // 
            // nuHours
            // 
            this.nuHours.DecimalPlaces = 1;
            this.nuHours.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuHours.Location = new System.Drawing.Point(86, 86);
            this.nuHours.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nuHours.Name = "nuHours";
            this.nuHours.Size = new System.Drawing.Size(81, 35);
            this.nuHours.TabIndex = 11;
            this.nuHours.ValueChanged += new System.EventHandler(this.nuHours_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 460);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "Order number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 30);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 413);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Phone number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 366);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 30);
            this.label3.TabIndex = 15;
            this.label3.Text = "Client name";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(12, 163);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(570, 188);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.Text = "";
            // 
            // tbClientName
            // 
            this.tbClientName.Location = new System.Drawing.Point(175, 363);
            this.tbClientName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(407, 35);
            this.tbClientName.TabIndex = 7;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(175, 457);
            this.tbOrderNumber.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(407, 35);
            this.tbOrderNumber.TabIndex = 9;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(175, 410);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(407, 35);
            this.tbPhoneNumber.TabIndex = 8;
            // 
            // btDelete
            // 
            this.btDelete.ForeColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(21, 993);
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
            this.btSave.Location = new System.Drawing.Point(486, 990);
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
            this.btCancel.Location = new System.Drawing.Point(347, 990);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(129, 46);
            this.btCancel.TabIndex = 19;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(21, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(595, 214);
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
            // nuHoursDone
            // 
            this.nuHoursDone.DecimalPlaces = 1;
            this.nuHoursDone.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuHoursDone.Location = new System.Drawing.Point(501, 86);
            this.nuHoursDone.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nuHoursDone.Name = "nuHoursDone";
            this.nuHoursDone.Size = new System.Drawing.Size(81, 35);
            this.nuHoursDone.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(370, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 30);
            this.label10.TabIndex = 24;
            this.label10.Text = "Hours done";
            // 
            // fCalendarEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 1045);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "fCalendarEvent";
            this.Text = "Calendar Event";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTechHours)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuHoursDone)).EndInit();
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
        private System.Windows.Forms.Button btAvailability;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbTechnician;
        private System.Windows.Forms.NumericUpDown nuTechHours;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbTechnicians;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.NumericUpDown nuHoursDone;
        private System.Windows.Forms.Label label10;
    }
}