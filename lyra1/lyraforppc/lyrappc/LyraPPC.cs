using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace lyrappc
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class LyraPPC : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		
		private ArrayList list = null;
		private System.Windows.Forms.MenuItem menuItem7;	

		public static string VERSION = "v.0.1";
		public static int BUILD = 1;
		public static string NAME = "lyra for Pocket PC";

		public LyraPPC()
		{
			InitializeComponent();
			this.panel2.Top = 72;
			this.label1.Text = LyraPPC.VERSION;
			this.Text = LyraPPC.NAME;

			string path;
			path = System.IO.Path.GetDirectoryName( 
				System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );

			FileStream fs = File.OpenRead(path + "\\data.lppc");
			StreamReader sr = new StreamReader(fs);
			
			string line = "";
			
			while ((line = sr.ReadLine()) != null && !line.StartsWith("####$SNAPSHOT")) {}
			this.menuItem7.Text = "[snapshot: " + sr.ReadLine() + "]";
			while ((line = sr.ReadLine()) != null && !line.StartsWith("####$COUNT")) {}
			int count = Int32.Parse(sr.ReadLine());
			this.list = new ArrayList(count);

			while ((line = sr.ReadLine()) != null && !line.StartsWith("####$DATA")) {}
			while ((line = sr.ReadLine()) != null)
			{
				try
				{
					string nrstr = line.Split(' ')[0];
					int nr = Int32.Parse(nrstr);
					string[] rest = line.Substring(nrstr.Length+1).Split('%');
					this.list.Add(new Song(nr,rest[0],rest[1]));
				}
				catch (Exception e) {}
			}
			sr.Close();
			fs.Close();
			this.displayList(this.list,new ShowAll());
		}

		private void displayList(ArrayList list, ISongFilter filter)
		{
			this.listBox1.Enabled = true;
			this.list.Sort(Song.getComparer());
			this.listBox1.Items.Clear();
			IEnumerator en = list.GetEnumerator();
			en.Reset();
			while(en.MoveNext())
			{
				if (filter.Show((Song)en.Current) == 0)
				{
					this.listBox1.Items.Add(en.Current);
				}
				else if (filter.Show((Song)en.Current) == 1) return;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LyraPPC));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem4);
			// 
			// menuItem4
			// 
			this.menuItem4.MenuItems.Add(this.menuItem6);
			this.menuItem4.MenuItems.Add(this.menuItem7);
			this.menuItem4.Text = "?";
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "lyra for Pocket PC (c) 2005 og";
			// 
			// menuItem7
			// 
			this.menuItem7.Text = "snapshot version";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(200, 56);
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.Text = "v 0.1";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Size = new System.Drawing.Size(184, 80);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(136, 8);
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.Text = "beta";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 96);
			this.textBox1.MaxLength = 4;
			this.textBox1.Size = new System.Drawing.Size(119, 20);
			this.textBox1.Text = "0000";
			this.textBox1.GotFocus += new System.EventHandler(this.textBox1_Clicked);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(208, 77);
			this.button1.Size = new System.Drawing.Size(16, 64);
			this.button1.Text = "v";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(8, 72);
			this.radioButton1.Size = new System.Drawing.Size(48, 24);
			this.radioButton1.Text = "alle";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 96);
			this.radioButton2.Size = new System.Drawing.Size(72, 24);
			this.radioButton2.Text = "Nummer";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 120);
			this.radioButton3.Size = new System.Drawing.Size(72, 24);
			this.radioButton3.Text = "Suche";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(80, 120);
			this.textBox2.Size = new System.Drawing.Size(119, 20);
			this.textBox2.Text = "keyword";
			this.textBox2.GotFocus += new System.EventHandler(this.textBox2_Clicked);
			// 
			// listBox1
			// 
			this.listBox1.ContextMenu = this.contextMenu1;
			this.listBox1.Location = new System.Drawing.Point(8, 152);
			this.listBox1.Size = new System.Drawing.Size(216, 106);
			this.listBox1.GotFocus += new System.EventHandler(this.listBox1_GotFocus);
			this.listBox1.LostFocus += new System.EventHandler(this.listBox1_LostFocus);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.Add(this.menuItem5);
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "Details...";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "";
			// 
			// menuItem2
			// 
			this.menuItem2.MenuItems.Add(this.menuItem3);
			this.menuItem2.Text = "Song";
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Details...";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.radioButton2);
			this.panel1.Controls.Add(this.radioButton3);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.listBox1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Size = new System.Drawing.Size(240, 280);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.LightGray;
			this.panel2.Controls.Add(this.textBox4);
			this.panel2.Controls.Add(this.textBox3);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Location = new System.Drawing.Point(0, 280);
			this.panel2.Size = new System.Drawing.Size(240, 200);
			this.panel2.Visible = false;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 90);
			this.textBox4.Multiline = true;
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(216, 56);
			this.textBox4.Text = "textBox4";
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.Window;
			this.textBox3.Location = new System.Drawing.Point(40, 43);
			this.textBox3.Multiline = true;
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(184, 40);
			this.textBox3.Text = "textBox3";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(160, 153);
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.Text = "zurück";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.Text = "Nr:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.label3.ForeColor = System.Drawing.Color.SteelBlue;
			this.label3.Size = new System.Drawing.Size(160, 24);
			this.label3.Text = "Details...";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(8, 43);
			this.label5.Size = new System.Drawing.Size(32, 32);
			this.label5.Text = "Titel:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label8.ForeColor = System.Drawing.Color.SteelBlue;
			this.label8.Location = new System.Drawing.Point(40, 24);
			this.label8.Size = new System.Drawing.Size(184, 16);
			this.label8.Text = "Liednummer:";
			// 
			// LyraPPC
			// 
			this.ClientSize = new System.Drawing.Size(234, 542);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Menu = this.mainMenu1;
			this.Text = "lyra for Pocket PC";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new LyraPPC());
		}

		// change text in "Nummer"
		private void textBox1_Clicked(object sender, System.EventArgs e)
		{
			this.radioButton2.Checked = true;
			this.radioButton1.Checked = this.radioButton3.Checked = false;
			this.textBox1.Text = "";
		}

		// change text in "Suche"
		private void textBox2_Clicked(object sender, System.EventArgs e)
		{
			this.radioButton3.Checked = true;
			this.radioButton1.Checked = this.radioButton2.Checked = false;
		}


		// show
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.panel1.Enabled = false;
			if (this.radioButton1.Checked)
			{
				this.displayList(this.list, new ShowAll());
			}
			else if (this.radioButton2.Checked)
			{
				try
				{
					int nr = Int32.Parse(this.textBox1.Text);
					this.displayList(this.list, new ShowNr(nr));
					if (this.listBox1.Items.Count == 0)
					{
						this.listBox1.Items.Add("Lied nicht vorhanden!");
						this.listBox1.Enabled = false;
					}
				}
				catch (Exception)
				{
					this.listBox1.Items.Clear();
					this.listBox1.Items.Add("Fehler! Nur Zahlen eingeben.");
					this.listBox1.Enabled = false;
					this.textBox1.Text = "0000";
					this.radioButton1.Checked = true;
					this.radioButton2.Checked = this.radioButton3.Checked = false;
				}	
			}
			else
			{
				this.displayList(this.list,new ShowQuery(this.textBox2.Text));
				if (this.listBox1.Items.Count == 0)
				{
					this.listBox1.Items.Add("Keine Ergebnisse!");
					this.listBox1.Enabled = false;
				}
			}
			this.panel1.Enabled = true;
		}

		// listBox selected
		private void listBox1_GotFocus(object sender, EventArgs e)
		{
			this.mainMenu1.MenuItems.Clear();
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			this.mainMenu1.MenuItems.Add(this.menuItem4);
		}

		private void listBox1_LostFocus(object sender, EventArgs e)
		{
			this.mainMenu1.MenuItems.Clear();
			this.listBox1.SelectedIndex = -1;
			this.mainMenu1.MenuItems.Add(this.menuItem4);
		}

		// hide panel2
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.panel2.Visible = false;
		}

		// details...
		private void menuItem3_Click(object sender, EventArgs e)
		{
			Song song = (Song)this.listBox1.SelectedItem;
			this.label8.Text = song.Nummer.ToString();
			this.textBox3.Text = song.Titel;
			this.textBox4.Text = song.Text;
			this.panel2.Visible = true;
			this.panel2.Focus();
		}

		// contextmenu
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.menuItem3_Click(sender,e);
		}
	}
}
