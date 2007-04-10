using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lyra2
{
    public class RankedID
    {
        public readonly string ID;
        public readonly float Boost;

        public RankedID(string id, float boost)
        {
            this.ID = id;
            this.Boost = boost;
        }

        public override bool Equals(object obj)
        {
            if (obj is RankedID)
            {
                RankedID rid = (RankedID)obj;
                return this.ID == rid.ID;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static RankedID operator +(RankedID rid1, RankedID rid2)
        {
            if (rid1.ID == rid2.ID)
            {
                return new RankedID(rid1.ID, rid1.Boost + rid2.Boost);
            }
            return null;
        }

        public static List<string> RankIDs(IFilter filter)
        {
            List<RankedID> sortedList = new List<RankedID>(filter);
            sortedList.Sort(delegate(RankedID x, RankedID y)
            {
                return -x.Boost.CompareTo(y.Boost);
            });
            List<string> ids = new List<string>();
            foreach(RankedID rid in sortedList)
            {
                ids.Add(rid.ID);
            }
            return ids;
        }
    }
}
