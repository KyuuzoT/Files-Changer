using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FilesChanger
{
    public partial class Form1 : Form
    {
        private string pathToFiles;

        public string GetPath
        {
            get
            {
                return pathToFiles;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    pathToFiles = folderBrowser.SelectedPath;
                    FilesListView.Items.Clear();
                    FillListView();
                }
            }
        }

        private void FillListView()
        {
            DirectoryInfo di = new DirectoryInfo(pathToFiles);
            FileInfo[] files = di.GetFiles("*", SearchOption.AllDirectories);
            int i = 0;
            foreach (var item in files)
            {
                FilesListView.Items.Insert(i++, item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread ChangingThread;
            DirectoryInfo di = new DirectoryInfo(pathToFiles);
            FileInfo[] files = di.GetFiles("*", SearchOption.AllDirectories);

            pbBar.Maximum = files.Length;
            pbBar.Minimum = 0;
            pbBar.Step = 1;

            //FilesChangingHelper.ReplacementChar = '*';
            FilesPartialChangingHelper.PartialReplacementChar = '*';
            int i = 0;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            foreach (var item in files)
            {
                //FilesChangingHelper.ChangeFile(item);
                FilesPartialChangingHelper.file = item;
                ChangingThread = new Thread(new ThreadStart(FilesPartialChangingHelper.PartialChangeFile));
                ChangingThread.Start();
                pbBar.PerformStep();
                FilesListView.SetItemChecked(i++, value: true);
                CurrentFile.Text = item.FullName;
                Thread.Sleep(100);
            }

            watch.Stop();

            string message = $"Job is done. Program execution time: {watch.Elapsed}";
            MessageBox.Show(message, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Thread.Sleep(1000);
            pbBar.Value = 0;
        }
    }
}
