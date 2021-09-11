using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Opulos.Core.UI {

public class SpinControlTestPanel : FlowLayoutPanel {

	public SpinControlTestPanel() {
		SpinControl sc = new SpinControl();
		TextBox tbb = new TextBox();
		int k = 0;
		StringBuilder sb2 = new StringBuilder();
		DateTime? now3 = null;
		sc.UpClicked += delegate {
			tbb.Text = k.ToString();
			k++;

			if (now3 == null)
				now3 = DateTime.UtcNow;
			else {
				DateTime now4 = DateTime.UtcNow;
				sb2.AppendLine((now4 - now3.Value).TotalMilliseconds.ToString());
				now3 = now4;
			}
		};
		sc.DownClicked += delegate {
			k--;
			tbb.Text = k.ToString();
		};

		tbb.Controls.Add(sc);

		SpinControl scModern = new SpinControl { ButtonStyle = SpinButtonStyle.Modern };
		TextBox tbb2 = new TextBox();
		tbb2.Controls.Add(scModern);

		DateTimePicker dp = new DateTimePicker();
		dp.Location = new Point(10, 70);
		dp.ShowUpDown = true;

		NumericUpDown nud2 = new NumericUpDown { Minimum = 6, Maximum = 100, Increment = 0.25m, DecimalPlaces = 2 };
		nud2.ValueChanged += delegate {
			this.Font = new Font(Font.FontFamily, Convert.ToSingle(nud2.Value), Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
		};
		nud2.Value = 8;

		DateTime? now = null;
		StringBuilder sb = new StringBuilder();
		nud2.ValueChanged += delegate {
			if (now == null)
				now = DateTime.UtcNow;
			else {
				DateTime now2 = DateTime.UtcNow;
				sb.AppendLine((now2 - now.Value).TotalMilliseconds.ToString());
				now = now2;
			}
		};

		CheckBox cbEnabled = new CheckBox { Text = "Enabled", Checked = true, AutoSize = true };
		cbEnabled.CheckedChanged += delegate {
			bool b = cbEnabled.Checked;
			tbb.Enabled = b;
			tbb2.Enabled = b;
			dp.Enabled = b;
			nud2.Enabled = b;
		};

		var btn = new Button { Text = "Test", AutoSize = true, AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink };
		ComboBox comboStyle = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
		comboStyle.Items.AddRange(new Object[] { SpinButtonStyle.Flat, SpinButtonStyle.Modern, SpinButtonStyle.Popup, SpinButtonStyle.Standard, SpinButtonStyle.System });
		comboStyle.SelectedValueChanged += delegate {
			sc.ButtonStyle = (SpinButtonStyle) comboStyle.SelectedItem;
			if (sc.ButtonStyle != SpinButtonStyle.Modern)
				btn.FlatStyle = (FlatStyle) comboStyle.SelectedItem;
		};

		FlowDirection = FlowDirection.TopDown;
		WrapContents = false;
		Dock = DockStyle.Fill;
		FlowLayoutPanel fl1 = this;
		fl1.Margin = new Padding(20);
		fl1.Controls.Add(nud2);
		fl1.Controls.Add(dp);
		fl1.Controls.Add(tbb);
		fl1.Controls.Add(tbb2);
		fl1.Controls.Add(btn);
		fl1.Controls.Add(cbEnabled);
		fl1.Controls.Add(comboStyle);
	}
}
}