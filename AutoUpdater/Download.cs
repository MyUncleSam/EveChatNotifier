using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdater
{
    public static class Download
    {
        /// <summary>
        /// downloads a given zip file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebClientEx StartDownloadZip(string url)
        {
            Uri downloadUri = new Uri(url);
            string fileName = string.Format("{0}.downloadtmp", Guid.NewGuid().ToString());
            
            if(System.IO.Path.HasExtension(downloadUri.AbsolutePath))
            {
                fileName = System.IO.Path.GetFileName(downloadUri.AbsolutePath);
            }
            string targetPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), string.Format("{0}-{1}", Guid.NewGuid().ToString("D"), fileName));

            WebClientEx wc = new WebClientEx();
            wc.Headers.Add("user-agent", "AutoUpdater");
            wc.DownloadFileAsync(downloadUri, targetPath); // dowload sync - no benefit
            wc.LastDownloadUri = downloadUri;
            wc.LastDownloadSaveTarget = targetPath;
            return wc;
        }
    }

    public class WebClientEx : WebClient
    {
        public Uri LastDownloadUri { get; set; }
        public string LastDownloadSaveTarget { get; set; }
    }

}
