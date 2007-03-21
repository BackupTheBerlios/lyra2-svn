using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lyra2
{
    public partial class DefaultSongView : Form, ISongView
    {
        public DefaultSongView()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.panelActivatorBtn.Left = this.Width - this.btnPane.Width + this.lyraBtn.Left;
            this.panelActivatorBtn.Top = this.lyraBtn.Top;
            this.topPane.Height = 0;
            this.browserDisplay.GotFocus += new EventHandler(browserDisplay_GotFocus);
        }

        void browserDisplay_GotFocus(object sender, EventArgs e)
        {
            this.topPane.Height = 0;
        }


        #region ISongView Members

        public void ShowSong(Song song)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ShowSongs(List<Song> songlist, int startindex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ShowSongs(List<Song> songlist)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void lyraBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelActivatorBtn_MouseHover(object sender, EventArgs e)
        {
            this.topPane.Height = 45;
        } 
    }
}