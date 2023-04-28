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
        /// <summary>
        /// Обход графа в ширину, начиная с данной вершины
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Обход графа в глубину, начиная с данной вершины
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
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

}
