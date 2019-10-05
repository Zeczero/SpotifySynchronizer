using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifySynchronizer.Title;
using SpotifySynchronizer.Sync;
using System.IO;
using System.Diagnostics;

namespace SpotifySynchronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.Title = "SpotifySynchronizer by Zeczero";
            Titles titles = new Titles();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            titles.GetTitle("SpotifySynchronizer ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;

            titles.GetCredits();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("\tKilling Spotify ..");

            string[] spotifyPath = SyncSpotify.KillSpotifyProcess().ToArray();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\tOK");

            foreach (String spotifyDir in SyncSpotify.GetToProcess())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\tProcessing {spotifyDir}..");

                String userDir = Path.Combine(spotifyDir, "Users");
                DirectoryInfo usersDirs = new DirectoryInfo(userDir);

                foreach (var di in usersDirs.GetDirectories("*-user"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t --> Found user: {di.Name}");
                }
            }
            if (spotifyPath.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\tStarting Spotify ..");

                SyncSpotify.TurnOnSpotify();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("     OK");

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\tPress any key to exit ..");

                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
