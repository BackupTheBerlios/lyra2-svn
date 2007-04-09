using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Lyra2
{
    /// <summary>
    /// song wrapper
    /// </summary>
    public class Song : IXMLConvertable
    {
        // data changed flag
        private bool changed = false;

        private string id;
        private string templateId;
        private Book parentBook;
        private DefaultInfo info = null;
        private int nr = Utils.NA;
        private SongLanguage defLang;

        // lyrics
        private Dictionary<SongLanguage, Lyrics> lyrics = null;

        public Song(Book parent, DefaultInfo info, Lyrics defLyrics, string templId)
            :
            this(parent, info, Utils.NA, defLyrics, templId)
        {
        }

        public Song(Book parent, DefaultInfo info, int nr, Lyrics defLyrics, string templId)
        {
            this.id = Utils.GetID("song");
            this.info = info;
            this.parentBook = parent;
            this.nr = nr;
            this.defLang = defLyrics.Language;
            this.lyrics = new Dictionary<SongLanguage, Lyrics>();
            this.lyrics.Add(defLyrics.Language, defLyrics);
            this.templateId = templId;
            this.changed = false;
        }

        public Song(Book parent, XmlElement el)
        {
            this.parentBook = parent;
            this.LoadXML(el);
            this.changed = false;
        }

        public string ID
        {
            get { return this.id; }
        }

        public int Number
        {
            get { return this.nr; }
            set { this.changed = true; this.nr = value; }
        }

        public SongLanguage DefaultLanguage
        {
            get { return this.defLang; }
            set
            {
                if (this.lyrics.ContainsKey(value))
                {
                    this.changed = true;
                    this.defLang = value;
                }
                else
                {
                    throw new LyraException("Sprache nicht definiert für dieses Lied!");
                }
            }
        }

        public List<Lyrics> AllLyrics
        {
            get { return new List<Lyrics>(this.lyrics.Values); }
        }

        public string TemplateID
        {
            get { return this.templateId; }
            set { this.changed = true; this.templateId = value; }
        }

        public Book ParentBook
        {
            get { return this.parentBook;  }
        }

        public DefaultInfo Info
        {
            get { return this.info; }
        }

        public string Title
        {
            get { return this.lyrics[this.defLang].Title;  }
        }

        public override bool Equals(object obj)
        {
            if(obj is Song)
            {
                Song s = (Song) obj;
                return this.id == s.ID;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        #region IXMLConvertable Members

        public XmlElement ToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement songEl = xmlDoc.CreateElement("song");
            // attributes
            XmlAttribute idAttr = xmlDoc.CreateAttribute("id");
            idAttr.InnerText = this.id;
            songEl.AppendChild(idAttr);
            XmlAttribute defLangAttr = xmlDoc.CreateAttribute("deflang");
            defLangAttr.InnerText = Utils.StringFromLanguage(this.defLang);
            songEl.AppendChild(defLangAttr);
            XmlAttribute templAttr = xmlDoc.CreateAttribute("template");
            templAttr.InnerText = this.templateId;
            songEl.AppendChild(templAttr);
            // info
            songEl.AppendChild(this.info.ToXML());
            // nr
            XmlElement nrEl = xmlDoc.CreateElement("nr");
            nrEl.InnerText = this.nr.ToString();
            songEl.AppendChild(nrEl);
            // lyrics
            foreach(Lyrics lyr in this.lyrics.Values)
            {
                songEl.AppendChild(lyr.ToXML());
            }
            return songEl;
        }

        public void LoadXML(XmlElement el)
        {
            try
            {
                this.id = el.Attributes["id"].InnerText;
                this.templateId = el.Attributes["template"].InnerText;
                this.defLang = Utils.LanguageFromString(el.Attributes["deflang"].InnerText);
                this.info = new DefaultInfo(el["defaultinfo"]);
                this.nr = Int32.Parse(el["nr"].InnerText);
                this.lyrics = new Dictionary<SongLanguage, Lyrics>();
                foreach (XmlElement lyricsEl in el.GetElementsByTagName("lyrics"))
                {
                    Lyrics lyr = new Lyrics(lyricsEl);
                    this.lyrics.Add(lyr.Language, lyr);
                }
            }
            catch (Exception ex)
            {
                throw new LyraException("Ungültiges XML Element (song)!", ex);
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
    }

    public enum SongLanguage
    {
        German, English, French, Italian, Hebrew, Spanish, Latin, Other
    }
}
