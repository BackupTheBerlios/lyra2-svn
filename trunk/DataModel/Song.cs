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
        private DefaultInfo info = null;
        private int nr = Utils.NA;
        private SongLanguage defLang;
        
        // lyrics
        private Dictionary<SongLanguage, Lyrics> lyrics = null;

        public Song(DefaultInfo info, Lyrics defLyrics, string templId)
            :
            this(info, Utils.NA, defLyrics, templId)
        {
        }

        public Song(DefaultInfo info, int nr, Lyrics defLyrics, string templId)
        {
            this.id = Utils.GetID("song");
            this.info = info;
            this.nr = nr;
            this.defLang = defLyrics.Language;
            this.lyrics = new Dictionary<SongLanguage, Lyrics>();
            this.lyrics.Add(defLyrics.Language, defLyrics);
            this.templateId = templId;
            this.changed = false;
        }

        public Song(XmlElement el)
        {
            this.LoadXML(el);
            this.changed = false;
        }

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
                this.templateId = el.Attributes["template"].InnerText;
                this.defLang = Utils.LanguageFromString(el.Attributes["deflang"].InnerText);

                XmlElement infoEl = el["info"];
                this.info = new DefaultInfo(infoEl["defaultinfo"]);
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
