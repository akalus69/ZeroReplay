using System;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class KeyPressEventArgs : EventArgs
{
	private string cod = "";

	public readonly Keys ModifierKeys;

	public readonly int KeyCode;

	public KeyPressEventArgs(Keys ModifierKeys, int KeyCode)
	{
		this.ModifierKeys = ModifierKeys;
		this.KeyCode = KeyCode;
		cod = Enum.GetName(typeof(Keys), KeyCode);
	}
}
