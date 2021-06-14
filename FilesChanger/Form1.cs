using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FilesChanger
{
    public partial class Form1 : Form
    {
        private ButtonsBehaviourProcessor buttons = new ButtonsBehaviourProcessor();

        public Form1()
        {
            InitializeComponent();
            buttons.Init(pbBar, FilesListView, CurrentFile);
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
            btnCheckAll.Text = btnCheckAll.Text.Equals("Check all") ? "Uncheck all" : "Check all";
        }
    }
}
