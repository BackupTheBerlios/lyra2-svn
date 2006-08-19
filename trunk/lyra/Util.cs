using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace lyra
{
	/// <summary>
	/// static help methods, vars and constants.
	/// </summary>
	public class Util
	{
		// info & build 
		public const string NAME = "lyra";
		public const string BUILDNR = "27";
		public const string VER = "1.7.2"; // with PocketPC
		public static string BUILD = "{build 20060716." + Util.BUILDNR + "}";
		public static string GUINAME = Util.NAME; // + " v" + Util.VER + "   " + Util.BUILD;

		// lyra update
		public const string UPDATESERVER = "http://cgi.ethz.ch/~ogirard/lyraupdate";
		// status / paths
		public const int MAXOPEN = 5;
		public const int WAIT = 1000; //ms
		public static bool DELALL = false;
		public static string URL = "data\\curtext.xml";
		public static string SCHEMA = "data\\curtext.xsd";
		public static string HLPURL = "doc\\lyrahelp.chm";
		public static string NEWSURL = "doc\\buildnews.txt";
		public static string INFORTF = "doc\\info.rtf";
		public static string LISTURL = "data\\lists.xml";
		public static string BASEURL = Path.GetFullPath(".");

		// format
		public const string REF = "refrain";
		public const string SPEC = "special";
		public const string BOLD = "b";
		public const string ITALIC = "i";
		public const string BLOCK = "p";
		public const string PGBR = "pagebreak";
		public static Color REFCOLOR;
		public static Color COLOR;
		public static Font SPECFONT = null;
		public static Font TRANSFONT = null;
		public static Font FONT = null;
		public static bool refmode = true;

		// pres
		public static Color UNICOLOR;
		public static Color GRADCOL1;
		public static Color GRADCOL2;
		public static int PREMODE;
		public static bool CASCADEPIC;
		private static string picturi;
		public static Image BGIMG;

		public static string PICTURI
		{
			set
			{
				try
				{
					Util.BGIMG = Image.FromFile(value);
					Util.picturi = value;
				}
				catch (Exception)
				{
					Util.picturi = "";
					Util.BGIMG = null;
				}
			}
			get { return Util.picturi; }
		}

		// FX
		public static string[] FX = new string[6];


		// OPTIONS
		// show german title with translation?
		public static bool SHOWGER = true;
		public static bool SHOWRIGHT = true;
		public static bool NOCOMMIT = false;
		public static bool SHOWBUILDNEWS = false;
		public static bool SHOWNR = true;
		public static bool CTRLSHOWNR = false;
		public static int TIMER = 3000;


		// cons
		public Util()
		{
		}

		// help methods

		public const string NL = "\r\n";
		public const string RTNL = "{\\par}";
		public const string HTMLNL = "<br />\n\t";

		public static void MBoxError()
		{
			Util.MBoxError("", null);
		}

		public static void MBoxError(string umsg)
		{
			Util.MBoxError(umsg, null);
		}

		public static void MBoxError(string umsg, Exception ex)
		{
			string msg = "Ooops! Es ist ein Fehler aufgetreten." + Util.NL + umsg + Util.NL;
			Util.Debug(umsg, ex);
			MessageBox.Show(msg, "lyra error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static string GetDate()
		{
			string date = "";
			date += DateTime.Now.Year.ToString() + "/";
			string month = (DateTime.Now.Month < 10) ? ("0" + DateTime.Now.Month.ToString()) : DateTime.Now.Month.ToString();
			string day = (DateTime.Now.Day < 10) ? ("0" + DateTime.Now.Day.ToString()) : DateTime.Now.Day.ToString();
			date += month + "/" + day;
			return date;
		}

		public static string toFour(int nr)
		{
			string zeros = "";
			string nrstr = nr.ToString();
			while ((nr *= 10) < 10000)
			{
				zeros += "0";
			}
			return zeros + nrstr;
		}

		public static string toVertical(string hor)
		{
			string vert = "";
			for (int i = 0; i < hor.Length - 1; i++)
			{
				vert += hor[i] + Util.NL;
			}
			return vert + hor[hor.Length - 1];
		}

		// FX
		public static void OpenFile(int fnr)
		{
			if (!Util.FX[fnr].Equals("-"))
			{
				if (Util.FX[fnr].StartsWith("pict://"))
				{
					PictView.ShowPictView(Util.FX[fnr].Substring(7));
				}
				else
				{
					FileLauncher.openFile(Util.FX[fnr]);
				}
			}
		}

		// stretch an image
		public static Bitmap stretchProportional(Image img, Size bounds)
		{
			Bitmap ret;
			if (img.Width > bounds.Width || img.Height > bounds.Height)
			{
				if (img.Width/bounds.Width > img.Height/bounds.Height)
				{
					int h = img.Height*bounds.Width/img.Width;
					ret = new Bitmap(img, new Size(bounds.Width, h));
				}
				else
				{
					int w = img.Width*bounds.Height/img.Height;
					ret = new Bitmap(img, new Size(w, bounds.Height));
				}
			}
			else
			{
				ret = new Bitmap(img);
			}
			return ret;
		}

		/**
		 * LANGUAGES
		 */
		public static int LangNR = 8;

		public enum Lang
		{
			EN,
			FR,
			IT,
			ES,
			DT,
			LT,
			HB,
			OT
		} ;

		public static string getLanguageString(int l, bool abrev)
		{
			if (abrev)
			{
				switch (l)
				{
					case (int) Util.Lang.EN:
						return "en";
					case (int) Util.Lang.FR:
						return "fr";
					case (int) Util.Lang.IT:
						return "it";
					case (int) Util.Lang.ES:
						return "es";
					case (int) Util.Lang.DT:
						return "dt";
					case (int) Util.Lang.LT:
						return "lt";
					case (int) Util.Lang.HB:
						return "hb";
					default:
						return "ot";
				}
			}
			else
			{
				switch (l)
				{
					case (int) Util.Lang.EN:
						return "english";
					case (int) Util.Lang.FR:
						return "français";
					case (int) Util.Lang.IT:
						return "italiano";
					case (int) Util.Lang.ES:
						return "español";
					case (int) Util.Lang.DT:
						return "deutsch";
					case (int) Util.Lang.LT:
						return "lateinisch";
					case (int) Util.Lang.HB:
						return "hebräisch";
					default:
						return "unknown";
				}
			}
		}

		public static int getLanguageInt(string lang)
		{
			if (lang == "en") return (int) Util.Lang.EN;
			else if (lang == "fr") return (int) Util.Lang.FR;
			else if (lang == "it") return (int) Util.Lang.IT;
			else if (lang == "es") return (int) Util.Lang.ES;
			else if (lang == "lt") return (int) Util.Lang.LT;
			else if (lang == "hb") return (int) Util.Lang.HB;
			else return (int) Util.Lang.OT;
		}


		private static Font GetFont(string key)
		{
			string[] str = key.Split(';');
			int nr = Int32.Parse(str[1]);
			FontStyle style = FontStyle.Regular;
			if (str[2] == "b")
				style = FontStyle.Bold;
			else if (str[2] == "i")
				style = FontStyle.Italic;


			return new Font(str[0], nr, style);
		}

		private static Color GetColor(string key)
		{
			string[] nrs = key.Split(';');
			return Color.FromArgb(Int32.Parse(nrs[0]),
			                      Int32.Parse(nrs[1]),
			                      Int32.Parse(nrs[2]));
		}

		public static string hexValue(int i)
		{
			string res = Convert.ToString(i, 16);
			if (res.Length == 1) res = "0" + res;
			return res;
		}

		private static string ColorToString(Color color)
		{
			return ((int) color.R).ToString() + ";" +
				((int) color.G).ToString() + ";" +
				((int) color.B).ToString();
		}

		private static string FontToString(Font font)
		{
			string res = "";
			res += font.Name + ";" + ((int) font.Size).ToString() + ";";

			if (font.Style == FontStyle.Regular)
				res += "s";
			else if (font.Style == FontStyle.Bold)
				res += "b";
			else if (font.Style == FontStyle.Italic)
				res += "i";

			return res;
		}

		public static void updateRegSettings()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\lyra", true);
				if (Util.SHOWBUILDNEWS) key.SetValue("1", "yes");
				else key.SetValue("1", "no");
				if (Util.SHOWGER) key.SetValue("ger", "yes");
				else key.SetValue("ger", "no");
				if (Util.SHOWRIGHT) key.SetValue("right", "yes");
				else key.SetValue("right", "no");
				if (Util.NOCOMMIT) key.SetValue("ac", "no");
				else key.SetValue("ac", "yes");
				if (Util.SHOWNR) key.SetValue("shnr", "yes");
				else key.SetValue("shnr", "no");
				key.SetValue("timer", Util.TIMER.ToString());

				key.Close();

				RegistryKey fonts = Registry.CurrentUser.OpenSubKey(@"Software\lyra\fonts", true);
				fonts.SetValue("standard", Util.FontToString(Util.FONT));
				fonts.SetValue("special", Util.FontToString(Util.SPECFONT));
				fonts.SetValue("transfont", Util.FontToString(Util.TRANSFONT));
				fonts.SetValue("refcolor", Util.ColorToString(Util.REFCOLOR));
				if (Util.refmode)
					fonts.SetValue("refmode", "normal");
				else
					fonts.SetValue("refmode", "fett");

				fonts.Close();

				RegistryKey pres = Registry.CurrentUser.OpenSubKey(@"Software\lyra\presentation", true);
				pres.SetValue("unicol", Util.ColorToString(Util.UNICOLOR));
				pres.SetValue("gradcol1", Util.ColorToString(Util.GRADCOL1));
				pres.SetValue("gradcol2", Util.ColorToString(Util.GRADCOL2));
				pres.SetValue("mode", Util.PREMODE);
				pres.SetValue("picuri", Util.picturi);
				pres.SetValue("cascade", Util.CASCADEPIC ? "yes" : "no");
				pres.Close();

				RegistryKey fx = Registry.CurrentUser.OpenSubKey(@"Software\lyra\FX", true);
				for (int i = 0; i < Util.FX.Length; i++)
				{
					fx.SetValue("f" + (i + 1).ToString(), Util.FX[i]);
				}
				fx.Close();
			}
			catch (Exception e)
			{
				Util.MBoxError(e.Message, e);
			}
		}


		public static void init()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\lyra", true);
				Util.HLPURL = key.GetValue("help").ToString();
				Util.URL = key.GetValue("url").ToString();
				Util.LISTURL = key.GetValue("lists").ToString();
				Util.SCHEMA = key.GetValue("schema").ToString();
				Util.SHOWBUILDNEWS = key.GetValue("1").ToString().Equals("yes");
				Util.SHOWRIGHT = key.GetValue("right").ToString().Equals("yes");
				Util.NOCOMMIT = key.GetValue("ac").ToString().Equals("no");
				Util.SHOWGER = key.GetValue("ger").ToString().Equals("yes");
				Util.SHOWNR = key.GetValue("shnr").ToString().Equals("yes");
				Util.TIMER = Int32.Parse(key.GetValue("timer").ToString());

				key.Close();

				RegistryKey fonts = Registry.CurrentUser.OpenSubKey(@"Software\lyra\fonts", true);
				Util.FONT = Util.GetFont(fonts.GetValue("standard").ToString());
				Util.SPECFONT = Util.GetFont(fonts.GetValue("special").ToString());
				Util.TRANSFONT = Util.GetFont(fonts.GetValue("transfont").ToString());
				Util.REFCOLOR = Util.GetColor(fonts.GetValue("refcolor").ToString());
				Util.COLOR = Util.GetColor(fonts.GetValue("color").ToString());
				if (fonts.GetValue("refmode").ToString() == "normal")
					Util.refmode = true;
				else
					Util.refmode = false;

				fonts.Close();

				RegistryKey pres = Registry.CurrentUser.OpenSubKey(@"Software\lyra\presentation", true);
				Util.UNICOLOR = Util.GetColor(pres.GetValue("unicol").ToString());
				Util.GRADCOL1 = Util.GetColor(pres.GetValue("gradcol1").ToString());
				Util.GRADCOL2 = Util.GetColor(pres.GetValue("gradcol2").ToString());
				Util.PREMODE = Int32.Parse(pres.GetValue("mode").ToString());
				Util.PICTURI = pres.GetValue("picuri").ToString();
				Util.CASCADEPIC = pres.GetValue("cascade").ToString().Equals("yes");
				pres.Close();

				RegistryKey fx = Registry.CurrentUser.OpenSubKey(@"Software\lyra\FX", true);
				for (int i = 0; i < Util.FX.Length; i++)
				{
					Util.FX[i] = fx.GetValue("f" + (i + 1).ToString()).ToString();
				}
				fx.Close();

				Util.loadStats();
			}
			catch (Exception e)
			{
				Util.MBoxError(e.Message, e);
			}
		}

		// ### STATS ###
		public static int NRSONGS = 0;
		public static long TOTALLOAD = 0;
		public static int NRUSE = 1;
		public static long TOTALSEARCH = 0;
		public static int NRSEARCH = 1;
		private static long TOTALUSE = 0;
		public static string DOTNET = "v1.1.4322 SP1";

		public static long getCurrentTicks()
		{
			return DateTime.Now.Ticks;
		}

		public static void addSearchTime(long ticks)
		{
			Util.TOTALSEARCH += ticks;
			Util.NRSEARCH++;
		}

		public static void addLoadTime(long ticks)
		{
			Util.TOTALLOAD += ticks;
			Util.NRUSE++;
		}

		public static long startticks;

		public static string getUseTime()
		{
			long ms = (Util.TOTALUSE + DateTime.Now.Ticks - Util.startticks)/TimeSpan.TicksPerMillisecond;
			long s = (long) Math.Floor(ms/1000);
			ms = ms - s*1000;
			long min = (long) Math.Floor(s/60);
			s = s - 60*min;
			long h = (long) Math.Floor(min/60);
			min = min - 60*h;
			long d = (long) Math.Floor(h/24);
			h = h - 24*d;
			return Convert.ToString(d) + "d " + Convert.ToString(h) + "h " + Convert.ToString(min) + "min " + Convert.ToString(s) + "s ";
		}

		public static void storeStats()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\lyra\stats", true);
				key.SetValue("TLD", Util.TOTALLOAD);
				key.SetValue("NRUSE", Util.NRUSE);
				key.SetValue("TSRC", Util.TOTALSEARCH);
				key.SetValue("NRSRC", Util.NRSEARCH);
				Util.TOTALUSE += Util.getCurrentTicks() - Util.startticks;
				key.SetValue("TUSE", Util.TOTALUSE);
				key.Close();
			}
			catch (Exception)
			{
				Util.MBoxError("error@Util.storeStats()");
			}
		}

		private static void loadStats()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\lyra\stats", true);
				Util.TOTALLOAD = Convert.ToInt64(key.GetValue("TLD").ToString());
				Util.NRUSE = Convert.ToInt32(key.GetValue("NRUSE").ToString());
				Util.TOTALSEARCH = Convert.ToInt64(key.GetValue("TSRC").ToString());
				Util.NRSEARCH = Convert.ToInt32(key.GetValue("NRSRC").ToString());
				Util.TOTALUSE = Convert.ToInt64(key.GetValue("TUSE").ToString());
				Util.startticks = DateTime.Now.Ticks;
				key.Close();
			}
			catch (Exception)
			{
				Util.MBoxError("error@Util.loadStats()");
			}
		}


		// ### DEBUG ###
		public static void Debug(string msg)
		{
			Util.Debug(msg, null);
		}

		public static void Debug(Exception dbex)
		{
			Util.Debug("", dbex);
		}

		public static void Debug(string msg, Exception dbex)
		{
			if (GUI.DEBUG) // if -d flag set
			{
				DebugConsole.Append(msg, dbex);
			}
		}
	}
}