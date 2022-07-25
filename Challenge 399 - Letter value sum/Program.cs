using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_399___Letter_value_sum
{
    internal class Program
    {
        public static List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
        public static List<string> words = File.ReadAllLines(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..")) + "\\word list.txt").ToList();

        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/

            Console.WriteLine("Assign every lowercase letter a value, from 1 for a to 26 for z. Given a string of lowercase letters, find the sum of the values of the letters in the string.\n");

            Console.WriteLine("microspectrophotometries" + " = " + LetterSum("microspectrophotometries"));
            Console.WriteLine("excellent" + " = " + LetterSum("excellent"));
            Console.WriteLine("cab" + " = " + LetterSum("cab"));
            Console.WriteLine("z" + " = " + LetterSum("z"));
            Console.WriteLine("a" + " = " + LetterSum("a"));
            Console.WriteLine(" " + " = " + LetterSum(" "));

            Console.WriteLine("\n\n1. microspectrophotometries is the only word with a letter sum of 317. Find the only word with a letter sum of 319.");

            Console.WriteLine("Answer : " + words.FirstOrDefault(x => LetterSum(x) == 319));

            Console.WriteLine("\n\n2. How many words have an odd letter sum?");

            Console.WriteLine("Answer : " + words.FindAll(x => LetterSum(x) % 2 != 0).Count());

            Console.WriteLine("\n\n3. There are 1921 words with a letter sum of 100, making it the second most common letter sum. What letter sum is most common, and how many words have it?");

            List<LetterSumWords> lsw = new List<LetterSumWords>(); // Contient chaque somme de lettre existant avec la liste des mots possédant cette somme
            words.ForEach(x =>
            {
                int sumOfWord = LetterSum(x);
                if (lsw.Exists(y => y.Sum == sumOfWord))
                    lsw.First(z => z.Sum == sumOfWord).Words.Add(x);
                else
                    lsw.Add(new LetterSumWords { Sum = sumOfWord, Words = new List<string>() { x } });
            });

            lsw = lsw.OrderByDescending(x => x.Words.Count).ToList();
            Console.WriteLine("Answer : " + lsw[0].Sum + " with " + lsw[0].Words.Count + " words.");

            Console.WriteLine("\n\n4. zyzzyva and biodegradabilities have the same letter sum as each other (151), and their lengths differ by 11 letters. Find the other pair of words with the same letter sum whose lengths differ by 11 letters.");
            lsw.ForEach(x =>
            {
                x.Words.ForEach(first_word =>
                {
                    x.Words.GetRange(x.Words.IndexOf(first_word), x.Words.Count - x.Words.IndexOf(first_word)).ForEach(second_word =>
                    {
                        if (Math.Abs(second_word.Length - first_word.Length) == 11)
                            Console.WriteLine("Sum : " + x.Sum + " | " + first_word + " and " + second_word);
                    });
                });
            });

            Console.WriteLine("\n\n5. cytotoxicity and unreservedness have the same letter sum as each other (188), and they have no letters in common. Find a pair of words that have no letters in common, and that have the same letter sum, which is larger than 188. (There are two such pairs, and one word appears in both pairs.)");
            lsw.FindAll(c => c.Sum > 188).ForEach(x =>
            {
                x.Words.ForEach(first_word =>
                {
                    x.Words.GetRange(x.Words.IndexOf(first_word), x.Words.Count - x.Words.IndexOf(first_word)).ForEach(second_word =>
                    {
                        bool passTest = true;

                        first_word.ToCharArray()
                         .ToList()
                         .ForEach(letter_first_word => { second_word.ToCharArray()
                             .ToList()
                             .ForEach(letter_second_word => 
                                { if (letter_first_word == letter_second_word) { passTest = false; } } // une lettre a été trouvé en commun (v et b)
                        );});

                        if (passTest)
                            Console.WriteLine("Sum : " + x.Sum + " | " + first_word + " and " + second_word);
                    });
                });
            });

            Console.WriteLine("\n\n6. The list of word { geographically, eavesdropper, woodworker, oxymorons } contains 4 words. Each word in the list has both a different number of letters, and a different letter sum. The list is sorted both in descending order of word length, and ascending order of letter sum. What's the longest such list you can find?");
            // mot le plus grand à la plus petit somme
            List<List<string>> q6_Answers = new List<List<string>>();

            for (int i = 0; i < lsw.Count; i++)
            {
                List<string> possibleAnswer = new List<string>();

                lsw.OrderBy(x => x.Sum).ToList().GetRange(i, lsw.Count - i).ForEach(y => // de la plus petite somme à la plus grande somme
                {
                    // on cherche le mot le plus grand
                    if (possibleAnswer.Count == 0)
                        possibleAnswer.Add(y.Words.OrderByDescending(z => z.Length).First());
                    else if (y.Words.OrderByDescending(z => z.Length).First().Length < possibleAnswer.Last().Length)
                        possibleAnswer.Add(y.Words.OrderByDescending(z => z.Length).First());
                });

                q6_Answers.Add(possibleAnswer);
            }


            Console.WriteLine("{ " + String.Join(", ", q6_Answers.OrderByDescending(x => x.Count).ToList()[0].ToArray()) + " }");

            Console.ReadKey();

            int LetterSum(string str)
            {
                int sum = 0;
                str.ToList().ForEach(x => { sum += alphabet.IndexOf(x) + 1; });
                return sum;
            }
        }

        internal class LetterSumWords
        {
            internal int Sum { get; set; }
            internal List<string> Words { get; set; }
        }
    }
}
