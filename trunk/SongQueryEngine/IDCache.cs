using C5;

namespace Lyra2
{
    class IDCache : HashSet<RankedID>
    {
        // valid flag (depends on current index version)
        private long validId = SongQueryEngine.IndexVersion;
        public bool Valid
        {
            get { return this.validId == SongQueryEngine.IndexVersion; }
        }

        public bool Contains(Song song)
        {
            return this.Contains(new RankedID(song.ID, 0.0f));
        }

        public bool Contains(string id)
        {
            return this.Contains(new RankedID(id, 0.0f));
        }

        public override bool Add(RankedID item)
        {
            if(this.Contains(item))
            {
                RankedID rid = new RankedID(item.ID, item.Boost);
                this.Find(ref rid);
                rid += item;
                return true;
            }
            return base.Add(item);
        }
    }
}
