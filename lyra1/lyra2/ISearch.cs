using System.Collections;
using System.Windows.Forms;

namespace lyra2
{
	/// <summary>
	/// Search Interface
	/// </summary>
	interface ISearch
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