using System.Collections.Generic;

namespace TopologicalSort
{
    public class Graph
    {
        public List<GraphNode> Nodes { get; set; } 
    }

    public class GraphNode
    {
        public string Value { get; set; }
        public LinkedList<GraphNode> Nodes { get; set; } = new LinkedList<GraphNode>();
    }
}
