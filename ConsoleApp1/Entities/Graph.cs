using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    class Graph
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
    }
}
