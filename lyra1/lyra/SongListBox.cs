using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace lyra
{
	/// <summary>
	/// Summary description for SongListBox
	/// </summary>
	public class SongListBox : System.Windows.Forms.ListBox
	{
		[Category("Action")]
		public event ScrollEventHandler Scrolled = null;
		private int oldTopIndex = 0;
		
		public SongListBox()
		{
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.ItemHeight = 15;
			this.DrawItem += new DrawItemEventHandler(SongListBox_DrawItem);
		}

		private void SongListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			if(e.Index < this.Items.Count && e.Index >= 0)
			{		
				//e.DrawBackground();
				bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				e.Graphics.FillRectangle(selected ? Brushes.LightSteelBlue : Brushes.White, e.Bounds);
				Brush foreColBrush = new SolidBrush(e.ForeColor);
				object item = this.Items[e.Index];
				if(item is Song)
				{
					Song song = (Song) item;
					e.Graphics.DrawString(Util.toFour(song.Number), e.Font, Brushes.DimGray,
					                      new RectangleF(e.Bounds.X, e.Bounds.Y, 50, e.Bounds.Height));
					e.Graphics.DrawString(song.Title, new Font(e.Font, FontStyle.Bold), selected ? Brushes.Black : Brushes.DimGray,
					                      new RectangleF(e.Bounds.X + 50, e.Bounds.Y, e.Bounds.Width - 50, e.Bounds.Height));
				}
				else
				{
					e.Graphics.DrawString(item.ToString(), e.Font, foreColBrush, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
				}
				e.DrawFocusRectangle();
			}
			// scrolled?
			if(this.oldTopIndex != this.TopIndex)
			{
				ScrollEventArgs scrollArgs = new ScrollEventArgs(this.oldTopIndex > this.TopIndex ? 
					ScrollEventType.SmallDecrement : ScrollEventType.SmallIncrement, this.TopIndex);
				this.OnScroll(scrollArgs);
			}
			this.oldTopIndex = this.TopIndex;
		}

		public void OnScroll(ScrollEventArgs e)
		{
			if(this.Scrolled != null)
			{
				this.Scrolled(this, e);
			}
		}
	}
}
