using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EveChatNotifier
{
    public class LogFile
    {
        public string FilePath { get; private set; }
        public DateTime LastModified { get; set; }
        public HeaderInfo LogInfo { get; private set; }

        private Timer t = new Timer();
        private long _LastSize;

        public LogFile(string file)
        {
            FilePath = file;
            LogInfo = LogHeaderReader.GetLogObject(file);
            _LastSize = (new FileInfo(FilePath)).Length;

            t.Tick += T_Tick;
            t.Interval = Properties.Settings.Default.FileCheckInterval * 1000; // check all 2 seconds for new log entries
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();

            try
            {
                if(!System.IO.File.Exists(FilePath))
                {
                    Logging.WriteLine(string.Format("Logfile no longer exists. Removing file form watching: {0}", FilePath));
                    EveChatEventArgs eceh = new EveChatEventArgs(null);
                    RemovedLog(this, eceh);
                }

                FileInfo fi = new FileInfo(FilePath);
                long curLenght = fi.Length;
                if ((curLenght != _LastSize))
                {
                    // open file in read only mode
                    System.IO.FileStream fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                    fs.Seek(_LastSize - curLenght, System.IO.SeekOrigin.End); // jump to the last saved position
                    _LastSize = curLenght;

                    System.IO.StreamReader sr = new System.IO.StreamReader(fs, Encoding.UTF8, true, 512);

                    // start reading the last part (the one who was added)
                    // as we check every X seconds it could be more then one line per log file!
                    string changesStr = null;
                    while (!sr.EndOfStream)
                    {
                        if (changesStr == null)
                        {
                            changesStr = sr.ReadLine();
                        }
                        else
                        {
                            changesStr += string.Format("{0}{1}", Environment.NewLine, sr.ReadLine());
                        }
                    }

                    // fire our event with only changes
                    EveChatEventArgs args = new EveChatEventArgs(changesStr);
                    NewChatLines(this, args);
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to pare log file:{0}{1}", Environment.NewLine, ex.ToString()));
            }

            t.Start();
        }

        public class EveChatEventArgs : EventArgs
        {
            public string NewLogLines { get; private set; }

            public EveChatEventArgs(string changes)
            {
                NewLogLines = changes;
            }
        }

        public delegate void EveChatEventHandler(object sender, EveChatEventArgs e);
        public event EveChatEventHandler NewChatLines;
        public event EveChatEventHandler RemovedLog;
    }
}
