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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpComponents = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbComponents = new ComponentsListBox();
            this.tabControl1.SuspendLayout();
            this.tpComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpComponents);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1545, 1064);
            this.tabControl1.TabIndex = 0;
            // 
            // tpComponents
            // 
            this.tpComponents.Controls.Add(this.lbComponents);
            this.tpComponents.Controls.Add(this.label1);
            this.tpComponents.Controls.Add(this.numericUpDown1);
            this.tpComponents.Location = new System.Drawing.Point(4, 39);
            this.tpComponents.Name = "tpComponents";
            this.tpComponents.Padding = new System.Windows.Forms.Padding(3);
            this.tpComponents.Size = new System.Drawing.Size(1537, 1021);
            this.tpComponents.TabIndex = 0;
            this.tpComponents.Text = "Onderdelen";
            this.tpComponents.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 132);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(278, 6);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 35);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Weken om vooruit te kijken";
            // 
            // lbComponents
            // 
            this.lbComponents.FormattingEnabled = true;
            this.lbComponents.ItemHeight = 30;
            this.lbComponents.Location = new System.Drawing.Point(8, 47);
            this.lbComponents.Name = "lbComponents";
            this.lbComponents.Size = new System.Drawing.Size(699, 514);
            this.lbComponents.TabIndex = 2;
            // 
            // fPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 1064);
            this.Controls.Add(this.tabControl1);
            this.Name = "fPlanning";
            this.Text = "fPlanning";
            this.tabControl1.ResumeLayout(false);
            this.tpComponents.ResumeLayout(false);
            this.tpComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpComponents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TabPage tabPage2;
        private ComponentsListBox lbComponents;
    }
}