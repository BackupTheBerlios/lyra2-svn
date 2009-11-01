using System.Collections;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Search Interface
    /// </summary>
    public interface ISearch
    {
        bool SearchCollection(string query,
                              SortedList list,
                              SongListBox resultBox,
                              bool text,
                              bool matchCase,
                              bool whole,
                              bool trans,
                              SortMethod sortMethod);
    }

    public enum SortMethod
    {
        NumberAscending = 0,
        NumberDescending = 1,
        RatingDescending = 2,
        RatingAscending = 3,
        TitleAscending = 4,
        TitleDescending = 5
    }
}