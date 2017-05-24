using System;
using System.Collections.Generic;
using System.Linq;

namespace FindSubSets
{
    class Program
    {
        static void Main(string[] args)
        {
            // var array = new HashSet<int> { 1, 5, 7, 35, 92, 153, 280, 375, 589, 810 };
            var array = new HashSet<int> { 1, 5, 7, 35 };
            foreach (var x in FindSubSets(array).Distinct())
            {
                Console.WriteLine(x);
            }
            Console.Read();
        }

        static IEnumerable<string> FindSubSets(HashSet<int> src)
        {
            if (src.Count != 0)
            {
                yield return string.Join(" ", src.Select(x => x.ToString()));
                foreach (var x in PullOne(src).SelectMany(y => FindSubSets(y)))
                {
                    yield return x;
                }
            }
        }

        static IEnumerable<HashSet<int>> PullOne(HashSet<int> src)
        {
            for (var i = 0; i < src.Count; i++)
            {
                var tmp = new HashSet<int>(src);
                tmp.Remove(src.ElementAt(i));
                yield return tmp;
            }
        }
    }
}
