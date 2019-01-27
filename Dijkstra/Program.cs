using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    class Program
    {
        const int Max = int.MaxValue;
        static void Main(string[] args)
        {
            var g = new int[][]
            {
                new [] { 0, 50, 10, -1, 45, -1},
                new [] { -1, 0, -1, -1,10,-1 },
                new [] { 20, -1, 0, 15, -1, -1},
                new [] { -1, 20, -1, 0, 35, -1},
                new [] { -1, -1, -1, 30, 0, -1 },
                new [] { -1, -1, -1, 3, -1, 0 }
            };

            foreach (var x in Dijkstra(g, 0))
            {
                Console.Write(x < Max ? (x + " ") : "X ");
            }
            Console.Read();
        }
        
        static IEnumerable<int> Dijkstra(int[][] g, int start)
        {
            // Arrange
            var tmp = new DijkstraInfo[g.Length];
            for (var i = 0; i < g.Length; i++)
            {
                tmp[i] = new DijkstraInfo();
                tmp[i].Index = i;
            }

            // Init
            var n = g.Length;
            var pos = start;
            for (var i = 0; i < g.Length; i++)
            {
                if (g[pos][i] >= 0 && tmp[i].Distance > g[pos][i])
                {
                    tmp[i].Distance = g[pos][i];
                    tmp[i].Path = pos;
                }
            }
            tmp[pos].IsVisited = true;

            // Loop
            do
            {
                var di = tmp.Where(x => !x.IsVisited && x.Distance < Max).OrderBy(x => x.Distance).FirstOrDefault();
                if (di == null)
                    break;
                pos = di.Index;
                for (var i = 0; i < g.Length; i++)
                {
                    if (g[pos][i] >= 0 && tmp[i].Distance > g[pos][i] + tmp[pos].Distance)
                    {
                        tmp[i].Distance = g[pos][i] + tmp[pos].Distance;
                        tmp[i].Path = pos;
                    }
                }
                tmp[pos].IsVisited = true;
            }
            while (--n != 0);

            // Output
            return tmp.Select(x => x.Distance);
        }

        class DijkstraInfo
        {
            public int Index { get; set; }
            public int Distance { get; set; } = Max;
            public int Path { get; set; } = -1;
            public bool IsVisited { get; set; } 
        }
    }
}
