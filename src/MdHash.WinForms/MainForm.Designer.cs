namespace MdHash.WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.Label();
            this.lblMd5 = new System.Windows.Forms.Label();
            this.txtHashSha1 = new System.Windows.Forms.TextBox();
            this.txtHashSha256 = new System.Windows.Forms.TextBox();
            this.lblSha1 = new System.Windows.Forms.Label();
            this.lblSha256 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlProgressBg = new System.Windows.Forms.Panel();
            this.pnlProgressFg = new System.Windows.Forms.Panel();
            this.linkLabelHashText = new System.Windows.Forms.LinkLabel();
            this.chkMD5 = new System.Windows.Forms.CheckBox();
            this.chkSHA1 = new System.Windows.Forms.CheckBox();
            this.chkSHA256 = new System.Windows.Forms.CheckBox();
            this.chkSHA384 = new System.Windows.Forms.CheckBox();
            this.chkSHA512 = new System.Windows.Forms.CheckBox();
            this.lblSha384 = new System.Windows.Forms.Label();
            this.txtHashSha384 = new System.Windows.Forms.TextBox();
            this.lblSha512 = new System.Windows.Forms.Label();
            this.txtHashSha512 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlProgressBg.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitle.Location = new System.Drawing.Point(32, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "OrangeHash";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFileName.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblFileName.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblFileName.Location = new System.Drawing.Point(12, 59);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(245, 14);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "No file provided — click to select";
            this.lblFileName.Click += new System.EventHandler(this.lblFileName_Click);
            // 
            // txtHash
            // 
            this.txtHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(5)))), ((int)(((byte)(3)))));
            this.txtHash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHash.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtHash.Location = new System.Drawing.Point(81, 83);
            this.txtHash.Name = "txtHash";
            this.txtHash.ReadOnly = true;
            this.txtHash.Size = new System.Drawing.Size(461, 18);
            this.txtHash.TabIndex = 2;
            this.txtHash.Tag = "MD5";
            this.txtHash.Click += new System.EventHandler(this.txtHash_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(467, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save to .txt";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(519, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 17);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtStatus.ForeColor = System.Drawing.Color.DimGray;
            this.txtStatus.Location = new System.Drawing.Point(12, 214);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(105, 14);
            this.txtStatus.TabIndex = 5;
            this.txtStatus.Text = "- Chose a file";
            // 
            // lblMd5
            // 
            this.lblMd5.AutoSize = true;
            this.lblMd5.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblMd5.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblMd5.Location = new System.Drawing.Point(12, 85);
            this.lblMd5.Name = "lblMd5";
            this.lblMd5.Size = new System.Drawing.Size(35, 14);
            this.lblMd5.TabIndex = 2;
            this.lblMd5.Text = "MD5:";
            // 
            // txtHashSha1
            // 
            this.txtHashSha1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHashSha1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(5)))), ((int)(((byte)(3)))));
            this.txtHashSha1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHashSha1.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtHashSha1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtHashSha1.Location = new System.Drawing.Point(81, 109);
            this.txtHashSha1.Name = "txtHashSha1";
            this.txtHashSha1.ReadOnly = true;
            this.txtHashSha1.Size = new System.Drawing.Size(461, 18);
            this.txtHashSha1.TabIndex = 6;
            this.txtHashSha1.Tag = "SHA-1";
            this.txtHashSha1.Click += new System.EventHandler(this.txtHash_Click);
            // 
            // txtHashSha256
            // 
            this.txtHashSha256.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHashSha256.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(5)))), ((int)(((byte)(3)))));
            this.txtHashSha256.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHashSha256.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtHashSha256.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtHashSha256.Location = new System.Drawing.Point(81, 135);
            this.txtHashSha256.Name = "txtHashSha256";
            this.txtHashSha256.ReadOnly = true;
            this.txtHashSha256.Size = new System.Drawing.Size(461, 18);
            this.txtHashSha256.TabIndex = 7;
            this.txtHashSha256.Tag = "SHA-256";
            this.txtHashSha256.Click += new System.EventHandler(this.txtHash_Click);
            // 
            // lblSha1
            // 
            this.lblSha1.AutoSize = true;
            this.lblSha1.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSha1.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSha1.Location = new System.Drawing.Point(12, 111);
            this.lblSha1.Name = "lblSha1";
            this.lblSha1.Size = new System.Drawing.Size(49, 14);
            this.lblSha1.TabIndex = 3;
            this.lblSha1.Text = "SHA-1:";
            // 
            // lblSha256
            // 
            this.lblSha256.AutoSize = true;
            this.lblSha256.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSha256.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSha256.Location = new System.Drawing.Point(12, 137);
            this.lblSha256.Name = "lblSha256";
            this.lblSha256.Size = new System.Drawing.Size(63, 14);
            this.lblSha256.TabIndex = 4;
            this.lblSha256.Text = "SHA-256:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Orange;
            this.linkLabel1.Location = new System.Drawing.Point(478, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(36, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 6F);
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(114, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 9);
            this.label1.TabIndex = 10;
            this.label1.Text = "v2.3";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MdHash.WinForms.Properties.Resources.orange_hash_32_32_new;
            this.pictureBox1.Location = new System.Drawing.Point(14, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pnlProgressBg
            // 
            this.pnlProgressBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.pnlProgressBg.Controls.Add(this.pnlProgressFg);
            this.pnlProgressBg.Location = new System.Drawing.Point(15, 239);
            this.pnlProgressBg.Name = "pnlProgressBg";
            this.pnlProgressBg.Size = new System.Drawing.Size(448, 10);
            this.pnlProgressBg.TabIndex = 12;
            // 
            // pnlProgressFg
            // 
            this.pnlProgressFg.BackColor = System.Drawing.Color.Orange;
            this.pnlProgressFg.Location = new System.Drawing.Point(0, 0);
            this.pnlProgressFg.Name = "pnlProgressFg";
            this.pnlProgressFg.Size = new System.Drawing.Size(0, 10);
            this.pnlProgressFg.TabIndex = 13;
            // 
            // linkLabelHashText
            // 
            this.linkLabelHashText.AutoSize = true;
            this.linkLabelHashText.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.linkLabelHashText.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelHashText.LinkColor = System.Drawing.Color.Orange;
            this.linkLabelHashText.Location = new System.Drawing.Point(411, 9);
            this.linkLabelHashText.Name = "linkLabelHashText";
            this.linkLabelHashText.Size = new System.Drawing.Size(60, 12);
            this.linkLabelHashText.TabIndex = 26;
            this.linkLabelHashText.TabStop = true;
            this.linkLabelHashText.Text = "Text To Hash";
            this.linkLabelHashText.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.linkLabelHashText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHashText_LinkClicked);
            // 
            // chkMD5
            // 
            this.chkMD5.AutoSize = true;
            this.chkMD5.Checked = true;
            this.chkMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMD5.Font = new System.Drawing.Font("Consolas", 8F);
            this.chkMD5.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkMD5.Location = new System.Drawing.Point(106, 35);
            this.chkMD5.Name = "chkMD5";
            this.chkMD5.Size = new System.Drawing.Size(44, 17);
            this.chkMD5.TabIndex = 14;
            this.chkMD5.Text = "MD5";
            this.chkMD5.UseVisualStyleBackColor = true;
            this.chkMD5.CheckedChanged += new System.EventHandler(this.HashSelection_CheckedChanged);
            // 
            // chkSHA1
            // 
            this.chkSHA1.AutoSize = true;
            this.chkSHA1.Checked = true;
            this.chkSHA1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA1.Font = new System.Drawing.Font("Consolas", 8F);
            this.chkSHA1.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkSHA1.Location = new System.Drawing.Point(161, 35);
            this.chkSHA1.Name = "chkSHA1";
            this.chkSHA1.Size = new System.Drawing.Size(50, 17);
            this.chkSHA1.TabIndex = 15;
            this.chkSHA1.Text = "SHA1";
            this.chkSHA1.UseVisualStyleBackColor = true;
            this.chkSHA1.CheckedChanged += new System.EventHandler(this.HashSelection_CheckedChanged);
            // 
            // chkSHA256
            // 
            this.chkSHA256.AutoSize = true;
            this.chkSHA256.Checked = true;
            this.chkSHA256.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA256.Font = new System.Drawing.Font("Consolas", 8F);
            this.chkSHA256.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkSHA256.Location = new System.Drawing.Point(223, 35);
            this.chkSHA256.Name = "chkSHA256";
            this.chkSHA256.Size = new System.Drawing.Size(62, 17);
            this.chkSHA256.TabIndex = 16;
            this.chkSHA256.Text = "SHA256";
            this.chkSHA256.UseVisualStyleBackColor = true;
            this.chkSHA256.CheckedChanged += new System.EventHandler(this.HashSelection_CheckedChanged);
            // 
            // chkSHA384
            // 
            this.chkSHA384.AutoSize = true;
            this.chkSHA384.Checked = true;
            this.chkSHA384.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA384.Font = new System.Drawing.Font("Consolas", 8F);
            this.chkSHA384.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkSHA384.Location = new System.Drawing.Point(298, 35);
            this.chkSHA384.Name = "chkSHA384";
            this.chkSHA384.Size = new System.Drawing.Size(62, 17);
            this.chkSHA384.TabIndex = 17;
            this.chkSHA384.Text = "SHA384";
            this.chkSHA384.UseVisualStyleBackColor = true;
            this.chkSHA384.CheckedChanged += new System.EventHandler(this.HashSelection_CheckedChanged);
            // 
            // chkSHA512
            // 
            this.chkSHA512.AutoSize = true;
            this.chkSHA512.Checked = true;
            this.chkSHA512.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSHA512.Font = new System.Drawing.Font("Consolas", 8F);
            this.chkSHA512.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkSHA512.Location = new System.Drawing.Point(373, 35);
            this.chkSHA512.Name = "chkSHA512";
            this.chkSHA512.Size = new System.Drawing.Size(62, 17);
            this.chkSHA512.TabIndex = 18;
            this.chkSHA512.Text = "SHA512";
            this.chkSHA512.UseVisualStyleBackColor = true;
            this.chkSHA512.CheckedChanged += new System.EventHandler(this.HashSelection_CheckedChanged);
            // 
            // lblSha384
            // 
            this.lblSha384.AutoSize = true;
            this.lblSha384.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSha384.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSha384.Location = new System.Drawing.Point(12, 163);
            this.lblSha384.Name = "lblSha384";
            this.lblSha384.Size = new System.Drawing.Size(63, 14);
            this.lblSha384.TabIndex = 22;
            this.lblSha384.Text = "SHA-384:";
            // 
            // txtHashSha384
            // 
            this.txtHashSha384.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHashSha384.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(5)))), ((int)(((byte)(3)))));
            this.txtHashSha384.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHashSha384.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtHashSha384.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtHashSha384.Location = new System.Drawing.Point(81, 161);
            this.txtHashSha384.Name = "txtHashSha384";
            this.txtHashSha384.ReadOnly = true;
            this.txtHashSha384.Size = new System.Drawing.Size(461, 18);
            this.txtHashSha384.TabIndex = 23;
            this.txtHashSha384.Tag = "SHA-384";
            this.txtHashSha384.Click += new System.EventHandler(this.txtHash_Click);
            // 
            // lblSha512
            // 
            this.lblSha512.AutoSize = true;
            this.lblSha512.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSha512.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSha512.Location = new System.Drawing.Point(12, 189);
            this.lblSha512.Name = "lblSha512";
            this.lblSha512.Size = new System.Drawing.Size(63, 14);
            this.lblSha512.TabIndex = 24;
            this.lblSha512.Text = "SHA-512:";
            // 
            // txtHashSha512
            // 
            this.txtHashSha512.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHashSha512.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(5)))), ((int)(((byte)(3)))));
            this.txtHashSha512.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHashSha512.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtHashSha512.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtHashSha512.Location = new System.Drawing.Point(81, 187);
            this.txtHashSha512.Name = "txtHashSha512";
            this.txtHashSha512.ReadOnly = true;
            this.txtHashSha512.Size = new System.Drawing.Size(461, 18);
            this.txtHashSha512.TabIndex = 25;
            this.txtHashSha512.Tag = "SHA-512";
            this.txtHashSha512.Click += new System.EventHandler(this.txtHash_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Algorithms :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(5)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(554, 260);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlProgressBg);
            this.Controls.Add(this.linkLabelHashText);
            this.Controls.Add(this.chkSHA512);
            this.Controls.Add(this.chkSHA384);
            this.Controls.Add(this.chkSHA256);
            this.Controls.Add(this.chkSHA1);
            this.Controls.Add(this.chkMD5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblSha512);
            this.Controls.Add(this.txtHashSha512);
            this.Controls.Add(this.lblSha384);
            this.Controls.Add(this.txtHashSha384);
            this.Controls.Add(this.lblSha256);
            this.Controls.Add(this.txtHashSha256);
            this.Controls.Add(this.lblSha1);
            this.Controls.Add(this.txtHashSha1);
            this.Controls.Add(this.lblMd5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Orange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrangeHash";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlProgressBg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Label lblMd5;
        private System.Windows.Forms.Label lblSha1;
        private System.Windows.Forms.Label lblSha256;
        private System.Windows.Forms.TextBox txtHashSha1;
        private System.Windows.Forms.TextBox txtHashSha256;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlProgressBg;
        private System.Windows.Forms.Panel pnlProgressFg;
        private System.Windows.Forms.CheckBox chkMD5;
        private System.Windows.Forms.CheckBox chkSHA1;
        private System.Windows.Forms.CheckBox chkSHA256;
        private System.Windows.Forms.CheckBox chkSHA384;
        private System.Windows.Forms.CheckBox chkSHA512;
        private System.Windows.Forms.LinkLabel linkLabelHashText;
        private System.Windows.Forms.Label lblSha384;
        private System.Windows.Forms.TextBox txtHashSha384;
        private System.Windows.Forms.Label lblSha512;
        private System.Windows.Forms.TextBox txtHashSha512;
        private System.Windows.Forms.Label label2;
    }
}
