using FilesChanger.Components;
using FilesChanger.Localization;
using FilesChanger.Localization.Models;

namespace FilesChanger
{
    public partial class FilesChanger : Form
    {
        private readonly LayoutBehaviourComponent layout;
        private LocalizationHandler localizationHandler;
        private IEnumerable<LocalizedStringModel> LanguageStrings = [];

        public FilesChanger()
        {
            InitializeComponent();

            bLanguageEn.Enabled = false;
            localizationHandler = new LocalizationHandler(AvailableLanguages.English);
            LanguageStrings = [.. localizationHandler.GetLocalizedStrings()];

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

        private void EnLanguageButton_Click(object sender, EventArgs e)
        {
            localizationHandler = new LocalizationHandler("English");
            if(bLanguageEn.Enabled)
            {
                bLanguageEn.Enabled = false;
                LanguageStrings = [.. localizationHandler.GetLocalizedStrings()];
                bLanguageRu.Enabled = true;
            }
        }

        private void RuLanguageButton_Click(object sender, EventArgs e)
        {
            localizationHandler = new LocalizationHandler("Russian");
            if (bLanguageRu.Enabled)
            {
                bLanguageRu.Enabled = false;
                LanguageStrings = [.. localizationHandler.GetLocalizedStrings()];
                bLanguageEn.Enabled = true;
            }
        }
    }
}
