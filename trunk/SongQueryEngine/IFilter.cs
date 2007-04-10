using System.Collections.Generic;

namespace Lyra2
{
    public interface IFilter : IEnumerable<RankedID>
    {
        bool Accept(Song song);

        SongFilter Filter { get; }

        SearchType Type { get; set; }

        bool CaseSensitive { get; set; }

        List<string> RankedIDs { get; }
    }
}
