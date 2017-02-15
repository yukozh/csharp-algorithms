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
            var bucket = new List<List<int>[]>();
            for(var i = 0; i < nums.Max().ToString().Length; i++)
            {
                var radix = new List<int>[10];
                for (var j = 0; j < 10; j++)
                {
                    if (i == 0)
                    {
                        radix[j] = nums.Where(x => x % 10 == j).ToList();
                    }
                    else
                    {
                        IEnumerable<int> last = bucket[i - 1][0];
                        for (var k = 1; k < 10; k++)
                        {
                            last = last.Concat(bucket[i - 1][k]);
                        }
                        radix[j] = last.Where(x => x / (10 * i) % 10 == j).ToList();
                    }
                }
                bucket.Add(radix);
            }
            foreach(var x in bucket.Last())
            {
                foreach(var y in x)
                {
                    yield return y;
                }
            }
        }
    }
}
