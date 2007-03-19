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
        public Book loadLyraBook(string filename)
        {
            return null;
        }

        public bool storeLyraBook(Book book)
        {
            try
            {
                string lbkFileName = Info.BOOK_PATH + book.FileName + ".lbk";
                if (File.Exists(lbkFileName)) File.Delete(lbkFileName);
                FileStream fileStream = new FileStream(lbkFileName, FileMode.CreateNew);
                GZipStream zipStream = new GZipStream(fileStream, CompressionMode.Compress);
                StreamWriter writer = new StreamWriter(zipStream, Encoding.UTF8);
                writer.Write(book.XML);
                writer.Close();
            }
            catch (Exception ex)
            {
                // an error occured!
                return false;
            }
            return true;
        }

        private XmlDocument readXML(string filename)
        {
            return null;
        }

        private bool writeXML(XmlDocument xmlDoc, string filename)
        {
            return true;
        }
    }
}
