using System.Collections;

namespace lyra2
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