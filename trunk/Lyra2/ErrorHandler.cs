using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lyra2
{
    class ErrorHandler
    {
        private static ErrorLevel logLevel = ErrorLevel.Info;
        private static bool verbose = false;
        public static void HandleError(string msg, Exception ex, ErrorLevel level)
        {
            if (level >= logLevel)
            {
                MessageBoxIcon icon = level >= ErrorLevel.Error ? MessageBoxIcon.Error : MessageBoxIcon.Information;
                if (msg == null) msg = "Lyra 2.0 System-Meldung";
                msg += Utils.WINNL;
                if (ex != null)
                {
                    msg += ex.GetType().Name + ":" + Utils.WINNL + ex.Message + Utils.WINNL + (verbose ? ex.StackTrace : "");
                }
                MessageBox.Show(msg, "Lyra 2.0 :: Fehler", MessageBoxButtons.OK, icon);
            }
        }

        public enum ErrorLevel
        {
            Debug, Warning, Info, Error, Fatal, Always
        }
    }
}
