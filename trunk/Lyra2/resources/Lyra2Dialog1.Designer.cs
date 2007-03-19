namespace Lyra2
{
    partial class Lyra2Dialog1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lyra2Dialog1));
            this.contentPane = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.commentLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.topBorder1 = new System.Windows.Forms.Panel();
            this.topBorder2 = new System.Windows.Forms.Panel();
            this.picPanel = new System.Windows.Forms.Panel();
            this.titlePic = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.bottomBorder1 = new System.Windows.Forms.Panel();
            this.bottomBorder2 = new System.Windows.Forms.Panel();
            this.topBorderRight1 = new System.Windows.Forms.Panel();
            this.topBorderRight2 = new System.Windows.Forms.Panel();
            this.buttonPane = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.topBorder1.SuspendLayout();
            this.picPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePic)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.bottomBorder1.SuspendLayout();
            this.topBorderRight1.SuspendLayout();
            this.buttonPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPane
            // 
            this.contentPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPane.Location = new System.Drawing.Point(0, 0);
            this.contentPane.Name = "contentPane";
            this.contentPane.Size = new System.Drawing.Size(388, 277);
            this.contentPane.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.commentLabel);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Controls.Add(this.topBorder1);
            this.topPanel.Controls.Add(this.picPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(388, 68);
            this.topPanel.TabIndex = 1;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(13, 30);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(126, 15);
            this.commentLabel.TabIndex = 2;
            this.commentLabel.Text = "Insert comment here...";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(40, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Title";
            // 
            // topBorder1
            // 
            this.topBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.topBorder1.Controls.Add(this.topBorder2);
            this.topBorder1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topBorder1.Location = new System.Drawing.Point(0, 66);
            this.topBorder1.Name = "topBorder1";
            this.topBorder1.Size = new System.Drawing.Size(220, 2);
            this.topBorder1.TabIndex = 0;
            // 
            // topBorder2
            // 
            this.topBorder2.BackColor = System.Drawing.Color.White;
            this.topBorder2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topBorder2.Location = new System.Drawing.Point(0, 1);
            this.topBorder2.Name = "topBorder2";
            this.topBorder2.Size = new System.Drawing.Size(220, 1);
            this.topBorder2.TabIndex = 0;
            // 
            // picPanel
            // 
            this.picPanel.Controls.Add(this.topBorderRight1);
            this.picPanel.Controls.Add(this.titlePic);
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.picPanel.Location = new System.Drawing.Point(220, 0);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(168, 68);
            this.picPanel.TabIndex = 3;
            // 
            // titlePic
            // 
            this.titlePic.Image = ((System.Drawing.Image)(resources.GetObject("titlePic.Image")));
            this.titlePic.Location = new System.Drawing.Point(0, 0);
            this.titlePic.Name = "titlePic";
            this.titlePic.Size = new System.Drawing.Size(168, 68);
            this.titlePic.TabIndex = 0;
            this.titlePic.TabStop = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.buttonPane);
            this.bottomPanel.Controls.Add(this.bottomBorder1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 230);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(388, 47);
            this.bottomPanel.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(3, 10);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Abbrechen";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(84, 10);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // bottomBorder1
            // 
            this.bottomBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.bottomBorder1.Controls.Add(this.bottomBorder2);
            this.bottomBorder1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomBorder1.Location = new System.Drawing.Point(0, 0);
            this.bottomBorder1.Name = "bottomBorder1";
            this.bottomBorder1.Size = new System.Drawing.Size(388, 2);
            this.bottomBorder1.TabIndex = 0;
            // 
            // bottomBorder2
            // 
            this.bottomBorder2.BackColor = System.Drawing.Color.White;
            this.bottomBorder2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomBorder2.Location = new System.Drawing.Point(0, 0);
            this.bottomBorder2.Name = "bottomBorder2";
            this.bottomBorder2.Size = new System.Drawing.Size(388, 1);
            this.bottomBorder2.TabIndex = 0;
            // 
            // topBorderRight1
            // 
            this.topBorderRight1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.topBorderRight1.Controls.Add(this.topBorderRight2);
            this.topBorderRight1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topBorderRight1.Location = new System.Drawing.Point(0, 66);
            this.topBorderRight1.Name = "topBorderRight1";
            this.topBorderRight1.Size = new System.Drawing.Size(168, 2);
            this.topBorderRight1.TabIndex = 1;
            // 
            // topBorderRight2
            // 
            this.topBorderRight2.BackColor = System.Drawing.Color.White;
            this.topBorderRight2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topBorderRight2.Location = new System.Drawing.Point(0, 1);
            this.topBorderRight2.Name = "topBorderRight2";
            this.topBorderRight2.Size = new System.Drawing.Size(168, 1);
            this.topBorderRight2.TabIndex = 0;
            // 
            // buttonPane
            // 
            this.buttonPane.Controls.Add(this.cancelBtn);
            this.buttonPane.Controls.Add(this.okBtn);
            this.buttonPane.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPane.Location = new System.Drawing.Point(220, 2);
            this.buttonPane.Name = "buttonPane";
            this.buttonPane.Size = new System.Drawing.Size(168, 45);
            this.buttonPane.TabIndex = 2;
            // 
            // Lyra2Dialog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 277);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.contentPane);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Lyra2Dialog1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lyra Dialog";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.topBorder1.ResumeLayout(false);
            this.picPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.titlePic)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomBorder1.ResumeLayout(false);
            this.topBorderRight1.ResumeLayout(false);
            this.buttonPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentPane;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel topBorder1;
        private System.Windows.Forms.Panel topBorder2;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel bottomBorder1;
        private System.Windows.Forms.Panel bottomBorder2;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.PictureBox titlePic;
        private System.Windows.Forms.Panel topBorderRight1;
        private System.Windows.Forms.Panel topBorderRight2;
        private System.Windows.Forms.Panel buttonPane;
    }
}