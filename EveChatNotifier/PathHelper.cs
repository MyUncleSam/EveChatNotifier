using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EveChatNotifier
{
    public static class PathHelper
    {
        public static Dictionary<string, string> KnownPaths = new Dictionary<string, string>()
        {
            { "%EXEPATH%", System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) },
            { "%MY_DOCUMENTS%", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) },
            { "%MY_MUSIC%", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) },
            { "%MY_PICTURES%", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) },
            { "%MY_VIDEOS", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) },
            { "%PROGRAM_DATA%", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) },
            { "%APPDATA_LOCAL%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) },
            { "%DESKTOP%", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) },
            { "%USERPATH%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) },
            { "%DEFAULT_EVELOGPATH%", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"EVE\logs\Chatlogs") },
            { "%DEFAULT_EVEOLDPATH%", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"EVE\logs\Chatlogs\old") }
        };
        
        /// <summary>
        /// remove place holders with real paths
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string DecryptPath(string path)
        {
            foreach (KeyValuePair<string, string> entry in KnownPaths)
            {
                path = path.Replace(entry.Key, entry.Value);
            }

            return path;
        }

        /// <summary>
        /// replace path beginning with place holder (longest wins)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string EncryptedPath(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            List<KeyValuePair<string, string>> matches = KnownPaths.Where(w => path.StartsWith(w.Value, StringComparison.OrdinalIgnoreCase)).ToList();

            if (matches.Count <= 0)
            {
                return path;
            }

            KeyValuePair<string, string> match = matches.OrderByDescending(o => o.Value.Length).First();
            return Regex.Replace(path, Regex.Escape(match.Value), Regex.Escape(match.Key), RegexOptions.IgnoreCase);
        }
    }
}
