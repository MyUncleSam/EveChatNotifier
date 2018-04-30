using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EveChatNotifier
{
    public partial class ShowAllNotifications : Form
    {
        public ShowAllNotifications()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.preferences_desktop_notification_bell;
        }
    }
}
