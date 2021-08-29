namespace FilesChanger
{
    partial class FilesChanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesChanger));
            this.pbBar = new System.Windows.Forms.ProgressBar();
            this.FilesListView = new System.Windows.Forms.CheckedListBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.CurrentFile = new System.Windows.Forms.Label();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.cbRename = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pbBar
            // 
            this.pbBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBar.Location = new System.Drawing.Point(10, 337);
            this.pbBar.Margin = new System.Windows.Forms.Padding(2);
            this.pbBar.Name = "pbBar";
            this.pbBar.Size = new System.Drawing.Size(581, 19);
            this.pbBar.TabIndex = 0;
            // 
            // FilesListView
            // 
            this.FilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesListView.CheckOnClick = true;
            this.FilesListView.FormattingEnabled = true;
            this.FilesListView.Location = new System.Drawing.Point(275, 11);
            this.FilesListView.Margin = new System.Windows.Forms.Padding(2);
            this.FilesListView.Name = "FilesListView";
            this.FilesListView.Size = new System.Drawing.Size(317, 274);
            this.FilesListView.TabIndex = 1;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(10, 39);
            this.btnPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(141, 40);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "Открыть папку";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Anime Ace v02", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnStart.Location = new System.Drawing.Point(10, 102);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(141, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Запустить";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // CurrentFile
            // 
            this.CurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentFile.AutoSize = true;
            this.CurrentFile.Location = new System.Drawing.Point(10, 318);
            this.CurrentFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentFile.Name = "CurrentFile";
            this.CurrentFile.Size = new System.Drawing.Size(56, 13);
            this.CurrentFile.TabIndex = 4;
            this.CurrentFile.Text = "Прогресс";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAll.Location = new System.Drawing.Point(275, 291);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(99, 28);
            this.btnCheckAll.TabIndex = 5;
            this.btnCheckAll.Text = "Выбрать все";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // cbRename
            // 
            this.cbRename.AutoSize = true;
            this.cbRename.Checked = true;
            this.cbRename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRename.Location = new System.Drawing.Point(10, 164);
            this.cbRename.Name = "cbRename";
            this.cbRename.Size = new System.Drawing.Size(164, 17);
            this.cbRename.TabIndex = 6;
            this.cbRename.Text = "Включить переименование";
            this.cbRename.UseVisualStyleBackColor = true;
            this.cbRename.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbRename_MouseDown);
            // 
            // FilesChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.cbRename);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.CurrentFile);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.FilesListView);
            this.Controls.Add(this.pbBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(616, 405);
            this.Name = "FilesChanger";
            this.Text = "Kyuuzo\'s File Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbBar;
        private System.Windows.Forms.CheckedListBox FilesListView;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label CurrentFile;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.CheckBox cbRename;
    }
}

