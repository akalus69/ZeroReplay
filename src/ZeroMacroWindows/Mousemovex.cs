using System.Runtime.InteropServices;

namespace ZeroMacroWindows;

internal class Mousemovex
{
	[DllImport("user32", CharSet = CharSet.Auto)]
	public static extern int SetCursorPos(int h, int x);

	public int movex(int x, int y)
	{
		SetCursorPos(x, y);
		return 1;
	}
}
