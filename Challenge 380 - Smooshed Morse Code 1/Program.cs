using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_380___Smooshed_Morse_Code_1
{

    internal class Program
    {
        private static List<string> morseAlphabet = ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..".Split(' ').ToList();
        private static List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
        private static List<string> words = File.ReadAllLines(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..")) + "\\word list.txt").ToList();
        private static List<string> wordsMorse = words.ConvertAll(x => smorse(x));
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine(smorse("sos"));
            Console.WriteLine(smorse("daily"));
            Console.WriteLine(smorse("programmer"));
            Console.WriteLine(smorse("bits"));
            Console.WriteLine(smorse("three"));

            Console.WriteLine("\n\nOptional bonus challenges");

            Console.WriteLine("1. " + Bonus1());
            Console.WriteLine("2. " + Bonus2());
            Console.WriteLine("3. " + Bonus3());
            Console.WriteLine("4. " + Bonus4());
            Console.WriteLine("4. " + Bonus5());



        }


        private static string Bonus5()
        {
            List<string> find = new List<string>();
            List<string> morse13lengthOrMore = wordsMorse.FindAll(x => x.Length >= 13);

            // foreach wordmorse on change premiere [0] puis 1 puis 2 etc jusqu'à unic word puis on essaye le deuxieme mot etc


            while (find.Count < 5)
            {
                string word = string.Empty;
                while(word.Length < 13)
                {
                    string nextL = morseAlphabet[random.Next(0, morseAlphabet.Count)];

                    if (word.Length + nextL.Length <= 13)
                        word += nextL;
                    else
                        continue;
                }

                bool passed = true;

                morse13lengthOrMore.ForEach(x =>
                {
                    if (x.Contains(word))
                        passed = false;
                });

                if(passed)
                    find.Add(word);
            }

            return "{ " + String.Join(" , ", find) + " }";
        }

        private static string Bonus4()
        {
            for (int i = 0; i < wordsMorse.Count; i++)
            {
                
                if (words[i].Length == 13)
                {
                    bool passed = true;
                    char[] l = wordsMorse[i].ToCharArray();

                    for (int z = 0; z < l.Length / 2; z++)
                    {
                        if (!(l.Length % 2 == 1 && z == l.Length / 2))
                            if (l[z] != l[l.Length - z - 1])
                                passed = false;
                    }

                    if (passed)
                        return wordsMorse[i] + "(" + words[i] + ")";
                    }
                
            }            

            return String.Empty;
        }

        private static string Bonus2()
        {
            for (int x = 0; x < wordsMorse.Count; x++)
            {
                List<char> c = wordsMorse[x].ToList();
                int consecutiveDash = 0;

                foreach (char y in c)           
                    if (y == '-' && consecutiveDash != 15)
                        consecutiveDash++;
                    else if(consecutiveDash != 15)
                        consecutiveDash = 0;
                    else             
                        return wordsMorse[x] + " (" + words[x] + ")";                                                           
            }
            return string.Empty;
        }

        private static string Bonus3()
        {
            for(int i = 0; i < wordsMorse.Count; i++)
                if(words[i].Length == 21 && words[i] != "counterdemonstrations")
                    if (wordsMorse[i].ToList().Count(v => v == '-') == wordsMorse[i].ToList().Count(v => v == '.'))
                        return wordsMorse[i] + " (" + words[i] + ")";
            

            return String.Empty;
        }

        private static string Bonus1()
        {
            return wordsMorse.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                                                    .Select(grp => grp.Key).First();
        }

        private static string smorse(string v)
        {
            string morse = string.Empty;
            v.ToList().ForEach(x => { morse += morseAlphabet[alphabet.IndexOf(x)]; });
            return morse;
        }
    }   
}
