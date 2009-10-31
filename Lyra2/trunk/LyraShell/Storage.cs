using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Stores and manages the lyrics of the current workspace.
    /// Wrapper-Class for PhysicalXML. Access for commit/load only
    /// through this class! GUI shouldn't have direct access to these methods.
    /// </summary>
    public class Storage : IStorage
    {
        private SortedList SongList;
        private IPhysicalStorage PStorage;
        private GUI owner;

        private ISearch search;

        private bool toBeCommited = false;

        public bool ToBeCommited
        {
            get { return this.toBeCommited; }
            set { this.toBeCommited = value; }
        }

        public Storage(string url, GUI owner)
        {
            this.PStorage = new PhysicalXML(Util.BASEURL + "\\" + url);
            this.SongList = this.PStorage.getSongs();
            this.owner = owner;
            // this.search = new Search();
            this.search = new IndexSearch(this.SongList.Values); // lucene searcher!
            Util.NRSONGS = this.SongList.Count;
        }

        public bool Commit()
        {
            if (!Util.NOCOMMIT)
            {
                if (this.PStorage.Commit(this.SongList))
                {
                    this.toBeCommited = false;
                    Util.NRSONGS = this.SongList.Count;
                    this.search = new IndexSearch(this.SongList.Values, true); // lucene searcher! (re-index!)
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Util.MBoxError("Sie haben keine Berechtigung, Änderungen vorzunehmen!\n" +
                               "Entfernen Sie unter Extras->Optionen..., Allgemein... den Schreibschutz\n" +
                               "oder wenden Sie sich an den Administrator.");
                return false;
            }
        }

        public bool cleanSearchIndex()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.owner.Enabled = false;
            try
            {
                this.search = new IndexSearch(this.SongList.Values, true); // lucene searcher! (re-index!)	
            }
            catch (Exception)
            {
                this.owner.Enabled = true;
                Cursor.Current = Cursors.Default;
                return false;
            }
            this.owner.Enabled = true;
            Cursor.Current = Cursors.Default;
            return true;
        }

        // get Song by ID
        public ISong getSongById(object id)
        {
            return (Song) this.SongList[id];
        }

        // get Song by Number
        public ISong getSong(int nr)
        {
            string id = "s" + Util.toFour(nr);
            Song ret;
            if (this.SongList.ContainsKey(id))
            {
                ret = (Song) this.SongList[id];
                if (ret.Deleted)
                    ret = null;
                return ret;
            }
            else
            {
                if (this.SongList.ContainsKey("s7001"))
                {
                    int i = this.SongList.IndexOfKey("7001");
                    for (; i < this.SongList.Count; i++)
                    {
                        if (((Song) this.SongList.GetByIndex(i)).Number == nr)
                        {
                            ret = (Song) this.SongList.GetByIndex(i);
                            if (ret.Deleted)
                                ret = null;
                            return ret;
                        }
                    }
                }
            }
            return null;
        }

        // reset to XML-File status! pay attention!
        public void ResetToLast()
        {
            this.SongList = this.PStorage.getSongs();
            Util.NRSONGS = this.SongList.Count;
            this.owner.UpdateListBox();
            this.owner.ToUpdate(false);
        }

        // import
        public bool Import(string url, bool append)
        {
            try
            {
                if (!append)
                {
                    this.SongList = this.PStorage.getSongs(new SortedList(), url, true);
                }
                else
                {
                    this.SongList = this.PStorage.getSongs(this.SongList, url, true);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // export
        public bool Export(string url)
        {
            try
            {
                File.Copy(Util.BASEURL + "\\" + Util.URL, url, true);
                return true;
            }
            catch (Exception ex)
            {
                Util.MBoxError("Fehler beim Exportieren\n" + ex.Message, ex);
            }
            return false;
        }

        public void displaySongs(ListBox box)
        {
            box.BeginUpdate();
            box.Items.Clear();
            foreach (Song song in this.SongList.Values)
            {
                if (!song.Deleted)
                {
                    box.Items.Add(song);
                }
            }
            Util.NRSONGS = box.Items.Count;
            box.EndUpdate();
        }

        public void Clear()
        {
            this.SongList.Clear();
        }

        public void RemoveSong(string id)
        {
            this.SongList.Remove(id);
        }

        public void AddSong(ISong song)
        {
            this.SongList.Add(song.ID, song);
        }


        // Search
        public void Search(string query, ListBox resultBox, bool text, bool matchCase, bool whole, bool trans)
        {
            if (!this.search.SearchCollection(query, this.SongList, resultBox, text, matchCase, whole, trans))
            {
                resultBox.Items.Add("Leider keinen passenden Eintrag gefunden.");
                this.owner.Status = "query done - no results :-(";
            }
            else
            {
                this.owner.Status = "query done - successful :-)";
            }
        }

        // Export for Pocket PC
        private string formatText(string text)
        {
            string ret = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '<')
                {
                    while (i < text.Length - 1 && text[i++] != '>') ;
                    i--;
                }
                else
                {
                    if (text[i] == '\n' || text[i] == '\t' || text[i] == '\r' || text[i] == '>' || text[i] == '%')
                    {
                        ret += " ";
                    }
                    else
                    {
                        ret += text[i];
                    }
                }
            }
            if (ret.Length > 100) ret = ret.Substring(0, 100);
            return ret + "...";
        }

        public bool ExportPPC(string url)
        {
            try
            {
                StreamWriter sw = new StreamWriter(url, false);
                sw.AutoFlush = true;
                sw.WriteLine("[ lyra for Pocket PC ]");
                sw.WriteLine();
                sw.WriteLine("####$SNAPSHOT");
                sw.WriteLine(DateTime.Now.ToShortDateString() + "@" + DateTime.Now.ToShortTimeString());
                sw.WriteLine("####$COUNT");
                sw.WriteLine(this.SongList.Count.ToString());
                sw.WriteLine("####$DATA");

                IDictionaryEnumerator en = this.SongList.GetEnumerator();
                en.Reset();
                while (en.MoveNext())
                {
                    Song song = (Song) en.Value;
                    string title = song.Title.Length > 0 ? song.Title : "  ";
                    string txt = this.formatText(song.Text);
                    sw.WriteLine(song.Number.ToString() + " " + title + "%" + txt);
                }
                sw.Close();
                string text = "Liste für Pocket PC wurde erfolgreich erstellt!" + Util.NL + "Sie finden Sie in " + url;
                MessageBox.Show(this.owner, text, "lyra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}