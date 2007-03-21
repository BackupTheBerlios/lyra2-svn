namespace Lyra2
{
    partial class DefaultSongView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultSongView));
            this.browserDisplay = new System.Windows.Forms.WebBrowser();
            this.topPane = new System.Windows.Forms.Panel();
            this.btnPane = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.panelActivatorBtn = new System.Windows.Forms.PictureBox();
            this.forwardBtn = new Lyra2.ImageButton(this.components);
            this.backBtn = new Lyra2.ImageButton(this.components);
            this.lyraBtn = new Lyra2.ImageButton(this.components);
            this.topPane.SuspendLayout();
            this.btnPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelActivatorBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyraBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // browserDisplay
            // 
            this.browserDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserDisplay.Location = new System.Drawing.Point(0, 0);
            this.browserDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserDisplay.Name = "browserDisplay";
            this.browserDisplay.Size = new System.Drawing.Size(628, 497);
            this.browserDisplay.TabIndex = 0;
            // 
            // topPane
            // 
            this.topPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(195)))), ((int)(((byte)(208)))));
            this.topPane.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topPane.BackgroundImage")));
            this.topPane.Controls.Add(this.btnPane);
            this.topPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(628, 45);
            this.topPane.TabIndex = 2;
            // 
            // btnPane
            // 
            this.btnPane.BackColor = System.Drawing.Color.Transparent;
            this.btnPane.Controls.Add(this.searchBox);
            this.btnPane.Controls.Add(this.forwardBtn);
            this.btnPane.Controls.Add(this.backBtn);
            this.btnPane.Controls.Add(this.lyraBtn);
            this.btnPane.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPane.Location = new System.Drawing.Point(276, 0);
            this.btnPane.Name = "btnPane";
            this.btnPane.Size = new System.Drawing.Size(352, 45);
            this.btnPane.TabIndex = 3;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(4, 15);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(178, 20);
            this.searchBox.TabIndex = 0;
            // 
            // panelActivatorBtn
            // 
            this.panelActivatorBtn.BackColor = System.Drawing.Color.White;
            this.panelActivatorBtn.Image = ((System.Drawing.Image)(resources.GetObject("panelActivatorBtn.Image")));
            this.panelActivatorBtn.Location = new System.Drawing.Point(564, -1);
            this.panelActivatorBtn.Name = "panelActivatorBtn";
            this.panelActivatorBtn.Size = new System.Drawing.Size(48, 48);
            this.panelActivatorBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panelActivatorBtn.TabIndex = 3;
            this.panelActivatorBtn.TabStop = false;
            this.panelActivatorBtn.MouseHover += new System.EventHandler(this.panelActivatorBtn_MouseHover);
            // 
            // forwardBtn
            // 
            this.forwardBtn.BackColor = System.Drawing.Color.Transparent;
            this.forwardBtn.Image = ((System.Drawing.Image)(resources.GetObject("forwardBtn.Image")));
            this.forwardBtn.ImageOff = ((System.Drawing.Image)(resources.GetObject("forwardBtn.ImageOff")));
            this.forwardBtn.ImageOn = ((System.Drawing.Image)(resources.GetObject("forwardBtn.ImageOn")));
            this.forwardBtn.Location = new System.Drawing.Point(249, 9);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(32, 32);
            this.forwardBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.forwardBtn.TabIndex = 4;
            this.forwardBtn.TabStop = false;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
            this.backBtn.ImageOff = ((System.Drawing.Image)(resources.GetObject("backBtn.ImageOff")));
            this.backBtn.ImageOn = ((System.Drawing.Image)(resources.GetObject("backBtn.ImageOn")));
            this.backBtn.Location = new System.Drawing.Point(211, 9);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(32, 32);
            this.backBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backBtn.TabIndex = 4;
            this.backBtn.TabStop = false;
            // 
            // lyraBtn
            // 
            this.lyraBtn.BackColor = System.Drawing.Color.Transparent;
            this.lyraBtn.Image = ((System.Drawing.Image)(resources.GetObject("lyraBtn.Image")));
            this.lyraBtn.ImageOff = ((System.Drawing.Image)(resources.GetObject("lyraBtn.ImageOff")));
            this.lyraBtn.ImageOn = ((System.Drawing.Image)(resources.GetObject("lyraBtn.ImageOn")));
            this.lyraBtn.Location = new System.Drawing.Point(288, -2);
            this.lyraBtn.Name = "lyraBtn";
            this.lyraBtn.Size = new System.Drawing.Size(48, 48);
            this.lyraBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lyraBtn.TabIndex = 4;
            this.lyraBtn.TabStop = false;
            this.lyraBtn.Click += new System.EventHandler(this.lyraBtn_Click);
            // 
            // DefaultSongView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 497);
            this.Controls.Add(this.topPane);
            this.Controls.Add(this.panelActivatorBtn);
            this.Controls.Add(this.browserDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DefaultSongView";
            this.Text = "DefaultSongView";
            this.topPane.ResumeLayout(false);
            this.btnPane.ResumeLayout(false);
            this.btnPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelActivatorBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyraBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browserDisplay;
        private System.Windows.Forms.Panel topPane;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Panel btnPane;
        private ImageButton lyraBtn;
        private ImageButton forwardBtn;
        private ImageButton backBtn;
        private System.Windows.Forms.PictureBox panelActivatorBtn;
    }
}