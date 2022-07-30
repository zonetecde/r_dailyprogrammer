using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_387___Caesar_cipher
{
    internal class Program
    {
        private static List<char> alphabet = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz".ToList();
        private static List<int> alphabetScore = new List<int>() { 3,-1,1,1,4,0,0,2,2,-5,-2,1,0,2,3,0,-6,2,2,3,1,-1,0,-5,0,-7};

        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/myx3wn/20210426_challenge_387_easy_caesar_cipher/

            Console.WriteLine("Warmup : ");
            Console.WriteLine(warmup('a', 0));
            Console.WriteLine(warmup('a', 1));
            Console.WriteLine(warmup('a', 5));
            Console.WriteLine(warmup('a', 26));
            Console.WriteLine(warmup('d', 15));
            Console.WriteLine(warmup('z', 1));
            Console.WriteLine(warmup('q', 22));

            Console.WriteLine("\nChallenge : ");
            Console.WriteLine(caesar("a", 1));
            Console.WriteLine(caesar("abcz", 1));
            Console.WriteLine(caesar("irk", 13));
            Console.WriteLine(caesar("fusion", 6));
            Console.WriteLine(caesar("dailyprogrammer", 6));
            Console.WriteLine(caesar("jgorevxumxgsskx", 20));

            Console.WriteLine("\nBonus : ");
            Console.WriteLine(caesar("Daily Programmer!", 6));

            Console.WriteLine("\nBonus 2 : ");
            Console.WriteLine(findKeyAndDecrypt("Zol abyulk tl puav h ulda."));
            Console.WriteLine(findKeyAndDecrypt("Tfdv ef wlikyvi, wfi uvrky rnrzkj pfl rcc nzky erjkp, szx, gfzekp kvvky."));
            Console.WriteLine(findKeyAndDecrypt("Qv wzlmz bw uiqvbiqv iqz-axmml dmtwkqbg, i aeittwe vmmla bw jmib qba eqvoa nwzbg-bpzmm bquma mdmzg amkwvl, zqopb?"));

        }

        private static string findKeyAndDecrypt(string text)
        {
            double[] scores = new double[27];

            for (int i = 0; i <= 26; i++) // teste de toute les clés possible
            {
                string output = caesar(text, i); // décryptage avec la clé
                output.ToList().ForEach(x =>
                {
                    if (!(alphabet.Exists(y => y == Char.ToLower(x))))        
                        output = output.Replace(x, ' ');
                });
                output = output.Replace(" ", string.Empty);

                scores[i] = output.Average(x =>
                    alphabetScore[
                        alphabet.IndexOf(Char.ToLower(x)) // sometimes it is outofindex but I want it continue without crashing 
                    ]);
            }

            return caesar(text, scores.ToList().IndexOf(scores.Max()) );
        }

        private static string caesar(string text, int key)
        {
            if (key > 26) key -= 26;

            return new string(text.ToList().Select(x =>  warmup(x, key)).ToArray());
        }

        private static char warmup(char letter, int pos)
        {
            if (!alphabet.Exists(x => x == letter)) // Si la lettre n'est pas dans l'alphabet 
                if (alphabet.Exists(x => x == Char.ToLower(letter))) // Si la lettre était juste en majuscule
                    return Char.ToUpper(alphabet[alphabet.IndexOf(Char.ToLower(letter)) + pos]); // Retour de la lettre en majuscule et avec caesar  
                else               
                    return letter; // Caractère spéciaux
                           
            return alphabet[alphabet.IndexOf(letter) + pos]; // Si la lettre est dans l'alphabet
        }
    }
}
