using System;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class MouseButtonEventArgs : EventArgs
{
	public readonly MouseButtons Button;

	public readonly MouseButtonState buttonState;

	public MouseButtonEventArgs(MouseButtons Button, MouseButtonState buttonState)
	{
		this.Button = Button;
		this.buttonState = buttonState;
	}
}
