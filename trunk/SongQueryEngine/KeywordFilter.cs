using System.Collections;
using System.Collections.Generic;

namespace Lyra2
{
    class KeywordFilter : IFilter
    {
        private IDCache cache = null;
        private string keyword = "";
        private SearchType type;
        private bool caseSensitive;

        private IDCache Cache
        {
            get
            {
                if (this.cache == null || !this.cache.Valid)
                {
                    // lazy query execution!
                    this.cache = SongQueryEngine.ExecuteSimpleKeywordQuery(this.keyword, this.type);
                }
                return this.cache;
            }
        }

        public string Keyword
        {
            get { return this.keyword; }
        }

        public KeywordFilter(string keyword, SearchType type)
        {
            this.keyword = keyword;
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
            return "Keyword[" + this.keyword + "]" + Utils.WINNL;
        }
    }
}
