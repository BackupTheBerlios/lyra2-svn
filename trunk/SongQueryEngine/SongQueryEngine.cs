using System.Collections.Generic;

namespace Lyra2
{
    public class SongQueryEngine
    {
        public static List<Song> ExecuteQuery(string query)
        {
            return null;
        }

        public static SongFilter CompileQuery(string query)
        {
            return null;
        }

        public static ISongQuery CreateQuery(string query)
        {
            return new SongQuery(query);
        }
    }
}
