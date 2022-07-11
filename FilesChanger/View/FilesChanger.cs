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

        private void btnPath_Click(object sender, EventArgs e)
        {
            layout.FillInListViewBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            layout.ProcessStartButtonClick();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            layout.CheckAllItems();
            if (FilesListView.CheckedItems.Count == 0)
            {
                btnCheckAll.Text = "Выбрать все";
                return;
            }
            btnCheckAll.Text = btnCheckAll.Text.Equals("Выбрать все") ? "Снять все" : "Выбрать все";
        }

        private void cbRename_MouseDown(object sender, MouseEventArgs e)
        {
            layout.ProcessRenameCheckBoxClick();
        }

        private void rbTopDirectory_CheckedChanged(object sender, EventArgs e)
        {
            //Cherry-pick
            layout.DirectoryOptions = System.IO.SearchOption.TopDirectoryOnly;
        }

        private void rbTopChildDirectories_CheckedChanged(object sender, EventArgs e)
        {
            layout.DirectoryOptions = System.IO.SearchOption.AllDirectories;
        }
    }
}
