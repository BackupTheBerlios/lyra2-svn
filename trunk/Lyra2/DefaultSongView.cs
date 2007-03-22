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
        private Screen DisplayingScreen
        {
            get { return Screen.FromControl(this); }
        }

        public DefaultSongView()
        {
            InitializeComponent();
            this.Width = this.DisplayingScreen.Bounds.Width;
            this.Height = this.DisplayingScreen.Bounds.Height;
            this.Left = 0;
            this.Top = 0;
            this.panelActivatorBtn.Left = this.Width - this.btnPane.Width + this.lyraBtn.Left;
            this.panelActivatorBtn.Top = this.lyraBtn.Top;
            this.topPane.Height = 0;
            this.mousePosition.Interval = 1000;
            this.mousePosition.Tick += new EventHandler(mousePosition_Tick);
            this.mousePosition.Start();
        }

        #region MouseTimer

        private Timer mousePosition = new Timer();
        private int countOut = 0;
        private bool isOut = true;

        void mousePosition_Tick(object sender, EventArgs e)
        {
            // if on displaying screen, ignore otherwise
            if (MousePosition.X >= DisplayingScreen.Bounds.Left &&
                MousePosition.X < DisplayingScreen.Bounds.Right)
            {
                if (MousePosition.Y < 10)
                {
                    this.topPane.Height = 45;
                    this.countOut = 0;
                }
                else if(MousePosition.Y > 45 && this.topPane.Height != 0)
                {
                    // wait 5 rounds, then hide the top pane
                    if (this.isOut)
                    {
                        // components like pulldown menus may block the counter!
                        this.countOut++;
                    }
                    if (this.countOut > 4)
                    {
                        this.topPane.Height = 0;
                        this.browserDisplay.Focus();
                    }
                }
            }
        }

        #endregion

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