using FilesChanger.Components.ContentProcessing;
using System.Diagnostics;
using System.Text;

namespace FilesChanger.Components
{
    public class LayoutBehaviourComponent(
        ProgressBar progressBar,
        CheckedListBox filesList,
        Label currentFileName,
        CheckBox isRenameEnabled)
    {
        private string filesPath = string.Empty;
        private ProgressBar _progressBar = progressBar;
        private IEnumerable<FileInfo> _files = [];
        private SearchOption _searchOption;

        internal IEnumerable<FileInfo> Files
        {
            get => _files;
            set => _files = value;
        }

        internal SearchOption DirectoryOptions
        {
            get => _searchOption;
            set => _searchOption = value;
        }

        internal void ConfirmRenameDeactivation()
        {
            if (!isRenameEnabled.Checked)
            {
                return;
            }

            const string message = "Renaming will make your files less recognizable. Are you sure you want to turn it off?";
            var result = MessageBox.Show(message, "Turn off renaming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                isRenameEnabled.Checked = false;
            }
        }

        internal void SelectFolderAndPopulateFiles()
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            filesPath = dialog.SelectedPath;
            filesList.Items.Clear();
            LoadFileList();
        }

        internal async Task ExecuteFileProcessingAsync()
        {
            if (filesList.Items.Count == 0 || filesList.CheckedItems.Count == 0)
            {
                return;
            }

            _progressBar = SetupProgressBar(0, _files.Count(), 1);

            var watch = Stopwatch.StartNew();
            await ProcessFilesAsync();
            watch.Stop();

            ShowCompletionMessage(watch.Elapsed);
            ResetUI();
        }

        internal void ToggleAllItems()
        {
            for (int i = 0; i < filesList.Items.Count; i++)
            {
                if (filesList.Items[i] == null)
                {
                    return;
                }

                bool isChecked = filesList.GetItemChecked(i);
                filesList.SetItemChecked(i, !isChecked);
            }
        }

        #region private methods
        private void LoadFileList()
        {
            var directory = new DirectoryInfo(filesPath);
            _files = directory.GetFiles("*", _searchOption).OrderBy(f => f.CreationTime);

            int index = 0;
            foreach (var file in _files)
                filesList.Items.Insert(index++, file);
        }

        private ProgressBar SetupProgressBar(int min, int max, int step)
        {
            _progressBar.Minimum = min;
            _progressBar.Maximum = max;
            _progressBar.Step = step;
            return _progressBar;
        }

        private async Task ProcessFilesAsync()
        {
            //FilesPartialChangingComponent.PartialReplacementChar = '*';

            int index = 0;
            foreach (var file in _files)
            {
                _progressBar.PerformStep();

                if (IsFileChecked(file))
                {
                    await Task.Run(() => 
                    {
                        using var processor = new FilePartialProcessor('*', Encoding.UTF8);
                        processor.ProcessFile(file);
                    });
                    currentFileName.Text = $"Progress: {filesList.Items[index]}";
                }

                index++;
            }

            if (isRenameEnabled.Checked)
            {
                RenameCheckedFiles();
            }
        }

        private bool IsFileChecked(FileInfo file)
        {
            int index = filesList.Items.IndexOf(file);
            return filesList.GetItemChecked(index);
        }

        private void RenameCheckedFiles()
        {
            var changer = new NameChangerComponent { Power = 7 };
            var selectedFiles = _files.Where(IsFileChecked).ToList();
            changer.ProccessRenamingFiles(selectedFiles);
        }

        private void ShowCompletionMessage(TimeSpan duration)
        {
            string msg = $"Job is done. Program execution time: {duration}";
            MessageBox.Show(msg, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetUI()
        {
            _progressBar.Value = 0;
            filesList.Items.Clear();
            LoadFileList();
        }

        #endregion
    }
}