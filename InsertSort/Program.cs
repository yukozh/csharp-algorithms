using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 19, 8, 3, 50, 12, 59, 20, 32, 34, 75, 2 };
            InsertSort(nums);
            foreach (var x in nums)
                Console.Write($"{x} ");
            Console.Read();
        }

        static void InsertSort(IList<int> nums)
        {
            for(var i = 1; i < nums.Count; i++)
            {
                for(var j = 0; j < i; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        var val = nums[i];
                        for (var k = i; k > j; k--)
                        {
                            nums[k] = nums[k - 1];
                        }
                        nums[j] = val;
                    }
                }
            }
        }
    }
}
