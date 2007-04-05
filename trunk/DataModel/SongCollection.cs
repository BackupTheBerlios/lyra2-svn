using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace Lyra2
{
    public class SongCollection : IEnumerable<Song>, IXMLConvertable
    {
        // data changed flag
        private bool changed = false;

        private DefaultInfo info = null;
        private ISongQuery query = null;
        private Image icon = null;

        // the songs selected for this collection
        private List<Song> songList = null;

        public SongCollection(DefaultInfo info, ISongQuery query, Image icon)
        {
            this.info = info;
            this.query = query;
            this.icon = icon;
        }

        public DefaultInfo Info
        {
            get { return this.info; }
            set { this.info = value; }
        }

        public ISongQuery Query
        {
            get { return this.query; }
            set { this.query = value; }
        }

        public Image Icon
        {
            get { return this.icon; }
        }

        public Song this[int i]
        {
            get
            {
                if (this.songList != null && i < this.songList.Count && i >= 0)
                {
                    return this.songList[i];
                }
                return null;
            }
        }

        public void MoveUp(Song song)
        {
            if (this.songList != null)
            {
                int pos = this.songList.IndexOf(song);
                if (pos >= 0 && pos < this.songList.Count-1)
                {
                    this.songList.RemoveAt(pos);
                    this.songList.Insert(pos + 1, song);
                }
            }
        }

        public void MoveDown(Song song)
        {
            if (this.songList != null)
            {
                int pos = this.songList.IndexOf(song);
                if (pos > 0 && pos < this.songList.Count)
                {
                    this.songList.RemoveAt(pos);
                    this.songList.Insert(pos - 1, song);
                }
            }
        }

        public List<Song> Songs
        {
            get { return new List<Song>(this.songList); }
        }

        #region IEnumerable<Song> Members

        public IEnumerator<Song> GetEnumerator()
        {
            return this.songList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.songList.GetEnumerator();
        }

        #endregion

        #region IXMLConvertable Members

        public XmlElement ToXML()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void LoadXML(XmlElement el)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string XML
        {
            get { return Utils.XMLPrettyPrint(this.ToXML()); }
        }

        public bool HasChanged
        {
            get { return this.changed; }
            set { this.changed = value; }
        }

        #endregion
    }
}
