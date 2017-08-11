using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveChatNotifier
{
    public static class Logging
    {
        private static string logPath = PathHelper.DecryptPath(Properties.Settings.Default.LogFile);

        public static void WriteLine(string text)
        {
            if(!Properties.Settings.Default.EnableLogging)
            {
                return;
            }

            try
            {
                System.IO.File.AppendAllText(logPath, string.Format("{0}: {1}{2}", DateTime.Now.ToString(), text, Environment.NewLine), Encoding.UTF8);
            }
            catch { }
        }
    }
}
