using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Lyra2.Properties;

namespace Lyra2
{
    class Info
    {
        // Lyra Info
        public static string GUI_TITLE = Settings.Default.SoftwareTitle;
        public static string VERSION = Settings.Default.Version;
        public static int BUILD = Settings.Default.BuildNR;
        public static DateTime RELEASE_DATE = Settings.Default.ReleaseDate;

        // Path Info
        public static string APP_PATH = Application.StartupPath + "\\";
        public static string RES_PATH = Application.StartupPath + "\\resources\\";
        public static string BOOK_PATH = Application.StartupPath + "\\books\\";
        public static string TEMP_XML = Application.StartupPath + "\\books\\temp.xml";
    }
}
