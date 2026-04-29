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
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pbBar
            // 
            resources.ApplyResources(pbBar, "pbBar");
            pbBar.Name = "pbBar";
            // 
            // FilesListView
            // 
            resources.ApplyResources(FilesListView, "FilesListView");
            FilesListView.CheckOnClick = true;
            FilesListView.FormattingEnabled = true;
            FilesListView.Name = "FilesListView";
            // 
            // btnPath
            // 
            resources.ApplyResources(btnPath, "btnPath");
            btnPath.Name = "btnPath";
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // btnStart
            // 
            resources.ApplyResources(btnStart, "btnStart");
            btnStart.ForeColor = Color.ForestGreen;
            btnStart.Name = "btnStart";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button2_Click;
            // 
            // CurrentFile
            // 
            resources.ApplyResources(CurrentFile, "CurrentFile");
            CurrentFile.Name = "CurrentFile";
            // 
            // btnCheckAll
            // 
            resources.ApplyResources(btnCheckAll, "btnCheckAll");
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.UseVisualStyleBackColor = true;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // cbRename
            // 
            resources.ApplyResources(cbRename, "cbRename");
            cbRename.Checked = true;
            cbRename.CheckState = CheckState.Checked;
            cbRename.Name = "cbRename";
            cbRename.UseVisualStyleBackColor = true;
            cbRename.MouseDown += cbRename_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbTopChildDirectories);
            groupBox1.Controls.Add(rbTopDirectory);
            groupBox1.Controls.Add(cbRename);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // rbTopChildDirectories
            // 
            resources.ApplyResources(rbTopChildDirectories, "rbTopChildDirectories");
            rbTopChildDirectories.Name = "rbTopChildDirectories";
            rbTopChildDirectories.TabStop = true;
            rbTopChildDirectories.UseVisualStyleBackColor = true;
            rbTopChildDirectories.CheckedChanged += rbTopChildDirectories_CheckedChanged;
            // 
            // rbTopDirectory
            // 
            resources.ApplyResources(rbTopDirectory, "rbTopDirectory");
            rbTopDirectory.Name = "rbTopDirectory";
            rbTopDirectory.TabStop = true;
            rbTopDirectory.UseVisualStyleBackColor = true;
            rbTopDirectory.CheckedChanged += rbTopDirectory_CheckedChanged;
            // 
            // FilesChanger
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(btnCheckAll);
            Controls.Add(CurrentFile);
            Controls.Add(btnStart);
            Controls.Add(btnPath);
            Controls.Add(FilesListView);
            Controls.Add(pbBar);
            Name = "FilesChanger";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}

