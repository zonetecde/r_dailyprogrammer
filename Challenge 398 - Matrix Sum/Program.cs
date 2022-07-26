using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_398___Matrix_Sum
{
    internal class Program
    {
        // [Y; X]
        public static int[,] matrix_5x5 = StringToMatrix(File.ReadAllLines(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..")) + "\\matrix_5x5.txt"));
        public static int[,] matrix_20x20 = StringToMatrix(File.ReadAllLines(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..")) + "\\matrix_20x20.txt"));
        public static int[,] matrix_97x97 = StringToMatrix(File.ReadAllLines(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..")) + "\\matrix_97x97.txt"));

        private static int[,] StringToMatrix(string[] stringMatrix)
        {
            int[,] matrix = new int[stringMatrix[0].Split(' ').Count(), stringMatrix.Count()];

            for (int x = 0; x < stringMatrix[0].Split(' ').Count(); x++)
            {
                for (int y = 0; y < stringMatrix.Count(); y++)
                {
                    matrix[y, x] = Convert.ToInt32(stringMatrix[y].Split(' ')[x]);
                }
            }

            return matrix;
        }

        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/oirb5v/20210712_challenge_398_difficult_matrix_sum/

            Console.WriteLine("5x5 matrix min sum :");
            Console.WriteLine(MinSum(matrix_5x5));
            Console.WriteLine("\n\n20x20 matrix min sum :");
            Console.WriteLine(MinSum(matrix_20x20));
            Console.WriteLine("\n\n97x97 matrix min sum :");
            Console.WriteLine(MinSum(matrix_97x97));

        }

        

        private static string MinSum(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            int[] toPermutate = Enumerable.Range(0, size).ToArray();

            var atw = MathAdv.QuickPerm(toPermutate);

            long minSum = long.MaxValue;
            string minString = string.Empty;

            foreach(var path in atw)
            {
                int[] a = path.ToArray();
                // { 0, 1, 2, 3}
                long sum = 0;

                for (int i = 0; i < size; i++)
                {
                    sum += matrix[a[i], i];
                }

                if (minSum > sum)
                {
                    minSum = sum;
                    minString = string.Empty;

                    for (int i = 0; i < a.Length; i++)
                    {
                        minString += matrix[a[i], i];
                        if (i < a.Length - 1)
                            minString += " + ";
                    }

                    minString += " = " + minSum;
                }
            }

            return minString;

            //List<NumberWithCo> path = new List<NumberWithCo>();

            //List<NumberWithCo> numberWithCo = new List<NumberWithCo>();

            //// on prend la pos de toute les valeurs les plus basse puis on essaye de prendre du plus petit au plus grand sans prendre chaque meme r&c
            //for (int y = 0; y < matrix.GetLength(0); y++)
            //{
            //    for (int x = 0; x < matrix.GetLength(1); x++)
            //    {
            //        numberWithCo.Add(new NumberWithCo()
            //        {
            //            Number = matrix[y, x],
            //            X = x,
            //            Y = y
            //        });
            //    }
            //}

            ////List<List<NumberWithCo>> paths = new List<List<NumberWithCo>>();


            ////for (int i = 0; i < size; i++)
            ////{
            ////    if(path_.Last().)
            ////}

            ////for (int y = 0; y < size; y++)
            ////{
            ////    {
            ////        List<NumberWithCo> path_ = new List<NumberWithCo>();

            ////        path_.Add(new NumberWithCo() { X = 0, Y = y });


            ////    }
            ////}


            //numberWithCo = numberWithCo.OrderBy(x => x.Number).ToList();
            //foreach (NumberWithCo nb in numberWithCo)
            //{
            //    bool testPass = true;

            //    foreach(NumberWithCo alreadyAddedNb in path)
            //    {
            //        if (alreadyAddedNb.X == nb.X || alreadyAddedNb.Y == nb.Y)
            //        {
            //            testPass = false;
            //            break;
            //        }
            //    }

            //    if(testPass)
            //    {
            //        path.Add(nb);
            //    }
            //}


            //return String.Join(" + ", path.Select(x => x.Number)) + " = " + path.Sum(x => x.Number);
        }

        internal class NumberWithCo
        {
            internal long Number { get; set; }
            internal int Y { get; set; }
            internal int X { get; set; }
        }
    }

    public static class MathAdv
    {
        public static IEnumerable<IEnumerable<T>> QuickPerm<T>(this IEnumerable<T> set)
        {
            int N = set.Count();
            int[] a = new int[N];
            int[] p = new int[N];

            var yieldRet = new T[N];

            List<T> list = new List<T>(set);

            int i, j, tmp; 

            for (i = 0; i < N; i++)
            {         
                a[i] = i + 1; 
                p[i] = 0; 
            }
            yield return list;

            i = 1;
            while (i < N)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i]; 
                    tmp = a[j]; 
                    a[j] = a[i];
                    a[i] = tmp;


                    for (int x = 0; x < N; x++)
                    {
                        yieldRet[x] = list[a[x] - 1];
                    }
                    yield return yieldRet;


                    p[i]++; 
                    i = 1; 
                }
                else
                {                   
                    p[i] = 0;
                    i++; 
                } 
            } 
        }
    }
}
