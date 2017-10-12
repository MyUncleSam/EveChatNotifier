using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineParser.Arguments;
using CommandLineParser.Validation;
using System.IO;

namespace AutoUpdater
{
    public class AppArguments
    {
        public static AppArguments CurArguments = new AppArguments();

        [ValueArgument(typeof(string), 'd', AllowMultiple = false, Description = "Download path to zip file containing new ")]
        public string DownloadUrl;

        [FileArgument('e', AllowMultiple = false, Description = "Path to exe which should be called after update procedure.", FileMustExist = true, LongName = "exe", Optional = false)]
        public FileInfo StartPath;
    }
}
