using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace lyra
{
	/// <summary>
	/// Zusammendfassende Beschreibung für GUI.
	/// </summary>
	public class GUI : System.Windows.Forms.Form
	{
		#region Designervariablen

		/// <summary>
		/// Erforderliche Designervariablen.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private SongListBox listBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private SongListBox listBox2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ComboBox comboBox1;
		private SearchTextBox textBox1;
		private System.Windows.Forms.Button button7;
		private SearchTextBox textBox2;
		private SongListBox listBox3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button button9;
		private SearchTextBox textBox3;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem menuItem47;
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuItem50;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem52;
		private System.Windows.Forms.MenuItem menuItem53;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem menuItem55;
		private System.Windows.Forms.MenuItem menuItem56;
		private System.Windows.Forms.MenuItem menuItem57;
		private System.Windows.Forms.MenuItem menuItem58;
		private System.Windows.Forms.MenuItem menuItem59;
		private System.Windows.Forms.MenuItem menuItem60;
		private System.Windows.Forms.MenuItem menuItem61;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;

		#endregion

		/// <summary>
		/// my variables
		/// </summary>
		private IStorage storage = null;
		public int curItem = -1;
		private PLists persLists;
		private System.Windows.Forms.MenuItem menuItem62;
		private System.Windows.Forms.MenuItem menuItem63;
		private System.Windows.Forms.MenuItem menuItem64;
		private System.Windows.Forms.Label label4;
		private DelayedTask searchTask;

		public ListBox StandardNavigate
		{
			get { return this.listBox1; }
		}

		public GUI()
		{
			InitializeComponent();
			base.Text = Util.GUINAME;
			Util.init();
			if(Screen.AllScreens.Length == 1)
			{
				this.menuItem54.Enabled = false;
			}
			else 
			{
				if(Util.SCREEN_ID == 0)
				{
					this.menuItem55.Checked = true;
				}
				else
				{
					this.menuItem56.Checked = true;
				}
			}
			
			if (Util.SHOWBUILDNEWS)
				(new Frst()).Show();

			this.Height = GUI.DEBUG ? 343 : 343 - this.statusBar1.Height;
			this.statusBar1.Visible = GUI.DEBUG;
			this.statusBarPanel1.Text = "ok";
			this.statusBarPanel2.Text = Util.URL;
			// (new Thread(new ThreadStart(this.Initialize))).Start();
		    this.Initialize();
			// debug console
			if (GUI.DEBUG)
			{
				DebugConsole.ShowDebugConsole(this);
				this.menuItem29.Visible = true;
				this.menuItem32.Visible = true;
			}
			
		}


		private void Initialize()
		{
            this.menuItem41.Enabled = File.Exists(Util.BASEURL + "\\" + Util.URL + ".bac");
            this.menuItem60.Checked = Util.SHOW_PREVIEW;
            this.listBox1.MouseDown += new MouseEventHandler(this.listBox1_click);
            this.listBox3.MouseDown += new MouseEventHandler(this.listBox3_click);
            this.GotFocus += new EventHandler(GUI_GotFocus);
            this.listBox1.Scrolled += new ScrollEventHandler(listBox_Scrolled);
            this.listBox2.Scrolled += new ScrollEventHandler(listBox_Scrolled);
            this.listBox3.Scrolled += new ScrollEventHandler(listBox_Scrolled);

            foreach (MenuItem item in mainMenu1.MenuItems)
            {
                item.Popup += new EventHandler(item_Popup);
            }

            this.contextMenu1.Popup += new EventHandler(contextMenu_Popup);
            this.contextMenu2.Popup += new EventHandler(contextMenu_Popup);
            this.Move += new EventHandler(GUI_Move);
			this.storage = new Storage(Util.URL, this);
			this.storage.displaySongs(this.listBox1);
			this.WindowState = FormWindowState.Normal;
			Song.owner = this;
			this.persLists = new PLists(this.comboBox1, this.storage);
			if (this.comboBox1.Items.Count > 0)
			{
				this.comboBox1.SelectedIndex = 0;
			}
			else
			{
				this.menuItem7.Visible = false;
			}
			this.menuItem10.Visible = false;
			this.Deactivate += new EventHandler(this.DeactivateMe);
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			Util.storeStats();
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
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GUI));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.textBox2 = new lyra.SearchTextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox1 = new lyra.SearchTextBox();
			this.listBox3 = new lyra.SongListBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button9 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.listBox1 = new lyra.SongListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new lyra.SearchTextBox();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.listBox2 = new lyra.SongListBox();
			this.button5 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem51 = new System.Windows.Forms.MenuItem();
			this.menuItem52 = new System.Windows.Forms.MenuItem();
			this.menuItem53 = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuItem63 = new System.Windows.Forms.MenuItem();
			this.menuItem64 = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem41 = new System.Windows.Forms.MenuItem();
			this.menuItem45 = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.menuItem49 = new System.Windows.Forms.MenuItem();
			this.menuItem50 = new System.Windows.Forms.MenuItem();
			this.menuItem43 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem46 = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.menuItem47 = new System.Windows.Forms.MenuItem();
			this.menuItem48 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem57 = new System.Windows.Forms.MenuItem();
			this.menuItem59 = new System.Windows.Forms.MenuItem();
			this.menuItem60 = new System.Windows.Forms.MenuItem();
			this.menuItem58 = new System.Windows.Forms.MenuItem();
			this.menuItem54 = new System.Windows.Forms.MenuItem();
			this.menuItem55 = new System.Windows.Forms.MenuItem();
			this.menuItem56 = new System.Windows.Forms.MenuItem();
			this.menuItem61 = new System.Windows.Forms.MenuItem();
			this.menuItem62 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem39 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.contextMenu2 = new System.Windows.Forms.ContextMenu();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(599, 272);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.pictureBox4);
			this.tabPage2.Controls.Add(this.pictureBox3);
			this.tabPage2.Controls.Add(this.textBox2);
			this.tabPage2.Controls.Add(this.button7);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Controls.Add(this.listBox3);
			this.tabPage2.Controls.Add(this.checkBox3);
			this.tabPage2.Controls.Add(this.checkBox1);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.pictureBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(591, 246);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Suche";
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
			this.label4.Location = new System.Drawing.Point(7, 232);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(472, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "Suchergebnisse könnten fehlerhaft sein. Bitte Änderungen übernehmen!";
			this.label4.Visible = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(403, 8);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(22, 22);
			this.pictureBox4.TabIndex = 12;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Click += new System.EventHandler(this.button8_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(486, 138);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(96, 96);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 11;
			this.pictureBox3.TabStop = false;
			// 
			// textBox2
			// 
			this.textBox2.AutoSize = false;
			this.textBox2.BackColor = System.Drawing.Color.LightYellow;
			this.textBox2.DefaultText = "Suchbegriffe";
			this.textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox2.ForeColor = System.Drawing.Color.DimGray;
			this.textBox2.Location = new System.Drawing.Point(8, 8);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(392, 22);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "Suchbegriffe";
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// button7
			// 
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button7.Location = new System.Drawing.Point(519, 42);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(64, 21);
			this.button7.TabIndex = 3;
			this.button7.Text = "anzeigen";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox1
			// 
			this.textBox1.DefaultText = "Nummer";
			this.textBox1.ForeColor = System.Drawing.Color.Black;
			this.textBox1.Location = new System.Drawing.Point(504, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(64, 21);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
			// 
			// listBox3
			// 
			this.listBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox3.ItemHeight = 15;
			this.listBox3.Location = new System.Drawing.Point(8, 50);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(464, 184);
			this.listBox3.TabIndex = 5;
			this.listBox3.DoubleClick += new System.EventHandler(this.listBox3_dblClick);
			this.listBox3.SelectedValueChanged += new System.EventHandler(this.listBox3_SelectedValueChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBox3.Location = new System.Drawing.Point(72, 32);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(88, 18);
			this.checkBox3.TabIndex = 10;
			this.checkBox3.Text = "Ganze Wörter";
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(8, 32);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(64, 18);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Nur Titel";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(360, 32);
			this.label1.Name = "label1";
			this.label1.TabIndex = 13;
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(464, 8);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(144, 96);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button9);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.listBox1);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(591, 246);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Songliste";
			// 
			// button9
			// 
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button9.Location = new System.Drawing.Point(488, 207);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(96, 28);
			this.button9.TabIndex = 5;
			this.button9.Text = "löschen";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.Control;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.Brown;
			this.button3.Location = new System.Drawing.Point(488, 9);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 46);
			this.button3.TabIndex = 3;
			this.button3.Text = "anzeigen!";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// listBox1
			// 
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(8, 9);
			this.listBox1.Name = "listBox1";
			this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listBox1.Size = new System.Drawing.Size(472, 214);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 0;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_dblClick);
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(488, 131);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 28);
			this.button1.TabIndex = 1;
			this.button1.Text = "neu...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(488, 169);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 28);
			this.button2.TabIndex = 2;
			this.button2.Text = "editieren";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.linkLabel1);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.textBox3);
			this.tabPage3.Controls.Add(this.button13);
			this.tabPage3.Controls.Add(this.button12);
			this.tabPage3.Controls.Add(this.comboBox1);
			this.tabPage3.Controls.Add(this.button6);
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.Controls.Add(this.listBox2);
			this.tabPage3.Controls.Add(this.button5);
			this.tabPage3.Controls.Add(this.pictureBox1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(591, 246);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Persönliche Liste";
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Orange;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.linkLabel1.Location = new System.Drawing.Point(489, 130);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(22, 21);
			this.linkLabel1.TabIndex = 13;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "<<";
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.linkLabel1.Click += new System.EventHandler(this.button10_Click);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(488, 108);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 19);
			this.label3.TabIndex = 12;
			this.label3.Text = "Lied hinzufügen";
			// 
			// textBox3
			// 
			this.textBox3.DefaultText = "Nummer";
			this.textBox3.ForeColor = System.Drawing.Color.DimGray;
			this.textBox3.Location = new System.Drawing.Point(512, 130);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(72, 21);
			this.textBox3.TabIndex = 9;
			this.textBox3.Text = "Nummer";
			this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
			this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
			// 
			// button13
			// 
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
			this.button13.Location = new System.Drawing.Point(8, 92);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(13, 37);
			this.button13.TabIndex = 8;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button12
			// 
			this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
			this.button12.Location = new System.Drawing.Point(8, 138);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(13, 37);
			this.button12.TabIndex = 7;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(32, 9);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(448, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button6.Location = new System.Drawing.Point(488, 65);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(96, 27);
			this.button6.TabIndex = 3;
			this.button6.Text = "Lied entfernen";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.Brown;
			this.button4.Location = new System.Drawing.Point(488, 9);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 46);
			this.button4.TabIndex = 1;
			this.button4.Text = "anzeigen!";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// listBox2
			// 
			this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox2.ItemHeight = 15;
			this.listBox2.Location = new System.Drawing.Point(32, 37);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(448, 199);
			this.listBox2.TabIndex = 0;
			this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
			this.listBox2.SelectedValueChanged += new System.EventHandler(this.listBox2_SelectedValueChanged);
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button5.Location = new System.Drawing.Point(488, 210);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 27);
			this.button5.TabIndex = 2;
			this.button5.Text = "neue Liste...";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(488, 145);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(144, 92);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem19,
																					  this.menuItem57,
																					  this.menuItem10,
																					  this.menuItem4,
																					  this.menuItem37});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem13,
																					  this.menuItem14,
																					  this.menuItem17,
																					  this.menuItem18,
																					  this.menuItem16,
																					  this.menuItem2});
			this.menuItem1.Text = "&Datei";
			// 
			// menuItem13
			// 
			this.menuItem13.Enabled = false;
			this.menuItem13.Index = 0;
			this.menuItem13.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem13.Text = "Ü&bernehmen!";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Enabled = false;
			this.menuItem14.Index = 1;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem15});
			this.menuItem14.Text = "Änderungen &verwerfen!";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 0;
			this.menuItem15.Text = "&Ok";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 2;
			this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem30,
																					   this.menuItem31});
			this.menuItem17.Text = "I&mportieren";
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 0;
			this.menuItem30.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftI;
			this.menuItem30.Text = "&XML";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 1;
			this.menuItem31.Text = "&LTX (Liedtext-Format)";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 3;
			this.menuItem18.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftE;
			this.menuItem18.Text = "Ex&portieren...";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 4;
			this.menuItem16.Text = "-";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "Be&enden";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 1;
			this.menuItem19.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem35,
																					   this.menuItem36,
																					   this.menuItem20,
																					   this.menuItem21,
																					   this.menuItem51,
																					   this.menuItem40,
																					   this.menuItem24,
																					   this.menuItem3});
			this.menuItem19.Text = "E&xtras";
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 0;
			this.menuItem35.Shortcut = System.Windows.Forms.Shortcut.F12;
			this.menuItem35.Text = "&Präsentationsmodus";
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 1;
			this.menuItem36.Text = "-";
			// 
			// menuItem20
			// 
			this.menuItem20.Enabled = false;
			this.menuItem20.Index = 2;
			this.menuItem20.Text = "Songbook drucken...";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 3;
			this.menuItem21.Text = "HTML Seite generieren...";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// menuItem51
			// 
			this.menuItem51.Index = 4;
			this.menuItem51.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem52,
																					   this.menuItem53});
			this.menuItem51.Text = "Unformatierter Text...";
			// 
			// menuItem52
			// 
			this.menuItem52.Index = 0;
			this.menuItem52.Text = "ausgewählter Song";
			this.menuItem52.Click += new System.EventHandler(this.menuItem52_Click);
			// 
			// menuItem53
			// 
			this.menuItem53.Index = 1;
			this.menuItem53.Text = "alle Songs";
			this.menuItem53.Click += new System.EventHandler(this.menuItem53_Click);
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 5;
			this.menuItem40.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem63,
																					   this.menuItem64,
																					   this.menuItem38,
																					   this.menuItem41,
																					   this.menuItem45,
																					   this.menuItem44,
																					   this.menuItem43,
																					   this.menuItem34,
																					   this.menuItem46,
																					   this.menuItem42,
																					   this.menuItem47,
																					   this.menuItem48});
			this.menuItem40.Text = "E&xpertentools";
			// 
			// menuItem63
			// 
			this.menuItem63.Index = 0;
			this.menuItem63.Text = "Suchindex ern&euern";
			this.menuItem63.Click += new System.EventHandler(this.menuItem63_Click);
			// 
			// menuItem64
			// 
			this.menuItem64.Index = 1;
			this.menuItem64.Text = "-";
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 2;
			this.menuItem38.Text = "&Update lyra Songtexte...";
			this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
			// 
			// menuItem41
			// 
			this.menuItem41.Index = 3;
			this.menuItem41.Text = "Letztes Update &rückgängig machen";
			this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
			// 
			// menuItem45
			// 
			this.menuItem45.Index = 4;
			this.menuItem45.Text = "-";
			// 
			// menuItem44
			// 
			this.menuItem44.Enabled = false;
			this.menuItem44.Index = 5;
			this.menuItem44.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem49,
																					   this.menuItem50});
			this.menuItem44.Text = "Dateien für Update-&Server erstellen";
			// 
			// menuItem49
			// 
			this.menuItem49.Index = 0;
			this.menuItem49.Text = "neuer Server...";
			this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
			// 
			// menuItem50
			// 
			this.menuItem50.Index = 1;
			this.menuItem50.Text = "für bestehenden Server...";
			this.menuItem50.Click += new System.EventHandler(this.menuItem50_Click);
			// 
			// menuItem43
			// 
			this.menuItem43.Index = 6;
			this.menuItem43.Text = "-";
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 7;
			this.menuItem34.Text = "Liste für &Pocket PC...";
			this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
			// 
			// menuItem46
			// 
			this.menuItem46.Index = 8;
			this.menuItem46.Text = "-";
			// 
			// menuItem42
			// 
			this.menuItem42.Enabled = false;
			this.menuItem42.Index = 9;
			this.menuItem42.Text = "&Vorbereiten für Lyra 2.0";
			// 
			// menuItem47
			// 
			this.menuItem47.Index = 10;
			this.menuItem47.Text = "-";
			// 
			// menuItem48
			// 
			this.menuItem48.Index = 11;
			this.menuItem48.Text = "Lyra neu starten! (ohne Übernehmen)";
			this.menuItem48.Click += new System.EventHandler(this.menuItem48_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 6;
			this.menuItem24.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 7;
			this.menuItem3.Text = "&Optionen...";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem57
			// 
			this.menuItem57.Index = 2;
			this.menuItem57.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem59,
																					   this.menuItem60,
																					   this.menuItem58,
																					   this.menuItem54,
																					   this.menuItem61,
																					   this.menuItem62});
			this.menuItem57.Text = "&Anzeige";
			this.menuItem57.Popup += new System.EventHandler(this.menuItem57_Popup);
			// 
			// menuItem59
			// 
			this.menuItem59.Index = 0;
			this.menuItem59.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.menuItem59.Text = "History";
			this.menuItem59.Click += new System.EventHandler(this.menuItem59_Click);
			// 
			// menuItem60
			// 
			this.menuItem60.Index = 1;
			this.menuItem60.Text = "Liedvorschau";
			this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
			// 
			// menuItem58
			// 
			this.menuItem58.Index = 2;
			this.menuItem58.Text = "-";
			// 
			// menuItem54
			// 
			this.menuItem54.Index = 3;
			this.menuItem54.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem55,
																					   this.menuItem56});
			this.menuItem54.Text = "Anzeige&schirm";
			// 
			// menuItem55
			// 
			this.menuItem55.Index = 0;
			this.menuItem55.Text = "Primär";
			this.menuItem55.Click += new System.EventHandler(this.menuItem55_Click);
			// 
			// menuItem56
			// 
			this.menuItem56.Index = 1;
			this.menuItem56.Text = "Sekundär";
			this.menuItem56.Click += new System.EventHandler(this.menuItem56_Click);
			// 
			// menuItem61
			// 
			this.menuItem61.Index = 4;
			this.menuItem61.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
			this.menuItem61.Text = "Anzeige aus&blenden";
			this.menuItem61.Click += new System.EventHandler(this.menuItem61_Click);
			// 
			// menuItem62
			// 
			this.menuItem62.Index = 5;
			this.menuItem62.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftB;
			this.menuItem62.Text = "Anzeige &schliessen";
			this.menuItem62.Click += new System.EventHandler(this.menuItem62_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 3;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem26,
																					   this.menuItem23,
																					   this.menuItem27,
																					   this.menuItem11,
																					   this.menuItem22,
																					   this.menuItem12});
			this.menuItem10.Text = "aktuelle &Liste";
			this.menuItem10.Visible = false;
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 0;
			this.menuItem26.Text = "&anzeigen!";
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 1;
			this.menuItem23.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem28});
			this.menuItem23.Text = "Liste &löschen";
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 0;
			this.menuItem28.Text = "&Ok";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 2;
			this.menuItem27.Text = "-";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "neue Liste...";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 4;
			this.menuItem22.Text = "Liste &importieren...";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 5;
			this.menuItem12.Text = "Liste &exportieren...";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem33,
																					  this.menuItem29,
																					  this.menuItem32});
			this.menuItem4.Text = "&Hilfe";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuItem5.Text = "&Inhalt";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 1;
			this.menuItem33.Text = "In&fo";
			this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 2;
			this.menuItem29.Text = "-";
			this.menuItem29.Visible = false;
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 3;
			this.menuItem32.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.menuItem32.Text = "&Debug Console";
			this.menuItem32.Visible = false;
			this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 5;
			this.menuItem37.Shortcut = System.Windows.Forms.Shortcut.F12;
			this.menuItem37.Text = "Präsentation b&eenden";
			this.menuItem37.Visible = false;
			this.menuItem37.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 272);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(599, 18);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "d";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Text = "cur state/action";
			this.statusBarPanel1.Width = 250;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Text = "cur xml-path / options";
			this.statusBarPanel2.Width = 330;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem6,
																						 this.menuItem7,
																						 this.menuItem39,
																						 this.menuItem8,
																						 this.menuItem25});
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "&anzeigen!";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "&editieren";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem39
			// 
			this.menuItem39.Index = 2;
			this.menuItem39.Text = "&löschen";
			this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 3;
			this.menuItem8.Text = "zu aktueller &Liste hinzufügen";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 4;
			this.menuItem25.Text = "Überse&tzungen";
			// 
			// contextMenu2
			// 
			this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem9});
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "zu aktueller &Liste hinzufügen";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// GUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(599, 290);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusBar1);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "GUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "lyra";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Exit);
			this.Activated += new System.EventHandler(this.MeGotFocus);
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion


		public static bool DEBUG = false;

		// Activated -> assure, that the open Editor gets focus back!
		private void MeGotFocus(object sender, System.EventArgs e)
		{
			if (Editor.open)
			{
				Editor.editor.Focus();
			}
			if (this.curItem != -1)
				this.listBox1.SelectedIndex = this.curItem;
			if(this.tabControl1.SelectedIndex == 0)
			{
				this.textBox2.Focus();
				this.textBox2.SelectAll();
			}
		}

		//deavtivated
		private void DeactivateMe(object sender, System.EventArgs e)
		{
			this.curItem = this.listBox1.SelectedIndex;
		}

		// onDoubleClick on listElement
		private void listBox1_dblClick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.listBox1.SelectedItems.Count == 1)
				{
					Util.CTRLSHOWNR = Util.SHOWNR;
					View.ShowSong((Song) this.listBox1.SelectedItem, this, this.listBox1);
				}
			}
			catch (ToManyViews ex)
			{
				Util.MBoxError(ex.Message, ex);
			}
		}

		// Suche::onDoubleClick on listElement
		private void listBox3_dblClick(object sender, System.EventArgs e)
		{
			if (this.listBox3.SelectedItem is Song)
			{
				try
				{
					if (this.listBox3.SelectedItems.Count == 1)
					{
						Util.CTRLSHOWNR = Util.SHOWNR;
						View.ShowSong((Song) this.listBox3.SelectedItem, this, this.listBox3);
					}
				}
				catch (ToManyViews ex)
				{
					Util.MBoxError(ex.Message, ex);
				}
			}
		}

		/// <summary>
		/// functionality
		/// </summary>
		// neu...
		private void button1_Click(object sender, System.EventArgs e)
		{
			Preview.ClosePreview();
			if (!Editor.open)
				(new Editor(null, this)).Show();
			else
				Editor.editor.Focus();
		}

		// edit
		private void button2_Click(object sender, System.EventArgs e)
		{
			if (this.listBox1.SelectedItems.Count == 1 && !Editor.open)
			{
				(new Editor((Song) this.listBox1.SelectedItem, this)).Show();
			}
			else if (Editor.open)
			{
				Editor.editor.Focus();
			}
		}

		// del
		private void button9_Click(object sender, System.EventArgs e)
		{
			if (this.listBox1.SelectedItems.Count == 1)
			{
				((Song) this.listBox1.SelectedItem).Delete();
				this.UpdateListBox();
				this.ToUpdate(true);
			}
		}

		// anzeigen
		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.listBox1.SelectedItems.Count == 1)
				{
					Util.CTRLSHOWNR = Util.SHOWNR;
					View.ShowSong((Song) this.listBox1.SelectedItem, this, this.listBox1);
				}
			}
			catch (ToManyViews ex)
			{
				Util.MBoxError(ex.Message, ex);
			}
		}

		public Song quickload(string nrstr)
		{
			try
			{
				int nr = Int32.Parse(nrstr);
				return this.storage.getSong(nr);
			}
			catch (Exception)
			{
			}
			return null;
		}

		// Quickload
		private void button7_Click(object sender, System.EventArgs e)
		{
			try
			{
				int nr = Int32.Parse(this.textBox1.Text);
				Song toShow = this.storage.getSong(nr);
				if (toShow != null)
				{
					try
					{
						Util.CTRLSHOWNR = !((KeyEventArgs) e).Control;
					}
					catch (Exception)
					{
						Util.CTRLSHOWNR = Util.SHOWNR;
					}
					View.ShowSong(toShow, this, this.listBox1);
				}
				else
				{
					Util.MBoxError("Lied konnte nicht gefunden werden!");
				}
			}
			catch (FormatException fe)
			{
				Util.MBoxError("Geben Sie bitte nur ganze, positive Zahlen ein!\n\n" +
					fe.Message, fe);
			}
			catch (ToManyViews mv)
			{
				Util.MBoxError(mv.Message, mv);
			}
			catch (Exception ex)
			{
				Util.MBoxError(ex.Message, ex);
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs ke)
		{
			if (ke.KeyCode == Keys.Enter)
			{
				this.button7_Click(sender, ke);
			}
		}

		/// <summary>
		/// MainMenu
		/// </summary>
		// Help
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this, Util.BASEURL + "\\" + Util.HLPURL);
		}

		//sicheres Beenden
		private bool CheckOnExit()
		{
			bool cancel = true;
			if (this.storage.ToBeCommited)
			{
				DialogResult res = MessageBox.Show(
					"Vor dem Beenden Änderungen übernehmen?",
					"Beenden von lyra",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning);

				if (res == DialogResult.Yes)
				{
					if (this.storage.Commit())
					{
						cancel = false;
					}
				}
				else if (res == DialogResult.No)
				{
					cancel = false;
				}
			}
			else
			{
				cancel = false;
			}
			return cancel;
		}

		// x-Exit
		private void Exit(object sender, System.ComponentModel.CancelEventArgs args)
		{
			args.Cancel = this.CheckOnExit();
		}

		// beenden aus Menü
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if (!this.CheckOnExit())
			{
				Application.Exit();
			}
		}


		// Übernehmen
		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			if (!Util.NOCOMMIT)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.Enabled = false;
				if (this.storage.Commit())
				{
					this.ToUpdate(false);
					this.ResetSearch();
					this.Status = "Änderungen erfolgreich übernommen...";
					Util.DELALL = false;
				}
				else
				{
					Util.MBoxError("Fehler beim Übernehmen!");
					this.Status = "Fehler beim Übernehmen!";
				}
				this.Enabled = true;
				Cursor.Current = Cursors.Default;
			}
			else
			{
				Util.MBoxError("Sie haben keine Berechtigung, Änderungen vorzunehmen!\n" +
					"Entfernen Sie unter Extras->Optionen..., Allgemein... den Schreibschutz\n" +
					"oder wenden Sie sich an den Administrator.");
				this.Status = "Fehler beim Übernehmen!";
			}
		}

		private void ResetSearch()
		{
			this.listBox3.Items.Clear();
			this.label1.Text = "";
			this.textBox2.Text = "Suchbegriffe";
			this.textBox2.ForeColor = Color.DimGray;
			this.label4.Visible = false;
		}
		
		// Änderungen verwerfen -> ok
		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			this.storage.ResetToLast();
			this.ResetSearch();
			Util.DELALL = false;
			this.Status = "Änderungen verworfen!";
		}

		// exportieren
		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "XML Dateien (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
			sfd.OverwritePrompt = true;
			sfd.Title = "In XML-Datei exportieren";
			DialogResult dr = sfd.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				if (this.storage.Export(sfd.FileName))
				{
					this.Status = "Export erfolgreich! :-)";
				}
				else
				{
					this.Status = "Beim Exportieren ging leider etwas schief. :-(";
				}
			}
		}

		// import XML
		private void menuItem30_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "XML Dateien (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
			ofd.CheckFileExists = true;
			ofd.Title = "XML-Datei importieren";
			DialogResult dr = ofd.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				string msg = "Sollen die Lieder der aktuellen Sammlung hinzugefügt werden?\n";
				msg += "(drücken Sie \"Nein\", falls die aktuellen Liedtexte gelöscht werden sollen)";
				DialogResult app = MessageBox.Show(this, msg,
				                                   "lyra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool res = false;
				if (app == DialogResult.Yes)
				{
					res = this.storage.Import(ofd.FileName, true);
				}
				else
				{
					Util.DELALL = true;
					res = this.storage.Import(ofd.FileName, false);
				}
				this.storage.displaySongs(this.listBox1);
				this.ToUpdate(true);
				if (res)
				{
					this.Status = "Importieren erfolgreich! :-)";
				}
				else
				{
					this.Status = "Beim Importieren ging leider etwas schief. :-(";
				}
			}
		}

		// import LTX
		private void menuItem31_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(this, "Beachten Sie bitte, dass die LTX-Datei UTF-8-codiert sein muss." + Util.NL +
				"Sie können mit dem Converter-Tool ({lyra}\\Converter\\) selber LTX-Dateien generieren!" + Util.NL +
				"Mehr dazu finden Sie in der Hilfe (F1).",
			                "lyra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "LTX Dateien (*.ltx)|*.ltx|Alle Dateien (*.*)|*.*";
			ofd.CheckFileExists = true;
			ofd.Title = "LTX-Datei importieren";
			DialogResult dr = ofd.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				string msg = "Sollen die Lieder der aktuellen Sammlung hinzugefügt werden?\n";
				msg += "(drücken Sie \"Nein\", falls die aktuellen Liedtexte gelöscht werden sollen)";
				DialogResult app = MessageBox.Show(this, msg,
				                                   "lyra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (app == DialogResult.Yes)
				{
					this.ImportLTX(ofd.FileName, true);
				}
				else
				{
					this.ImportLTX(ofd.FileName, false);
				}
			}
		}

		private void ImportLTX(string url, bool append)
		{
			if (!append)
			{
				this.storage.Clear();
				Util.DELALL = true;
			}

			StreamReader reader = new StreamReader(url);
			try
			{
				string line, text, title;
				line = text = title = "";
				int nr = 0;
				bool intext = false;
				while ((line = reader.ReadLine()) != null)
				{
					if (intext)
					{
						if (line.EndsWith("#END"))
						{
							text += line.Substring(0, line.Length - 4);
							Song song = new Song(nr, title, text, "s" + Util.toFour(nr), "", true);
							text = title = "";
							intext = false;
							try
							{
								this.storage.AddSong(song);
							}
							catch (ArgumentException)
							{
								string msg = "Wollen Sie Lied Nr." + nr.ToString() + " ersetzen?\n";
								msg += "(drücken Sie \"abbrechen\", wenn Sie das Lied überspringen wollen.)";
								DialogResult dr =
									MessageBox.Show(this, msg,
									                "lyra import", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
								if (dr == DialogResult.Yes)
								{
									this.storage.RemoveSong(song.ID);
									this.storage.AddSong(song);
								}
								else if (dr == DialogResult.No)
								{
									song.nextID();
									this.storage.AddSong(song);
								}
								else
								{
									// cancel <-> ignore song
								}
								continue;
							}
						}
						else
						{
							text += line + "\n";
						}
					}
						// first line of song
					else if (line != "")
					{
						string[] words = line.Split(' ');
						title = line.Substring(words[0].Length + 1);
						nr = Int32.Parse(words[0]);
						intext = true;
					}
				}
				this.storage.displaySongs(this.listBox1);
				this.ToUpdate(true);
				this.Status = "LTX-Import erfolgreich! :-)";
			}
			catch (Exception ie)
			{
				Util.MBoxError("Fehler beim Importieren.\n" + ie.Message, ie);
				this.Status = "Beim LTX-Import ging leider etwas schief. :-(";
			}
		}

		// reload the curtext.xml-file
		public void ReloadCurText()
		{
			this.storage.ResetToLast();
		}


		/// <summary>
		/// contextmenu
		/// </summary>
		// Kontextmenü
		private void listBox1_click(object sender, MouseEventArgs e)
		{
			if (this.prback == null)
			{
				int i = this.listBox1.IndexFromPoint(e.X, e.Y);
				this.menuItem8.Visible = (this.comboBox1.Items.Count > 0);

				if (i != -1)
				{
					this.listBox1.SetSelected(i, true);
					try
					{
						this.contextMenu1.MenuItems.RemoveAt(4);
					}
					catch (Exception)
					{
					}

					if (((Song) this.listBox1.SelectedItem).TransMenu != null)
						this.contextMenu1.MenuItems.Add(((Song) this.listBox1.SelectedItem).TransMenu);


				}
				if (e.Button == MouseButtons.Right && this.listBox1.SelectedItems.Count == 1)
				{
					this.contextMenu1.Show(this.listBox1, new Point(e.X, e.Y));
				}
			}
		}

		// Kontextmenü Suche
		private void listBox3_click(object sender, MouseEventArgs e)
		{
			if (this.comboBox1.Items.Count > 0 && this.prback == null)
			{
				int i = this.listBox3.IndexFromPoint(e.X, e.Y);
				if (e.Button == MouseButtons.Right && i != -1 &&
					this.listBox3.Items[i].ToString().Substring(0, 4) != "Leid")
				{
					this.listBox3.SelectedIndex = i;
					this.contextMenu2.Show(this.listBox3, new Point(e.X, e.Y));
				}
			}
		}

		// anzeigen
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Util.CTRLSHOWNR = Util.SHOWNR;
			this.button3_Click(sender, e);
		}

		// edit
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			if (!Editor.open)
				(new Editor((Song) this.listBox1.SelectedItem, this)).Show();
			else
				Editor.editor.Focus();
		}

		// del
		private void menuItem39_Click(object sender, System.EventArgs e)
		{
			((Song) this.listBox1.SelectedItem).Delete();
			this.UpdateListBox();
			this.ToUpdate(true);
		}


		/// <summary>
		/// Util
		/// </summary>
		public void AddSong(Song song)
		{
			this.storage.AddSong(song);
		}

		public void UpdateListBox()
		{
			this.storage.displaySongs(this.listBox1);
			this.persLists.Refresh(this.listBox2);
		}

		public void ToUpdate(bool update)
		{
			this.menuItem13.Enabled = update;
			this.menuItem14.Enabled = update;
			this.storage.ToBeCommited = update;
		}

		// Search
		private void button8_Click(object sender, System.EventArgs e)
		{
			this.executeSearch();	
		}
		
		private void executeSearch()
		{
			if(this.textBox2.Text != "" && this.textBox2.Text != "Suchbegriffe")
			{
				try
				{
					this.storage.Search(this.textBox2.Text, this.listBox3, !this.checkBox1.Checked,
					                    false, this.checkBox3.Checked, false);		
					this.label4.Visible = this.storage.ToBeCommited;
				}
				catch (Exception ex)
				{
					Util.MBoxError("Ihre Suchanfrage hat einen Fehler verursacht.\nIn der Hilfe (F1) finden Sie eine Anleitung.", ex);
				}
			}
			int res = this.listBox3.Items.Count;
			switch(res)
			{
				case 0:
					this.label1.Text = "Keine Resultate!";
					break;
				case 1:
					this.label1.Text = "Ein Resultat";
					break;
				default:
					this.label1.Text = res + " Resultate";
					break;
			}
			Preview.ClosePreview();
		}

		private void textBox2_KeyDown(object sender, KeyEventArgs ke)
		{
			if (ke.KeyCode == Keys.Enter)
			{
				this.executeSearch();
			}
		}

		public string Status
		{
			set { this.statusBarPanel1.Text = value; }
		}


		private void textBox1_Click(object sender, System.EventArgs e)
		{
			this.textBox1.SelectAll();
		}

		// Optionen
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Options.ShowOptions();
		}

		/**
		 * MyLists
		 */
		// MyLists-Change
		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.persLists.setCurrent((MyList) this.comboBox1.SelectedItem, this.listBox2);
			this.Status = "";
		}

		// anzeigen
		private void button4_Click(object sender, System.EventArgs e)
		{
			if (this.listBox2.Items.Count > 0)
			{
				try
				{
					Util.CTRLSHOWNR = Util.SHOWNR;
					int ind = (this.listBox2.SelectedIndex > 0) ? this.listBox2.SelectedIndex : 0;
					View.ShowSong((Song) this.listBox2.Items[ind], this, this.listBox2);
				}
				catch (ToManyViews ex)
				{
					Util.MBoxError(ex.Message, ex);
				}
			}
		}

		// up
		private void button13_Click(object sender, System.EventArgs e)
		{
			if (this.listBox2.SelectedItems.Count == 1)
			{
				int i = this.persLists.MoveSongUp(this.listBox2.SelectedIndex);
				this.persLists.Refresh(this.listBox2);
				this.listBox2.SelectedIndex = i;
			}
		}

		// down
		private void button12_Click(object sender, System.EventArgs e)
		{
			if (this.listBox2.SelectedItems.Count == 1)
			{
				int i = this.persLists.MoveSongDown(this.listBox2.SelectedIndex);
				this.persLists.Refresh(this.listBox2);
				this.listBox2.SelectedIndex = i;
			}
		}

		// hinzufügen (aus Liste)
		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.persLists.AddSongToCurrent((Song) this.listBox1.SelectedItem);
			this.persLists.Refresh(this.listBox2);
			this.Status = "Song hinzugefügt.";
		}

		// hinzufügen (aus Suche)
		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.persLists.AddSongToCurrent((Song) this.listBox3.SelectedItem);
			this.persLists.Refresh(this.listBox2);
			this.Status = "Song hinzugefügt.";
		}

		// entfernen
		private void button6_Click(object sender, System.EventArgs e)
		{
			if (this.listBox2.SelectedItems.Count == 1)
			{
				this.persLists.RemoveSongFromCurrent(this.listBox2.SelectedIndex);
				this.persLists.Refresh(this.listBox2);
				this.Status = "Song entfernt.";
				Preview.ClosePreview();
			}
		}

		// Listen-Menü
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.menuItem10.Visible = (this.tabControl1.SelectedIndex == 2) && (this.prback == null);
			if(this.tabControl1.SelectedIndex == 0)
			{
				this.textBox2.Focus();
				this.textBox2.SelectAll();
			}
			this.label4.Visible = this.storage.ToBeCommited;
			Preview.ClosePreview();
		}

		// anzeigen! (Menü)
		private void menuItem26_Click(object sender, System.EventArgs e)
		{
			this.button4_Click(sender, e);
		}

		// lösche Liste (Menü)
		private void menuItem28_Click(object sender, System.EventArgs e)
		{
			if (this.comboBox1.Items.Count == 1)
			{
				MessageBox.Show(this, "Liste kann nicht gelöscht werden!" + Util.NL + "(mindestens eine Liste muss vorhanden sein)", "lyra Warnung",
				                MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (this.comboBox1.SelectedItem != null)
			{
				this.persLists.DeleteCurrent();
				this.comboBox1.Items.RemoveAt(this.comboBox1.SelectedIndex);
				if (this.comboBox1.Items.Count > 0)
				{
					this.comboBox1.SelectedIndex = 0;
				}
				else
				{
					this.listBox2.Items.Clear();
					this.comboBox1.Text = "";
				}
				Preview.ClosePreview();
			}
		}

		// neue Liste
		public void createNewList(string name, string author)
		{
			string date = Util.GetDate();
			this.persLists.addNewList(name, author, date, "");
			this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
			this.Status = "Neue Liste erstellt.";
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			NewList.ShowNewList(this);
			Preview.ClosePreview();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			this.menuItem11_Click(sender, e);
			Preview.ClosePreview();
		}

		// import Liste
		private void menuItem22_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "LLS Dateien (*.lls)|*.lls|Alle Dateien (*.*)|*.*";
			ofd.CheckFileExists = true;
			ofd.Title = "LyraListen-Datei importieren";
			DialogResult dr = ofd.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				this.importList(ofd.FileName);
			}
			this.Status = "Liste erfolgreich importiert. :-)";
		}

		private void importList(string url)
		{
			try
			{
				StreamReader reader = new StreamReader(url);
				string lls = reader.ReadLine();
				if (lls == "<LYRA LISTFILE>")
				{
					string name = reader.ReadLine();
					string author = reader.ReadLine();
					string date = reader.ReadLine();
					string songs = reader.ReadLine();
					this.persLists.addNewList(name, author, date, songs);
					this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
				}
				else
				{
					Util.MBoxError("Falsches File-Format.");
					this.Status = "Fehler beim Importieren der Liste. :-(";
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				this.Status = "Fehler beim Importieren der Liste. :-(";
				Util.MBoxError("Lyra-Listen-Datei nicht gefunden oder Format nicht korrekt!", ex);
			}
		}

		// export Liste
		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "LLS Dateien (*.lls)|*.lls|Alle Dateien (*.*)|*.*";
			sfd.OverwritePrompt = true;
			sfd.Title = "In LyraListen-Datei exportieren";
			DialogResult dr = sfd.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				try
				{
					StreamWriter writer = new StreamWriter(sfd.FileName);
					writer.WriteLine("<LYRA LISTFILE>");
					((MyList) this.comboBox1.SelectedItem).exportMe(writer);
				}
				catch (Exception ex)
				{
					Util.MBoxError("File kann nicht erstellt werden.", ex);
					this.Status = "Fehler beim Exportieren!";
				}
			}
			this.Status = "Liste erfolgreich exportiert. :-)";
		}

		// HTML-Seite generieren...
		private void menuItem21_Click(object sender, System.EventArgs e)
		{
			ListBox box = null;
			string idtext = "";
			switch (this.tabControl1.SelectedIndex)
			{
				case 0:
					box = this.listBox3;
					idtext = "Suchabfrage </b>[";
					if (this.textBox2.Text.Equals("Suchbegriffe..."))
					{
						idtext += "leer]";
					}
					else
					{
						if (this.checkBox1.Checked) idtext += "nur Titel,";
						if (this.checkBox3.Checked) idtext += "ganzes Wort,";
						if (idtext[idtext.Length - 1] == ',') idtext = idtext.Substring(0, idtext.Length - 1);
						idtext += "]:" + Util.HTMLNL + "<b>\"" + this.textBox2.Text + "\"";
					}
					break;
				case 1:
					box = this.listBox1;
					idtext = "ganze Liste";
					break;
				case 2:
					box = this.listBox2;
					idtext = "pers&ouml;nliche Liste:" + Util.HTMLNL + this.comboBox1.SelectedItem.ToString();
					break;
			}
			HTML.showHTML(this, box, idtext);
		}

		// Debugging
		private void menuItem32_Click(object sender, System.EventArgs e)
		{
			DebugConsole.ShowDebugConsole(this);
		}


		// add song directly to list by nr
		private void button10_Click(object sender, System.EventArgs e)
		{
			try
			{
				int curpos = this.listBox2.SelectedIndex;
				int nr = Int32.Parse(this.textBox3.Text);
				Song addSong = this.storage.getSong(nr);
				if (addSong != null)
				{
					this.persLists.AddSongToCurrent(addSong);
					this.persLists.MoveLast(curpos);
					this.persLists.Refresh(this.listBox2);
					this.Status = "Song hinzugefügt.";
				}
				else
				{
					this.Status = "Song nicht gefunden.";
					Util.MBoxError("Lied konnte nicht gefunden werden!");
				}
				Preview.ClosePreview();
			}
			catch (FormatException fe)
			{
				Util.MBoxError("Geben Sie bitte nur ganze, positive Zahlen ein!\n\n" +
					fe.Message, fe);
				this.textBox3.Text = "Liednr";
				this.textBox3.SelectAll();
				this.textBox3.Focus();
			}
			catch (Exception ex)
			{
				Util.MBoxError(ex.Message, ex);
			}
		}


		// Lists
		private void textBox3_Click(object sender, System.EventArgs e)
		{
			this.textBox3.SelectAll();
		}

		private void listBox2_DoubleClick(object sender, EventArgs e)
		{
			this.button4_Click(sender, e);
		}

		private void textBox3_KeyDown(object sender, KeyEventArgs ke)
		{
			if (ke.KeyCode == Keys.Enter)
			{
				this.button10_Click(sender, ke);
				this.textBox3.SelectAll();
				this.textBox3.Focus();
			}
		}

		// show info
		private void menuItem33_Click(object sender, System.EventArgs e)
		{
			Info.showInfo(this);
		}

		// Pocket PC
		private void menuItem34_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "LPPC Datei (data.lppc)|*.lppc";
			sfd.FileName = "data.lppc";
			sfd.OverwritePrompt = true;
			sfd.Title = "Liste für Pocket PC generieren.";
			DialogResult dr = sfd.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				if (this.storage.ExportPPC(sfd.FileName))
				{
					this.Status = "Export für Pocket PC erfolgreich! :-)";
				}
				else
				{
					this.Status = "Beim Exportieren für Pocket PC ging leider etwas schief. :-(";
				}
			}
		}

		#region Präsentationsmodus

		private PrBackground prback = null;

		private void menuItem35_Click(object sender, System.EventArgs e)
		{
			if (this.prback != null)
			{
				this.prback.Close();
				this.prback = null;
				this.hideForPresentation(false);
			}
			else
			{
				this.prback = new PrBackground(this);
				this.hideForPresentation(true);
				this.prback.Show();
				this.Focus();
			}

		}

		private void hideForPresentation(bool hide)
		{
			bool visible = !hide;
			this.menuItem37.Visible = hide;
			this.menuItem1.Visible = visible;
			this.menuItem19.Visible = visible;
			this.menuItem4.Visible = visible;
			this.menuItem10.Visible = visible & (this.tabControl1.SelectedIndex == 2);
			this.button1.Visible = visible;
			this.button2.Visible = visible;
			this.button9.Visible = visible;
			this.button6.Visible = visible;
			this.linkLabel1.Visible = visible;
			this.button5.Visible = visible;
			this.textBox3.Visible = visible;
			this.label3.Visible = visible;
			this.pictureBox1.Visible = visible;
		}

		#endregion

		// update lyra
		private void menuItem38_Click(object sender, System.EventArgs e)
		{
			if (LyraUpdate.ShowUpdate(this) == DialogResult.OK)
			{
				MessageBox.Show(this, "Update wurde durchgeführt!" + Util.NL + "lyra wird jetzt neu gestartet.",
				                "lyra Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.restart();
			}
			// else cancelled
		}

		// rollback last update
		private void menuItem41_Click(object sender, System.EventArgs e)
		{
			File.Copy(LyraUpdateView.BACKUP, LyraUpdateView.CURTEXT, true);
			File.Delete(LyraUpdateView.BACKUP);
			if (MessageBox.Show(this, "Listen ebenfalls wieder auf den Stand" + Util.NL + "vor dem letzten Update zurücksetzen?" +
				Util.NL + Util.NL + "Vorsicht! Alle Änderungen seit dem letzten Update" + Util.NL + "gehen verloren.",
			                    "lyra Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				File.Copy(LyraUpdateView.BACKUPLIST, LyraUpdateView.LISTFILE, true);
				File.Delete(LyraUpdateView.BACKUPLIST);
			}
			MessageBox.Show(this, "Update wurde rückgängig gemacht!" + Util.NL + "lyra wird jetzt neu gestartet.",
			                "lyra Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.restart();
		}

		// restart lyra
		private void restart()
		{
			// Shut down the current app instance
			Application.Exit();
			// Restart the app
			System.Diagnostics.Process.Start(Application.ExecutablePath);
		}

		// restart lyra client
		private void menuItem48_Click(object sender, System.EventArgs e)
		{
			this.restart();
		}

		// create new Server
		private void menuItem49_Click(object sender, System.EventArgs e)
		{
		}

		// from existing Server
		private void menuItem50_Click(object sender, System.EventArgs e)
		{
		}

		private string[] formats = new string[] { "refrain", "special", "p8","p16","p24","p32","p40","b","i","pagebreak",};
		private bool isFormat(string s)
		{
			s = s.TrimStart('/', ' ');
			foreach(string f in formats)
			{
				if(s.StartsWith(f))
				{
					return true;
				}
			}
			return false;
		}
		private void showUnformated(Song s)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Bitte geben Sie den Pfad für die Textdatei an!";
			sfd.Filter = "Textdatei|*.txt";
			sfd.FileName = "lyra_" + s.Number.ToString() + ".txt";
			if(sfd.ShowDialog(this) == DialogResult.OK)
			{
				StreamWriter sw = new StreamWriter(sfd.FileName,false);
				string title = s.Number.ToString().PadRight(5,' ') + ":  " + s.Title;
				string line = "".PadRight(title.Length,'-');
				sw.WriteLine(title);
				sw.WriteLine(line);
				sw.WriteLine();
				string text = "";
				for(int i=0; i<s.Text.Length; i++)
				{
					if(s.Text[i] == '<')
					{
						if(this.isFormat(s.Text.Substring(i+1)))
						{
							if(s.Text.Substring(i+1).StartsWith("refrain"))
							{
								text += "REFRAIN:" + Util.NL;
							}
							i = s.Text.IndexOf('>',i) + 1;
						}
					}
					text += s.Text[i];
				}
				text = text.Replace("&gt;",">").Replace("&lt;","<").Replace("\n","\r\n");
				sw.WriteLine(text);
				sw.Close();

				Process.Start("file://" + sfd.FileName);
			}
		}

		private void menuItem52_Click(object sender, System.EventArgs e)
		{
			if(this.tabControl1.SelectedIndex == 0)
			{ // search
				if(this.listBox3.SelectedItem is Song)
				{
					Song s = (Song)this.listBox3.SelectedItem;
					this.showUnformated(s);
					return;
				}
			}
			else if(this.tabControl1.SelectedIndex == 1)
			{ // selection
				if(this.listBox1.SelectedItem is Song)
				{
					Song s = (Song)this.listBox1.SelectedItem;
					this.showUnformated(s);
					return;
				}
			}
			else
			{ // list selection
				if(this.listBox2.SelectedItem is Song)
				{
					Song s = (Song)this.listBox2.SelectedItem;
					this.showUnformated(s);
					return;
				}
			}
			MessageBox.Show(this,"Es ist kein Lied ausgewählt!","Fehler!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
		}

		private void menuItem53_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Bitte geben Sie den Pfad für die Textdatei an!";
			sfd.Filter = "Textdatei|*.txt";
			sfd.FileName = "lyra_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
			if(sfd.ShowDialog(this) == DialogResult.OK)
			{
				StreamWriter sw = new StreamWriter(sfd.FileName,false);

				foreach(Song s in this.listBox1.Items)
				{
					string title = s.Number.ToString().PadRight(5,' ') + ":  " + s.Title;
					string line = "".PadRight(title.Length,'-');
					sw.WriteLine(title);
					sw.WriteLine(line);
					sw.WriteLine();
					string text = "";
					for(int i=0; i<s.Text.Length; i++)
					{
						if(s.Text[i] == '<')
						{
							if(this.isFormat(s.Text.Substring(i+1)))
							{
								if(s.Text.Substring(i+1).StartsWith("refrain"))
								{
									text += "REFRAIN:" + Util.NL;
								}
								i = s.Text.IndexOf('>',i) + 1;
							}
						}
						if(i < s.Text.Length) text += s.Text[i];
					}
					text = text.Replace("&gt;",">").Replace("&lt;","<").Replace("\n","\r\n");
					while(text.EndsWith("\r\n")) text = text.Substring(0,text.Length-2);
					sw.WriteLine(text);
					sw.WriteLine();
					sw.WriteLine();
				}
				sw.Close();

				Process.Start("file://" + sfd.FileName);
			}	
		}


		private void menuItem55_Click(object sender, System.EventArgs e)
		{
			Util.SCREEN_ID = 0;
			View.display = Util.GetScreen(0);
			Util.updateRegSettings();
			this.menuItem55.Checked = true;
			this.menuItem56.Checked = false;
		}

		private void menuItem56_Click(object sender, System.EventArgs e)
		{
			Util.SCREEN_ID = 1;
			View.display = Util.GetScreen(1);
			Util.updateRegSettings();
			this.menuItem55.Checked = false;
			this.menuItem56.Checked = true;
		}

		private void menuItem61_Click(object sender, System.EventArgs e)
		{
			this.menuItem61.Checked = !this.menuItem61.Checked;
			View.BlackScreen(this.menuItem61.Checked);
		}

		private void menuItem57_Popup(object sender, System.EventArgs e)
		{
			this.menuItem61.Checked = View.black;
			this.menuItem60.Checked = Util.SHOW_PREVIEW;
		}

		private void menuItem59_Click(object sender, System.EventArgs e)
		{
			History.ShowHistory(this);
		}

		private void listBox3_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(menuItem60.Checked)
			{
				Song s = this.listBox3.SelectedItem as Song;
				if(s != null)
				{
					Rectangle rect = this.listBox3.GetItemRectangle(this.listBox3.SelectedIndex);
					Point location = this.listBox3.PointToScreen(new Point(rect.Left, rect.Top));
					location.X += this.listBox3.Width - 25;
					//location.Y += rect.Height + 2;
					Preview.ShowPreview(this, s, this.getBestLocationForPreview(location));
					this.listBox3.Focus();
				}
			}
		}

		private void listBox1_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(menuItem60.Checked)
			{
				Song s = this.listBox1.SelectedItem as Song;
				if(s != null)
				{
					Rectangle rect = this.listBox1.GetItemRectangle(this.listBox1.SelectedIndex);
					Point location = this.listBox1.PointToScreen(new Point(rect.Left, rect.Top));
					location.X += this.listBox1.Width - 25;
					//location.Y += rect.Height + 2;
					Preview.ShowPreview(this, s, this.getBestLocationForPreview(location));
					this.listBox1.Focus();
				}
			}		
		}

		private void listBox2_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(menuItem60.Checked)
			{
				Song s = this.listBox2.SelectedItem as Song;
				if(s != null)
				{
					Rectangle rect = this.listBox2.GetItemRectangle(this.listBox2.SelectedIndex);
					Point location = this.listBox2.PointToScreen(new Point(rect.Left, rect.Top));
					location.X += this.listBox2.Width - 25;
					//location.Y += rect.Height + 2;
					Preview.ShowPreview(this, s, this.getBestLocationForPreview(location));
					this.listBox2.Focus();
				}
			}
		}

		private void menuItem60_Click(object sender, System.EventArgs e)
		{
			this.menuItem60.Checked = !this.menuItem60.Checked;
			Util.SHOW_PREVIEW = this.menuItem60.Checked;
			Util.updateRegSettings();
		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
			if(this.searchTask != null)
			{
				this.searchTask.Abort();
			}
			this.searchTask = new DelayedTask(new ThreadStart(this.executeSearch), 300);
			this.searchTask.Start();
		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			this.executeSearch();
		}

		private void menuItem62_Click(object sender, System.EventArgs e)
		{
			View.CloseView();
		}

		private void GUI_GotFocus(object sender, EventArgs e)
		{
			Preview.ClosePreview();
		}

		private void listBox_Scrolled(object sender, ScrollEventArgs e)
		{
			Preview.ClosePreview();
		}

		private void item_Popup(object sender, EventArgs e)
		{
			Preview.ClosePreview();
		}

		private void contextMenu_Popup(object sender, EventArgs e)
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

		private void menuItem63_Click(object sender, System.EventArgs e)
		{
			if(this.storage.ToBeCommited)
			{
				MessageBox.Show(this,
					"Index konnte nicht neu gebildet werden!" + Util.NL +
					"Bitte zuerst alle Änderungen übernehmen oder verwerfen.",
					"Suchindex erneuern...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(this.storage.cleanSearchIndex())
			{
				MessageBox.Show(this, "Index wurde erfolgreich neu gebildet.", "Suchindex erneuern...", MessageBoxButtons.OK,
				                MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(this,
				                "Index konnte nicht neu gebildet werden!" + Util.NL +
				                "Bitte lyra beenden und vor dem Neustart das Verzeichnis '<lyra>\\index' manuell löschen.",
				                "Suchindex erneuern...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void GUI_Move(object sender, EventArgs e)
		{
			Preview.ClosePreview();
		}

		private void button8_Click_1(object sender, System.EventArgs e)
		{
			(new TestForm()).ShowDialog(this);
		}
	}
}