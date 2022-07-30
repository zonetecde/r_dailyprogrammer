using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_386___Partition_counts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.reddit.com/r/dailyprogrammer/comments/jfcuz5/20201021_challenge_386_intermediate_partition/

            Console.WriteLine("There is " + p(666) + " ways to calculate 666");
            Console.WriteLine("There is " + p(6666) + " ways to calculate 6666");
        }

        private static BigInteger p(int v)
        {
            // --------------- CALCUL DE LA SUITE LOGIQUE POUR ADDITION/SOUSTRACTION
            List<int> posOfCalcul_temp = new List<int>() { 1, 3 };

            for (int i = 3; i <= v; i++)         
                if(i%2 == 1)               
                    posOfCalcul_temp.Add(posOfCalcul_temp[posOfCalcul_temp .Count - 2] + 1);               
                else               
                    posOfCalcul_temp.Add(posOfCalcul_temp[posOfCalcul_temp.Count - 2] + 2);
                          
            List<CalculatorPos> posOfCalcul = new List<CalculatorPos>() { 
                new CalculatorPos(){pos = 1, isItPlus = true},
                new CalculatorPos(){pos = 2, isItPlus = true} 
            };

            for (int i = 2; i < posOfCalcul_temp.Count; i++)         
                posOfCalcul.Add(new CalculatorPos()
                {
                    pos = posOfCalcul[i - 1].pos + posOfCalcul_temp[i - 1],
                    isItPlus = posOfCalcul[i - 1].isItPlus == posOfCalcul[i - 2].isItPlus ? !posOfCalcul[i - 1].isItPlus : posOfCalcul[i - 1].isItPlus
                });
            
            // ----------------- PARTITION NUMBER SEQUENCE CALCULATOR
            List<BigInteger> logicalSequence = new List<BigInteger>() { 1, 1 };

            for (int i = 2; i < v + 1; i++)
            {
                BigInteger nextInteger = 0;

                for (int a = 0; a < logicalSequence.Count; a++)
                {
                    var z = posOfCalcul.Find(x => x.pos - 1 == a) ?? new CalculatorPos() { pos = -1, isItPlus = true }; 

                    if (z.isItPlus && z.pos != -1)
                        nextInteger += logicalSequence[a];
                    else if(z.pos != -1)
                        nextInteger -= logicalSequence[a];
                }
                                  
                logicalSequence.Insert(0, nextInteger);
            }

            return logicalSequence.First();
        }
    }

    internal class CalculatorPos
    {
        internal int pos { get; set; }
        internal bool isItPlus { get; set; }
    }
}
