using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class CondizioneIf : UserControl
{
	private IContainer components = null;

	private GroupBox groupBox1;

	public RadioButton radioButton2;

	public RadioButton radioButton1;

	public TextBox textBox1;

	public RadioButton radioButton3;

	public CheckBox checkBox1;

	public bool avanti = false;

	public int puntoflusso = 0;

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
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.checkBox1);
		this.groupBox1.Controls.Add(this.radioButton3);
		this.groupBox1.Controls.Add(this.radioButton2);
		this.groupBox1.Controls.Add(this.radioButton1);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(282, 99);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Condizone da verificare";
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(6, 45);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(93, 17);
		this.checkBox1.TabIndex = 4;
		this.checkBox1.Text = "CaseSensitive";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.radioButton3.AutoSize = true;
		this.radioButton3.Location = new System.Drawing.Point(141, 64);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(76, 17);
		this.radioButton3.TabIndex = 3;
		this.radioButton3.Text = "Diversa da";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(141, 42);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(135, 17);
		this.radioButton2.TabIndex = 2;
		this.radioButton2.Text = "Contente queste parole";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton1.AutoSize = true;
		this.radioButton1.Checked = true;
		this.radioButton1.Location = new System.Drawing.Point(141, 19);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(59, 17);
		this.radioButton1.TabIndex = 1;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Uguale";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.textBox1.Location = new System.Drawing.Point(6, 19);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(120, 20);
		this.textBox1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.groupBox1);
		base.Name = "Condizione";
		base.Size = new System.Drawing.Size(290, 111);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	public CondizioneIf()
	{
		InitializeComponent();
	}
}
