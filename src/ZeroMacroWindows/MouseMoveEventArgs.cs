using System;

namespace ZeroMacroWindows;

public class MouseMoveEventArgs : EventArgs
{
	public readonly int X;

	public readonly int Y;

	public MouseMoveEventArgs(int X, int Y)
	{
		this.X = X;
		this.Y = Y;
	}
}
