using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_393___Making_change
{
    internal class Program
    {
        private static int[] currency = new int[] { 500, 100, 25, 10, 5, 1 };

        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/nucsik/20210607_challenge_393_easy_making_change/

            Console.WriteLine("0 = " + Change(0));
            Console.WriteLine("12 = " + Change(12));
            Console.WriteLine("468 = " + Change(468));
            Console.WriteLine("123456 = " + Change(123456));
        }

        private static int Change(int v)
        {
            int t = 0;

            while(v > 0)
            {
                for (int i = 0; i < currency.Count(); i++)
                    if (v >= currency[i])
                    {
                        v -= currency[i];
                        t++;
                        break;
                    }
            }

            return t;
        }
    }
}
