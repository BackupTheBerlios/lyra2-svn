using System.Windows.Forms;

namespace lyra2
{
	/// <summary>
	/// Storage Interface
	/// </summary>
	public interface IStorage
	{
		bool Commit();
		void ResetToLast();
		Song getSongById(object id);
		Song getSong(int nr);
		void Clear();
		void AddSong(Song song);
		void RemoveSong(string id);

		bool Import(string url, bool append);
		bool Export(string url);
		bool ExportPPC(string url);

		void displaySongs(ListBox box);

		void Search(string query, ListBox resultBox, bool text, bool matchCase, bool whole, bool trans);

		bool ToBeCommited { get; set; }
		
		bool cleanSearchIndex();
	}
}