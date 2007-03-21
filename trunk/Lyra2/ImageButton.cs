using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Lyra2
{
    public partial class ImageButton : PictureBox
    {
        private Image imgOff = new Bitmap(32, 32);
        private Image imgOn = new Bitmap(32, 32);

        public Image ImageOff
        {
            get { return this.imgOff; }
            set { this.imgOff = value; }
        }

        public Image ImageOn
        {
            get { return this.imgOn; }
            set { this.imgOn = value; }
        }

        public ImageButton()
        {
            InitializeComponent();
        }

        public ImageButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            if (this.imgOn != null)
            {
                this.Image = this.imgOn;
            }
        }

        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.imgOff != null)
            {
                this.Image = this.imgOff;
            }
        }
    }
}
