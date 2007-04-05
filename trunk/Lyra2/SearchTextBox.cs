using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lyra2
{
    class SearchTextBox : TextBox
    {
        private string caption = "";
        private Color textCol = Color.Black;
        private Color fadeCol = Color.Gray;

        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                if(this.Text == "")
                {
                    this.Text = value;
                }
            }
        }

        public Color TextColor
        {
            get { return textCol; }
            set { textCol = value; }
        }

        public Color FadeColor
        {
            get { return fadeCol; }
            set { fadeCol = value; }
        }

        public SearchTextBox()
        {
            this.Enter += new EventHandler(SearchTextBox_Enter);
            this.Leave += new EventHandler(SearchTextBox_Leave);
            this.Click += new EventHandler(SearchTextBox_Click);
            this.Text = this.caption;
            this.ForeColor = this.fadeCol;
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (this.Text == "")
            {
                this.Text = this.caption;
                this.ForeColor = this.fadeCol;
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (this.Text == this.caption)
            {
                this.Text = "";
                this.ForeColor = this.textCol;
            }
        }
    }
}
