using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZeroMacroWindows;

// Dialog con l'elenco di tutte le configurazioni conosciute e la hotkey associata.
// Doppio click su una riga = carica e avvia subito quella macro.
public class ConfigListDialog : Form
{
	private readonly Form1 mio;

	private ListView listView1;

	private TextBox textBoxCombo;

	private Button buttonAssocia;

	private Button buttonRimuovi;

	private Label labelInfo;

	public ConfigListDialog(Form1 owner)
	{
		mio = owner;
		Inizializza();
		Ricarica();
	}

	private void Inizializza()
	{
		Text = "Configurazioni e hotkey";
		ClientSize = new Size(640, 420);
		StartPosition = FormStartPosition.CenterParent;
		FormBorderStyle = FormBorderStyle.Sizable;
		MinimizeBox = false;
		listView1 = new ListView();
		listView1.Dock = DockStyle.Top;
		listView1.Height = 330;
		listView1.View = View.Details;
		listView1.FullRowSelect = true;
		listView1.MultiSelect = false;
		listView1.HideSelection = false;
		listView1.Columns.Add("Configurazione", 200);
		listView1.Columns.Add("Hotkey", 130);
		listView1.Columns.Add("Percorso", 290);
		listView1.DoubleClick += listView1_DoubleClick;
		listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
		Panel barra = new Panel();
		barra.Dock = DockStyle.Bottom;
		barra.Height = 68;
		labelInfo = new Label();
		labelInfo.Location = new Point(8, 6);
		labelInfo.Size = new Size(620, 18);
		labelInfo.Text = "Doppio click su una riga = carica e avvia. Selezione + Associa = nuova hotkey.";
		textBoxCombo = new TextBox();
		textBoxCombo.Location = new Point(8, 28);
		textBoxCombo.Width = 150;
		textBoxCombo.ReadOnly = true;
		textBoxCombo.Text = "(premi combinazione)";
		textBoxCombo.GotFocus += delegate
		{
			if (textBoxCombo.Text == "(premi combinazione)")
			{
				textBoxCombo.Text = "";
			}
		};
		textBoxCombo.KeyDown += textBoxCombo_Capture;
		buttonAssocia = new Button();
		buttonAssocia.Text = "Associa a selezionata";
		buttonAssocia.Location = new Point(166, 24);
		buttonAssocia.Size = new Size(150, 27);
		buttonAssocia.Click += buttonAssocia_Click;
		buttonRimuovi = new Button();
		buttonRimuovi.Text = "Rimuovi hotkey";
		buttonRimuovi.Location = new Point(322, 24);
		buttonRimuovi.Size = new Size(120, 27);
		buttonRimuovi.Click += buttonRimuovi_Click;
		Button buttonChiudi = new Button();
		buttonChiudi.Text = "Chiudi";
		buttonChiudi.Location = new Point(552, 24);
		buttonChiudi.Size = new Size(80, 27);
		buttonChiudi.Click += delegate { Close(); };
		barra.Controls.Add(labelInfo);
		barra.Controls.Add(textBoxCombo);
		barra.Controls.Add(buttonAssocia);
		barra.Controls.Add(buttonRimuovi);
		barra.Controls.Add(buttonChiudi);
		base.Controls.Add(listView1);
		base.Controls.Add(barra);
	}

	public void Ricarica()
	{
		listView1.BeginUpdate();
		listView1.Items.Clear();
		List<string> percorsi = HotkeyManager.PercorsiNoti();
		foreach (string p in percorsi)
		{
			string hk = HotkeyManager.HotkeyPer(p);
			ListViewItem lvi = new ListViewItem(Path.GetFileName(p));
			lvi.SubItems.Add(hk ?? "-");
			lvi.SubItems.Add(p);
			lvi.Tag = p;
			if (string.Equals(p, mio.hotkeys?.CurrentMacroPath, StringComparison.OrdinalIgnoreCase))
			{
				lvi.BackColor = Color.LightYellow;
				lvi.Font = new Font(lvi.Font, FontStyle.Bold);
			}
			listView1.Items.Add(lvi);
		}
		listView1.EndUpdate();
	}

	private string PercorsoSelezionato()
	{
		if (listView1.SelectedItems.Count == 0)
		{
			return null;
		}
		return (string)listView1.SelectedItems[0].Tag;
	}

	private void listView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string p = PercorsoSelezionato();
		string hk = HotkeyManager.HotkeyPer(p);
		textBoxCombo.Text = (hk ?? "");
		textBoxCombo.Tag = null;
	}

	private void listView1_DoubleClick(object sender, EventArgs e)
	{
		string p = PercorsoSelezionato();
		if (p == null)
		{
			return;
		}
		mio.CaricaEAvvia(p);
		Close();
	}

	private void textBoxCombo_Capture(object sender, KeyEventArgs e)
	{
		e.SuppressKeyPress = true;
		e.Handled = true;
		Keys key = e.KeyCode;
		if (key == Keys.ControlKey || key == Keys.ShiftKey || key == Keys.Menu || key == Keys.LWin || key == Keys.RWin || key == Keys.None)
		{
			return;
		}
		if (e.Modifiers == Keys.None)
		{
			textBoxCombo.Text = "Serve CTRL/ALT/SHIFT";
			return;
		}
		textBoxCombo.Tag = Form1.FormaComboPubblica(e.Modifiers, key);
		textBoxCombo.Text = (string)textBoxCombo.Tag;
	}

	private void buttonAssocia_Click(object sender, EventArgs e)
	{
		string p = PercorsoSelezionato();
		if (p == null)
		{
			MessageBox.Show("Seleziona prima una configurazione nell'elenco.");
			return;
		}
		string combo = (textBoxCombo.Tag as string) ?? textBoxCombo.Text;
		if (string.IsNullOrEmpty(combo) || !HotkeyManager.TryParseCombo(combo, out Keys _, out Keys _))
		{
			MessageBox.Show("Premi prima una combinazione nel campo (es. CTRL+B).");
			return;
		}
		mio.hotkeys.AssociaSpecifica(combo, p);
		List<string> fallite = mio.hotkeys.RegisterAll();
		if (fallite.Contains(combo.ToUpperInvariant()))
		{
			MessageBox.Show("Combinazione salvata ma NON attiva: gia' usata da un altro programma.");
		}
		Ricarica();
		mio.aggiornaUiHotkey();
	}

	private void buttonRimuovi_Click(object sender, EventArgs e)
	{
		string p = PercorsoSelezionato();
		if (p == null)
		{
			return;
		}
		mio.hotkeys.RimuoviPerPath(p);
		Ricarica();
		mio.aggiornaUiHotkey();
	}
}