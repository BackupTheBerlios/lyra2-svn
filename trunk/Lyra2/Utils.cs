using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Lyra2
{
    class Utils
    {
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

    }
}
