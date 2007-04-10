using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.IO.Compression;

namespace Lyra2
{
    class DataManager : IEnumerable<Book>
    {
        private Dictionary<string, Book> allBooks = new Dictionary<string, Book>();

        private DirectoryInfo bookDir;
        public DataManager(DirectoryInfo bookDir)
        {
            this.bookDir = bookDir;
            foreach (FileInfo bookFile in bookDir.GetFiles("*.lbk"))
            {
                Book book = this.LoadLyraBook(bookFile);
                this.allBooks.Add(book.ID, book);
            }
        }

        public static void ConvertXMLToLBK(DirectoryInfo bookDir)
        {
            foreach (FileInfo xmlFile in bookDir.GetFiles("*.xml"))
            {
                XmlDocument tempDoc = new XmlDocument();
                tempDoc.Load(xmlFile.FullName);
                Book tempBook = new Book(tempDoc, xmlFile.FullName.Replace(".xml",".lbk"));
                try
                {
                    FileInfo bookFile = new FileInfo(tempBook.FileName);
                    if (bookFile.Exists) bookFile.Delete();
                    FileStream fileStream = new FileStream(bookFile.FullName, FileMode.CreateNew);
                    GZipStream zipStream = new GZipStream(fileStream, CompressionMode.Compress);
                    StreamWriter writer = new StreamWriter(zipStream, Encoding.UTF8);
                    writer.Write(tempBook.XML);
                    writer.Close();
                    zipStream.Close();
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    throw new LyraException("Buch '" + tempBook + "' konnte nicht gespeichert werden!", ex);
                }
            }
        }

        public void StoreLyraBook(Book book)
        {
            this.StoreLyraBook(book, new FileInfo(book.FileName));
        }

        public void StoreLyraBook(Book book, FileInfo bookFile)
        {
            try
            {
                if (!bookFile.FullName.EndsWith(".lbk")) bookFile = new FileInfo(bookFile.FullName + ".lbk");
                if (bookFile.Exists) bookFile.Delete();
                FileStream fileStream = new FileStream(bookFile.FullName, FileMode.CreateNew);
                GZipStream zipStream = new GZipStream(fileStream, CompressionMode.Compress);
                StreamWriter writer = new StreamWriter(zipStream, Encoding.UTF8);
                writer.Write(book.XML);
                writer.Close();
                zipStream.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new LyraException("Buch '" + book + "' konnte nicht gespeichert werden!", ex);
            }
        }

        public Book LoadLyraBook(FileInfo bookFile)
        {
            if (bookFile == null) return null;
            try
            {
                if (bookFile.Exists)
                {
                    FileStream fileStream = new FileStream(bookFile.FullName, FileMode.Open);
                    GZipStream zipStream = new GZipStream(fileStream, CompressionMode.Decompress);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(zipStream);
                    Book book = new Book(xmlDoc, bookFile.FullName);
                    zipStream.Close();
                    fileStream.Close();
                    return book;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new LyraException("Buch '" + bookFile.FullName + "' konnte nicht geöffnet werden!", ex);
            }
        }

        public Book this[string id]
        {
            get { return this.allBooks[id]; }
        }

        public Song GetSongById(string id)
        {
            try
            {
                Book book = this[Utils.GetBookId(id)];
                return book[Utils.GetSimpleSongId(id)];
            }
            catch(Exception)
            {
                return null;
            }
        }

        #region IEnumerable<Book> Members

        public IEnumerator<Book> GetEnumerator()
        {
            return this.allBooks.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.allBooks.Values.GetEnumerator();
        }

        #endregion

        #region Data Changed Event
        
        public event DataChangedHandler DataChanged;

        public void OnDataChanged(DataChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }

        #endregion
    }
}
