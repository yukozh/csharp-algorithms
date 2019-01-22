using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 19, 8, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            nums = MergeSort(nums).ToList();
            foreach (var x in nums)
                Console.Write($"{x} ");
            Console.Read();
        }

        static IEnumerable<int> MergeSort(IEnumerable<int> nums)
        {
            if (nums.Count() <= 1)
                return nums;
            var mid = nums.Count() / 2;
            var arr1 = MergeSort(nums.Take(mid));
            var arr2 = MergeSort(nums.Skip(mid));
            return Merge(arr1, arr2); 
        }

        static IEnumerable<int> Merge(IEnumerable<int> a, IEnumerable<int> b)
        {
            while(a.Count() + b.Count() > 0)
            {
                var min1 = a.Count() > 0 ? a.First() : int.MaxValue;
                var min2 = b.Count() > 0 ? b.First() : int.MaxValue;
                if (min1 < min2)
                {
                    a = a.Skip(1);
                    yield return min1;
                }
                else
                {
                    b = b.Skip(1);
                    yield return min2;
                }
            }
        }
    }
}
