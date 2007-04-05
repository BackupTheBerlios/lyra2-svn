namespace Lyra2
{
    partial class LyraGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LyraGUI));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.globalStateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.songView = new System.Windows.Forms.ListView();
            this.nrColHeader = new System.Windows.Forms.ColumnHeader();
            this.titleColHeader = new System.Windows.Forms.ColumnHeader();
            this.lastViewedColHeader = new System.Windows.Forms.ColumnHeader();
            this.songToolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.searchBox = new System.Windows.Forms.ToolStripTextBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.leftSplit = new System.Windows.Forms.SplitContainer();
            this.bookList = new Lyra2.NiceListBox();
            this.songCollectionList = new Lyra2.NiceListBox();
            this.leftTopPanel = new System.Windows.Forms.Panel();
            this.lyraTitlePic = new System.Windows.Forms.PictureBox();
            this.bookColHeader = new System.Windows.Forms.ColumnHeader();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.songToolStrip.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.leftSplit.Panel1.SuspendLayout();
            this.leftSplit.Panel2.SuspendLayout();
            this.leftSplit.SuspendLayout();
            this.leftTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lyraTitlePic)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalStateLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 515);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(945, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // globalStateLabel
            // 
            this.globalStateLabel.Name = "globalStateLabel";
            this.globalStateLabel.Size = new System.Drawing.Size(37, 17);
            this.globalStateLabel.Text = "Bereit";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(945, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem.Text = "Be&enden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "E&xtras";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testDialogToolStripMenuItem,
            this.showViewToolStripMenuItem,
            this.toolStripMenuItem2,
            this.infoToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            // 
            // testDialogToolStripMenuItem
            // 
            this.testDialogToolStripMenuItem.Name = "testDialogToolStripMenuItem";
            this.testDialogToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.testDialogToolStripMenuItem.Text = "Test Dialog";
            this.testDialogToolStripMenuItem.Click += new System.EventHandler(this.testDialogToolStripMenuItem_Click);
            // 
            // showViewToolStripMenuItem
            // 
            this.showViewToolStripMenuItem.Name = "showViewToolStripMenuItem";
            this.showViewToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.showViewToolStripMenuItem.Text = "Show View";
            this.showViewToolStripMenuItem.Click += new System.EventHandler(this.showViewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(130, 6);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.infoToolStripMenuItem.Text = "&Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.rightPanel);
            this.centerPanel.Controls.Add(this.leftPanel);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 24);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(945, 491);
            this.centerPanel.TabIndex = 4;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.songView);
            this.rightPanel.Controls.Add(this.songToolStrip);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(305, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(640, 491);
            this.rightPanel.TabIndex = 1;
            // 
            // songView
            // 
            this.songView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nrColHeader,
            this.titleColHeader,
            this.bookColHeader,
            this.lastViewedColHeader});
            this.songView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songView.GridLines = true;
            this.songView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.songView.HoverSelection = true;
            this.songView.Location = new System.Drawing.Point(0, 25);
            this.songView.MultiSelect = false;
            this.songView.Name = "songView";
            this.songView.Size = new System.Drawing.Size(640, 466);
            this.songView.TabIndex = 1;
            this.songView.UseCompatibleStateImageBehavior = false;
            this.songView.View = System.Windows.Forms.View.Details;
            // 
            // nrColHeader
            // 
            this.nrColHeader.Text = "Nr.";
            this.nrColHeader.Width = 35;
            // 
            // titleColHeader
            // 
            this.titleColHeader.Text = "Titel";
            this.titleColHeader.Width = 394;
            // 
            // lastViewedColHeader
            // 
            this.lastViewedColHeader.Text = "Zuletzt betrachtet";
            this.lastViewedColHeader.Width = 107;
            // 
            // songToolStrip
            // 
            this.songToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.songToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.searchBox});
            this.songToolStrip.Location = new System.Drawing.Point(0, 0);
            this.songToolStrip.Name = "songToolStrip";
            this.songToolStrip.Size = new System.Drawing.Size(640, 25);
            this.songToolStrip.TabIndex = 0;
            this.songToolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // searchBox
            // 
            this.searchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchBox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(200, 25);
            this.searchBox.Text = "Liedsuche";
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftPanel.BackgroundImage")));
            this.leftPanel.Controls.Add(this.leftSplit);
            this.leftPanel.Controls.Add(this.leftTopPanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(305, 491);
            this.leftPanel.TabIndex = 0;
            // 
            // leftSplit
            // 
            this.leftSplit.BackColor = System.Drawing.Color.Transparent;
            this.leftSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSplit.Location = new System.Drawing.Point(0, 84);
            this.leftSplit.Name = "leftSplit";
            this.leftSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftSplit.Panel1
            // 
            this.leftSplit.Panel1.Controls.Add(this.bookList);
            // 
            // leftSplit.Panel2
            // 
            this.leftSplit.Panel2.Controls.Add(this.songCollectionList);
            this.leftSplit.Size = new System.Drawing.Size(305, 407);
            this.leftSplit.SplitterDistance = 114;
            this.leftSplit.TabIndex = 0;
            // 
            // bookList
            // 
            this.bookList.ActiveColor1 = System.Drawing.Color.Lavender;
            this.bookList.ActiveColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.bookList.ActiveTitleFontColor = System.Drawing.Color.Peru;
            this.bookList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.bookList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.bookList.Filter = null;
            this.bookList.FormattingEnabled = true;
            this.bookList.InactiveColor1 = System.Drawing.Color.LightSlateGray;
            this.bookList.InactiveColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.bookList.InactiveTitleFontColor = System.Drawing.Color.LightGray;
            this.bookList.ItemHeight = 15;
            this.bookList.Location = new System.Drawing.Point(0, 0);
            this.bookList.Name = "bookList";
            this.bookList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.bookList.Size = new System.Drawing.Size(305, 114);
            this.bookList.TabIndex = 1;
            // 
            // songCollectionList
            // 
            this.songCollectionList.ActiveColor1 = System.Drawing.Color.Lavender;
            this.songCollectionList.ActiveColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.songCollectionList.ActiveTitleFontColor = System.Drawing.Color.Peru;
            this.songCollectionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.songCollectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songCollectionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.songCollectionList.Filter = null;
            this.songCollectionList.FormattingEnabled = true;
            this.songCollectionList.InactiveColor1 = System.Drawing.Color.LightSlateGray;
            this.songCollectionList.InactiveColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.songCollectionList.InactiveTitleFontColor = System.Drawing.Color.LightGray;
            this.songCollectionList.ItemHeight = 15;
            this.songCollectionList.Location = new System.Drawing.Point(0, 0);
            this.songCollectionList.Name = "songCollectionList";
            this.songCollectionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.songCollectionList.Size = new System.Drawing.Size(305, 289);
            this.songCollectionList.TabIndex = 0;
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.leftTopPanel.Controls.Add(this.lyraTitlePic);
            this.leftTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTopPanel.Location = new System.Drawing.Point(0, 0);
            this.leftTopPanel.Name = "leftTopPanel";
            this.leftTopPanel.Size = new System.Drawing.Size(305, 84);
            this.leftTopPanel.TabIndex = 0;
            // 
            // lyraTitlePic
            // 
            this.lyraTitlePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyraTitlePic.Image = ((System.Drawing.Image)(resources.GetObject("lyraTitlePic.Image")));
            this.lyraTitlePic.Location = new System.Drawing.Point(0, 0);
            this.lyraTitlePic.Name = "lyraTitlePic";
            this.lyraTitlePic.Size = new System.Drawing.Size(305, 84);
            this.lyraTitlePic.TabIndex = 0;
            this.lyraTitlePic.TabStop = false;
            // 
            // bookColHeader
            // 
            this.bookColHeader.Text = "Buch";
            this.bookColHeader.Width = 100;
            // 
            // LyraGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 537);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "LyraGUI";
            this.Text = "Lyra 2";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.centerPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.songToolStrip.ResumeLayout(false);
            this.songToolStrip.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftSplit.Panel1.ResumeLayout(false);
            this.leftSplit.Panel2.ResumeLayout(false);
            this.leftSplit.ResumeLayout(false);
            this.leftTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lyraTitlePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel leftTopPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.ToolStrip songToolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripTextBox searchBox;
        private System.Windows.Forms.SplitContainer leftSplit;
        private NiceListBox bookList;
        private NiceListBox songCollectionList;
        private System.Windows.Forms.ListView songView;
        private System.Windows.Forms.ColumnHeader nrColHeader;
        private System.Windows.Forms.ColumnHeader titleColHeader;
        private System.Windows.Forms.ColumnHeader lastViewedColHeader;
        private System.Windows.Forms.ToolStripStatusLabel globalStateLabel;
        private System.Windows.Forms.PictureBox lyraTitlePic;
        private System.Windows.Forms.ToolStripMenuItem testDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader bookColHeader;
    }
}

