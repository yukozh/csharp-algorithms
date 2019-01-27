// http://www.joyoi.cn/problem/tyvj-1005

using System;
using System.Collections.Generic;
using System.Linq;

namespace Medic
{
    class Medic
    {
        public int Time { get; set; }

        public int Value { get; set; }
    }

    class Program
    {
        static int time;

        static List<Medic> medics = new List<Medic>();

        static int[] dp;

        static void Input()
        {
            var line = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToList();
            time = line[0];
            var medicCount = line[1];
            dp = new int[time + 1];
            for (var i = 0; i < medicCount; i++)
            {
                var l = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToList();
                medics.Add(new Medic { Time = l[0], Value = l[1] });
            }
        }

        static void Dp()
        {
            foreach(var medic in medics)
            {
                for (var i = time; i > 0; i--)
                {
                    if (i - medic.Time >= 0)
                    {
                        dp[i] = Math.Max(dp[i], dp[i - medic.Time] + medic.Value);
                    }
                }
            }
        }

        static void Output()
        {
            Console.WriteLine(dp[time]);
        }

        static void Main(string[] args)
        {
            Input();
            Dp();
            Output();
        }
    }
}
