using System;
using System.Drawing;
using System.Threading;

namespace lyra
{
	/// <summary>
	/// Summary description for Preview.
	/// </summary>
	public class Preview : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		
		private DelayedTask closingTask;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Song song;
		private GUI owner;
		
		private static Preview _this = null;
		private System.Windows.Forms.Button closeBtn;
		private bool autoClose = true;
		
		public static void ShowPreview(GUI owner, Song song, Point location)
		{
			if(_this != null)
			{
				if(_this.song == song)
				{
					return; // do nothing
				}
				if(!_this.IsDisposed)
				{
					_this.Close();
				}
				_this = null;
			}
		
			_this = new Preview(owner, song, location);
			_this.Show();
			_this.Focus();
		}
		
		public static void ClosePreview()
		{
			try
			{
				_this.Close();
			}
			catch(Exception)
			{
				// do nothing!
			}
		}

		private Preview(GUI owner, Song song, Point location)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.owner = owner;
			this.song = song;
			this.Location = location;
			this.label1.Text = song.Number.ToString();
			this.label2.Text = song.Title;
			this.label3.Text = this.getText(song.Text);
			this.LostFocus += new EventHandler(Preview_LostFocus);
			this.Closing += new System.ComponentModel.CancelEventHandler(Preview_Closing);
			this.GotFocus += new EventHandler(Preview_GotFocus);
			this.closeBtn.GotFocus += new EventHandler(closeBtn_GotFocus);
		}
		
		private string getText(string text)
		{
			string cleanedString = "";
			bool skip = false;
			int lines = 0;
			foreach(char c in text)
			{
				if(c == '<')
				{
					skip = true;
				}
				else if (c == '>')
				{
					skip = false;
				}
				else
				{
					if(!skip)
					{
						if (c == '\n')
						{
							lines++;			
						}
						cleanedString += c;
						if(lines >= 10)
						{
							cleanedString += Util.NL + "[...]";
							cleanedString = cleanedString.Replace("&lt;", "<").Replace("&gt;", ">");
							return cleanedString;
						}
					}
				}
			}
			cleanedString = cleanedString.Replace("&lt;", "<").Replace("&gt;", ">");
			return cleanedString;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.closeBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			this.label1.Click += new System.EventHandler(this.Preview_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.DarkBlue;
			this.label2.Location = new System.Drawing.Point(56, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(360, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "label1";
			this.label2.Click += new System.EventHandler(this.Preview_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(408, 216);
			this.label3.TabIndex = 1;
			this.label3.Text = "label3";
			this.label3.Click += new System.EventHandler(this.Preview_Click);
			// 
			// closeBtn
			// 
			this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.closeBtn.Location = new System.Drawing.Point(396, 4);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(19, 19);
			this.closeBtn.TabIndex = 2;
			this.closeBtn.Text = "x";
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// Preview
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(422, 246);
			this.ControlBox = false;
			this.Controls.Add(this.closeBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Preview";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Click += new System.EventHandler(this.Preview_Click);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void Preview_LostFocus(object sender, EventArgs e)
		{
			if(this.closingTask != null)
			{
				this.closingTask.Abort();
			}
			this.closingTask = new DelayedTask(new ThreadStart(this.Close), 3000);
			this.closingTask.Start();
		}
		
		private void Preview_Click(object sender, System.EventArgs e)
		{	
			//this.Close();
			if(this.closingTask != null)
			{
				this.closingTask.Abort();
			}
			this.BackColor = Color.FromArgb(0xee, 0xee, 0xee);
			this.autoClose = false;
		}

		private void Preview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.closingTask != null)
			{
				this.closingTask.Abort();
			}
			Preview._this = null;
		}

		private void Preview_GotFocus(object sender, EventArgs e)
		{
			if(this.closingTask != null && !this.autoClose)
			{
				this.closingTask.Abort();
			}
		}

		private void closeBtn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void closeBtn_GotFocus(object sender, EventArgs e)
		{
			if(this.closingTask != null && !this.autoClose)
			{
				this.closingTask.Abort();
			}
			this.Focus();
		}
	}
}
