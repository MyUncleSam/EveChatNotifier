using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EveChatNotifier
{
    public static class LogReader
    {
        private static Regex _GetLogEntryRegex = null;

        /// <summary>
        /// extract information from one entry!
        /// </summary>
        /// <param name="logLine"></param>
        /// <returns></returns>
        public static LogEntry GetLogEntry(string logLine)
        {
            if(_GetLogEntryRegex == null)
            {
                _GetLogEntryRegex = new Regex(Properties.Settings.Default.ChatEntryRegex, RegexOptions.Compiled | RegexOptions.Singleline);
            }

            LogEntry retEntry = new LogEntry();

            if(Properties.Settings.Default.UseRegex)
            {
                Match regMatch = _GetLogEntryRegex.Match(logLine);
                if (regMatch.Success)
                {
                    string sendDateStr = regMatch.Groups["senddate"].Value;
                    string sender = regMatch.Groups["sender"].Value;
                    string sendText = regMatch.Groups["text"].Value;

                    DateTime sendDate;
                    if (DateTime.TryParse(sendDateStr, out sendDate))
                    {
                        retEntry.SendDate = sendDate;
                    }
                    retEntry.Sender = sender;
                    retEntry.Text = sendText;
                }
            }
            else
            {
                // string acrobatic
                if(logLine.Contains("[") && logLine.Contains("]") && logLine.Contains(">"))
                {
                    int startDate = logLine.IndexOf("[");
                    int endDateStartSender = logLine.IndexOf("]");
                    int endSenderStartText = logLine.IndexOf(">");

                    string sendDateStr = logLine.Substring(startDate + 1, endDateStartSender - (startDate + 1)).Trim();
                    string sender = logLine.Substring(endDateStartSender + 1, endSenderStartText - (endDateStartSender + 1)).Trim();
                    string sendText = logLine.Substring(endSenderStartText + 1).Trim();

                    DateTime sendDate;
                    if(DateTime.TryParse(sendDateStr, out sendDate))
                    {
                        retEntry.SendDate = sendDate;
                    }
                    retEntry.Sender = sender;
                    retEntry.Text = sendText;
                }
            }

            return retEntry;
        }
    }

    public class LogEntry
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
    }
}
