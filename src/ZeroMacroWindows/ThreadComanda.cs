using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ZeroMacroWindows;

internal class ThreadComanda
{
	private Form1 mio;

	private int shift = 0;

	private int ctrl = 0;

	private int numerovariabile = 0;

	public ThreadComanda(Form1 m)
	{
		mio = m;
	}

	public void scrivi(string str)
	{
		if (str.CompareTo("!IrETURN") == 0)
		{
			Win32.keybd_event(13, 0, 0u, IntPtr.Zero);
			Win32.keybd_event(13, 0, 2u, IntPtr.Zero);
		}
		else if (str.CompareTo("!IcOPY") == 0)
		{
			Win32.keybd_event(17, 0, 0u, IntPtr.Zero);
			Win32.keybd_event(67, 0, 0u, IntPtr.Zero);
			Win32.keybd_event(67, 0, 2u, IntPtr.Zero);
			Win32.keybd_event(17, 0, 2u, IntPtr.Zero);
		}
		else if (str.CompareTo("!IdELETE") == 0)
		{
			Win32.keybd_event(46, 0, 0u, IntPtr.Zero);
			Win32.keybd_event(46, 0, 2u, IntPtr.Zero);
		}
		else if (str.CompareTo("!IdELETEX") == 0)
		{
			Win32.keybd_event(37, 0, 0u, IntPtr.Zero);
			Win32.keybd_event(37, 0, 2u, IntPtr.Zero);
			Win32.keybd_event(46, 0, 0u, IntPtr.Zero);
			Win32.keybd_event(46, 0, 2u, IntPtr.Zero);
		}
		else
		{
			if (str.CompareTo("!IsU") == 0 || str.CompareTo("!IgIU") == 0)
			{
				return;
			}
			if (str.CompareTo("!ImETIN2") == 0)
			{
				Mouseclicksxl mouseclicksxl = new Mouseclicksxl();
				mouseclicksxl.clickx(0, 0);
				return;
			}
			if (str.CompareTo("!IiNCOLLA") == 0)
			{
				Win32.keybd_event(17, 0, 0u, IntPtr.Zero);
				Win32.keybd_event(86, 0, 0u, IntPtr.Zero);
				Win32.keybd_event(86, 0, 2u, IntPtr.Zero);
				Win32.keybd_event(17, 0, 2u, IntPtr.Zero);
				return;
			}
			if (str.CompareTo("!ItAB") == 0)
			{
				Win32.keybd_event(9, 0, 0u, IntPtr.Zero);
				Win32.keybd_event(9, 0, 2u, IntPtr.Zero);
				return;
			}
			if (str.CompareTo("!IsHIFT") == 0)
			{
				Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
				Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
				shift = 1;
				return;
			}
			if (str.CompareTo("!IcTRL") == 0)
			{
				Win32.keybd_event(17, 0, 0u, IntPtr.Zero);
				Win32.keybd_event(17, 0, 2u, IntPtr.Zero);
				ctrl = 1;
				return;
			}
			if (str.CompareTo("!I$$") == 0)
			{
				str = numerovariabile.ToString();
				numerovariabile++;
			}
			int length = str.Length;
			char[] array = str.ToCharArray();
			char[] array2 = array;
			foreach (char c in array2)
			{
				if (shift == 1)
				{
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					shift = 2;
				}
				if (ctrl == 1)
				{
					Win32.keybd_event(17, 0, 0u, IntPtr.Zero);
					ctrl = 2;
				}
				switch (c)
				{
				case 'a':
					Win32.keybd_event(65, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(65, 0, 2u, IntPtr.Zero);
					break;
				case 'A':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(65, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(65, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'b':
					Win32.keybd_event(66, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(66, 0, 2u, IntPtr.Zero);
					break;
				case 'B':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(66, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(66, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'c':
					Win32.keybd_event(67, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(67, 0, 2u, IntPtr.Zero);
					break;
				case 'C':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(67, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(67, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'd':
					Win32.keybd_event(68, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(68, 0, 2u, IntPtr.Zero);
					break;
				case 'D':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(68, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(68, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'e':
					Win32.keybd_event(69, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(69, 0, 2u, IntPtr.Zero);
					break;
				case 'E':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(69, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(69, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'f':
					Win32.keybd_event(70, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(70, 0, 2u, IntPtr.Zero);
					break;
				case 'F':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(70, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(70, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'g':
					Win32.keybd_event(71, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(71, 0, 2u, IntPtr.Zero);
					break;
				case 'G':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(71, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(71, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'h':
					Win32.keybd_event(72, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(72, 0, 2u, IntPtr.Zero);
					break;
				case 'H':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(72, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(72, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'i':
					Win32.keybd_event(73, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(73, 0, 2u, IntPtr.Zero);
					break;
				case 'I':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(73, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(73, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'l':
					Win32.keybd_event(76, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(76, 0, 2u, IntPtr.Zero);
					break;
				case 'L':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(76, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(76, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'm':
					Win32.keybd_event(77, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(77, 0, 2u, IntPtr.Zero);
					break;
				case 'M':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(77, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(77, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'n':
					Win32.keybd_event(78, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(78, 0, 2u, IntPtr.Zero);
					break;
				case 'N':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(78, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(78, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'k':
					Win32.keybd_event(75, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(75, 0, 2u, IntPtr.Zero);
					break;
				case 'K':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(75, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(75, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'o':
					Win32.keybd_event(79, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(79, 0, 2u, IntPtr.Zero);
					break;
				case 'O':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(79, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(79, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'p':
					Win32.keybd_event(80, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(80, 0, 2u, IntPtr.Zero);
					break;
				case 'P':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(80, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(80, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'q':
					Win32.keybd_event(81, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(81, 0, 2u, IntPtr.Zero);
					break;
				case 'Q':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(81, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(81, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'r':
					Win32.keybd_event(82, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(82, 0, 2u, IntPtr.Zero);
					break;
				case 'R':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(82, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(82, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 's':
					Win32.keybd_event(83, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(83, 0, 2u, IntPtr.Zero);
					break;
				case 'S':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(83, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(83, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 't':
					Win32.keybd_event(84, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(84, 0, 2u, IntPtr.Zero);
					break;
				case 'T':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(84, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(84, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'u':
					Win32.keybd_event(85, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(85, 0, 2u, IntPtr.Zero);
					break;
				case 'U':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(85, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(85, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'v':
					Win32.keybd_event(86, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(86, 0, 2u, IntPtr.Zero);
					break;
				case 'V':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(86, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(86, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'z':
					Win32.keybd_event(90, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(90, 0, 2u, IntPtr.Zero);
					break;
				case 'Z':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(90, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(90, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'x':
					Win32.keybd_event(88, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(88, 0, 2u, IntPtr.Zero);
					break;
				case 'X':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(88, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(88, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'y':
					Win32.keybd_event(89, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(89, 0, 2u, IntPtr.Zero);
					break;
				case 'Y':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(89, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(89, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'j':
					Win32.keybd_event(74, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(74, 0, 2u, IntPtr.Zero);
					break;
				case 'J':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(74, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(74, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'w':
					Win32.keybd_event(87, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(87, 0, 2u, IntPtr.Zero);
					break;
				case 'W':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(87, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(87, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '0':
					Win32.keybd_event(48, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(48, 0, 2u, IntPtr.Zero);
					break;
				case '1':
					Win32.keybd_event(49, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(49, 0, 2u, IntPtr.Zero);
					break;
				case '2':
					Win32.keybd_event(50, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(50, 0, 2u, IntPtr.Zero);
					break;
				case '3':
					Win32.keybd_event(51, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(51, 0, 2u, IntPtr.Zero);
					break;
				case '4':
					Win32.keybd_event(52, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(52, 0, 2u, IntPtr.Zero);
					break;
				case '5':
					Win32.keybd_event(53, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(53, 0, 2u, IntPtr.Zero);
					break;
				case '6':
					Win32.keybd_event(54, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(54, 0, 2u, IntPtr.Zero);
					break;
				case '7':
					Win32.keybd_event(55, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(55, 0, 2u, IntPtr.Zero);
					break;
				case '8':
					Win32.keybd_event(56, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(56, 0, 2u, IntPtr.Zero);
					break;
				case '9':
					Win32.keybd_event(57, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(57, 0, 2u, IntPtr.Zero);
					break;
				case ',':
					Win32.keybd_event(188, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(188, 0, 2u, IntPtr.Zero);
					break;
				case '\r':
					Win32.keybd_event(13, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(13, 0, 2u, IntPtr.Zero);
					break;
				case '+':
					Win32.keybd_event(187, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(187, 0, 2u, IntPtr.Zero);
					break;
				case '-':
					Win32.keybd_event(189, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(189, 0, 2u, IntPtr.Zero);
					break;
				case '.':
					Win32.keybd_event(190, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(190, 0, 2u, IntPtr.Zero);
					break;
				case 'è':
					Win32.keybd_event(186, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(186, 0, 2u, IntPtr.Zero);
					break;
				case 'ù':
					Win32.keybd_event(191, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(191, 0, 2u, IntPtr.Zero);
					break;
				case 'à':
					Win32.keybd_event(222, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(222, 0, 2u, IntPtr.Zero);
					break;
				case 'ì':
					Win32.keybd_event(221, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(221, 0, 2u, IntPtr.Zero);
					break;
				case '\'':
					Win32.keybd_event(219, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(219, 0, 2u, IntPtr.Zero);
					break;
				case ' ':
					Win32.keybd_event(32, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(32, 0, 2u, IntPtr.Zero);
					break;
				case '\\':
					Win32.keybd_event(220, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(220, 0, 2u, IntPtr.Zero);
					break;
				case '<':
					Win32.keybd_event(223, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(223, 0, 2u, IntPtr.Zero);
					break;
				case 'ò':
					Win32.keybd_event(192, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(192, 0, 2u, IntPtr.Zero);
					break;
				case '§':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(191, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(191, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'ç':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(192, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(192, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case ':':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(190, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(190, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case ';':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(188, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(188, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '?':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(219, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(219, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '^':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(221, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(221, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '|':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(220, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(220, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '°':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(222, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(222, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '>':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(223, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(223, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '_':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(189, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(189, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case 'é':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(186, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(186, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '*':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(187, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(187, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '!':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(49, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(49, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '"':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(50, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(50, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '£':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(51, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(51, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '$':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(52, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(52, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '%':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(53, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(53, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '/':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(55, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(55, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '(':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(56, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(56, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '&':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(54, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(54, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case ')':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(57, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(57, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '=':
					Win32.keybd_event(16, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(48, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(48, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					break;
				case '@':
					Win32.keybd_event(165, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(192, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(192, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(165, 0, 2u, IntPtr.Zero);
					break;
				case '#':
					Win32.keybd_event(165, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(222, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(222, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(165, 0, 2u, IntPtr.Zero);
					break;
				case '[':
					Win32.keybd_event(165, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(186, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(186, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(165, 0, 2u, IntPtr.Zero);
					break;
				case ']':
					Win32.keybd_event(165, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(187, 0, 0u, IntPtr.Zero);
					Win32.keybd_event(187, 0, 2u, IntPtr.Zero);
					Win32.keybd_event(165, 0, 2u, IntPtr.Zero);
					break;
				}
				if (shift == 2)
				{
					Win32.keybd_event(16, 0, 2u, IntPtr.Zero);
					shift = 0;
				}
				if (ctrl == 2)
				{
					Win32.keybd_event(17, 0, 2u, IntPtr.Zero);
					ctrl = 0;
				}
				Thread.Sleep(10);
			}
		}
	}

	public void vai()
	{
		try
		{
			Random random = new Random();
			int num = 500;
			int millisecondsTimeout = 1000;
			int num2 = 1;
			try
			{
				num = int.Parse(mio.textBox1.Text);
			}
			catch (Exception)
			{
			}
			try
			{
				num2 = int.Parse(mio.textBox2.Text);
			}
			catch (Exception)
			{
			}
			int num3 = 0;
			if (mio.gotox)
			{
				num3 = mio.listBox1.SelectedIndex;
			}
			int num4 = mio.listBox1.Items.Count;
			if (mio.parziale)
			{
				bool flag = false;
				int num5 = -1;
				int num6 = -1;
				int num7 = 0;
				foreach (object item in mio.listBox1.Items)
				{
					if (item.ToString().IndexOf("*************************") >= 0)
					{
						if (num5 == -1)
						{
							num5 = num7;
						}
						else
						{
							num6 = num7;
						}
						flag = true;
					}
					num7++;
				}
				if (flag)
				{
					num3 = num5;
					num4 = num6;
				}
			}
			bool flag2 = false;
			bool flag3 = false;
			int index = 0;
			int index2 = 0;
			for (int i = 0; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					try
					{
						string text = mio.listBox1.Items[j].ToString();
						mio.listBox1.SelectedItem = text;
						if (text.IndexOf("Click Sx :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								Mousemovex mousemovex = new Mousemovex();
								Mouseclicksx mouseclicksx = new Mouseclicksx();
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new ClickSx(), n);
								int x = int.Parse(mio.listaclicksx[n].textBox1.Text);
								int y = int.Parse(mio.listaclicksx[n].textBox2.Text);
								mousemovex.movex(x, y);
								Thread.Sleep(250);
								mouseclicksx.clickx(x, y);
							}
						}
						if (text.IndexOf("Click Dx :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								Mousemovex mousemovex = new Mousemovex();
								Mouseclickdx mouseclickdx = new Mouseclickdx();
								int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n2 = mio.trovaposizioneinlista(new ClickDx(), n2);
								int x = int.Parse(mio.listaclickdx[n2].textBox1.Text);
								int y = int.Parse(mio.listaclickdx[n2].textBox2.Text);
								mousemovex.movex(x, y);
								Thread.Sleep(250);
								mouseclickdx.clickx(x, y);
							}
						}
						if (text.IndexOf("Parola :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n2 = mio.trovaposizioneinlista(new Parole(), n2);
								scrivi(mio.listaparole[n2].textBox1.Text);
								Thread.Sleep(250);
							}
						}
						if (text.IndexOf("Tratto Sx :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								Mousemovex mousemovex = new Mousemovex();
								Mouseclicksxp mouseclicksxp = new Mouseclicksxp();
								Mouseclicksxl mouseclicksxl = new Mouseclicksxl();
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new TrattoSx(), n);
								int x2 = int.Parse(mio.listatrattosx[n].textBox1.Text);
								int y2 = int.Parse(mio.listatrattosx[n].textBox2.Text);
								int x3 = int.Parse(mio.listatrattosx[n].textBox4.Text);
								int y3 = int.Parse(mio.listatrattosx[n].textBox3.Text);
								mousemovex.movex(x2, y2);
								int millisecondsTimeout2 = 350;
								if (num < 300)
								{
									millisecondsTimeout2 = num;
								}
								Thread.Sleep(millisecondsTimeout2);
								mouseclicksxp.clickx(x2, y2);
								Thread.Sleep(millisecondsTimeout2);
								mousemovex.movex(x3, y3);
								Thread.Sleep(millisecondsTimeout2);
								mouseclicksxl.clickx(x3, y3);
							}
						}
						if (text.IndexOf("Tratto Dx :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								Mousemovex mousemovex = new Mousemovex();
								Mouseclickdxp mouseclickdxp = new Mouseclickdxp();
								Mouseclickdxl mouseclickdxl = new Mouseclickdxl();
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new TrattoDx(), n);
								int x2 = int.Parse(mio.listatrattodx[n].textBox1.Text);
								int y2 = int.Parse(mio.listatrattodx[n].textBox2.Text);
								int x3 = int.Parse(mio.listatrattodx[n].textBox4.Text);
								int y3 = int.Parse(mio.listatrattodx[n].textBox3.Text);
								mousemovex.movex(x2, y2);
								Thread.Sleep(350);
								mouseclickdxp.clickx(x2, y2);
								Thread.Sleep(350);
								mousemovex.movex(x3, y3);
								Thread.Sleep(350);
								mouseclickdxl.clickx(x3, y3);
							}
						}
						if (text.IndexOf("Click 2x :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								Mousemovex mousemovex = new Mousemovex();
								Mouseclicksx mouseclicksx = new Mouseclicksx();
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new Clickx2(), n);
								int x = int.Parse(mio.listaclick2x[n].textBox1.Text);
								int y = int.Parse(mio.listaclick2x[n].textBox2.Text);
								mousemovex.movex(x, y);
								Thread.Sleep(250);
								mouseclicksx.clickx(x, y);
								Thread.Sleep(150);
								mouseclicksx.clickx(x, y);
							}
						}
						if (text.IndexOf("Pausa :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new Pausa(), n);
								string text2 = mio.listapausa[n].textBox1.Text;
								int num8 = 0;
								if (text2.IndexOf(",") >= 0)
								{
									string text3 = text2.Substring(text2.IndexOf(",") + 1);
									text2 = text2.Substring(0, text2.IndexOf(","));
									if (text2 != "0")
									{
										num8 = int.Parse(text2) * 1000;
									}
									num8 = ((text3.Length <= 1) ? (num8 + int.Parse(text3) * 100) : (num8 + int.Parse(text3) * 10));
								}
								else
								{
									num8 = int.Parse(text2) * 1000;
								}
								Thread.Sleep(num8);
							}
						}
						if (text.IndexOf("Variabile :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new RandomContr(), n);
								int num9 = mio.listarandom[n].comboBox1.SelectedIndex + 1;
								for (int k = 0; k < num9; k++)
								{
									if (mio.listarandom[n].radioButton1.Checked)
									{
										scrivi(random.Next(10).ToString());
										Thread.Sleep(100);
									}
									else
									{
										scrivi(mio.listarandom[n].var.ToString());
										mio.listarandom[n].var++;
									}
								}
							}
						}
						if (text.IndexOf("If :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								mio.zio.Opacity = 1.0;
								mio.zio.TopMost = true;
								Mousemovex mousemovex = new Mousemovex();
								Mouseclicksx mouseclicksx = new Mouseclicksx();
								int x = 5;
								int y = 5;
								mousemovex.movex(x, y);
								Thread.Sleep(250);
								mouseclicksx.clickx(x, y);
								Thread.Sleep(250);
								scrivi("!IiNCOLLA");
								Thread.Sleep(250);
								mio.zio.Opacity = 0.0;
								mio.zio.TopMost = false;
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new CondizioneIf(), n);
								mio.listaif[n].puntoflusso = j - 1;
								flag3 = true;
								index2 = n;
								string text4 = "";
								string text5 = mio.listaif[n].textBox1.Text;
								try
								{
									text4 = Clipboard.GetText();
								}
								catch (Exception)
								{
								}
								try
								{
									text4 = mio.zio.textBox1.Text;
									mio.zio.textBox1.Text = "";
								}
								catch (Exception)
								{
								}
								if (mio.listaif[n].checkBox1.Checked)
								{
									text4 = text4.ToLowerInvariant();
									text5 = text5.ToLowerInvariant();
								}
								if (mio.listaif[n].radioButton1.Checked)
								{
									if (text4 == text5)
									{
										mio.listaif[n].avanti = false;
									}
									else
									{
										StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\log.txt", append: true);
										streamWriter.WriteLine("OGGI : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + text4);
										streamWriter.Close();
										mio.listaif[n].avanti = true;
									}
								}
								if (mio.listaif[n].radioButton2.Checked)
								{
									if (text4.IndexOf(text5) >= 0)
									{
										mio.listaif[n].avanti = false;
									}
									else
									{
										StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\log.txt", append: true);
										streamWriter.WriteLine("OGGI : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + text4);
										streamWriter.Close();
										mio.listaif[n].avanti = true;
									}
								}
								if (mio.listaif[n].radioButton3.Checked)
								{
									if (text4 != text5)
									{
										mio.listaif[n].avanti = false;
									}
									else
									{
										StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\log.txt", append: true);
										streamWriter.WriteLine("OGGI : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + text4);
										streamWriter.Close();
										mio.listaif[n].avanti = true;
									}
								}
							}
						}
						if (text.IndexOf("C_If_C :") >= 0)
						{
							int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
							n = mio.trovaposizioneinlista(new CondizioneIf(), n);
							if (mio.listaif[n].avanti)
							{
								flag3 = false;
							}
						}
						if (text.IndexOf("While :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								mio.zio.Opacity = 1.0;
								mio.zio.TopMost = true;
								Mousemovex mousemovex = new Mousemovex();
								Mouseclicksx mouseclicksx = new Mouseclicksx();
								int x = 5;
								int y = 5;
								mousemovex.movex(x, y);
								Thread.Sleep(250);
								mouseclicksx.clickx(x, y);
								Thread.Sleep(250);
								scrivi("!IiNCOLLA");
								Thread.Sleep(250);
								mio.zio.Opacity = 0.0;
								mio.zio.TopMost = false;
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new Condizione(), n);
								mio.listawhile[n].puntoflusso = j - 1;
								flag2 = true;
								index = n;
								string text4 = "";
								string text5 = mio.listawhile[n].textBox1.Text;
								try
								{
									text4 = Clipboard.GetText();
								}
								catch (Exception)
								{
								}
								try
								{
									text4 = mio.zio.textBox1.Text;
									mio.zio.textBox1.Text = "";
								}
								catch (Exception)
								{
								}
								if (mio.listawhile[n].checkBox1.Checked)
								{
									text4 = text4.ToLowerInvariant();
									text5 = text5.ToLowerInvariant();
								}
								if (mio.listawhile[n].radioButton1.Checked)
								{
									if (text4 == text5)
									{
										mio.listawhile[n].avanti = true;
									}
									else
									{
										StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\log.txt", append: true);
										streamWriter.WriteLine("OGGI : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + text4);
										streamWriter.Close();
										mio.listawhile[n].avanti = false;
									}
								}
								if (mio.listawhile[n].radioButton2.Checked)
								{
									if (text4.IndexOf(text5) >= 0)
									{
										mio.listawhile[n].avanti = true;
									}
									else
									{
										StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\log.txt", append: true);
										streamWriter.WriteLine("OGGI : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + text4);
										streamWriter.Close();
										mio.listawhile[n].avanti = false;
									}
								}
								if (mio.listawhile[n].radioButton3.Checked)
								{
									if (text4 != text5)
									{
										mio.listawhile[n].avanti = true;
									}
									else
									{
										StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\log.txt", append: true);
										streamWriter.WriteLine("OGGI : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine + text4);
										streamWriter.Close();
										mio.listawhile[n].avanti = false;
									}
								}
							}
						}
						if (text.IndexOf("C_While_C :") >= 0)
						{
							int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
							n = mio.trovaposizioneinlista(new Condizione(), n);
							if (!mio.listawhile[n].avanti)
							{
								j = mio.listawhile[n].puntoflusso;
							}
							else
							{
								flag2 = false;
							}
						}
						if (text.IndexOf("--------------------------") >= 0)
						{
							MessageBox.Show("Pausa.. Premere Ok per far ripartire il programma");
							mio.pausaprogramma = false;
							mio.button16.BackColor = mio.BackColor;
						}
						if (text.IndexOf("Process :") >= 0)
						{
							bool flag4 = true;
							if (flag2 && mio.listawhile[index].avanti)
							{
								flag4 = false;
							}
							if (flag3 && mio.listaif[index2].avanti)
							{
								flag4 = false;
							}
							if (flag4)
							{
								int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
								n = mio.trovaposizioneinlista(new ProcessStart(), n);
								string text6 = mio.listaprocessi[n].textBox1.Text;
								string text7 = mio.listaprocessi[n].textBox2.Text;
								if (text7 != "")
								{
									Process.Start(text6, text7);
								}
								else
								{
									Process.Start(text6);
								}
							}
						}
						if (mio.pausaprogramma)
						{
							MessageBox.Show("Pausa.. Premere Ok per far ripartire il programma");
							mio.pausaprogramma = false;
							mio.button16.BackColor = mio.BackColor;
						}
					}
					catch
					{
					}
					Thread.Sleep(num);
				}
				Thread.Sleep(millisecondsTimeout);
			}
		}
		catch (Exception)
		{
		}
	}
}
