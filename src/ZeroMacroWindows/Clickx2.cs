using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class Clickx2 : UserControl
{
	public int dt = 0;

	private IContainer components = null;

	private GroupBox groupBox1;

	public TextBox textBox2;

	private Label label2;

	public TextBox textBox1;

	private Label label1;

	public Clickx2()
	{
		InitializeComponent();
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
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(112, 100);
		this.groupBox1.TabIndex = 1;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Position";
		this.textBox2.Location = new System.Drawing.Point(27, 57);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(58, 20);
		this.textBox2.TabIndex = 3;
		this.textBox2.Text = "0";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(7, 60);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(14, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Y";
		this.textBox1.Location = new System.Drawing.Point(27, 17);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(58, 20);
		this.textBox1.TabIndex = 1;
		this.textBox1.Text = "0";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(7, 20);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(14, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "X";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.groupBox1);
		base.Name = "Clickx2";
		base.Size = new System.Drawing.Size(148, 114);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}
}
