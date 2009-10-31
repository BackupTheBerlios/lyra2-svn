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
		                      ListBox resultBox,
		                      bool text,
		                      bool matchCase,
		                      bool whole,
		                      bool trans);


	}
}