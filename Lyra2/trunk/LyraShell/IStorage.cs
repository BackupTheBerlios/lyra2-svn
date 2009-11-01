using System.Windows.Forms;

namespace Lyra2.LyraShell
{
	/// <summary>
	/// Storage Interface
	/// </summary>
	public interface IStorage
	{
		bool Commit();
		void ResetToLast();
		ISong getSongById(object id);
		ISong getSong(int nr);
		void Clear();
		void AddSong(ISong song);
		void RemoveSong(string id);

		bool Import(string url, bool append);
		bool Export(string url);
		bool ExportPPC(string url);

		void displaySongs(ListBox box);

        void Search(string query, SongListBox resultBox, bool text, bool matchCase, bool whole, bool trans, SortMethod sortMethod);

		bool ToBeCommited { get; set; }
		
		bool cleanSearchIndex();
	}
}