using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EveChatNotifier.HelperControls
{
    public partial class FolderChooser : UserControl
    {
        private FolderBrowserDialog FolderDialog { get; set; }

        public FolderChooser()
        {
            Init();
        }
       
        public void Init()
        {
            InitializeComponent();
            FolderDialog = new FolderBrowserDialog();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if(FolderDialog.ShowDialog() == DialogResult.OK)
            {
                if(System.IO.Directory.Exists(FolderDialog.SelectedPath))
                {
                    tbFolder.Text = FolderDialog.SelectedPath;
                }
                else
                {
                    tbFolder.Text = "";
                }
            }
        }

        public string SelectedFolder
        {
            get
            {
                if(FolderDialog.SelectedPath != null)
                {
                    if(System.IO.Directory.Exists(FolderDialog.SelectedPath))
                    {
                        return FolderDialog.SelectedPath;
                    }
                }

                return "";
            }
            set
            {
                FolderDialog.SelectedPath = value;
                tbFolder.Text = value;
            }
        }

        private void FolderChooser_Resize(object sender, EventArgs e)
        {
            int newTbWidth = this.Size.Width - btnChoose.Size.Width - 1 - 5;
            tbFolder.Size = new Size(newTbWidth, tbFolder.Height);

            btnChoose.Location = new Point(tbFolder.Location.X + tbFolder.Size.Width + 5);
        }
    }
}
