using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class REC : Form
{
	private InputListener inputListener;

	private Form1 mio;

	private IContainer components = null;

	private TextBox tbStatus;

	private Button button1;

	private CheckBox checkBox1;

	private SplitContainer splitContainer1;

	private Label label1;

	public TextBox textBox1;

	private Button button2;

	private CheckBox checkBox2;

	public REC(Form1 m)
	{
		mio = m;
		InitializeComponent();
	}

	private void REC_Load(object sender, EventArgs e)
	{
		checkBox1.Checked = true;
	}

	private void InputListener_KeyPress(object sender, KeyPressEventArgs e)
	{
		string text = "";
		TextBox textBox = tbStatus;
		textBox.Text = textBox.Text + "Attesa " + inputListener.attesa + "\r\n";
		inputListener.attesa = 0;
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Space") == 0) ? " " : Enum.GetName(typeof(Keys), e.KeyCode));
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Enter") == 0) ? "!IrETURN" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Tab") == 0) ? "!ItAB" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oem4") == 0) ? "'" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D1") == 0) ? "1" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D2") == 0) ? "2" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D3") == 0) ? "3" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("OemPipe") == 0) ? "\\" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oem102") == 0) ? "<" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oem6") == 0) ? "ì" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("LShiftKey") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("RShiftKey") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("RControlKey") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("LControlKey") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("LWin") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("RWin") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Back") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Left") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Down") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Up") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Right") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("End") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("PageDown") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumLock") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Divide") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Multiply") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Subtract") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Add") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Prior") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Clear") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Insert") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Home") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Delete") == 0) ? "!IdELETE" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Back") == 0) ? "!IdELETEX" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Decimal") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Menu") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("RMenu") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Apps") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("LMenu") == 0) ? " " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad1") == 0) ? "1" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad2") == 0) ? "2" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad3") == 0) ? "3" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad4") == 0) ? "4" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad5") == 0) ? "5" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad6") == 0) ? "6" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad7") == 0) ? "7" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad8") == 0) ? "8" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad9") == 0) ? "9" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("NumPad0") == 0) ? "0" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("OemSemicolon") == 0) ? "è" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oemplus") == 0) ? "+" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oemtilde") == 0) ? "ò" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("OemQuotes") == 0) ? "à" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oem2") == 0) ? "ù" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("Oemcomma") == 0) ? "," : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("OemPeriod") == 0) ? "." : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("OemMinus") == 0) ? "-" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D4") == 0) ? "4" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D5") == 0) ? "5" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D6") == 0) ? "6" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D7") == 0) ? "7" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D8") == 0) ? "8" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D9") == 0) ? "9" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("D0") == 0) ? "0" : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("ShiftKey") == 0) ? " !IsHIFT " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("ControlKey") == 0) ? " !IcTRL " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("ShiftKeyLShiftKey") == 0) ? " !IsHIFT " : text);
		text = ((Enum.GetName(typeof(Keys), e.KeyCode).CompareTo("MButton") == 0) ? " " : text);
		if (e.ModifierKeys == Keys.Shift)
		{
			TextBox textBox2 = tbStatus;
			textBox2.Text = textBox2.Text + "Prexxed Shift & " + text + "\r\n";
		}
		else if (text.IndexOf("!") < 0)
		{
			TextBox textBox3 = tbStatus;
			textBox3.Text = textBox3.Text + "Prexxed " + text.ToLowerInvariant() + "\r\n";
		}
		else
		{
			TextBox textBox4 = tbStatus;
			textBox4.Text = textBox4.Text + "Prexxed " + text + "\r\n";
		}
		tbStatus.SelectionStart = tbStatus.Text.Length;
		tbStatus.ScrollToCaret();
	}

	private void InputListener_MouseButton(object sender, MouseButtonEventArgs e)
	{
		TextBox textBox = tbStatus;
		textBox.Text = textBox.Text + "Attesa " + inputListener.attesa + "\r\n";
		if (e.buttonState == MouseButtonState.Pressed)
		{
			TextBox textBox2 = tbStatus;
			textBox2.Text = textBox2.Text + "Pressed " + e.Button.ToString() + "\r\n";
		}
		else
		{
			TextBox textBox3 = tbStatus;
			textBox3.Text = textBox3.Text + "Released " + e.Button.ToString() + "\r\n";
		}
		tbStatus.SelectionStart = tbStatus.Text.Length;
		tbStatus.ScrollToCaret();
	}

	private void InputListener_MouseMove(object sender, MouseMoveEventArgs e)
	{
		TextBox textBox = tbStatus;
		textBox.Text = textBox.Text + "Attesa " + inputListener.attesa + "\r\n";
		TextBox textBox2 = tbStatus;
		string text = textBox2.Text;
		textBox2.Text = text + "Moved " + e.X + "," + e.Y + "\r\n";
		tbStatus.SelectionStart = tbStatus.Text.Length;
		tbStatus.ScrollToCaret();
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		TopMost = checkBox1.Checked;
	}

	private void trasforma()
	{
		try
		{
			string text = "0";
			string text2 = "0";
			string text3 = tbStatus.Text;
			while (text3.IndexOf("\r\n") >= 0)
			{
				string text4 = text3.Substring(0, text3.IndexOf("\r\n"));
				text3 = text3.Substring(text3.IndexOf("\r\n") + 2);
				if (text4.IndexOf("Moved ") >= 0)
				{
					string text5 = text4.Substring(text4.IndexOf(" ") + 1);
					text2 = text5.Substring(text5.IndexOf(",") + 1);
					text = text5.Substring(0, text5.IndexOf(","));
				}
				if (text4.IndexOf("Attesa ") >= 0)
				{
					try
					{
						string text5 = text4.Substring(text4.IndexOf(" ") + 1);
						if (int.Parse(text5) > 10)
						{
							double num = double.Parse(text5) / 1000.0;
							int num2 = mio.aggiungipausa();
							for (int i = 0; i < mio.listapausa.Count; i++)
							{
								if (mio.listapausa[i].dt == num2)
								{
									mio.listapausa[i].textBox1.Text = num.ToString();
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
				if (text4.IndexOf("Prexxed") >= 0)
				{
					if (text4.IndexOf("Shift") < 0)
					{
						int num2 = mio.aggiungistringa();
						text4 = text4.Substring(text4.IndexOf(" ") + 1);
						if (text4.Length > 3)
						{
							text4 = text4.Replace(" ", "");
						}
						for (int i = 0; i < mio.listaparole.Count; i++)
						{
							if (mio.listaparole[i].dt == num2)
							{
								mio.listaparole[i].textBox1.Text = text4;
							}
						}
					}
					else
					{
						text4 = text4.Substring(text4.LastIndexOf(" ") + 1);
						if (text4.Length > 3)
						{
							text4 = text4.Replace(" ", "");
						}
						if (text4 != "")
						{
							int num2 = mio.aggiungistringa();
							for (int i = 0; i < mio.listaparole.Count; i++)
							{
								if (mio.listaparole[i].dt == num2)
								{
									mio.listaparole[i].textBox1.Text = "!IsHIFT";
								}
							}
							num2 = mio.aggiungistringa();
							for (int i = 0; i < mio.listaparole.Count; i++)
							{
								if (mio.listaparole[i].dt == num2)
								{
									mio.listaparole[i].textBox1.Text = text4;
								}
							}
						}
					}
				}
				if (text4.IndexOf("Pressed Left") >= 0)
				{
					if (text3.IndexOf("Released Left") >= 0)
					{
						string text5 = text3.Substring(0, text3.IndexOf("Released Left"));
						text3 = text3.Substring(text3.IndexOf("Released Left"));
						text3 = text3.Substring(text3.IndexOf("\r\n") + 2);
						if (text5.IndexOf("Moved ") >= 0)
						{
							string text6 = "0";
							string text7 = "0";
							bool flag = false;
							string text8 = "";
							string text9 = "";
							int num3 = 0;
							int num4 = int.Parse(textBox1.Text);
							while (text5.IndexOf("Moved ") >= 0)
							{
								text5 = text5.Substring(text5.IndexOf("Moved ") + 1);
								string text10 = text5.Substring(text5.IndexOf(" ") + 1);
								text10 = text10.Substring(0, text10.IndexOf("\r\n"));
								text7 = text10.Substring(text10.IndexOf(",") + 1);
								text6 = text10.Substring(0, text10.IndexOf(","));
								int num5 = int.Parse(text6);
								int num6 = int.Parse(text7);
								int num7 = int.Parse(text);
								int num8 = int.Parse(text2);
								if (num4 != 0)
								{
									if ((num5 > num7 + num4 || num5 < num7 - num4) && (num6 > num8 + num4 || num6 < num8 - num4))
									{
										flag = false;
										int num2 = mio.aggiungitrattosx();
										for (int i = 0; i < mio.listatrattosx.Count; i++)
										{
											if (mio.listatrattosx[i].dt == num2)
											{
												mio.listatrattosx[i].textBox1.Text = text;
												mio.listatrattosx[i].textBox2.Text = text2;
												mio.listatrattosx[i].textBox4.Text = text6;
												mio.listatrattosx[i].textBox3.Text = text7;
											}
										}
									}
									else
									{
										if (num3 == 0)
										{
											text8 = text;
											text9 = text2;
										}
										num3++;
										flag = true;
									}
								}
								else
								{
									int num2 = mio.aggiungitrattosx();
									for (int i = 0; i < mio.listatrattosx.Count; i++)
									{
										if (mio.listatrattosx[i].dt == num2)
										{
											mio.listatrattosx[i].textBox1.Text = text;
											mio.listatrattosx[i].textBox2.Text = text2;
											mio.listatrattosx[i].textBox4.Text = text6;
											mio.listatrattosx[i].textBox3.Text = text7;
										}
									}
								}
								text = text6;
								text2 = text7;
							}
							if (flag && num4 != 0)
							{
								int num2 = mio.aggiungitrattosx();
								for (int i = 0; i < mio.listatrattosx.Count; i++)
								{
									if (mio.listatrattosx[i].dt == num2)
									{
										mio.listatrattosx[i].textBox1.Text = text8;
										mio.listatrattosx[i].textBox2.Text = text9;
										mio.listatrattosx[i].textBox4.Text = text6;
										mio.listatrattosx[i].textBox3.Text = text7;
									}
								}
							}
						}
						else
						{
							text4 = "Attesa";
							while (text4.IndexOf("Attesa") >= 0)
							{
								text4 = text3.Substring(0, text3.IndexOf("\r\n"));
								if (text4.IndexOf("Attesa") >= 0)
								{
									text3 = text3.Substring(text3.IndexOf("\r\n") + 2);
								}
							}
							if (text4.IndexOf("Pressed Left") >= 0)
							{
								text3 = text3.Substring(text3.IndexOf("\r\n") + 2);
								int num2 = mio.aggiungiclickperdue();
								for (int i = 0; i < mio.listaclick2x.Count; i++)
								{
									if (mio.listaclick2x[i].dt == num2)
									{
										mio.listaclick2x[i].textBox1.Text = text;
										mio.listaclick2x[i].textBox2.Text = text2;
									}
								}
							}
							else
							{
								int num2 = mio.aggiungiclicksx();
								for (int i = 0; i < mio.listaclicksx.Count; i++)
								{
									if (mio.listaclicksx[i].dt == num2)
									{
										mio.listaclicksx[i].textBox1.Text = text;
										mio.listaclicksx[i].textBox2.Text = text2;
									}
								}
							}
						}
					}
					else
					{
						text3 = "";
					}
				}
				if (text4.IndexOf("Pressed Right") < 0)
				{
					continue;
				}
				if (text3.IndexOf("Released Right") >= 0)
				{
					string text5 = text3.Substring(0, text3.IndexOf("Released Right"));
					text3 = text3.Substring(text3.IndexOf("Released Right"));
					text3 = text3.Substring(text3.IndexOf("\r\n") + 2);
					int num2;
					if (text5.IndexOf("Moved ") >= 0)
					{
						string text6 = "0";
						string text7 = "0";
						bool flag = false;
						string text8 = "";
						string text9 = "";
						int num3 = 0;
						int num4 = int.Parse(textBox1.Text);
						while (text5.IndexOf("Moved ") >= 0)
						{
							text5 = text5.Substring(text5.IndexOf("Moved ") + 1);
							string text10 = text5.Substring(text5.IndexOf(" ") + 1);
							text10 = text10.Substring(0, text10.IndexOf("\r\n"));
							text7 = text10.Substring(text10.IndexOf(",") + 1);
							text6 = text10.Substring(0, text10.IndexOf(","));
							int num5 = int.Parse(text6);
							int num6 = int.Parse(text7);
							int num7 = int.Parse(text);
							int num8 = int.Parse(text2);
							if (num4 != 0)
							{
								if ((num5 > num7 + num4 || num5 < num7 - num4) && (num6 > num8 + num4 || num6 < num8 - num4))
								{
									flag = false;
									num2 = mio.aggiungitrattodx();
									for (int i = 0; i < mio.listatrattodx.Count; i++)
									{
										if (mio.listatrattodx[i].dt == num2)
										{
											mio.listatrattodx[i].textBox1.Text = text;
											mio.listatrattodx[i].textBox2.Text = text2;
											mio.listatrattodx[i].textBox4.Text = text6;
											mio.listatrattodx[i].textBox3.Text = text7;
										}
									}
								}
								else
								{
									if (num3 == 0)
									{
										text8 = text;
										text9 = text2;
									}
									num3++;
									flag = true;
								}
							}
							else
							{
								num2 = mio.aggiungitrattodx();
								for (int i = 0; i < mio.listatrattodx.Count; i++)
								{
									if (mio.listatrattodx[i].dt == num2)
									{
										mio.listatrattodx[i].textBox1.Text = text;
										mio.listatrattodx[i].textBox2.Text = text2;
										mio.listatrattodx[i].textBox4.Text = text6;
										mio.listatrattodx[i].textBox3.Text = text7;
									}
								}
							}
							text = text6;
							text2 = text7;
						}
						if (!flag || num4 == 0)
						{
							continue;
						}
						num2 = mio.aggiungitrattodx();
						for (int i = 0; i < mio.listatrattodx.Count; i++)
						{
							if (mio.listatrattodx[i].dt == num2)
							{
								mio.listatrattodx[i].textBox1.Text = text8;
								mio.listatrattodx[i].textBox2.Text = text9;
								mio.listatrattodx[i].textBox4.Text = text6;
								mio.listatrattodx[i].textBox3.Text = text7;
							}
						}
						continue;
					}
					num2 = mio.aggiungiclickdx();
					for (int i = 0; i < mio.listaclickdx.Count; i++)
					{
						if (mio.listaclickdx[i].dt == num2)
						{
							mio.listaclickdx[i].textBox1.Text = text;
							mio.listaclickdx[i].textBox2.Text = text2;
						}
					}
				}
				else
				{
					text3 = "";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			inputListener.vai = false;
			inputListener.Kill();
			trasforma();
		}
		catch (Exception)
		{
		}
		Close();
	}

	private void REC_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			mio.button23.BackColor = Color.White;
			mio.vai = false;
			inputListener.vai = false;
		}
		catch (Exception)
		{
		}
	}

	private void REC_FormClosing_1(object sender, FormClosingEventArgs e)
	{
		try
		{
			mio.button23.BackColor = Color.White;
			mio.vai = false;
			inputListener.vai = false;
		}
		catch (Exception)
		{
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		button2.Enabled = false;
		inputListener = new InputListener();
		inputListener.OnMouseMove += InputListener_MouseMove;
		inputListener.OnMouseButton += InputListener_MouseButton;
		inputListener.OnKeyPress += InputListener_KeyPress;
		inputListener.Run();
	}

	private void REC_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox2.Checked)
		{
			textBox1.Text = "0";
		}
		else
		{
			textBox1.Text = "1000";
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroMacroWindows.REC));
		this.tbStatus = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.button2 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.tbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tbStatus.Location = new System.Drawing.Point(0, 0);
		this.tbStatus.Multiline = true;
		this.tbStatus.Name = "tbStatus";
		this.tbStatus.ReadOnly = true;
		this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.tbStatus.Size = new System.Drawing.Size(226, 113);
		this.tbStatus.TabIndex = 0;
		this.button1.Location = new System.Drawing.Point(146, 4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 22);
		this.button1.TabIndex = 1;
		this.button1.Text = "Stop";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(this.button1_Click);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(3, 8);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(66, 17);
		this.checkBox1.TabIndex = 2;
		this.checkBox1.Text = "top most";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.tbStatus);
		this.splitContainer1.Panel2.Controls.Add(this.checkBox2);
		this.splitContainer1.Panel2.Controls.Add(this.button2);
		this.splitContainer1.Panel2.Controls.Add(this.label1);
		this.splitContainer1.Panel2.Controls.Add(this.textBox1);
		this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
		this.splitContainer1.Panel2.Controls.Add(this.button1);
		this.splitContainer1.Size = new System.Drawing.Size(226, 176);
		this.splitContainer1.SplitterDistance = 113;
		this.splitContainer1.TabIndex = 3;
		this.button2.Location = new System.Drawing.Point(83, 4);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(57, 22);
		this.button2.TabIndex = 5;
		this.button2.Text = "Play";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(this.button2_Click);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(233, 46);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(81, 13);
		this.label1.TabIndex = 4;
		this.label1.Text = "Normalizza tratti";
		this.textBox1.Location = new System.Drawing.Point(351, 41);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(100, 20);
		this.textBox1.TabIndex = 3;
		this.textBox1.Text = "1000";
		this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new System.Drawing.Point(4, 32);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(65, 17);
		this.checkBox2.TabIndex = 6;
		this.checkBox2.Text = "Disegna";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(226, 176);
		base.Controls.Add(this.splitContainer1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "REC";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "REC";
		base.Load += new System.EventHandler(this.REC_Load);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.REC_FormClosed);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.REC_FormClosing_1);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
