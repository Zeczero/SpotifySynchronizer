using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SpotifySynchronizer.Sync
{
    class SyncSpotify
    {
        public static IEnumerable<string> KillSpotifyProcess()
        {
            foreach(var process in Process.GetProcessesByName("Spotify"))
            {
                yield return process.MainModule.FileName;

                if (process.CloseMainWindow())
                {
                    Thread.Sleep(200);
                    if (process.HasExited)
                    {
                        continue;
                    }
                }
                try
                {
                    process.Kill();
                }
                catch(Exception ex)
                {

                }
            }
        }

        public static string GetDirectory()
        {
            var getAppData = Environment.GetEnvironmentVariable("LocalAppData");
            var getSpotifyDir = Path.Combine(getAppData, "Spotify");
            if (!Directory.Exists(getSpotifyDir))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tNo Directory was found! Please make sure you have installed Spotify.");
                return null;
            }

            return getSpotifyDir;
        }
        public static List<string> GetToProcess()
        {
            List<string> dirsToProcess = new List<string>(2);
            string spoDir = GetDirectory();
            dirsToProcess.Add(spoDir);

            return dirsToProcess;
        }
        public static Process TurnOnSpotify()
        {
            Process myprocess = new Process();
            var appDir = Environment.GetEnvironmentVariable("AppData");
            var spotifyDir = Path.Combine(appDir, "Spotify");
            var SpotExe = Path.Combine(spotifyDir, "Spotify.exe");
            try
            {
                    myprocess.StartInfo.FileName = SpotExe;
                    myprocess.Start();
            }
            catch (Exception ex)
            {

            }
            return myprocess;
        }

    }
}
