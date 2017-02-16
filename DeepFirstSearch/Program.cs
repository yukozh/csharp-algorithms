using System;
using System.Collections.Generic;

namespace DeepFirstSearch
{
    class Node
    {
        public string Value { get; set; }

        public LinkedList<Node> Nodes { get; set; } = new LinkedList<Node>();
    }

    class Program
    {
        static HashSet<Node> Visited = new HashSet<Node>();

        static void Main(string[] args)
        {
            // Arrange 
            var A = new Node { Value = "A" };
            var B = new Node { Value = "B" };
            var C = new Node { Value = "C" };
            var D = new Node { Value = "D" };
            var E = new Node { Value = "E" };
            var F = new Node { Value = "F" };
            var G = new Node { Value = "G" };
            A.Nodes.AddLast(B);
            A.Nodes.AddLast(C);
            A.Nodes.AddLast(D);
            B.Nodes.AddLast(A);
            B.Nodes.AddLast(D);
            C.Nodes.AddLast(A);
            D.Nodes.AddLast(A);
            D.Nodes.AddLast(B);
            D.Nodes.AddLast(E);
            E.Nodes.AddLast(D);
            E.Nodes.AddLast(F);
            F.Nodes.AddLast(E);
            F.Nodes.AddLast(G);
            G.Nodes.AddLast(F);

            // Search
            Visit(A);
            Console.Read();
        }

        static void Visit(Node n)
        {
            if (Visited.Contains(n))
                return;
            Visited.Add(n);
            Console.Write($"{ n.Value } ");
            foreach (var x in n.Nodes)
                Visit(x);
        }
    }
}
