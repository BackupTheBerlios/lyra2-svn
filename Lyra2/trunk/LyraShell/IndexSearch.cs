using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System.Collections.Generic;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Summary description for IndexSearch
    /// </summary>
    public class IndexSearch : ISearch
    {
        private readonly string indexDir = Application.StartupPath + "\\index";
        private ICollection songList;
        private Hashtable nrIndex;
        private readonly StandardAnalyzer indexAnalyzer;

        public IndexSearch(ICollection songList, bool forceReIndex)
        {
            this.SetSongList(songList);
            DirectoryInfo indexDirInfo = new DirectoryInfo(this.indexDir);
            this.indexAnalyzer = new StandardAnalyzer(new FileInfo(Application.StartupPath + "\\data\\stopwords.txt"), false);

            try
            {
                if (!indexDirInfo.Exists || forceReIndex || this.CheckIfFileChanged()) this.GenerateIndex(this.songList);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message + "\n" + ex.StackTrace);
                throw;
            }
        }

        public IndexSearch(ICollection songList)
            : this(songList, false)
        {
        }

        public void ReIndex(ICollection songList)
        {
            this.SetSongList(songList);
            try
            {
                this.GenerateIndex(this.songList);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void SetSongList(ICollection songList)
        {
            this.songList = songList;
            this.nrIndex = new Hashtable();
            foreach (Song song in songList)
            {
                this.nrIndex.Add(song.Number, song);
            }
        }

        #region ISearch Members

        public bool SearchCollection(string query, SortedList list,
                                     SongListBox resultBox, bool text, bool matchCase, bool whole, bool trans, SortMethod sortMethod)
        {
            DirectoryInfo indexDir = new DirectoryInfo(this.indexDir);
            IndexSearcher searcher = new IndexSearcher(indexDir.FullName);
            QueryParser parser = new QueryParser(text ? "text" : "title", this.indexAnalyzer);

            LyraQuery lQuery = SearchUtil.CreateLyraQuery(query, whole);
            if (lQuery.LuceneQuery != "")
            {
                Query luceneQuery = parser.Parse(lQuery.LuceneQuery);
                Hits hits = searcher.Search(luceneQuery);

                List<ISong> songs = new List<ISong>();
                resultBox.Ratings.Clear();

                for (int i = 0; i < hits.Length(); i++)
                {
                    Document doc = hits.Doc(i);
                    int nr = Int32.Parse(doc.GetField("nr").StringValue());
                    Song song = (Song)this.nrIndex[nr];
                    if (song != null)
                    {
                        songs.Add(song);
                        resultBox.Ratings.Add(song, hits.Score(i));
                    }
                }

                // sort results
                songs.Sort();
                int countNumbers = 0;
                // search for nr
                if (lQuery.Numbers != null)
                {
                    for (int i = lQuery.Numbers.Count - 1; i >= 0; i--)
                    {
                        int nr = lQuery.Numbers[i];
                        Song song = this.nrIndex[nr] as Song;
                        if (song != null)
                        {
                            songs.Insert(0, song);
                            countNumbers++;
                        }
                    }
                }

                //docs.Sort(new BoostSorter());
                lock (resultBox)
                {
                    resultBox.BeginUpdate();
                    resultBox.Items.Clear();
                    foreach (Song song in songs)
                    {
                        resultBox.Items.Add(song);
                    }
                    resultBox.SetSearchTags(GetTags(query));
                    resultBox.NrOfNumberMatches = countNumbers;
                    resultBox.EndUpdate();
                    resultBox.Sort(sortMethod);
                }
            }
            searcher.Close();
            return true;
        }

        private static IList<string> GetTags(string query)
        {
            IList<string> tags =
                   new List<string>(
                       query.Replace("*", "").Replace("?", "").Replace("+", "").Replace("-", "").ToLowerInvariant().Split(
                           new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            for (int i = 0; i < tags.Count; i++)
            {
                int nr;
                if (Int32.TryParse(tags[i], out nr) && nr >= 0 && nr < 10000)
                {
                    tags[i] = Util.toFour(nr);
                }
            }
            return tags;
        }

        #endregion

        private void GenerateIndex(ICollection songList)
        {
            try
            {
                // set new songList and recreate number index
                this.SetSongList(songList);
                // create empty index directory
                DirectoryInfo indexDir = new DirectoryInfo(this.indexDir);
                if (indexDir.Exists)
                {
                    indexDir.Delete(true);
                }
                indexDir.Create();

                // open index writer
                IndexWriter writer = new IndexWriter(this.indexDir, this.indexAnalyzer, true);
                foreach (Song song in songList)
                {
                    AddSong(writer, song);
                }

                // save index
                writer.Optimize();
                writer.Close();

                // save hash
                FileInfo curtext = new FileInfo(Application.StartupPath + "\\" + Util.URL);
                FileInfo hash = new FileInfo(this.indexDir + "\\hash");
                if (hash.Exists) hash.Delete();
                StreamWriter fwriter = new StreamWriter(hash.FullName);
                fwriter.Write(Util.MD5FileHash(curtext));
                fwriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }
        }

        private static void AddSong(IndexWriter writer, ISong song)
        {
            try
            {
                Document songDoc = new Document();
                Field textField = new Field("text", song.Text ?? "" + " " + song.Title ?? "", Field.Store.NO, Field.Index.TOKENIZED);
                Field titleField = new Field("title", song.Title ?? "", Field.Store.NO, Field.Index.TOKENIZED);
                Field nrField = new Field("nr", song.Number.ToString(), Field.Store.YES, Field.Index.TOKENIZED);
                songDoc.Add(nrField);
                songDoc.Add(titleField);
                songDoc.Add(textField);
                writer.AddDocument(songDoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }

        private bool CheckIfFileChanged()
        {
            try
            {
                FileInfo curtext = new FileInfo(Application.StartupPath + "\\" + Util.URL);
                FileInfo hash = new FileInfo(indexDir + "\\hash");
                if (!hash.Exists) return true;
                StreamReader reader = new StreamReader(hash.FullName);
                string hashStr = reader.ReadToEnd();
                reader.Close();
                // Console.Out.WriteLine(hashStr != Util.MD5FileHash(curtext) ? "changed" : "ok");
                return hashStr != Util.MD5FileHash(curtext); // file changed if hash not equal
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
            {
            }
            return false;
        }
    }

    /*
        internal class BoostSorter : IComparer
        {
            #region IComparer Members

            public int Compare(object x, object y)
            {
                Document xDoc = x as Document;
                Document yDoc = y as Document;
                if (xDoc != null && yDoc != null)
                {
                    float diff = xDoc.GetBoost() - yDoc.GetBoost();
                    if (Math.Abs(diff) < 0.1)
                    {
                        return 0;
                    }
                    else if (diff < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                return 0;
            }

            #endregion
        }
    */
}