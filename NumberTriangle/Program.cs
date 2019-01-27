// http://www.joyoi.cn/problem/tyvj-1044

using System;
using System.Linq;

namespace NumberTriangle
{
    class Program
    {
        static int[,] arr;
        static int[,] dp;
        static int layer;

        static void Input()
        {
            layer = Convert.ToInt32(Console.ReadLine());
            arr = new int[layer + 1, layer + 2];
            dp = new int[layer + 1, layer + 2];
            for (var i = 1; i <= layer; i++)
            {
                var l = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                for (var j = 0; j < l.Count(); j++)
                {
                    arr[i, j + 1] = l[j];
                }
            }
        }

        static void Dp()
        {
            for (var i = 1; i <= layer; i++)
            {
                for (var j = 1; j <= i; j++)
                {
                    dp[i, j] = arr[i, j] + Math.Max(dp[i - 1, j], dp[i - 1, j - 1]);
                }
            }
        }

        static void Output()
        {
            var result = -1;
            for (var i = 0; i <= layer; i++)
            {
                result = Math.Max(dp[layer, i], result);
            }
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            Input();
            Dp();
            Output();
        }
    }
}
