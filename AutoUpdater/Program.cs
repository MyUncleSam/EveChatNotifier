using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdater
{
    class Program
    {
        private static bool isWorking = true;
        private static int curTick = 0;

        static void Main(string[] args)
        {
            Environment.ExitCode = 0;

            CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
            parser.AcceptEqualSignSyntaxForValueArguments = true;
            parser.IgnoreCase = true;
            parser.AcceptSlash = true;
            parser.AllowShortSwitchGrouping = false;
            parser.ExtractArgumentAttributes(AppArguments.CurArguments);

            try
            {
                parser.ParseCommandLine(args);
            }
            catch (CommandLineParser.Exceptions.CommandLineArgumentException cle)
            {
                Console.WriteLine(string.Format("Invalid command line parameters: {0}", cle.Message));
                parser.ShowUsage();
                Environment.ExitCode = 1;
                return;
            }
            catch (CommandLineParser.Validation.ArgumentConflictException ace)
            {
                Console.WriteLine(string.Format("Invalid command line parameters: {0}", ace.Message));
                parser.ShowUsage();
                Environment.ExitCode = 1;
                return;
            }

            if (!parser.ParsingSucceeded)
            {
                Environment.ExitCode = 1;
                return;
            }

            if(!AppArguments.CurArguments.DownloadUrl.StartsWith(Properties.Settings.Default.PathStartsWith, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(string.Format("SECURITY BREACH:{0}{0}Download path seems to be not a valid download path. Please contact the author of this software!", Environment.NewLine));
                Console.WriteLine();
                Console.WriteLine("Press any key to exit the program.");
                Console.Read();
                Environment.ExitCode = 2;
                return;
            }

            Console.Write("Waiting for EveChatNotifier to finish close process ... ");
            while(System.Diagnostics.Process.GetProcessesByName("EveChatNotifier").Any())
            {
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine("done");

            Console.WriteLine(string.Format("Downloading update from '{0}':", AppArguments.CurArguments.DownloadUrl));
            Console.WriteLine();
            Console.WriteLine("Progress:");
            Console.Write("|");
            Console.Write(new String('-', 98));
            Console.WriteLine("|");

            WebClientEx downloadCLient = Download.StartDownloadZip(AppArguments.CurArguments.DownloadUrl);
            downloadCLient.DownloadProgressChanged += DownloadCLient_DownloadProgressChanged;
            downloadCLient.DownloadFileCompleted += DownloadCLient_DownloadFileCompleted;

            // wait till update procedure finished
            while(isWorking) { }
        }

        private static void DownloadCLient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine();

            WebClientEx wce = (WebClientEx)sender;
            Console.WriteLine("Download finished - extracting files ...");

            try
            {
                ZipLogic.ExtractToDirectory(wce.LastDownloadSaveTarget, AppArguments.CurArguments.StartPath.Directory.FullName, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error extracting files:{0}{1}", Environment.NewLine, ex.ToString()));
                Console.WriteLine();
                Console.WriteLine("Press any key to exit.");
                Console.Read();
                Environment.ExitCode = 3;

                isWorking = false;
                return;
            }

            // launch program again
            try
            {
                Console.WriteLine();
                Console.WriteLine("Update finished successfully. Starting updated application ...");
                System.Threading.Thread.Sleep(2000);

                System.Diagnostics.Process.Start(AppArguments.CurArguments.StartPath.FullName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Unable to launch startup application '{0}':{1}{2}", AppArguments.CurArguments.StartPath, Environment.NewLine, ex.ToString()));
                Console.WriteLine();
                Console.WriteLine("Press any key to exit the program.");
                Console.Read();
                Environment.ExitCode = 4;
            }

            isWorking = false;
        }

        /// <summary>
        /// progressbar for download process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DownloadCLient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            while (curTick < e.ProgressPercentage)
            {
                curTick++;
                Console.Write("+");
            }
        }
    }
}
