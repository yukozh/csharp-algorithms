using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int> { 19, 8, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            a = QuickSort(a).ToList();
            foreach (var x in a)
                Console.Write(x + " ");
            Console.Read();
        }

        static IEnumerable<int> QuickSort(IEnumerable<int> src)
        {
            if (src.Count() <= 1)
            {
                return src;
            }

            return QuickSort(src.Skip(1).Where(x => x <= src.First()))
                .Concat(new[] { src.First() })
                .Concat(QuickSort(src.Skip(1).Where(x => x > src.First())));
        }
    }
}
