using Graphs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Extensions
{
    public static class NodeExtensions
    {
        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();

            visited.Add(startNode);
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();

                yield return node;

                var nextNodes = node.IncidentNodes.Where(x => !visited.Contains(x));
                foreach (var nextNode in nextNodes)
                {
                    visited.Add(nextNode);
                    queue.Enqueue(nextNode);
                }
            }
        }

        public static IEnumerable<Node> DepthSearch(this Node startNode)
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();

            stack.Push(startNode);
            visited.Add(startNode);
            while (stack.Count != 0)
            {
                Node node = stack.Pop();

                yield return node;
                var nextNodes = node.IncidentNodes.Where(x => !visited.Contains(x));
                foreach (var nextNode in nextNodes)
                {
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
            }
        }

    }

    public static class GraphExtensions
    {
        public static IEnumerable<IEnumerable<Node>> FindConnectedComponents(this Graph graph)
        {
            var marked = new HashSet<Node>();

            while (true)
            {
                var node = graph.Nodes
                    .Where(x => !marked.Contains(x) )
                    .FirstOrDefault();

                if (node == null) break;

                var breadthSearch = node.BreadthSearch().ToList();

                foreach(var visitedNode in breadthSearch)
                {
                    marked.Add(visitedNode);
                }
                yield return breadthSearch;
            }
        }
    }
}
