using System.Collections;
using System.Collections.Generic;

namespace Lyra2
{
    class SongQuery : ISongQuery
    {
        private SongFilter filter;
        private string query;
        private List<Song> results;

        public SongQuery(SongFilter filter, string query)
        {
            this.filter = filter;
            this.query = query;
            this.results = null;
        }

        public SongQuery(string query)
        {
            this.query = query;
            this.filter = null;
            this.results = null;
        }

        #region ISongQuery Members

        public SongFilter Filter
        {
            get
            {
                if (this.filter == null)
                {
                    // lazy filter creation
                    this.filter = SongQueryEngine.CompileQuery(this.query);
                }
                return this.filter;
            }
        }

        public string Query
        {
            get { return this.query; }
            set
            {
                this.Reset();
                this.query = value;
            }
        }

        public List<Song> Results
        {
            get
            {
                if(this.results == null)
                {
                    this.results = SongQueryEngine.ExecuteQuery(this.query);
                }
                return this.results;
            }
        }

        public void Reset()
        {
            this.filter = null;
            this.results = null;
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
