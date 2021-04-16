using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bruteforce
{
    class Program
    {
        public const string alphabet = "0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private static string _password;
        private static bool _hacked;
        private static Stopwatch _timer;

        /// <summary>
        /// Алгоритм перебора
        /// </summary>
        /// <param name="currentString"> с какой последовательности начинается перебор </param>
        /// <param name="numOfCharacters"> длина перебираемой строки </param>
        public static void BruteForce(string currentString, int numOfCharacters)
        {
            if (numOfCharacters < 1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (currentString + alphabet[i] == _password)
                    {
                        _hacked = true;
                    }
                }
            }
            if (numOfCharacters >= 1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    BruteForce(currentString + alphabet[i], numOfCharacters - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            InitConsole();

            Console.WriteLine("Enter password for brute: ");
            _password = Console.ReadLine();
            StartProcess();
            //6 поточная обработка 
            Parallel.For(0, 6, i => 
            {
                BruteForce(string.Empty, i);
                if (_hacked == true)
                    FinishProcess();
            });
        }


        /// <summary>
        /// Делаем атмосферную cmd
        /// </summary>
        static void InitConsole()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Bruteforce";
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Запускаем таймер
        /// </summary>
        static void StartProcess()
        {
            Console.WriteLine($"Proccessing...");
            _timer = new Stopwatch();
            _timer.Start();
        }

        /// <summary>
        /// Подсчет времени затраченного для перебора
        /// </summary>
        static void FinishProcess()
        {
            _timer.Stop();
            TimeSpan ts = _timer.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            Console.WriteLine($"{_password} hacked in " + elapsedTime);
        }
    }
}
