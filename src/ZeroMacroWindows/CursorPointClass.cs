using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ZeroMacroWindows;

internal class CursorPointClass
{
	[DllImport("user32.dll")]
	public static extern IntPtr GetCursorPos(ref Point pt);
}
