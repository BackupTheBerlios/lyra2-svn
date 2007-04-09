using System;
using System.Xml;

namespace Lyra2
{
    public class DefaultInfo : IXMLConvertable
    {
        // data changed flag
        private bool changed = false;

        private string label = "";
        private string description = "";
        private string author = "";
        private DateTime createDate = DateTime.Now;
        private DateTime lastModified = DateTime.Now;
        private DateTime lastUsed = DateTime.Now;

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

        public DefaultInfo(XmlElement el)
        {
            this.LoadXML(el);
        }

        #region IXMLConvertable Members

        public XmlElement ToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement defInfoEl = xmlDoc.CreateElement("defaultinfo");
            XmlElement labelEl = xmlDoc.CreateElement("label");
            labelEl.InnerText = this.Label;
            defInfoEl.AppendChild(labelEl);
            XmlElement descEl = xmlDoc.CreateElement("description");
            descEl.InnerText = this.Description;
            defInfoEl.AppendChild(descEl);
            XmlElement authEl = xmlDoc.CreateElement("author");
            authEl.InnerText = this.Author;
            defInfoEl.AppendChild(authEl);
            XmlElement createDateEl = xmlDoc.CreateElement("createdate");
            createDateEl.InnerText = Utils.FormatLongDate(this.CreateDate);
            defInfoEl.AppendChild(createDateEl);
            XmlElement lastModEl = xmlDoc.CreateElement("lastmodified");
            lastModEl.InnerText = Utils.FormatLongDate(this.LastModified);
            defInfoEl.AppendChild(lastModEl);
            XmlElement lastUsedEl = xmlDoc.CreateElement("lastused");
            lastUsedEl.InnerText = Utils.FormatLongDate(this.LastUsed);
            defInfoEl.AppendChild(lastUsedEl);
            return defInfoEl;
        }

        public void LoadXML(XmlElement el)
        {
            if (el.Name == "defaultinfo")
            {
                try
                {
                    this.Label = el["label"].InnerText;
                    this.Description = el["desc"].InnerText;
                    this.Author = el["author"].InnerText;
                    this.CreateDate = Utils.DateFromString(el["createdate"].InnerText);
                    this.LastModified = Utils.DateFromString(el["lastmodified"].InnerText);
                    this.LastUsed = Utils.DateFromString(el["lastused"].InnerText);
                }
                catch (Exception ex)
                {
                    throw new LyraException("Ungültiges XML Element (defaultinfo)!", ex);
                }
            }
            else
            {
                throw new LyraException("Ungültiges XML Element (defaultinfo)!");
            }
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

        public string Label
        {
            get { return label; }
            set { this.changed = true; label = value; }
        }

        public string Description
        {
            get { return description; }
            set { this.changed = true; description = value; }
        }

        public string Author
        {
            get { return author; }
            set { this.changed = true; author = value; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set { this.changed = true; createDate = value; }
        }

        public DateTime LastModified
        {
            get { return lastModified; }
            set { this.changed = true; lastModified = value; }
        }

        public DateTime LastUsed
        {
            get { return lastUsed; }
            set { this.changed = true; lastUsed = value; }
        }
    }
}
