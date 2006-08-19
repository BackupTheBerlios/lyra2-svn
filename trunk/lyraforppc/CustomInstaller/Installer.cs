using System.ComponentModel;

using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace CustomInstaller
{
	/// <summary>
	/// Summary description for Installer.
	/// </summary>
	[RunInstaller(true)]
	public class Installer : System.Configuration.Install.Installer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Installer()
		{
			// This call is required by the Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Installer
			// 
			this.AfterUninstall += new System.Configuration.Install.InstallEventHandler(this.Installer_AfterUninstall);
			this.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.Installer_AfterInstall);

		}
		#endregion

		private void Installer_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
		{
			// get fullpath to .ini file
			string arg = Path.Combine(
				Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
				"Setup.ini");
			
			// run WinCE App Manager to install .cab file on device
			RunAppManager(arg);
		}

		private void Installer_AfterUninstall(object sender, System.Configuration.Install.InstallEventArgs e)
		{
			// run app manager in uninstall mode (without any arguments)
			RunAppManager(null);
		}

		private void RunAppManager(string arg)
		{
			// get path to the app manager
			const string RegPath = @"Software\Microsoft\Windows\" + 
				@"CurrentVersion\App Paths\CEAppMgr.exe";
			RegistryKey key = Registry.LocalMachine.OpenSubKey(RegPath);					
			string appManager = key.GetValue("") as string;
			
			if (appManager != null)
			{
				// launch the app
				Process.Start(
					string.Format("\"{0}\"", appManager), 
					(arg == null) ? "" : string.Format("\"{0}\"", arg));
			}
			else
			{
				// could not locate app manager
				MessageBox.Show("WinCE Application Manager konnte nicht gestartet werden.");
			}
		}
	}
}
