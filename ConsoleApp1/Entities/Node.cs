using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Entities
{
    public class Node
    {
        private readonly List<Edge> incidentEdges = new List<Edge>();
        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                return IncidentEdges.Select(x => x.OtherNode(this) );
            }
        }

        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                foreach (var edge in incidentEdges)
                {
                    yield return edge;
                }
            }
        }

        public readonly int Number;

        public Node(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public static Edge Connect(Node firstNode, Node secondNode, Graph graph)
        {
            if (!graph.Nodes.Contains(firstNode) ||
                !graph.Nodes.Contains(secondNode))
                throw new ArgumentException("Одна из вершин не принадлежит графу!");

            var newEdge = new Edge(firstNode, secondNode);
            firstNode.incidentEdges.Add(newEdge);
            secondNode.incidentEdges.Add(newEdge);
            return newEdge;
        }

        public static void Disconnect(Edge edge)
        {
            edge.First.incidentEdges.Remove(edge);
            edge.Second.incidentEdges.Remove(edge);
        }

    }
}
