using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_378___The_Havel_Hakimi_algorithm_for_graph_realization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/bqy1cf/20190520_challenge_378_easy_the_havelhakimi/

            Console.WriteLine(anyoneLying(new List<int>() { 5, 3, 0, 2, 6, 2, 0, 7, 2, 5 }));
            Console.WriteLine(anyoneLying(new List<int>() { 4, 2, 0, 1, 5, 0 }));
            Console.WriteLine(anyoneLying(new List<int>() { 3, 1, 2, 3, 1, 0 }));
            Console.WriteLine(anyoneLying(new List<int>() { 16, 9, 9, 15, 9, 7, 9, 11, 17, 11, 4, 9, 12, 14, 14, 12, 17, 0, 3, 16 }));
            Console.WriteLine(anyoneLying(new List<int>() { 14, 10, 17, 13, 4, 8, 6, 7, 13, 13, 17, 18, 8, 17, 2, 14, 6, 4, 7, 12 }));
            Console.WriteLine(anyoneLying(new List<int>() { 15, 18, 6, 13, 12, 4, 4, 14, 1, 6, 18, 2, 6, 16, 0, 9, 10, 7, 12, 3 }));
            Console.WriteLine(anyoneLying(new List<int>() { 6, 0, 10, 10, 10, 5, 8, 3, 0, 14, 16, 2, 13, 1, 2, 13, 6, 15, 5, 1 }));
            Console.WriteLine(anyoneLying(new List<int>() { 2, 2, 0 }));
            Console.WriteLine(anyoneLying(new List<int>() { 3, 2, 1 }));
            Console.WriteLine(anyoneLying(new List<int>() { 1, 1 }));
            Console.WriteLine(anyoneLying(new List<int>() { 1 }));
            Console.WriteLine(anyoneLying(new List<int>() {}));
        }

        private static bool anyoneLying(List<int> list)
        {
            list.RemoveAll(x => x.Equals(0));

            if (!list.Any())
                return true;

            list = list.OrderByDescending(x => x).ToList();

            int n = list[0];
            list.RemoveAt(0);

            if (n <= list.Count)
            {
                for (int i = 0; i < n; i++)
                {
                    list[i] -= 1;
                }

                return anyoneLying(list);
            }
            else
                return false;
        }
    }
}
