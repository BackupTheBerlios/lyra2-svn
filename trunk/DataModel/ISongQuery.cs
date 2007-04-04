using System;
using System.Collections.Generic;
using System.Text;

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
        string Query { get; }
        SongFilter Filter { get; }
        List<Song> Results { get; }

        void Reset();
    }
}
