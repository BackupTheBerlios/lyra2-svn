using System;
using System.Collections.Generic;
using System.Text;

namespace Lyra2
{
    class SongCollectionListItem : NiceListBox.INiceListBoxItem
    {
        private SongCollection songCollection = null;

        public SongCollectionListItem(SongCollection songCollection)
        {
            this.songCollection = songCollection;
        }

        public static implicit operator SongCollection(SongCollectionListItem scItem)
        {
            return scItem.songCollection;
        }

        public SongCollection WrappedSongCollection
        {
            get { return this.songCollection; }
        }

        #region INiceListBoxItem Members

        public string Title
        {
            get { return this.songCollection.Title; }
        }

        public string Desc
        {
            get { return this.songCollection.Desc; }
        }

        public string State
        {
            get { return "Erstellt am " + Utils.FormatShortDate(this.songCollection.CreateDate) + "."; }
        }

        public System.Drawing.Image Icon
        {
            get { return this.songCollection.Icon; }
        }

        #endregion
    }
}
