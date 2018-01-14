using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdater
{
    public static class ZipLogic
    {
        /// <summary>
        /// files which should be ignored / not overwritten
        /// </summary>
        public static readonly List<string> FilesNotOverwrite = new List<string>()
        {
            "log.txt",
            "AutoUpdater.exe"
        };

        /// <summary>
        /// extract all entries to a given folder (ignores files specified in FilesNotOverwrite)
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFolder"></param>
        /// <param name="overwrite"></param>
        public static void ExtractToDirectory(string sourceFile, string destinationFolder, bool overwrite)
        {
            ZipFile zf = new ZipFile(sourceFile);
            bool hasError = false;
            
            foreach (ZipEntry ze in zf)
            {
                string fileName = System.IO.Path.GetFileName(ze.FileName).Trim('.').ToLower();

                try
                {
                    if (FilesNotOverwrite.Any(a => a.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    ExtractExistingFileAction eefa = ExtractExistingFileAction.DoNotOverwrite;
                    if (overwrite)
                    {
                        eefa = ExtractExistingFileAction.OverwriteSilently;
                    }
                    ze.Extract(destinationFolder, eefa);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(string.Format("Unable to extract {0}: {1}", System.IO.Path.GetFileName(fileName), ex.Message));
                    hasError = true;
                }
            }

            if(hasError)
            {
                Console.WriteLine();
                Console.WriteLine("There where errors during the extraction process. If the software is not running as intended please do a manual upgrade!");
            }
        }
    }
}
