using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Stopwatch stopwatch = Stopwatch.StartNew();

            Console.WriteLine("There is " + p(666) + " ways to calculate 666");

            stopwatch.Stop();
            Console.WriteLine("/\\ found in " + stopwatch.ElapsedMilliseconds + "ms\n");

            stopwatch.Restart();
            Console.WriteLine("There is " + p(6666) + " ways to calculate 6666");
            stopwatch.Stop();
            Console.WriteLine("/\\ found in " + stopwatch.ElapsedMilliseconds + "ms\n");
            stopwatch.Restart();
            Console.WriteLine("There is " + p(666666) + " ways to calculate 666666");
            stopwatch.Stop();
            Console.WriteLine("/\\ found in " + stopwatch.ElapsedMilliseconds + "ms\n");
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

            //List<CalculatorPos> posOfCalcul = new List<CalculatorPos>() { 
            //    new CalculatorPos(){pos = 1, isItPlus = true},
            //    new CalculatorPos(){pos = 2, isItPlus = true} 
            //};

            var posOfCalcul = new Dictionary<int, bool>();
            posOfCalcul.Add(1, true);
            posOfCalcul.Add(2, true);

            int lastKey = 2;
            bool lastBool = true; 
            bool lastBool2 = true;

            for (int i = 2; i < posOfCalcul_temp.Count; i++)
            {
                posOfCalcul.Add(

                    lastKey + posOfCalcul_temp[i - 1], lastBool == lastBool2 ? !lastBool : lastBool

                    );

                lastKey += posOfCalcul_temp[i - 1];

                if (lastBool == lastBool2)             
                    lastBool = !lastBool;                
                else              
                    lastBool2 = !lastBool2;
                
            }


            // ----------------- PARTITION NUMBER SEQUENCE CALCULATOR
            List <BigInteger> logicalSequence = new List<BigInteger>() { 1, 1 };

            for (int i = 2; i < v + 1; i++)
            {
                BigInteger nextInteger = 0;

                for (int a = 0; a < logicalSequence.Count; a++)
                {
                    bool isItPlus;


                    if(posOfCalcul.TryGetValue(a + 1, out isItPlus))

                        if (isItPlus)
                            nextInteger += logicalSequence[a];
                        else 
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
