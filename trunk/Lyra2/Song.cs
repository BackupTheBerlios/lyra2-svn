using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Lyra2
{
    public class Song
    {
        private long id;

        public const int NA = -1;

        private int nr = Song.NA;
        private string title = "";
        private List<string> pages = new List<string>();

        private Image background = null;
        private float imgAlpha = 1.0f;
        private string defaultBgColor = "";
        private string defaultTextColor = "";
        private SongLanguage lang;

        private List<string> tags = new List<string>();
    }

    enum SongLanguage
    {
        German, English, French, Italian, Hebrew, Spanish, Latin, Other
    }
}
