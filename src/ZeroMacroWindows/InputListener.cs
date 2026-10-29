using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ZeroMacroWindows;

public class InputListener
{
	public delegate void MouseMoveHandler(object inputListener, MouseMoveEventArgs mouseMoveInfo);

	public delegate void MouseButtonHandler(object inputListener, MouseButtonEventArgs mouseButtonInfo);

	public delegate void KeyPressHandler(object inputListener, KeyPressEventArgs KeyPressInfo);

	private Thread thdMain;

	public int attesa = 0;

	public bool vai = true;

	private int lastX = 0;

	private int lastY = 0;

	private MouseButtons lastButton = MouseButtons.None;

	public event MouseMoveHandler OnMouseMove;

	public event MouseButtonHandler OnMouseButton;

	public event KeyPressHandler OnKeyPress;

	[DllImport("user32.dll")]
	public static extern int GetAsyncKeyState(long vKey);

	public void Run()
	{
		thdMain = new Thread(RunThread);
		thdMain.Start();
	}

	public void Kill()
	{
		try
		{
			thdMain.Abort();
		}
		catch (Exception)
		{
		}
	}

	private void RunThread()
	{
		while (vai)
		{
			if (lastX != Control.MousePosition.X || lastY != Control.MousePosition.Y)
			{
				lastX = Control.MousePosition.X;
				lastY = Control.MousePosition.Y;
				MouseMoveEventArgs mouseMoveInfo = new MouseMoveEventArgs(lastX, lastY);
				if (OnMouseMove != null)
				{
					OnMouseMove(this, mouseMoveInfo);
				}
				attesa = 0;
			}
			if (lastButton != Control.MouseButtons)
			{
				attesa = 0;
				if (Control.MouseButtons == MouseButtons.None)
				{
					MouseButtonEventArgs mouseButtonInfo = new MouseButtonEventArgs(lastButton, MouseButtonState.Released);
					if (OnMouseButton != null)
					{
						OnMouseButton(this, mouseButtonInfo);
					}
				}
				else
				{
					MouseButtonEventArgs mouseButtonInfo = new MouseButtonEventArgs(Control.MouseButtons, MouseButtonState.Pressed);
					if (OnMouseButton != null)
					{
						OnMouseButton(this, mouseButtonInfo);
					}
				}
				lastButton = Control.MouseButtons;
			}
			int num = 0;
			for (num = 1; num < 255; num++)
			{
				if (GetAsyncKeyState(num) == -32767)
				{
					KeyPressEventArgs keyPressInfo = new KeyPressEventArgs(Control.ModifierKeys, num);
					if (OnKeyPress != null)
					{
						OnKeyPress(this, keyPressInfo);
					}
				}
			}
			attesa += 10;
			Thread.Sleep(10);
		}
	}
}
