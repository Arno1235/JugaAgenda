namespace JugaAgenda_v2
{
    partial class fAvailability
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
            this.label5 = new System.Windows.Forms.Label();
            this.nuHours = new System.Windows.Forms.NumericUpDown();
            this.lbAvailableResults = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 30);
            this.label5.TabIndex = 19;
            this.label5.Text = "Hours";
            // 
            // nuHours
            // 
            this.nuHours.DecimalPlaces = 1;
            this.nuHours.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuHours.Location = new System.Drawing.Point(92, 15);
            this.nuHours.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nuHours.Name = "nuHours";
            this.nuHours.Size = new System.Drawing.Size(81, 35);
            this.nuHours.TabIndex = 18;
            this.nuHours.ValueChanged += new System.EventHandler(this.nuHours_ValueChanged);
            // 
            // lbAvailableResults
            // 
            this.lbAvailableResults.FormattingEnabled = true;
            this.lbAvailableResults.ItemHeight = 30;
            this.lbAvailableResults.Location = new System.Drawing.Point(12, 59);
            this.lbAvailableResults.Name = "lbAvailableResults";
            this.lbAvailableResults.Size = new System.Drawing.Size(461, 604);
            this.lbAvailableResults.TabIndex = 20;
            this.lbAvailableResults.DoubleClick += new System.EventHandler(this.lbAvailableResults_DoubleClick);
            // 
            // fAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 675);
            this.Controls.Add(this.lbAvailableResults);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nuHours);
            this.Name = "fAvailability";
            this.Text = "fAvailability";
            this.Resize += new System.EventHandler(this.fAvailability_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nuHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nuHours;
        private System.Windows.Forms.ListBox lbAvailableResults;
    }
}