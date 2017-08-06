using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EveChatNotifier
{
    public static class LogHeaderReader
    {
        public static HeaderInfo GetLogObject(string filePath)
        {
            string headerInfo = GetHeaderFromFile(filePath);

            HeaderInfo retInfo = new HeaderInfo();
            StringReader sr = new StringReader(headerInfo);

            string curLine = null;
            while((curLine = sr.ReadLine()) != null)
            {
                curLine = curLine.Trim();
                if(curLine.Length <= 0 || !curLine.Contains(":"))
                {
                    continue;
                }

                // get position of first ":"
                int splitterPos = curLine.IndexOf(':');

                string key = curLine.Substring(0, splitterPos).Trim();
                string value = curLine.Substring(splitterPos + 1).Trim();

                if(key.Equals("Channel ID", StringComparison.OrdinalIgnoreCase))
                {
                    retInfo.ChannelId = value;
                }
                if(key.Equals("Channel Name", StringComparison.OrdinalIgnoreCase))
                {
                    retInfo.ChannelName = value;
                }
                if(key.Equals("Listener", StringComparison.OrdinalIgnoreCase))
                {
                    retInfo.PilotName = value;
                }
                if(key.Equals("Session started", StringComparison.OrdinalIgnoreCase))
                {
                    DateTime sessTime;
                    if(DateTime.TryParse(value, out sessTime))
                    {
                        retInfo.SessionDate = sessTime;
                    }
                }
            }

            return retInfo;
        }

        public static string GetHeaderFromFile(string filePath)
        {
            FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sReader = new StreamReader(fStream, Encoding.UTF8, true, 512);

            string retString = "";
            string curLine = null;
            while ((curLine = sReader.ReadLine()) != null && !curLine.StartsWith("["))
            {
                curLine = curLine.Trim();

                if(string.IsNullOrWhiteSpace(curLine))
                {
                    continue;
                }

                if(retString == null)
                {
                    retString = curLine;
                }
                else
                {
                    retString += string.Format("{0}{1}", Environment.NewLine, curLine);
                }
            }

            return retString;
        }
    }

    public class HeaderInfo
    {
        public string ChannelName { get; set; }
        public string PilotName { get; set; }
        public DateTime SessionDate { get; set; }
        public string ChannelId { get; set; }
    }
}
