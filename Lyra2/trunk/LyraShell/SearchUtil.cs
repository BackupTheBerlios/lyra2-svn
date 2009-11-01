using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Search Utils
    /// </summary>
    public static class SearchUtil
    {
        private static Hashtable stopWords = InitStopWords();
        private static Hashtable InitStopWords()
        {
            // initialize hashmap
            stopWords = new Hashtable(1024);
            using (StreamReader sr = new StreamReader(Application.StartupPath + "\\data\\stopwords.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim().ToLower();
                    if (!stopWords.ContainsKey(line))
                    {
                        stopWords.Add(line, line);
                    }
                }
            }
            return stopWords;
        }

        /// <summary>
        /// Checks if word to be looked up is a stop word (english/german/french/italian)
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool IsStopWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return true;
            }
            return stopWords.ContainsKey(word.Trim().ToLower());
        }

        /// <summary>
        /// Checks if the string word is a number
        /// </summary>
        /// <param name="word">query word</param>
        /// <returns>number (int) if it's a number, -1 otherwise</returns>
        private static int IsNumber(string word)
        {
            int nr;
            if (Int32.TryParse(word, out nr))
            {
                return nr;
            }
            return -1;
        }

        public static LyraQuery CreateLyraQuery(string lyraQuery, bool exact)
        {
            ArrayList words = new ArrayList();
            IList<int> numbers = new List<int>();
            string[] wordParts = lyraQuery.Split(' ');

            for (int i = 0; i < wordParts.Length; i++)
            {
                if (wordParts[i] != "")
                {
                    string word = wordParts[i];
                    if (word.StartsWith("\""))
                    {
                        string nextWord = word;
                        while (!wordParts[i].EndsWith("\"") && i < wordParts.Length - 1)
                        {
                            nextWord += " " + wordParts[++i];
                        }
                        word = "\"" + nextWord.Trim('\"') + "\"";
                    }
                    while (word.StartsWith("*") || word.StartsWith("?"))
                    {
                        word = word.Length > 1 ? word.Substring(1) : "";
                    }
                    int nr = SearchUtil.IsNumber(word);
                    if (nr != -1)
                    {
                        numbers.Add(nr);
                    }
                    else if (!SearchUtil.IsStopWord(word))
                    {
                        words.Add(word);
                    }
                }
            }
            string query = "";
            foreach (string word in words)
            {
                if (exact || word.EndsWith("\"") || word.IndexOfAny(new[] { '*', '?' }) > 0)
                {
                    query += "+" + word + " ";
                }
                else
                {
                    query += "+" + word + "* ";
                }
            }
            if (lyraQuery.IndexOf('\"') < 0)
            {
                query += "\"" + lyraQuery + "\" ";
            }
            
            Console.Out.WriteLine(lyraQuery + " --> " + query);

            LyraQuery resultQuery = new LyraQuery(lyraQuery, query, numbers, exact);
            return resultQuery;
        }
    }
}