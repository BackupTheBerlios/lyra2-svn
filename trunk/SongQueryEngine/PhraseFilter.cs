using System.Collections;
using System.Collections.Generic;

namespace Lyra2
{
    class PhraseFilter : IFilter
    {
        private IDCache cache = null;
        private string phrase = "";
        private SearchType type;
        private bool caseSensitive;

        private IDCache Cache
        {
            get
            {
                if (this.cache == null || !this.cache.Valid)
                {
                    // lazy query execution!
                    // TODO
                    throw new LyraException("Noch nicht implementiert!");
                }
                return this.cache;
            }
        }

        public string Phrase
        {
            get { return this.phrase; }
        }

        public PhraseFilter(string phrase, SearchType type)
        {
            this.phrase = phrase;
            this.type = type;
        }

        #region IFilter Members

        public bool Accept(Song song)
        {
            // index look-up to guarantee same results by filtering as for entire index query!
            return this.Cache.Contains(song);
        }

        public SongFilter Filter
        {
            get
            {
                return delegate(Song song) { return this.Accept(song); };
            }
        }

        public SearchType Type
        {
            get { return this.type; }
            set { this.cache = null; this.type = value; }
        }

        public bool CaseSensitive
        {
            get { return this.caseSensitive; }
            set { this.cache = null; this.caseSensitive = value; }
        }

        public List<string> RankedIDs
        {
            get { return RankedID.RankIDs(this); }
        }

        #endregion

        #region IEnumerable<Song> Members

        public IEnumerator<RankedID> GetEnumerator()
        {
            return this.Cache.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Cache.GetEnumerator();
        }

        #endregion


        public override string ToString()
        {
            return "Phrase[" + this.phrase + "]" + Utils.WINNL;
        }
    }
}
