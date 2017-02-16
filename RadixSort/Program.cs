using System;
using System.Collections.Generic;
using System.Linq;

namespace RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int> { 19, 8, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            a = RadixSort(a).ToList();
            foreach (var x in a)
                Console.Write(x + " ");
            Console.Read();
        }

        static IEnumerable<int> RadixSort(IEnumerable<int> nums)
        {
            var radix_total = new List<List<int>[]>();
            for(var i = 0; i < nums.Max().ToString().Length; i++)
            {
                var radix_inner = new List<int>[10];
                for (var j = 0; j < 10; j++)
                {
                    if (i == 0)
                    {
                        radix_inner[j] = nums.Where(x => x % 10 == j).ToList();
                    }
                    else
                    {
                        IEnumerable<int> last = radix_total[i - 1][0];
                        for (var k = 1; k < 10; k++)
                        {
                            last = last.Concat(radix_total[i - 1][k]);
                        }
                        radix_inner[j] = last.Where(x => x / (10 * i) % 10 == j).ToList();
                    }
                }
                radix_total.Add(radix_inner);
            }

            return radix_total.Last().SelectMany(x => x);
        }
    }
}
