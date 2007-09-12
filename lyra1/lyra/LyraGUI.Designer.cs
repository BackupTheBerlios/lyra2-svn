namespace lyra
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
            Fireball.Windows.Forms.DiscoverProfessionalRender discoverProfessionalRender2 = new Fireball.Windows.Forms.DiscoverProfessionalRender();
            System.Windows.Forms.ToolStripProfessionalRenderer toolStripProfessionalRenderer2 = new System.Windows.Forms.ToolStripProfessionalRenderer();
            Fireball.Windows.Forms.TuxBar.Themes.FireTheme fireTheme2 = new Fireball.Windows.Forms.TuxBar.Themes.FireTheme();
            Fireball.Windows.Forms.TuxBar.Themes.FireTheme fireTheme1 = new Fireball.Windows.Forms.TuxBar.Themes.FireTheme();
            this.sidePane = new Fireball.Windows.Forms.DiscoverControl();
            this.discoverPane1 = new Fireball.Windows.Forms.DiscoverPane();
            this.discoverPane2 = new Fireball.Windows.Forms.DiscoverPane();
            this.discoverPane3 = new Fireball.Windows.Forms.DiscoverPane();
            this.tabStrip1 = new Fireball.Windows.Forms.TabStrip();
            this.tuxBarContainer1 = new Fireball.Windows.Forms.TuxBar.TuxBarContainer();
            this.tuxBarItem1 = new Fireball.Windows.Forms.TuxBar.TuxBarItem();
            this.sidePane.SuspendLayout();
            this.tuxBarContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePane
            // 
            this.sidePane.BackColor = System.Drawing.Color.White;
            this.sidePane.Controls.Add(this.discoverPane1);
            this.sidePane.Controls.Add(this.discoverPane2);
            this.sidePane.Controls.Add(this.discoverPane3);
            discoverProfessionalRender2.DividerBackgroundColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            discoverProfessionalRender2.DividerBackgroundColor2 = System.Drawing.SystemColors.ButtonFace;
            discoverProfessionalRender2.DividerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            discoverProfessionalRender2.GripperColor1 = System.Drawing.SystemColors.ButtonHighlight;
            discoverProfessionalRender2.GripperColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            discoverProfessionalRender2.HeaderBackgroundColor1 = System.Drawing.SystemColors.InactiveCaption;
            discoverProfessionalRender2.HeaderBackgroundColor2 = System.Drawing.SystemColors.ActiveCaption;
            discoverProfessionalRender2.HeaderTextColor = System.Drawing.Color.White;
            discoverProfessionalRender2.PaneBackgroundColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            discoverProfessionalRender2.PaneBackgroundColor2 = System.Drawing.SystemColors.ButtonFace;
            discoverProfessionalRender2.PaneCheckedBackgroundColor1 = System.Drawing.Color.Empty;
            discoverProfessionalRender2.PaneCheckedBackgroundColor2 = System.Drawing.Color.Empty;
            discoverProfessionalRender2.PaneSelectedBackgroundColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            discoverProfessionalRender2.PaneSelectedBackgroundColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.sidePane.CurrentRender = discoverProfessionalRender2;
            this.sidePane.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePane.HeaderFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.sidePane.Location = new System.Drawing.Point(0, 0);
            toolStripProfessionalRenderer2.RoundedEdges = true;
            this.sidePane.MenuItemsRenderer = toolStripProfessionalRenderer2;
            this.sidePane.Name = "sidePane";
            this.sidePane.SelectedPane = this.discoverPane1;
            this.sidePane.ShowPanes = 3;
            this.sidePane.Size = new System.Drawing.Size(276, 505);
            this.sidePane.TabIndex = 0;
            // 
            // discoverPane1
            // 
            this.discoverPane1.LargeImage = null;
            this.discoverPane1.Listed = true;
            this.discoverPane1.Location = new System.Drawing.Point(1, 24);
            this.discoverPane1.Name = "discoverPane1";
            this.discoverPane1.Size = new System.Drawing.Size(274, 365);
            this.discoverPane1.SmallImage = null;
            this.discoverPane1.TabIndex = 0;
            this.discoverPane1.Text = "Suche";
            // 
            // discoverPane2
            // 
            this.discoverPane2.LargeImage = null;
            this.discoverPane2.Listed = true;
            this.discoverPane2.Location = new System.Drawing.Point(1, 24);
            this.discoverPane2.Name = "discoverPane2";
            this.discoverPane2.Size = new System.Drawing.Size(274, 365);
            this.discoverPane2.SmallImage = null;
            this.discoverPane2.TabIndex = 1;
            // 
            // discoverPane3
            // 
            this.discoverPane3.LargeImage = null;
            this.discoverPane3.Listed = true;
            this.discoverPane3.Location = new System.Drawing.Point(1, 24);
            this.discoverPane3.Name = "discoverPane3";
            this.discoverPane3.Size = new System.Drawing.Size(274, 365);
            this.discoverPane3.SmallImage = null;
            this.discoverPane3.TabIndex = 2;
            // 
            // tabStrip1
            // 
            this.tabStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabStrip1.Location = new System.Drawing.Point(415, 200);
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.SelectedItem = null;
            this.tabStrip1.Size = new System.Drawing.Size(142, 145);
            this.tabStrip1.TabIndex = 1;
            this.tabStrip1.Text = "tabStrip1";
            // 
            // tuxBarContainer1
            // 
            this.tuxBarContainer1.AutoScroll = true;
            this.tuxBarContainer1.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.tuxBarContainer1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.tuxBarContainer1.Controls.Add(this.tuxBarItem1);
            this.tuxBarContainer1.Location = new System.Drawing.Point(626, 109);
            this.tuxBarContainer1.Name = "tuxBarContainer1";
            this.tuxBarContainer1.ShowBorder = true;
            this.tuxBarContainer1.Size = new System.Drawing.Size(200, 280);
            this.tuxBarContainer1.TabIndex = 2;
            this.tuxBarContainer1.Theme = fireTheme2;
            // 
            // tuxBarItem1
            // 
            this.tuxBarItem1.BackColor = System.Drawing.Color.Transparent;
            this.tuxBarItem1.EnableResize = false;
            this.tuxBarItem1.Icon = null;
            this.tuxBarItem1.Location = new System.Drawing.Point(97, 0);
            this.tuxBarItem1.MinHeight = 150;
            this.tuxBarItem1.Name = "tuxBarItem1";
            this.tuxBarItem1.Size = new System.Drawing.Size(100, 150);
            this.tuxBarItem1.TabIndex = 1;
            this.tuxBarItem1.Theme = fireTheme1;
            // 
            // LyraGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 505);
            this.Controls.Add(this.tuxBarContainer1);
            this.Controls.Add(this.tabStrip1);
            this.Controls.Add(this.sidePane);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LyraGUI";
            this.Text = "LyraGUI";
            this.sidePane.ResumeLayout(false);
            this.tuxBarContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Fireball.Windows.Forms.DiscoverControl sidePane;
        private Fireball.Windows.Forms.DiscoverPane discoverPane1;
        private Fireball.Windows.Forms.DiscoverPane discoverPane2;
        private Fireball.Windows.Forms.DiscoverPane discoverPane3;
        private Fireball.Windows.Forms.TabStrip tabStrip1;
        private Fireball.Windows.Forms.TuxBar.TuxBarContainer tuxBarContainer1;
        private Fireball.Windows.Forms.TuxBar.TuxBarItem tuxBarItem1;

    }
}