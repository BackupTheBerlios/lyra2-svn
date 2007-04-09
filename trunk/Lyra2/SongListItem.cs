using System.Windows.Forms;

namespace Lyra2
{
    class SongListItem : ListViewItem
    {
        private Song song;

        public SongListItem(Song song)
        {
            this.song = song;
            base.Tag = song;
            string nrStr = song.Number == Utils.NA ? "" : song.Number.ToString();
            base.Text = nrStr;
            base.SubItems.Add(song.Title);
            string bookTitle = song.ParentBook != null ? song.ParentBook.Info.Label : "-";
            base.SubItems.Add(bookTitle);
            string lastUsed = Utils.FormatShortDate(song.Info.LastUsed);
            base.SubItems.Add(lastUsed);
        }

        public Song WrappedSong
        {
            get { return this.song; }
        }

        public override bool Equals(object obj)
        {
            if(obj is SongListItem)
            {
                SongListItem sli = (SongListItem) obj;
                return this.song.Equals(sli.song);
            }
            else if (obj is Song)
            {
                return this.song.Equals((Song) obj);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.song.GetHashCode();
        }

        public static implicit operator Song(SongListItem songIt)
        {
            return songIt.song;
        }
    }
}
