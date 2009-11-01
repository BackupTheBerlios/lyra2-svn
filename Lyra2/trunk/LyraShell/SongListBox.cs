using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Summary description for SongListBox
    /// </summary>
    public class SongListBox : ListBox
    {
        [Category("Action")]
        public event ScrollEventHandler Scrolled = null;
        private int oldTopIndex = 0;

        private Color backColor;
        public Color HighLightBackColor
        {
            get { return this.backColor; }
            set { this.backColor = value; }
        }

        public SongListBox()
        {
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.ItemHeight = 15;
            this.DrawItem += SongListBox_DrawItem;
            this.HighLightBackColor = Color.LightGray;
            this.Sorted = false;
        }

        private readonly Brush highlight = new SolidBrush(Color.FromArgb(251, 225, 98));
        private readonly Brush highlightLight = new SolidBrush(Color.FromArgb(253, 253, 176));
        private readonly Brush normalTextColor = Brushes.Navy;
        private readonly Brush numberMatchTextColor = new SolidBrush(Color.FromArgb(0, 102, 128));
        private readonly Pen highlightBorder = new Pen(Color.FromArgb(251, 225, 98));
        private readonly Pen highlightBorderLight = new Pen(Color.FromArgb(253, 253, 176));
        private readonly Pen separatorLine = new Pen(Color.FromArgb(230, 220, 197));

        private const int RatingWidth = 200;
        private const int RatingOffset = 0;

        private void SongListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < this.Items.Count && e.Index >= 0)
            {
                Color bgcol = BackColor;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    bgcol = HighLightBackColor;
                    e.DrawFocusRectangle();
                }

                e.Graphics.FillRectangle(new SolidBrush(bgcol), e.Bounds);


                Brush foreColBrush = new SolidBrush(e.ForeColor);
                object item = this.Items[e.Index];
                if (item is Song)
                {
                    Song song = (Song)item;
                    if (e.Index < this.nrOfNumberMatches && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(highlightLight, e.Bounds);
                    }
                    this.DrawString(e.Graphics, Util.toFour(song.Number), e.Font, Brushes.DimGray,
                                        new RectangleF(e.Bounds.X, e.Bounds.Y, 50, e.Bounds.Height), highlightLight,
                                        highlightBorderLight);
                    if (e.Index < this.nrOfNumberMatches)
                    {
                        // it's a number match...
                        RectangleF titleFrame = new RectangleF(e.Bounds.X + 50, e.Bounds.Y, e.Bounds.Width - 50,
                                                              e.Bounds.Height);
                        this.DrawString(e.Graphics, song.Title, new Font(e.Font, FontStyle.Bold), normalTextColor,
                                         titleFrame, highlight, highlightBorder);
                    }
                    else
                    {
                        this.DrawString(e.Graphics, song.Title, new Font(e.Font, FontStyle.Bold), normalTextColor,
                                          new RectangleF(e.Bounds.X + 50, e.Bounds.Y, e.Bounds.Width - 50, e.Bounds.Height), highlight, highlightBorder);

                        if (this.method == SortMethod.RatingDescending || this.method == SortMethod.RatingAscending)
                        {
                            float rating = this.Ratings[song];
                            float space = RatingWidth * Math.Min(1f, rating * 2);

                            Brush b = new LinearGradientBrush(new Point(e.Bounds.Right - RatingWidth - RatingOffset, e.Bounds.Top),
                                                              new Point(e.Bounds.Right - RatingOffset, e.Bounds.Top), Color.White,
                                                              Color.FromArgb(100, 0, 85, 170));
                            e.Graphics.FillRectangle(b, new RectangleF(e.Bounds.Right - space - RatingOffset, e.Bounds.Top, space, e.Bounds.Height));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString(item.ToString(), e.Font, foreColBrush, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                }
                if (this.nrOfNumberMatches > 0 && e.Index == this.nrOfNumberMatches - 1 && this.Items.Count > this.nrOfNumberMatches)
                {
                    e.Graphics.DrawLine(separatorLine, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
                e.DrawFocusRectangle();
            }
            // scrolled?
            if (this.oldTopIndex != this.TopIndex)
            {
                ScrollEventArgs scrollArgs = new ScrollEventArgs(this.oldTopIndex > this.TopIndex ?
                    ScrollEventType.SmallDecrement : ScrollEventType.SmallIncrement, this.TopIndex);
                this.OnScroll(scrollArgs);
            }
            this.oldTopIndex = this.TopIndex;
        }

        private IList<string> searchTags;

        public void SetSearchTags(IList<string> tags)
        {
            this.searchTags = new List<string>();
            foreach (string tag in tags)
            {
                this.searchTags.Add(tag.Replace("*", "").Replace("?", "").ToLowerInvariant());
            }
            this.Refresh();
        }

        private int nrOfNumberMatches = 0;

        public int NrOfNumberMatches
        {
            get { return this.nrOfNumberMatches; }
            set { this.nrOfNumberMatches = value; }
        }

        public void ResetSearchTags()
        {
            this.searchTags = null;
            this.Refresh();
        }

        private void DrawString(Graphics g, string text, Font font, Brush brush, RectangleF bounds, Brush highlightBrush, Pen highlightBorder)
        {
            if (!this.HasSearchTagMatch(text))
            {
                g.DrawString(text, font, brush, bounds);
            }
            else
            {
                string lowerText = text.ToLowerInvariant();
                List<CharacterRange> intervals = new List<CharacterRange>();
                foreach (string searchTag in searchTags)
                {
                    int pos = lowerText.IndexOf(searchTag);
                    while (pos >= 0 && pos < lowerText.Length)
                    {
                        intervals.Add(new CharacterRange(pos, searchTag.Length));
                        pos = lowerText.IndexOf(searchTag, pos + 1);
                    }
                }
                intervals.Sort((a, b) => a.First - b.First);
                for (int i = 0; i < intervals.Count - 1; i++)
                {
                    CharacterRange interval = intervals[i];
                    CharacterRange nextInterval = intervals[i + 1];
                    if (interval.First + interval.Length >= nextInterval.First)
                    {
                        interval.Length = nextInterval.First + nextInterval.Length - interval.First;
                        intervals.Remove(nextInterval);
                        --i; // remain at this position
                    }
                }
                if (intervals.Count == 0)
                {
                    g.DrawString(text, font, brush, bounds);
                    return; // should not occur
                }

                StringFormat stringFormat = new StringFormat();
                stringFormat.SetMeasurableCharacterRanges(intervals.ToArray());

                Region[] regions = g.MeasureCharacterRanges(text, font, bounds, stringFormat);
                foreach (Region region in regions)
                {
                    RectangleF regBounds = region.GetBounds(g);
                    regBounds.X--;
                    regBounds.Width += 2;
                    g.FillRectangle(highlightBrush, regBounds);
                    g.DrawRectangle(highlightBorder, Rectangle.Round(regBounds));
                }

                g.DrawString(text, font, brush, bounds, stringFormat);
            }
        }

        private readonly IDictionary<ISong, float> ratings = new Dictionary<ISong, float>();

        public IDictionary<ISong, float> Ratings
        {
            get { return this.ratings; }
        }

        private int CompareRating(ISong a, ISong b)
        {
            float ar = 0f;
            float br = 0f;
            if (this.ratings.ContainsKey(a)) ar = this.ratings[a];
            if (this.ratings.ContainsKey(b)) br = this.ratings[b];

            if (ar == br)
            {
                return 0;
            }
            return ar > br ? -1 : 1;
        }

        private SortMethod method;

        public void Sort(SortMethod method)
        {
            this.BeginUpdate();
            this.method = method;
            List<ISong> sortedSongs = new List<ISong>();
            for (int i = this.nrOfNumberMatches; i < this.Items.Count; i++)
            {
                ISong song = this.Items[i] as ISong;

                if (song != null)
                {
                    sortedSongs.Add(song);
                }
            }
            switch (method)
            {
                case SortMethod.NumberAscending:
                    sortedSongs.Sort((a, b) => a.Number.CompareTo(b.Number));
                    break;
                case SortMethod.NumberDescending:
                    sortedSongs.Sort((a, b) => -a.Number.CompareTo(b.Number));
                    break;
                case SortMethod.RatingAscending:
                    sortedSongs.Sort((a, b) => -CompareRating(a, b));
                    break;
                case SortMethod.RatingDescending:
                    sortedSongs.Sort(CompareRating);
                    break;
                case SortMethod.TitleAscending:
                    sortedSongs.Sort((a, b) => a.Title.CompareTo(b.Title));
                    break;
                case SortMethod.TitleDescending:
                    sortedSongs.Sort((a, b) => -a.Title.CompareTo(b.Title));
                    break;
            }
            foreach (ISong song in sortedSongs)
            {
                this.Items.Remove(song);
            }
            this.Items.AddRange(sortedSongs.ToArray());
            this.EndUpdate();
        }

        private bool HasSearchTagMatch(string text)
        {
            #region    Precondition

            if (this.searchTags == null) return false;

            #endregion Precondition

            string lowerText = text.ToLowerInvariant();
            foreach (string searchTag in this.searchTags)
            {
                if (lowerText.Contains(searchTag)) return true;
            }

            return false;
        }

        protected virtual void OnScroll(ScrollEventArgs e)
        {
            if (this.Scrolled != null)
            {
                this.Scrolled(this, e);
            }
        }
    }
}
