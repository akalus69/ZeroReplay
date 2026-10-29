using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class Parole : UserControl
{
	public int dt = 0;

	private IContainer components = null;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private ListBox listBox1;

	public TextBox textBox1;

	public Parole()
	{
		InitializeComponent();
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			switch (listBox1.SelectedIndex)
			{
			case 0:
				textBox1.Text = "!IcOPY";
				break;
			case 1:
				textBox1.Text = "!IiNCOLLA";
				break;
			case 2:
				textBox1.Text = "!IcTRL";
				break;
			case 3:
				textBox1.Text = "!IsHIFT";
				break;
			case 4:
				textBox1.Text = "!IrETURN";
				break;
			case 5:
				textBox1.Text = "!ItAB";
				break;
			case 6:
				textBox1.Text = "!IdELETE";
				break;
			}
		}
		catch (Exception)
		{
		}
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Location = new System.Drawing.Point(3, 5);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(124, 100);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Word";
		this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBox1.Location = new System.Drawing.Point(3, 16);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.textBox1.Size = new System.Drawing.Size(118, 81);
		this.textBox1.TabIndex = 0;
		this.groupBox2.Controls.Add(this.listBox1);
		this.groupBox2.Location = new System.Drawing.Point(133, 5);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(168, 100);
		this.groupBox2.TabIndex = 1;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Extra Option";
		this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Items.AddRange(new object[7] { "Copy selected text in Memory", "Insert text in Memory", "Press CTRL", "Press SHIFT", "Press Return", "Press Tab", "Press Delete" });
		this.listBox1.Location = new System.Drawing.Point(3, 16);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(162, 69);
		this.listBox1.TabIndex = 0;
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Name = "Parole";
		base.Size = new System.Drawing.Size(307, 113);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
