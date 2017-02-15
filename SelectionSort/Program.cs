using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 19, 8, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            SelectionSort(nums);
            foreach (var x in nums)
                Console.Write($"{x} ");
            Console.Read();
        }

        static void SelectionSort(IList<int> nums)
        {
            for(var i = 0; i < nums.Count; i++)
            {
                var min = nums.Skip(i).Min();
                var pos = nums.IndexOf(min);
                Swap(nums, pos, i);
            }
        }

        static void Swap(IList<int> nums, int pos1, int pos2)
        {
            var tmp = nums[pos1];
            nums[pos1] = nums[pos2];
            nums[pos2] = tmp;
        }
    }
}
