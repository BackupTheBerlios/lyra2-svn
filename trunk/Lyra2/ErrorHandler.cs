using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace Lyra2
{
    class ErrorHandler
    {
        // logger for this class
        private static readonly ILog log = LogManager.GetLogger(typeof(ErrorHandler));

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
                if (level >= ErrorLevel.Error)
                {
                    log.Error(msg, ex);
                }
                else
                {
                    log.Info(msg);
                }
            }
        }

        public static void HandleError(string msg, ErrorLevel level)
        {
            ErrorHandler.HandleError(msg, null, level);
        }

        public static void HandleError(string msg, Exception ex)
        {
            ErrorHandler.HandleError(msg, ex, ErrorLevel.Info);
        }

        public static void HandleError(LyraException ex)
        {
            // TODO (other handling??)
        }

        public static void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "Lyra 2.0 Info");
        }

        public enum ErrorLevel
        {
            Debug, Warning, Info, Error, Fatal, Always
        }
    }
}
