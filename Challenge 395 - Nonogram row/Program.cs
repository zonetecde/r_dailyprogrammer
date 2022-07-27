using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_395___Nonogram_row
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.reddit.com/r/dailyprogrammer/comments/o4uyzl/20210621_challenge_395_easy_nonogram_row/
            // Worked the first time!

            Console.WriteLine(nonogramRow(new byte[] {  }));
            Console.WriteLine(nonogramRow(new byte[] { 0, 0, 0, 0, 0 }));
            Console.WriteLine(nonogramRow(new byte[] { 1, 1, 1, 1, 1 }));
            Console.WriteLine(nonogramRow(new byte[] { 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 }));
            Console.WriteLine(nonogramRow(new byte[] { 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0 }));
            Console.WriteLine(nonogramRow(new byte[] { 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1 }));
            Console.WriteLine(nonogramRow(new byte[] { 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0 }));
            Console.WriteLine(nonogramRow(new byte[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }));
        }

        private static string nonogramRow(byte[] binary)
        {
            return "[" + 
                String.Join(",", 
                    String.Join(string.Empty, binary)
                        .Split('0').ToList()
                            .Where(x => !String.IsNullOrWhiteSpace(x))
                                .Select(c => c.Length).ToList())
                + "]";
        }
    }
}
