using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_391___The_ABACABA_sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/njxq95/20210524_challenge_391_easy_the_abacaba_sequence/

            List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();

            string fString = string.Empty;
            for (int i = 0; i < 26; i++)         
                fString = fString + alphabet[i] + fString;

            File.WriteAllText("../../output.txt", fString);
        }
    }
}
