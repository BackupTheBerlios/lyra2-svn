using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.IO.Compression;

namespace Lyra2
{
    class DataManager
    {
        private Dictionary<string, Book> allBooks = new Dictionary<string, Book>();

        private DirectoryInfo bookDir;
        public DataManager(DirectoryInfo bookDir)
        {
            this.bookDir = bookDir;
            foreach (FileInfo bookFile in bookDir.GetFiles("*.lbk"))
            {
                Book book = this.loadLyraBook(bookFile);
                this.allBooks.Add(book.ID, book);

            }
        }

        public void storeLyraBook(Book book)
        {
            this.storeLyraBook(book, new FileInfo(book.FileName));
        }

        public void storeLyraBook(Book book, FileInfo bookFile)
        {
            try
            {
                if (bookFile.Extension != "lbk") bookFile = new FileInfo(bookFile.FullName + ".lbk");
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

        public Book loadLyraBook(FileInfo bookFile)
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
    }
}
