using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EveChatNotifier.Updater
{
    public partial class UpdateDialog : Form
    {
        public UpdateEnum UserResult { get; private set; }

        public UpdateDialog(string message)
        {
            InitializeComponent();
            tbUpdateMessage.Text = message;
            UserResult = UpdateEnum.None;
        }

        private void btnOpenPage_Click(object sender, EventArgs e)
        {
            UserResult = UpdateEnum.OpenWebpage;
            this.Close();
        }

        private void btnStartUpdate_Click(object sender, EventArgs e)
        {
            UserResult = UpdateEnum.StartUpdate;
            this.Close();
        }

        public enum UpdateEnum
        {
            None,
            OpenWebpage,
            StartUpdate
        }
    }
}
