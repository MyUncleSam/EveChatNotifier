using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EveChatNotifier.Updater
{
    public static class GithubUpdateChecker
    {
        private static WebClient wc = new WebClient();

        /// <summary>
        /// retrieves the 
        /// </summary>
        /// <returns></returns>
        public static void VersionCheckasync(string gitUserName, string repoName)
        {
            try
            {
                //HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(string.Format(@"https://api.github.com/repos/{0}/{1}/releases/latest", gitUserName, repoName));
                //wr.ContentType = "text/plain";
                //wr.Timeout = System.Threading.Timeout.Infinite;
                //wr.Method = "GET";
                //wr.Accept = "text/plain";

                //HttpWebResponse resp = (HttpWebResponse)wr.GetResponse();

                wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
                wc.Headers.Add("user-agent", repoName);
                wc.DownloadStringAsync(new Uri(string.Format(@"https://api.github.com/repos/{0}/{1}/releases/latest", gitUserName, repoName)));




                //WebRequest wr = WebRequest.Create(string.Format(@"https://api.github.com/repos/{0}/{1}/releases/latest", gitUserName, repoName));
                //wr.ContentType = "text/plain";
                //wr.Timeout = System.Threading.Timeout.Infinite;
                //wr.Method = "GET";
                //WebResponse resp = wr.GetResponse();
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
                    string webPath = release.html_url;

                    List<string> attachments = new List<string>();

                    foreach (Asset att in release.assets)
                    {
                        attachments.Add(att.browser_download_url);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to read version from return value:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }
    }
}
