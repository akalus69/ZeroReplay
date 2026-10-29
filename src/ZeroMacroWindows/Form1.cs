using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZeroMacroWindows.Properties;

namespace ZeroMacroWindows;

public class Form1 : Form
{
	private IContainer components = null;

	private SplitContainer splitContainer1;

	private SplitContainer splitContainer2;

	private GroupBox groupBox1;

	private Button button3;

	private Button button2;

	private Button button1;

	private Button button7;

	private Button button6;

	private Button button5;

	private Button button4;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem avviaToolStripMenuItem;

	private ToolStripMenuItem stopToolStripMenuItem;

	private GroupBox groupBox2;

	private ToolStripMenuItem opzioniToolStripMenuItem;

	private Button button9;

	private Button button8;

	private ToolStripMenuItem foundPositionInYourDesktopToolStripMenuItem;

	public ListBox listBox1;

	private Button button10;

	private Label label2;

	private Label label1;

	public TextBox textBox2;

	public TextBox textBox1;

	private SplitContainer splitContainer4;

	private GroupBox groupBox3;

	private Button button11;

	private Button button13;

	private Button button12;

	private ToolStrip toolStrip1;

	private ToolStripSplitButton toolStripSplitButton1;

	private ToolStripMenuItem saveAllToolStripMenuItem;

	private ToolStripMenuItem saveToolStripMenuItem;

	private ToolStripMenuItem loadToolStripMenuItem;

	private ToolStripMenuItem addPartToolStripMenuItem;

	private Button button14;

	public PictureBox pictureBox1;

	public SplitContainer splitContainer3;

	private Button button15;

	private CheckBox checkBox1;

	public Button button16;

	private ToolStripMenuItem newToolStripMenuItem;

	private Button button17;

	private ToolStripMenuItem loadAndGoToolStripMenuItem;

	private Button button18;

	private Button button19;

	private ToolStripMenuItem loadToolStripMenuItem1;

	private ToolStripMenuItem saveToolStripMenuItem1;

	private ToolStripMenuItem countSelectedStringToolStripMenuItem;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem helpToolStripMenuItem;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem copyToolStripMenuItem;

	private Button button20;

	private Button button22;

	private Button button21;

	public Button button23;

	private ToolStripMenuItem settaNormalizzatoreTrattoInRECToolStripMenuItem;

	public ToolStripTextBox toolStripTextBox1;

	public Button button24;

	public Button button25;

	public CheckBox checkBox2;

	public TextBox textBox3;

	public bool vai = false;

	public bool breakpointx = false;

	public Clipboard MiaClip;

	public Interpreta zio;

	public bool parziale = false;

	public bool pausaprogramma = false;

	private Thread CHUCK;

	private Thread ttt;

	public bool gotox = false;

