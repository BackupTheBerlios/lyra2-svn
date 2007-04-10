using System.Collections;
using System.Collections.Generic;

namespace Lyra2
{
    class SongQuery : ISongQuery
    {
        // query
        private string query;
        private IFilter compiledQuery;

        // settings
        private SearchType type = SearchType.All;
        private bool caseSensitive = false;

        // mapped results
        private List<Song> results = null;

        // valid flag (depends on current index version)
        private long validId = SongQueryEngine.IndexVersion;
        public bool Valid
        {
            get { return this.validId == SongQueryEngine.IndexVersion; }
        }

        public SongQuery(string query)
        {
            this.query = query;
            this.compiledQuery = SongQueryEngine.CompileQuery(query);
        }

        #region ISongQuery Members

        public SongFilter Filter
        {
            get
            {
                return this.compiledQuery.Filter;
            }
        }

        public string Query
        {
            get { return this.query; }
            set
            {
                this.query = value;
                this.compiledQuery = SongQueryEngine.CompileQuery(value);
                this.results = null;
            }
        }

        public List<Song> Results(IIDToSongMapper mapper)
        {
            if (this.results == null)
            {
                

            }
            return this.results;
        }

        public SearchType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public bool CaseSensitive
        {
            get { return this.caseSensitive; }
            set { this.caseSensitive = value; }
        }

        #endregion

        #region IEnumerable<Song> Members

        public IEnumerator<Song> GetEnumerator()
        {
            return this.results.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.results.GetEnumerator();
        }

        #endregion

    }
}
