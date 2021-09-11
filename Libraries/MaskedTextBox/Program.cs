using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;


namespace Opulos.Core.UI {

static class Program {

	[STAThread]
	static void Main() {
		//System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ja-JP");
		//System.Threading.Thread.CurrentThread.CurrentCulture = ci;
		//System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);

//TextOverlay.TestAlgorithm();
//return;

		Form f = new Form();
		var p = new MaskedTextBoxDemoPanel();
		f.Controls.Add(p);
		f.Font = new Font(SystemFonts.MenuFont.FontFamily, 12f, FontStyle.Regular);
		var s = new Size(600, 700);
		f.ClientSize = s;
		f.StartPosition = FormStartPosition.CenterScreen;
		//f.StartPosition = FormStartPosition.Manual;
		//f.Location = new Point(630, 200);
		Application.Run(f);

	}
}
}