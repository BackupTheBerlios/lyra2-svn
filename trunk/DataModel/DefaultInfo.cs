using System;
using System.Xml;

namespace Lyra2
{
    public class DefaultInfo
    {
        public string Label = "";
        public string Description = "";
        public string Author = "";
        public DateTime CreateDate = DateTime.Now;
        public DateTime LastModified = DateTime.Now;
        public DateTime LastUsed = DateTime.Now;

        public DefaultInfo(string label, string desc, string author, DateTime createDate,
            DateTime lastModified, DateTime lastUsed)
        {
            this.Label = label;
            this.Description = desc;
            this.Author = author;
            this.CreateDate = createDate;
            this.LastModified = lastModified;
            this.LastUsed = lastUsed;
        }

        public DefaultInfo(string label, string desc)
            : this(label, desc, "", DateTime.Now, DateTime.Now, DateTime.Now)
        {
        }

        public DefaultInfo(XmlElement defaultInfoEl)
        {

        }

        public XmlElement GetXML()
        {
            return null;
        }
    }
}
