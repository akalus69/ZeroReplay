using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class TrattoDx : UserControl
{
	private IContainer components = null;

	private GroupBox groupBox2;

	public TextBox textBox3;

	private Label label3;

	public TextBox textBox4;

	private Label label4;

	private GroupBox groupBox1;

	public TextBox textBox2;

	private Label label2;

	public TextBox textBox1;

	private Label label1;

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
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.groupBox2.SuspendLayout();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox2.Controls.Add(this.textBox3);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Controls.Add(this.textBox4);
		this.groupBox2.Controls.Add(this.label4);
		this.groupBox2.Location = new System.Drawing.Point(148, 14);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(112, 100);
		this.groupBox2.TabIndex = 6;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Position End";
		this.textBox3.Location = new System.Drawing.Point(27, 57);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(58, 20);
		this.textBox3.TabIndex = 3;
		this.textBox3.Text = "0";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(7, 60);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(14, 13);
		this.label3.TabIndex = 2;
		this.label3.Text = "Y";
		this.textBox4.Location = new System.Drawing.Point(27, 17);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(58, 20);
		this.textBox4.TabIndex = 1;
		this.textBox4.Text = "0";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(7, 20);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(14, 13);
		this.label4.TabIndex = 0;
		this.label4.Text = "X";
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(15, 14);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(112, 100);
		this.groupBox1.TabIndex = 5;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Position Start";
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
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Name = "TrattoDx";
		base.Size = new System.Drawing.Size(290, 139);
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	public TrattoDx()
	{
		InitializeComponent();
	}
}
