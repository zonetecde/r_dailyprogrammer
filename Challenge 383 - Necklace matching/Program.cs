using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_383___Necklace_matching
{
    internal class Program
    {
        private static List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
        private static List<string> words = File.ReadAllLines("../../words.txt").ToList();
        private static List<string> wordsNecklaced = File.ReadAllLines("../../words.txt").ToList();

        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/ffxabb/20200309_challenge_383_easy_necklace_matching/

            Console.WriteLine("Challenge");
            Console.WriteLine(sameNecklace("nicole", "icolen"));
            Console.WriteLine(sameNecklace("nicole", "lenico"));
            Console.WriteLine(sameNecklace("nicole", "coneli"));
            Console.WriteLine(sameNecklace("aabaaaaabaab", "aabaabaabaaa"));
            Console.WriteLine(sameNecklace("abc", "cba"));
            Console.WriteLine(sameNecklace("xxyyy", "xxxyy"));
            Console.WriteLine(sameNecklace("xyxxz", "xxyxz"));
            Console.WriteLine(sameNecklace("x", "x"));
            Console.WriteLine(sameNecklace("x", "xx"));
            Console.WriteLine(sameNecklace("x", ""));
            Console.WriteLine(sameNecklace("", ""));

            Console.WriteLine("\n\nOptional Bonus 1");
            Console.WriteLine(repeats("abc"));
            Console.WriteLine(repeats("abcabcabc") );
            Console.WriteLine(repeats("abcabcabcx"));
            Console.WriteLine(repeats("aaaaaa")) ;
            Console.WriteLine(repeats("a"));
            Console.WriteLine(repeats("")) ;

            Console.WriteLine("\n\nOptional Bonus 2");
            findSameNecklace();
            
        }

        private static void findSameNecklace()
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i][0] == 'a')
                    continue ;

                char firstLetter = 'z';

                for (int z = 0; z < words[i].Length; z++)                
                    if (alphabet.IndexOf(firstLetter) > alphabet.IndexOf(words[i][z]))
                        firstLetter = alphabet[alphabet.IndexOf(words[i][z])];

                for (int y = 0; y < wordsNecklaced[i].Length; y++)
                {
                    wordsNecklaced[i] += wordsNecklaced[i][0];
                    wordsNecklaced[i] = wordsNecklaced[i].Remove(0, 1);
                    if (wordsNecklaced[i][0] == firstLetter)
                        break;
                }
            }

            
            List<nclass> objet = new List<nclass>();

            for (int i = 0; i < wordsNecklaced.Count; i++)
                if (objet.Exists(x => x.Necklace == wordsNecklaced[i]))
                    objet.Find(x => x.Necklace == wordsNecklaced[i]).Index.Add(i);
                else
                    objet.Add(new nclass()
                    {
                        Index = new List<int>(),
                        Necklace = wordsNecklaced[i]
                    });

            objet.OrderByDescending(x => x.Index.Count).ToList().ForEach(x =>
            {
                if(x.Index.Count > 1)
                {
                    Console.WriteLine(x.Index.Count + " : " + x.Necklace);
                }
            });


        }

        internal class nclass
        {
            internal string Necklace { get; set; }
            internal List<int> Index { get; set; }
        }

        private static int repeats(string v)
        {
            int t = v.Length == 0 ? 1 : 0;
            string v1 = v;

            for (int i = 0; i < v.Length; i++)
            {
                v1 += v1[0];
                v1 = v1.Remove(0, 1);
                if (v == v1)
                    t++;
            }

            return t;
        }

        private static bool sameNecklace(string v1, string v2)
        {
            if (v1.Length != v2.Length) return false;

            for (int i = 0; i < v1.Length; i++)
            {
                v1 += v1[0];
                v1 = v1.Remove(0, 1);
                if (v1 == v2) return true;
            }
            return false;
        }
    }
}
