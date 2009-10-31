using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Lyra2.UtilShared;
using Infragistics.Win.Misc;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Zusammendfassende Beschreibung f�r GUI.
    /// </summary>
    public class GUI : Form
    {
        private IContainer components;

        #region Designervariablen


        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label3;
        private LyraButtonControl button1;
        private SongListBox allSongsListBox;
        private LyraButtonControl button2;
        private StatusBar statusBar1;
        private StatusBarPanel statusBarPanel1;
        private LyraButtonControl button3;
        private StatusBarPanel statusBarPanel2;
        private ContextMenu contextMenu1;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private TabPage tabPage3;
        private ContextMenu contextMenu2;
        private SongListBox personalListsListBox;
        private LyraButtonControl button4;
        private LyraButtonControl button5;
        private LyraButtonControl button6;
        private ComboBox comboBox1;
        private SearchTextBox textBox1;
        private LyraButtonControl button7;
        private SearchTextBox mainSearchBox;
        private SongListBox searchListBox;
        private CheckBox checkBox1;
        private LyraButtonControl button9;
        private SearchTextBox textBox3;
        private CheckBox checkBox3;
        private UltraButton button12;
        private UltraButton button13;
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem8;
        private MenuItem menuItem13;
        private MenuItem menuItem14;
        private MenuItem menuItem15;
        private MenuItem menuItem16;
        private MenuItem menuItem17;
        private MenuItem menuItem18;
        private MenuItem menuItem19;
        private MenuItem menuItem20;
        private MenuItem menuItem21;
        private MenuItem menuItem24;
        private MenuItem menuItem30;
        private MenuItem menuItem31;
        private MenuItem menuItem9;
        private MenuItem menuItem10;
        private MenuItem menuItem11;
        private MenuItem menuItem12;
        private MenuItem menuItem22;
        private MenuItem menuItem23;
        private MenuItem menuItem26;
        private MenuItem menuItem27;
        private MenuItem menuItem28;
        private MenuItem menuItem29;
        private MenuItem menuItem32;
        private MenuItem menuItem33;
        private MenuItem menuItem34;
        private MenuItem menuItem35;
        private MenuItem menuItem36;
        private MenuItem menuItem37;
        private MenuItem menuItem25;
        private MenuItem menuItem39;
        private MenuItem menuItem38;
        private MenuItem menuItem40;
        private MenuItem menuItem41;
        private MenuItem menuItem42;
        private MenuItem menuItem43;
        private MenuItem menuItem44;
        private MenuItem menuItem45;
        private MenuItem menuItem46;
        private MenuItem menuItem47;
        private MenuItem menuItem48;
        private MenuItem menuItem49;
        private MenuItem menuItem50;
        private MenuItem menuItem51;
        private MenuItem menuItem52;
        private MenuItem menuItem54;
        private MenuItem menuItem55;
        private MenuItem menuItem56;
        private MenuItem menuItem57;
        private MenuItem menuItem58;
        private MenuItem menuItem59;
        private MenuItem menuItem61;
        private PictureBox pictureBox4;
        private Label resultsLabel;
        private LinkLabel linkLabel1;

        #endregion

        private IStorage storage;
        public int curItem = -1;
        private PLists persLists;
        private MenuItem menuItem62;
        private MenuItem menuItem63;
        private MenuItem menuItem64;
        private Label label4;
        private MenuItem menuItem65;
        private SongPreview songPreview1;
        private UltraPanel controlPaneRight;
        private UltraPanel panel1;
        private Panel panel4;
        private SongPreview songPreview3;
        private MenuItem menuItem60;
        private MenuItem menuItem66;
        private MenuItem menuItem67;
        private UltraPanel panel7;
        private Panel panel8;
        private Panel panel9;
        private SongPreview songPreview2;
        private PictureBox pictureBox1;
        private Label label2;
        private SplitContainer searchSplitter;
        private Panel searchPaneTop;
        private DelayedTaskRunner<EventArgs> searchTask;
        private SplitContainer allSongsSplitter;
        private SplitContainer persListSplitter;
        private MenuItem menuItem69;
        private MenuItem menuItem68;
        private MenuItem menuItem53;
        private readonly Personalizer personalizeStore;

        public Personalizer Personalizer
        {
            get { return personalizeStore; }
        }

        public ListBox StandardNavigate
        {
            get { return this.allSongsListBox; }
        }

        private Start start;

        public GUI()
        {
            InitializeComponent();
            this.Enabled = false;
            this.personalizeStore = new Personalizer(Application.StartupPath + @"\laststate.dat");

            this.InitializeLyraGUI();
            this.InitializeSearch();

            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += delegate { this.InitializeLyraData(); };
            this.start = new Start();
            this.start.StartPosition = FormStartPosition.CenterScreen;

            this.start.Show(this);
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync();

            if (Screen.AllScreens.Length == 1)
            {
                this.menuItem54.Enabled = false;
            }
            else
            {
                if (Util.SCREEN_ID == 0)
                {
                    this.menuItem55.Checked = true;
                }
                else
                {
                    this.menuItem56.Checked = true;
                }
            }
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            this.storage.displaySongs(this.allSongsListBox);
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
            this.Deactivate += this.DeactivateMe;
            this.start.Hide();

        }

        private void InitializeLyraGUI()
        {
            base.Text = Util.GUINAME;
            this.menuItem41.Enabled = File.Exists(Util.BASEURL + "\\" + Util.URL + ".bac");
            this.WindowState = FormWindowState.Normal;

            this.allSongsListBox.MouseDown += this.listBox1_click;
            this.searchListBox.MouseDown += this.listBox3_click;
            this.allSongsListBox.KeyDown += listBox1_KeyDown;
            this.personalListsListBox.KeyDown += listBox2_KeyDown;
            this.searchListBox.KeyDown += listBox3_KeyDown;
            this.checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            this.checkBox3.CheckedChanged += checkBox1_CheckedChanged;
            this.statusBar1.Visible = DEBUG;
            this.statusBarPanel1.Text = "ok";
            this.statusBarPanel2.Text = Util.URL;
            this.Resize += delegate { this.SizeSearchPane(); };
            this.personalizeStore.Load();

            // init GUI size
            this.StartPosition = FormStartPosition.Manual;
            int left = this.personalizeStore.GetIntValue(PersonalizationItemNames.GUILeft);
            if (left >= 0) this.Left = left;
            int top = this.personalizeStore.GetIntValue(PersonalizationItemNames.GUITop);
            if (top >= 0) this.Top = top;
            int width = this.personalizeStore.GetIntValue(PersonalizationItemNames.GUIWidth);
            if (width >= 0) this.Width = width;
            int height = this.personalizeStore.GetIntValue(PersonalizationItemNames.GUIHeight);
            if (height >= 0) this.Height = height;

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.personalizeStore.GetIntValue(PersonalizationItemNames.HistoryIsShown) > 0)
            {
                History.ShowHistory(this);
            }
            if (this.personalizeStore.GetIntValue(PersonalizationItemNames.RemoteIsShown) > 0)
            {
                RemoteControl.ShowRemoteControl(this);
            }

            this.SizeSearchPane();

            // init splitters
            int searchSplit = this.personalizeStore.GetIntValue(PersonalizationItemNames.SearchSplitPosition);
            if (searchSplit >= 0) this.searchSplitter.SplitterDistance = searchSplit;
            int allSongsSplit = this.personalizeStore.GetIntValue(PersonalizationItemNames.AllSplitPosition);
            if (allSongsSplit >= 0) this.allSongsSplitter.SplitterDistance = allSongsSplit;
            int persListSplit = this.personalizeStore.GetIntValue(PersonalizationItemNames.ListSplitPosition);
            if (persListSplit >= 0) this.persListSplitter.SplitterDistance = persListSplit;
        }

        private void SizeSearchPane()
        {
            this.mainSearchBox.Width = this.panel4.Width - this.searchPaneTop.Width - 10;
            this.resultsLabel.Left = this.mainSearchBox.Right - this.resultsLabel.Width;
        }

        private void InitializeLyraData()
        {
            this.storage = new Storage(Util.URL, this);  
            Thread.Sleep(1000);
        }

        private delegate void InvokeSearch();

        private void InitializeSearch()
        {
            this.searchTask = new DelayedTaskRunner<EventArgs>(250);
            InvokeSearch searchInvoker = delegate { this.executeSearch(); };
            this.searchTask.RunDelayedTask += delegate { this.Invoke(searchInvoker); };
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            History.StorePersonalizationSettings(this.Personalizer, true);
            RemoteControl.StorePersonalizationSettings(this.Personalizer, true);
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            this.personalizeStore[PersonalizationItemNames.GUILeft] = this.Left.ToString();
            this.personalizeStore[PersonalizationItemNames.GUITop] = this.Top.ToString();
            this.personalizeStore[PersonalizationItemNames.GUIWidth] = this.Width.ToString();
            this.personalizeStore[PersonalizationItemNames.GUIHeight] = this.Height.ToString();
            this.personalizeStore[PersonalizationItemNames.SearchSplitPosition] = this.searchSplitter.SplitterDistance.ToString();
            this.personalizeStore[PersonalizationItemNames.AllSplitPosition] = this.allSongsSplitter.SplitterDistance.ToString();
            this.personalizeStore[PersonalizationItemNames.ListSplitPosition] = this.persListSplitter.SplitterDistance.ToString();
            this.personalizeStore.Write();
            base.OnClosed(e);
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
        /// Erforderliche Methode f�r die Designerunterst�tzung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.searchSplitter = new System.Windows.Forms.SplitContainer();
            this.searchListBox = new Lyra2.LyraShell.SongListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.songPreview3 = new Lyra2.LyraShell.SongPreview();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchPaneTop = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainSearchBox = new Lyra2.LyraShell.SearchTextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.panel1 = new Infragistics.Win.Misc.UltraPanel();
            this.textBox1 = new Lyra2.LyraShell.SearchTextBox();
            this.button7 = new Lyra2.LyraShell.LyraButtonControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.allSongsSplitter = new System.Windows.Forms.SplitContainer();
            this.allSongsListBox = new Lyra2.LyraShell.SongListBox();
            this.songPreview1 = new Lyra2.LyraShell.SongPreview();
            this.controlPaneRight = new Infragistics.Win.Misc.UltraPanel();
            this.button3 = new Lyra2.LyraShell.LyraButtonControl();
            this.button1 = new Lyra2.LyraShell.LyraButtonControl();
            this.button2 = new Lyra2.LyraShell.LyraButtonControl();
            this.button9 = new Lyra2.LyraShell.LyraButtonControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.persListSplitter = new System.Windows.Forms.SplitContainer();
            this.personalListsListBox = new Lyra2.LyraShell.SongListBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new Lyra2.LyraShell.LyraButtonControl();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button12 = new Infragistics.Win.Misc.UltraButton();
            this.button13 = new Infragistics.Win.Misc.UltraButton();
            this.songPreview2 = new Lyra2.LyraShell.SongPreview();
            this.panel7 = new Infragistics.Win.Misc.UltraPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button6 = new Lyra2.LyraShell.LyraButtonControl();
            this.button4 = new Lyra2.LyraShell.LyraButtonControl();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new Lyra2.LyraShell.SearchTextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
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
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
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
            this.menuItem65 = new System.Windows.Forms.MenuItem();
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
            this.menuItem60 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.searchSplitter.Panel1.SuspendLayout();
            this.searchSplitter.Panel2.SuspendLayout();
            this.searchSplitter.SuspendLayout();
            this.panel4.SuspendLayout();
            this.searchPaneTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.ClientArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.allSongsSplitter.Panel1.SuspendLayout();
            this.allSongsSplitter.Panel2.SuspendLayout();
            this.allSongsSplitter.SuspendLayout();
            this.controlPaneRight.ClientArea.SuspendLayout();
            this.controlPaneRight.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.persListSplitter.Panel1.SuspendLayout();
            this.persListSplitter.Panel2.SuspendLayout();
            this.persListSplitter.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.ClientArea.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 271);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.searchSplitter);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(694, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Suche";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // searchSplitter
            // 
            this.searchSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchSplitter.Location = new System.Drawing.Point(0, 60);
            this.searchSplitter.Name = "searchSplitter";
            this.searchSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // searchSplitter.Panel1
            // 
            this.searchSplitter.Panel1.Controls.Add(this.searchListBox);
            this.searchSplitter.Panel1.Controls.Add(this.label4);
            this.searchSplitter.Panel1MinSize = 150;
            // 
            // searchSplitter.Panel2
            // 
            this.searchSplitter.Panel2.Controls.Add(this.songPreview3);
            this.searchSplitter.Panel2MinSize = 50;
            this.searchSplitter.Size = new System.Drawing.Size(582, 185);
            this.searchSplitter.SplitterDistance = 150;
            this.searchSplitter.TabIndex = 18;
            // 
            // searchListBox
            // 
            this.searchListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.searchListBox.HighLightBackColor = System.Drawing.Color.LightGray;
            this.searchListBox.ItemHeight = 15;
            this.searchListBox.Location = new System.Drawing.Point(0, 0);
            this.searchListBox.Name = "searchListBox";
            this.searchListBox.NrOfNumberMatches = 0;
            this.searchListBox.Size = new System.Drawing.Size(582, 124);
            this.searchListBox.TabIndex = 5;
            this.searchListBox.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.searchListBox.DoubleClick += new System.EventHandler(this.listBox3_dblClick);
            this.searchListBox.SelectedValueChanged += new System.EventHandler(this.listBox3_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(0, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(582, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Suchergebnisse k�nnten fehlerhaft sein. Bitte �nderungen �bernehmen!";
            this.label4.Visible = false;
            // 
            // songPreview3
            // 
            this.songPreview3.AutoScroll = true;
            this.songPreview3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songPreview3.Location = new System.Drawing.Point(0, 0);
            this.songPreview3.Name = "songPreview3";
            this.songPreview3.Size = new System.Drawing.Size(582, 50);
            this.songPreview3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.searchPaneTop);
            this.panel4.Controls.Add(this.mainSearchBox);
            this.panel4.Controls.Add(this.checkBox3);
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.resultsLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(582, 60);
            this.panel4.TabIndex = 17;
            // 
            // searchPaneTop
            // 
            this.searchPaneTop.Controls.Add(this.pictureBox4);
            this.searchPaneTop.Controls.Add(this.label2);
            this.searchPaneTop.Controls.Add(this.pictureBox1);
            this.searchPaneTop.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchPaneTop.Location = new System.Drawing.Point(382, 0);
            this.searchPaneTop.Name = "searchPaneTop";
            this.searchPaneTop.Size = new System.Drawing.Size(200, 60);
            this.searchPaneTop.TabIndex = 2;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 22);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.button8_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(67, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Suche zur�cksetzen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // mainSearchBox
            // 
            this.mainSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(176)))));
            this.mainSearchBox.DefaultText = "Suchbegriffe";
            this.mainSearchBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainSearchBox.ForeColor = System.Drawing.Color.DimGray;
            this.mainSearchBox.Location = new System.Drawing.Point(8, 8);
            this.mainSearchBox.Name = "mainSearchBox";
            this.mainSearchBox.Size = new System.Drawing.Size(704, 22);
            this.mainSearchBox.TabIndex = 0;
            this.mainSearchBox.Text = "Suchbegriffe";
            this.mainSearchBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.mainSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // checkBox3
            // 
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(72, 32);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(88, 18);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Ganze W�rter";
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(8, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 18);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Nur Titel";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // resultsLabel
            // 
            this.resultsLabel.BackColor = System.Drawing.Color.Transparent;
            this.resultsLabel.ForeColor = System.Drawing.Color.DimGray;
            this.resultsLabel.Location = new System.Drawing.Point(504, 32);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(100, 23);
            this.resultsLabel.TabIndex = 13;
            this.resultsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            appearance1.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.right_pane_bg;
            appearance1.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(110, 100, 1, 350);
            appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.panel1.Appearance = appearance1;
            // 
            // panel1.ClientArea
            // 
            this.panel1.ClientArea.Controls.Add(this.textBox1);
            this.panel1.ClientArea.Controls.Add(this.button7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(582, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 245);
            this.panel1.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.DefaultText = "Nummer";
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(16, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Nummer";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(16, 29);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 28);
            this.button7.TabIndex = 1;
            this.button7.Text = "Anzeigen";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.allSongsSplitter);
            this.tabPage1.Controls.Add(this.controlPaneRight);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(694, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Songliste";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // allSongsSplitter
            // 
            this.allSongsSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allSongsSplitter.Location = new System.Drawing.Point(0, 0);
            this.allSongsSplitter.Name = "allSongsSplitter";
            this.allSongsSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // allSongsSplitter.Panel1
            // 
            this.allSongsSplitter.Panel1.Controls.Add(this.allSongsListBox);
            this.allSongsSplitter.Panel1MinSize = 150;
            // 
            // allSongsSplitter.Panel2
            // 
            this.allSongsSplitter.Panel2.Controls.Add(this.songPreview1);
            this.allSongsSplitter.Panel2MinSize = 50;
            this.allSongsSplitter.Size = new System.Drawing.Size(582, 245);
            this.allSongsSplitter.SplitterDistance = 171;
            this.allSongsSplitter.TabIndex = 8;
            // 
            // allSongsListBox
            // 
            this.allSongsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allSongsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allSongsListBox.HighLightBackColor = System.Drawing.Color.LightGray;
            this.allSongsListBox.ItemHeight = 15;
            this.allSongsListBox.Location = new System.Drawing.Point(0, 0);
            this.allSongsListBox.Name = "allSongsListBox";
            this.allSongsListBox.NrOfNumberMatches = 0;
            this.allSongsListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.allSongsListBox.Size = new System.Drawing.Size(582, 169);
            this.allSongsListBox.Sorted = true;
            this.allSongsListBox.TabIndex = 0;
            this.allSongsListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.allSongsListBox.DoubleClick += new System.EventHandler(this.listBox1_dblClick);
            this.allSongsListBox.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // songPreview1
            // 
            this.songPreview1.AutoScroll = true;
            this.songPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songPreview1.Location = new System.Drawing.Point(0, 0);
            this.songPreview1.Name = "songPreview1";
            this.songPreview1.Size = new System.Drawing.Size(582, 70);
            this.songPreview1.TabIndex = 0;
            // 
            // controlPaneRight
            // 
            appearance2.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.right_pane_bg;
            appearance2.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(110, 100, 1, 350);
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.controlPaneRight.Appearance = appearance2;
            // 
            // controlPaneRight.ClientArea
            // 
            this.controlPaneRight.ClientArea.Controls.Add(this.button3);
            this.controlPaneRight.ClientArea.Controls.Add(this.button1);
            this.controlPaneRight.ClientArea.Controls.Add(this.button2);
            this.controlPaneRight.ClientArea.Controls.Add(this.button9);
            this.controlPaneRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlPaneRight.Location = new System.Drawing.Point(582, 0);
            this.controlPaneRight.Name = "controlPaneRight";
            this.controlPaneRight.Size = new System.Drawing.Size(112, 245);
            this.controlPaneRight.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Brown;
            this.button3.Location = new System.Drawing.Point(10, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Anzeigen!";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Neues Lied�";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Editieren�";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(10, 140);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 28);
            this.button9.TabIndex = 5;
            this.button9.Text = "L�schen";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.persListSplitter);
            this.tabPage3.Controls.Add(this.panel7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(694, 245);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pers�nliche Liste";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // persListSplitter
            // 
            this.persListSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.persListSplitter.Location = new System.Drawing.Point(0, 0);
            this.persListSplitter.Name = "persListSplitter";
            this.persListSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // persListSplitter.Panel1
            // 
            this.persListSplitter.Panel1.Controls.Add(this.personalListsListBox);
            this.persListSplitter.Panel1.Controls.Add(this.panel8);
            this.persListSplitter.Panel1.Controls.Add(this.panel9);
            this.persListSplitter.Panel1MinSize = 150;
            // 
            // persListSplitter.Panel2
            // 
            this.persListSplitter.Panel2.Controls.Add(this.songPreview2);
            this.persListSplitter.Panel2MinSize = 50;
            this.persListSplitter.Size = new System.Drawing.Size(582, 245);
            this.persListSplitter.SplitterDistance = 170;
            this.persListSplitter.TabIndex = 17;
            // 
            // personalListsListBox
            // 
            this.personalListsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personalListsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.personalListsListBox.HighLightBackColor = System.Drawing.Color.LightGray;
            this.personalListsListBox.ItemHeight = 15;
            this.personalListsListBox.Location = new System.Drawing.Point(24, 30);
            this.personalListsListBox.Name = "personalListsListBox";
            this.personalListsListBox.NrOfNumberMatches = 0;
            this.personalListsListBox.Size = new System.Drawing.Size(558, 139);
            this.personalListsListBox.TabIndex = 0;
            this.personalListsListBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.personalListsListBox.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            this.personalListsListBox.SelectedValueChanged += new System.EventHandler(this.listBox2_SelectedValueChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comboBox1);
            this.panel8.Controls.Add(this.button5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(24, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(558, 30);
            this.panel8.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(1, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(448, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(455, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 21);
            this.button5.TabIndex = 2;
            this.button5.Text = "Neue Liste�";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.button12);
            this.panel9.Controls.Add(this.button13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(24, 170);
            this.panel9.TabIndex = 16;
            // 
            // button12
            // 
            appearance7.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.ImageAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.arrow_down;
            this.button12.Appearance = appearance7;
            this.button12.BackgroundImage = global::Lyra2.LyraShell.Properties.Resources.pfeilDown;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button12.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance6.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.arrow_down_over;
            this.button12.HotTrackAppearance = appearance6;
            this.button12.Location = new System.Drawing.Point(5, 136);
            this.button12.Name = "button12";
            appearance9.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.arrow_down_down;
            this.button12.PressedAppearance = appearance9;
            this.button12.ShowFocusRect = false;
            this.button12.ShowOutline = false;
            this.button12.Size = new System.Drawing.Size(13, 37);
            this.button12.TabIndex = 7;
            this.button12.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.button12.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.button12.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ImageAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.arrow_up;
            appearance4.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.button13.Appearance = appearance4;
            this.button13.BackgroundImage = global::Lyra2.LyraShell.Properties.Resources.pfeilUp;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button13.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance5.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.arrow_up_over;
            this.button13.HotTrackAppearance = appearance5;
            this.button13.Location = new System.Drawing.Point(5, 88);
            this.button13.Name = "button13";
            appearance8.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.arrow_up_down;
            this.button13.PressedAppearance = appearance8;
            this.button13.ShowFocusRect = false;
            this.button13.ShowOutline = false;
            this.button13.Size = new System.Drawing.Size(13, 37);
            this.button13.TabIndex = 8;
            this.button13.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.button13.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.button13.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // songPreview2
            // 
            this.songPreview2.AutoScroll = true;
            this.songPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songPreview2.Location = new System.Drawing.Point(0, 0);
            this.songPreview2.Name = "songPreview2";
            this.songPreview2.Size = new System.Drawing.Size(582, 71);
            this.songPreview2.TabIndex = 0;
            // 
            // panel7
            // 
            appearance3.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.right_pane_bg;
            appearance3.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(110, 100, 1, 350);
            appearance3.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.panel7.Appearance = appearance3;
            // 
            // panel7.ClientArea
            // 
            this.panel7.ClientArea.Controls.Add(this.linkLabel1);
            this.panel7.ClientArea.Controls.Add(this.button6);
            this.panel7.ClientArea.Controls.Add(this.button4);
            this.panel7.ClientArea.Controls.Add(this.label3);
            this.panel7.ClientArea.Controls.Add(this.textBox3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(582, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(112, 245);
            this.panel7.TabIndex = 14;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Orange;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(10, 144);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(24, 18);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "<<";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Click += new System.EventHandler(this.button10_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 27);
            this.button6.TabIndex = 3;
            this.button6.Text = "Lied entfernen";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 46);
            this.button4.TabIndex = 1;
            this.button4.Text = "Anzeigen!";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(10, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lied hinzuf�gen";
            // 
            // textBox3
            // 
            this.textBox3.DefaultText = "Nummer";
            this.textBox3.ForeColor = System.Drawing.Color.DimGray;
            this.textBox3.Location = new System.Drawing.Point(34, 144);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 21);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "Nummer";
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
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
            this.menuItem13.Text = "�&bernehmen!";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Enabled = false;
            this.menuItem14.Index = 1;
            this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15});
            this.menuItem14.Text = "�nderungen &verwerfen!";
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
            this.menuItem18.Text = "Ex&portieren�";
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
            this.menuItem35.Text = "&Pr�sentationsmodus";
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
            this.menuItem21.Text = "HTML Seite generieren�";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 4;
            this.menuItem51.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem52,
            this.menuItem69});
            this.menuItem51.Text = "Unformatierter Text�";
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 0;
            this.menuItem52.Text = "Ausgew�hlter Song";
            this.menuItem52.Click += new System.EventHandler(this.menuItem52_Click);
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 1;
            this.menuItem69.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem68,
            this.menuItem53});
            this.menuItem69.Text = "Alle Songs";
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 0;
            this.menuItem68.Text = "Titel-Index";
            this.menuItem68.Click += new System.EventHandler(this.menuItem68_Click);
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 1;
            this.menuItem53.Text = "Komplett";
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
            this.menuItem41.Text = "Letztes Update &r�ckg�ngig machen";
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
            this.menuItem44.Text = "Dateien f�r Update-&Server erstellen";
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
            this.menuItem50.Text = "f�r bestehenden Server...";
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
            this.menuItem34.Text = "Liste f�r &Pocket PC...";
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
            this.menuItem42.Text = "&Vorbereiten f�r Lyra 2.0";
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 10;
            this.menuItem47.Text = "-";
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 11;
            this.menuItem48.Text = "Lyra neu starten! (ohne �bernehmen)";
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
            this.menuItem3.Text = "&Optionen�";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 2;
            this.menuItem57.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem59,
            this.menuItem65,
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
            // menuItem65
            // 
            this.menuItem65.Index = 1;
            this.menuItem65.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.menuItem65.Text = "Fernsteuerung";
            this.menuItem65.Click += new System.EventHandler(this.menuItem65_Click);
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
            this.menuItem55.Text = "Prim�r";
            this.menuItem55.Click += new System.EventHandler(this.menuItem55_Click);
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 1;
            this.menuItem56.Text = "Sekund�r";
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
            this.menuItem26.Text = "&Anzeigen!";
            this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 1;
            this.menuItem23.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem28});
            this.menuItem23.Text = "Liste &l�schen";
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
            this.menuItem11.Text = "Neue Liste�";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 4;
            this.menuItem22.Text = "Liste &importieren�";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 5;
            this.menuItem12.Text = "Liste &exportieren�";
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
            this.menuItem37.Text = "Pr�sentation b&eenden";
            this.menuItem37.Visible = false;
            this.menuItem37.Click += new System.EventHandler(this.menuItem35_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 271);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(702, 18);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "d";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "cur state/action";
            this.statusBarPanel1.Width = 250;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
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
            this.menuItem6.Text = "&Anzeigen!";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "&Editieren�";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 2;
            this.menuItem39.Text = "&L�schen";
            this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "Zu aktueller &Liste hinzuf�gen";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 4;
            this.menuItem25.Text = "�berse&tzungen";
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem60,
            this.menuItem66,
            this.menuItem67,
            this.menuItem9});
            // 
            // menuItem60
            // 
            this.menuItem60.Index = 0;
            this.menuItem60.Text = "&Anzeigen!";
            this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 1;
            this.menuItem66.Text = "&Editieren�";
            this.menuItem66.Click += new System.EventHandler(this.menuItem66_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 2;
            this.menuItem67.Text = "&L�schen";
            this.menuItem67.Click += new System.EventHandler(this.menuItem67_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "Zu aktueller &Liste hinzuf�gen";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // GUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(702, 289);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "GUI";
            this.Text = "lyra";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.MeGotFocus);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Exit);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.searchSplitter.Panel1.ResumeLayout(false);
            this.searchSplitter.Panel2.ResumeLayout(false);
            this.searchSplitter.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.searchPaneTop.ResumeLayout(false);
            this.searchPaneTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ClientArea.ResumeLayout(false);
            this.panel1.ClientArea.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.allSongsSplitter.Panel1.ResumeLayout(false);
            this.allSongsSplitter.Panel2.ResumeLayout(false);
            this.allSongsSplitter.ResumeLayout(false);
            this.controlPaneRight.ClientArea.ResumeLayout(false);
            this.controlPaneRight.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.persListSplitter.Panel1.ResumeLayout(false);
            this.persListSplitter.Panel2.ResumeLayout(false);
            this.persListSplitter.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ClientArea.ResumeLayout(false);
            this.panel7.ClientArea.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public static bool DEBUG;

        // Activated -> assure, that the open Editor gets focus back!
        private void MeGotFocus(object sender, EventArgs e)
        {
            if (Editor.open)
            {
                Editor.editor.Focus();
            }
            if (this.curItem != -1)
                this.allSongsListBox.SelectedIndex = this.curItem;
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.mainSearchBox.Focus();
                this.mainSearchBox.SelectAll();
            }
        }

        //deavtivated
        private void DeactivateMe(object sender, EventArgs e)
        {
            this.curItem = this.allSongsListBox.SelectedIndex;
        }

        // onDoubleClick on listElement
        private void listBox1_dblClick(object sender, EventArgs e)
        {
            try
            {
                if (this.allSongsListBox.SelectedItems.Count == 1)
                {
                    Util.CTRLSHOWNR = Util.SHOWNR;
                    View.ShowSong((ISong)this.allSongsListBox.SelectedItem, this, this.allSongsListBox);
                }
            }
            catch (ToManyViews ex)
            {
                Util.MBoxError(ex.Message, ex);
            }
        }

        // Suche::onDoubleClick on listElement
        private void listBox3_dblClick(object sender, EventArgs e)
        {
            if (this.searchListBox.SelectedItem is ISong)
            {
                try
                {
                    if (this.searchListBox.SelectedItems.Count == 1)
                    {
                        Util.CTRLSHOWNR = Util.SHOWNR;
                        View.ShowSong((ISong)this.searchListBox.SelectedItem, this, this.searchListBox);
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Editor.open)
            {
                (new Editor(null, this)).Show();
            }
            else
            {
                Editor.editor.Focus();
            }
            this.songPreview1.Reset();
        }

        // edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.allSongsListBox.SelectedItems.Count == 1 && !Editor.open)
            {
                (new Editor((ISong)this.allSongsListBox.SelectedItem, this)).Show();
            }
            else if (Editor.open)
            {
                Editor.editor.Focus();
            }
        }

        // del
        private void button9_Click(object sender, EventArgs e)
        {
            if (this.allSongsListBox.SelectedItems.Count == 1)
            {
                ((ISong)this.allSongsListBox.SelectedItem).Delete();
                this.UpdateListBox();
                this.ToUpdate(true);
                this.songPreview1.Reset();
            }
        }

        // anzeigen
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.allSongsListBox.SelectedItems.Count == 1)
                {
                    Util.CTRLSHOWNR = Util.SHOWNR;
                    View.ShowSong((ISong)this.allSongsListBox.SelectedItem, this, this.allSongsListBox);
                }
            }
            catch (ToManyViews ex)
            {
                Util.MBoxError(ex.Message, ex);
            }
        }

        public ISong quickload(string nrstr)
        {
            try
            {
                int nr = Int32.Parse(nrstr);
                return this.storage.getSong(nr);
            }
            catch
            {
            }
            return null;
        }

        // Quickload
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int nr = Int32.Parse(this.textBox1.Text);
                ISong toShow = this.storage.getSong(nr);
                if (toShow != null)
                {
                    try
                    {
                        Util.CTRLSHOWNR = !((KeyEventArgs)e).Control;
                    }
                    catch (Exception)
                    {
                        Util.CTRLSHOWNR = Util.SHOWNR;
                    }
                    View.ShowSong(toShow, this, this.allSongsListBox);
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
        private void menuItem5_Click(object sender, EventArgs e)
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
                    "Vor dem Beenden �nderungen �bernehmen?",
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
        private void Exit(object sender, CancelEventArgs args)
        {
            args.Cancel = this.CheckOnExit();
        }

        // beenden aus Men�
        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        // �bernehmen
        private void menuItem13_Click(object sender, EventArgs e)
        {
            if (!Util.NOCOMMIT)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Enabled = false;
                if (this.storage.Commit())
                {
                    this.ToUpdate(false);
                    this.ResetSearch();
                    this.Status = "�nderungen erfolgreich �bernommen...";
                    Util.DELALL = false;
                }
                else
                {
                    Util.MBoxError("Fehler beim �bernehmen!");
                    this.Status = "Fehler beim �bernehmen!";
                }
                this.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                Util.MBoxError("Sie haben keine Berechtigung, �nderungen vorzunehmen!\n" +
                               "Entfernen Sie unter Extras->Optionen..., Allgemein... den Schreibschutz\n" +
                               "oder wenden Sie sich an den Administrator.");
                this.Status = "Fehler beim �bernehmen!";
            }
        }

        private void ResetSearch()
        {
            this.searchListBox.Items.Clear();
            this.searchListBox.ResetSearchTags();
            this.resultsLabel.Text = "";
            this.mainSearchBox.Text = "Suchbegriffe";
            this.mainSearchBox.ForeColor = Color.DimGray;
            this.label4.Visible = false;
        }

        // �nderungen verwerfen -> ok
        private void menuItem15_Click(object sender, EventArgs e)
        {
            this.storage.ResetToLast();
            this.ResetSearch();
            Util.DELALL = false;
            this.Status = "�nderungen verworfen!";
        }

        // exportieren
        private void menuItem18_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Dateien (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            sfd.OverwritePrompt = true;
            sfd.Title = "In XML-Datei exportieren";
            DialogResult dr = sfd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.Status = this.storage.Export(sfd.FileName) ? "Export erfolgreich! :-)" : "Beim Exportieren ging leider etwas schief. :-(";
            }
        }

        // import XML
        private void menuItem30_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Dateien (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.Title = "XML-Datei importieren";
            DialogResult dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                string msg = "Sollen die Lieder der aktuellen Sammlung hinzugef�gt werden?\n";
                msg += "(dr�cken Sie \"Nein\", falls die aktuellen Liedtexte gel�scht werden sollen)";
                DialogResult app = MessageBox.Show(this, msg,
                                                   "lyra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool res;
                if (app == DialogResult.Yes)
                {
                    res = this.storage.Import(ofd.FileName, true);
                }
                else
                {
                    Util.DELALL = true;
                    res = this.storage.Import(ofd.FileName, false);
                }
                this.storage.displaySongs(this.allSongsListBox);
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
        private void menuItem31_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Beachten Sie bitte, dass die LTX-Datei UTF-8-codiert sein muss." + Util.NL +
                                  "Sie k�nnen mit dem Converter-Tool ({lyra}\\Converter\\) selber LTX-Dateien generieren!" +
                                  Util.NL +
                                  "Mehr dazu finden Sie in der Hilfe (F1).",
                            "lyra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "LTX Dateien (*.ltx)|*.ltx|Alle Dateien (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.Title = "LTX-Datei importieren";
            DialogResult dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                string msg = "Sollen die Lieder der aktuellen Sammlung hinzugef�gt werden?\n";
                msg += "(dr�cken Sie \"Nein\", falls die aktuellen Liedtexte gel�scht werden sollen)";
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
                string line;
                int nr = 0;
                bool intext = false;
                while ((line = reader.ReadLine()) != null)
                {
                    string title = "";
                    if (intext)
                    {
                        string text = "";
                        if (line.EndsWith("#END"))
                        {
                            text += line.Substring(0, line.Length - 4);
                            ISong song = new Song(nr, title, text, "s" + Util.toFour(nr), "", true);
                            text = title = "";
                            intext = false;
                            try
                            {
                                this.storage.AddSong(song);
                            }
                            catch (ArgumentException)
                            {
                                string msg = "Wollen Sie Lied Nr." + nr + " ersetzen?\n";
                                msg += "(dr�cken Sie \"abbrechen\", wenn Sie das Lied �berspringen wollen.)";
                                DialogResult dr =
                                    MessageBox.Show(this, msg,
                                                    "lyra import", MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question);
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
                this.storage.displaySongs(this.allSongsListBox);
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
        // Kontextmen�
        private void listBox1_click(object sender, MouseEventArgs e)
        {
            if (this.prback == null)
            {
                int i = this.allSongsListBox.IndexFromPoint(e.X, e.Y);
                this.menuItem8.Visible = (this.comboBox1.Items.Count > 0);

                if (i != -1)
                {
                    this.allSongsListBox.SetSelected(i, true);
                    try
                    {
                        this.contextMenu1.MenuItems.RemoveAt(4);
                    }
                    catch (Exception)
                    {
                    }

                    if (((ISong)this.allSongsListBox.SelectedItem).TransMenu != null)
                        this.contextMenu1.MenuItems.Add(((ISong)this.allSongsListBox.SelectedItem).TransMenu);
                }
                if (e.Button == MouseButtons.Right && this.allSongsListBox.SelectedItems.Count == 1)
                {
                    this.contextMenu1.Show(this.allSongsListBox, new Point(e.X, e.Y));
                }
            }
        }

        // Kontextmen� Suche
        private void listBox3_click(object sender, MouseEventArgs e)
        {
            if (this.comboBox1.Items.Count > 0 && this.prback == null)
            {
                int i = this.searchListBox.IndexFromPoint(e.X, e.Y);
                if (e.Button == MouseButtons.Right && i != -1 &&
                    this.searchListBox.Items[i].ToString().Substring(0, 4) != "Leid")
                {
                    this.searchListBox.SelectedIndex = i;
                    this.contextMenu2.Show(this.searchListBox, new Point(e.X, e.Y));
                }
            }
        }

        // context-menu search list

        /// <summary>
        /// anzeigen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem60_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.searchListBox.SelectedItems.Count == 1)
                {
                    Util.CTRLSHOWNR = Util.SHOWNR;
                    View.ShowSong((ISong)this.searchListBox.SelectedItem, this, this.searchListBox);
                }
            }
            catch (ToManyViews ex)
            {
                Util.MBoxError(ex.Message, ex);
            }
        }

        /// <summary>
        /// editieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem66_Click(object sender, EventArgs e)
        {
            if (!Editor.open)
                (new Editor((ISong)this.searchListBox.SelectedItem, this)).Show();
            else
                Editor.editor.Focus();
        }

        /// <summary>
        /// l�schen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem67_Click(object sender, EventArgs e)
        {
            ((ISong)this.searchListBox.SelectedItem).Delete();
            this.searchListBox.BeginUpdate();
            this.searchListBox.Items.RemoveAt(this.searchListBox.SelectedIndex);
            this.searchListBox.EndUpdate();
            this.ToUpdate(true);
            this.songPreview3.Reset();
        }

        // anzeigen
        private void menuItem6_Click(object sender, EventArgs e)
        {
            Util.CTRLSHOWNR = Util.SHOWNR;
            this.button3_Click(sender, e);
        }

        // edit
        private void menuItem7_Click(object sender, EventArgs e)
        {
            if (!Editor.open)
                (new Editor((ISong)this.allSongsListBox.SelectedItem, this)).Show();
            else
                Editor.editor.Focus();
        }

        // del
        private void menuItem39_Click(object sender, EventArgs e)
        {
            ((ISong)this.allSongsListBox.SelectedItem).Delete();
            this.UpdateListBox();
            this.ToUpdate(true);
            this.songPreview1.Reset();
        }


        /// <summary>
        /// Util
        /// </summary>
        public void AddSong(ISong song)
        {
            this.storage.AddSong(song);
        }

        public void UpdateListBox()
        {
            this.storage.displaySongs(this.allSongsListBox);
            this.persLists.Refresh(this.personalListsListBox);
            this.songPreview1.Reset();
            this.songPreview2.Reset();
        }

        public void ToUpdate(bool update)
        {
            this.menuItem13.Enabled = update;
            this.menuItem14.Enabled = update;
            this.storage.ToBeCommited = update;
        }

        // Search
        private void button8_Click(object sender, EventArgs e)
        {
            this.searchTask.CancelTask();
            this.executeSearch();
        }

        private void executeSearch()
        {
            if (this.mainSearchBox.Text != "" && this.mainSearchBox.Text != "Suchbegriffe")
            {
                try
                {
                    this.storage.Search(this.mainSearchBox.Text, this.searchListBox, !this.checkBox1.Checked,
                                        false, this.checkBox3.Checked, false);
                    this.label4.Visible = this.storage.ToBeCommited;
                }
                catch (Exception ex)
                {
                    Util.MBoxError(
                        "Ihre Suchanfrage hat einen Fehler verursacht.\nIn der Hilfe (F1) finden Sie eine Anleitung.",
                        ex);
                }
            }
            int res = this.searchListBox.Items.Count;
            switch (res)
            {
                case 0:
                    this.resultsLabel.Text = "Keine Resultate!";
                    break;
                case 1:
                    this.resultsLabel.Text = "Ein Resultat";
                    break;
                default:
                    this.resultsLabel.Text = res + " Resultate";
                    break;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs ke)
        {
            if (ke.KeyCode == Keys.Enter)
            {
                this.searchTask.CancelTask();
                this.executeSearch();
            }
            else if (ke.KeyCode == Keys.Delete)
            {
                if (this.mainSearchBox.SelectionStart + this.mainSearchBox.SelectionLength == this.mainSearchBox.Text.Length)
                {
                    this.ResetQuery();
                    ke.Handled = true;
                }
            }
        }

        private void ResetQuery()
        {
            this.songPreview3.Reset();
            this.searchListBox.Items.Clear();
            this.searchListBox.ResetSearchTags();
            this.mainSearchBox.Text = "";
            this.searchListBox.Focus();
            this.resultsLabel.Text = "";
        }

        public string Status
        {
            set { this.statusBarPanel1.Text = value; }
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        // Optionen
        private void menuItem3_Click(object sender, EventArgs e)
        {
            Options.ShowOptions();
        }

        /**
		 * MyLists
		 */
        // MyLists-Change
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.persLists.setCurrent((MyList)this.comboBox1.SelectedItem, this.personalListsListBox);
            this.songPreview2.Reset();
            this.Status = "";
        }

        // anzeigen
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.personalListsListBox.Items.Count > 0)
            {
                try
                {
                    Util.CTRLSHOWNR = Util.SHOWNR;
                    int ind = (this.personalListsListBox.SelectedIndex > 0) ? this.personalListsListBox.SelectedIndex : 0;
                    View.ShowSong((ISong)this.personalListsListBox.Items[ind], this, this.personalListsListBox);
                }
                catch (ToManyViews ex)
                {
                    Util.MBoxError(ex.Message, ex);
                }
            }
        }

        // up
        private void button13_Click(object sender, EventArgs e)
        {
            if (this.personalListsListBox.SelectedItems.Count == 1)
            {
                int i = this.persLists.MoveSongUp(this.personalListsListBox.SelectedIndex);
                this.persLists.Refresh(this.personalListsListBox);
                this.personalListsListBox.SelectedIndex = i;
            }
        }

        // down
        private void button12_Click(object sender, EventArgs e)
        {
            if (this.personalListsListBox.SelectedItems.Count == 1)
            {
                int i = this.persLists.MoveSongDown(this.personalListsListBox.SelectedIndex);
                this.persLists.Refresh(this.personalListsListBox);
                this.personalListsListBox.SelectedIndex = i;
            }
        }

        // hinzuf�gen (aus Liste)
        private void menuItem8_Click(object sender, EventArgs e)
        {
            this.persLists.AddSongToCurrent((ISong)this.allSongsListBox.SelectedItem);
            this.persLists.Refresh(this.personalListsListBox);
            this.Status = "Song hinzugef�gt.";
            this.songPreview2.Reset();
        }

        // hinzuf�gen (aus Suche)
        private void menuItem9_Click(object sender, EventArgs e)
        {
            this.persLists.AddSongToCurrent((ISong)this.searchListBox.SelectedItem);
            this.persLists.Refresh(this.personalListsListBox);
            this.Status = "Song hinzugef�gt.";
            this.songPreview2.Reset();
        }

        // entfernen
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.personalListsListBox.SelectedItems.Count == 1)
            {
                this.persLists.RemoveSongFromCurrent(this.personalListsListBox.SelectedIndex);
                this.persLists.Refresh(this.personalListsListBox);
                this.Status = "Song entfernt.";
                this.songPreview2.Reset();
            }
        }

        // Listen-Men�
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.menuItem10.Visible = (this.tabControl1.SelectedIndex == 2) && (this.prback == null);
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.mainSearchBox.Focus();
                this.mainSearchBox.SelectAll();
            }
            this.label4.Visible = this.storage.ToBeCommited;
        }

        // anzeigen! (Men�)
        private void menuItem26_Click(object sender, EventArgs e)
        {
            this.button4_Click(sender, e);
        }

        // l�sche Liste (Men�)
        private void menuItem28_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Items.Count == 1)
            {
                MessageBox.Show(this,
                                "Liste kann nicht gel�scht werden!" + Util.NL +
                                "(mindestens eine Liste muss vorhanden sein)",
                                "lyra Warnung",
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
                    this.personalListsListBox.Items.Clear();
                    this.comboBox1.Text = "";
                }
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

        private void menuItem11_Click(object sender, EventArgs e)
        {
            NewList.ShowNewList(this);
            this.songPreview2.Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.menuItem11_Click(sender, e);
        }

        // import Liste
        private void menuItem22_Click(object sender, EventArgs e)
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
        private void menuItem12_Click(object sender, EventArgs e)
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
                    ((MyList)this.comboBox1.SelectedItem).exportMe(writer);
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
        private void menuItem21_Click(object sender, EventArgs e)
        {
            ListBox box = null;
            string idtext = "";
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    box = this.searchListBox;
                    idtext = "Suchabfrage </b>[";
                    if (this.mainSearchBox.Text.Equals("Suchbegriffe..."))
                    {
                        idtext += "leer]";
                    }
                    else
                    {
                        if (this.checkBox1.Checked) idtext += "nur Titel,";
                        if (this.checkBox3.Checked) idtext += "ganzes Wort,";
                        if (idtext[idtext.Length - 1] == ',') idtext = idtext.Substring(0, idtext.Length - 1);
                        idtext += "]:" + Util.HTMLNL + "<b>\"" + this.mainSearchBox.Text + "\"";
                    }
                    break;
                case 1:
                    box = this.allSongsListBox;
                    idtext = "ganze Liste";
                    break;
                case 2:
                    box = this.personalListsListBox;
                    idtext = "pers&ouml;nliche Liste:" + Util.HTMLNL + this.comboBox1.SelectedItem.ToString();
                    break;
            }
            HTML.showHTML(this, box, idtext);
        }

        // Debugging
        private void menuItem32_Click(object sender, EventArgs e)
        {
            DebugConsole.ShowDebugConsole(this);
        }


        // add song directly to list by nr
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int curpos = this.personalListsListBox.SelectedIndex;
                int nr = Int32.Parse(this.textBox3.Text);
                ISong addSong = this.storage.getSong(nr);
                if (addSong != null)
                {
                    this.persLists.AddSongToCurrent(addSong);
                    this.persLists.MoveLast(curpos);
                    this.persLists.Refresh(this.personalListsListBox);
                    this.Status = "Song hinzugef�gt.";
                }
                else
                {
                    this.Status = "Song nicht gefunden.";
                    Util.MBoxError("Lied konnte nicht gefunden werden!");
                }
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
        private void textBox3_Click(object sender, EventArgs e)
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
        private void menuItem33_Click(object sender, EventArgs e)
        {
            Info.showInfo(this);
        }

        // Pocket PC
        private void menuItem34_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "LPPC Datei (data.lppc)|*.lppc";
            sfd.FileName = "data.lppc";
            sfd.OverwritePrompt = true;
            sfd.Title = "Liste f�r Pocket PC generieren.";
            DialogResult dr = sfd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                if (this.storage.ExportPPC(sfd.FileName))
                {
                    this.Status = "Export f�r Pocket PC erfolgreich! :-)";
                }
                else
                {
                    this.Status = "Beim Exportieren f�r Pocket PC ging leider etwas schief. :-(";
                }
            }
        }

        #region Pr�sentationsmodus

        private PrBackground prback = null;

        private void menuItem35_Click(object sender, EventArgs e)
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
        }

        #endregion

        // update lyra
        private void menuItem38_Click(object sender, EventArgs e)
        {
            if (LyraUpdate.ShowUpdate(this) == DialogResult.OK)
            {
                MessageBox.Show(this, "Update wurde durchgef�hrt!" + Util.NL + "lyra wird jetzt neu gestartet.",
                                "lyra Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.restart();
            }
            // else cancelled
        }

        // rollback last update
        private void menuItem41_Click(object sender, EventArgs e)
        {
            File.Copy(LyraUpdateView.BACKUP, LyraUpdateView.CURTEXT, true);
            File.Delete(LyraUpdateView.BACKUP);
            if (MessageBox.Show(this,
                                "Listen ebenfalls wieder auf den Stand" + Util.NL +
                                "vor dem letzten Update zur�cksetzen?" +
                                Util.NL + Util.NL + "Vorsicht! Alle �nderungen seit dem letzten Update" + Util.NL +
                                "gehen verloren.",
                                "lyra Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Copy(LyraUpdateView.BACKUPLIST, LyraUpdateView.LISTFILE, true);
                File.Delete(LyraUpdateView.BACKUPLIST);
            }
            MessageBox.Show(this, "Update wurde r�ckg�ngig gemacht!" + Util.NL + "lyra wird jetzt neu gestartet.",
                            "lyra Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.restart();
        }

        // restart lyra
        private void restart()
        {
            // Shut down the current app instance
            Application.Exit();
            // Restart the app
            Process.Start(Application.ExecutablePath);
        }

        // restart lyra client
        private void menuItem48_Click(object sender, EventArgs e)
        {
            this.restart();
        }

        // create new Server
        private void menuItem49_Click(object sender, EventArgs e)
        {
        }

        // from existing Server
        private void menuItem50_Click(object sender, EventArgs e)
        {
        }

        private string[] formats =
            new string[] { "refrain", "special", "p8", "p16", "p24", "p32", "p40", "b", "i", "pagebreak", };

        private bool isFormat(string s)
        {
            s = s.TrimStart('/', ' ');
            foreach (string f in formats)
            {
                if (s.StartsWith(f))
                {
                    return true;
                }
            }
            return false;
        }

        private void showUnformated(ISong s)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Bitte geben Sie den Pfad f�r die Textdatei an!";
            sfd.Filter = "Textdatei|*.txt";
            sfd.FileName = "lyra_" + s.Number + ".txt";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName, false);
                string title = s.Number.ToString().PadRight(5, ' ') + ":  " + s.Title;
                string line = "".PadRight(title.Length, '-');
                sw.WriteLine(title);
                sw.WriteLine(line);
                sw.WriteLine();
                string text = "";
                for (int i = 0; i < s.Text.Length; i++)
                {
                    if (s.Text[i] == '<')
                    {
                        if (this.isFormat(s.Text.Substring(i + 1)))
                        {
                            if (s.Text.Substring(i + 1).StartsWith("refrain"))
                            {
                                text += "REFRAIN:" + Util.NL;
                            }
                            i = s.Text.IndexOf('>', i) + 1;
                        }
                    }
                    text += s.Text[i];
                }
                text = text.Replace("&gt;", ">").Replace("&lt;", "<").Replace("\n", "\r\n");
                sw.WriteLine(text);
                sw.Close();

                Process.Start("file://" + sfd.FileName);
            }
        }

        private void menuItem52_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                // search
                if (this.searchListBox.SelectedItem is ISong)
                {
                    ISong s = (ISong)this.searchListBox.SelectedItem;
                    this.showUnformated(s);
                    return;
                }
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                // selection
                if (this.allSongsListBox.SelectedItem is ISong)
                {
                    ISong s = (ISong)this.allSongsListBox.SelectedItem;
                    this.showUnformated(s);
                    return;
                }
            }
            else
            {
                // list selection
                if (this.personalListsListBox.SelectedItem is ISong)
                {
                    ISong s = (ISong)this.personalListsListBox.SelectedItem;
                    this.showUnformated(s);
                    return;
                }
            }
            MessageBox.Show(this, "Es ist kein Lied ausgew�hlt!", "Fehler!", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private void menuItem53_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Bitte geben Sie den Pfad f�r die Textdatei an!";
            sfd.Filter = "Textdatei|*.txt";
            sfd.FileName = "lyra_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName, false);

                foreach (ISong s in this.allSongsListBox.Items)
                {
                    string title = s.Number.ToString().PadRight(5, ' ') + ":  " + s.Title;
                    string line = "".PadRight(title.Length, '-');
                    sw.WriteLine(title);
                    sw.WriteLine(line);
                    sw.WriteLine();
                    string text = "";
                    for (int i = 0; i < s.Text.Length; i++)
                    {
                        if (s.Text[i] == '<')
                        {
                            if (this.isFormat(s.Text.Substring(i + 1)))
                            {
                                if (s.Text.Substring(i + 1).StartsWith("refrain"))
                                {
                                    text += "REFRAIN:" + Util.NL;
                                }
                                i = s.Text.IndexOf('>', i) + 1;
                            }
                        }
                        if (i < s.Text.Length) text += s.Text[i];
                    }
                    text = text.Replace("&gt;", ">").Replace("&lt;", "<").Replace("\n", "\r\n");
                    while (text.EndsWith("\r\n")) text = text.Substring(0, text.Length - 2);
                    sw.WriteLine(text);
                    sw.WriteLine();
                    sw.WriteLine();
                }
                sw.Close();

                Process.Start("file://" + sfd.FileName);
            }
        }


        private void menuItem55_Click(object sender, EventArgs e)
        {
            Util.SCREEN_ID = 0;
            View.display = Util.GetScreen(0);
            Util.updateRegSettings();
            this.menuItem55.Checked = true;
            this.menuItem56.Checked = false;
        }

        private void menuItem56_Click(object sender, EventArgs e)
        {
            Util.SCREEN_ID = 1;
            View.display = Util.GetScreen(1);
            Util.updateRegSettings();
            this.menuItem55.Checked = false;
            this.menuItem56.Checked = true;
        }

        private void menuItem61_Click(object sender, EventArgs e)
        {
            this.BlackScreen();
        }

        public void BlackScreen()
        {
            this.menuItem61.Checked = !this.menuItem61.Checked;
            View.BlackScreen(this.menuItem61.Checked);
        }

        private void menuItem57_Popup(object sender, EventArgs e)
        {
            this.menuItem61.Checked = View.black;
        }

        private void menuItem59_Click(object sender, EventArgs e)
        {
            History.ShowHistory(this);
        }

        private void listBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            ISong s = this.searchListBox.SelectedItem as ISong;
            if (s != null)
            {
                this.songPreview3.ShowSong(s);
                this.searchListBox.Focus();
            }
            else
            {
                this.songPreview3.Reset();
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ISong s = this.allSongsListBox.SelectedItem as ISong;
            if (s != null)
            {
                this.songPreview1.ShowSong(s);
                this.allSongsListBox.Focus();
            }
            else
            {
                this.songPreview1.Reset();
            }
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ISong s = this.personalListsListBox.SelectedItem as ISong;
            if (s != null)
            {
                this.songPreview2.ShowSong(s);
                this.personalListsListBox.Focus();
            }
            else
            {
                this.songPreview2.Reset();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.searchTask.RunTask(EventArgs.Empty);
            this.songPreview3.Reset();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.searchTask.CancelTask();
            this.executeSearch();
        }

        private void menuItem62_Click(object sender, EventArgs e)
        {
            View.CloseView();
        }


        private void menuItem63_Click(object sender, EventArgs e)
        {
            if (this.storage.ToBeCommited)
            {
                MessageBox.Show(this,
                                "Index konnte nicht neu gebildet werden!" + Util.NL +
                                "Bitte zuerst alle �nderungen �bernehmen oder verwerfen.",
                                "Suchindex erneuern...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.storage.cleanSearchIndex())
            {
                MessageBox.Show(this, "Index wurde erfolgreich neu gebildet.", "Suchindex erneuern...",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this,
                                "Index konnte nicht neu gebildet werden!" + Util.NL +
                                "Bitte lyra beenden und vor dem Neustart das Verzeichnis '<lyra>\\index' manuell l�schen.",
                                "Suchindex erneuern...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuItem65_Click(object sender, EventArgs e)
        {
            RemoteControl.ShowRemoteControl(this);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.listBox1_dblClick(sender, e);
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.listBox2_DoubleClick(sender, e);
            }
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.listBox3_dblClick(sender, e);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.personalListsListBox.SelectedIndex < 0)
            {
                this.songPreview2.Reset();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.allSongsListBox.SelectedIndex < 0)
            {
                this.songPreview1.Reset();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.searchListBox.SelectedIndex < 0)
            {
                this.songPreview3.Reset();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.songPreview3.Reset();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.ResetQuery();
        }

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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void menuItem68_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Bitte geben Sie den Pfad f�r die Titel-Index Datei an!";
            sfd.Filter = "Textdatei|*.txt";
            sfd.FileName = "lyra_titel_index_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName, false);
                string fileTitle = "Lyra Titel-Index " + DateTime.Now.ToString("ddMMyyyy") + "  [" + this.allSongsListBox.Items.Count + " Songs]";
                sw.WriteLine(fileTitle);
                sw.WriteLine("".PadRight(fileTitle.Length, '-'));
                sw.WriteLine();
                foreach (ISong s in this.allSongsListBox.Items)
                {
                    string title = s.Number.ToString().PadRight(5, ' ') + ":  " + s.Title;
                    sw.WriteLine(title);
                }
                sw.Close();

                Process.Start("file://" + sfd.FileName);
            }
        }
    }
}