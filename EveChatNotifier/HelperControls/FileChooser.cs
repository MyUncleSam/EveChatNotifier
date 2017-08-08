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
    public partial class FileChooser : UserControl
    {
        private OpenFileDialog FileDialog { get; set; }

        public FileChooser()
        {
            Init();
        }

        public void Init()
        {
            InitializeComponent();
            FileDialog = new OpenFileDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FileDialog.ShowDialog() == DialogResult.OK)
            {
                if(FileDialog.CheckFileExists)
                {
                    tbFile.Text = FileDialog.FileName;
                }
                else
                {
                    tbFile.Text = "";
                }
            }
        }

        public string SelectedFile
        {
            get
            {
                return tbFile.Text;
            }
            set
            {
                FileDialog.FileName = value;
                tbFile.Text = value;
            }
        }

        private void FileChooser_Resize(object sender, EventArgs e)
        {
            int newTbWidth = this.Size.Width - btnChoose.Size.Width - 1 - 5;
            tbFile.Size = new Size(newTbWidth, tbFile.Height);

            btnChoose.Location = new Point(tbFile.Location.X + tbFile.Size.Width + 5);
        }
    }
}
