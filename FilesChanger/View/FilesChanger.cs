using FilesChanger.Components;
using System;
using System.Windows.Forms;

namespace FilesChanger
{
    public partial class FilesChanger : Form
    {
        private readonly LayoutBehaviourComponent layout = new LayoutBehaviourComponent();

        public FilesChanger()
        {
            InitializeComponent();
            layout.InitializeUI(pbBar, FilesListView, CurrentFile, cbRename);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            layout.SelectFolderAndPopulateFiles();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await layout.ExecuteFileProcessingAsync();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            layout.ToggleAllItems();

            if (FilesListView.CheckedItems.Count == 0)
            {
                btnCheckAll.Text = "Выбрать все";
                return;
            }

            btnCheckAll.Text = btnCheckAll.Text.Equals("Выбрать все") ? "Снять все" : "Выбрать все";
        }

        private void cbRename_MouseDown(object sender, MouseEventArgs e)
        {
            layout.ConfirmRenameDeactivation();
        }

        private void rbTopDirectory_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = System.IO.SearchOption.TopDirectoryOnly;
        }

        private void rbTopChildDirectories_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = System.IO.SearchOption.AllDirectories;
        }
    }
}
