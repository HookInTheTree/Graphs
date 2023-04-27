using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    class Edge
    {
        public readonly Node First;
        public readonly Node Second;

        public Edge(Node first, Node second)
        {
            First = first;
            Second = second;
        }

        public bool IsIncident(Node node)
        {
            return First == node || Second == node;
        }

        public Node OtherNode(Node node)
        {
            if (First == node) return Second;
            else if (Second == node) return First;
            else throw new ArgumentException("Вершина не относится к данному ребру!");
        }
    }
}
