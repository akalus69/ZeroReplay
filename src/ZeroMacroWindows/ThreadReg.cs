using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZeroMacroWindows;

internal class ThreadReg
{
	private string keybuffer;

	private int tempo;

	private StringBuilder strtempo;

	private Form1 mio;

	private int attesa;

	public ThreadReg(Form1 m)
	{
		tempo = 0;
		strtempo = new StringBuilder();
		mio = m;
		attesa = 10;
	}

	public void vai()
	{
		keybuffer = string.Empty;
		int num = 0;
		MessageBox.Show("Saranno registrati solo i movimenti che seguiranno 1 beep, gli altri bisognera' ripeterli fino a sentirlo");
		while (mio.vai)
		{
			foreach (int value in Enum.GetValues(typeof(Keys)))
			{
				if (Keylog.GetAsyncKeyState(value) != -32767)
				{
					continue;
				}
				Point pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				string name = Enum.GetName(typeof(Keys), value);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Space") == 0) ? " " : Enum.GetName(typeof(Keys), value));
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Enter") == 0) ? " !IrETURN " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Tab") == 0) ? " !ItAB " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oem4") == 0) ? "'" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D1") == 0) ? "1" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D2") == 0) ? "2" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D3") == 0) ? "3" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("OemPipe") == 0) ? "\\" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oem102") == 0) ? "<" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oem6") == 0) ? "ì" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("LShiftKey") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("RShiftKey") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("RControlKey") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("LControlKey") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("LWin") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("RWin") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Back") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Left") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Down") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Up") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Right") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("End") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("PageDown") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumLock") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Divide") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Multiply") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Subtract") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Add") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Prior") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Clear") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Insert") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Home") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Delete") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Decimal") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Menu") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("RMenu") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Apps") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("LMenu") == 0) ? " " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad1") == 0) ? "1" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad2") == 0) ? "2" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad3") == 0) ? "3" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad4") == 0) ? "4" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad5") == 0) ? "5" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad6") == 0) ? "6" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad7") == 0) ? "7" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad8") == 0) ? "8" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad9") == 0) ? "9" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("NumPad0") == 0) ? "0" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("OemSemicolon") == 0) ? "è" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oemplus") == 0) ? "+" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oemtilde") == 0) ? "ò" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("OemQuotes") == 0) ? "à" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oem2") == 0) ? "ù" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("Oemcomma") == 0) ? "," : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("OemPeriod") == 0) ? "." : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("OemMinus") == 0) ? "-" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D4") == 0) ? "4" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D5") == 0) ? "5" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D6") == 0) ? "6" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D7") == 0) ? "7" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D8") == 0) ? "8" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D9") == 0) ? "9" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("D0") == 0) ? "0" : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("ShiftKey") == 0) ? " !IsHIFT " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("ControlKey") == 0) ? " !IcTRL " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("ShiftKeyLShiftKey") == 0) ? " !IsHIFT " : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("LButton") == 0) ? (" Lbutton( " + pt.X + "," + pt.Y + ") ") : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("RButton") == 0) ? (" Rbutton( " + pt.X + "," + pt.Y + ") ") : keybuffer);
				keybuffer = ((Enum.GetName(typeof(Keys), value).CompareTo("MButton") == 0) ? " " : keybuffer);
				if (keybuffer.CompareTo(" Lbutton( " + pt.X + "," + pt.Y + ") ") == 0)
				{
					try
					{
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
				}
				if (keybuffer.CompareTo(" Rbutton( " + pt.X + "," + pt.Y + ") ") == 0)
				{
					try
					{
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
				}
				if (tempo > 1000)
				{
					strtempo.Append(" !TT!" + tempo + " " + keybuffer);
				}
				else
				{
					strtempo.Append(keybuffer);
				}
				tempo = 0;
			}
			Thread.Sleep(attesa);
			tempo += attesa;
		}
	}
}
