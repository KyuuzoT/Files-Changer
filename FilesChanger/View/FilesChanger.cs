using FilesChanger.Components;

namespace FilesChanger
{
    public partial class FilesChanger : Form
    {
        private readonly LayoutBehaviourComponent layout;

        public FilesChanger()
        {
            InitializeComponent();
            layout = new LayoutBehaviourComponent(pbBar, FilesListView, CurrentFile, cbRename);
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
                btnCheckAll.Text = "Select all";
                return;
            }

            btnCheckAll.Text = btnCheckAll.Text.Equals("Select all") ? "Deselect all" : "Select all";
        }

        private void cbRename_MouseDown(object sender, MouseEventArgs e)
        {
            layout.ConfirmRenameDeactivation();
        }

        private void rbTopDirectory_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = SearchOption.TopDirectoryOnly;
        }

        private void rbTopChildDirectories_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = SearchOption.AllDirectories;
        }
    }
}
