using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesChanger
{
    public class ButtonsBehaviourProcessor
    {
        private string pathToFiles;
        private ProgressBar pbBar;
        private CheckedListBox filesList;
        private Label currentFile;
        private FileInfo[] files;

        internal void Init(ProgressBar bar, CheckedListBox listBox, Label label)
        {
            pbBar = bar;
            filesList = listBox;
            currentFile = label;
        }

        private void FillInFilesList(CheckedListBox filesList)
        {
            DirectoryInfo di = new DirectoryInfo(pathToFiles);
            files = di.GetFiles("*", SearchOption.AllDirectories);
            int i = 0;
            foreach (var item in files)
            {
                filesList.Items.Insert(i++, item);
            }
        }

        internal void FillInListViewBox()
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    pathToFiles = folderBrowser.SelectedPath;
                    filesList.Items.Clear();
                    FillInFilesList(filesList);
                }
            }
        }

        private void CheckItemInList(ref int index)
        {
            filesList.SetItemChecked(index, value: true);
            currentFile.Text = $"Progress: {filesList.Items[index]}";
            index++;
        }

        private ProgressBar InitProgressBar(int min, int max, int step)
        {
            ProgressBar bar = pbBar;
            bar.Minimum = min;
            bar.Maximum = max;
            bar.Step = step;

            return bar;
        }

        private bool isItemChecked(FileInfo item)
        {
            int index = filesList.Items.IndexOf(item);

            if (filesList.GetItemChecked(index))
            {
                MessageBox.Show($"Checked item: {item}", "Check!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return true;
        }

        private void ProcessFiles()
        {
            FilesPartialChangingHelper.PartialReplacementChar = '*';
            int itemIndex = 0;
            foreach (var item in files)
            {
                //FilesPartialChangingHelper.PartialChangeFile(item);
                isItemChecked(item);
                pbBar.PerformStep();
                CheckItemInList(ref itemIndex);
            }
        }

        internal void ProcessStartButtonClick()
        {
            Stopwatch watch = new Stopwatch();
            pbBar = InitProgressBar(min: 0, max: files.Length, step: 1);

            watch.Start();
            ProcessFiles();
            watch.Stop();

            PrintExecutionMessage(watch.Elapsed);
            pbBar.Value = 0;
        }

        private void PrintExecutionMessage(TimeSpan time)
        {
            string message = $"Job is done. Program execution time: {time}";
            MessageBox.Show(message, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
