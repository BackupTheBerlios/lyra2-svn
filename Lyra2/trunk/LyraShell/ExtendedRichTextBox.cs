using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
	/// <summary>
	/// This is a hack to get a nice transparent RichTextBox
	/// </summary>
	public class ExtendedRichTextBox : RichTextBox
	{
		
		#region Transparency
		
		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		static extern IntPtr LoadLibrary(string lpFileName);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams prams = base.CreateParams;
				if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
				{
					prams.ExStyle |= 0x020; // transparent
					prams.ClassName = "RICHEDIT50W";
				}
				return prams;
			}
		}
		
		#endregion Transparency

		#region Scrolling
		
		// import user32 SendMessage function
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
		private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// msg HSCROLL | VSCROLL
		private const int WM_VSCROLL = 0x115;
		private const int WM_HSCROLL = 0x114;

		// params VSCROLL
		private readonly IntPtr SB_LINEUP = new IntPtr(0);
		private readonly IntPtr SB_LINEDOWN = new IntPtr(1);
		private readonly IntPtr SB_PAGEUP = new IntPtr(2);
		private readonly IntPtr SB_PAGEDOWN = new IntPtr(3);
		private readonly IntPtr SB_TOP = new IntPtr(6);
		private readonly IntPtr SB_BOTTOM = new IntPtr(7);
		
		// params HSCROLL
		private readonly IntPtr SB_LINELEFT = new IntPtr(0);
		private readonly IntPtr SB_LINERIGHT = new IntPtr(1);
		private readonly IntPtr SB_PAGELEFT = new IntPtr(2);
		private readonly IntPtr SB_PAGERIGHT = new IntPtr(3);
		private readonly IntPtr SB_LEFT = new IntPtr(6);
		private readonly IntPtr SB_RIGHT = new IntPtr(7);

		public void ScrollDown()
		{
			SendMessage(new HandleRef(this, this.Handle), WM_VSCROLL, SB_LINEDOWN, IntPtr.Zero);
		}

		public void ScrollUp()
		{
			SendMessage(new HandleRef(this, this.Handle), WM_VSCROLL, SB_LINEUP, IntPtr.Zero);
		}
		
		public void ScrollPageDown()
		{
			SendMessage(new HandleRef(this, this.Handle), WM_VSCROLL, SB_PAGEDOWN, IntPtr.Zero);
		}

		public void ScrollPageUp()
		{
			SendMessage(new HandleRef(this, this.Handle), WM_VSCROLL, SB_PAGEUP, IntPtr.Zero);
		}
		
		public void ScrollToTop()
		{
			SendMessage(new HandleRef(this, this.Handle), WM_VSCROLL, SB_TOP, IntPtr.Zero);
		}

		public void ScrollToBottom()
		{
			SendMessage(new HandleRef(this, this.Handle), WM_VSCROLL, SB_BOTTOM, IntPtr.Zero);
		}

		#endregion Scrolling
	}
}