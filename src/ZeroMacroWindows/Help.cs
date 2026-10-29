using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class Help : Form
{
	private IContainer components = null;

	private SplitContainer splitContainer1;

	private TextBox textBox1;

	private Button button19;

	private Button button18;

	private Button button13;

	private Button button12;

	private Button button11;

	private Button button4;

	private Button button5;

	private Button button7;

	private Button button6;

	private Button button1;

	private Button button3;

	private Button button2;

	public Help()
	{
		InitializeComponent();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Emulazione click sinistro del mouse";
	}

	private void button5_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Emulazione click destro del mouse";
	}

	private void button6_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Inserimento stringa";
	}

	private void button7_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Inserimento pausa";
	}

	private void button19_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Inserimento condizione while, fino a che la condizione non si verifichera' il ciclo rimarra quello compreso nel While e nel C_While_C";
	}

	private void button11_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Emulazione pressione tasto sinistro e movimento mouse";
	}

	private void button12_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Emulazione pressione tasto destro e movimento mouse";
	}

	private void button13_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Emulazione doppio click del mouse";
	}

	private void button18_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Inserimento di un numero random o di una variabile incrementale";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		textBox1.Text = "ZeroMacroWindows permette di crearsi delle proprie macro per poter poi non ripetere le stesse cose 100 volte a manina (non siamo scimmiette)" + Environment.NewLine + "La pressione su uno dei tasti in questa finestra spieghera' quello che è permesso fare, da li in poi le possibilita' di ottimizzare il vostro lavoro dipendera' solo dalla vostra immaginazione, unico consiglio è cercare di avere sempre strutture posizionali ripetitive (ad esempio aprire a tutto schermo i programmi per avere sempre gli stessi punti dove premere, etc)" + Environment.NewLine + "Buon Lavoro, aka";
	}

	private void Help_Load(object sender, EventArgs e)
	{
		textBox1.Text = "ZeroMacroWindows permette di crearsi delle proprie macro per poter poi non ripetere le stesse cose 100 volte a manina (non siamo scimmiette)" + Environment.NewLine + "La pressione su uno dei tasti in questa finestra spieghera' quello che è permesso fare, da li in poi le possibilita' di ottimizzare il vostro lavoro dipendera' solo dalla vostra immaginazione, unico consiglio è cercare di avere sempre strutture posizionali ripetitive (ad esempio aprire a tutto schermo i programmi per avere sempre gli stessi punti dove premere, etc)" + Environment.NewLine + "Buon Lavoro, aka";
	}

	private void button2_Click(object sender, EventArgs e)
	{
		textBox1.Text = "Quando si verifica esegue le operazioni comprese dentro If--C_If_C";
	}

	private void button3_Click(object sender, EventArgs e)
	{
		textBox1.Text = "ZeroMacro registra le operazioni svolte e le riproduce, 2 hint, il primo è che a volte conviene (dopo la registrazione) aumentare con il tasto +0,25 sec le pause, il secondo è che se si desidera disegnare su paint e poi riprodurre il disegno si deve cliccare nella finestra di registrazione su \"disegna\" per far si che vengano registrati i tratti correttamente";
	}

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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroMacroWindows.Help));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.button1 = new System.Windows.Forms.Button();
		this.button19 = new System.Windows.Forms.Button();
		this.button18 = new System.Windows.Forms.Button();
		this.button13 = new System.Windows.Forms.Button();
		this.button12 = new System.Windows.Forms.Button();
		this.button11 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.button5 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.button6 = new System.Windows.Forms.Button();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.button3);
		this.splitContainer1.Panel1.Controls.Add(this.button2);
		this.splitContainer1.Panel1.Controls.Add(this.button1);
		this.splitContainer1.Panel1.Controls.Add(this.button19);
		this.splitContainer1.Panel1.Controls.Add(this.button18);
		this.splitContainer1.Panel1.Controls.Add(this.button13);
		this.splitContainer1.Panel1.Controls.Add(this.button12);
		this.splitContainer1.Panel1.Controls.Add(this.button11);
		this.splitContainer1.Panel1.Controls.Add(this.button4);
		this.splitContainer1.Panel1.Controls.Add(this.button5);
		this.splitContainer1.Panel1.Controls.Add(this.button7);
		this.splitContainer1.Panel1.Controls.Add(this.button6);
		this.splitContainer1.Panel2.Controls.Add(this.textBox1);
		this.splitContainer1.Size = new System.Drawing.Size(381, 355);
		this.splitContainer1.SplitterDistance = 178;
		this.splitContainer1.TabIndex = 0;
		this.button1.Location = new System.Drawing.Point(268, 147);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(89, 23);
		this.button1.TabIndex = 18;
		this.button1.Text = "Funzionamento";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.button19.Location = new System.Drawing.Point(3, 118);
		this.button19.Name = "button19";
		this.button19.Size = new System.Drawing.Size(167, 23);
		this.button19.TabIndex = 17;
		this.button19.Text = "While";
		this.button19.UseVisualStyleBackColor = true;
		this.button19.Click += new System.EventHandler(this.button19_Click);
		this.button18.Location = new System.Drawing.Point(190, 89);
		this.button18.Name = "button18";
		this.button18.Size = new System.Drawing.Size(167, 23);
		this.button18.TabIndex = 16;
		this.button18.Text = "Variabile";
		this.button18.UseVisualStyleBackColor = true;
		this.button18.Click += new System.EventHandler(this.button18_Click);
		this.button13.Location = new System.Drawing.Point(190, 61);
		this.button13.Name = "button13";
		this.button13.Size = new System.Drawing.Size(167, 23);
		this.button13.TabIndex = 15;
		this.button13.Text = "Click  x2";
		this.button13.UseVisualStyleBackColor = true;
		this.button13.Click += new System.EventHandler(this.button13_Click);
		this.button12.Location = new System.Drawing.Point(190, 32);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(167, 23);
		this.button12.TabIndex = 14;
		this.button12.Text = "Tratto Dx";
		this.button12.UseVisualStyleBackColor = true;
		this.button12.Click += new System.EventHandler(this.button12_Click);
		this.button11.Location = new System.Drawing.Point(190, 3);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(167, 23);
		this.button11.TabIndex = 13;
		this.button11.Text = "Tratto Sx";
		this.button11.UseVisualStyleBackColor = true;
		this.button11.Click += new System.EventHandler(this.button11_Click);
		this.button4.Location = new System.Drawing.Point(3, 3);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(167, 23);
		this.button4.TabIndex = 9;
		this.button4.Text = "Click Sx";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(this.button4_Click);
		this.button5.Location = new System.Drawing.Point(3, 32);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(167, 23);
		this.button5.TabIndex = 10;
		this.button5.Text = "Click Dx";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(this.button5_Click);
		this.button7.Location = new System.Drawing.Point(3, 89);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(167, 23);
		this.button7.TabIndex = 12;
		this.button7.Text = "Pausa";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(this.button7_Click);
		this.button6.Location = new System.Drawing.Point(3, 60);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(167, 23);
		this.button6.TabIndex = 11;
		this.button6.Text = "Stringa";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(this.button6_Click);
		this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBox1.Location = new System.Drawing.Point(0, 0);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(381, 173);
		this.textBox1.TabIndex = 0;
		this.button2.Location = new System.Drawing.Point(3, 147);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(167, 23);
		this.button2.TabIndex = 19;
		this.button2.Text = "If";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.button3.Location = new System.Drawing.Point(190, 118);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(167, 23);
		this.button3.TabIndex = 20;
		this.button3.Text = "REC";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(this.button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(381, 355);
		base.Controls.Add(this.splitContainer1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Help";
		this.Text = "Help";
		base.Load += new System.EventHandler(this.Help_Load);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
