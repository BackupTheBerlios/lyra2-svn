using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lyra2
{
    public partial class LyraGUI : Form
    {
        public LyraGUI()
        {
            InitializeComponent();
            this.loadTestSetup();
        }

        private void loadTestSetup()
        {
            // TEST SETUP
            this.songCollectionList.Items.Add((SongCollectionListItem)new SongCollection("Alle Liedtexte!", "Zeigt alle Liedtexte an.", DateTime.Now, DateTime.Now, DateTime.Now, Image.FromFile(Info.RES_PATH + "icon_allbooks.png")));
            this.songCollectionList.Items.Add((SongCollectionListItem)new SongCollection("Letzte Suche", "Suche nach: \"lobet +herrn\"", DateTime.Now, DateTime.Now, DateTime.Now, Image.FromFile(Info.RES_PATH + "icon_search.png")));
            this.bookList.Items.Add((BookListItem)new Book("Test1", "ogirard", "Ein Testkommentar...", DateTime.Now));
            this.bookList.Items.Add((BookListItem)new Book("Test2", "ogirard", "Ein Testkommentar...", DateTime.Now));
            this.bookList.Items.Add((BookListItem)new Book("Test3", "ogirard", "Ein Testkommentar...", DateTime.Now));
            this.bookList.Items.Add((BookListItem)new Book("Test4", "ogirard", "Ein Testkommentar...", DateTime.Now));
            Book book = new Book("Test5", "ogirard", "Ein Testkommentar...", DateTime.Now);
            this.bookList.Items.Add((BookListItem)book);
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
    }
}