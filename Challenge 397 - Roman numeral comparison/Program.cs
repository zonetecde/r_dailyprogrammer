using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_397___Roman_numeral_comparison
{
    internal class Program
    {
        internal static List<string> romans = new List<string> {

                "M1000",
                "D500",
                "C100",
                "L50",
                "X10",
                "V5",
                "I1",
            };

        static void Main(string[] args)
        {
            Console.WriteLine(numCompare("I", "I"));
            Console.WriteLine(numCompare("I", "II"));
            Console.WriteLine(numCompare("II", "I"));
            Console.WriteLine(numCompare("V", "IIII"));
            Console.WriteLine(numCompare("MDCLXV", "MDCLXVI"));
            Console.WriteLine(numCompare("MM", "MDCCCCLXXXXVIIII"));
        }

        private static bool numCompare(string v1, string v2)
        {
            //Console.Write(v1 + " - " + v2 + " = ");

            int s1 = 0;
            int s2 = 0;
            v1.ToCharArray().ToList().ForEach(x => { s1 += Convert.ToInt32(romans.Find(y => y.Contains(x)).Remove(0, 1)); });
            v2.ToCharArray().ToList().ForEach(x => { s2 += Convert.ToInt32(romans.Find(y => y.Contains(x)).Remove(0, 1)); });
            
            return s1 < s2;
        }
    }
}
