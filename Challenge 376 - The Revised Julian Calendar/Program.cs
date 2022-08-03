using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_376___The_Revised_Julian_Calendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/b0nuoh/20190313_challenge_376_intermediate_the_revised/

            Console.WriteLine(howManyLeapYears(2016, 2017));
            Console.WriteLine(howManyLeapYears(2019, 2020));
            Console.WriteLine(howManyLeapYears(1900, 1901));
            Console.WriteLine(howManyLeapYears(2000, 2001));
            Console.WriteLine(howManyLeapYears(123456, 123456));
            Console.WriteLine(howManyLeapYears(1234, 5678));
            Console.WriteLine(howManyLeapYears(123456, 7891011));
            Console.WriteLine(howManyLeapYears(123456789101112, 1314151617181920));
        }

        private static long howManyLeapYears(long v1, long v2)
        {
            long total = 0;

            if (v2 - v1 >= 900)
            {
                long y = v2 - v1;

                v1 += (y / 900) * 900;
                total += (y / 900) * 218;
            }

            for (long i = v1; i < v2; i++)
            {
                if (i % 900 == 200 || i % 900 == 600)
                    total++;
                else if (((double)i / (double)100) % 1 != 0 &&
                    ((double)i / (double)4) % 1 == 0)
                {
                    total++;
                }
            }
            

            return total;
        }
    }
}
