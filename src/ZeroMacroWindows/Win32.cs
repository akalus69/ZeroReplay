using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZeroMacroWindows;

public static class Win32
{
	public const int KEYEVENTF_KEYUP = 2;

	public const uint VK_F6 = 117u;

	public const uint VK_ESCAPE = 27u;

	public const uint VK_RETURN = 13u;

	public const uint VK_ALT = 18u;

	public const uint VK_TAB = 9u;

	public const uint VK_CTRL = 17u;

	public const uint VK_SPACE = 32u;

	public const uint VK_SU = 38u;

	public const uint VK_GIU = 40u;

	public const uint VK_DESTRA = 39u;

	public const uint VK_SINISTRA = 37u;

	public const uint VK_DELETE = 46u;

	public const uint VK_PUNTO = 190u;

	public const uint VK_EACC = 186u;

	public const uint VK_SOMMA = 187u;

	public const uint VK_VIR = 188u;

	public const uint VK_DIFF = 189u;

	public const uint VK_UACC = 191u;

	public const uint VK_OACC = 192u;

	public const uint VK_ACC = 219u;

	public const uint VK_SLASH = 220u;

	public const uint VK_IACC = 221u;

	public const uint VK_AACC = 222u;

	public const uint VK_MIN = 223u;

	public const uint VK_ALTGR = 165u;

	public const uint VK_0 = 48u;

	public const uint VK_1 = 49u;

	public const uint VK_2 = 50u;

	public const uint VK_3 = 51u;

	public const uint VK_4 = 52u;

	public const uint VK_5 = 53u;

	public const uint VK_6 = 54u;

	public const uint VK_7 = 55u;

	public const uint VK_8 = 56u;

	public const uint VK_9 = 57u;

	public const uint VK_A = 65u;

	public const uint VK_B = 66u;

	public const uint VK_C = 67u;

	public const uint VK_D = 68u;

	public const uint VK_E = 69u;

	public const uint VK_F = 70u;

	public const uint VK_G = 71u;

	public const uint VK_H = 72u;

	public const uint VK_I = 73u;

	public const uint VK_J = 74u;

	public const uint VK_K = 75u;

	public const uint VK_L = 76u;

	public const uint VK_M = 77u;

	public const uint VK_N = 78u;

	public const uint VK_O = 79u;

	public const uint VK_P = 80u;

	public const uint VK_Q = 81u;

	public const uint VK_R = 82u;

	public const uint VK_S = 83u;

	public const uint VK_T = 84u;

	public const uint VK_U = 85u;

	public const uint VK_V = 86u;

	public const uint VK_W = 87u;

	public const uint VK_X = 88u;

	public const uint VK_Y = 89u;

	public const uint VK_Z = 90u;

	public const uint VK_SHIFT = 16u;

	public const uint WM_KEYDOWN = 256u;

	public const uint WM_KEYUP = 257u;

	[DllImport("user32.dll")]
	public static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetWindowTextLength(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

	[DllImport("user32.dll")]
	public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll", SetLastError = true)]
		public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

		public const int WM_HOTKEY = 786;

		public const uint MOD_ALT = 1u;

		public const uint MOD_CONTROL = 2u;

		public const uint MOD_SHIFT = 4u;

		public const uint MOD_WIN = 8u;

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
	}
