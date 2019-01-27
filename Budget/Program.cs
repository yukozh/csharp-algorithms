// http://www.joyoi.cn/problem/tyvj-1057

using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget
{
    class Program
    {
        class Item
        {
            public int Price { get; set; }

            public int Value { get; set; }

            public List<Item> Attachment { get; set; } = new List<Item>();
        }
        
        static int budget;

        static List<Item> items = new List<Item>();

        static int[] dp;

        static void Input()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            budget = line[0];
            dp = new int[budget + 1];
            items.Add(null);
            for (var i = 0; i < line[1]; i++)
            {
                var l = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (l[2] != 0)
                {
                    items[l[2]].Attachment.Add(new Item
                    {
                        Price = l[0],
                        Value = l[1]
                    });
                    items.Add(null);
                }
                else
                {
                    items.Add(new Item
                    {
                        Price = l[0],
                        Value = l[1]
                    });
                }
            }
        }

        static int Max(params int[] args)
        {
            return args.Max();
        }

        static void Dp()
        {
            foreach (var item in items.Where(x => x != null))
            {
                for(var i = budget; i >= 0; i--)
                {
                    dp[i] = Max(dp[i],
                      i - item.Price < 0 
                          ? 0 
                          : dp[i - item.Price] + item.Value * item.Price,
                      item.Attachment.Count == 0 || i - item.Price - item.Attachment.First().Price < 0
                          ? 0
                          : dp[i - item.Price - item.Attachment.First().Price] + item.Value * item.Price + item.Attachment.First().Value * item.Attachment.First().Price,
                      item.Attachment.Count == 0 || i - item.Price - item.Attachment.Last().Price < 0
                          ? 0
                          : dp[i - item.Price - item.Attachment.Last().Price] + item.Value * item.Price + item.Attachment.Last().Value * item.Attachment.Last().Price,
                      item.Attachment.Count == 0 || i - item.Price - item.Attachment.Select(y => y.Price).Sum() < 0
                          ? 0
                          : dp[i - item.Price - item.Attachment.Select(y => y.Price).Sum()] + item.Value + item.Attachment.Select(y => y.Value * y.Price).Sum());
                }
            }
        }

        static void Output()
        {
            Console.WriteLine(dp[budget]);
        }

        static void Main(string[] args)
        {
            Input();
            Dp();
            Output();
        }
    }
}
