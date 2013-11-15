using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CavaPlugin
{
    class CavaPluginUpdater
    {
        private static readonly String SubPluginDir = Application.StartupPath + "\\Plugins\\CavaPlugin\\";
        private static WebClient _client;
        private static int _newestRev; 

        public static void WriteNewRevFile(string verfilename, string revvalue)
        {
            var file = new StreamWriter(@"" + SubPluginDir + verfilename);
            file.Write("$Revision: " + revvalue + " $");
            file.Close();
        }

        public static bool UpdateAvailable(string url, string namever)
        {
            return (GetNewestRev(url) > GetCurrentRev(namever));
        }

        public static int GetNewestRev(string url)
        {
            _client = new WebClient();
            var html = _client.DownloadString(url);
            var revisionMatch = Regex.Match(html, @"Revision ([A-Za-z0-9\-.]+):");
            if (revisionMatch.Success)
            {
                _newestRev = int.Parse(revisionMatch.Groups[1].Value);
                return _newestRev;
            }
            return 0;
        }

        public static int GetCurrentRev(string namever)
        {
            var verFile = new StreamReader(SubPluginDir + namever);
            var verString = verFile.ReadToEnd();
            verFile.Close();
            try
            {
                var currentRev = int.Parse(verString.Replace("$Revision: ", "").Replace(" $", ""));
                return currentRev;
            }
            catch
            {
                return 0;
            }
        }
    }
}