	public HotkeyManager hotkeys;

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 786 && hotkeys != null && hotkeys.Attiva)
		{
			lanciaMacroDaHotkey(hotkeys.PathPerId(m.WParam.ToInt32()));
		}
		base.WndProc(ref m);
	}

	public void CaricaEAvvia(string path)
	{
		svuotaListe();
		caricafile(path);
		button8_Click(this, EventArgs.Empty);
	}

	private void lanciaMacroDaHotkey(string path)
	{
		try
		{
			if (path == null)
			{
				return;
			}
			bool macroGiaAttiva = CHUCK != null && CHUCK.IsAlive;
			if (macroGiaAttiva)
			{
				// sta gia' girando una macro: metti in coda quella richiesta
				hotkeys.PendingHotkeyMacro = path;
				return;
			}
			CaricaEAvvia(path);
		}
		catch
		{
		}
	}

	public void aggiornaUiHotkey()
		{
			try
			{
				checkBox2.Checked = hotkeys.Attiva;
				textBox3.Text = (hotkeys.ComboCorrente ?? "");
			}
			catch
			{
			}
		}

		private System.Windows.Forms.Timer hotkeyQueueTimer;

		private void costruisciUiHotkey()
		{
			hotkeys = new HotkeyManager(this);
			Panel barra = new Panel();
			barra.Dock = DockStyle.Bottom;
			barra.Height = 32;
			checkBox2 = new CheckBox();
			checkBox2.Text = "Hotkey ON";
			checkBox2.Location = new Point(6, 8);
			checkBox2.AutoSize = true;
			checkBox2.CheckedChanged += checkBox2_HotkeyToggled;
			textBox3 = new TextBox();
			textBox3.Location = new Point(90, 5);
			textBox3.Width = 130;
			textBox3.ReadOnly = true;
			textBox3.KeyDown += textBox3_CaptureCombo;
			textBox3.Text = "(premi combinazione)";
			textBox3.GotFocus += delegate
			{
				if (textBox3.Text == "(premi combinazione)")
				{
					textBox3.Text = "";
				}
			};
			Button buttonAssocia = new Button();
			buttonAssocia.Text = "Associa";
			buttonAssocia.Location = new Point(226, 3);
			buttonAssocia.Size = new Size(70, 25);
			buttonAssocia.Click += buttonAssociaHotkey_Click;
			Button buttonRimuovi = new Button();
			buttonRimuovi.Text = "Rimuovi";
			buttonRimuovi.Location = new Point(300, 3);
			buttonRimuovi.Size = new Size(70, 25);
			buttonRimuovi.Click += buttonRimuoviHotkey_Click;
			Button buttonLista = new Button();
			buttonLista.Text = "Elenco configurazioni...";
			buttonLista.Location = new Point(376, 3);
			buttonLista.Size = new Size(150, 25);
			buttonLista.Click += delegate
			{
				new ConfigListDialog(this).ShowDialog(this);
				aggiornaUiHotkey();
			};
			barra.Controls.Add(checkBox2);
			barra.Controls.Add(textBox3);
			barra.Controls.Add(buttonAssocia);
			barra.Controls.Add(buttonRimuovi);
			barra.Controls.Add(buttonLista);
			base.Controls.Add(barra);
			splitContainer1.BringToFront();
			hotkeyQueueTimer = new System.Windows.Forms.Timer();
			hotkeyQueueTimer.Interval = 1000;
			hotkeyQueueTimer.Tick += hotkeyQueueTimer_Tick;
			hotkeyQueueTimer.Start();
		}

		private void hotkeyQueueTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (hotkeys != null && hotkeys.PendingHotkeyMacro != null && (CHUCK == null || !CHUCK.IsAlive))
				{
					string p = hotkeys.PendingHotkeyMacro;
					hotkeys.PendingHotkeyMacro = null;
					CaricaEAvvia(p);
				}
			}
			catch
			{
			}
		}

		private void checkBox2_HotkeyToggled(object sender, EventArgs e)
			{
				if (hotkeys == null)
				{
					return;
				}
				hotkeys.Attiva = checkBox2.Checked;
				if (hotkeys.Attiva)
				{
					List<string> fallite = hotkeys.RegisterAll();
					if (fallite.Count > 0)
					{
						MessageBox.Show("Queste hotkey non sono attive perche' gia' usate da altri programmi:\n" + string.Join("\n", fallite.ToArray()));
					}
				}
				else
				{
					hotkeys.UnregisterAll();
				}
			}

			public static string FormaComboPubblica(Keys mods, Keys key)
			{
				return FormaCombo(mods, key);
			}

		private void textBox3_CaptureCombo(object sender, KeyEventArgs e)
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
				textBox3.Text = "Serve almeno CTRL/ALT/SHIFT";
				return;
			}
			textBox3.Tag = FormaCombo(e.Modifiers, key);
			textBox3.Text = (string)textBox3.Tag;
		}

		private static string FormaCombo(Keys mods, Keys key)
		{
			string text = "";
			if ((mods & Keys.Control) != Keys.None)
			{
				text += "CTRL+";
			}
			if ((mods & Keys.Alt) != Keys.None)
			{
				text += "ALT+";
			}
			if ((mods & Keys.Shift) != Keys.None)
			{
				text += "SHIFT+";
			}
			if ((mods & Keys.LWin) != Keys.None)
			{
				text += "WIN+";
			}
			return text + key.ToString().ToUpperInvariant();
		}

		private void buttonAssociaHotkey_Click(object sender, EventArgs e)
		{
			string combo = (textBox3.Tag as string) ?? textBox3.Text;
			if (hotkeys.CurrentMacroPath == null)
			{
				MessageBox.Show("Carica o salva prima una configurazione, poi associa la combinazione.");
				return;
			}
			if (string.IsNullOrEmpty(combo) || !HotkeyManager.TryParseCombo(combo, out Keys _, out Keys _))
			{
				MessageBox.Show("Combinazione non valida. Premi una combinazione nel campo (es. CTRL+B).");
				return;
			}
			if (hotkeys.Associa(combo))
			{
				if (checkBox2.Checked)
				{
					List<string> fallite = hotkeys.RegisterAll();
					if (fallite.Contains(combo.ToUpperInvariant()))
					{
						MessageBox.Show("Combinazione salvata ma NON registrata: probabilmente gia usata da un altro programma.");
					}
				}
			}
			else
			{
				MessageBox.Show("Combinazione non valida.");
			}
		}

		private void buttonRimuoviHotkey_Click(object sender, EventArgs e)
		{
			hotkeys.RimuoviAssociazione();
			textBox3.Text = "";
			textBox3.Tag = null;
		}

	public List<ClickSx> listaclicksx = new List<ClickSx>();

	public List<ClickDx> listaclickdx = new List<ClickDx>();

	public List<Parole> listaparole = new List<Parole>();

	public List<TrattoSx> listatrattosx = new List<TrattoSx>();

	public List<TrattoDx> listatrattodx = new List<TrattoDx>();

	public List<Clickx2> listaclick2x = new List<Clickx2>();

	public List<Pausa> listapausa = new List<Pausa>();

	public List<RandomContr> listarandom = new List<RandomContr>();

	public List<Condizione> listawhile = new List<Condizione>();

	public List<CondizioneIf> listaif = new List<CondizioneIf>();

	public List<ProcessStart> listaprocessi = new List<ProcessStart>();

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroMacroWindows.Form1));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.splitContainer4 = new System.Windows.Forms.SplitContainer();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.button22 = new System.Windows.Forms.Button();
		this.button21 = new System.Windows.Forms.Button();
		this.button19 = new System.Windows.Forms.Button();
		this.button18 = new System.Windows.Forms.Button();
		this.button13 = new System.Windows.Forms.Button();
		this.button12 = new System.Windows.Forms.Button();
		this.button11 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.button6 = new System.Windows.Forms.Button();
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
		this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.loadAndGoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.addPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.button16 = new System.Windows.Forms.Button();
		this.button15 = new System.Windows.Forms.Button();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button9 = new System.Windows.Forms.Button();
		this.button8 = new System.Windows.Forms.Button();
		this.splitContainer2 = new System.Windows.Forms.SplitContainer();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.splitContainer3 = new System.Windows.Forms.SplitContainer();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.button25 = new System.Windows.Forms.Button();
		this.button23 = new System.Windows.Forms.Button();
		this.button24 = new System.Windows.Forms.Button();
		this.button20 = new System.Windows.Forms.Button();
		this.button17 = new System.Windows.Forms.Button();
		this.button14 = new System.Windows.Forms.Button();
		this.button10 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.avviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.foundPositionInYourDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.countSelectedStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.settaNormalizzatoreTrattoInRECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.splitContainer4.Panel1.SuspendLayout();
		this.splitContainer4.Panel2.SuspendLayout();
		this.splitContainer4.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.groupBox2.SuspendLayout();
		this.splitContainer2.Panel1.SuspendLayout();
		this.splitContainer2.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.splitContainer3.Panel1.SuspendLayout();
		this.splitContainer3.Panel2.SuspendLayout();
		this.splitContainer3.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		this.menuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Location = new System.Drawing.Point(0, 24);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
		this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
		this.splitContainer1.Size = new System.Drawing.Size(570, 572);
		this.splitContainer1.SplitterDistance = 202;
		this.splitContainer1.TabIndex = 0;
		this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer4.Location = new System.Drawing.Point(0, 0);
		this.splitContainer4.Name = "splitContainer4";
		this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
		this.splitContainer4.Panel2.Controls.Add(this.toolStrip1);
		this.splitContainer4.Panel2.Controls.Add(this.button16);
		this.splitContainer4.Panel2.Controls.Add(this.button15);
		this.splitContainer4.Panel2.Controls.Add(this.pictureBox1);
		this.splitContainer4.Panel2.Controls.Add(this.checkBox1);
		this.splitContainer4.Panel2.Controls.Add(this.groupBox2);
		this.splitContainer4.Panel2.Controls.Add(this.button9);
		this.splitContainer4.Panel2.Controls.Add(this.button8);
		this.splitContainer4.Size = new System.Drawing.Size(202, 572);
		this.splitContainer4.SplitterDistance = 346;
		this.splitContainer4.TabIndex = 7;
		this.groupBox3.Controls.Add(this.button22);
		this.groupBox3.Controls.Add(this.button21);
		this.groupBox3.Controls.Add(this.button19);
		this.groupBox3.Controls.Add(this.button18);
		this.groupBox3.Controls.Add(this.button13);
		this.groupBox3.Controls.Add(this.button12);
		this.groupBox3.Controls.Add(this.button11);
		this.groupBox3.Controls.Add(this.button4);
		this.groupBox3.Controls.Add(this.button5);
		this.groupBox3.Controls.Add(this.button7);
		this.groupBox3.Controls.Add(this.button6);
		this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox3.Location = new System.Drawing.Point(0, 0);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(202, 346);
		this.groupBox3.TabIndex = 4;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Command";
		this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
		this.button22.Location = new System.Drawing.Point(14, 310);
		this.button22.Name = "button22";
		this.button22.Size = new System.Drawing.Size(167, 23);
		this.button22.TabIndex = 10;
		this.button22.Text = "If";
		this.button22.UseVisualStyleBackColor = true;
		this.button22.Click += new System.EventHandler(this.button22_Click);
		this.button21.Location = new System.Drawing.Point(15, 252);
		this.button21.Name = "button21";
		this.button21.Size = new System.Drawing.Size(167, 23);
		this.button21.TabIndex = 9;
		this.button21.Text = "Process";
		this.button21.UseVisualStyleBackColor = true;
		this.button21.Click += new System.EventHandler(this.button21_Click);
		this.button19.Location = new System.Drawing.Point(15, 281);
		this.button19.Name = "button19";
		this.button19.Size = new System.Drawing.Size(167, 23);
		this.button19.TabIndex = 8;
		this.button19.Text = "While";
		this.button19.UseVisualStyleBackColor = true;
		this.button19.Click += new System.EventHandler(this.button19_Click);
		this.button18.Location = new System.Drawing.Point(15, 223);
		this.button18.Name = "button18";
		this.button18.Size = new System.Drawing.Size(167, 23);
		this.button18.TabIndex = 7;
		this.button18.Text = "Variabile";
		this.button18.UseVisualStyleBackColor = true;
		this.button18.Click += new System.EventHandler(this.button18_Click);
		this.button13.Location = new System.Drawing.Point(14, 194);
		this.button13.Name = "button13";
		this.button13.Size = new System.Drawing.Size(167, 23);
		this.button13.TabIndex = 6;
		this.button13.Text = "Click  x2";
		this.button13.UseVisualStyleBackColor = true;
		this.button13.Click += new System.EventHandler(this.button13_Click);
		this.button12.Location = new System.Drawing.Point(14, 165);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(167, 23);
		this.button12.TabIndex = 5;
		this.button12.Text = "Tratto Dx";
		this.button12.UseVisualStyleBackColor = true;
		this.button12.Click += new System.EventHandler(this.button12_Click);
		this.button11.Location = new System.Drawing.Point(14, 136);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(167, 23);
		this.button11.TabIndex = 4;
		this.button11.Text = "Tratto Sx";
		this.button11.UseVisualStyleBackColor = true;
		this.button11.Click += new System.EventHandler(this.button11_Click);
		this.button4.Location = new System.Drawing.Point(14, 19);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(167, 23);
		this.button4.TabIndex = 0;
		this.button4.Text = "Click Sx";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.button5.Location = new System.Drawing.Point(14, 49);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(167, 23);
		this.button5.TabIndex = 1;
		this.button5.Text = "Click Dx";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.button7.Location = new System.Drawing.Point(14, 107);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(167, 23);
		this.button7.TabIndex = 3;
		this.button7.Text = "Pausa";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(this.button7_Click);
		this.button6.Location = new System.Drawing.Point(14, 78);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(167, 23);
		this.button6.TabIndex = 2;
		this.button6.Text = "Stringa";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripSplitButton1 });
		this.toolStrip1.Location = new System.Drawing.Point(15, 188);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(44, 25);
		this.toolStrip1.TabIndex = 7;
		this.toolStrip1.Text = "toolStrip1";
		this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.saveAllToolStripMenuItem, this.saveToolStripMenuItem, this.loadAndGoToolStripMenuItem, this.loadToolStripMenuItem, this.addPartToolStripMenuItem });
		this.toolStripSplitButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripSplitButton1.Image");
		this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripSplitButton1.Name = "toolStripSplitButton1";
		this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
		this.toolStripSplitButton1.Text = "Option to Save / Load";
		this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
		this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
		this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.saveAllToolStripMenuItem.Text = "Save All";
		this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
		this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
		this.saveToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.saveToolStripMenuItem.Text = "Save Part";
		this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
		this.loadAndGoToolStripMenuItem.Name = "loadAndGoToolStripMenuItem";
		this.loadAndGoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.loadAndGoToolStripMenuItem.Text = "Load and Go";
		this.loadAndGoToolStripMenuItem.Click += new System.EventHandler(this.loadAndGoToolStripMenuItem_Click);
		this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
		this.loadToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.loadToolStripMenuItem.Text = "Load";
		this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
		this.addPartToolStripMenuItem.Name = "addPartToolStripMenuItem";
		this.addPartToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.addPartToolStripMenuItem.Text = "Add Part";
		this.addPartToolStripMenuItem.Click += new System.EventHandler(this.addPartToolStripMenuItem_Click);
		this.button16.Location = new System.Drawing.Point(14, 139);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(74, 23);
		this.button16.TabIndex = 9;
		this.button16.Text = "Pause";
		this.button16.UseVisualStyleBackColor = true;
		this.button16.Click += new System.EventHandler(this.button16_Click);
		this.button15.Location = new System.Drawing.Point(107, 110);
		this.button15.Name = "button15";
		this.button15.Size = new System.Drawing.Size(74, 23);
		this.button15.TabIndex = 8;
		this.button15.Text = "GoToPoint";
		this.button15.UseVisualStyleBackColor = true;
		this.button15.Click += new System.EventHandler(this.button15_Click);
		this.pictureBox1.Location = new System.Drawing.Point(139, 168);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(41, 45);
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(15, 168);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(118, 17);
		this.checkBox1.TabIndex = 0;
		this.checkBox1.Text = "Always Top Screen";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.groupBox2.Controls.Add(this.label2);
		this.groupBox2.Controls.Add(this.label1);
		this.groupBox2.Controls.Add(this.textBox2);
		this.groupBox2.Controls.Add(this.textBox1);
		this.groupBox2.Location = new System.Drawing.Point(9, 7);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(185, 94);
		this.groupBox2.TabIndex = 4;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Number Ripetition /Time to every command";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(26, 69);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(72, 13);
		this.label2.TabIndex = 8;
		this.label2.Text = "Time (millisec)";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(26, 35);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(69, 13);
		this.label1.TabIndex = 7;
		this.label1.Text = "Nr° Ripetition";
		this.textBox2.Location = new System.Drawing.Point(117, 31);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(54, 20);
		this.textBox2.TabIndex = 1;
		this.textBox2.Text = "1";
		this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.textBox1.Location = new System.Drawing.Point(117, 66);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(54, 20);
		this.textBox1.TabIndex = 0;
		this.textBox1.Text = "1000";
		this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.button9.Location = new System.Drawing.Point(107, 139);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(74, 23);
		this.button9.TabIndex = 6;
		this.button9.Text = "Stop";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(this.button9_Click);
		this.button8.Location = new System.Drawing.Point(15, 110);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(74, 23);
		this.button8.TabIndex = 5;
		this.button8.Text = "Go";
		this.button8.UseVisualStyleBackColor = true;
		this.button8.Click += new System.EventHandler(this.button8_Click);
		this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer2.Location = new System.Drawing.Point(0, 0);
		this.splitContainer2.Name = "splitContainer2";
		this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
		this.splitContainer2.Size = new System.Drawing.Size(364, 572);
		this.splitContainer2.SplitterDistance = 412;
		this.splitContainer2.TabIndex = 0;
		this.groupBox1.Controls.Add(this.splitContainer3);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox1.Location = new System.Drawing.Point(0, 0);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(364, 412);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "WorkList Operation ";
		this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
		this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer3.Location = new System.Drawing.Point(3, 16);
		this.splitContainer3.Name = "splitContainer3";
		this.splitContainer3.Panel1.Controls.Add(this.listBox1);
		this.splitContainer3.Panel2.Controls.Add(this.button25);
		this.splitContainer3.Panel2.Controls.Add(this.button23);
		this.splitContainer3.Panel2.Controls.Add(this.button24);
		this.splitContainer3.Panel2.Controls.Add(this.button20);
		this.splitContainer3.Panel2.Controls.Add(this.button17);
		this.splitContainer3.Panel2.Controls.Add(this.button14);
		this.splitContainer3.Panel2.Controls.Add(this.button10);
		this.splitContainer3.Panel2.Controls.Add(this.button3);
		this.splitContainer3.Panel2.Controls.Add(this.button2);
		this.splitContainer3.Panel2.Controls.Add(this.button1);
		this.splitContainer3.Size = new System.Drawing.Size(358, 393);
		this.splitContainer3.SplitterDistance = 303;
		this.splitContainer3.TabIndex = 1;
		this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
		this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(0, 0);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(303, 381);
		this.listBox1.TabIndex = 0;
		this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
		this.listBox1.Leave += new System.EventHandler(this.listBox1_Leave);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.copyToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
		this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
		this.copyToolStripMenuItem.Text = "Copy";
		this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
		this.button25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button25.Location = new System.Drawing.Point(4, 281);
		this.button25.Name = "button25";
		this.button25.Size = new System.Drawing.Size(44, 53);
		this.button25.TabIndex = 9;
		this.button25.Text = "-0,250\r\nPausa";
		this.button25.UseVisualStyleBackColor = true;
		this.button25.Click += new System.EventHandler(this.button25_Click);
		this.button23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button23.Location = new System.Drawing.Point(3, 357);
		this.button23.Name = "button23";
		this.button23.Size = new System.Drawing.Size(44, 24);
		this.button23.TabIndex = 7;
		this.button23.Text = "REC";
		this.button23.UseVisualStyleBackColor = true;
		this.button23.Click += new System.EventHandler(this.button23_Click);
		this.button24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button24.Location = new System.Drawing.Point(3, 222);
		this.button24.Name = "button24";
		this.button24.Size = new System.Drawing.Size(44, 53);
		this.button24.TabIndex = 8;
		this.button24.Text = "+0,250\r\nPausa";
		this.button24.UseVisualStyleBackColor = true;
		this.button24.Click += new System.EventHandler(this.button24_Click);
		this.button20.Location = new System.Drawing.Point(3, 177);
		this.button20.Name = "button20";
		this.button20.Size = new System.Drawing.Size(44, 39);
		this.button20.TabIndex = 6;
		this.button20.Text = "BreakPoint";
		this.button20.UseVisualStyleBackColor = true;
		this.button20.Click += new System.EventHandler(this.button20_Click);
		this.button17.Location = new System.Drawing.Point(3, 145);
		this.button17.Name = "button17";
		this.button17.Size = new System.Drawing.Size(44, 24);
		this.button17.TabIndex = 5;
		this.button17.Text = "===";
		this.button17.UseVisualStyleBackColor = true;
		this.button17.Click += new System.EventHandler(this.button17_Click);
		this.button14.BackgroundImage = ZeroMacroWindows.Properties.Resources.imagesCALVTU5O;
		this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button14.Location = new System.Drawing.Point(3, 115);
		this.button14.Name = "button14";
		this.button14.Size = new System.Drawing.Size(44, 24);
		this.button14.TabIndex = 4;
		this.button14.Text = "A";
		this.button14.UseVisualStyleBackColor = true;
		this.button14.Click += new System.EventHandler(this.button14_Click);
		this.button10.BackgroundImage = ZeroMacroWindows.Properties.Resources.imagesCALVTU5O;
		this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button10.Location = new System.Drawing.Point(3, 86);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(44, 24);
		this.button10.TabIndex = 3;
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(this.button10_Click);
		this.button3.BackgroundImage = ZeroMacroWindows.Properties.Resources.cestino;
		this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button3.Location = new System.Drawing.Point(2, 57);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(44, 24);
		this.button3.TabIndex = 2;
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		this.button2.BackgroundImage = ZeroMacroWindows.Properties.Resources.images;
		this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button2.Location = new System.Drawing.Point(3, 29);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(44, 24);
		this.button2.TabIndex = 1;
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.button1.BackgroundImage = ZeroMacroWindows.Properties.Resources.imagessu;
		this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.button1.Location = new System.Drawing.Point(3, 2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(44, 23);
		this.button1.TabIndex = 0;
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.fileToolStripMenuItem, this.opzioniToolStripMenuItem, this.toolStripMenuItem1 });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(570, 24);
		this.menuStrip1.TabIndex = 1;
		this.menuStrip1.Text = "menuStrip1";
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.newToolStripMenuItem, this.avviaToolStripMenuItem, this.stopToolStripMenuItem, this.loadToolStripMenuItem1, this.saveToolStripMenuItem1 });
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		this.fileToolStripMenuItem.Text = "File";
		this.newToolStripMenuItem.Name = "newToolStripMenuItem";
		this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.newToolStripMenuItem.Text = "New";
		this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
		this.avviaToolStripMenuItem.Name = "avviaToolStripMenuItem";
		this.avviaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.avviaToolStripMenuItem.Text = "Go";
		this.avviaToolStripMenuItem.Click += new System.EventHandler(this.button8_Click);
		this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
		this.stopToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
		this.stopToolStripMenuItem.Text = "Stop";
		this.stopToolStripMenuItem.Click += new System.EventHandler(this.button9_Click);
		this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
		this.loadToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
		this.loadToolStripMenuItem1.Text = "Load";
		this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
		this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
		this.saveToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
		this.saveToolStripMenuItem1.Text = "Save";
		this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
		this.opzioniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.foundPositionInYourDesktopToolStripMenuItem, this.countSelectedStringToolStripMenuItem, this.settaNormalizzatoreTrattoInRECToolStripMenuItem });
		this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
		this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
		this.opzioniToolStripMenuItem.Text = "Options";
		this.foundPositionInYourDesktopToolStripMenuItem.Name = "foundPositionInYourDesktopToolStripMenuItem";
		this.foundPositionInYourDesktopToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
		this.foundPositionInYourDesktopToolStripMenuItem.Text = "Found Position in Your Desktop";
		this.foundPositionInYourDesktopToolStripMenuItem.Click += new System.EventHandler(this.foundPositionInYourDesktopToolStripMenuItem_Click);
		this.countSelectedStringToolStripMenuItem.Name = "countSelectedStringToolStripMenuItem";
		this.countSelectedStringToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
		this.countSelectedStringToolStripMenuItem.Text = "Count Selected String";
		this.countSelectedStringToolStripMenuItem.Click += new System.EventHandler(this.countSelectedStringToolStripMenuItem_Click);
		this.settaNormalizzatoreTrattoInRECToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripTextBox1 });
		this.settaNormalizzatoreTrattoInRECToolStripMenuItem.Name = "settaNormalizzatoreTrattoInRECToolStripMenuItem";
		this.settaNormalizzatoreTrattoInRECToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
		this.settaNormalizzatoreTrattoInRECToolStripMenuItem.Text = "Setta Normalizzatore Tratto in REC";
		this.settaNormalizzatoreTrattoInRECToolStripMenuItem.Visible = false;
		this.toolStripTextBox1.Name = "toolStripTextBox1";
		this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
		this.toolStripTextBox1.Text = "1000";
		this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.helpToolStripMenuItem });
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
		this.toolStripMenuItem1.Text = "?";
		this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
		this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
		this.helpToolStripMenuItem.Text = "Help";
		this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(570, 596);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.menuStrip1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		base.Name = "Form1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ZeroMacroWindows 0.5";
		base.Load += new System.EventHandler(this.Form1_Load);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		this.splitContainer4.Panel1.ResumeLayout(false);
		this.splitContainer4.Panel2.ResumeLayout(false);
		this.splitContainer4.Panel2.PerformLayout();
		this.splitContainer4.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.splitContainer2.Panel1.ResumeLayout(false);
		this.splitContainer2.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.splitContainer3.Panel1.ResumeLayout(false);
		this.splitContainer3.Panel2.ResumeLayout(false);
		this.splitContainer3.ResumeLayout(false);
		this.contextMenuStrip1.ResumeLayout(false);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public Form1()
	{
		InitializeComponent();
	}

	private void groupBox1_Enter(object sender, EventArgs e)
	{
	}

	public int aggiungiclicksx()
	{
		int num = 0;
		string value = "Click Sx";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Click Sx : " + num);
		ClickSx clickSx = new ClickSx();
		clickSx.dt = num;
		listaclicksx.Add(clickSx);
		return num;
	}

	private void button4_Click(object sender, EventArgs e)
	{
		aggiungiclicksx();
	}

	private void Form1_Load(object sender, EventArgs e)
		{
			zio = new Interpreta();
			zio.Show();
			Control.CheckForIllegalCrossThreadCalls = false;
			button9.Enabled = false;
			costruisciUiHotkey();
			if (Program.StartupMacroPath != null)
			{
				svuotaListe();
				caricafile(Program.StartupMacroPath);
				if (Program.AutoRun)
				{
					button8_Click(sender, e);
				}
			}
			else
			{
				// niente macro da riga di comando: precarica comunque la prima macro
				// associata a una hotkey, cosi' il trigger globale funziona sempre
				Dictionary<string, string> ass = HotkeyManager.ReadIni();
				foreach (KeyValuePair<string, string> kvp in ass)
				{
					if (File.Exists(kvp.Value))
					{
						caricafile(kvp.Value);
						break;
					}
				}
				if (hotkeys.CurrentMacroPath == null)
				{
					hotkeys.SetCurrentMacro(null);
				}
			}
			// se questa macro ha gia una hotkey associata, attiva di default la feature
			if (hotkeys.ComboCorrente != null)
			{
				checkBox2.Checked = true;
			}
			aggiornaUiHotkey();
		}

	public int trovaposizioneinlista(object pr, int n)
	{
		int result = 0;
		try
		{
			ClickSx clickSx = (ClickSx)pr;
			int num = 0;
			foreach (ClickSx item in listaclicksx)
			{
				if (item.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			ClickDx clickDx = (ClickDx)pr;
			int num = 0;
			foreach (ClickDx item2 in listaclickdx)
			{
				if (item2.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			Parole parole = (Parole)pr;
			int num = 0;
			foreach (Parole item3 in listaparole)
			{
				if (item3.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			TrattoSx trattoSx = (TrattoSx)pr;
			int num = 0;
			foreach (TrattoSx item4 in listatrattosx)
			{
				if (item4.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			TrattoDx trattoDx = (TrattoDx)pr;
			int num = 0;
			foreach (TrattoDx item5 in listatrattodx)
			{
				if (item5.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			Clickx2 clickx = (Clickx2)pr;
			int num = 0;
			foreach (Clickx2 item6 in listaclick2x)
			{
				if (item6.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			Pausa pausa = (Pausa)pr;
			int num = 0;
			foreach (Pausa item7 in listapausa)
			{
				if (item7.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			RandomContr randomContr = (RandomContr)pr;
			int num = 0;
			foreach (RandomContr item8 in listarandom)
			{
				if (item8.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			Condizione condizione = (Condizione)pr;
			int num = 0;
			foreach (Condizione item9 in listawhile)
			{
				if (item9.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			CondizioneIf condizioneIf = (CondizioneIf)pr;
			int num = 0;
			foreach (CondizioneIf item10 in listaif)
			{
				if (item10.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		try
		{
			ProcessStart processStart = (ProcessStart)pr;
			int num = 0;
			foreach (ProcessStart item11 in listaprocessi)
			{
				if (item11.dt == n)
				{
					result = num;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			splitContainer2.Panel2.Controls.Clear();
			string text = listBox1.SelectedItem.ToString();
			if (text.IndexOf("Click Sx :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n = trovaposizioneinlista(new ClickSx(), n);
				splitContainer2.Panel2.Controls.Add(listaclicksx[n]);
			}
			else if (text.IndexOf("Click Dx :") >= 0)
			{
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n2 = trovaposizioneinlista(new ClickDx(), n2);
				splitContainer2.Panel2.Controls.Add(listaclickdx[n2]);
			}
			else if (text.IndexOf("Parola :") >= 0)
			{
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n2 = trovaposizioneinlista(new Parole(), n2);
				splitContainer2.Panel2.Controls.Add(listaparole[n2]);
			}
			else if (text.IndexOf("Tratto Sx :") >= 0)
			{
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n2 = trovaposizioneinlista(new TrattoSx(), n2);
				splitContainer2.Panel2.Controls.Add(listatrattosx[n2]);
			}
			else if (text.IndexOf("Tratto Dx :") >= 0)
			{
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n2 = trovaposizioneinlista(new TrattoDx(), n2);
				splitContainer2.Panel2.Controls.Add(listatrattodx[n2]);
			}
			else if (text.IndexOf("Click 2x :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n = trovaposizioneinlista(new Clickx2(), n);
				splitContainer2.Panel2.Controls.Add(listaclick2x[n]);
			}
			else if (text.IndexOf("Pausa :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n = trovaposizioneinlista(new Pausa(), n);
				splitContainer2.Panel2.Controls.Add(listapausa[n]);
			}
			else if (text.IndexOf("Variabile :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n = trovaposizioneinlista(new RandomContr(), n);
				splitContainer2.Panel2.Controls.Add(listarandom[n]);
			}
			else if (text.IndexOf("While :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n = trovaposizioneinlista(new Condizione(), n);
				splitContainer2.Panel2.Controls.Add(listawhile[n]);
			}
			else if (text.IndexOf("Process :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				listaprocessi[n].setta();
				n = trovaposizioneinlista(new ProcessStart(), n);
				splitContainer2.Panel2.Controls.Add(listaprocessi[n]);
			}
			else if (text.IndexOf("If :") >= 0)
			{
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				splitContainer2.Panel2.Controls.Clear();
				n = trovaposizioneinlista(new CondizioneIf(), n);
				splitContainer2.Panel2.Controls.Add(listaif[n]);
			}
		}
		catch (Exception)
		{
		}
	}

	public int aggiungiclickdx()
	{
		int num = 0;
		string value = "Click Dx";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Click Dx : " + num);
		ClickDx clickDx = new ClickDx();
		clickDx.dt = num;
		listaclickdx.Add(clickDx);
		return num;
	}

	private void button5_Click(object sender, EventArgs e)
	{
		aggiungiclickdx();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			string value = listBox1.SelectedItem.ToString();
			if (listBox1.SelectedIndex > 0)
			{
				string value2 = listBox1.Items[listBox1.SelectedIndex - 1].ToString();
				listBox1.Items[listBox1.SelectedIndex - 1] = value;
				listBox1.Items[listBox1.SelectedIndex] = value2;
				listBox1.SelectedItem = listBox1.Items[listBox1.SelectedIndex - 1];
			}
		}
		catch (Exception)
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			string value = listBox1.SelectedItem.ToString();
			if (listBox1.SelectedIndex < listBox1.Items.Count)
			{
				string value2 = listBox1.Items[listBox1.SelectedIndex + 1].ToString();
				listBox1.Items[listBox1.SelectedIndex + 1] = value;
				listBox1.Items[listBox1.SelectedIndex] = value2;
				listBox1.SelectedItem = listBox1.Items[listBox1.SelectedIndex + 1];
			}
		}
		catch (Exception)
		{
		}
	}

	private void ordianalista()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		int num12 = 0;
		for (int i = 0; i < listBox1.Items.Count; i++)
		{
			string text = listBox1.Items[i].ToString();
			if (text.IndexOf("Click Sx :") >= 0)
			{
				listBox1.Items[i] = "Click Sx : " + num;
				num++;
			}
			if (text.IndexOf("Click Dx :") >= 0)
			{
				listBox1.Items[i] = "Click Dx : " + num3;
				num3++;
			}
			if (text.IndexOf("Parola :") >= 0)
			{
				listBox1.Items[i] = "Parola : " + num4;
				num4++;
			}
			if (text.IndexOf("Tratto Sx :") >= 0)
			{
				listBox1.Items[i] = "Tratto Sx : " + num7;
				num7++;
			}
			if (text.IndexOf("Tratto Dx :") >= 0)
			{
				listBox1.Items[i] = "Tratto Dx : " + num8;
				num8++;
			}
			if (text.IndexOf("Click 2x :") >= 0)
			{
				listBox1.Items[i] = "Click 2x : " + num2;
				num2++;
			}
			if (text.IndexOf("Pausa :") >= 0)
			{
				listBox1.Items[i] = "Pausa : " + num5;
				num5++;
			}
			if (text.IndexOf("Variabile :") >= 0)
			{
				listBox1.Items[i] = "Variabile : " + num9;
				num9++;
			}
			if (text.IndexOf("While :") >= 0)
			{
				listBox1.Items[i] = "While : " + num10;
				num10++;
			}
			if (text.IndexOf("C_While_C :") >= 0)
			{
				listBox1.Items[i] = "C_While_C : " + num10;
			}
			if (text.IndexOf("Process :") >= 0)
			{
				listBox1.Items[i] = "Process : " + num11;
				num11++;
			}
			if (text.IndexOf("If :") >= 0)
			{
				listBox1.Items[i] = "If : " + num12;
				num12++;
			}
		}
	}

	private void cancellacomando(string parola)
	{
		if (parola.IndexOf("Click Sx :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new ClickSx(), n);
			listaclicksx.Remove(listaclicksx[n]);
		}
		if (parola.IndexOf("Click Dx :") >= 0)
		{
			int n2 = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n2 = trovaposizioneinlista(new ClickDx(), n2);
			listaclickdx.Remove(listaclickdx[n2]);
		}
		if (parola.IndexOf("Parola :") >= 0)
		{
			int n2 = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n2 = trovaposizioneinlista(new Parole(), n2);
			listaparole.Remove(listaparole[n2]);
		}
		if (parola.IndexOf("Tratto Sx :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new TrattoSx(), n);
			listatrattosx.Remove(listatrattosx[n]);
		}
		if (parola.IndexOf("Tratto Dx :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new TrattoDx(), n);
			listatrattodx.Remove(listatrattodx[n]);
		}
		if (parola.IndexOf("Click 2x :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new Clickx2(), n);
			listaclick2x.Remove(listaclick2x[n]);
		}
		if (parola.IndexOf("Pausa :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new Pausa(), n);
			listapausa.Remove(listapausa[n]);
		}
		if (parola.IndexOf("Variabile :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new RandomContr(), n);
			listarandom.Remove(listarandom[n]);
		}
		if (parola.IndexOf("While :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new Condizione(), n);
			listawhile.Remove(listawhile[n]);
		}
		if (parola.IndexOf("Process :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new ProcessStart(), n);
			listaprocessi.Remove(listaprocessi[n]);
		}
		if (parola.IndexOf("If :") >= 0)
		{
			int n = int.Parse(parola.Substring(parola.IndexOf(":") + 2));
			n = trovaposizioneinlista(new CondizioneIf(), n);
			listaif.Remove(listaif[n]);
		}
		listBox1.Items.Remove(parola);
		splitContainer2.Panel2.Controls.Clear();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			if (text.IndexOf("*************************") < 0)
			{
				cancellacomando(text);
			}
			else
			{
				MessageBox.Show("Can't delete part in this mode, to delete press Part");
			}
		}
		catch (Exception)
		{
		}
	}

	private void foundPositionInYourDesktopToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ThreadTRVX threadTRVX = new ThreadTRVX();
		Thread thread = new Thread(threadTRVX.partenza);
		thread.Start();
	}

	private void button10_Click(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(listBox1.SelectedItem.ToString()))
			{
				try
				{
					ThreadTRVX threadTRVX = new ThreadTRVX(this);
					Thread thread = new Thread(threadTRVX.inserisci);
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.BelowNormal;
					thread.Start();
					return;
				}
				catch (NullReferenceException)
				{
					return;
				}
				catch (Exception)
				{
					return;
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Must Selected a work to want to complete");
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		gotox = false;
		button9.Enabled = true;
		try
		{
			CHUCK.Abort();
		}
		catch
		{
		}
		try
		{
			ThreadComanda threadComanda = new ThreadComanda(this);
			CHUCK = new Thread(threadComanda.vai);
			CHUCK.IsBackground = true;
			CHUCK.Priority = ThreadPriority.BelowNormal;
			CHUCK.Start();
		}
		catch
		{
		}
	}

	private void button9_Click(object sender, EventArgs e)
	{
		try
		{
			CHUCK.Abort();
		}
		catch
		{
		}
	}

	public int aggiungistringa()
	{
		int num = 0;
		string value = "Parola :";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Parola : " + num);
		Parole parole = new Parole();
		parole.dt = num;
		listaparole.Add(parole);
		return num;
	}

	private void button6_Click(object sender, EventArgs e)
	{
		aggiungistringa();
	}

	private void groupBox3_Enter(object sender, EventArgs e)
	{
	}

	public int aggiungitrattosx()
	{
		int num = 0;
		string value = "Tratto Sx";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Tratto Sx : " + num);
		TrattoSx trattoSx = new TrattoSx();
		trattoSx.dt = num;
		listatrattosx.Add(trattoSx);
		return num;
	}

	private void button11_Click(object sender, EventArgs e)
	{
		aggiungitrattosx();
	}

	public int aggiungitrattodx()
	{
		int num = 0;
		string value = "Tratto Dx";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Tratto Dx : " + num);
		TrattoDx trattoDx = new TrattoDx();
		trattoDx.dt = num;
		listatrattodx.Add(trattoDx);
		return num;
	}

	private void button12_Click(object sender, EventArgs e)
	{
		aggiungitrattodx();
	}

	public int aggiungiclickperdue()
	{
		int num = 0;
		string value = "Click 2x";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Click 2x : " + num);
		Clickx2 clickx = new Clickx2();
		clickx.dt = num;
		listaclick2x.Add(clickx);
		return num;
	}

	private void button13_Click(object sender, EventArgs e)
	{
		aggiungiclickperdue();
	}

	public int aggiungipausa()
	{
		int num = 0;
		string value = "Pausa";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Pausa : " + num);
		Pausa pausa = new Pausa();
		pausa.dt = num;
		listapausa.Add(pausa);
		return num;
	}

	private void button7_Click(object sender, EventArgs e)
	{
		aggiungipausa();
	}

	public void caricafile(string percorsoFile = null)
		{
			try
			{
				int num = Screen.PrimaryScreen.Bounds.Height;
				int num2 = Screen.PrimaryScreen.Bounds.Width;
				if (percorsoFile == null)
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.ShowDialog();
					if (string.IsNullOrEmpty(openFileDialog.FileName))
					{
						return;
					}
					percorsoFile = openFileDialog.FileName;
				}
				string text = percorsoFile.Substring(percorsoFile.LastIndexOf("\\") + 1);
							Text = "ZeroMacroWindows <" + text + ">";
							if (hotkeys != null)
							{
								hotkeys.SetCurrentMacro(percorsoFile);
								aggiornaUiHotkey();
							}
							StreamReader streamReader = new StreamReader(percorsoFile);
			string text2 = "";
			text2 = streamReader.ReadLine();
			string s = text2.Substring(0, text2.IndexOf(","));
			text2 = text2.Substring(text2.IndexOf(",") + 1);
			int num3 = int.Parse(s);
			int num4 = int.Parse(text2);
			num -= num4;
			num2 -= num3;
			text2 = streamReader.ReadLine();
			textBox1.Text = text2;
			text2 = streamReader.ReadLine();
			textBox2.Text = text2;
			int num5 = 0;
			int num6 = 0;
			while ((text2 = streamReader.ReadLine()) != null)
			{
				string text3 = text2;
				int num7 = int.Parse(text3.Substring(text3.IndexOf(":") + 2));
				bool flag = true;
				foreach (object item in listBox1.Items)
				{
					if (item.ToString() == text3)
					{
						flag = false;
					}
				}
				int num8 = 0;
				if (flag && text3.IndexOf("C_While_C") < 0 && text3.IndexOf("C_If_C") < 0)
				{
					listBox1.Items.Add(text3);
				}
				if (text3.IndexOf("Click Sx :") >= 0)
				{
					ClickSx clickSx = new ClickSx();
					if (flag)
					{
						clickSx.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Click Sx :";
						int num9 = 0;
						foreach (object item2 in listBox1.Items)
						{
							if (item2.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						clickSx.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					clickSx.textBox1.Text = streamReader.ReadLine();
					clickSx.textBox2.Text = streamReader.ReadLine();
					listaclicksx.Add(clickSx);
				}
				if (text3.IndexOf("Process :") >= 0)
				{
					ProcessStart processStart = new ProcessStart();
					if (flag)
					{
						processStart.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Process :";
						int num9 = 0;
						foreach (object item3 in listBox1.Items)
						{
							if (item3.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						processStart.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					processStart.textBox1.Text = streamReader.ReadLine();
					processStart.textBox2.Text = streamReader.ReadLine();
					listaprocessi.Add(processStart);
				}
				if (text3.IndexOf("Click Dx :") >= 0)
				{
					ClickDx clickDx = new ClickDx();
					if (flag)
					{
						clickDx.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Click Dx :";
						int num9 = 0;
						foreach (object item4 in listBox1.Items)
						{
							if (item4.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						clickDx.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					clickDx.textBox1.Text = streamReader.ReadLine();
					clickDx.textBox2.Text = streamReader.ReadLine();
					listaclickdx.Add(clickDx);
				}
				if (text3.IndexOf("Parola :") >= 0)
				{
					Parole parole = new Parole();
					if (flag)
					{
						parole.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Parola :";
						int num9 = 0;
						foreach (object item5 in listBox1.Items)
						{
							if (item5.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						parole.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					parole.textBox1.Text = streamReader.ReadLine();
					while (text2.IndexOf("!!***!!") < 0)
					{
						text2 = streamReader.ReadLine();
						if (text2.IndexOf("!!***!!") < 0)
						{
							parole.textBox1.Text = parole.textBox1.Text + Environment.NewLine + text2;
						}
					}
					listaparole.Add(parole);
				}
				if (text3.IndexOf("Tratto Sx :") >= 0)
				{
					TrattoSx trattoSx = new TrattoSx();
					if (flag)
					{
						trattoSx.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Tratto Sx :";
						int num9 = 0;
						foreach (object item6 in listBox1.Items)
						{
							if (item6.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						trattoSx.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					trattoSx.textBox1.Text = streamReader.ReadLine();
					trattoSx.textBox2.Text = streamReader.ReadLine();
					trattoSx.textBox4.Text = streamReader.ReadLine();
					trattoSx.textBox3.Text = streamReader.ReadLine();
					listatrattosx.Add(trattoSx);
				}
				if (text3.IndexOf("Tratto Dx :") >= 0)
				{
					TrattoDx trattoDx = new TrattoDx();
					if (flag)
					{
						trattoDx.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Tratto Dx :";
						int num9 = 0;
						foreach (object item7 in listBox1.Items)
						{
							if (item7.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						trattoDx.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					trattoDx.textBox1.Text = streamReader.ReadLine();
					trattoDx.textBox2.Text = streamReader.ReadLine();
					trattoDx.textBox4.Text = streamReader.ReadLine();
					trattoDx.textBox3.Text = streamReader.ReadLine();
					listatrattodx.Add(trattoDx);
				}
				if (text3.IndexOf("Click 2x :") >= 0)
				{
					Clickx2 clickx = new Clickx2();
					if (flag)
					{
						clickx.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Click 2x :";
						int num9 = 0;
						foreach (object item8 in listBox1.Items)
						{
							if (item8.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						clickx.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					clickx.textBox1.Text = streamReader.ReadLine();
					clickx.textBox2.Text = streamReader.ReadLine();
					listaclick2x.Add(clickx);
				}
				if (text3.IndexOf("Pausa :") >= 0)
				{
					Pausa pausa = new Pausa();
					if (flag)
					{
						pausa.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Pausa :";
						int num9 = 0;
						foreach (object item9 in listBox1.Items)
						{
							if (item9.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						pausa.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					pausa.textBox1.Text = streamReader.ReadLine();
					listapausa.Add(pausa);
				}
				if (text3.IndexOf("Variabile :") >= 0)
				{
					RandomContr randomContr = new RandomContr();
					if (flag)
					{
						randomContr.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "Variabile :";
						int num9 = 0;
						foreach (object item10 in listBox1.Items)
						{
							if (item10.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						randomContr.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					randomContr.setta();
					int selectedIndex = int.Parse(streamReader.ReadLine());
					randomContr.comboBox1.SelectedIndex = selectedIndex;
					string text5 = streamReader.ReadLine();
					if (text5 == "1")
					{
						randomContr.radioButton1.Checked = true;
					}
					else
					{
						randomContr.radioButton2.Checked = true;
					}
					listarandom.Add(randomContr);
				}
				if (text3.IndexOf("While :") >= 0)
				{
					Condizione condizione = new Condizione();
					if (flag)
					{
						condizione.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "While :";
						int num9 = 0;
						foreach (object item11 in listBox1.Items)
						{
							if (item11.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						condizione.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					num5 = condizione.dt;
					condizione.textBox1.Text = streamReader.ReadLine();
					string text5 = streamReader.ReadLine();
					if (text5 == "1")
					{
						condizione.radioButton1.Checked = true;
					}
					else if (text5 == "2")
					{
						condizione.radioButton2.Checked = true;
					}
					else
					{
						condizione.radioButton3.Checked = true;
					}
					listawhile.Add(condizione);
				}
				if (text3.IndexOf("If :") >= 0)
				{
					CondizioneIf condizioneIf = new CondizioneIf();
					if (flag)
					{
						condizioneIf.dt = int.Parse(streamReader.ReadLine());
					}
					else
					{
						string text4 = "If :";
						int num9 = 0;
						foreach (object item12 in listBox1.Items)
						{
							if (item12.ToString().IndexOf(text4) >= 0)
							{
								num9++;
							}
						}
						condizioneIf.dt = num9;
						listBox1.Items.Add(text4 + " " + num9);
						streamReader.ReadLine();
					}
					num6 = condizioneIf.dt;
					condizioneIf.textBox1.Text = streamReader.ReadLine();
					string text5 = streamReader.ReadLine();
					if (text5 == "1")
					{
						condizioneIf.radioButton1.Checked = true;
					}
					else if (text5 == "2")
					{
						condizioneIf.radioButton2.Checked = true;
					}
					else
					{
						condizioneIf.radioButton3.Checked = true;
					}
					listaif.Add(condizioneIf);
				}
				if (text3.IndexOf("C_If_C :") >= 0)
				{
					listBox1.Items.Add("C_If_C : " + num6);
				}
				if (text3.IndexOf("C_While_C :") >= 0)
				{
					listBox1.Items.Add("C_While_C : " + num5);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void salva(List<string> lx)
	{
		try
		{
			int num = Screen.PrimaryScreen.Bounds.Height;
			int num2 = Screen.PrimaryScreen.Bounds.Width;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.ShowDialog();
			if (string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				return;
			}
			string text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1);
			Text = "ZeroMacroWindows <" + text + ">";
			string fileName = saveFileDialog.FileName;
			HotkeyManager.RegisterMacroKnown(fileName);
			StreamWriter streamWriter = new StreamWriter(fileName);
			streamWriter.WriteLine(num2 + "," + num);
			streamWriter.WriteLine(textBox1.Text);
			streamWriter.WriteLine(textBox2.Text);
			foreach (string item in lx)
			{
				string text2 = item.ToString();
				int num3 = int.Parse(text2.Substring(text2.IndexOf(":") + 2));
				streamWriter.WriteLine(text2);
				if (text2.IndexOf("Click Sx :") >= 0)
				{
					num3 = trovaposizioneinlista(new ClickSx(), num3);
					streamWriter.WriteLine(listaclicksx[num3].dt.ToString());
					streamWriter.WriteLine(listaclicksx[num3].textBox1.Text);
					streamWriter.WriteLine(listaclicksx[num3].textBox2.Text);
				}
				if (text2.IndexOf("Process :") >= 0)
				{
					num3 = trovaposizioneinlista(new ProcessStart(), num3);
					streamWriter.WriteLine(listaprocessi[num3].dt.ToString());
					streamWriter.WriteLine(listaprocessi[num3].textBox1.Text);
					streamWriter.WriteLine(listaprocessi[num3].textBox2.Text);
				}
				if (text2.IndexOf("Click Dx :") >= 0)
				{
					num3 = trovaposizioneinlista(new ClickDx(), num3);
					streamWriter.WriteLine(listaclickdx[num3].dt.ToString());
					streamWriter.WriteLine(listaclickdx[num3].textBox1.Text);
					streamWriter.WriteLine(listaclickdx[num3].textBox2.Text);
				}
				if (text2.IndexOf("Parola :") >= 0)
				{
					num3 = trovaposizioneinlista(new Parole(), num3);
					streamWriter.WriteLine(listaparole[num3].dt.ToString());
					streamWriter.WriteLine(listaparole[num3].textBox1.Text);
					streamWriter.WriteLine("!!***!!");
				}
				if (text2.IndexOf("Tratto Sx :") >= 0)
				{
					num3 = trovaposizioneinlista(new TrattoSx(), num3);
					streamWriter.WriteLine(listatrattosx[num3].dt.ToString());
					streamWriter.WriteLine(listatrattosx[num3].textBox1.Text);
					streamWriter.WriteLine(listatrattosx[num3].textBox2.Text);
					streamWriter.WriteLine(listatrattosx[num3].textBox4.Text);
					streamWriter.WriteLine(listatrattosx[num3].textBox3.Text);
				}
				if (text2.IndexOf("Tratto Dx :") >= 0)
				{
					num3 = trovaposizioneinlista(new TrattoDx(), num3);
					streamWriter.WriteLine(listatrattodx[num3].dt.ToString());
					streamWriter.WriteLine(listatrattodx[num3].textBox1.Text);
					streamWriter.WriteLine(listatrattodx[num3].textBox2.Text);
					streamWriter.WriteLine(listatrattodx[num3].textBox4.Text);
					streamWriter.WriteLine(listatrattodx[num3].textBox3.Text);
				}
				if (text2.IndexOf("Click 2x :") >= 0)
				{
					num3 = trovaposizioneinlista(new Clickx2(), num3);
					streamWriter.WriteLine(listaclick2x[num3].dt.ToString());
					streamWriter.WriteLine(listaclick2x[num3].textBox1.Text);
					streamWriter.WriteLine(listaclick2x[num3].textBox2.Text);
				}
				if (text2.IndexOf("Pausa :") >= 0)
				{
					num3 = trovaposizioneinlista(new Pausa(), num3);
					streamWriter.WriteLine(listapausa[num3].dt.ToString());
					streamWriter.WriteLine(listapausa[num3].textBox1.Text);
				}
				if (text2.IndexOf("Variabile :") >= 0)
				{
					num3 = trovaposizioneinlista(new RandomContr(), num3);
					streamWriter.WriteLine(listarandom[num3].dt.ToString());
					streamWriter.WriteLine(listarandom[num3].comboBox1.SelectedIndex.ToString());
					if (listarandom[num3].radioButton1.Checked)
					{
						streamWriter.WriteLine("1");
					}
					else
					{
						streamWriter.WriteLine("2");
					}
				}
				if (text2.IndexOf("While :") >= 0)
				{
					num3 = trovaposizioneinlista(new Condizione(), num3);
					streamWriter.WriteLine(listawhile[num3].dt.ToString());
					streamWriter.WriteLine(listawhile[num3].textBox1.Text);
					if (listawhile[num3].radioButton1.Checked)
					{
						streamWriter.WriteLine("1");
					}
					else if (listawhile[num3].radioButton2.Checked)
					{
						streamWriter.WriteLine("2");
					}
					else
					{
						streamWriter.WriteLine("3");
					}
				}
				if (text2.IndexOf("If :") >= 0)
				{
					num3 = trovaposizioneinlista(new CondizioneIf(), num3);
					streamWriter.WriteLine(listaif[num3].dt.ToString());
					streamWriter.WriteLine(listaif[num3].textBox1.Text);
					if (listaif[num3].radioButton1.Checked)
					{
						streamWriter.WriteLine("1");
					}
					else if (listaif[num3].radioButton2.Checked)
					{
						streamWriter.WriteLine("2");
					}
					else
					{
						streamWriter.WriteLine("3");
					}
				}
			}
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		foreach (object item in listBox1.Items)
		{
			list.Add(item.ToString());
		}
		salva(list);
	}

	private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
	{
	}

	private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			svuotaListe();
			caricafile();
		}

		public void svuotaListe()
		{
			listBox1.Items.Clear();
			listaprocessi.Clear();
			listawhile.Clear();
			listaif.Clear();
			listarandom.Clear();
			listaclicksx.Clear();
			listaclick2x.Clear();
			listaclickdx.Clear();
			listaparole.Clear();
			listapausa.Clear();
			listatrattodx.Clear();
			listatrattosx.Clear();
		}

		private void listBox1_Leave(object sender, EventArgs e)
	{
		try
		{
			string value = listBox1.SelectedItem.ToString();
			if (string.IsNullOrEmpty(value))
			{
				splitContainer2.Panel2.Controls.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button14_Click(object sender, EventArgs e)
	{
		try
		{
			try
			{
				ThreadTRVX threadTRVX = new ThreadTRVX(this);
				Thread thread = new Thread(threadTRVX.inserisciA);
				thread.IsBackground = true;
				thread.Priority = ThreadPriority.BelowNormal;
				thread.Start();
			}
			catch (NullReferenceException)
			{
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
	}

	private void saveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (parziale)
			{
				List<string> list = new List<string>();
				foreach (object item in listBox1.Items)
				{
					list.Add(item.ToString());
				}
				salva(list);
			}
			else
			{
				MessageBox.Show("You Must first create a Partial part to save");
			}
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void button15_Click(object sender, EventArgs e)
	{
		button9.Enabled = true;
		try
		{
			CHUCK.Abort();
		}
		catch
		{
		}
		try
		{
			string text = listBox1.SelectedItem.ToString();
			gotox = true;
			ThreadComanda threadComanda = new ThreadComanda(this);
			CHUCK = new Thread(threadComanda.vai);
			CHUCK.IsBackground = true;
			CHUCK.Priority = ThreadPriority.BelowNormal;
			CHUCK.Start();
		}
		catch
		{
			MessageBox.Show("Must select start operation");
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			TopMost = true;
		}
		else
		{
			TopMost = false;
		}
	}

	private void button16_Click(object sender, EventArgs e)
	{
		if (pausaprogramma)
		{
			button16.BackColor = BackColor;
			pausaprogramma = false;
		}
		else
		{
			button16.BackColor = Color.Red;
			pausaprogramma = true;
		}
	}

	private void newToolStripMenuItem_Click(object sender, EventArgs e)
	{
		listBox1.Items.Clear();
		listaprocessi.Clear();
		listawhile.Clear();
		listaif.Clear();
		listarandom.Clear();
		listaclicksx.Clear();
		listaclick2x.Clear();
		listaclickdx.Clear();
		listaparole.Clear();
		listapausa.Clear();
		listatrattodx.Clear();
		listatrattosx.Clear();
	}

	private void addPartToolStripMenuItem_Click(object sender, EventArgs e)
	{
		caricafile();
	}

	private void button17_Click(object sender, EventArgs e)
	{
		try
		{
			foreach (object item in listBox1.Items)
			{
				if (item.ToString().IndexOf("*************************") >= 0)
				{
					parziale = true;
				}
			}
			if (parziale)
			{
				listBox1.Items.Remove("*************************");
				listBox1.Items.Remove("*************************");
				parziale = false;
				button17.BackColor = BackColor;
			}
			else
			{
				listBox1.Items.Add("*************************");
				listBox1.Items.Add("*************************");
				parziale = true;
				button17.BackColor = Color.Violet;
			}
		}
		catch (Exception)
		{
		}
	}

	private void loadAndGoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		listBox1.Items.Clear();
		listaprocessi.Clear();
		listawhile.Clear();
		listaif.Clear();
		listarandom.Clear();
		listaclicksx.Clear();
		listaclick2x.Clear();
		listaclickdx.Clear();
		listaparole.Clear();
		listapausa.Clear();
		listatrattodx.Clear();
		listatrattosx.Clear();
		caricafile();
		button8_Click(sender, e);
	}

	private void button18_Click(object sender, EventArgs e)
	{
		int num = 0;
		string value = "Variabile";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Variabile : " + num);
		RandomContr randomContr = new RandomContr();
		randomContr.setta();
		randomContr.dt = num;
		listarandom.Add(randomContr);
	}

	private void button19_Click(object sender, EventArgs e)
	{
		int num = 0;
		string value = "While ";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("While : " + num);
		listBox1.Items.Add("C_While_C : " + num);
		Condizione condizione = new Condizione();
		condizione.dt = num;
		listawhile.Add(condizione);
	}

	private void countSelectedStringToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Clipboard.GetText();
			MessageBox.Show(text.Length.ToString());
		}
		catch (Exception)
		{
		}
	}

	private void helpToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Help help = new Help();
		help.Show();
	}

	private void copyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = listBox1.SelectedItem.ToString();
			int index = int.Parse(text.Substring(text.IndexOf(":") + 2));
			if (text.IndexOf("Click Sx :") >= 0)
			{
				ClickSx clickSx = new ClickSx();
				clickSx.textBox1.Text = listaclicksx[index].textBox1.Text;
				clickSx.textBox2.Text = listaclicksx[index].textBox2.Text;
				listBox1.Items.Add("Click Sx : " + listaclicksx.Count);
				clickSx.dt = listaclicksx.Count;
				listaclicksx.Add(clickSx);
			}
			if (text.IndexOf("Process :") >= 0)
			{
				ProcessStart processStart = new ProcessStart();
				processStart.textBox1.Text = listaprocessi[index].textBox1.Text;
				processStart.textBox2.Text = listaprocessi[index].textBox2.Text;
				listBox1.Items.Add("Process : " + listaprocessi.Count);
				processStart.dt = listaprocessi.Count;
				listaprocessi.Add(processStart);
			}
			if (text.IndexOf("Click Dx :") >= 0)
			{
				ClickDx clickDx = new ClickDx();
				clickDx.textBox1.Text = listaclickdx[index].textBox1.Text;
				clickDx.textBox2.Text = listaclickdx[index].textBox1.Text;
				listBox1.Items.Add("Click Dx : " + listaclickdx.Count);
				clickDx.dt = listaclickdx.Count;
				listaclickdx.Add(clickDx);
			}
			if (text.IndexOf("Parola :") >= 0)
			{
				Parole parole = new Parole();
				parole.textBox1.Text = listaparole[index].textBox1.Text;
				listBox1.Items.Add("Parola : " + listaparole.Count);
				parole.dt = listaparole.Count;
				listaparole.Add(parole);
			}
			if (text.IndexOf("Tratto Sx :") >= 0)
			{
				TrattoSx trattoSx = new TrattoSx();
				trattoSx.textBox1.Text = listatrattosx[index].textBox1.Text;
				trattoSx.textBox2.Text = listatrattosx[index].textBox2.Text;
				trattoSx.textBox4.Text = listatrattosx[index].textBox3.Text;
				trattoSx.textBox3.Text = listatrattosx[index].textBox4.Text;
				listBox1.Items.Add("Tratto Sx : " + listatrattosx.Count);
				trattoSx.dt = listatrattosx.Count;
				listatrattosx.Add(trattoSx);
			}
			if (text.IndexOf("Tratto Dx :") >= 0)
			{
				TrattoDx trattoDx = new TrattoDx();
				trattoDx.textBox1.Text = listatrattodx[index].textBox1.Text;
				trattoDx.textBox2.Text = listatrattodx[index].textBox2.Text;
				trattoDx.textBox4.Text = listatrattodx[index].textBox3.Text;
				trattoDx.textBox3.Text = listatrattodx[index].textBox4.Text;
				listBox1.Items.Add("Tratto Dx : " + listatrattodx.Count);
				trattoDx.dt = listatrattodx.Count;
				listatrattodx.Add(trattoDx);
			}
			if (text.IndexOf("Click 2x :") >= 0)
			{
				Clickx2 clickx = new Clickx2();
				clickx.textBox1.Text = listaclick2x[index].textBox1.Text;
				clickx.textBox2.Text = listaclick2x[index].textBox2.Text;
				listBox1.Items.Add("Click 2x : " + listaclick2x.Count);
				clickx.dt = listaclick2x.Count;
				listaclick2x.Add(clickx);
			}
			if (text.IndexOf("Pausa :") >= 0)
			{
				Pausa pausa = new Pausa();
				pausa.textBox1.Text = listapausa[index].textBox1.Text;
				listBox1.Items.Add("Pausa : " + listapausa.Count);
				pausa.dt = listapausa.Count;
				listapausa.Add(pausa);
			}
			if (text.IndexOf("Variabile :") >= 0)
			{
				RandomContr randomContr = new RandomContr();
				randomContr.setta();
				int selectedIndex = listarandom[index].comboBox1.SelectedIndex;
				randomContr.comboBox1.SelectedIndex = selectedIndex;
				randomContr.radioButton1.Checked = listarandom[index].radioButton1.Checked;
				randomContr.radioButton2.Checked = listarandom[index].radioButton2.Checked;
				listBox1.Items.Add("Variabile : " + listarandom.Count);
				randomContr.dt = listarandom.Count;
				listarandom.Add(randomContr);
			}
			if (text.IndexOf("While :") >= 0)
			{
				Condizione condizione = new Condizione();
				condizione.textBox1.Text = listawhile[index].textBox1.Text;
				condizione.radioButton1.Checked = listawhile[index].radioButton1.Checked;
				condizione.radioButton2.Checked = listawhile[index].radioButton2.Checked;
				condizione.radioButton3.Checked = listawhile[index].radioButton3.Checked;
				listBox1.Items.Add("While : " + listawhile.Count);
				listBox1.Items.Add("C_While_C : " + listawhile.Count);
				condizione.dt = listawhile.Count;
				listawhile.Add(condizione);
			}
			if (text.IndexOf("If :") >= 0)
			{
				CondizioneIf condizioneIf = new CondizioneIf();
				condizioneIf.textBox1.Text = listaif[index].textBox1.Text;
				condizioneIf.radioButton1.Checked = listaif[index].radioButton1.Checked;
				condizioneIf.radioButton2.Checked = listaif[index].radioButton2.Checked;
				condizioneIf.radioButton3.Checked = listaif[index].radioButton3.Checked;
				listBox1.Items.Add("If : " + listaif.Count);
				listBox1.Items.Add("C_If_C : " + listaif.Count);
				condizioneIf.dt = listaif.Count;
				listaif.Add(condizioneIf);
			}
		}
		catch
		{
		}
	}

	private void button20_Click(object sender, EventArgs e)
	{
		MessageBox.Show("please select point in WorkList operation to set breakPoint");
		breakpointx = true;
	}

	private void listBox1_MouseClick(object sender, MouseEventArgs e)
	{
		try
		{
			if (!breakpointx)
			{
				return;
			}
			int selectedIndex = listBox1.SelectedIndex;
			List<string> list = new List<string>();
			if (selectedIndex > 0)
			{
				foreach (object item in listBox1.Items)
				{
					list.Add(item.ToString());
				}
				listBox1.Items.Clear();
				int num = 0;
				foreach (string item2 in list)
				{
					if (num == selectedIndex)
					{
						listBox1.Items.Add("--------------------------");
					}
					num++;
					listBox1.Items.Add(item2);
				}
			}
			breakpointx = false;
		}
		catch (Exception)
		{
		}
	}

	private void button21_Click(object sender, EventArgs e)
	{
		int num = 0;
		string value = "Process";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("Process : " + num);
		ProcessStart processStart = new ProcessStart();
		processStart.dt = num;
		listaprocessi.Add(processStart);
	}

	private void button22_Click(object sender, EventArgs e)
	{
		int num = 0;
		string value = "If ";
		foreach (object item in listBox1.Items)
		{
			if (item.ToString().IndexOf(value) >= 0)
			{
				num++;
			}
		}
		listBox1.Items.Add("If : " + num);
		listBox1.Items.Add("C_If_C : " + num);
		CondizioneIf condizioneIf = new CondizioneIf();
		condizioneIf.dt = num;
		listaif.Add(condizioneIf);
	}

	private void button23_Click(object sender, EventArgs e)
	{
		if (!vai)
		{
			vai = true;
			button23.BackColor = Color.Red;
			textBox1.Text = "25";
			REC rEC = new REC(this);
			rEC.textBox1.Text = toolStripTextBox1.Text;
			rEC.Show();
		}
	}

	private void button24_Click(object sender, EventArgs e)
	{
		try
		{
			for (int i = 0; i < listapausa.Count; i++)
			{
				int num = 0;
				double num2;
				if (listapausa[i].textBox1.Text.IndexOf(",") < 0)
				{
					num = int.Parse(listapausa[i].textBox1.Text);
					num2 = num;
					listapausa[i].textBox1.Text = (num2 + 0.25).ToString();
					continue;
				}
				string text = listapausa[i].textBox1.Text;
				string s = text.Substring(0, text.IndexOf(","));
				text = text.Substring(text.IndexOf(",") + 1);
				num = ((text.Length <= 1) ? (int.Parse(text) * 100 + 250) : (int.Parse(text) * 10 + 250));
				num = int.Parse(s) * 1000 + num;
				num2 = num;
				num2 /= 1000.0;
				listapausa[i].textBox1.Text = num2.ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	private void button25_Click(object sender, EventArgs e)
	{
		try
		{
			for (int i = 0; i < listapausa.Count; i++)
			{
				int num = 0;
				double num2;
				if (listapausa[i].textBox1.Text.IndexOf(",") < 0)
				{
					num = int.Parse(listapausa[i].textBox1.Text);
					num2 = num;
					listapausa[i].textBox1.Text = ((!(num2 - 0.25 > 0.0)) ? 0.0 : (num2 - 0.25)).ToString();
					continue;
				}
				string text = listapausa[i].textBox1.Text;
				string s = text.Substring(0, text.IndexOf(","));
				text = text.Substring(text.IndexOf(",") + 1);
				num = int.Parse(s) * 1000;
				num = ((text.Length <= 1) ? (num + int.Parse(text) * 100) : (num + int.Parse(text) * 10));
				num = ((num - 250 > 0) ? (num - 250) : 0);
				num2 = num;
				num2 /= 1000.0;
				listapausa[i].textBox1.Text = num2.ToString();
			}
		}
		catch (Exception)
		{
		}
	}
}
