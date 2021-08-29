using FilesChanger.Components;
using System;
using System.Windows.Forms;

namespace FilesChanger
{
    public partial class FilesChanger : Form
    {
        private LayoutBehaviourComponent buttons = new LayoutBehaviourComponent();

        public FilesChanger()
        {
            InitializeComponent();
            buttons.Init(pbBar, FilesListView, CurrentFile, cbRename);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            buttons.FillInListViewBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttons.ProcessStartButtonClick();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            buttons.CheckAllItems();
            btnCheckAll.Text = btnCheckAll.Text.Equals("Выбрать все") ? "Снять все" : "Выбрать все";
        }

        private void cbRename_MouseDown(object sender, MouseEventArgs e)
        {
            buttons.ProcessRenameCheckBoxClick();
        }
    }
}
