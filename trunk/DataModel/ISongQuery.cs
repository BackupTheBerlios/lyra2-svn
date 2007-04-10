using System.Collections.Generic;

namespace Lyra2
{
    /// <summary>
    /// General song filter delegate.
    /// </summary>
    /// <param name="song"></param>
    /// <returns></returns>
    public delegate bool SongFilter(Song song);

    public interface ISongQuery : IEnumerable<Song>
    {
        // query
        string Query { get; }
        SongFilter Filter { get; }
        // results
        List<Song> Results(IIDToSongMapper mapper);
        // settings
        SearchType Type { get; set; }
        bool CaseSensitive { get; set; }
    }

    public enum SearchType
    {
        All, TitleOnly, NumberQuery
    }
}
