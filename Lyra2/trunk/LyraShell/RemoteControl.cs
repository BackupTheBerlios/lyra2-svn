using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Infragistics.Win;
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
        private Infragistics.Win.Misc.UltraPanel remotePanel;
        private ListBox jumpMarksListBox;
        private Infragistics.Win.Misc.UltraButton lastBtn;
        private Infragistics.Win.Misc.UltraPanel bottomPanel;
        private Infragistics.Win.Misc.UltraPanel line;
        private Infragistics.Win.Misc.UltraButton nextBtn;
        private Label nrLabel;
        private Label curSongLabel;
        private Label prevLabel;
        private Label nextLabel;
        private Panel mainPane;
        private Label jumperLabel;
        private Panel scrollPane;
        private Infragistics.Win.Misc.UltraButton scrollUpwardsBtn;
        private Infragistics.Win.Misc.UltraButton jumpTopBtn;
        private Infragistics.Win.Misc.UltraButton jumpEndBtn;
        private Infragistics.Win.Misc.UltraButton scrollDownwardsBtn;
        private Infragistics.Win.Misc.UltraPanel scrollBox;
        private Infragistics.Win.Misc.UltraLabel titleLabel;
        private PictureBox scrollImage;

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

        private readonly BackgroundWorker bgw = new BackgroundWorker();
		private RemoteControl(GUI owner)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
			this.owner = owner;
			this.Closing += RemoteControl_Closing;
            View.SongDisplayed += ViewSongDisplayed;
            this.Update(View.CurrentSongInfo);
            this.scrollBox.ClientArea.MouseEnter += ScroolBoxEnterHandler;
            this.scrollBox.ClientArea.MouseLeave += ScrollBoxLeaveHandler;
            bgw.DoWork += UnblinkWork;
            bgw.WorkerSupportsCancellation = true;
		}

        void UnblinkWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            if (!e.Cancel)
            {
                this.Invoke(new MethodInvoker(() => this.scrollImage.Visible = false));
            }
        }

	    private bool doScroll = false;

        private void ScrollBoxLeaveHandler(object sender, EventArgs e)
        {
            this.doScroll = false;
        }

        private void ScroolBoxEnterHandler(object sender, EventArgs e)
        {
            this.doScroll = true;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            #region    Precondition

            if(!this.doScroll) return;

            #endregion Precondition

            if (e.Delta < 0)
            {
                // down
                this.scrollDownBtn_Click(this, e);
                this.ScrollBoxBlink(true);
            }
            else
            {
                this.scrollUpBtn_Click(this, e);
                this.ScrollBoxBlink(false);
            }
            
        }
        
        private void ScrollBoxBlink(bool down)
        {
            this.scrollImage.Image = down ? Properties.Resources.scroll_down_bg : Properties.Resources.scroll_up_bg;
            this.scrollImage.Visible = true;
            if (!this.bgw.IsBusy)
            {
                this.bgw.RunWorkerAsync(Color.DimGray);
            }
            
        }

        private void ViewSongDisplayed(object sender, SongDisplayedEventArgs args)
        {
            this.Update(args);
        }

        private void Update(SongDisplayedEventArgs songInfo)
        {
            if (songInfo == null)
            {
                this.titleLabel.Text = "";
                this.nrLabel.Text = "n/a";
                this.nextBtn.Enabled = false;
                this.lastBtn.Enabled = false;
                this.nextLabel.Text = "";
                this.prevLabel.Text = "";
                this.jumpMarksListBox.Items.Clear();
                return;
            }

            this.titleLabel.Text = songInfo.DisplayedSong != null ? songInfo.DisplayedSong.Title : "";
            this.nrLabel.Text = songInfo.DisplayedSong != null ? songInfo.DisplayedSong.Number.ToString().PadLeft(4, '0') : "n/a";
            this.nextBtn.Enabled = songInfo.NextSong != null;
            this.lastBtn.Enabled = songInfo.PreviousSong != null;
            this.nextLabel.Text = songInfo.NextSong != null ? songInfo.NextSong.Number.ToString().PadLeft(4,'0') : "";
            this.prevLabel.Text = songInfo.PreviousSong != null ? songInfo.PreviousSong.Number.ToString().PadLeft(4, '0') : "";
            this.jumpMarksListBox.BeginUpdate();
            this.jumpMarksListBox.Items.Clear();
            foreach (JumpMark jumpMark in songInfo.Jumpmarks)
            {
                this.jumpMarksListBox.Items.Add(jumpMark);
            }
            this.jumpMarksListBox.EndUpdate();
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
                View.SongDisplayed -= ViewSongDisplayed;
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.remotePanel = new Infragistics.Win.Misc.UltraPanel();
            this.mainPane = new System.Windows.Forms.Panel();
            this.jumpMarksListBox = new System.Windows.Forms.ListBox();
            this.jumperLabel = new System.Windows.Forms.Label();
            this.scrollPane = new System.Windows.Forms.Panel();
            this.scrollBox = new Infragistics.Win.Misc.UltraPanel();
            this.jumpEndBtn = new Infragistics.Win.Misc.UltraButton();
            this.scrollDownwardsBtn = new Infragistics.Win.Misc.UltraButton();
            this.scrollUpwardsBtn = new Infragistics.Win.Misc.UltraButton();
            this.jumpTopBtn = new Infragistics.Win.Misc.UltraButton();
            this.bottomPanel = new Infragistics.Win.Misc.UltraPanel();
            this.titleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.nrLabel = new System.Windows.Forms.Label();
            this.nextLabel = new System.Windows.Forms.Label();
            this.prevLabel = new System.Windows.Forms.Label();
            this.curSongLabel = new System.Windows.Forms.Label();
            this.line = new Infragistics.Win.Misc.UltraPanel();
            this.nextBtn = new Infragistics.Win.Misc.UltraButton();
            this.lastBtn = new Infragistics.Win.Misc.UltraButton();
            this.scrollImage = new System.Windows.Forms.PictureBox();
            this.remotePanel.ClientArea.SuspendLayout();
            this.remotePanel.SuspendLayout();
            this.mainPane.SuspendLayout();
            this.scrollPane.SuspendLayout();
            this.scrollBox.ClientArea.SuspendLayout();
            this.scrollBox.SuspendLayout();
            this.bottomPanel.ClientArea.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.line.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollImage)).BeginInit();
            this.SuspendLayout();
            // 
            // remotePanel
            // 
            // 
            // remotePanel.ClientArea
            // 
            this.remotePanel.ClientArea.Controls.Add(this.mainPane);
            this.remotePanel.ClientArea.Controls.Add(this.scrollPane);
            this.remotePanel.ClientArea.Controls.Add(this.bottomPanel);
            this.remotePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remotePanel.Location = new System.Drawing.Point(0, 0);
            this.remotePanel.Name = "remotePanel";
            this.remotePanel.Size = new System.Drawing.Size(468, 295);
            this.remotePanel.TabIndex = 11;
            // 
            // mainPane
            // 
            this.mainPane.Controls.Add(this.jumpMarksListBox);
            this.mainPane.Controls.Add(this.jumperLabel);
            this.mainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPane.Location = new System.Drawing.Point(72, 52);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(396, 243);
            this.mainPane.TabIndex = 12;
            // 
            // jumpMarksListBox
            // 
            this.jumpMarksListBox.FormattingEnabled = true;
            this.jumpMarksListBox.Items.AddRange(new object[] {
            "Test 1"});
            this.jumpMarksListBox.Location = new System.Drawing.Point(9, 19);
            this.jumpMarksListBox.Name = "jumpMarksListBox";
            this.jumpMarksListBox.Size = new System.Drawing.Size(376, 212);
            this.jumpMarksListBox.TabIndex = 0;
            // 
            // jumperLabel
            // 
            this.jumperLabel.AutoSize = true;
            this.jumperLabel.BackColor = System.Drawing.Color.Transparent;
            this.jumperLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumperLabel.ForeColor = System.Drawing.Color.DimGray;
            this.jumperLabel.Location = new System.Drawing.Point(6, 3);
            this.jumperLabel.Name = "jumperLabel";
            this.jumperLabel.Size = new System.Drawing.Size(103, 13);
            this.jumperLabel.TabIndex = 11;
            this.jumperLabel.Text = "Sprungmarken";
            // 
            // scrollPane
            // 
            this.scrollPane.Controls.Add(this.scrollBox);
            this.scrollPane.Controls.Add(this.jumpEndBtn);
            this.scrollPane.Controls.Add(this.scrollDownwardsBtn);
            this.scrollPane.Controls.Add(this.scrollUpwardsBtn);
            this.scrollPane.Controls.Add(this.jumpTopBtn);
            this.scrollPane.Dock = System.Windows.Forms.DockStyle.Left;
            this.scrollPane.Location = new System.Drawing.Point(0, 52);
            this.scrollPane.Name = "scrollPane";
            this.scrollPane.Size = new System.Drawing.Size(72, 243);
            this.scrollPane.TabIndex = 11;
            // 
            // scrollBox
            // 
            appearance1.BackColor = System.Drawing.Color.DimGray;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Rectangular;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.scrollBox.Appearance = appearance1;
            this.scrollBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1;
            // 
            // scrollBox.ClientArea
            // 
            this.scrollBox.ClientArea.Controls.Add(this.scrollImage);
            this.scrollBox.Location = new System.Drawing.Point(3, 93);
            this.scrollBox.Name = "scrollBox";
            this.scrollBox.Size = new System.Drawing.Size(64, 64);
            this.scrollBox.TabIndex = 13;
            // 
            // jumpEndBtn
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance6.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance6.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_enabled;
            appearance6.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 7);
            this.jumpEndBtn.Appearance = appearance6;
            appearance7.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_rollover;
            this.jumpEndBtn.HotTrackAppearance = appearance7;
            this.jumpEndBtn.Location = new System.Drawing.Point(5, 194);
            this.jumpEndBtn.Name = "jumpEndBtn";
            appearance8.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_pressed;
            this.jumpEndBtn.PressedAppearance = appearance8;
            this.jumpEndBtn.ShowFocusRect = false;
            this.jumpEndBtn.Size = new System.Drawing.Size(59, 27);
            this.jumpEndBtn.TabIndex = 12;
            this.jumpEndBtn.Text = "bottom";
            this.jumpEndBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.jumpEndBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.jumpEndBtn.Click += new System.EventHandler(this.scrollToEndBtn_Click);
            // 
            // scrollDownwardsBtn
            // 
            appearance15.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance15.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance15.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_enabled;
            appearance15.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 7);
            this.scrollDownwardsBtn.Appearance = appearance15;
            this.scrollDownwardsBtn.AutoRepeat = true;
            this.scrollDownwardsBtn.AutoRepeatInterval = 50;
            appearance16.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_rollover;
            this.scrollDownwardsBtn.HotTrackAppearance = appearance16;
            this.scrollDownwardsBtn.Location = new System.Drawing.Point(5, 161);
            this.scrollDownwardsBtn.Name = "scrollDownwardsBtn";
            appearance17.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_pressed;
            this.scrollDownwardsBtn.PressedAppearance = appearance17;
            this.scrollDownwardsBtn.ShowFocusRect = false;
            this.scrollDownwardsBtn.Size = new System.Drawing.Size(59, 27);
            this.scrollDownwardsBtn.TabIndex = 12;
            this.scrollDownwardsBtn.Text = "down";
            this.scrollDownwardsBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.scrollDownwardsBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.scrollDownwardsBtn.Click += new System.EventHandler(this.scrollDownBtn_Click);
            // 
            // scrollUpwardsBtn
            // 
            appearance18.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance18.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance18.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_enabled;
            appearance18.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 7);
            this.scrollUpwardsBtn.Appearance = appearance18;
            this.scrollUpwardsBtn.AutoRepeat = true;
            this.scrollUpwardsBtn.AutoRepeatInterval = 50;
            appearance19.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_rollover;
            this.scrollUpwardsBtn.HotTrackAppearance = appearance19;
            this.scrollUpwardsBtn.Location = new System.Drawing.Point(5, 60);
            this.scrollUpwardsBtn.Name = "scrollUpwardsBtn";
            appearance20.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_pressed;
            this.scrollUpwardsBtn.PressedAppearance = appearance20;
            this.scrollUpwardsBtn.ShowFocusRect = false;
            this.scrollUpwardsBtn.Size = new System.Drawing.Size(59, 27);
            this.scrollUpwardsBtn.TabIndex = 12;
            this.scrollUpwardsBtn.Text = "up";
            this.scrollUpwardsBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.scrollUpwardsBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.scrollUpwardsBtn.Click += new System.EventHandler(this.scrollUpBtn_Click);
            // 
            // jumpTopBtn
            // 
            appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance9.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance9.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_enabled;
            appearance9.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 7);
            this.jumpTopBtn.Appearance = appearance9;
            appearance10.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_rollover;
            this.jumpTopBtn.HotTrackAppearance = appearance10;
            this.jumpTopBtn.Location = new System.Drawing.Point(5, 27);
            this.jumpTopBtn.Name = "jumpTopBtn";
            appearance11.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_pressed;
            this.jumpTopBtn.PressedAppearance = appearance11;
            this.jumpTopBtn.ShowFocusRect = false;
            this.jumpTopBtn.Size = new System.Drawing.Size(58, 27);
            this.jumpTopBtn.TabIndex = 12;
            this.jumpTopBtn.Text = "top";
            this.jumpTopBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.jumpTopBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.jumpTopBtn.Click += new System.EventHandler(this.scrollToTopBtn_Click);
            // 
            // bottomPanel
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.GlassTop50;
            this.bottomPanel.Appearance = appearance21;
            // 
            // bottomPanel.ClientArea
            // 
            this.bottomPanel.ClientArea.Controls.Add(this.titleLabel);
            this.bottomPanel.ClientArea.Controls.Add(this.nrLabel);
            this.bottomPanel.ClientArea.Controls.Add(this.nextLabel);
            this.bottomPanel.ClientArea.Controls.Add(this.prevLabel);
            this.bottomPanel.ClientArea.Controls.Add(this.curSongLabel);
            this.bottomPanel.ClientArea.Controls.Add(this.line);
            this.bottomPanel.ClientArea.Controls.Add(this.nextBtn);
            this.bottomPanel.ClientArea.Controls.Add(this.lastBtn);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(468, 52);
            this.bottomPanel.TabIndex = 9;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance23.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance23.FontData.Name = "Verdana";
            appearance23.FontData.SizeInPoints = 9F;
            appearance23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(170)))));
            appearance23.TextHAlignAsString = "Left";
            appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord;
            appearance23.TextVAlignAsString = "Middle";
            this.titleLabel.Appearance = appearance23;
            this.titleLabel.Location = new System.Drawing.Point(50, 23);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(313, 23);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Titel";
            this.titleLabel.WrapText = false;
            // 
            // nrLabel
            // 
            this.nrLabel.BackColor = System.Drawing.Color.Transparent;
            this.nrLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrLabel.ForeColor = System.Drawing.Color.Black;
            this.nrLabel.Location = new System.Drawing.Point(5, 22);
            this.nrLabel.Name = "nrLabel";
            this.nrLabel.Size = new System.Drawing.Size(39, 23);
            this.nrLabel.TabIndex = 11;
            this.nrLabel.Text = "0009";
            this.nrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nextLabel
            // 
            this.nextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextLabel.BackColor = System.Drawing.Color.Transparent;
            this.nextLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLabel.ForeColor = System.Drawing.Color.DimGray;
            this.nextLabel.Location = new System.Drawing.Point(418, 5);
            this.nextLabel.Name = "nextLabel";
            this.nextLabel.Size = new System.Drawing.Size(47, 14);
            this.nextLabel.TabIndex = 11;
            this.nextLabel.Text = "next";
            this.nextLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // prevLabel
            // 
            this.prevLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prevLabel.BackColor = System.Drawing.Color.Transparent;
            this.prevLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevLabel.ForeColor = System.Drawing.Color.DimGray;
            this.prevLabel.Location = new System.Drawing.Point(369, 6);
            this.prevLabel.Name = "prevLabel";
            this.prevLabel.Size = new System.Drawing.Size(47, 13);
            this.prevLabel.TabIndex = 11;
            this.prevLabel.Text = "prev";
            this.prevLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // curSongLabel
            // 
            this.curSongLabel.AutoSize = true;
            this.curSongLabel.BackColor = System.Drawing.Color.Transparent;
            this.curSongLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curSongLabel.ForeColor = System.Drawing.Color.DimGray;
            this.curSongLabel.Location = new System.Drawing.Point(3, 3);
            this.curSongLabel.Name = "curSongLabel";
            this.curSongLabel.Size = new System.Drawing.Size(159, 13);
            this.curSongLabel.TabIndex = 11;
            this.curSongLabel.Text = "Aktuell angezeigter Song :";
            // 
            // line
            // 
            appearance22.BackColor = System.Drawing.Color.DimGray;
            this.line.Appearance = appearance22;
            this.line.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line.Location = new System.Drawing.Point(0, 51);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(468, 1);
            this.line.TabIndex = 1;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_enabled;
            appearance4.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 7);
            this.nextBtn.Appearance = appearance4;
            appearance5.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_rollover;
            this.nextBtn.HotTrackAppearance = appearance5;
            this.nextBtn.Location = new System.Drawing.Point(418, 21);
            this.nextBtn.Name = "nextBtn";
            appearance3.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_pressed;
            this.nextBtn.PressedAppearance = appearance3;
            this.nextBtn.ShowFocusRect = false;
            this.nextBtn.Size = new System.Drawing.Size(47, 27);
            this.nextBtn.TabIndex = 12;
            this.nextBtn.Text = ">>";
            this.nextBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.nextBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.nextBtn.Click += new System.EventHandler(this.nextSongBtn_Click);
            // 
            // lastBtn
            // 
            this.lastBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance12.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance12.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_enabled;
            appearance12.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 7);
            this.lastBtn.Appearance = appearance12;
            appearance13.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_rollover;
            this.lastBtn.HotTrackAppearance = appearance13;
            this.lastBtn.Location = new System.Drawing.Point(369, 21);
            this.lastBtn.Name = "lastBtn";
            appearance14.ImageBackground = global::Lyra2.LyraShell.Properties.Resources.button_pressed;
            this.lastBtn.PressedAppearance = appearance14;
            this.lastBtn.ShowFocusRect = false;
            this.lastBtn.Size = new System.Drawing.Size(47, 27);
            this.lastBtn.TabIndex = 12;
            this.lastBtn.Text = "<<";
            this.lastBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lastBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.lastBtn.Click += new System.EventHandler(this.previousSongBtn_Click);
            // 
            // scrollImage
            // 
            this.scrollImage.Location = new System.Drawing.Point(6, 5);
            this.scrollImage.Name = "scrollImage";
            this.scrollImage.Size = new System.Drawing.Size(48, 48);
            this.scrollImage.TabIndex = 12;
            this.scrollImage.TabStop = false;
            // 
            // RemoteControl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(468, 295);
            this.Controls.Add(this.remotePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(474, 319);
            this.MinimizeBox = false;
            this.Name = "RemoteControl";
            this.ShowInTaskbar = false;
            this.Text = "Fernsteuerung";
            this.remotePanel.ClientArea.ResumeLayout(false);
            this.remotePanel.ResumeLayout(false);
            this.mainPane.ResumeLayout(false);
            this.mainPane.PerformLayout();
            this.scrollPane.ResumeLayout(false);
            this.scrollBox.ClientArea.ResumeLayout(false);
            this.scrollBox.ResumeLayout(false);
            this.bottomPanel.ClientArea.ResumeLayout(false);
            this.bottomPanel.ClientArea.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.line.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrollImage)).EndInit();
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