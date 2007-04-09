using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lyra2
{
    public partial class LyraGUI : Form
    {
        // data manager (business logic for displayed book and song data handling)
        private DataManager dataManager = null;

        // default song collections
        private SongCollection allSongs = null;
        private SongCollection lastQuery = null;

        public LyraGUI()
        {
            InitializeComponent();
            
            this.init();
        }

        private void init()
        {
            this.Text = Info.GUI_TITLE + " 2   [BETA::" + Info.VERSION + "." + Info.BUILD + "." +
                Utils.FormatShortDate(Info.RELEASE_DATE).Replace(".", "") + "]";
            
            // default song collections
            this.allSongs = new SongCollection(new DefaultInfo("Alle Liedtexte!", "Zeigt alle Liedtexte an."), 
                SongQueryEngine.CreateQuery("*"), Image.FromFile(Info.RES_PATH + "icon_allbooks.png"));
            this.lastQuery = new SongCollection(new DefaultInfo("Letzte Suche", ""), null, Image.FromFile(Info.RES_PATH + "icon_search.png"));
            // add fields
            this.songCollectionList.Items.Add(new SongCollectionListItem(this.allSongs));
            this.songCollectionList.Items.Add(new SongCollectionListItem(this.lastQuery));

            // init data manager! (data handling implementation)
            this.dataManager = new DataManager(new DirectoryInfo(Info.BOOK_PATH));

            // load all books
            foreach (Book book in this.dataManager)
            {
                this.bookList.Items.Add(new BookListItem(book));
                this.bookList.SetSelected(this.bookList.Items.IndexOf(book), book.Selected);
            }

            // update the song list!
            this.songCollectionList.SelectedIndex = 0; // TODO remember selection
            this.updateMainView(null, true);
        }

        /// <summary>
        /// refreshes the main song display grid
        /// </summary>
        /// <param name="displayedSongs">songs to be displayed or <code>null</code> if they should be detected automatically</param>
        /// <param name="fullupdate">set <code>true</code> to force a complete refresh, <code>false</code> to refresh only the indicated songs</param>
        private void updateMainView(List<Song> displayedSongs, bool fullupdate)
        {
            if (displayedSongs == null)
            {
                foreach (BookListItem bookIt in this.bookList.SelectedItems)
                {
                    Book book = bookIt;
                    if (this.songCollectionList.SelectedItems.Contains(this.allSongs))
                    {
                        ErrorHandler.ShowInfo(book.Info.Label);
                        // show all!
                        foreach (Song song in book)
                        {
                            this.songView.Items.Add(new SongListItem(song));
                        }
                    }
                }
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (this.searchBox.Text == "Liedsuche")
            {
                this.searchBox.Text = "";
                this.searchBox.ForeColor = Color.Black;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (this.searchBox.Text == "")
            {
                this.searchBox.Text = "Liedsuche";
                this.searchBox.ForeColor = Color.Gray;
            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            this.searchBox.SelectAll();
        }

        private void testDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new TestDialog()).ShowDialog(this);
        }

        private void showViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new DefaultSongView()).ShowDialog(this);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutLyra()).ShowDialog(this);
        }
    }
}