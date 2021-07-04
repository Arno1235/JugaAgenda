
namespace JugaAgenda
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupZondag = new System.Windows.Forms.GroupBox();
            this.numZondagUren = new System.Windows.Forms.NumericUpDown();
            this.listZondag = new System.Windows.Forms.ListBox();
            this.groupZaterdag = new System.Windows.Forms.GroupBox();
            this.numZaterdagUren = new System.Windows.Forms.NumericUpDown();
            this.listZaterdag = new System.Windows.Forms.ListBox();
            this.groupVrijdag = new System.Windows.Forms.GroupBox();
            this.numVrijdagUren = new System.Windows.Forms.NumericUpDown();
            this.listVrijdag = new System.Windows.Forms.ListBox();
            this.groupDonderdag = new System.Windows.Forms.GroupBox();
            this.numDonderdagUren = new System.Windows.Forms.NumericUpDown();
            this.listDonderdag = new System.Windows.Forms.ListBox();
            this.groupWoensdag = new System.Windows.Forms.GroupBox();
            this.numWoensdagUren = new System.Windows.Forms.NumericUpDown();
            this.listWoensdag = new System.Windows.Forms.ListBox();
            this.groupDinsdag = new System.Windows.Forms.GroupBox();
            this.numDinsdagUren = new System.Windows.Forms.NumericUpDown();
            this.listDinsdag = new System.Windows.Forms.ListBox();
            this.groupMaandag = new System.Windows.Forms.GroupBox();
            this.numMaandagUren = new System.Windows.Forms.NumericUpDown();
            this.listMaandag = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numWerkUren = new System.Windows.Forms.NumericUpDown();
            this.checkWerkPrioriteit = new System.Windows.Forms.CheckBox();
            this.textWerkBeschrijving = new System.Windows.Forms.TextBox();
            this.butWerkToevoegen = new System.Windows.Forms.Button();
            this.listWerk = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupZondag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZondagUren)).BeginInit();
            this.groupZaterdag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZaterdagUren)).BeginInit();
            this.groupVrijdag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVrijdagUren)).BeginInit();
            this.groupDonderdag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonderdagUren)).BeginInit();
            this.groupWoensdag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWoensdagUren)).BeginInit();
            this.groupDinsdag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDinsdagUren)).BeginInit();
            this.groupMaandag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaandagUren)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWerkUren)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1278, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupZondag);
            this.tabPage1.Controls.Add(this.groupZaterdag);
            this.tabPage1.Controls.Add(this.groupVrijdag);
            this.tabPage1.Controls.Add(this.groupDonderdag);
            this.tabPage1.Controls.Add(this.groupWoensdag);
            this.tabPage1.Controls.Add(this.groupDinsdag);
            this.tabPage1.Controls.Add(this.groupMaandag);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1270, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agenda";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupZondag
            // 
            this.groupZondag.AutoSize = true;
            this.groupZondag.Controls.Add(this.numZondagUren);
            this.groupZondag.Controls.Add(this.listZondag);
            this.groupZondag.Location = new System.Drawing.Point(1082, 6);
            this.groupZondag.Name = "groupZondag";
            this.groupZondag.Size = new System.Drawing.Size(173, 443);
            this.groupZondag.TabIndex = 7;
            this.groupZondag.TabStop = false;
            this.groupZondag.Text = "Zondag";
            // 
            // numZondagUren
            // 
            this.numZondagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numZondagUren.Location = new System.Drawing.Point(3, 417);
            this.numZondagUren.Name = "numZondagUren";
            this.numZondagUren.Size = new System.Drawing.Size(167, 23);
            this.numZondagUren.TabIndex = 1;
            // 
            // listZondag
            // 
            this.listZondag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listZondag.FormattingEnabled = true;
            this.listZondag.ItemHeight = 15;
            this.listZondag.Location = new System.Drawing.Point(3, 19);
            this.listZondag.Name = "listZondag";
            this.listZondag.Size = new System.Drawing.Size(167, 421);
            this.listZondag.TabIndex = 0;
            // 
            // groupZaterdag
            // 
            this.groupZaterdag.AutoSize = true;
            this.groupZaterdag.Controls.Add(this.numZaterdagUren);
            this.groupZaterdag.Controls.Add(this.listZaterdag);
            this.groupZaterdag.Location = new System.Drawing.Point(903, 6);
            this.groupZaterdag.Name = "groupZaterdag";
            this.groupZaterdag.Size = new System.Drawing.Size(173, 443);
            this.groupZaterdag.TabIndex = 6;
            this.groupZaterdag.TabStop = false;
            this.groupZaterdag.Text = "Zaterdag";
            // 
            // numZaterdagUren
            // 
            this.numZaterdagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numZaterdagUren.Location = new System.Drawing.Point(3, 417);
            this.numZaterdagUren.Name = "numZaterdagUren";
            this.numZaterdagUren.Size = new System.Drawing.Size(167, 23);
            this.numZaterdagUren.TabIndex = 1;
            // 
            // listZaterdag
            // 
            this.listZaterdag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listZaterdag.FormattingEnabled = true;
            this.listZaterdag.ItemHeight = 15;
            this.listZaterdag.Location = new System.Drawing.Point(3, 19);
            this.listZaterdag.Name = "listZaterdag";
            this.listZaterdag.Size = new System.Drawing.Size(167, 421);
            this.listZaterdag.TabIndex = 0;
            // 
            // groupVrijdag
            // 
            this.groupVrijdag.AutoSize = true;
            this.groupVrijdag.Controls.Add(this.numVrijdagUren);
            this.groupVrijdag.Controls.Add(this.listVrijdag);
            this.groupVrijdag.Location = new System.Drawing.Point(724, 6);
            this.groupVrijdag.Name = "groupVrijdag";
            this.groupVrijdag.Size = new System.Drawing.Size(173, 443);
            this.groupVrijdag.TabIndex = 5;
            this.groupVrijdag.TabStop = false;
            this.groupVrijdag.Text = "Vrijdag";
            // 
            // numVrijdagUren
            // 
            this.numVrijdagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numVrijdagUren.Location = new System.Drawing.Point(3, 417);
            this.numVrijdagUren.Name = "numVrijdagUren";
            this.numVrijdagUren.Size = new System.Drawing.Size(167, 23);
            this.numVrijdagUren.TabIndex = 1;
            // 
            // listVrijdag
            // 
            this.listVrijdag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVrijdag.FormattingEnabled = true;
            this.listVrijdag.ItemHeight = 15;
            this.listVrijdag.Location = new System.Drawing.Point(3, 19);
            this.listVrijdag.Name = "listVrijdag";
            this.listVrijdag.Size = new System.Drawing.Size(167, 421);
            this.listVrijdag.TabIndex = 0;
            // 
            // groupDonderdag
            // 
            this.groupDonderdag.AutoSize = true;
            this.groupDonderdag.Controls.Add(this.numDonderdagUren);
            this.groupDonderdag.Controls.Add(this.listDonderdag);
            this.groupDonderdag.Location = new System.Drawing.Point(545, 6);
            this.groupDonderdag.Name = "groupDonderdag";
            this.groupDonderdag.Size = new System.Drawing.Size(173, 443);
            this.groupDonderdag.TabIndex = 4;
            this.groupDonderdag.TabStop = false;
            this.groupDonderdag.Text = "Donderdag";
            // 
            // numDonderdagUren
            // 
            this.numDonderdagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numDonderdagUren.Location = new System.Drawing.Point(3, 417);
            this.numDonderdagUren.Name = "numDonderdagUren";
            this.numDonderdagUren.Size = new System.Drawing.Size(167, 23);
            this.numDonderdagUren.TabIndex = 1;
            // 
            // listDonderdag
            // 
            this.listDonderdag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDonderdag.FormattingEnabled = true;
            this.listDonderdag.ItemHeight = 15;
            this.listDonderdag.Location = new System.Drawing.Point(3, 19);
            this.listDonderdag.Name = "listDonderdag";
            this.listDonderdag.Size = new System.Drawing.Size(167, 421);
            this.listDonderdag.TabIndex = 0;
            // 
            // groupWoensdag
            // 
            this.groupWoensdag.AutoSize = true;
            this.groupWoensdag.Controls.Add(this.numWoensdagUren);
            this.groupWoensdag.Controls.Add(this.listWoensdag);
            this.groupWoensdag.Location = new System.Drawing.Point(366, 6);
            this.groupWoensdag.Name = "groupWoensdag";
            this.groupWoensdag.Size = new System.Drawing.Size(173, 443);
            this.groupWoensdag.TabIndex = 3;
            this.groupWoensdag.TabStop = false;
            this.groupWoensdag.Text = "Woensdag";
            // 
            // numWoensdagUren
            // 
            this.numWoensdagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numWoensdagUren.Location = new System.Drawing.Point(3, 417);
            this.numWoensdagUren.Name = "numWoensdagUren";
            this.numWoensdagUren.Size = new System.Drawing.Size(167, 23);
            this.numWoensdagUren.TabIndex = 1;
            // 
            // listWoensdag
            // 
            this.listWoensdag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listWoensdag.FormattingEnabled = true;
            this.listWoensdag.ItemHeight = 15;
            this.listWoensdag.Location = new System.Drawing.Point(3, 19);
            this.listWoensdag.Name = "listWoensdag";
            this.listWoensdag.Size = new System.Drawing.Size(167, 421);
            this.listWoensdag.TabIndex = 0;
            // 
            // groupDinsdag
            // 
            this.groupDinsdag.AutoSize = true;
            this.groupDinsdag.Controls.Add(this.numDinsdagUren);
            this.groupDinsdag.Controls.Add(this.listDinsdag);
            this.groupDinsdag.Location = new System.Drawing.Point(187, 6);
            this.groupDinsdag.Name = "groupDinsdag";
            this.groupDinsdag.Size = new System.Drawing.Size(173, 443);
            this.groupDinsdag.TabIndex = 2;
            this.groupDinsdag.TabStop = false;
            this.groupDinsdag.Text = "Dinsdag";
            // 
            // numDinsdagUren
            // 
            this.numDinsdagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numDinsdagUren.Location = new System.Drawing.Point(3, 417);
            this.numDinsdagUren.Name = "numDinsdagUren";
            this.numDinsdagUren.Size = new System.Drawing.Size(167, 23);
            this.numDinsdagUren.TabIndex = 1;
            // 
            // listDinsdag
            // 
            this.listDinsdag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDinsdag.FormattingEnabled = true;
            this.listDinsdag.ItemHeight = 15;
            this.listDinsdag.Location = new System.Drawing.Point(3, 19);
            this.listDinsdag.Name = "listDinsdag";
            this.listDinsdag.Size = new System.Drawing.Size(167, 421);
            this.listDinsdag.TabIndex = 0;
            // 
            // groupMaandag
            // 
            this.groupMaandag.AutoSize = true;
            this.groupMaandag.Controls.Add(this.numMaandagUren);
            this.groupMaandag.Controls.Add(this.listMaandag);
            this.groupMaandag.Location = new System.Drawing.Point(8, 6);
            this.groupMaandag.Name = "groupMaandag";
            this.groupMaandag.Size = new System.Drawing.Size(173, 443);
            this.groupMaandag.TabIndex = 1;
            this.groupMaandag.TabStop = false;
            this.groupMaandag.Text = "Maandag";
            // 
            // numMaandagUren
            // 
            this.numMaandagUren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numMaandagUren.Location = new System.Drawing.Point(3, 417);
            this.numMaandagUren.Name = "numMaandagUren";
            this.numMaandagUren.Size = new System.Drawing.Size(167, 23);
            this.numMaandagUren.TabIndex = 1;
            // 
            // listMaandag
            // 
            this.listMaandag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMaandag.FormattingEnabled = true;
            this.listMaandag.ItemHeight = 15;
            this.listMaandag.Location = new System.Drawing.Point(3, 19);
            this.listMaandag.Name = "listMaandag";
            this.listMaandag.Size = new System.Drawing.Size(167, 421);
            this.listMaandag.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numWerkUren);
            this.tabPage2.Controls.Add(this.checkWerkPrioriteit);
            this.tabPage2.Controls.Add(this.textWerkBeschrijving);
            this.tabPage2.Controls.Add(this.butWerkToevoegen);
            this.tabPage2.Controls.Add(this.listWerk);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1270, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bewerken";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numWerkUren
            // 
            this.numWerkUren.Location = new System.Drawing.Point(325, 36);
            this.numWerkUren.Name = "numWerkUren";
            this.numWerkUren.Size = new System.Drawing.Size(59, 23);
            this.numWerkUren.TabIndex = 5;
            // 
            // checkWerkPrioriteit
            // 
            this.checkWerkPrioriteit.AutoSize = true;
            this.checkWerkPrioriteit.Location = new System.Drawing.Point(465, 40);
            this.checkWerkPrioriteit.Name = "checkWerkPrioriteit";
            this.checkWerkPrioriteit.Size = new System.Drawing.Size(71, 19);
            this.checkWerkPrioriteit.TabIndex = 4;
            this.checkWerkPrioriteit.Text = "Prioriteit";
            this.checkWerkPrioriteit.UseVisualStyleBackColor = true;
            // 
            // textWerkBeschrijving
            // 
            this.textWerkBeschrijving.Location = new System.Drawing.Point(325, 6);
            this.textWerkBeschrijving.Name = "textWerkBeschrijving";
            this.textWerkBeschrijving.Size = new System.Drawing.Size(211, 23);
            this.textWerkBeschrijving.TabIndex = 2;
            // 
            // butWerkToevoegen
            // 
            this.butWerkToevoegen.Location = new System.Drawing.Point(461, 65);
            this.butWerkToevoegen.Name = "butWerkToevoegen";
            this.butWerkToevoegen.Size = new System.Drawing.Size(75, 23);
            this.butWerkToevoegen.TabIndex = 1;
            this.butWerkToevoegen.Text = "Teovoegen";
            this.butWerkToevoegen.UseVisualStyleBackColor = true;
            this.butWerkToevoegen.Click += new System.EventHandler(this.butWerkToevoegen_Click);
            // 
            // listWerk
            // 
            this.listWerk.Dock = System.Windows.Forms.DockStyle.Left;
            this.listWerk.FormattingEnabled = true;
            this.listWerk.ItemHeight = 15;
            this.listWerk.Location = new System.Drawing.Point(3, 3);
            this.listWerk.Name = "listWerk";
            this.listWerk.Size = new System.Drawing.Size(316, 456);
            this.listWerk.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUpdate,
            this.menuInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Menu";
            // 
            // menuUpdate
            // 
            this.menuUpdate.Name = "menuUpdate";
            this.menuUpdate.Size = new System.Drawing.Size(57, 20);
            this.menuUpdate.Text = "Update";
            this.menuUpdate.Click += new System.EventHandler(this.menuUpdate_Click);
            // 
            // menuInfo
            // 
            this.menuInfo.Name = "menuInfo";
            this.menuInfo.Size = new System.Drawing.Size(40, 20);
            this.menuInfo.Text = "Info";
            this.menuInfo.Click += new System.EventHandler(this.menuInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 514);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Juga Agenda";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupZondag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numZondagUren)).EndInit();
            this.groupZaterdag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numZaterdagUren)).EndInit();
            this.groupVrijdag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numVrijdagUren)).EndInit();
            this.groupDonderdag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDonderdagUren)).EndInit();
            this.groupWoensdag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWoensdagUren)).EndInit();
            this.groupDinsdag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDinsdagUren)).EndInit();
            this.groupMaandag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMaandagUren)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWerkUren)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate;
        private System.Windows.Forms.ListBox listWerk;
        private System.Windows.Forms.Button butWerkToevoegen;
        private System.Windows.Forms.NumericUpDown numWerkUren;
        private System.Windows.Forms.CheckBox checkWerkPrioriteit;
        private System.Windows.Forms.TextBox textWerkBeschrijving;
        private System.Windows.Forms.GroupBox groupMaandag;
        private System.Windows.Forms.NumericUpDown numMaandagUren;
        private System.Windows.Forms.ListBox listMaandag;
        private System.Windows.Forms.GroupBox groupDonderdag;
        private System.Windows.Forms.NumericUpDown numDonderdagUren;
        private System.Windows.Forms.ListBox listDonderdag;
        private System.Windows.Forms.GroupBox groupWoensdag;
        private System.Windows.Forms.NumericUpDown numWoensdagUren;
        private System.Windows.Forms.ListBox listWoensdag;
        private System.Windows.Forms.GroupBox groupDinsdag;
        private System.Windows.Forms.NumericUpDown numDinsdagUren;
        private System.Windows.Forms.ListBox listDinsdag;
        private System.Windows.Forms.GroupBox groupZondag;
        private System.Windows.Forms.NumericUpDown numZondagUren;
        private System.Windows.Forms.ListBox listZondag;
        private System.Windows.Forms.GroupBox groupZaterdag;
        private System.Windows.Forms.NumericUpDown numZaterdagUren;
        private System.Windows.Forms.ListBox listZaterdag;
        private System.Windows.Forms.GroupBox groupVrijdag;
        private System.Windows.Forms.NumericUpDown numVrijdagUren;
        private System.Windows.Forms.ListBox listVrijdag;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;
    }
}

