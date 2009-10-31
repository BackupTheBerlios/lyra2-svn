using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Zusammendfassende Beschreibung f�r Editor.
    /// </summary>
    public class Editor : Form
    {
        private LyraButtonControl button1;
        private LyraButtonControl button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private Container components = null;

        private ISong song = null;
        private RichTextBox richTextBox1;
        private Panel panel1;
        private LyraButtonControl button3;
        private Label label5;
        private LyraButtonControl button4;
        private LyraButtonControl button5;
        private LyraButtonControl button6;
        private LyraButtonControl button7;
        private LyraButtonControl button8;
        private ComboBox comboBox1;
        private Label label6;
        private GUI owner;
        private string undo = "";
        private Bitmap transImage = null;

        public static bool open = false;
        private LyraButtonControl button9;
        private LyraButtonControl button10;
        private LyraButtonControl button11;
        private ListBox listBox1;
        private Label label7;
        private LyraButtonControl button14;
        private LyraButtonControl button16;
        private LyraButtonControl button17;
        private LyraButtonControl button12;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private TextBox textBox4;
        private Label label8;
        private LyraButtonControl button13;
        private TrackBar trackBar1;
        private CheckBox checkBox2;
        private Label label9;
        private Label label10;
        private PictureBox pictureBox1;
        private PictureBox previewBtn;
        private Label label11;
        public static Editor editor = null;


        public Editor(ISong song, GUI owner)
        {
            open = true;
            editor = this;
            this.AcceptButton = this.button1;
            InitializeComponent();
            this.Height = 460;
            if (song != null)
            {
                this.song = song;
                this.textBox1.Text = song.Title;
                this.textBox2.Text = song.Number.ToString();
                this.richTextBox1.Text = song.Text;
                this.button12.Enabled = true;
                if (song.Desc == "")
                {
                    this.checkBox1.Checked = false;
                    this.textBox3.Text = "---";
                    this.textBox3.Enabled = false;
                }
                else
                {
                    this.checkBox1.Checked = true;
                    this.textBox3.Text = song.Desc;
                    this.textBox3.Enabled = true;
                }
                if (song.BackgroundPicture != "")
                {
                    this.textBox4.Text = song.BackgroundPicture;
                    this.trackBar1.Value = song.Transparency;
                    this.checkBox2.Checked = song.Scale;
                }
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.richTextBox1.Text = "";
                this.textBox2.Enabled = true;
                this.textBox3.Text = "---";
                this.checkBox1.Checked = false;
                this.textBox3.Enabled = false;
            }
            this.owner = owner;
        }


        /// <summary>
        /// Die verwendeten Ressourcen bereinigen.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            open = false;
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
        /// Erforderliche Methode f�r die Designerunterst�tzung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.previewBtn = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button12 = new Lyra2.LyraShell.LyraButtonControl();
            this.button10 = new Lyra2.LyraShell.LyraButtonControl();
            this.button11 = new Lyra2.LyraShell.LyraButtonControl();
            this.button9 = new Lyra2.LyraShell.LyraButtonControl();
            this.button8 = new Lyra2.LyraShell.LyraButtonControl();
            this.button7 = new Lyra2.LyraShell.LyraButtonControl();
            this.button6 = new Lyra2.LyraShell.LyraButtonControl();
            this.button5 = new Lyra2.LyraShell.LyraButtonControl();
            this.button4 = new Lyra2.LyraShell.LyraButtonControl();
            this.button3 = new Lyra2.LyraShell.LyraButtonControl();
            this.button2 = new Lyra2.LyraShell.LyraButtonControl();
            this.button1 = new Lyra2.LyraShell.LyraButtonControl();
            this.button14 = new Lyra2.LyraShell.LyraButtonControl();
            this.button16 = new Lyra2.LyraShell.LyraButtonControl();
            this.button17 = new Lyra2.LyraShell.LyraButtonControl();
            this.button13 = new Lyra2.LyraShell.LyraButtonControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(240, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "textBox1";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(102, 38);
            this.textBox2.MaxLength = 4;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "textBox2";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lyra Songtext Editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Liednummer:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Titel:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Text:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(600, 232);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "richTextBox1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(640, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 232);
            this.panel1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "um";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightGray;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.Items.AddRange(new object[] {
            "8",
            "16",
            "24",
            "32",
            "40"});
            this.comboBox1.Location = new System.Drawing.Point(32, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(40, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SlateGray;
            this.label5.Location = new System.Drawing.Point(2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Format";
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(24, 465);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(600, 69);
            this.listBox1.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 441);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "�bersetzungen";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(200, 64);
            this.textBox3.MaxLength = 3;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 28;
            this.textBox3.Text = "---";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(104, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 16);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Bemerkungen:";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(117, 341);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(384, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Hintergrundbild:";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(304, 368);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 16);
            this.trackBar1.TabIndex = 30;
            this.trackBar1.TickFrequency = 25;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(116, 368);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 16);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Text = "Bild strecken";
            // 
            // label9
            // 
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(232, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Transparenz:";
            // 
            // label10
            // 
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(305, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "0%         50%       100%";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(440, 368);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // previewBtn
            // 
            this.previewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previewBtn.Image = ((System.Drawing.Image)(resources.GetObject("previewBtn.Image")));
            this.previewBtn.Location = new System.Drawing.Point(648, 5);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(64, 64);
            this.previewBtn.TabIndex = 33;
            this.previewBtn.TabStop = false;
            this.previewBtn.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(653, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Vorschau";
            // 
            // button12
            // 
            this.button12.Enabled = false;
            this.button12.Location = new System.Drawing.Point(149, 38);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(48, 20);
            this.button12.TabIndex = 27;
            this.button12.Text = "�ndern";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.Control;
            this.button10.Location = new System.Drawing.Point(24, 401);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(160, 24);
            this.button10.TabIndex = 21;
            this.button10.Text = "�bersetzungen >>";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(7, 203);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 24);
            this.button11.TabIndex = 17;
            this.button11.Text = "Break";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button9.Location = new System.Drawing.Point(7, 141);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 24);
            this.button9.TabIndex = 14;
            this.button9.Text = "Tab";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button8.Location = new System.Drawing.Point(7, 86);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 24);
            this.button8.TabIndex = 12;
            this.button8.Text = "Einr�cken";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button7.Location = new System.Drawing.Point(7, 54);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(64, 24);
            this.button7.TabIndex = 11;
            this.button7.Text = "Spezial";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(47, 173);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 24);
            this.button6.TabIndex = 16;
            this.button6.Text = "K";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(7, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 24);
            this.button5.TabIndex = 15;
            this.button5.Text = "F";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(56, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 22);
            this.button4.TabIndex = 18;
            this.button4.Text = "�";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.Location = new System.Drawing.Point(7, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "Refrain";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(608, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 20;
            this.button2.Text = "Abbrechen";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(688, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 24);
            this.button1.TabIndex = 19;
            this.button1.Text = "Ok";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(688, 505);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(40, 24);
            this.button14.TabIndex = 24;
            this.button14.Text = "Del";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(632, 473);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(96, 24);
            this.button16.TabIndex = 22;
            this.button16.Text = "Neu�";
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(632, 505);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(40, 24);
            this.button17.TabIndex = 23;
            this.button17.Text = "Edit";
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(512, 342);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(88, 20);
            this.button13.TabIndex = 27;
            this.button13.Text = "durchsuchen�";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Editor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 544);
            this.ControlBox = false;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Editor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.Activated += new System.EventHandler(this.MeGotFocus);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // abbrechen
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ok
        private void button1_Click(object sender, EventArgs e)
        {
            int nr;
            try
            {
                nr = Int32.Parse(this.textBox2.Text);
            }
            catch (Exception ex)
            {
                Util.MBoxError("�berpr�fen Sie die Liednummer!", ex);
                this.textBox2.Focus();
                this.textBox2.SelectAll();
                return;
            }
            string title = this.textBox1.Text;
            string text = this.richTextBox1.Text;
            string desc = this.textBox3.Text == "---" ? "" : this.textBox3.Text;
            if (this.toDel != null && nr == this.toDel.Number) // number hasn't changed!
            {
                this.song = this.toDel;
            }
            if (this.song != null)
            {
                this.song.Title = title;
                this.song.Text = text;
                this.song.Desc = desc;
                this.song.BackgroundPicture = this.textBox4.Text;
                this.song.Transparency = this.trackBar1.Value;
                this.song.Scale = this.checkBox2.Checked;
                this.owner.Status = "Liedtext editiert...";
            }
            else
            {
                string id = "s" + Util.toFour(nr);
                ISong newSong = new Song(nr, title, text, id, desc, true);
                newSong.BackgroundPicture = this.textBox4.Text;
                newSong.Transparency = this.trackBar1.Value;
                newSong.Scale = this.checkBox2.Checked;
                if (this.toDel != null)
                {
                    CopyTrans(this.toDel, newSong);
                    this.toDel.Delete();
                }
                try
                {
                    this.owner.AddSong(newSong);
                }
                catch
                {
                    string msg = "Diese Liednummer wurde bereits einmal verwendet!\n";
                    msg += "Soll das Lied trotzdem hinzugef�gt werden?\n";
                    msg += "(evtl. haben Sie das Lied bereits einer anderen Nummer zugewiesen,\n";
                    msg += "in diesem Fall einfach \"Ja\" klicken!)";

                    DialogResult dr = MessageBox.Show(this, msg, "lyra - neues Lied hinzuf�gen",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        newSong.nextID();
                        this.owner.AddSong(newSong);
                    }
                    else
                    {
                        return;
                    }
                }
                this.owner.Status = "Neues Lied erfolgreich hinzugef�gt...";
            }
            this.owner.UpdateListBox();
            this.owner.ToUpdate(true);
            this.Close();
        }


        // Refrain
        private void button3_Click(object sender, EventArgs e)
        {
            this.format(Util.REF, true);
        }

        // bold
        private void button5_Click(object sender, EventArgs e)
        {
            this.format(Util.BOLD, false);
        }

        // italic
        private void button6_Click(object sender, EventArgs e)
        {
            this.format(Util.ITALIC, false);
        }

        // special
        private void button7_Click(object sender, EventArgs e)
        {
            this.format(Util.SPEC, false);
        }

        // einr�cken
        private void button8_Click(object sender, EventArgs e)
        {
            this.format(Util.BLOCK + this.comboBox1.SelectedItem, true);
        }

        // tab
        private void button9_Click(object sender, EventArgs e)
        {
            int pos = this.richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(pos, '\t'.ToString());
            this.richTextBox1.Focus();
            this.richTextBox1.Select(pos + 1, 0);
        }

        // page break
        private void button11_Click(object sender, EventArgs e)
        {
            int findpos;
            if ((findpos = this.richTextBox1.Find("<" + Util.PGBR + " />", 0, RichTextBoxFinds.MatchCase)) == -1)
            {
                this.button4.Enabled = true;
                this.button4.BackColor = Color.LightSteelBlue;
                this.undo = this.richTextBox1.Rtf;
                int pos = this.richTextBox1.SelectionStart;
                if ((pos > 0) && (this.richTextBox1.Text[pos - 1] != '\n'))
                {
                    this.richTextBox1.Text = this.richTextBox1.Text.Insert(pos, "\n");
                    pos++;
                }
                this.richTextBox1.Text = this.richTextBox1.Text.Insert(pos, "\n<" + Util.PGBR + " />\n");
                pos += Util.PGBR.Length + 6;
                if ((pos < this.richTextBox1.Text.Length) && (this.richTextBox1.Text[pos] != '\n'))
                {
                    this.richTextBox1.Text = this.richTextBox1.Text.Insert(pos, "\n");
                }
                this.richTextBox1.Focus();
                this.richTextBox1.Select(pos + 1, 0);
            }
            else
            {
                Util.MBoxError("Nur ein Seitenumbruch m�glich!");
                this.richTextBox1.Focus();
                this.richTextBox1.Select(findpos, 4 + Util.PGBR.Length);
            }
        }

        // undo
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.undo != "")
            {
                this.richTextBox1.Rtf = this.undo;
                this.undo = "";
            }
            else if (this.richTextBox1.CanUndo)
            {
                this.richTextBox1.Undo();
            }
        }

        private void format(string tag, bool nl)
        {
            this.button4.Enabled = true;
            this.button4.BackColor = Color.LightSteelBlue;
            this.undo = this.richTextBox1.Rtf;
            int left = this.richTextBox1.SelectionStart;
            int right = this.richTextBox1.SelectionLength + left + tag.Length + 2;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(left, "<" + tag + ">");
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(right, "</" + tag + ">");
            if (nl)
            {
                if (((right + tag.Length + 3) < this.richTextBox1.Text.Length) &&
                    (this.richTextBox1.Text[right + tag.Length + 3] != '\n'))
                {
                    this.richTextBox1.Text = this.richTextBox1.Text.Insert(right + tag.Length + 3, "\n");
                }
                if ((left > 0) && (this.richTextBox1.Text[left - 1] != '\n'))
                {
                    this.richTextBox1.Text = this.richTextBox1.Text.Insert(left, "\n");
                    right++;
                }
            }
            this.richTextBox1.Focus();
            this.richTextBox1.Select(right, 0);
        }

        // show translations
        private bool transshown = false;

        private void button10_Click(object sender, EventArgs e)
        {
            int nr;
            try
            {
                nr = Int32.Parse(this.textBox2.Text);
            }
            catch (Exception ex)
            {
                Util.MBoxError("�berpr�fen Sie die Liednummer!", ex);
                this.textBox2.Focus();
                this.textBox2.SelectAll();
                return;
            }
            if (this.toDel != null && nr == this.toDel.Number)
            {
                this.song = this.toDel;
                this.toDel = null;
                this.textBox2.Enabled = false;
                this.button12.Enabled = true;
            }
            if (this.song == null)
            {
                DialogResult add = MessageBox.Show(this, "Das neue Lied muss zuerst gespeichert werden.\n" +
                                                         "Soll das Lied jetzt hinzugef�gt werden?", "lyra Hinweis",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);
                if (add == DialogResult.No)
                {
                    return;
                }
                string title = this.textBox1.Text;
                string text = this.richTextBox1.Text;
                string id = "s" + Util.toFour(nr);
                string desc = this.checkBox1.Checked ? this.textBox3.Text : "";
                this.song = new Song(nr, title, text, id, desc, true);
                if (this.toDel != null)
                {
                    CopyTrans(this.toDel, this.song);
                    this.toDel.Delete();
                }
                try
                {
                    this.owner.AddSong(this.song);
                }
                catch
                {
                    string msg = "Diese Liednummer wurde bereits einmal verwendet!\n";
                    msg += "Soll das Lied trotzdem hinzugef�gt werden?";

                    DialogResult dr = MessageBox.Show(this, msg, "lyra - neues Lied hinzuf�gen",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        this.song.nextID();
                        this.owner.AddSong(this.song);
                    }
                    else
                    {
                        return;
                    }
                }
                this.owner.Status = "Neues Lied erfolgreich hinzugef�gt...";
                this.owner.UpdateListBox();
                this.owner.ToUpdate(true);
                this.textBox2.Enabled = false;
                this.button12.Enabled = true;
            }

            if (!this.transshown)
            {
                this.Height = 568;
                this.transshown = true;
                this.button10.Text = "<< �bersetzungen";
                this.song.ShowTranslations(this.listBox1);
                if (this.listBox1.Items.Count > 0)
                {
                    this.listBox1.SelectedIndex = 0;
                }
            }
            else
            {
                this.Height = 460;
                this.transshown = false;
                this.button10.Text = "�bersetzungen >>";
            }
        }

        // Translations
        // neu...
        private void button16_Click(object sender, EventArgs e)
        {
            if (!TEditor.TEditorOpen)
            {
                (new TEditor(this.listBox1, this.song, this.owner)).Show();
            }
            else
            {
                TEditor.tEditor.Focus();
            }
        }

        // edit
        private void button17_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItems.Count == 1)
            {
                if (!TEditor.TEditorOpen)
                {
                    (new TEditor(this.listBox1, this.song, this.owner, (ITranslation)this.listBox1.SelectedItem)).Show();
                }
                else
                {
                    TEditor.tEditor.Focus();
                }
            }
        }

        // del
        private void button14_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItems.Count == 1)
            {
                this.song.RemoveTranslation((ITranslation)this.listBox1.SelectedItem);
                this.song.ShowTranslations(this.listBox1);
                this.owner.ToUpdate(true);
            }
        }

        private void MeGotFocus(object sender, EventArgs e)
        {
            if (TEditor.TEditorOpen)
            {
                TEditor.tEditor.Focus();
            }
        }

        // change Song-Nr.
        private ISong toDel = null;

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.transshown)
            {
                this.button10_Click(sender, e);
            }
            this.button12.Enabled = false;
            this.textBox2.Enabled = true;
            this.toDel = this.song;
            this.song = null;
        }

        private static void CopyTrans(ISong from, ISong to)
        {
            from.copyTranslation(to);
        }

        // checkBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox3.Enabled = true;
                this.textBox3.Text = "";
                this.textBox3.SelectAll();
            }
            else
            {
                this.textBox3.Enabled = false;
                this.textBox3.Text = "---";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox4.Text.Trim() != "")
            {
                this.checkBox2.Enabled = true;
                this.trackBar1.Enabled = true;
                this.label9.Enabled = true;
                this.label10.Enabled = true;
                if (this.textBox4.Text.StartsWith(Util.PICTDIR))
                {
                    this.textBox4.Text = this.textBox4.Text.Replace(Util.PICTDIR, Util.PICTSSYM);
                }
            }
            else
            {
                this.textBox4.Text = "";
                this.checkBox2.Enabled = false;
                this.checkBox2.Checked = false;
                this.trackBar1.Value = 0;
                this.trackBar1.Enabled = false;
                this.label9.Enabled = false;
                this.label10.Enabled = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bilder|*.gif;*.jpg;*.png;*.bmp";
            ofd.CheckFileExists = true;
            ofd.Title = "W�hlen Sie bitte eine Bild-Datei aus!";

            if (this.textBox4.Text == "")
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else
            {
                ofd.FileName = this.textBox4.Text.Replace(Util.PICTSSYM, Util.PICTDIR);
            }

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                this.textBox4.Text = ofd.FileName;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Util.GenerateMagicImage(this.transImage, this.trackBar1.Value);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (((keyData & Keys.B) == Keys.B) && (keyData & Keys.Control) == Keys.Control)
            {
                if (this.owner != null)
                {
                    this.owner.BlackScreen();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            string id = Util.PREVIEW_SONG_ID;
            string title = this.textBox1.Text;
            string text = this.richTextBox1.Text;
            int nr = 0;
            try
            {
                nr = int.Parse(this.textBox2.Text);
            }
            catch (Exception)
            { }
            string desc = this.textBox3.Text == "---" ? "" : this.textBox3.Text;
            ISong previewSong = new Song(nr, title, text, id, desc, true);
            previewSong.BackgroundPicture = this.textBox4.Text;
            previewSong.Transparency = this.trackBar1.Value;
            previewSong.Scale = this.checkBox2.Checked;
            ListBox previewListBox = new ListBox();
            previewListBox.Items.Add(previewSong);
            View.ShowSong(previewSong, this.owner, previewListBox);
        }
    }
}