using System;
using System.ComponentModel;
using System.Windows.Forms;
using Lyra2.UtilShared;

namespace Lyra2.LyraShell
{
	/// <summary>
	/// Summary description for RemoteControl.
	/// </summary>
	public class RemoteControl : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private GUI owner = null;
		private Button previousSongBtn;
		private Button nextSongBtn;
		private Button scrollUpBtn;
		private Button scrollDownBtn;
		private Button scrollToTopBtn;
		private Button scrollToBottomBtn;

		private static RemoteControl _this = null;

		public static void ShowRemoteControl(GUI owner)
		{
			if (_this == null)
			{
				_this = new RemoteControl(owner);
                LoadPersonalizationSettings(owner.Personalizer);
			}
			_this.Show();
			_this.Focus();
		}

		public static void ForceFocus()
		{
			if (_this != null)
			{
				_this.Focus();
			}
		}

		private RemoteControl(GUI owner)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
			this.owner = owner;
			this.Closing += new CancelEventHandler(RemoteControl_Closing);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RemoteControl));
			this.previousSongBtn = new System.Windows.Forms.Button();
			this.nextSongBtn = new System.Windows.Forms.Button();
			this.scrollUpBtn = new System.Windows.Forms.Button();
			this.scrollDownBtn = new System.Windows.Forms.Button();
			this.scrollToTopBtn = new System.Windows.Forms.Button();
			this.scrollToBottomBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// previousSongBtn
			// 
			this.previousSongBtn.BackColor = System.Drawing.Color.WhiteSmoke;
			this.previousSongBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.previousSongBtn.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.previousSongBtn.ForeColor = System.Drawing.Color.DimGray;
			this.previousSongBtn.Location = new System.Drawing.Point(5, 58);
			this.previousSongBtn.Name = "previousSongBtn";
			this.previousSongBtn.Size = new System.Drawing.Size(32, 40);
			this.previousSongBtn.TabIndex = 0;
			this.previousSongBtn.Text = "<<";
			this.previousSongBtn.Click += new System.EventHandler(this.previousSongBtn_Click);
			// 
			// nextSongBtn
			// 
			this.nextSongBtn.BackColor = System.Drawing.Color.WhiteSmoke;
			this.nextSongBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.nextSongBtn.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nextSongBtn.ForeColor = System.Drawing.Color.DimGray;
			this.nextSongBtn.Location = new System.Drawing.Point(77, 58);
			this.nextSongBtn.Name = "nextSongBtn";
			this.nextSongBtn.Size = new System.Drawing.Size(32, 40);
			this.nextSongBtn.TabIndex = 0;
			this.nextSongBtn.Text = ">>";
			this.nextSongBtn.Click += new System.EventHandler(this.nextSongBtn_Click);
			// 
			// scrollUpBtn
			// 
			this.scrollUpBtn.BackColor = System.Drawing.Color.Gainsboro;
			this.scrollUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.scrollUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("scrollUpBtn.Image")));
			this.scrollUpBtn.Location = new System.Drawing.Point(45, 34);
			this.scrollUpBtn.Name = "scrollUpBtn";
			this.scrollUpBtn.Size = new System.Drawing.Size(24, 37);
			this.scrollUpBtn.TabIndex = 10;
			this.scrollUpBtn.Click += new System.EventHandler(this.scrollUpBtn_Click);
			// 
			// scrollDownBtn
			// 
			this.scrollDownBtn.BackColor = System.Drawing.Color.Gainsboro;
			this.scrollDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.scrollDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("scrollDownBtn.Image")));
			this.scrollDownBtn.Location = new System.Drawing.Point(45, 82);
			this.scrollDownBtn.Name = "scrollDownBtn";
			this.scrollDownBtn.Size = new System.Drawing.Size(24, 37);
			this.scrollDownBtn.TabIndex = 9;
			this.scrollDownBtn.Click += new System.EventHandler(this.scrollDownBtn_Click);
			// 
			// scrollToTopBtn
			// 
			this.scrollToTopBtn.BackColor = System.Drawing.Color.DarkGray;
			this.scrollToTopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.scrollToTopBtn.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.scrollToTopBtn.Location = new System.Drawing.Point(45, 6);
			this.scrollToTopBtn.Name = "scrollToTopBtn";
			this.scrollToTopBtn.Size = new System.Drawing.Size(24, 24);
			this.scrollToTopBtn.TabIndex = 0;
			this.scrollToTopBtn.Text = "=";
			this.scrollToTopBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.scrollToTopBtn.Click += new System.EventHandler(this.scrollToTopBtn_Click);
			// 
			// scrollToBottomBtn
			// 
			this.scrollToBottomBtn.BackColor = System.Drawing.Color.DarkGray;
			this.scrollToBottomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.scrollToBottomBtn.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.scrollToBottomBtn.Location = new System.Drawing.Point(45, 123);
			this.scrollToBottomBtn.Name = "scrollToBottomBtn";
			this.scrollToBottomBtn.Size = new System.Drawing.Size(24, 24);
			this.scrollToBottomBtn.TabIndex = 0;
			this.scrollToBottomBtn.Text = "=";
			this.scrollToBottomBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.scrollToBottomBtn.Click += new System.EventHandler(this.scrollToEndBtn_Click);
			// 
			// RemoteControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Navy;
			this.ClientSize = new System.Drawing.Size(114, 157);
			this.Controls.Add(this.previousSongBtn);
			this.Controls.Add(this.nextSongBtn);
			this.Controls.Add(this.scrollToBottomBtn);
			this.Controls.Add(this.scrollToTopBtn);
			this.Controls.Add(this.scrollUpBtn);
			this.Controls.Add(this.scrollDownBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RemoteControl";
			this.Opacity = 0.75;
			this.ShowInTaskbar = false;
			this.Text = "Fernsteuerung";
			this.ResumeLayout(false);

		}

		#endregion

		private void RemoteControl_Closing(object sender, CancelEventArgs e)
		{
            StorePersonalizationSettings(owner.Personalizer, false);
			_this = null;
		}

		private void scrollUpBtn_Click(object sender, EventArgs e)
		{
			View.ExecuteActionOnView(View.ViewActions.ScrollUp);
		}

		private void nextSongBtn_Click(object sender, EventArgs e)
		{
			View.ExecuteActionOnView(View.ViewActions.NextSong);
		}

		private void previousSongBtn_Click(object sender, EventArgs e)
		{
			View.ExecuteActionOnView(View.ViewActions.PreviewsSong);
		}

		private void scrollDownBtn_Click(object sender, EventArgs e)
		{
			View.ExecuteActionOnView(View.ViewActions.ScrollDown);	
		}

		private void scrollToTopBtn_Click(object sender, EventArgs e)
		{
			View.ExecuteActionOnView(View.ViewActions.ScrollToTop);
		}

		private void scrollToEndBtn_Click(object sender, EventArgs e)
		{
			View.ExecuteActionOnView(View.ViewActions.ScrollToEnd);
		}

