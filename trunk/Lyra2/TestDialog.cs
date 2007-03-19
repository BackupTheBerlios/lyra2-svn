using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lyra2
{
    public partial class TestDialog : Form
    {
        public TestDialog()
        {
            InitializeComponent();
            this.textBox1.Text = Info.BOOK_PATH + "LyraDefault.xml";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book book = new Book("LyraDefault");
            DataManager dataManager = new DataManager();
            dataManager.storeLyraBook(book);
        }
    }
}