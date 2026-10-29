using System.Runtime.InteropServices;

namespace ZeroMacroWindows;

internal class Keylog
{
	[DllImport("user32.dll")]
	public static extern short GetAsyncKeyState(int vKey);
}
