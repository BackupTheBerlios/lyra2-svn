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
    }
}
