namespace CheckDif
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
            this.btnSearchObjects = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.cbObjects = new System.Windows.Forms.ComboBox();
            this.lsbFiles = new System.Windows.Forms.ListBox();
            this.lbObject = new System.Windows.Forms.Label();
            this.cbFolder = new System.Windows.Forms.ComboBox();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShowDif = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnSearchObjects
            // 
            this.btnSearchObjects.Location = new System.Drawing.Point(329, 43);
            this.btnSearchObjects.Name = "btnSearchObjects";
            this.btnSearchObjects.Size = new System.Drawing.Size(75, 23);
            this.btnSearchObjects.TabIndex = 1;
            this.btnSearchObjects.Text = "Search";
            this.btnSearchObjects.UseVisualStyleBackColor = true;
            this.btnSearchObjects.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(12, 205);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(390, 77);
            this.tbInfo.TabIndex = 2;
            // 
            // cbObjects
            // 
            this.cbObjects.FormattingEnabled = true;
            this.cbObjects.Location = new System.Drawing.Point(58, 45);
            this.cbObjects.Name = "cbObjects";
            this.cbObjects.Size = new System.Drawing.Size(265, 21);
            this.cbObjects.TabIndex = 3;
            this.cbObjects.SelectedIndexChanged += new System.EventHandler(this.cbObjects_SelectedIndexChanged);
            // 
            // lsbFiles
            // 
            this.lsbFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbFiles.FormattingEnabled = true;
            this.lsbFiles.Location = new System.Drawing.Point(12, 93);
            this.lsbFiles.Name = "lsbFiles";
            this.lsbFiles.Size = new System.Drawing.Size(390, 106);
            this.lsbFiles.TabIndex = 4;
            // 
            // lbObject
            // 
            this.lbObject.AutoSize = true;
            this.lbObject.Location = new System.Drawing.Point(11, 48);
            this.lbObject.Name = "lbObject";
            this.lbObject.Size = new System.Drawing.Size(41, 13);
            this.lbObject.TabIndex = 5;
            this.lbObject.Text = "Object:";
            // 
            // cbFolder
            // 
            this.cbFolder.FormattingEnabled = true;
            this.cbFolder.Location = new System.Drawing.Point(58, 18);
            this.cbFolder.Name = "cbFolder";
            this.cbFolder.Size = new System.Drawing.Size(265, 21);
            this.cbFolder.TabIndex = 6;
            this.cbFolder.SelectedIndexChanged += new System.EventHandler(this.cbFolder_SelectedIndexChanged);
            // 
            // lbFolder
            // 
            this.lbFolder.AutoSize = true;
            this.lbFolder.Location = new System.Drawing.Point(11, 21);
            this.lbFolder.Name = "lbFolder";
            this.lbFolder.Size = new System.Drawing.Size(39, 13);
            this.lbFolder.TabIndex = 7;
            this.lbFolder.Text = "Folder:";
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Location = new System.Drawing.Point(329, 16);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(75, 23);
            this.btnPickFolder.TabIndex = 8;
            this.btnPickFolder.Text = "Pick";
            this.btnPickFolder.UseVisualStyleBackColor = true;
            // 
            // lbFiles
            // 
            this.lbFiles.AutoSize = true;
            this.lbFiles.Location = new System.Drawing.Point(9, 77);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(31, 13);
            this.lbFiles.TabIndex = 9;
            this.lbFiles.Text = "Files:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(329, 288);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowDif
            // 
            this.btnShowDif.Location = new System.Drawing.Point(12, 288);
            this.btnShowDif.Name = "btnShowDif";
            this.btnShowDif.Size = new System.Drawing.Size(75, 23);
            this.btnShowDif.TabIndex = 11;
            this.btnShowDif.Text = "Show dif";
            this.btnShowDif.UseVisualStyleBackColor = true;
            this.btnShowDif.Click += new System.EventHandler(this.btnShowDif_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(165, 123);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 12;
            this.progressBar.Visible = false;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 317);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnShowDif);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.btnPickFolder);
            this.Controls.Add(this.lbFolder);
            this.Controls.Add(this.cbFolder);
            this.Controls.Add(this.lbObject);
            this.Controls.Add(this.lsbFiles);
            this.Controls.Add(this.cbObjects);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.btnSearchObjects);
            this.Name = "fmMain";
            this.Text = "CheckDif";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchObjects;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.ComboBox cbObjects;
        private System.Windows.Forms.ListBox lsbFiles;
        private System.Windows.Forms.Label lbObject;
        private System.Windows.Forms.ComboBox cbFolder;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.Button btnPickFolder;
        private System.Windows.Forms.Label lbFiles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowDif;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

