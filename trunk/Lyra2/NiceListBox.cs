using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lyra2
{
    public partial class NiceListBox : ListBox
    {
        private static Font boldFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
        private static Font txtFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        private static Font smallFont = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Regular);
        // colors
        private Color activeColor1 = Color.FromArgb(132, 170, 227);
        private Color activeColor2 = Color.White;
        private Color inactiveColor1 = Color.FromArgb(235, 235, 235);
        private Color inactiveColor2 = Color.White;
        private Color activeTitleFontColor = Color.Orange;
        private Color inactiveTitleFontColor = Color.Black;

        private INiceListBoxFilter filter = null;

        /// <summary>
        /// filter accepting or rejecting INiceListBoxItems
        /// </summary>
        public INiceListBoxFilter Filter
        {
            get { return this.filter; }
            set
            {
                this.filter = value;
                // refresh this list if filter changed!
                this.Refresh();
            }
        }

        /// <summary>
        /// remove filter
        /// </summary>
        public void NoFilter()
        {
            this.filter = null;
            this.Refresh();
        }

        /// <summary>
        /// Color1 of active gradient
        /// </summary>
        public Color ActiveColor1
        {
            get { return this.activeColor1; }
            set { this.activeColor1 = value; }
        }

        /// <summary>
        /// Color2 of active gradient
        /// </summary>
        public Color ActiveColor2
        {
            get { return this.activeColor2; }
            set { this.activeColor2 = value; }
        }

        /// <summary>
        /// Color1 of inactive gradient
        /// </summary>
        public Color InactiveColor1
        {
            get { return this.inactiveColor1; }
            set { this.inactiveColor1 = value; }
        }

        /// <summary>
        /// Color2 of inactive gradient
        /// </summary>
        public Color InactiveColor2
        {
            get { return this.inactiveColor2; }
            set { this.inactiveColor2 = value; }
        }

        /// <summary>
        /// Color of active title
        /// </summary>
        public Color ActiveTitleFontColor
        {
            get { return this.activeTitleFontColor; }
            set { this.activeTitleFontColor = value; }
        }

        /// <summary>
        /// Color of inactive title
        /// </summary>
        public Color InactiveTitleFontColor
        {
            get { return this.inactiveTitleFontColor; }
            set { this.inactiveTitleFontColor = value; }
        }

        public NiceListBox()
        {
            InitializeComponent();

            // special drawing   
            this.MeasureItem += new MeasureItemEventHandler(NiceListBox_MeasureItem);
            this.DrawItem += new DrawItemEventHandler(NiceListBox_DrawItem);
        }

        #region ListBox Custom Draw

        /// <summary>
        /// Measures List Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NiceListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // get Graphics
            Graphics g = e.Graphics;
            ListBox lbox = (ListBox)sender;
            int distance = 4;

            // get Info
            if (lbox.Items.Count > 0 && lbox.Items[e.Index] is INiceListBoxItem)
            {
                // layout
                INiceListBoxItem curItem = (INiceListBoxItem)lbox.Items[e.Index];
                if (this.filter != null && !this.filter.AcceptItem(curItem))
                {
                    // if filter does not accept this item, don't draw it
                    e.ItemHeight = 0;
                }
                string desc = Utils.CleanString(curItem.Desc, 50);
                if (desc == "") desc = "TEST";
                string state = Utils.CleanString(curItem.State, 50);
                if (desc == "") state = "TEST";
                int nr = e.Index + 1;

                // string sizes
                SizeF nrSize = g.MeasureString(nr + ".", NiceListBox.boldFont);
                SizeF descSize = g.MeasureString(desc, NiceListBox.txtFont, e.ItemWidth - (int)nrSize.Width - 10, new StringFormat(StringFormatFlags.FitBlackBox));
                SizeF stateSize = g.MeasureString(state, NiceListBox.smallFont, e.ItemWidth - (int)nrSize.Width - 10, new StringFormat(StringFormatFlags.FitBlackBox));

                // set ItemHeight
                e.ItemHeight = 3 + (int)nrSize.Height + distance + (int)descSize.Height + distance + (int)stateSize.Height + 4;
            }
            else
            {
                // not supported!
                e.ItemHeight = 0;
            }
        }

        // draw Item
        private void NiceListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // get Graphics
            Graphics g = e.Graphics;
            ListBox lbox = (ListBox)sender;
            int distance = 4;

            // get Info
            if (lbox.Items.Count > 0 && lbox.Items[e.Index] is INiceListBoxItem)
            {
                // layout
                INiceListBoxItem curItem = (INiceListBoxItem)lbox.Items[e.Index];
                if (this.filter != null && !this.filter.AcceptItem(curItem))
                {
                    return;
                }
                Image img = curItem.Icon;
                string desc = Utils.CleanString(curItem.Desc, 50);
                string state = Utils.CleanString(curItem.State, 50);
                string title = curItem.Title;
                int nr = e.Index + 1;

                // active?
                bool active = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                if (active) // selected
                {
                    g.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, e.Bounds.Height), this.activeColor1, this.activeColor2), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                }
                else // not selected
                {
                    g.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, e.Bounds.Height), this.inactiveColor1, this.inactiveColor2), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                }

                g.DrawString(nr + ".", boldFont, Brushes.Black, e.Bounds.X, e.Bounds.Y + 3);
                SizeF nrSize = g.MeasureString(nr + ".", boldFont);


                g.DrawString(title, NiceListBox.boldFont, new SolidBrush(active ? this.activeTitleFontColor : this.inactiveTitleFontColor), e.Bounds.X + nrSize.Width + 8, e.Bounds.Y + 3);

                Rectangle rect = new Rectangle(e.Bounds.X + (int)nrSize.Width + 10, e.Bounds.Y + 3 + (int)nrSize.Height + distance, lbox.ClientSize.Width - (int)nrSize.Width - 10, this.ClientSize.Height);
                g.DrawString(desc, txtFont, Brushes.Black, rect, new StringFormat(StringFormatFlags.FitBlackBox));

                SizeF descSize = g.MeasureString(desc == "" ? "TEST" : desc, NiceListBox.txtFont, lbox.ClientSize.Width - (int)nrSize.Width - 10, new StringFormat(StringFormatFlags.FitBlackBox));
                rect.Y += (int)descSize.Height + distance;

                g.DrawString(state, NiceListBox.smallFont, Brushes.Gray, rect, new StringFormat(StringFormatFlags.FitBlackBox));

                g.DrawImage(img, new Point(e.Bounds.Right - 35, e.Bounds.Top + 5));
            }
        }
        #endregion

        public interface INiceListBoxItem
        {
            /// <summary>
            /// Title to be displayed
            /// </summary>
            string Title { get; }

            /// <summary>
            /// Description to be displayed
            /// (optional, returns null if undefined)
            /// </summary>
            string Desc { get; }

            /// <summary>
            /// State (as string) to be displayed
            /// (optional, returns null if undefined)
            /// </summary>
            string State { get; }

            /// <summary>
            /// Icon to be displayed
            /// (optional, returns null if undefined)
            /// Use Image.FromFile(filename); to load an image from a file directly.
            /// </summary>
            Image Icon { get; }
        }

        public interface INiceListBoxFilter
        {
            /// <summary>
            /// returns true iff item is accepted
            /// </summary>
            /// <returns></returns>
            bool AcceptItem(INiceListBoxItem item);
        }
    }
}
