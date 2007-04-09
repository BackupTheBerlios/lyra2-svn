using System.Drawing;

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

        public override bool Equals(object obj)
        {
            if (obj is SongCollection)
            {
                return this.songCollection.Equals((SongCollection) obj);
            }
            else if(obj is SongCollectionListItem)
            {
                return this.songCollection.Equals(((SongCollectionListItem) obj).songCollection);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.songCollection.GetHashCode();
        }

        #region INiceListBoxItem Members

        public string Title
        {
            get { return this.songCollection.Info.Label; }
        }

        public string Desc
        {
            get { return this.songCollection.Info.Description; }
        }

        public string State
        {
            get { return "Erstellt am " + Utils.FormatShortDate(this.songCollection.Info.CreateDate) + "."; }
        }

        public Image Icon
        {
            get { return this.songCollection.Icon; }
        }

        #endregion
    }
}
