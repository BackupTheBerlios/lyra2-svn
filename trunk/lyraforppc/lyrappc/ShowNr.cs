using System;

namespace lyrappc
{
	/// <summary>
	/// Summary description for ShowNr.
	/// </summary>
	public class ShowNr : ISongFilter
	{
		private int nr;
		public ShowNr(int nr)
		{
			this.nr = nr;
		}
		#region ISongFilter Members

		public int Show(Song song)
		{
			return song.isNr(this.nr);
		}

		#endregion
	}
}
