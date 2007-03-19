using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lyra2
{
    class Info
    {
        public const string GUI_TITLE = "";
        public const int VERSION = 2;
        public const int BUILD = 1;

        public static string APP_PATH = Application.StartupPath + "\\";
        public static string RES_PATH = Application.StartupPath + "\\resources\\";
        public static string BOOK_PATH = Application.StartupPath + "\\books\\";
        public static string TEMP_XML = Application.StartupPath + "\\books\\temp.xml";
    }
}
