using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 3, 8, 11, 19, 30, 35, 60, 74, 82, 100 };
            Console.WriteLine($"The numer 74's index is { BinarySearch(nums, 74) }.");
            Console.Read();
        }

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="find">欲查找的数值</param>
        /// <param name="begin">起始位置</param>
        /// <param name="end">结束位置</param>
        /// <returns></returns>
        static int BinarySearch(int[] nums, int find, int begin = 0, int end = -1)
        {
            if (end == -1)
                end = nums.Count();
            if (begin >= end)
                return -1;
            var mid = (begin + end) / 2;
            if (nums[mid] == find)
                return mid;
            else if (nums[mid] > find)
                return BinarySearch(nums, find, begin, mid - 1);
            else
                return BinarySearch(nums, find, mid + 1, end);
        }
    }
}
