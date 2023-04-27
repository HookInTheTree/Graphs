using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    class Node
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

        public void Connect(Node anotherNode)
        {
            var newEdge = new Edge(this, anotherNode);
            incidentEdges.Add(newEdge);
            anotherNode.incidentEdges.Add(newEdge);
        }

        public void Disconnect(Edge edge)
        {
            edge.First.incidentEdges.Remove(edge);
            edge.Second.incidentEdges.Remove(edge);
        }
    }
}
