using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace lyra2
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUI.DEBUG = (args.Length == 1 && args[0].Equals("-d"));
            
            Application.Run(new GUI());
        }
    }
}
