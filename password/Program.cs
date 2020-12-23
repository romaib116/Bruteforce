using System;

namespace Bruteforce
{
    class Program
    {
        public const string alphabet = "0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        public static void BruteForce(string characters, int numOfCharacters)
        {
            if (numOfCharacters < 1)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    Console.WriteLine(characters + alphabet[i]);
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
            for (int i = 0; i < 6; i++)
            {
                BruteForce("", i);
            }
        }
    }
}
