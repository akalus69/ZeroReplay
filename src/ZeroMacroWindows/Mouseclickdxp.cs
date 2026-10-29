using System.Runtime.InteropServices;

namespace ZeroMacroWindows;

internal class Mouseclickdxp
{
	[DllImport("user32", CharSet = CharSet.Auto)]
	public static extern void mouse_event(int h, int x, int p, int c, int z);

	public int clickx(int x, int y)
	{
		mouse_event(8, x, y, 0, 0);
		return 1;
	}
}
