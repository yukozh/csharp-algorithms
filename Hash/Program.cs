using System;
using System.Collections.Generic;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 19, 5, 21, 24, 45, 20, 68, 27, 70, 11, 10 };
            Init(nums);
            Console.WriteLine("70 at the position " + Find(70));
            Console.Read();
        }

        static int[] Store = new int[17];

        static void Init(IEnumerable<int> nums)
        {
            foreach(var x in nums)
            {
                var pos = GetHash(x);
                while (Store[pos] != 0)
                    pos++;
                Store[pos] = x;
            }
        }

        static int GetHash(int num) => num % 17;

        static int Find(int num)
        {
            var pos = GetHash(num);
            while (Store[pos] != num)
                ++pos;
            return pos;
        }
    }
}
