using AutoUpdaterDotNET;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace EveChatNotifier.Github
{
    public static class GithubUpdateCheck
    {
        private static WebClient wc = new WebClient();
        private static string releaseUrl = "https://github.com/{0}/{1}/releases";

        /// <summary>
        /// extracts the version information from github (version = tag) and create an AutoUpdate.NET compatible xml file for update procedure
        /// </summary>
        /// <param name="gitUserName"></param>
        /// <param name="repoName"></param>
        public static void UpdateUsingLocalXmlFile(string gitUserName, string repoName)
        {
            releaseUrl = string.Format(releaseUrl, gitUserName, repoName);

            try
            {
				// no idea why but we need to fallback to TSL1.2 in order to retrieve github information ...
				//ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
				//ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

				Uri reqUri = new Uri(string.Format(@"http://api.github.com/repos/{0}/{1}/releases/latest", gitUserName, repoName));

				RestClient client = new RestClient(@"https://api.github.com");
				RestRequest request = new RestRequest("repos/{username}/{reponame}/releases/latest", Method.GET);
				request.AddUrlSegment("username", gitUserName);
				request.AddUrlSegment("reponame", repoName);
				request.AddHeader("user-agent", repoName);
				request.RequestFormat = DataFormat.Json;
				request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();

				client.ExecuteAsync<GithubUpdater.GithubReleaseRestSharp>(request, (response) =>
				{
					if(response.IsSuccessful)
					{
						RestReleaseCheck(response.Data);
					}
					else
					{
						Logging.WriteLine(string.Format("Unable to start update procedure:{0}{1}", Environment.NewLine, response.ErrorMessage));
					}
				});
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to start async version check:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }

		/// <summary>
		/// RestSharp update detection
		/// </summary>
		/// <param name="release"></param>
		private static void RestReleaseCheck(GithubUpdater.GithubReleaseRestSharp release)
		{
			try
			{
				// generate update information object
				UpdaterXml.item update = new UpdaterXml.item();
				update.url = release.assets.Where(w => w.browser_download_url.EndsWith(".zip", StringComparison.OrdinalIgnoreCase)).First().browser_download_url;
				update.version = release.tag_name;
				update.changelog = releaseUrl;
				update.mandatory = false;

				// generate xml file
				string updateUrl = null;
				do
				{
					updateUrl = System.IO.Path.Combine(System.IO.Path.GetTempPath(), string.Format("{0}.xml", Guid.NewGuid().ToString("N")));
				} while (System.IO.File.Exists(updateUrl));

				// add file to cleanup job
				Cleanup.GetInstance().FilesToDelete.AddIfNotExist<string>(updateUrl);

				// serialize to file
				using (TextWriter writer = new StreamWriter(updateUrl, false))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(UpdaterXml.item));
					serializer.Serialize(writer, update);
					writer.Close();
				}

				// start update procedure
				if (Properties.Settings.Default.CheckForUpdates)
				{
					Logging.WriteLine("AutoUpdater feature enabled - checking for update in the background.");

					AutoUpdater.ShowRemindLaterButton = true;
					AutoUpdater.ReportErrors = false;
					AutoUpdater.Mandatory = false;
					AutoUpdater.ShowSkipButton = true;
					AutoUpdater.Start(updateUrl);
				}
			}
			catch(Exception ex)
			{
				Logging.WriteLine(string.Format("Unable to start update procedure:{0}{1}", Environment.NewLine, ex.ToString()));
			}
		}

		/// <summary>
		/// start auto update after download
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                GithubRelease release = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubRelease>(e.Result);

                // generate update information object
                UpdaterXml.item update = new UpdaterXml.item();
                update.url = release.assets.Where(w => w.browser_download_url.EndsWith(".zip", StringComparison.OrdinalIgnoreCase)).First().browser_download_url;
                update.version = release.tag_name;
                update.changelog = releaseUrl;
                update.mandatory = false;

                // generate xml file
                string updateUrl = null;
                do
                {
                    updateUrl = System.IO.Path.Combine(System.IO.Path.GetTempPath(), string.Format("{0}.xml", Guid.NewGuid().ToString("N")));
                } while (System.IO.File.Exists(updateUrl));

                // add file to cleanup job
                Cleanup.GetInstance().FilesToDelete.AddIfNotExist<string>(updateUrl);

                // serialize to file
                using (TextWriter writer = new StreamWriter(updateUrl, false))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UpdaterXml.item));
                    serializer.Serialize(writer, update);
                    writer.Close();
                }

                // start update procedure
                if (Properties.Settings.Default.CheckForUpdates)
                {
                    Logging.WriteLine("AutoUpdater feature enabled - checking for update in the background.");

                    AutoUpdater.ShowRemindLaterButton = true;
                    AutoUpdater.ReportErrors = false;
                    AutoUpdater.Mandatory = false;
                    AutoUpdater.ShowSkipButton = true;
                    AutoUpdater.Start(updateUrl);
                }

                // we cannot delete the xml file because we have no idea when the check is done by the auto updater
                //try
                //{
                //    System.IO.File.Delete(updateUrl);
                //}
                //catch { }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Unable to start update procedure:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }
    }
}
