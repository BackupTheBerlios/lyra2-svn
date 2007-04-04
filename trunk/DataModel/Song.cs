using System;
using System.Collections.Generic;
using System.Text;

namespace Lyra2
{
    /// <summary>
    /// song wrapper
    /// </summary>
    public class Song
    {    
        private readonly string id;
        private int nr = Utils.NA;
        private string title = "";
        private List<string> pages = new List<string>();

        private SongLanguage lang;
        private List<string> tags = new List<string>();
    }

    enum SongLanguage
    {
        German, English, French, Italian, Hebrew, Spanish, Latin, Other
    }
}
