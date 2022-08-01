using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_380___Smooshed_Morse_Code_2
{
    internal class Program
    {
        private static List<string> morseAlphabet = ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..".Split(' ').ToList();
        private static List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
        private static Random random = new Random();
        private static List<string> morsealphabetList = File.ReadAllLines(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..")) + "\\morsealphabet.txt").ToList();

        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/cn6gz5/20190807_challenge_380_intermediate_smooshed/

            Console.WriteLine(smalpha(".--...-.-.-.....-.--........----.-.-..---.---.--.--.-.-....-..-...-.---..--.----.."));
            Console.WriteLine(smalpha(".----...---.-....--.-........-----....--.-..-.-..--.--...--..-.---.--..-.-...--..-"));
            Console.WriteLine(smalpha("..-...-..-....--.---.---.---..-..--....-.....-..-.--.-.-.--.-..--.--..--.----..-.."));

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            List<string> output = new List<string>();
            for (int i = 0; i < morsealphabetList.Count; i++)
            {
                output.Add(smalpha(morsealphabetList[i]));
            }

            watch.Stop();

            Console.WriteLine(String.Join(" , ", output));
            Console.WriteLine($"^ The 1000 last one executed in : {watch.ElapsedMilliseconds} ms");
        }

        private static string smalpha(string v)
        {
            int i = 0;

            string alphabetFinal = string.Empty;
            int currentIndex = 0;

            AGAIN:
            while(alphabetFinal.Length < 26)
            {
                string nextLetter = morseAlphabet[random.Next(0, morseAlphabet.Count)];

                if (currentIndex + nextLetter.Length <= v.Length)
                {
                    if (!alphabetFinal.Contains(alphabet[morseAlphabet.IndexOf(nextLetter)]))
                    {
                        alphabetFinal += alphabet[morseAlphabet.IndexOf(nextLetter)];
                        currentIndex += nextLetter.Length;
                    }
                    else
                        i++;
                }

                if (i == 1000 && alphabetFinal.Length < 26)
                    goto AGAIN;
            }

            return alphabetFinal;
        }
    }
}
