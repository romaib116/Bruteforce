using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Bruteforce
{
    class Program
    {
        public const string variables = "0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";


        public static void BruteForce(string symbols, int numOfSymbols)
        {
            if (numOfSymbols < 1)
            {
                for (int i = 0; i < variables.Length; i++)
                {
                    Console.WriteLine(symbols + variables[i]);
                }
            }
            if (numOfSymbols >= 1)
            {
                for (int i = 0; i < variables.Length; i++)
                {
                    BruteForce(symbols + variables[i], numOfSymbols - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                BruteForce("", i);
            }
        }
    }
}
