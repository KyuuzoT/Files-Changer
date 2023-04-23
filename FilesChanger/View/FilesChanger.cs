using FilesChanger.Components;
using System;
using System.Windows.Forms;

namespace FilesChanger
{
    public partial class FilesChanger : Form
    {
        private LayoutBehaviourComponent layout = new LayoutBehaviourComponent();

        public FilesChanger()
        {
            InitializeComponent();
            layout.Init(pbBar, FilesListView, CurrentFile, cbRename);
        }

        private async void btnPath_Click(object sender, EventArgs e)
        {
            layout.FillInListViewBox();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await layout.ProcessStartButtonClick();
        }

        private async void btnCheckAll_Click(object sender, EventArgs e)
        {
            layout.CheckAllItems();
            if (FilesListView.CheckedItems.Count == 0)
            {
                btnCheckAll.Text = "Выбрать все";
                return;
            }
            btnCheckAll.Text = btnCheckAll.Text.Equals("Выбрать все") ? "Снять все" : "Выбрать все";
        }

        private async void cbRename_MouseDown(object sender, MouseEventArgs e)
        {
            layout.ProcessRenameCheckBoxClick();
        }

        private async void rbTopDirectory_CheckedChanged(object sender, EventArgs e)
        {
            //Cherry-pick
            layout.DirectoryOptions = System.IO.SearchOption.TopDirectoryOnly;
        }

        private async void rbTopChildDirectories_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = System.IO.SearchOption.AllDirectories;
        }
    }
}
