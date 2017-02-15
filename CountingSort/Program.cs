using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 19, 8, 3, 3, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            var min = nums.Min();
            var max = nums.Max();
            var result = CountingSort(nums);
            for (var i = min; i <= max; i++)
                if (result.ContainsKey(i))
                    for (var j = 0; j < result[i]; j++)
                        Console.Write($"{i} ");
            Console.Read();
        }

        static Dictionary<int, int> CountingSort(IEnumerable<int> nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (var x in nums)
            {
                if (dic.ContainsKey(x))
                    dic[x]++;
                else
                    dic.Add(x, 1);
            }
            return dic;
        }
    }
}
