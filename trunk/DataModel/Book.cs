using System;
using System.Collections.Generic;
using System.Xml;

namespace Lyra2
{
    /// <summary>
    /// Wrapper Class for Lyra 2.0 XML Book
    /// </summary>
    public class Book : IEnumerable<Song>, IXMLConvertable
    {
        // data changed flag
        private bool changed = false;

        // source
        private string filename = "";
        private XmlDocument sourceXML;

        // data
        private string id = "";
        private DefaultInfo info = null;
        private bool selected;

        // songs
        private List<Song> songs = null;
        
        // templates
        private List<ViewTemplate> templates = null;
        
        public Book(XmlDocument bookDoc, string filename)
        {
            this.filename = filename;
            this.sourceXML = bookDoc;
            XmlElement bookRoot = bookDoc["book"];
            this.LoadXML(bookRoot);
            this.changed = false;
        }

        public Book(DefaultInfo info)
        {
            this.id = Utils.GetID("book");
            this.info = info;
            this.songs = new List<Song>();
            this.templates = new List<ViewTemplate>();
            this.selected = true;
            this.changed = false;
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public string FileName
        {
            get { return this.filename; }
        }

        public string ID
        {
            get { return this.id; }
        }

        public DefaultInfo Info
        {
            get { return this.info; }
        }

        public Song this[int i]
        {
            get
            {
                if (this.songs != null && i < this.songs.Count && i >= 0)
                {
                    return this.songs[i];
                }
                return null;
            }
        }

        public void MoveUp(Song song)
        {
            if (this.songs != null)
            {
                int pos = this.songs.IndexOf(song);
                if (pos >= 0 && pos < this.songs.Count - 1)
                {
                    this.songs.RemoveAt(pos);
                    this.songs.Insert(pos + 1, song);
                }
            }
        }

        public void MoveDown(Song song)
        {
            if (this.songs != null)
            {
                int pos = this.songs.IndexOf(song);
                if (pos > 0 && pos < this.songs.Count)
                {
                    this.songs.RemoveAt(pos);
                    this.songs.Insert(pos - 1, song);
                }
            }
        }

        public List<Song> Songs
        {
            get { return this.songs == null ? null : new List<Song>(this.songs); }
        }

        public List<ViewTemplate> ExportedTemplates
        {
            get { return this.templates == null ? null : new List<ViewTemplate>(this.templates); }
        }
                
        public override bool Equals(object obj)
        {
            if (obj is Book)
            {
                Book b = (Book)obj;
                return b.ID == this.ID;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }


        #region IEnumerable<Song> Members

        public IEnumerator<Song> GetEnumerator()
        {
            return this.songs.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.songs.GetEnumerator();
        }

        #endregion


        #region IXMLConvertable Members

        public XmlElement ToXML()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void LoadXML(XmlElement el)
        {
            try
            {
                this.id = el.Attributes["id"].InnerText;
                XmlElement infoEl = el["info"];
                this.info = new DefaultInfo(infoEl["defaultinfo"]);
                this.selected = infoEl["isselected"].InnerText == "yes";
                this.songs = new List<Song>();
                XmlElement songsEl = el["songs"];
                foreach(XmlElement songEl in songsEl.GetElementsByTagName("song"))
                {
                    this.songs.Add(new Song(songEl));
                }

                this.templates = new List<ViewTemplate>();
                XmlElement templatesEl = el["templates"];
                foreach (XmlElement templateEl in templatesEl.GetElementsByTagName("template"))
                {
                    this.templates.Add(new ViewTemplate(templateEl));
                }
            }
            catch (Exception ex)
            {
                throw new LyraException("Ungültiges XML Element (book)!", ex);
            }
        }

        public string XML
        {
            get { return Utils.XMLPrettyPrint(this.ToXML()); }
        }

        public bool HasChanged
        {
            get { return this.changed || this.info.HasChanged; }
            set { this.changed = value; }
        }

        #endregion
    }
}
