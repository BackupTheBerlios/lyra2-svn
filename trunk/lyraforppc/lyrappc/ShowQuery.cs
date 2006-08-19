using System;

namespace lyrappc
{
	/// <summary>
	/// Summary description for ShowQuery.
	/// </summary>
	public class ShowQuery : ISongFilter
	{
		private string query;
		public ShowQuery(string query)
		{
			this.query = query;
		}
		#region ISongFilter Members

		public int Show(Song song)
		{
			return song.contains(this.query)?0:-1;
		}

		#endregion
	}
}
