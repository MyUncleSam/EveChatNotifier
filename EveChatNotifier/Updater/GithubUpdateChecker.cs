using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Tulpep.NotificationWindow;

namespace EveChatNotifier.Updater
{
    public static class GithubUpdateChecker
    {
        private static WebClient wc = new WebClient();
        private static string releasePage = null;

        /// <summary>
        /// retrieves the 
        /// </summary>
        /// <returns></returns>
        public static void VersionCheckasync(string gitUserName, string repoName)
        {
            try
            {
                wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
                wc.Headers.Add("user-agent", repoName);
                wc.DownloadStringAsync(new Uri(string.Format(@"https://api.github.com/repos/{0}/{1}/releases/latest", gitUserName, repoName)));
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to start async version check:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }

        private static void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                GithubRelease release = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubRelease>(e.Result);
                Version gitVersion = Version.Parse(release.tag_name);

                if(gitVersion > System.Reflection.Assembly.GetExecutingAssembly().GetName().Version)
                {
                    // we have a new version
                    releasePage = release.html_url;

                    //List<string> attachments = new List<string>();

                    //foreach (Asset att in release.assets)
                    //{
                    //    attachments.Add(att.browser_download_url);
                    //}

                    // show popup in the setted colors
                    PopupNotifier Notifier = new PopupNotifier();
                    Notifier.IsRightToLeft = false;
                    Notifier.ShowCloseButton = true;
                    Notifier.ShowGrip = false;
                    Notifier.Image = Properties.Resources.eve_logo_landing2;

                    Notifier.Delay = Properties.Settings.Default.ToastDelay > 20000 ? Properties.Settings.Default.ToastDelay : 20000;
                    Notifier.AnimationDuration = 500;

                    Notifier.BodyColor = Properties.Settings.Default.ToastBodyColor;
                    Notifier.BorderColor = Properties.Settings.Default.ToastBorderColor;
                    Notifier.ContentColor = Properties.Settings.Default.ToastContentColor;
                    Notifier.ContentHoverColor = Properties.Settings.Default.ToastContentHoverColor;
                    Notifier.HeaderColor = Properties.Settings.Default.ToastHeaderColor;
                    Notifier.TitleColor = Properties.Settings.Default.ToastTitleColor;

                    Notifier.Click += Notifier_Click;

                    Notifier.TitleText = string.Format("New version found: {0}", release.tag_name);
                    Notifier.ContentText = string.Format("Click to update:{0}{1}", Environment.NewLine, release.body);
                    Notifier.Popup();
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to read version from return value:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }

        private static void Notifier_Click(object sender, EventArgs e)
        {
            // do basic checking if it is a webpage link
            Uri releaseUri = new Uri(releasePage);
            if(string.IsNullOrWhiteSpace(releaseUri.Scheme) || !releaseUri.Scheme.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                Logging.WriteLine(string.Format("Update release page seems to be invalid (non http scheme): {0}", releasePage));
                System.Windows.Forms.MessageBox.Show("Opening the release page was blocked for security reasons. Please take a look into the log file!", "Blocked for security reasons", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                Process.Start(GetBrowserPath(), releasePage);
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to open default browser - opening webpage by executing webpage url:{0}{1}", Environment.NewLine, ex.ToString()));
                Process.Start(releasePage);
            }

            ((PopupNotifier)sender).Hide();
        }

        private static string GetBrowserPath()
        {
            string key = @"http\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }
    }
}
