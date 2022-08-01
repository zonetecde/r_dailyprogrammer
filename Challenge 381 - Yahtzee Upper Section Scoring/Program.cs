using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_381___Yahtzee_Upper_Section_Scoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/dv0231/20191111_challenge_381_easy_yahtzee_upper_section/
            var watch = new System.Diagnostics.Stopwatch();

            List<int> numbersChallenge = File.ReadAllLines("../../yahtzee-upper-1.txt").Select(int.Parse).ToList();

            Console.WriteLine(yahtzeeUppernew(new List<int>() { 2, 3, 5, 5, 6 }));
            Console.WriteLine(yahtzeeUppernew(new List<int>() { 1, 1, 1, 1, 3 }));
            Console.WriteLine(yahtzeeUppernew(new List<int>() { 1, 1, 1, 3, 3 }));
            Console.WriteLine(yahtzeeUppernew(new List<int>() { 1, 2, 3, 4, 5 }));
            Console.WriteLine(yahtzeeUppernew(new List<int>() { 6, 6, 6, 6, 6 }));
            Console.WriteLine(yahtzeeUppernew(new List<int>() { 1654, 1654, 50995, 30864, 1654, 50995, 22747, 1654, 1654, 1654, 1654, 1654, 30864, 4868, 1654, 4868, 1654, 30864, 4868, 30864 }));

            watch.Start();
            Console.Write(yahtzeeUppernew(numbersChallenge));
            watch.Stop();

            Console.Write($" - Execution Time: {watch.ElapsedMilliseconds} ms\n");

        }

        private static int yahtzeeUppernew (List<int> v)
        {
            return v.GroupBy(i => i).ToList().ConvertAll(x => x.Key * x.Count()).Max();
        }
    }
}
