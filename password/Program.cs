using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bruteforce
{
    class Program
    {
        public const string alphabet = "0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        public const string password = "alina";
        public static bool hacked = false;

        public static void BruteForce(string characters, int numOfCharacters)
        {
            if (numOfCharacters < 1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (characters+alphabet[i] == password)
                    {
                        hacked = true;
                    }
                }
            }
            if (numOfCharacters >= 1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    BruteForce(characters + alphabet[i], numOfCharacters - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Password for brute = {password}; Proccessing...");
            Console.CursorVisible = true;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Parallel.For(0, 6, i => {
                BruteForce("", i);
                if (hacked == true)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine("Hacked in " + elapsedTime);
                }
            });
        }
    }
}
