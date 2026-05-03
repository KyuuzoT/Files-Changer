using FilesChanger.Components;
using FilesChanger.Localization;
using FilesChanger.Localization.Models;

namespace FilesChanger
{
    public partial class FilesChanger : Form
    {
        private readonly LayoutBehaviourComponent layout;
        private LocalizationHandler localizationHandler;

        public FilesChanger()
        {
            InitializeComponent();

            bLanguageEn.Enabled = false;
            localizationHandler = new LocalizationHandler(AvailableLanguages.English);

            layout = new LayoutBehaviourComponent(pbBar, FilesListView, CurrentFile, cbRename);
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            layout.SelectFolderAndPopulateFiles();
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            await layout.ExecuteFileProcessingAsync();
        }

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            layout.ToggleAllItems();
            var initialText = localizationHandler.GetElement(nameof(btnCheckAll)).TextMain;
            var variantText = localizationHandler.GetElement(nameof(btnCheckAll)).TextVariants?.FirstOrDefault();

            if (FilesListView.CheckedItems.Count == 0)
            {
                //btnCheckAll.Text = "Select all";
                btnCheckAll.Text = initialText;
                // TODO: Come up with mechanism that will ensure Refresh() on all localized elements
                // as soon as the language button pressed!
                Refresh();
                return;
            }

            btnCheckAll.Text = 
                btnCheckAll.Text.Equals(initialText) && !string.IsNullOrEmpty(variantText) ?
                variantText : 
                initialText;
            Refresh();
        }

        private void CbRename_MouseDown(object sender, MouseEventArgs e)
        {
            layout.ConfirmRenameDeactivation();
        }

        private void RbTopDirectory_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = SearchOption.TopDirectoryOnly;
        }

        private void RbTopChildDirectories_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = SearchOption.AllDirectories;
        }

        private void EnLanguageButton_Click(object sender, EventArgs e)
        {
            localizationHandler = new LocalizationHandler("English");
            if(bLanguageEn.Enabled)
            {
                bLanguageEn.Enabled = false;
                bLanguageRu.Enabled = true;
            }
        }

        private void RuLanguageButton_Click(object sender, EventArgs e)
        {
            localizationHandler = new LocalizationHandler("Russian");
            if (bLanguageRu.Enabled)
            {
                bLanguageRu.Enabled = false;
                bLanguageEn.Enabled = true;
            }
        }
    }
}
