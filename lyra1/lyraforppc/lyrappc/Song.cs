using System.Collections;

namespace lyrappc
{
	/// <summary>
	/// Summary description for Song.
	/// </summary>
	public class Song : IComparer
	{
		private int nr;
		private string title;
		private string text;
		public int Nummer
		{
			get { return this.nr; }
		}
		public string Titel
		{
			get { return this.title; }
		}
		public string Text
		{
			get { return this.text; }
		}

		public Song(int nr, string title, string text)
		{
			this.nr = nr;
			this.title = title;
			this.text = text;
		}

		private string ToFourString(int nr)
		{
			if (nr <= 0) return "0000";
			string toret = nr.ToString();
			while ((nr*=10) < 10000)
			{
				toret = "0" + toret;
			}
			return toret;
		}
		public override string ToString()
		{
			string ret = this.ToFourString(nr) + " " + this.title;
			if (ret.Length>30) ret = ret.Substring(0,30) + "...";
			return ret;
		}

		public int Compare(object x, object y)
		{
			if (x is Song && y is Song)
			{
				Song xs = (Song)x;
				Song ys = (Song)y;
				return (xs.nr > ys.nr)?1:(xs.nr < ys.nr)?-1:0;
			}
			return 0;
		}

		private static IComparer comparer = new Song(0,"","");
		public static IComparer getComparer()
		{
			return Song.comparer;
		}

		public bool contains(string query)
		{
			string s = this.title.ToLower();
			query = query.ToLower();
			int n = query.Length;
			for (int i=0;i<s.Length-n;i++)
			{
				if (s.Substring(i,n) == query) return true;
			}
			return false;
		}

		public int isNr(int nr)
		{
			return this.nr == nr?0:this.nr>nr?1:-1;
		}

	}
}
