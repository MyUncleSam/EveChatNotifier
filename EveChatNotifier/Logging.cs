using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveChatNotifier
{
    public static class Logging
    {
        private static string logPath = null;

        public static void WriteLine(string text)
        {
            if(logPath == null)
            {
                string exePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                logPath = Properties.Settings.Default.LogFile.Replace("%EXEPATH%", exePath);
            }

            try
            {
                System.IO.File.AppendAllText(logPath, string.Format("{0}: {1}{2}", DateTime.Now.ToString(), text, Environment.NewLine), Encoding.UTF8);
            }
            catch { }
        }
    }
}
