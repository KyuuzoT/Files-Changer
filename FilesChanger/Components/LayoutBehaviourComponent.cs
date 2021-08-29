using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FilesChanger.Components
{
    public class LayoutBehaviourComponent
    {
        private string pathToFiles;
        private ProgressBar pbBar;
        private CheckedListBox filesList;
        private Label currentFile;
        private FileInfo[] files;
        private CheckBox renameFlag;

        internal void Init(ProgressBar bar, CheckedListBox listBox, Label label, CheckBox cbRename)
        {
            pbBar = bar;
            filesList = listBox;
            currentFile = label;
            renameFlag = cbRename;
        }

        private void FillInFilesList()
        {
            DirectoryInfo di = new DirectoryInfo(pathToFiles);
            files = di.GetFiles("*", SearchOption.AllDirectories);
            int i = 0;
            foreach (var item in files)
            {
                filesList.Items.Insert(i++, item);
            }
        }

        internal void ProcessRenameCheckBoxClick()
        {
            string message = "Переименование позволит надежнее затереть файлы. Вы уверены, что хотите отключить его?";
            if (renameFlag.Checked)
            {
                var result = MessageBox.Show(message, "Отключить переименование", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    renameFlag.Checked = false;
                    return;
                }
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
                    FillInFilesList();
                }
            }
        }

        private void CheckItemInList(ref int index)
        {
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

            return filesList.GetItemChecked(index);
        }

        private void ProcessFiles()
        {
            FilesPartialChangingHelper.PartialReplacementChar = '*';
            int itemIndex = 0;

            foreach (var item in files)
            {
                pbBar.PerformStep();
                if (isItemChecked(item))
                {
                    FilesPartialChangingHelper.PartialChangeFile(item);
                    CheckItemInList(ref itemIndex);
                }
            }

            if (renameFlag.Checked)
            {
                RenameFiles(files);
            }
        }

        private void RenameFiles(IEnumerable<FileInfo> files)
        {
            NameChangerComponent changer = new NameChangerComponent();
            changer.Power = 7;
            var checkedFiles = files.Where(x => isItemChecked(x)).ToList();
            changer.ProccessRenamingFiles(checkedFiles);
        }

        internal void ProcessStartButtonClick()
        {
            if (filesList.Items.Count > 0 && filesList.CheckedItems.Count > 0)
            {
                Stopwatch watch = new Stopwatch();
                pbBar = InitProgressBar(min: 0, max: files.Length, step: 1);

                watch.Start();
                ProcessFiles();
                watch.Stop();

                PrintExecutionMessage(watch.Elapsed);
                pbBar.Value = 0;
                filesList.Items.Clear();
                FillInFilesList();
            }
        }

        private void PrintExecutionMessage(TimeSpan time)
        {
            string message = $"Job is done. Program execution time: {time}";
            MessageBox.Show(message, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void CheckAllItems()
        {
            var localCopy = filesList.Items;
            for (int i = 0; i < localCopy.Count; i++)
            {
                if (localCopy[i] == null)
                {
                    return;
                }

                if (!filesList.GetItemChecked(i))
                {
                    filesList.SetItemChecked(i, true);
                }
                else
                {
                    filesList.SetItemChecked(i, false);
                }
            }
        }
    }
}
