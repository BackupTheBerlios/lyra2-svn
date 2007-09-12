using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

namespace lyra2
{
	/// <summary>
	/// Summary description for IndexSearch.
	/// </summary>
	public class IndexSearch : ISearch
	{
		private string INDEXDIR = Application.StartupPath + "\\index";
		private ICollection songList;
		private Hashtable nrIndex;
			
		public IndexSearch(ICollection songList, bool forceReIndex)
		{
			this.setSongList(songList);
			DirectoryInfo indexDir = new DirectoryInfo(INDEXDIR);
			
			try
			{
				if(!indexDir.Exists || forceReIndex || this.checkIfFileChanged()) this.generateIndex(this.songList);
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine(ex.Message + "\n" + ex.StackTrace);
				throw ex;
			}
		}
		
		public IndexSearch(ICollection songList) : this(songList, false) {}
		
		public void ReIndex(ICollection songList)
		{
			this.setSongList(songList);
			try
			{
				this.generateIndex(this.songList);
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine(ex.Message + "\n" + ex.StackTrace);
			}
		}
		
		public void setSongList(ICollection songList)
		{
			this.songList = songList;
			this.nrIndex = new Hashtable();
			foreach(Song song in songList)
			{
				this.nrIndex.Add(song.Number, song);
			}
		}
		
		private string toLuceneQuery(string lyraQuery, bool exact)
		{
			ArrayList words = new ArrayList();
			string[] wordParts = lyraQuery.Split(' ');
			for(int i=0;i<wordParts.Length;i++)
			{
				if(wordParts[i] != "")
				{
					string word = wordParts[i];
					if(word.StartsWith("\""))
					{
						string nextWord = word;
						while(!wordParts[i].EndsWith("\"") && i < wordParts.Length-1)
						{
							nextWord += " " + wordParts[++i];
						}
						word = "\"" + nextWord.Trim('\"') + "\"";
					}
					while(word.StartsWith("*") || word.StartsWith("?"))
					{
						if(word.Length > 1)
						{
							word = word.Substring(1);
						}
						else
						{
							word = "";
						}
					}
					if(word != "")
					{
						words.Add(word);
					}
				}
			}
			string query = "";
			foreach(string word in words)
			{
				if(exact || word.EndsWith("\"") || word.IndexOfAny(new char[] {'*', '?'}) > 0)
				{
					query += "+" + word + " ";
				}
				else
				{
					query += "+" + word + "* ";
				}
			}
			
			// Console.Out.WriteLine(lyraQuery + " --> " + query);
			return query;	
		}
		
		#region ISearch Members
		
		public bool SearchCollection(string query, System.Collections.SortedList list, 
		                             System.Windows.Forms.ListBox resultBox, bool text, bool matchCase, bool whole, bool trans)
		{	
			DirectoryInfo indexDir = new DirectoryInfo(INDEXDIR);
			IndexSearcher searcher = new IndexSearcher(indexDir.FullName);
			QueryParser parser = new QueryParser(text ? "text" : "title", new StandardAnalyzer());
			
			string lQuery = this.toLuceneQuery(query, whole);
			if(lQuery != "")
			{
				Query luceneQuery = parser.Parse(lQuery);
				Hits hits = searcher.Search(luceneQuery);
				
				ArrayList docs = new ArrayList();
				for (int i = 0; i < hits.Length(); i++) 
				{
					Document doc = hits.Doc(i);
					docs.Add(doc);
				}
				ArrayList songs = new ArrayList();
				foreach(Document doc in docs)
				{
					int nr = Int32.Parse(doc.GetField("nr").StringValue());
					Song s = (Song)this.nrIndex[nr];
					if(s != null)
					{
						songs.Add(s);
					}
					// Console.Out.WriteLine(s.Number + " " + s.Title + " [boost:" + doc.GetBoost() + "]");
				}
				songs.Sort();			
				
				//docs.Sort(new BoostSorter());
				lock(resultBox)
				{
					resultBox.BeginUpdate();
					resultBox.Items.Clear();
					foreach(Song song in songs)
					{
						resultBox.Items.Add(song);
					}
					resultBox.EndUpdate();
				}
			}
			searcher.Close();
			return true;
		}

		#endregion
		
		public void generateIndex(ICollection songList)
		{
			// set new songList and recreate number index
			this.setSongList(songList);
			// create empty index directory
			DirectoryInfo indexDir = new DirectoryInfo(INDEXDIR);
			if(indexDir.Exists)
			{
				indexDir.Delete(true);
				indexDir.Create();
			}
			// open index writer
			IndexWriter writer = new IndexWriter(INDEXDIR, new StandardAnalyzer(), true);
			foreach(Song song in songList)
			{
				this.addSong(writer, song);
			}
			
			// save index
			writer.Optimize();
			writer.Close();
			
			// save hash
			FileInfo curtext = new FileInfo(Application.StartupPath + "\\" + Util.URL);
			FileInfo hash = new FileInfo(INDEXDIR + "\\hash");
			if(hash.Exists) hash.Delete();
			StreamWriter fwriter = new StreamWriter(hash.FullName);
			fwriter.Write(Util.MD5FileHash(curtext));
			fwriter.Close();
		}
		
		private void addSong(IndexWriter writer, Song song)
		{
			Document songDoc = new Document();
			Field textField = new Field("text", song.Text + " " + song.Title, Field.Store.NO, Field.Index.TOKENIZED);
			Field titleField = new Field("title", song.Title, Field.Store.NO, Field.Index.TOKENIZED);
			Field nrField = new Field("nr", song.Number.ToString(), Field.Store.YES, Field.Index.TOKENIZED);
			songDoc.Add(nrField);
			songDoc.Add(titleField);
			songDoc.Add(textField);
			writer.AddDocument(songDoc);
		}
		
		public bool checkIfFileChanged()
		{
			try
			{
				FileInfo curtext = new FileInfo(Application.StartupPath + "\\" + Util.URL);
				FileInfo hash = new FileInfo(INDEXDIR + "\\hash");
				if(!hash.Exists) return true;
				StreamReader reader = new StreamReader(hash.FullName);
				string hashStr = reader.ReadToEnd();
				reader.Close();
				// Console.Out.WriteLine(hashStr != Util.MD5FileHash(curtext) ? "changed" : "ok");
				return hashStr != Util.MD5FileHash(curtext); // file changed if hash not equal
			}
			catch(Exception)
			{
			}
			return false;
		}
	}
	
	class BoostSorter : IComparer
	{
		#region IComparer Members

		public int Compare(object x, object y)
		{
			Document xDoc = x as Document;
			Document yDoc = y as Document;
			if(xDoc != null && yDoc != null)
			{
				float diff = xDoc.GetBoost() - yDoc.GetBoost();
				if(Math.Abs(diff) < 0.1)
				{
					return 0;
				}
				else if(diff < 0)
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

}
