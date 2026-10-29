using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ZeroMacroWindows;

internal class ThreadTRVX
{
	private int shift = 0;

	private int ctrl = 0;

	private int numerovariabile = 0;

	private Form1 mio;

	public ThreadTRVX(Form1 m)
	{
		mio = m;
	}

	public ThreadTRVX()
	{
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

	public void conta()
	{
		try
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
			string text = mio.zio.textBox1.Text;
			MessageBox.Show(text.Length.ToString());
		}
		catch (Exception)
		{
		}
	}

	public void salvaparte()
	{
		mio.Controls.Add(mio.listBox1);
		mio.listBox1.BringToFront();
		mio.listBox1.Dock = DockStyle.Fill;
		string text = "";
		while (text == "")
		{
			try
			{
				text = mio.listBox1.SelectedItem.ToString();
			}
			catch (Exception)
			{
			}
		}
		string text2 = "";
		while (text2 == "")
		{
			try
			{
				text2 = mio.listBox1.SelectedItem.ToString();
			}
			catch (Exception)
			{
			}
		}
		List<string> list = new List<string>();
		bool flag = false;
		foreach (object item in mio.listBox1.Items)
		{
			if (item.ToString().IndexOf(text) >= 0)
			{
				flag = true;
			}
			if (item.ToString().IndexOf(text2) >= 0)
			{
				flag = false;
			}
			if (flag)
			{
				list.Add(item.ToString());
			}
		}
		mio.salva(list);
		mio.splitContainer3.Panel1.Controls.Add(mio.listBox1);
		mio.listBox1.Dock = DockStyle.Fill;
	}

	public void inserisciA()
	{
		try
		{
			int num = 0;
			try
			{
				num = mio.listBox1.SelectedIndex;
				if (num < 1)
				{
					num = 0;
				}
			}
			catch (Exception)
			{
			}
			if (num < 0)
			{
				num = 0;
			}
			for (int i = num; i < mio.listBox1.Items.Count; i++)
			{
				string text = mio.listBox1.Items[i].ToString();
				mio.listBox1.SelectedItem = text;
				Thread.Sleep(1000);
				if (text.IndexOf("Click Sx :") >= 0)
				{
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3500);
					Point pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
					n = mio.trovaposizioneinlista(new ClickSx(), n);
					mio.listaclicksx[n].textBox1.Text = pt.X.ToString();
					mio.listaclicksx[n].textBox2.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
				}
				if (text.IndexOf("Click Dx :") >= 0)
				{
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3500);
					Point pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
					n2 = mio.trovaposizioneinlista(new ClickDx(), n2);
					mio.listaclickdx[n2].textBox1.Text = pt.X.ToString();
					mio.listaclickdx[n2].textBox2.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
				}
				if (text.IndexOf("Tratto Sx :") >= 0)
				{
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3500);
					Point pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
					n2 = mio.trovaposizioneinlista(new TrattoSx(), n2);
					mio.listatrattosx[n2].textBox1.Text = pt.X.ToString();
					mio.listatrattosx[n2].textBox2.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
					Thread.Sleep(1500);
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3000);
					pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					mio.listatrattosx[n2].textBox4.Text = pt.X.ToString();
					mio.listatrattosx[n2].textBox3.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
				}
				if (text.IndexOf("Tratto Dx :") >= 0)
				{
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3500);
					Point pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
					n2 = mio.trovaposizioneinlista(new TrattoDx(), n2);
					mio.listatrattodx[n2].textBox1.Text = pt.X.ToString();
					mio.listatrattodx[n2].textBox2.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
					Thread.Sleep(1500);
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3000);
					pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					mio.listatrattodx[n2].textBox4.Text = pt.X.ToString();
					mio.listatrattodx[n2].textBox3.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
				}
				if (text.IndexOf("Click 2x :") >= 0)
				{
					mio.pictureBox1.BackColor = Color.Red;
					Thread.Sleep(3500);
					Point pt = default;
					CursorPointClass.GetCursorPos(ref pt);
					int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
					n = mio.trovaposizioneinlista(new Clickx2(), n);
					mio.listaclick2x[n].textBox1.Text = pt.X.ToString();
					mio.listaclick2x[n].textBox2.Text = pt.Y.ToString();
					mio.pictureBox1.BackColor = Color.Green;
				}
			}
			mio.pictureBox1.BackColor = Color.Transparent;
		}
		catch (Exception)
		{
		}
	}

	public void inserisci()
	{
		try
		{
			string text = mio.listBox1.SelectedItem.ToString();
			if (text.IndexOf("Click Sx :") >= 0)
			{
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				mio.pictureBox1.BackColor = Color.Transparent;
				Point pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				n = mio.trovaposizioneinlista(new ClickSx(), n);
				mio.listaclicksx[n].textBox1.Text = pt.X.ToString();
				mio.listaclicksx[n].textBox2.Text = pt.Y.ToString();
			}
			if (text.IndexOf("Click Dx :") >= 0)
			{
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				mio.pictureBox1.BackColor = Color.Transparent;
				Point pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				n2 = mio.trovaposizioneinlista(new ClickDx(), n2);
				mio.listaclickdx[n2].textBox1.Text = pt.X.ToString();
				mio.listaclickdx[n2].textBox2.Text = pt.Y.ToString();
			}
			if (text.IndexOf("Tratto Sx :") >= 0)
			{
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				Point pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				n2 = mio.trovaposizioneinlista(new TrattoSx(), n2);
				mio.listatrattosx[n2].textBox1.Text = pt.X.ToString();
				mio.listatrattosx[n2].textBox2.Text = pt.Y.ToString();
				mio.pictureBox1.BackColor = Color.Green;
				Thread.Sleep(1500);
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				mio.pictureBox1.BackColor = Color.Transparent;
				pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				mio.listatrattosx[n2].textBox4.Text = pt.X.ToString();
				mio.listatrattosx[n2].textBox3.Text = pt.Y.ToString();
			}
			if (text.IndexOf("Tratto Dx :") >= 0)
			{
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				Point pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				int n2 = int.Parse(text.Substring(text.IndexOf(":") + 2));
				n2 = mio.trovaposizioneinlista(new TrattoDx(), n2);
				mio.listatrattodx[n2].textBox1.Text = pt.X.ToString();
				mio.listatrattodx[n2].textBox2.Text = pt.Y.ToString();
				mio.pictureBox1.BackColor = Color.Green;
				Thread.Sleep(1500);
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				mio.listatrattodx[n2].textBox4.Text = pt.X.ToString();
				mio.listatrattodx[n2].textBox3.Text = pt.Y.ToString();
			}
			if (text.IndexOf("Click 2x :") >= 0)
			{
				mio.pictureBox1.BackColor = Color.Red;
				Thread.Sleep(3000);
				mio.pictureBox1.BackColor = Color.Transparent;
				Point pt = default;
				CursorPointClass.GetCursorPos(ref pt);
				int n = int.Parse(text.Substring(text.IndexOf(":") + 2));
				n = mio.trovaposizioneinlista(new Clickx2(), n);
				mio.listaclick2x[n].textBox1.Text = pt.X.ToString();
				mio.listaclick2x[n].textBox2.Text = pt.Y.ToString();
			}
			mio.pictureBox1.BackColor = Color.Transparent;
		}
		catch (Exception)
		{
		}
	}

	public void partenza()
	{
		Thread.Sleep(5000);
		Point pt = default;
		CursorPointClass.GetCursorPos(ref pt);
		MessageBox.Show(pt.X + "  " + pt.Y);
	}
}
