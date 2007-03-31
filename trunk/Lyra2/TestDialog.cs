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
    public partial class TestDialog : Form
    {
        public TestDialog()
        {
            InitializeComponent();
            this.textBox1.Text = Info.BOOK_PATH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataManager.ConvertXMLToLBK(new DirectoryInfo(this.textBox1.Text));
        }
    }
}