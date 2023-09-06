namespace JugaAgenda_v2.Screens
{
    partial class fCustomMessageBox
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
            labMessage = new System.Windows.Forms.Label();
            bt1 = new System.Windows.Forms.Button();
            bt2 = new System.Windows.Forms.Button();
            bt3 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labMessage
            // 
            labMessage.AutoSize = true;
            labMessage.Location = new System.Drawing.Point(12, 9);
            labMessage.Name = "labMessage";
            labMessage.Size = new System.Drawing.Size(82, 25);
            labMessage.TabIndex = 0;
            labMessage.Text = "Message";
            // 
            // bt1
            // 
            bt1.Location = new System.Drawing.Point(12, 37);
            bt1.Name = "bt1";
            bt1.Size = new System.Drawing.Size(112, 34);
            bt1.TabIndex = 1;
            bt1.Text = "button1";
            bt1.UseVisualStyleBackColor = true;
            bt1.Click += bt1_Click;
            // 
            // bt2
            // 
            bt2.Location = new System.Drawing.Point(130, 37);
            bt2.Name = "bt2";
            bt2.Size = new System.Drawing.Size(112, 34);
            bt2.TabIndex = 2;
            bt2.Text = "button2";
            bt2.UseVisualStyleBackColor = true;
            bt2.Click += bt2_Click;
            // 
            // bt3
            // 
            bt3.Location = new System.Drawing.Point(248, 37);
            bt3.Name = "bt3";
            bt3.Size = new System.Drawing.Size(112, 34);
            bt3.TabIndex = 3;
            bt3.Text = "button3";
            bt3.UseVisualStyleBackColor = true;
            bt3.Click += bt3_Click;
            // 
            // fCustomMessageBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(374, 89);
            Controls.Add(bt3);
            Controls.Add(bt2);
            Controls.Add(bt1);
            Controls.Add(labMessage);
            Name = "fCustomMessageBox";
            Text = "fCustomMessageBox";
            TopMost = true;
            FormClosed += fCustomMessageBox_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
    }
}