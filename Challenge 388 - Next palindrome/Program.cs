using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_388___Next_palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/n3var6/20210503_challenge_388_intermediate_next/

            Console.WriteLine("808 : " + nextPal(808));
            Console.WriteLine("999 : " + nextPal(999));
            Console.WriteLine("2133 : " + nextPal(2133));
        }

        private static int nextPal(int v)
        {
            while(true)
            {
                v++;
                bool passed = true;
                char[] l = v.ToString().ToCharArray();
                
                for (int i = 0; i < l.Length / 2; i++)
                {
                    if (!(l.Length % 2 == 1 && i == l.Length / 2))
                        if (l[i] != l[l.Length - i - 1])
                            passed = false;
                }
                if (passed)              
                    return v;
                
            }
        }
    }
}
