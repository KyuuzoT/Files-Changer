using FilesChanger.Components.ContentProcessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesChanger.Components
{
    public class LayoutBehaviourComponent
    {
        private string _pathToFiles;
        private ProgressBar _progressBar;
        private CheckedListBox _fileList;
        private Label _currentFileLabel;
        private CheckBox _renameCheckBox;
        private IEnumerable<FileInfo> _files;
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

        internal void InitializeUI(ProgressBar progressBar, CheckedListBox fileList, Label fileLabel, CheckBox renameCheckBox)
        {
            _progressBar = progressBar;
            _fileList = fileList;
            _currentFileLabel = fileLabel;
            _renameCheckBox = renameCheckBox;
        }

        internal void ConfirmRenameDeactivation()
        {
            if (!_renameCheckBox.Checked)
            {
                return;
            }

            const string message = "Переименование позволит надежнее затереть файлы. Вы уверены, что хотите отключить его?";
            var result = MessageBox.Show(message, "Отключить переименование", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _renameCheckBox.Checked = false;
            }
        }

        internal void SelectFolderAndPopulateFiles()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _pathToFiles = dialog.SelectedPath;
                _fileList.Items.Clear();
                LoadFileList();
            }
        }

        internal async Task ExecuteFileProcessingAsync()
        {
            if (_fileList.Items.Count == 0 || _fileList.CheckedItems.Count == 0)
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
            for (int i = 0; i < _fileList.Items.Count; i++)
            {
                if (_fileList.Items[i] == null)
                {
                    return;
                }

                bool isChecked = _fileList.GetItemChecked(i);
                _fileList.SetItemChecked(i, !isChecked);
            }
        }

        #region private methods
        private void LoadFileList()
        {
            var directory = new DirectoryInfo(_pathToFiles);
            _files = directory.GetFiles("*", _searchOption).OrderBy(f => f.CreationTime);

            int index = 0;
            foreach (var file in _files)
                _fileList.Items.Insert(index++, file);
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
            FilesPartialChangingComponent.PartialReplacementChar = '*';

            int index = 0;
            foreach (var file in _files)
            {
                _progressBar.PerformStep();

                if (IsFileChecked(file))
                {
                    await Task.Run(() => FilesPartialChangingComponent.PartialChangeFile(file));
                    _currentFileLabel.Text = $"Progress: {_fileList.Items[index]}";
                }

                index++;
            }

            if (_renameCheckBox.Checked)
            {
                RenameCheckedFiles();
            }
        }

        private bool IsFileChecked(FileInfo file)
        {
            int index = _fileList.Items.IndexOf(file);
            return _fileList.GetItemChecked(index);
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
            _fileList.Items.Clear();
            LoadFileList();
        }

        #endregion
    }
}