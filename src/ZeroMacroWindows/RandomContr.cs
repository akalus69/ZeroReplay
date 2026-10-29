using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class RandomContr : UserControl
{
	private IContainer components = null;

	private GroupBox groupBox1;

	private Label label1;

	private GroupBox groupBox2;

	public ComboBox comboBox1;

	public RadioButton radioButton2;

	public RadioButton radioButton1;

	public int var = 0;

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
		this.label1 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.comboBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(124, 91);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Opzioni";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(17, 24);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(85, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Numero caratteri";
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[15]
		{
			"1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
			"11", "12", "13", "14", "15"
		});
		this.comboBox1.Location = new System.Drawing.Point(20, 42);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(89, 21);
		this.comboBox1.TabIndex = 1;
		this.groupBox2.Controls.Add(this.radioButton2);
		this.groupBox2.Controls.Add(this.radioButton1);
		this.groupBox2.Location = new System.Drawing.Point(134, 3);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(125, 42);
		this.groupBox2.TabIndex = 1;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Random";
		this.radioButton1.AutoSize = true;
		this.radioButton1.Checked = true;
		this.radioButton1.Location = new System.Drawing.Point(17, 19);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(34, 17);
		this.radioButton1.TabIndex = 0;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Si";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(68, 19);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(39, 17);
		this.radioButton2.TabIndex = 1;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "No";
		this.radioButton2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Name = "RandomContr";
		base.Size = new System.Drawing.Size(272, 108);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
	}

	public RandomContr()
	{
		InitializeComponent();
	}

	public void setta()
	{
		try
		{
			string text = comboBox1.SelectedItem.ToString();
		}
		catch (Exception)
		{
			comboBox1.SelectedIndex = 0;
		}
	}
}
