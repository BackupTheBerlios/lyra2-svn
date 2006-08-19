using System;

namespace lyra
{
	/// <summary>
	/// Summary description for Info.
	/// </summary>
	public class Info : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label23;

		private static Info info = null;

		public static void showInfo(GUI owner)
		{
			if (Info.info == null) Info.info = new Info(owner);
			Info.info.Show();
			owner.Enabled = false;
		}

		private GUI owner;

		private Info(GUI owner)
		{
			this.owner = owner;
			InitializeComponent();
			this.label21.Text = Util.VER;
			this.label22.Text = Util.BUILD;
			this.label23.Text = GUI.DEBUG ? "ja" : "nein";
			this.label24.Text = ".NET " + Util.DOTNET;
			this.label25.Text = Util.NRSONGS.ToString();
			this.label26.Text = Util.NRUSE != 0 ? Convert.ToString(Util.TOTALLOAD/Util.NRUSE/TimeSpan.TicksPerMillisecond) + " ms" : "0 ms";
			this.label27.Text = Util.NRSEARCH != 0 ? Convert.ToString(Util.TOTALSEARCH/Util.NRSEARCH/TimeSpan.TicksPerMillisecond) + " ms" : "0 ms";
			this.label28.Text = Util.getUseTime();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			this.owner.Enabled = true;
			Info.info = null;
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Info));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(32, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "version";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 224);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "build";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(32, 256);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "debuging";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 280);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "compiled";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(32, 312);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "# Songs";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(32, 336);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 18);
			this.label6.TabIndex = 0;
			this.label6.Text = "Ø loadtime";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(32, 360);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 19);
			this.label7.TabIndex = 0;
			this.label7.Text = "Ø search";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(32, 392);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "total use";
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(32, 416);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "© 2004-2006";
			// 
			// label24
			// 
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label24.Location = new System.Drawing.Point(120, 280);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(192, 19);
			this.label24.TabIndex = 0;
			this.label24.Text = "label1";
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.Transparent;
			this.label21.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.Location = new System.Drawing.Point(120, 200);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(192, 19);
			this.label21.TabIndex = 0;
			this.label21.Text = "label1";
			// 
			// label29
			// 
			this.label29.BackColor = System.Drawing.Color.Transparent;
			this.label29.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label29.Location = new System.Drawing.Point(120, 416);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(192, 18);
			this.label29.TabIndex = 0;
			this.label29.Text = "O.Girard, A.Jost";
			// 
			// label28
			// 
			this.label28.BackColor = System.Drawing.Color.Transparent;
			this.label28.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label28.Location = new System.Drawing.Point(120, 392);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(192, 19);
			this.label28.TabIndex = 0;
			this.label28.Text = "label1";
			// 
			// label27
			// 
			this.label27.BackColor = System.Drawing.Color.Transparent;
			this.label27.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label27.Location = new System.Drawing.Point(120, 360);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(192, 19);
			this.label27.TabIndex = 0;
			this.label27.Text = "label1";
			// 
			// label26
			// 
			this.label26.BackColor = System.Drawing.Color.Transparent;
			this.label26.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label26.Location = new System.Drawing.Point(120, 336);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(192, 18);
			this.label26.TabIndex = 0;
			this.label26.Text = "label1";
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.Transparent;
			this.label22.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.Location = new System.Drawing.Point(120, 224);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(192, 18);
			this.label22.TabIndex = 0;
			this.label22.Text = "label1";
			// 
			// label25
			// 
			this.label25.BackColor = System.Drawing.Color.Transparent;
			this.label25.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label25.Location = new System.Drawing.Point(120, 312);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(192, 18);
			this.label25.TabIndex = 0;
			this.label25.Text = "label1";
			// 
			// label23
			// 
			this.label23.BackColor = System.Drawing.Color.Transparent;
			this.label23.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label23.Location = new System.Drawing.Point(120, 256);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(192, 18);
			this.label23.TabIndex = 0;
			this.label23.Text = "label1";
			// 
			// Info
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(476, 500);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label29);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label23);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Info";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Info";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion
	}
}