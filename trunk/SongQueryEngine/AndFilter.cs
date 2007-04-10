using System.Collections.Generic;
using C5;
using System.Collections;

namespace Lyra2
{
    class AndFilter : IFilter
    {
        private IFilter leftFilter;
        private IFilter rightFilter;

        public AndFilter(IFilter leftFilter, IFilter rightFilter)
        {
            this.leftFilter = leftFilter;
            this.rightFilter = rightFilter;
        }

        #region IFilter Members

        public bool Accept(Song song)
        {
            return this.leftFilter.Accept(song) && this.rightFilter.Accept(song);
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
            get { return this.leftFilter.Type; }
            set { this.leftFilter.Type = value; this.rightFilter.Type = value; }
        }

        public bool CaseSensitive
        {
            get { return this.leftFilter.CaseSensitive; }
            set { this.leftFilter.CaseSensitive = value; this.rightFilter.CaseSensitive = value; }
        }

        public List<string> RankedIDs
        {
            get { return RankedID.RankIDs(this);  }
        }

        #endregion

        #region IEnumerable<RankedID> Members

        public IEnumerator<RankedID> GetEnumerator()
        {
            IDCache cache = new IDCache();

            foreach (RankedID rid in this.leftFilter)
            {
                cache.Add(rid);
            }

            IDCache results = new IDCache();
            foreach (RankedID rid in this.rightFilter)
            {
                if (cache.Contains(rid))
                {
                    RankedID resRid = new RankedID(rid.ID, rid.Boost);
                    cache.Find(ref resRid);
                    resRid += rid;
                    results.Add(resRid);
                }
                else
                {
                    results.Add(rid);
                }
            }

            return results.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            IDCache cache = new IDCache();

            foreach (RankedID rid in this.leftFilter)
            {
                cache.Add(rid);
            }

            List<RankedID> results = new List<RankedID>();
            foreach (RankedID rid in this.rightFilter)
            {
                if (cache.Contains(rid))
                {
                    RankedID resRid = new RankedID(rid.ID, rid.Boost);
                    cache.Find(ref resRid);
                    resRid += rid;
                    results.Add(resRid);
                }
                else
                {
                    results.Add(rid);
                }
            }

            return results.GetEnumerator();
        }

        #endregion

        public override string ToString()
        {
            return "AND" + Utils.WINNL + "(" + Utils.WINNL + this.leftFilter.ToString() + this.rightFilter.ToString() + ")" + Utils.WINNL;
        }
    }
}
