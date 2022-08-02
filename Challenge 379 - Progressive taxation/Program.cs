using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_379___Progressive_taxation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/cdieag/20190715_challenge_379_easy_progressive_taxation/

            Console.WriteLine(tax(0));
            Console.WriteLine(tax(10000));
            Console.WriteLine(tax(10009));
            Console.WriteLine(tax(10010));
            Console.WriteLine(tax(12000));
            Console.WriteLine(tax(56789));
            Console.WriteLine(tax(1234567));

            Console.WriteLine("\n\n Bonus :");
            Console.WriteLine(overall(0.00));
            Console.WriteLine(overall(0.06));
            Console.WriteLine(overall(0.09));
            Console.WriteLine(overall(0.32));
            Console.WriteLine(overall(0.40));
        }

        private static int overall(double v)
        {
            // 256250
            // taxe : 82000
            //    t = tax(256250)
            // OU
            //    t = v * i

            for (int i = 1; i < 300_000_000; i++)
            {
                double t = tax(i);

                if ((double)v * (double)i == t)
                    return i;
            }

            return -1;
        }

        private static double tax(int v)
        {
            if (v <= 10_000)
                return 0;
            else if(v > 10_000 && v <= 30_000)
            {
                return ((double)(v - 10_000) * 0.1);
            }
            else if(v > 30_000 && v < 100_000)
            {
                return ((double)20_000 * 0.1) + ((double)(v - 30_000) * 0.25);
            }
            else if(v > 100_000)
            {
                return ((double)20_000 * 0.1) + ((double)70_000 * 0.25) + (double)(v - 100_000) * 0.40;
            }

            return -1;
        }
    }
}
