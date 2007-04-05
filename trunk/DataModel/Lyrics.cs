using System;
using System.Collections.Generic;
using System.Xml;

namespace Lyra2
{
    public class Lyrics : IXMLConvertable
    {
        // data changed flag
        private bool changed = false;

        // data
        private SongLanguage lang;
        private string title;
        private List<string> pages;
        private int cols = 1;
        private bool scroll = false;

        public Lyrics(SongLanguage lang, string title, List<string> pages)
        {
            this.lang = lang;
            this.title = title;
            this.pages = pages;
        }

        public Lyrics(SongLanguage lang, string title, string onlypage)
        {
            this.lang = lang;
            this.title = title;
            this.pages = new List<string>();
            this.pages.Add(onlypage);
        }

        public Lyrics(XmlElement el)
        {
            this.LoadXML(el);
        }

        #region IXMLConvertable Members

        public XmlElement ToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement lyricsEl = xmlDoc.CreateElement("lyrics");
            XmlAttribute langAttr = xmlDoc.CreateAttribute("lang");
            langAttr.InnerText = Utils.StringFromLanguage(this.lang);
            lyricsEl.AppendChild(langAttr);
            XmlElement titleEl = xmlDoc.CreateElement("title");
            titleEl.InnerText = this.title;
            lyricsEl.AppendChild(titleEl);
            XmlElement textEl = xmlDoc.CreateElement("text");
            XmlAttribute colAttr = xmlDoc.CreateAttribute("cols");
            colAttr.InnerText = this.cols.ToString();
            textEl.AppendChild(colAttr);
            XmlAttribute scrollAttr = xmlDoc.CreateAttribute("scroll");
            scrollAttr.InnerText = this.scroll ? "yes" : "no";
            textEl.AppendChild(scrollAttr);
            int nr = 1;
            foreach (string page in this.pages)
            {
                XmlElement pageEl = xmlDoc.CreateElement("page");
                XmlAttribute nrAttr = xmlDoc.CreateAttribute("nr");
                nrAttr.InnerText = nr.ToString();
                pageEl.AppendChild(nrAttr);
                pageEl.InnerText = page;
                textEl.AppendChild(pageEl);
            }
            lyricsEl.AppendChild(textEl);
            return lyricsEl;
        }

        public string XML
        {
            get { return Utils.XMLPrettyPrint(this.ToXML()); }
        }

        public void LoadXML(XmlElement el)
        {
            try
            {
                this.lang = Utils.LanguageFromString(el.Attributes["lang"].InnerText);
                this.title = el["title"].InnerText;
                this.pages = new List<string>();
                XmlElement pagesEl = el["text"];
                this.cols = Int32.Parse(pagesEl.Attributes["cols"].InnerText);
                this.scroll = pagesEl.Attributes["scroll"].InnerText == "yes";
                foreach (XmlElement page in pagesEl.GetElementsByTagName("page"))
                {
                    this.pages.Add(page.InnerText);
                }
            }
            catch (Exception ex)
            {
                throw new LyraException("Ungültiges XML Element (lyrics)!", ex);
            }
        }

        public bool HasChanged
        {
            get { return this.changed; }
            set { this.changed = value; }
        }

        #endregion

        public SongLanguage Language
        {
            get { return lang; }
            set { this.changed = true; lang = value; }
        }

        public string Title
        {
            get { return title; }
            set { this.changed = true; title = value; }
        }

        public List<string> Pages
        {
            get { return this.pages == null ? null : new List<string>(this.pages); }
        }

        public int Cols
        {
            get { return cols; }
            set { this.changed = true; cols = value; }
        }

        public bool Scroll
        {
            get { return scroll; }
            set { this.changed = true; scroll = value; }
        }

        public string this[int i]
        {
            get
            {
                if (this.pages != null && i < this.pages.Count && i >= 0)
                {
                    return this.pages[i];
                }
                return null;
            }
        }

    }
}
