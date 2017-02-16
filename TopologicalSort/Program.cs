using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // 构建依赖关系
            var step1a = new GraphNode { Value = "切香菜" };
            var step1b = new GraphNode { Value = "切葱丝" };
            var step1c = new GraphNode { Value = "切姜丝" };
            var step1d = new GraphNode { Value = "里脊切片" };
            var step1e = new GraphNode { Value = "调制酸甜汁" };
            var step2 = new GraphNode { Value = "里脊片裹淀粉" };
            var step3 = new GraphNode { Value = "将裹好淀粉的里脊片炸金黄定型" };
            var step4 = new GraphNode { Value = "回锅再炸一遍" };
            var step5 = new GraphNode { Value = "配料入锅并浇汁" };
            step1d.Nodes.AddLast(step2);
            step2.Nodes.AddLast(step3);
            step3.Nodes.AddLast(step4);
            step1a.Nodes.AddLast(step5);
            step1b.Nodes.AddLast(step5);
            step1c.Nodes.AddLast(step5);
            step1e.Nodes.AddLast(step5);
            var graph = new Graph
            {
                Nodes = new List<GraphNode> { step1a, step1b, step1c, step1d, step1e, step2, step3, step4, step5 }.OrderBy(x => Guid.NewGuid()).ToList()
            };

            // 拓扑排序
            foreach (var x in TopologicalSort(graph))
                Console.WriteLine(x);
            Console.Read();
        }

        static IEnumerable<string> TopologicalSort(Graph g)
        {
            while(g.Nodes.Count > 0)
            {
                var in0 = g.Nodes.Where(x => !g.Nodes.Any(y => y.Nodes.Contains(x))).ToList();
                foreach (var x in in0)
                {
                    yield return x.Value;
                    g.Nodes.Remove(x);
                    g.Nodes.ForEach(y => y.Nodes.Remove(x));
                }
            }
        }
    }
}
