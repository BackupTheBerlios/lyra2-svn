using System;

namespace lyrappc
{
	/// <summary>
	/// Summary description for ShowAll.
	/// </summary>
	public class ShowAll : ISongFilter
	{
		#region ISongFilter Members

		public int Show(Song song)
		{
			return 0;
		}

		#endregion
	}
}
