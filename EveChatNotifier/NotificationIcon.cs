using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EveChatNotifier
{
    public class NotificationIcon
    {
        private static NotificationIcon _Instance = null;
        private Icon DefaultIcon = Properties.Resources.preferences_desktop_notification_bell;

        private NotificationIcon() { }

        public static NotificationIcon GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new NotificationIcon();
            }
            return _Instance;
        }

        /// <summary>
        /// gets the default icon
        /// </summary>
        /// <returns></returns>
        public Icon GetIcon()
        {
            return GetIcon(0);
        }

        /// <summary>
        /// writes a text at the default icon and returns it
        /// </summary>
        /// <param name="messageCount"></param>
        /// <returns></returns>
        public Icon GetIcon(int messageCount)
        {
            if(messageCount <= 0)
            {
                return DefaultIcon;
            }

            return WriteMissingText(messageCount);
        }

        /// <summary>
        /// writes a text to the icon and returns it
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private Icon WriteMissingText(int count)
        {
            Brush b = new SolidBrush(Color.White);
            Bitmap bmp = new Bitmap(DefaultIcon.ToBitmap());
            Graphics g = Graphics.FromImage(bmp);

            TextRenderer.DrawText(g, count.ToString(), new Font(SystemFonts.DefaultFont.FontFamily, bmp.Height * 0.7F, FontStyle.Bold), new Rectangle(0, 0, bmp.Width, bmp.Height), Color.White, Color.Transparent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.GlyphOverhangPadding);

            IntPtr hIcon = bmp.GetHicon();
            Icon i = Icon.FromHandle(hIcon);
            return i;
        }
    }
}
