namespace FilesChanger
{
    partial class Form1
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
            this.pbBar = new System.Windows.Forms.ProgressBar();
            this.FilesListView = new System.Windows.Forms.CheckedListBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CurrentFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbBar
            // 
            this.pbBar.Location = new System.Drawing.Point(13, 415);
            this.pbBar.Name = "pbBar";
            this.pbBar.Size = new System.Drawing.Size(775, 23);
            this.pbBar.TabIndex = 0;
            // 
            // FilesListView
            // 
            this.FilesListView.CheckOnClick = true;
            this.FilesListView.FormattingEnabled = true;
            this.FilesListView.Location = new System.Drawing.Point(367, 13);
            this.FilesListView.Name = "FilesListView";
            this.FilesListView.Size = new System.Drawing.Size(421, 361);
            this.FilesListView.TabIndex = 1;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(13, 48);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(188, 49);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "Choose Folder";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Anime Ace v02", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.ForestGreen;
            this.button2.Location = new System.Drawing.Point(13, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CurrentFile
            // 
            this.CurrentFile.AutoSize = true;
            this.CurrentFile.Location = new System.Drawing.Point(13, 392);
            this.CurrentFile.Name = "CurrentFile";
            this.CurrentFile.Size = new System.Drawing.Size(46, 17);
            this.CurrentFile.TabIndex = 4;
            this.CurrentFile.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentFile);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.FilesListView);
            this.Controls.Add(this.pbBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbBar;
        private System.Windows.Forms.CheckedListBox FilesListView;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label CurrentFile;
    }
}

