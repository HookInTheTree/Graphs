using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Entities
{
    public class Graph
    {
        private readonly Node[] nodes;
        public IEnumerable<Node> Nodes
        {
            get
            {
                foreach (var node in nodes)
                    yield return node;
            }
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return Nodes.SelectMany(x => x.IncidentEdges).Distinct();
            }
        }

        public Graph(int nodeCount)
        {
            nodes = Enumerable
                .Range(0, nodeCount)
                .Select(x => new Node(x))
                .ToArray();
        }

        public Node this[int index]
        {
            get
            {
                return nodes[index];
            }
        }

        public void Connect(int index1, int index2)
        {
            Node.Connect(nodes[index1], nodes[index2], this);
        }

        public void Disconnect(Edge edge)
        {
            Node.Disconnect(edge);
        }

        public static Graph CreateGraph(params Tuple<int,int>[] incidentNodes)
        {

            var maxPoint = incidentNodes
                .SelectMany(x => new[] { x.Item1, x.Item2 })
                .Max();

            var graph = new Graph(maxPoint+ 1);

            foreach (var edge in incidentNodes)
                graph.Connect(edge.Item1, edge.Item2);
            return graph;
        }
    }
}
