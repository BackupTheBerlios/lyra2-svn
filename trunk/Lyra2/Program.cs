using System;
using System.IO;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace Lyra2
{
    static class Program
    {
        // logger for this class
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Log4net config
            XmlConfigurator.Configure(new FileInfo(Application.StartupPath + "\\config\\log4net.config"));

            log.Info("Start Lyra 2.0");
            SongQueryEngine.INDEX_PATH = Info.INDEX_PATH;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LyraGUI());
        }
    }
}