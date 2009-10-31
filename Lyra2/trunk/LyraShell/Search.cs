using System.Collections;
using System.Windows.Forms;
using Lyra2.UtilShared;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Zusammendfassende Beschreibung für Search.
    /// </summary>
    public class Search : ISearch
    {
        public bool SearchCollection(string query, SortedList list, ListBox resultBox,
                                     bool text, bool matchCase, bool whole, bool trans)
        {
            long start = Util.getCurrentTicks();
            IDictionaryEnumerator en = list.GetEnumerator();
            en.Reset();
            string target;
            Song song;
            bool found = false;
            while (en.MoveNext())
            {
                song = (Song) en.Value;

                // only title?
                target = text ? (song.Title + " " + song.Text) : song.Title;

                // with translations?
                if (trans)
                {
                    target += (" " + this.queryTrans(song.Translations, text));
                }

                // if case doesn't need to be matched, make all letters small ones...
                if (!matchCase)
                {
                    target = target.ToLower();
                    query = query.ToLower();
                }

                if (this.Or(query, this.cleanTarget(target), whole))
                {
                    resultBox.Items.Add(song);
                    found = true;
                }
            }
            Util.addSearchTime(Util.getCurrentTicks() - start);
            return found;
        }

        public string queryTrans(SortedList trans, bool text)
        {
            string query = "";
            IDictionaryEnumerator en = trans.GetEnumerator();
            en.Reset();
            while (en.MoveNext())
            {
                query += ((Translation) en.Value).Title;
                if (text) query += " " + ((Translation) en.Value).Text;
            }
            return query;
        }

        private bool And(string andquery, string target, bool whole)
        {
            string[] query = andquery.Split('+');
            for (int i = 0; i < query.Length; i++)
            {
                if (!this.Contains(this.cleanKey(query[i]), target, whole))
                    return false;
            }

            return true;
        }

        private bool Or(string orquery, string target, bool whole)
        {
            string[] query = orquery.Split('-');
            for (int i = 0; i < query.Length; i++)
            {
                if (this.And(query[i], target, whole))
                    return true;
            }
            return false;
        }

        private string cleanKey(string key)
        {
            if (key.Length > 0 && key[0] == ' ')
            {
                key = key.Substring(1, key.Length - 1);
            }
            if (key.Length > 0 && key[key.Length - 1] == ' ')
            {
                key = key.Substring(0, key.Length - 1);
            }
            return key;
        }

        private string cleanTarget(string target)
        {
            string ret = "";
            bool opened = false;
            bool lastspace = false;
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == '\n' ||
                    target[i] == '.' ||
                    target[i] == ',')
                {
                    if (!lastspace)
                        ret += " ";
                    lastspace = true;
                }
                else if (target[i] == '<')
                {
                    if (i > 0 && target[i - 1] != ' ') ret += " ";
                    opened = true;
                    lastspace = true;
                }
                else if (!opened)
                {
                    if (!(lastspace && target[i] == ' '))
                    {
                        ret += target[i].ToString();
                        lastspace = false;
                    }
                }
                else if (target[i] == '>')
                {
                    opened = false;
                }
            }
            return ret;
        }

        private bool Contains(string key, string target, bool whole)
        {
            int i = 0;
            while (i <= (target.Length - key.Length))
            {
                if (target.Substring(i, key.Length).Equals(key))
                {
                    if (whole)
                    {
                        if ((i > 0 && target[i - 1] == ' ') &&
                            ((i + key.Length) < target.Length && target[i + key.Length] == ' '))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                i++;
            }
            return false;
        }
    }
}