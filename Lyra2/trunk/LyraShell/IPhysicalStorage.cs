using System.Collections;

namespace Lyra2.LyraShell
{
	/// <summary>
	/// Interface Physical Storage
	/// </summary>
	public interface IPhysicalStorage
	{
		SortedList getSongs();
		SortedList getSongs(SortedList songs, string url, bool imp);

		bool Commit(SortedList internList);
		string commitTranslations(SortedList trans);
	}
}