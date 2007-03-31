using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Lyra2
{
    /// <summary>
    /// Wrapper Class for Lyra 2.0 XML Book
    /// </summary>
    class Book : IEnumerable<Song>
    {
        // source
        private string filename = "";
        private XmlDocument sourceXML;

        // data
        private string id = "";
        private string title = "";
        private string author = "";
        private string desc = "";
        private DateTime createDate = DateTime.Now;
        private DateTime lastModified = DateTime.Now;
        private DateTime lastUsed = DateTime.Now;
        private List<Song> songs = new List<Song>();        
        private List<ViewTemplate> exportedTemplates = new List<ViewTemplate>();
        private bool selected;

        public Book(XmlDocument xmlDoc, string filename)
        {
            this.filename = filename;
            this.sourceXML = xmlDoc;
            this.loadData(xmlDoc);
        }

        private void loadData(XmlDocument xmlDoc)
        {
            XmlElement bookRoot = xmlDoc["book"];
            this.id = bookRoot.Attributes["id"].InnerText;
            XmlElement infoElem = bookRoot["info"];
            this.title = infoElem["title"].InnerText;
            this.desc = infoElem["desc"].InnerText;
            this.author = infoElem["author"].InnerText;
            this.createDate = Utils.DateFromString(infoElem["createdate"].InnerText);
            this.lastModified = Utils.DateFromString(infoElem["lastmodified"].InnerText);
            this.lastUsed = Utils.DateFromString(infoElem["lastused"].InnerText);
            this.selected = infoElem["isselected"].InnerText == "yes";
        }

        public Book(string title, string author, string desc, DateTime createDate)
        {
            this.id = Utils.GetID("book");
            this.title = title;
            this.author = author;
            this.desc = desc;
            this.createDate = createDate;
        }

        public static explicit operator BookListItem(Book book)
        {
            return new BookListItem(book);
        }

        public string ID
        {
            get { return this.id; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
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
            get { return this.songs[i]; }
            set { this.songs[i] = value; }
        }

        public List<Song> Songs
        {
            get { return new List<Song>(this.songs); }
        }

        public string FileName
        {
            get { return this.filename; }
        }

        public string XML
        {
            get { return Utils.XMLPrettyPrint(this.sourceXML); }
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Book || obj is BookListItem)
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
    }
}
