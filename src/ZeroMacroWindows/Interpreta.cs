using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class Interpreta : Form
{
	private IContainer components = null;

	public TextBox textBox1;

	public Interpreta()
	{
		InitializeComponent();
	}

	private void Interpreta_Load(object sender, EventArgs e)
	{
		Location = new Point(0, 0);
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBox1.Location = new System.Drawing.Point(0, 0);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(292, 45);
		this.textBox1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(292, 45);
		base.ControlBox = false;
		base.Controls.Add(this.textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Interpreta";
		base.Opacity = 0.0;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Interpreta";
		base.TopMost = true;
		base.Load += new System.EventHandler(this.Interpreta_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
