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
        private static GithubRelease release = null;

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
                release = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubRelease>(e.Result);
                Version gitVersion = Version.Parse(release.tag_name);

                if(gitVersion > System.Reflection.Assembly.GetExecutingAssembly().GetName().Version)
                {
                    Logging.WriteLine(string.Format("New version found: {0}", release.tag_name));

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
                else
                {
                    Logging.WriteLine(string.Format("Your version {0} is up2date.", release.tag_name));
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to read version from return value:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }

        private static void Notifier_Click(object sender, EventArgs e)
        {
            ((PopupNotifier)sender).Hide();

            UpdateDialog ud = new UpdateDialog(release.body);
            ud.ShowDialog();

            if(ud.UserResult == UpdateDialog.UpdateEnum.OpenWebpage)
            {
                System.Diagnostics.Process.Start("https://github.com/MyUncleSam/EveChatNotifier");
            }
            else if(ud.UserResult == UpdateDialog.UpdateEnum.StartUpdate)
            {
                // start auto updater logic
                string downloadUrl = release.assets.First(f => System.IO.Path.GetExtension(f.name).Trim('.').Equals("zip", StringComparison.OrdinalIgnoreCase)).browser_download_url;
                string workingDirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = System.IO.Path.Combine(workingDirectory, "AutoUpdater.exe");
                psi.Arguments = string.Format("-d=\"{0}\" -e=\"{1}\"", downloadUrl, System.Windows.Forms.Application.ExecutablePath);
                Process proc = new Process();
                proc.StartInfo = psi;
                proc.Start();

                System.Windows.Forms.Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
