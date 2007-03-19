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
        private string id = "";
        private string title = "";
        private string author = "";
        private string desc = "";
        private DateTime createDate = DateTime.Now;
        private DateTime lastModified = DateTime.Now;
        private DateTime lastUsed = DateTime.Now;
        private List<Song> songs = new List<Song>();
        private string filename = "";

        public Book(string filename)
        {
            this.filename = filename;
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
            get { return "TEST"; /* TODO */ }
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
