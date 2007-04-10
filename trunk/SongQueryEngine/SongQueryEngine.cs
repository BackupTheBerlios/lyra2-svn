using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Antlr.Runtime;
using Lyra2.ANTLR;

namespace Lyra2
{
    public class SongQueryEngine
    {
        // index path
        public static string INDEX_PATH = @"C:\Temp\LyraIndex";
        // index fields
        public const string INDEX_FIELD_ID = "id";
        public const string INDEX_FIELD_NR = "nr";
        public const string INDEX_FIELD_LASTUSED = "lastused";
        public const string INDEX_FIELD_TITLE = "title";
        public const string INDEX_FIELD_CONTENT = "content";

        /// <summary>
        /// Compiles the query and creates an ISongQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static ISongQuery Query(string query)
        {
            return new SongQuery(query);
        }

        public static IFilter CompileTest(string query)
        {
            return CompileQuery(query);
        }


        /// <summary>
        /// Compiles a Lyra 2.0 query
        /// </summary>
        /// <param name="query">Query string</param>
        /// <returns>Compiled query as filter tree</returns>
        internal static IFilter CompileQuery(string query)
        {
            try
            {
                // parse query
                ICharStream cs = new ANTLRStringStream(query);
                Lyra2QueryLexer lexer = new Lyra2QueryLexer(cs);
                ITokenStream tokens = new CommonTokenStream(lexer);
                Lyra2QueryParser parser = new Lyra2QueryParser(tokens);
                IFilter compiledQuery = parser.lyraQuery();
                return compiledQuery;
            }
            catch(Exception ex)
            {
                throw new LyraException("Suchanfrage ist fehlerhaft!", ex);
            }
        }

        /// <summary>
        /// Executes a Lucene.NET index query for given keyword returns a cached ID list.
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static IDCache ExecuteSimpleKeywordQuery(string keyword, SearchType type)
        {
            DirectoryInfo indexDir = new DirectoryInfo(SongQueryEngine.INDEX_PATH);
            if (indexDir.Exists)
            {
                try
                {
                    IndexSearcher searcher = new IndexSearcher(indexDir.FullName);
                    Query titleQuery = QueryParser.Parse(keyword, INDEX_FIELD_TITLE, new StandardAnalyzer());
                    Query contentQuery = QueryParser.Parse(keyword, INDEX_FIELD_CONTENT, new StandardAnalyzer());
                    Query nrQuery = QueryParser.Parse(keyword, INDEX_FIELD_NR, new StandardAnalyzer());
                    Hits titleHits = null;
                    Hits contentHits = null;
                    Hits nrHits = null;
                    switch (type)
                    {
                        case SearchType.NumberQuery:
                            nrHits = searcher.Search(nrQuery);
                            break;
                        case SearchType.All:
                            contentHits = searcher.Search(contentQuery);
                            titleHits = searcher.Search(titleQuery);
                            break;
                        case SearchType.TitleOnly:
                            titleHits = searcher.Search(titleQuery);
                            break;
                    }
                    IDCache results = new IDCache();
                    SongQueryEngine.AddHits(nrHits, results);
                    SongQueryEngine.AddHits(titleHits, results);
                    SongQueryEngine.AddHits(contentHits, results);
                    return results;
                }
                catch (Exception ex)
                {
                    throw new LyraException("Fehler bei Keyword Suche!", ex);
                }
            }
            else
            {
                throw new LyraException("Index existiert nicht!");
            }
        }

        private static IDCache AddHits(Hits hits, IDCache results)
        {
            if (hits != null)
            {
                IEnumerator e = hits.Iterator();
                while (e.MoveNext())
                {
                    Hit hit = (Hit)e.Current;
                    string id = hit.GetDocument().GetField(INDEX_FIELD_ID).StringValue();
                    float boost = hit.GetBoost();
                    RankedID rid = new RankedID(id, boost);
                    results.Add(rid);
                }
            }
            return results;
        }

        #region Index

        private static long indexVersion = 0;
        internal static long IndexVersion
        {
            get { return SongQueryEngine.indexVersion; }
        }

        private static string GetContent(Song song)
        {
            string content = "";
            foreach (string page in song.Pages)
            {
                content += page + Utils.WINNL;
            }
            return content;
        }

        private static Document GetSongDocument(Song song)
        {
            Document doc = new Document();
            // ID
            Field idField = new Field(INDEX_FIELD_ID, song.ID, true, true, false);
            // last used date
            Field lastUsedField = Field.Keyword(INDEX_FIELD_LASTUSED, song.Info.LastUsed);
            // NR
            Field nrField = new Field(INDEX_FIELD_NR, song.Number == Utils.NA ? "$$$$NA$$$$" : song.Number.ToString(), true, true, false);
            // title only (default language)
            Field titleField = Field.Text(INDEX_FIELD_TITLE, song.Title);
            // content (default language)
            string content = SongQueryEngine.GetContent(song);
            Field contentField = Field.Text(INDEX_FIELD_CONTENT, content);

            // add index fields
            doc.Add(idField);
            doc.Add(lastUsedField);
            doc.Add(nrField);
            doc.Add(titleField);
            doc.Add(contentField);
            return doc;
        }

        public static void UpdateIndex(IndexUpdateType updateType, List<Song> songs)
        {
            try
            {
                // increase index version (invalidate results based on current version)
                SongQueryEngine.indexVersion++;

                DirectoryInfo indexDir = new DirectoryInfo(SongQueryEngine.INDEX_PATH);
                if (updateType == IndexUpdateType.Rebuild)
                {
                    indexDir.Delete();
                }
                if (!indexDir.Exists)
                {
                    // create index
                    if (updateType == IndexUpdateType.Add || updateType == IndexUpdateType.Rebuild)
                    {
                        IndexWriter writer = new IndexWriter(indexDir.FullName, new StandardAnalyzer(), true);
                        foreach (Song song in songs)
                        {
                            writer.AddDocument(SongQueryEngine.GetSongDocument(song));
                        }
                        writer.Optimize();
                        writer.Close();
                    }
                    else
                    {
                        throw new LyraException("Operation nicht möglich. Index existiert nicht!", ErrorLevel.Debug);
                    }
                }
                else
                {
                    // open existing index and add songs
                    IndexWriter writer = new IndexWriter(indexDir.FullName, new StandardAnalyzer(), false);
                }
            }
            catch (LyraException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new LyraException("Index konnte nicht kreiert werden!", ex);
            }
        }

        #endregion
    }

    public enum IndexUpdateType
    {
        Rebuild, Delete, Add, Update, Clean
    }
}
