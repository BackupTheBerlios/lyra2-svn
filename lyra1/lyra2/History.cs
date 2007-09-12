using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace lyra2
{
	/// <summary>
	/// Summary description for History.
	/// </summary>
	public class History : System.Windows.Forms.Form
	{
		private SongListBox listBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private GUI owner = null;

		private static History _this = null;
		
		public static void ShowHistory(GUI owner)
		{
			if(_this == null)
			{
				_this = new History(owner);
			}
			_this.Show();
			_this.Focus();
		}
		
		public static void ForceFocus()
		{
			if(_this != null)
			{
				_this.Focus();
			}
		}
		
		private EventHandler changedHandler;
		
		private History(GUI owner)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.changedHandler = new EventHandler(View_HistoryChanged);
			View.HistoryChanged += this.changedHandler;
			this.Closing += new CancelEventHandler(History_Closing);
			this.Load += new EventHandler(History_Load);
			this.owner = owner;
			this.loadHistory();
			this.listBox3.Scrolled +=new ScrollEventHandler(listBox3_Scrolled);
			this.Move += new EventHandler(History_Move);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox3 = new SongListBox();
			this.SuspendLayout();
			// 
			// listBox3
			// 
			this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox3.Location = new System.Drawing.Point(0, 0);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(376, 316);
			this.listBox3.TabIndex = 6;
			this.listBox3.DoubleClick += new System.EventHandler(this.listBox3_DoubleClick);
			this.listBox3.SelectedValueChanged += new System.EventHandler(this.listBox3_SelectedValueChanged);
			// 
			// History
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 318);
			this.Controls.Add(this.listBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "History";
			this.ShowInTaskbar = false;
			this.Text = "History";
			this.ResumeLayout(false);

		}
		#endregion

		private void View_HistoryChanged(object sender, EventArgs e)
		{
			this.loadHistory();
		}

		private void History_Closing(object sender, CancelEventArgs e)
		{
			View.HistoryChanged -= this.changedHandler;
			History._this = null;
			Preview.ClosePreview();
		}
		
		private void loadHistory()
		{
			this.listBox3.BeginUpdate();
			this.listBox3.Items.Clear();
			foreach(Song s in View.SongHistory)
			{
				this.listBox3.Items.Insert(0, s);
			}
			if(this.listBox3.Items.Count == 0)
			{
				this.listBox3.Items.Add("Es sind noch keine Lieder geöffnet worden!");
			}
			this.listBox3.EndUpdate();
		}

		private void listBox3_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.listBox3.SelectedItem is Song)
			{
				View.ShowSong((Song) this.listBox3.SelectedItem, this.owner, this.listBox3);
			}
		}

		private void listBox3_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(Util.SHOW_PREVIEW)
			{
				Song s = this.listBox3.SelectedItem as Song;
				if(s != null)
				{
					Rectangle rect = this.listBox3.GetItemRectangle(this.listBox3.SelectedIndex);
					Point location = this.listBox3.PointToScreen(new Point(rect.Left, rect.Top));
					location.X += this.listBox3.Width - 25;
					//location.Y += rect.Height + 2;
					Preview.ShowPreview(this.owner, s, getBestLocationForPreview(location));
					this.listBox3.Focus();
				}
			}
		}

		private void History_Load(object sender, EventArgs e)
		{
			Preview.ClosePreview();
		}

		private void listBox3_Scrolled(object sender, ScrollEventArgs e)
		{
			Preview.ClosePreview();
		}
		
		private Point getBestLocationForPreview(Point itemLocation)
		{
			Screen currentScreen = Screen.FromControl(this);
			if(itemLocation.X + 424 < currentScreen.Bounds.Width)
			{
				if(itemLocation.Y + 248 >= currentScreen.Bounds.Height)
				{
					itemLocation.Y = currentScreen.Bounds.Height - 249;
				}
			}
			else
			{
				if(itemLocation.Y + 248 < currentScreen.Bounds.Height)
				{
					itemLocation.X = currentScreen.Bounds.Width - 425;
				}
				else
				{
					itemLocation.X = currentScreen.Bounds.Width - 425;
					itemLocation.Y = currentScreen.Bounds.Height - 249;
				}
			}
			return itemLocation;
		}

		private void History_Move(object sender, EventArgs e)
		{
			Preview.ClosePreview();
		}
	}
}
