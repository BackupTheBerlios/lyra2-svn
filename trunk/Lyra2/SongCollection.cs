using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Lyra2
{
    class SongCollection : IEnumerable<Song>
    {
        private string title = "";
        private string desc = "";
        private DateTime createDate = DateTime.Now;
        private DateTime lastModified = DateTime.Now;
        private DateTime lastUsed = DateTime.Now;
        private List<Song> songList = null;
        private Image icon = null;

        public SongCollection(string title, string desc, DateTime createDate, DateTime lastModified, DateTime lastUsed, Image icon)
        {
            this.title = title;
            this.desc = desc;
            this.createDate = createDate;
            this.lastModified = lastModified;
            this.lastUsed = lastUsed;
            this.icon = icon;
        }

        public static explicit operator SongCollectionListItem(SongCollection songCollection)
        {
            return new SongCollectionListItem(songCollection);
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Desc
        {
            get { return this.desc; }
            set { this.desc = value; }
        }

        public DateTime CreateDate
        {
            get { return this.createDate; }
        }

        public DateTime LastModified
        {
            get { return this.lastModified; }
            set { this.lastModified = value; }
        }

        public DateTime LastUsed
        {
            get { return this.lastUsed; }
            set { this.lastUsed = value; }
        }

        public Song this[int i]
        {
            get { return this.songList[i]; }
            set { this.songList[i] = value; }
        }

        public List<Song> Songs
        {
            get { return new List<Song>(this.songList); }
        }

        public Image Icon
        {
            get { return this.icon; }
        }

        #region IEnumerable<Song> Members

        public IEnumerator<Song> GetEnumerator()
        {
            return this.songList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.songList.GetEnumerator();
        }

        #endregion
    }
}
