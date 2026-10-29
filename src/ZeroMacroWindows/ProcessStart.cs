using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class ProcessStart : UserControl
{
	private IContainer components = null;

	private GroupBox groupBox1;

	private Label label3;

	private Label label2;

	private ListBox listBox1;

	private Label label1;

	public TextBox textBox2;

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
		this.label1 = new System.Windows.Forms.Label();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.listBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(335, 120);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Process Start";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(3, 16);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(82, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Process to Start";
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(197, 32);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(127, 82);
		this.listBox1.TabIndex = 1;
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(194, 16);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(78, 13);
		this.label2.TabIndex = 2;
		this.label2.Text = "Active Process";
		this.textBox1.Location = new System.Drawing.Point(6, 32);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(174, 20);
		this.textBox1.TabIndex = 3;
		this.textBox2.Location = new System.Drawing.Point(6, 71);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(174, 20);
		this.textBox2.TabIndex = 5;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(3, 55);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(78, 13);
		this.label3.TabIndex = 4;
		this.label3.Text = "Option process";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.groupBox1);
		base.Name = "ProcessStart";
		base.Size = new System.Drawing.Size(348, 134);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	public ProcessStart()
	{
		InitializeComponent();
	}

	public void setta()
	{
		Process[] processes = Process.GetProcesses();
		listBox1.Items.Clear();
		Process[] array = processes;
		foreach (Process process in array)
		{
			string processName = process.ProcessName;
			listBox1.Items.Add(processName);
		}
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string value = listBox1.SelectedItem.ToString();
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				string fileName = process.MainModule.FileName;
				if (fileName.IndexOf(value) >= 0)
				{
					textBox1.Text = fileName;
				}
			}
			if (textBox1.Text == "")
			{
				textBox1.Text = value;
			}
		}
		catch (Exception)
		{
		}
	}
}
