using System;
using System.Collections.Generic;
using System.Text;

namespace Lyra2
{
    interface ISongView
    {
        /// <summary>
        /// Displays the given song according to SongView's features...
        /// </summary>
        /// <param name="song">Song to be displayed</param>
        void ShowSong(Song song);

        /// <summary>
        /// Displays the given songs according to SongView's features...
        /// </summary>
        /// <param name="songlist">List of songs to be displayed</param>
        /// <param name="startindex">Index of first song to be displayed</param>
        void ShowSongs(List<Song> songlist, int startindex);

        /// <summary>
        /// Displays the given songs according to SongView's features...
        /// Starting with the first song
        /// </summary>
        /// <param name="songlist">List of songs to be displayed</param>
        void ShowSongs(List<Song> songlist);
    }
}
