﻿namespace CheckDif
{
    partial class fmMain
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
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.cbFolder = new System.Windows.Forms.ComboBox();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShowDif = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tbWinMergePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbConnStr = new System.Windows.Forms.ComboBox();
            this.lbConnStr = new System.Windows.Forms.Label();
            this.dlgPickFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.clFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clObject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.Location = new System.Drawing.Point(8, 233);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(579, 77);
            this.tbInfo.TabIndex = 2;
            // 
            // cbFolder
            // 
            this.cbFolder.FormattingEnabled = true;
            this.cbFolder.Location = new System.Drawing.Point(57, 8);
            this.cbFolder.Name = "cbFolder";
            this.cbFolder.Size = new System.Drawing.Size(265, 21);
            this.cbFolder.TabIndex = 6;
            this.cbFolder.SelectedIndexChanged += new System.EventHandler(this.cbFolder_SelectedIndexChanged);
            // 
            // lbFolder
            // 
            this.lbFolder.AutoSize = true;
            this.lbFolder.Location = new System.Drawing.Point(10, 11);
            this.lbFolder.Name = "lbFolder";
            this.lbFolder.Size = new System.Drawing.Size(39, 13);
            this.lbFolder.TabIndex = 7;
            this.lbFolder.Text = "Folder:";
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Location = new System.Drawing.Point(328, 6);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(75, 23);
            this.btnPickFolder.TabIndex = 8;
            this.btnPickFolder.Text = "Pick";
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.AutoSize = true;
            this.lbFiles.Location = new System.Drawing.Point(8, 36);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(31, 13);
            this.lbFiles.TabIndex = 9;
            this.lbFiles.Text = "Files:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(527, 377);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowDif
            // 
            this.btnShowDif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowDif.Location = new System.Drawing.Point(6, 316);
            this.btnShowDif.Name = "btnShowDif";
            this.btnShowDif.Size = new System.Drawing.Size(75, 23);
            this.btnShowDif.TabIndex = 11;
            this.btnShowDif.Text = "Show dif";
            this.btnShowDif.UseVisualStyleBackColor = true;
            this.btnShowDif.Click += new System.EventHandler(this.btnShowDif_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(249, 136);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 12;
            this.progressBar.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(603, 371);
            this.tabControl.TabIndex = 13;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.lvFiles);
            this.tabMain.Controls.Add(this.cbFolder);
            this.tabMain.Controls.Add(this.btnShowDif);
            this.tabMain.Controls.Add(this.progressBar);
            this.tabMain.Controls.Add(this.tbInfo);
            this.tabMain.Controls.Add(this.lbFiles);
            this.tabMain.Controls.Add(this.btnPickFolder);
            this.tabMain.Controls.Add(this.lbFolder);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(595, 345);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tbWinMergePath);
            this.tabSettings.Controls.Add(this.button1);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.cbConnStr);
            this.tabSettings.Controls.Add(this.lbConnStr);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(595, 345);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tbWinMergePath
            // 
            this.tbWinMergePath.Location = new System.Drawing.Point(16, 72);
            this.tbWinMergePath.Name = "tbWinMergePath";
            this.tbWinMergePath.Size = new System.Drawing.Size(309, 20);
            this.tbWinMergePath.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Pick";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "WinMerge path:";
            // 
            // cbConnStr
            // 
            this.cbConnStr.FormattingEnabled = true;
            this.cbConnStr.Location = new System.Drawing.Point(16, 25);
            this.cbConnStr.Name = "cbConnStr";
            this.cbConnStr.Size = new System.Drawing.Size(309, 21);
            this.cbConnStr.TabIndex = 8;
            // 
            // lbConnStr
            // 
            this.lbConnStr.AutoSize = true;
            this.lbConnStr.Location = new System.Drawing.Point(13, 9);
            this.lbConnStr.Name = "lbConnStr";
            this.lbConnStr.Size = new System.Drawing.Size(92, 13);
            this.lbConnStr.TabIndex = 9;
            this.lbConnStr.Text = "Connection string:";
            // 
            // dlgPickFolder
            // 
            this.dlgPickFolder.ShowNewFolderButton = false;
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clFile,
            this.clObject});
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFiles.Location = new System.Drawing.Point(8, 52);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(579, 175);
            this.lvFiles.TabIndex = 13;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DoubleClick += new System.EventHandler(this.lvFiles_DoubleClick);
            // 
            // clFile
            // 
            this.clFile.Text = "File";
            this.clFile.Width = 200;
            // 
            // clObject
            // 
            this.clObject.Text = "Object";
            this.clObject.Width = 300;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 403);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnClose);
            this.Name = "fmMain";
            this.Text = "CheckDif";
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.ComboBox cbFolder;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.Button btnPickFolder;
        private System.Windows.Forms.Label lbFiles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowDif;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.FolderBrowserDialog dlgPickFolder;
        private System.Windows.Forms.TextBox tbWinMergePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbConnStr;
        private System.Windows.Forms.Label lbConnStr;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader clFile;
        private System.Windows.Forms.ColumnHeader clObject;
    }
}

