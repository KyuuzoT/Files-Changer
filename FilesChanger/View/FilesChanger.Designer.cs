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
            pbBar = new ProgressBar();
            FilesListView = new CheckedListBox();
            btnPath = new Button();
            btnStart = new Button();
            CurrentFile = new Label();
            btnCheckAll = new Button();
            cbRename = new CheckBox();
            groupBox1 = new GroupBox();
            rbTopChildDirectories = new RadioButton();
            rbTopDirectory = new RadioButton();
            gbLanguageChange = new GroupBox();
            bLanguageRu = new Button();
            bLanguageEn = new Button();
            groupBox1.SuspendLayout();
            gbLanguageChange.SuspendLayout();
            SuspendLayout();
            // 
            // pbBar
            // 
            pbBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbBar.Location = new Point(20, 778);
            pbBar.Margin = new Padding(4, 5, 4, 5);
            pbBar.Name = "pbBar";
            pbBar.Size = new Size(1162, 44);
            pbBar.TabIndex = 8;
            // 
            // FilesListView
            // 
            FilesListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FilesListView.CheckOnClick = true;
            FilesListView.FormattingEnabled = true;
            FilesListView.Location = new Point(550, 89);
            FilesListView.Margin = new Padding(4, 5, 4, 5);
            FilesListView.Name = "FilesListView";
            FilesListView.Size = new Size(630, 548);
            FilesListView.TabIndex = 3;
            // 
            // btnPath
            // 
            btnPath.Location = new Point(20, 90);
            btnPath.Margin = new Padding(4, 5, 4, 5);
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(282, 92);
            btnPath.TabIndex = 2;
            btnPath.Text = "Open Folder";
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 204);
            btnStart.ForeColor = Color.ForestGreen;
            btnStart.Location = new Point(20, 235);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(282, 92);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button2_Click;
            // 
            // CurrentFile
            // 
            CurrentFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CurrentFile.AutoSize = true;
            CurrentFile.Location = new Point(20, 734);
            CurrentFile.Margin = new Padding(4, 0, 4, 0);
            CurrentFile.Name = "CurrentFile";
            CurrentFile.Size = new Size(92, 30);
            CurrentFile.TabIndex = 7;
            CurrentFile.Text = "Progress";
            // 
            // btnCheckAll
            // 
            btnCheckAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckAll.Location = new Point(550, 662);
            btnCheckAll.Margin = new Padding(6, 7, 6, 7);
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.Size = new Size(198, 65);
            btnCheckAll.TabIndex = 6;
            btnCheckAll.Text = "Select all";
            btnCheckAll.UseVisualStyleBackColor = true;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // cbRename
            // 
            cbRename.AutoSize = true;
            cbRename.Checked = true;
            cbRename.CheckState = CheckState.Checked;
            cbRename.Location = new Point(12, 44);
            cbRename.Margin = new Padding(6, 7, 6, 7);
            cbRename.Name = "cbRename";
            cbRename.Size = new Size(229, 34);
            cbRename.TabIndex = 0;
            cbRename.Text = "Enable file renaming";
            cbRename.UseVisualStyleBackColor = true;
            cbRename.MouseDown += cbRename_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbTopChildDirectories);
            groupBox1.Controls.Add(rbTopDirectory);
            groupBox1.Controls.Add(cbRename);
            groupBox1.Location = new Point(20, 374);
            groupBox1.Margin = new Padding(6, 7, 6, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 7, 6, 7);
            groupBox1.Size = new Size(518, 353);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // rbTopChildDirectories
            // 
            rbTopChildDirectories.AutoSize = true;
            rbTopChildDirectories.Location = new Point(12, 155);
            rbTopChildDirectories.Margin = new Padding(6, 7, 6, 7);
            rbTopChildDirectories.Name = "rbTopChildDirectories";
            rbTopChildDirectories.Size = new Size(257, 34);
            rbTopChildDirectories.TabIndex = 2;
            rbTopChildDirectories.TabStop = true;
            rbTopChildDirectories.Text = "Parent and child folders";
            rbTopChildDirectories.UseVisualStyleBackColor = true;
            rbTopChildDirectories.CheckedChanged += rbTopChildDirectories_CheckedChanged;
            // 
            // rbTopDirectory
            // 
            rbTopDirectory.AutoSize = true;
            rbTopDirectory.Location = new Point(12, 99);
            rbTopDirectory.Margin = new Padding(6, 7, 6, 7);
            rbTopDirectory.Name = "rbTopDirectory";
            rbTopDirectory.Size = new Size(202, 34);
            rbTopDirectory.TabIndex = 1;
            rbTopDirectory.TabStop = true;
            rbTopDirectory.Text = "Parent folder only";
            rbTopDirectory.UseVisualStyleBackColor = true;
            rbTopDirectory.CheckedChanged += rbTopDirectory_CheckedChanged;
            // 
            // gbLanguageChange
            // 
            gbLanguageChange.Controls.Add(bLanguageRu);
            gbLanguageChange.Controls.Add(bLanguageEn);
            gbLanguageChange.Location = new Point(1030, 0);
            gbLanguageChange.Name = "gbLanguageChange";
            gbLanguageChange.Size = new Size(150, 81);
            gbLanguageChange.TabIndex = 1;
            gbLanguageChange.TabStop = false;
            gbLanguageChange.Text = "Language";
            // 
            // bLanguageRu
            // 
            bLanguageRu.Location = new Point(78, 35);
            bLanguageRu.Name = "bLanguageRu";
            bLanguageRu.Size = new Size(58, 40);
            bLanguageRu.TabIndex = 1;
            bLanguageRu.Text = "Ру";
            bLanguageRu.UseVisualStyleBackColor = true;
            bLanguageRu.Click += RuLanguageButton_Click;
            // 
            // bLanguageEn
            // 
            bLanguageEn.Location = new Point(14, 35);
            bLanguageEn.Name = "bLanguageEn";
            bLanguageEn.Size = new Size(58, 40);
            bLanguageEn.TabIndex = 0;
            bLanguageEn.Text = "En";
            bLanguageEn.UseVisualStyleBackColor = true;
            bLanguageEn.Click += EnLanguageButton_Click;
            // 
            // FilesChanger
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 845);
            Controls.Add(gbLanguageChange);
            Controls.Add(groupBox1);
            Controls.Add(btnCheckAll);
            Controls.Add(CurrentFile);
            Controls.Add(btnStart);
            Controls.Add(btnPath);
            Controls.Add(FilesListView);
            Controls.Add(pbBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1208, 851);
            Name = "FilesChanger";
            Text = "Kyuuzo's File Changer";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbLanguageChange.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbBar;
        private System.Windows.Forms.CheckedListBox FilesListView;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label CurrentFile;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.CheckBox cbRename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTopChildDirectories;
        private System.Windows.Forms.RadioButton rbTopDirectory;
        private GroupBox gbLanguageChange;
        private Button bLanguageRu;
        private Button bLanguageEn;
    }
}

