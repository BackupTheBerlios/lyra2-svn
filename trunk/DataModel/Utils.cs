using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace Lyra2
{
    public class Utils
    {
        // const indicating a not-existing int-value (e.g. song nr)
        public const int NA = -1;
        // Windows new line delimiter
        public const string WINNL = "\r\n";

        public static Random RAND = new Random();
        private static long idCount = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        public static bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^(([^<>()[\]\\.,;:\s@\""]+"
                + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                + @"[a-zA-Z]{2,}))$");
        }

        private static string DATEFORMATSHORT = "dd.MM.yyyy";
        private static string DATEFORMATLONG = "dd.MM.yyyy@HH:mm:ss";

        public static string FormatShortDate(DateTime date)
        {
            return date.ToString(DATEFORMATSHORT);
        }

        public static string FormatLongDate(DateTime date)
        {
            return date.ToString(DATEFORMATLONG);
        }

        public static DateTime DateFromString(string datestring)
        {
            string[] datetime = datestring.Split('@');
            int h = 0;
            int m = 0;
            int s = 0;
            int d = 0;
            int M = 0;
            int y = 0;
            string[] date = datestring.Split('.');
            if (datetime.Length == 2)
            {
                string[] time = datetime[1].Split(':');
                if (time.Length != 3)
                {
                    throw new LyraException("Wrong date format!", ErrorLevel.Debug);
                }
                h = Int32.Parse(time[0]);
                m = Int32.Parse(time[1]);
                s = Int32.Parse(time[2]);
                date = datetime[0].Split('.');
            }
            else if (datetime.Length > 2 || datetime.Length <= 0 || date.Length != 3)
            {
                throw new LyraException("Wrong date format!", ErrorLevel.Debug);
            }
            d = Int32.Parse(date[0]);
            M = Int32.Parse(date[1]);
            y = Int32.Parse(date[2]);
            DateTime parsedDate = new DateTime(y, M, d, h, m, s);
            return parsedDate;
        }
        /// <summary>
        /// Removes line breaks and tabs from string
        /// </summary>
        /// <param name="toclean">original string</param>
        /// <param name="maxlength">maximal length of clean string</param>
        /// <returns></returns>
        public static string CleanString(string toclean, int maxlength)
        {
            toclean = toclean.Replace(Utils.WINNL, "¬ ").Replace("\t", "  ");
            return (maxlength != -1 && toclean.Length > maxlength) ? toclean.Substring(0, maxlength - 3) + "..." : toclean;
        }

        /// <summary>
        /// Removes line breaks and tabs from string
        /// </summary>
        /// <param name="toclean">original string</param>
        /// <returns></returns>
        public static string CleanString(string toclean)
        {
            return Utils.CleanString(toclean, -1);
        }

        /// <summary>
        /// Format string s by adding prefix in front and suffix at the end
        /// if append is <code>true</code>, the space char is added at the end, if it's <code>false</code>, in front until
        /// s' has at least the indicated length
        /// </summary>
        /// <param name="s"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <param name="length"></param>
        /// <param name="space"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string Format(string s, string prefix, string suffix, int length, char space, bool append)
        {
            s = prefix + s + suffix;
            while (s.Length < length)
            {
                if (append) s += space;
                else s = space + s;
            }
            return s;
        }

        /// <summary>
        /// Returns <code>true</code> iff key is contained in str, <code>false</code> otherwise
        /// </summary>
        /// <param name="key"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Contains(String key, String str)
        {
            str = str.ToLower();
            key = key.ToLower();

            for (int i = 0; i < str.Length - key.Length + 1; i++)
            {
                if (str.Substring(i, key.Length).Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetID(string prefix)
        {
            return prefix + Convert.ToString(idCount++, 16).ToUpper();
        }

        public static string XMLPrettyPrint(XmlElement xmlelem)
        {
            if (xmlelem == null) return "";
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            string result = "";
            try
            {
                // write XML to memory
                xmlelem.WriteContentTo(writer);
                writer.Flush();
                ms.Flush();
                // go to start to read content
                ms.Position = 0;
                // read XML from memory
                StreamReader reader = new StreamReader(ms);
                result = reader.ReadToEnd();
            }
            catch (XmlException)
            {
            }

            ms.Close();
            writer.Close();

            return result;
        }

        public static SongLanguage LanguageFromString(string str)
        {
            switch (str)
            {
                case "ger":
                    return SongLanguage.German;
                case "eng":
                    return SongLanguage.English;
                case "fre":
                    return SongLanguage.French;
                case "ita":
                    return SongLanguage.Italian;
                case "lat":
                    return SongLanguage.Latin;
                case "spa":
                    return SongLanguage.Spanish;
                case "heb":
                    return SongLanguage.Hebrew;
                default:
                    return SongLanguage.Other;
            }
        }

        public static string StringFromLanguage(SongLanguage lang)
        {
            switch (lang)
            {
                case SongLanguage.English:
                    return "eng";
                case SongLanguage.French:
                    return "fre";
                case SongLanguage.German:
                    return "ger";
                case SongLanguage.Hebrew:
                    return "heb";
                case SongLanguage.Italian:
                    return "ita";
                case SongLanguage.Latin:
                    return "lat";
                case SongLanguage.Spanish:
                    return "spa";
                default:
                    return "";
            }
        }
    }
}
