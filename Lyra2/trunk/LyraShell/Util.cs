using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Lyra2.UtilShared;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// static help methods, vars and constants.
    /// </summary>
    public class Util
    {
        public static string CONFIGPATH = Application.StartupPath + "\\lyra.config";
        // info & build 
        public const string NAME = "Lyra";
        public const string BUILDNR = "41";
        public const string VER = "2.1.0"; // with PocketPC
        public static string BUILD = "{build 20090830." + Util.BUILDNR + "}";
        public static string GUINAME = Util.NAME; // + " v" + Util.VER + "   " + Util.BUILD;

        // lyra update
        public const string UPDATESERVER = "http://cgi.ethz.ch/~ogirard/lyraupdate";
        // status / paths
        public const int MAXOPEN = 5;
        public const int WAIT = 1000; //ms
        public static bool DELALL;
        public static string URL = "data\\curtext.xml";
        public static string SCHEMA = "data\\curtext.xsd";
        public static string HLPURL = "doc\\lyrahelp.chm";
        public static string NEWSURL = "doc\\buildnews.txt";
        public static string INFORTF = "doc\\info.rtf";
        public static string LISTURL = "data\\lists.xml";
        public static string BASEURL = Application.StartupPath;
        public static bool PREVIEW_BOTTOM_MODE = true;

        // format
        public const string REF = "refrain";
        public const string SPEC = "special";
        public const string BOLD = "b";
        public const string ITALIC = "i";
        public const string BLOCK = "p";
        public const string PGBR = "pagebreak";
        public static Color REFCOLOR;
        public static Color COLOR;
        public static Font SPECFONT;
        public static Font TRANSFONT;
        public static Font FONT;
        public static bool refmode = true;

        // pictures
        public static string PICTDIR = Application.StartupPath + "\\data\\pictures\\";
        public static bool COPYPICS = true;
        public const string PICTSSYM = "{pics}\\";
        public static bool KEEPRATIO;

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
        public static bool NOCOMMIT;
        public static bool SHOWBUILDNEWS;
        public static bool SHOWNR = true;
        public static bool CTRLSHOWNR;
        public static int TIMER = 3000;
        public static int SCREEN_ID;
        public static bool SHOW_PREVIEW;

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
            string msg = "Es ist ein Fehler aufgetreten!" + Util.NL + umsg + Util.NL;
            Util.Debug(umsg, ex);
            MessageBox.Show(msg, "lyra error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string MD5FileHash(FileInfo file)
        {
            if (!file.Exists) return "";
            FileStream stream = null;
            try
            {
                stream = new FileStream(file.FullName, FileMode.Open);
                MD5 md5 = MD5.Create();

                byte[] hash = md5.ComputeHash(stream);
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < hash.Length; i++)
                {
                    sBuilder.Append(hash[i].ToString("x2"));
                }
                stream.Close();
                return sBuilder.ToString().ToUpper();
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                if (stream != null) { stream.Close(); }
            }
        }

        public static string GetDate()
        {
            string date = "";
            date += DateTime.Now.Year + "/";
            string month = (DateTime.Now.Month < 10) ? ("0" + DateTime.Now.Month) : DateTime.Now.Month.ToString();
            string day = (DateTime.Now.Day < 10) ? ("0" + DateTime.Now.Day) : DateTime.Now.Day.ToString();
            date += month + "/" + day;
            return date;
        }

        public static string toFour(int nr)
        {
            if (nr == 0) return "0000";

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

        public static string handlePicture(string fn)
        {
            fn = fn.ToLower();
            if (Util.COPYPICS && !fn.StartsWith(Util.PICTSSYM) && Util.isPict(fn))
            {
                string converted = fn.Replace('\\', '_').Replace(":", "");
                if (!File.Exists(Util.PICTDIR + converted))
                {
                    File.Copy(fn, Util.PICTDIR + converted);
                }
                return Util.PICTSSYM + converted;
            }
            if (Util.isPict(fn))
            {
                return fn;
            }
            // auto correct invalid file names
            return "";
        }

        public static string CleanText(string text)
        {
            string cleanedString = "";
            text = text.Replace("\r", "");
            bool skip = false;
            foreach (char c in text)
            {
                if (c == '<')
                {
                    skip = true;
                }
                else if (c == '>')
                {
                    skip = false;
                }
                else
                {
                    if (!skip)
                    {
                        cleanedString += c;
                        // if (lines >= 10)
                        // {
                        //     cleanedString += Util.NL + "[...]";
                        //     cleanedString = cleanedString.Replace("&lt;", "<").Replace("&gt;", ">");
                        //     return cleanedString;
                        // }
                    }
                }
            }
            cleanedString = cleanedString.Replace("&lt;", "<").Replace("&gt;", ">");
            return cleanedString;
        }

        private static bool isPict(string pictPath)
        {
            return (pictPath.EndsWith(".gif") || pictPath.EndsWith(".jpg") || pictPath.EndsWith(".bmp") || pictPath.EndsWith(".bmp")) &&
                   (File.Exists(pictPath) || pictPath.StartsWith(Util.PICTSSYM));
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
                if (img.Width / bounds.Width > img.Height / bounds.Height)
                {
                    int h = img.Height * bounds.Width / img.Width;
                    ret = new Bitmap(img, new Size(bounds.Width, h));
                }
                else
                {
                    int w = img.Width * bounds.Height / img.Height;
                    ret = new Bitmap(img, new Size(w, bounds.Height));
                }
            }
            else
            {
                ret = new Bitmap(img);
            }
            return ret;
        }

        // stretch an image
        public static Bitmap handlePic(bool scale, Image img, Size bounds, bool keepRatio, int transparency)
        {
            Bitmap ret;
            if (scale)
            {
                if (!keepRatio)
                {
                    ret = new Bitmap(img, bounds);
                }
                else
                {
                    if (img.Width / bounds.Width > img.Height / bounds.Height)
                    {
                        int h = img.Height * bounds.Width / img.Width;
                        ret = new Bitmap(img, new Size(bounds.Width, h));
                    }
                    else
                    {
                        int w = img.Width * bounds.Height / img.Height;
                        ret = new Bitmap(img, new Size(w, bounds.Height));
                    }
                }
            }
            else
            {

                Bitmap centered = new Bitmap(bounds.Width, bounds.Height);
                Graphics g = Graphics.FromImage(centered);
                g.FillRectangle(Brushes.White, 0, 0, bounds.Width, bounds.Height);
                g.DrawImage(img, (bounds.Width - img.Width) / 2, (bounds.Height - img.Height) / 2, img.Width, img.Height);
                ret = centered;
            }

            if (transparency > 0)
            {
                ret = Util.GenerateMagicImage(ret, transparency);
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
        }

        public static Bitmap GenerateMagicImage(Bitmap bFront, int transparency)
        {
            float opacity = (100 - transparency) / 100f;
            Bitmap bHidden = new Bitmap(bFront.Width, bFront.Height);
            // the following code draws the front image over the hidden image using the alpha blending effect
            Graphics g = Graphics.FromImage(bHidden);
            g.FillRectangle(Brushes.White, 0, 0, bFront.Width, bFront.Height);
            float[][] ptsArray ={ new float[] {1, 0, 0, 0, 0},
									new float[] {0, 1, 0, 0, 0},
									new float[] {0, 0, 1, 0, 0},
									new[] {0, 0, 0, opacity, 0}, 
									new float[] {0, 0, 0, 0, 1}};
            ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
            ImageAttributes imgAttributes = new ImageAttributes();
            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(bFront, new Rectangle(0, 0, bFront.Width, bFront.Height), 0, 0, bFront.Width, bFront.Height, GraphicsUnit.Pixel, imgAttributes);

            // return the result image
            // Bitmap bResult = new Bitmap( bHidden.Width, bHidden.Height );
            // bResult = (Bitmap)bHidden.Clone();
            return bHidden;
        }

        public static string getLanguageString(int l, bool abrev)
        {
            if (abrev)
            {
                switch (l)
                {
                    case (int)Util.Lang.EN:
                        return "en";
                    case (int)Util.Lang.FR:
                        return "fr";
                    case (int)Util.Lang.IT:
                        return "it";
                    case (int)Util.Lang.ES:
                        return "es";
                    case (int)Util.Lang.DT:
                        return "dt";
                    case (int)Util.Lang.LT:
                        return "lt";
                    case (int)Util.Lang.HB:
                        return "hb";
                    default:
                        return "ot";
                }
            }
            switch (l)
            {
                case (int)Util.Lang.EN:
                    return "english";
                case (int)Util.Lang.FR:
                    return "français";
                case (int)Util.Lang.IT:
                    return "italiano";
                case (int)Util.Lang.ES:
                    return "español";
                case (int)Util.Lang.DT:
                    return "deutsch";
                case (int)Util.Lang.LT:
                    return "lateinisch";
                case (int)Util.Lang.HB:
                    return "hebräisch";
                default:
                    return "unknown";
            }
        }

        public static int getLanguageInt(string lang)
        {
            if (lang == "en") return (int)Util.Lang.EN;
            if (lang == "fr") return (int)Util.Lang.FR;
            if (lang == "it") return (int)Util.Lang.IT;
            if (lang == "es") return (int)Util.Lang.ES;
            if (lang == "lt") return (int)Util.Lang.LT;
            if (lang == "hb") return (int)Util.Lang.HB;
            return (int)Util.Lang.OT;
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
            return ((int)color.R) + ";" +
                ((int)color.G) + ";" +
                ((int)color.B);
        }

        private static string FontToString(Font font)
        {
            string res = "";
            res += font.Name + ";" + ((int)font.Size) + ";";

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
                ConfigFile configFile = new ConfigFile(Util.CONFIGPATH);

                configFile["1"] = Util.SHOWBUILDNEWS ? "yes" : "no";
                configFile["ger"] = Util.SHOWGER ? "yes" : "no";
                configFile["right"] = Util.SHOWGER ? "yes" : "no";
                configFile["ger"] = Util.SHOWRIGHT ? "yes" : "no";
                configFile["ac"] = Util.NOCOMMIT ? "yes" : "no";
                configFile["shnr"] = Util.SHOWNR ? "yes" : "no";
                configFile["timer"] = Util.TIMER.ToString();
                configFile["screen_id"] = Util.SCREEN_ID.ToString();
                configFile["show_preview"] = Util.SHOW_PREVIEW ? "yes" : "no";

                configFile["fonts.standard"] = Util.FontToString(Util.FONT);
                configFile["fonts.special"] = Util.FontToString(Util.SPECFONT);
                configFile["fonts.transfont"] = Util.FontToString(Util.TRANSFONT);
                configFile["fonts.color"] = Util.ColorToString(Util.COLOR);
                configFile["fonts.refcolor"] = Util.ColorToString(Util.REFCOLOR);
                configFile["fonts.refmode"] = Util.refmode ? "normal" : "fett";

                configFile["presentation.unicol"] = Util.ColorToString(Util.UNICOLOR);
                configFile["presentation.gradcol1"] = Util.ColorToString(Util.GRADCOL1);
                configFile["presentation.gradcol2"] = Util.ColorToString(Util.GRADCOL2);
                configFile["presentation.mode"] = Util.PREMODE.ToString();
                configFile["presentation.picuri"] = Util.picturi;
                configFile["presentation.cascade"] = Util.CASCADEPIC ? "yes" : "no";

                for (int i = 0; i < Util.FX.Length; i++)
                {
                    configFile["FX.f" + (i + 1)] = Util.FX[i];
                }

                configFile.Save(Util.CONFIGPATH);
            }
            catch (Exception e)
            {
                Util.MBoxError(e.Message, e);
            }
        }

        static Util()
        {
            try
            {
                ConfigFile configFile = new ConfigFile(Util.CONFIGPATH);

                Util.HLPURL = configFile["help"];
                Util.URL = configFile["url"];
                Util.LISTURL = configFile["lists"];
                Util.SCHEMA = configFile["schema"];
                Util.SHOWBUILDNEWS = configFile["1"].Equals("yes");
                Util.SHOWRIGHT = configFile["right"].Equals("yes");
                Util.NOCOMMIT = configFile["ac"].Equals("yes");
                Util.SHOWGER = configFile["ger"].Equals("yes");
                Util.SHOWNR = configFile["shnr"].Equals("yes");
                Util.TIMER = Int32.Parse(configFile["timer"]);

                try
                {
                    Util.SCREEN_ID = Int32.Parse(configFile["screen_id"]);
                    View.display = Util.GetScreen(Util.SCREEN_ID);
                }
                catch (Exception)
                {
                    Util.SCREEN_ID = 0;
                    View.display = Screen.PrimaryScreen;
                    configFile.addProperty("screen_id", "0");
                    configFile.Save(Util.CONFIGPATH);
                }


                if (configFile["show_preview"] == "n/a")
                {
                    Util.SHOW_PREVIEW = false;
                    configFile.addProperty("show_preview", "no");
                    configFile.Save(Util.CONFIGPATH);
                }
                else
                {
                    Util.SHOW_PREVIEW = configFile["show_preview"] == "yes";
                }


                Util.FONT = Util.GetFont(configFile["fonts.standard"]);
                Util.SPECFONT = Util.GetFont(configFile["fonts.special"]);
                Util.TRANSFONT = Util.GetFont(configFile["fonts.transfont"]);
                Util.REFCOLOR = Util.GetColor(configFile["fonts.refcolor"]);
                Util.COLOR = Util.GetColor(configFile["fonts.color"]);
                Util.refmode = configFile["fonts.refmode"] == "normal";
                Util.UNICOLOR = Util.GetColor(configFile["presentation.unicol"]);
                Util.GRADCOL1 = Util.GetColor(configFile["presentation.gradcol1"]);
                Util.GRADCOL2 = Util.GetColor(configFile["presentation.gradcol2"]);
                Util.PREMODE = Int32.Parse(configFile["presentation.mode"]);
                Util.PICTURI = configFile["presentation.picuri"];
                Util.CASCADEPIC = configFile["presentation.cascade"].Equals("yes");

                for (int i = 0; i < Util.FX.Length; i++)
                {
                    Util.FX[i] = configFile["FX.f" + (i + 1)];
                }

                Util.loadStats();

            }
            catch (Exception e)
            {
                Util.MBoxError(e.Message, e);
            }
        }

        // ### STATS ###
        public static int NRSONGS;
        public static long TOTALLOAD;
        public static int NRUSE = 1;
        public static long TOTALSEARCH;
        public static int NRSEARCH = 1;
        private static long TOTALUSE;
        public static string DOTNET = "v3.5 SP1";

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
        public static string PREVIEW_SONG_ID = "sPreview";

        public static string getUseTime()
        {
            long ms = (Util.TOTALUSE + DateTime.Now.Ticks - Util.startticks) / TimeSpan.TicksPerMillisecond;
            long s = (long)Math.Floor((double)ms / 1000);
            // ms = ms - s * 1000;
            long min = (long)Math.Floor((double)s / 60);
            s = s - 60 * min;
            long h = (long)Math.Floor((double)min / 60);
            min = min - 60 * h;
            long d = (long)Math.Floor((double)h / 24);
            h = h - 24 * d;
            return Convert.ToString(d) + "d " + Convert.ToString(h) + "h " + Convert.ToString(min) + "min " + Convert.ToString(s) + "s ";
        }

        public static void storeStats()
        {
            try
            {
                ConfigFile configFile = new ConfigFile(Util.CONFIGPATH);
                configFile["stats.TLD"] = Util.TOTALLOAD.ToString();
                configFile["stats.NRUSE"] = Util.NRUSE.ToString();
                configFile["stats.TSRC"] = Util.TOTALSEARCH.ToString();
                configFile["stats.NRSRC"] = Util.NRSEARCH.ToString();
                Util.TOTALUSE += Util.getCurrentTicks() - Util.startticks;
                configFile["stats.TUSE"] = Util.TOTALUSE.ToString();
                configFile.Save(Util.CONFIGPATH);
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
                ConfigFile configFile = new ConfigFile(Util.CONFIGPATH);
                Util.TOTALLOAD = Convert.ToInt64(configFile["stats.TLD"]);
                Util.NRUSE = Convert.ToInt32(configFile["stats.NRUSE"]);
                Util.TOTALSEARCH = Convert.ToInt64(configFile["stats.TSRC"]);
                Util.NRSEARCH = Convert.ToInt32(configFile["stats.NRSRC"]);
                Util.TOTALUSE = Convert.ToInt64(configFile["stats.TUSE"]);
                Util.startticks = DateTime.Now.Ticks;
            }
            catch (Exception)
            {
                Util.MBoxError("error@Util.loadStats()");
            }
        }

        public static Screen GetScreen(int id)
        {
            if (id == 0)
            {
                return Screen.PrimaryScreen;
            }
            if (id == 1)
            {
                Screen secScr = Screen.AllScreens[0];
                if (secScr == Screen.PrimaryScreen && Screen.AllScreens.Length == 2)
                {
                    secScr = Screen.AllScreens[1];
                }
                return secScr;
            }
            return null;
        }

        private readonly static KeysConverter keysConverter = new KeysConverter();
        public static bool KeyMatches(Keys key, params Keys[] matches)
        {
            #region    Precondition

            if (matches.Length == 0) return false;

            #endregion Precondition

            Keys allmatches = matches[0];
            for (int i = 1; i < matches.Length; i++)
            {
                allmatches |= matches[i];
            }
            return keysConverter.Compare(key, allmatches) == 0;
            
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