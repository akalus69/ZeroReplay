using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class Pausa : UserControl
{
	private IContainer components = null;

	private GroupBox groupBox1;

	public TextBox textBox1;

	public int dt = 0;

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
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Location = new System.Drawing.Point(3, 14);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(88, 56);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Time (sec)";
		this.textBox1.Location = new System.Drawing.Point(6, 19);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(60, 20);
		this.textBox1.TabIndex = 0;
		this.textBox1.Text = "2";
		this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.groupBox1);
		base.Name = "Pausa";
		base.Size = new System.Drawing.Size(150, 86);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	public Pausa()
	{
		InitializeComponent();
	}
}