//		private void scrollPageUpBtn_Click(object sender, System.EventArgs e)
//		{
//			View.ExecuteActionOnView(View.ViewActions.ScrollPageUp);
//		}
//
//		private void scrollPageDownBtn_Click(object sender, System.EventArgs e)
//		{
//			View.ExecuteActionOnView(View.ViewActions.ScrollPageDown);
//		}
		
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.F3)
			{
				Util.OpenFile(0);
			}
			else if (keyData == Keys.F4)
			{
				Util.OpenFile(1);
			}
			else if (keyData == Keys.F5)
			{
				Util.OpenFile(2);
			}
			else if (keyData == Keys.F6)
			{
				Util.OpenFile(3);
			}
			else if (keyData == Keys.F7)
			{
				Util.OpenFile(4);
			}
			else if (keyData == Keys.F8)
			{
				Util.OpenFile(5);
			}
			return base.ProcessCmdKey (ref msg, keyData);
		}


        public static void StorePersonalizationSettings(Personalizer personalizer, bool shown)
        {
            if (_this != null)
            {
                personalizer[PersonalizationItemNames.RemoteTop] = _this.Top.ToString();
                personalizer[PersonalizationItemNames.RemoteLeft] = _this.Left.ToString();
                personalizer[PersonalizationItemNames.RemoteWidth] = _this.Width.ToString();
                personalizer[PersonalizationItemNames.RemoteHeight] = _this.Height.ToString();
                personalizer[PersonalizationItemNames.RemoteIsShown] = shown ? "1" : "0";
                personalizer.Write();
            }
        }

        private static void LoadPersonalizationSettings(Personalizer personalizer)
        {
            if (_this != null)
            {
                personalizer.Load();
                int top = personalizer.GetIntValue(PersonalizationItemNames.RemoteTop);
                if (top > 0) _this.Top = top;
                int left = personalizer.GetIntValue(PersonalizationItemNames.RemoteLeft);
                if (left > 0) _this.Left = left;
                int width = personalizer.GetIntValue(PersonalizationItemNames.RemoteWidth);
                if (width > 0) _this.Width = width;
                int height = personalizer.GetIntValue(PersonalizationItemNames.RemoteHeight);
                if (height > 0) _this.Height = height;

                personalizer[PersonalizationItemNames.RemoteIsShown] = "1";
                personalizer.Write();
            }
        }
	}
}