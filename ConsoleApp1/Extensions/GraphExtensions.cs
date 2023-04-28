using Graphs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Extensions
{
    public static class GraphExtensions
    {
        /// <summary>
        /// Находит все связные компоненты графа
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<Node>> FindConnectedComponents(this Graph graph)
        {
            var marked = new HashSet<Node>();

            while (true)
            {
                var node = graph.Nodes
                    .Where(x => !marked.Contains(x))
                    .FirstOrDefault();

                if (node == null) break;

                var breadthSearch = node.BreadthSearch().ToList();

                foreach (var visitedNode in breadthSearch)
                {
                    marked.Add(visitedNode);
                }
                yield return breadthSearch;
            }
        }

        /// <summary>
        /// Находит кратчайший путь от стартовой вершины к конечной в неориентированном графе
        /// </summary>
        /// <param name="graph">Граф</param>
        /// <param name="start">Стартовая вершина</param>
        /// <param name="end">Конечная вершина</param>
        /// <returns>Возвращает путь из вершин</returns>
        public static IEnumerable<Node> FindShortestPath(this Graph graph, Node start, Node end)
        {
            var track = new Dictionary<Node, Node>();
            var queue = new Queue<Node>();

            track[start] = null;
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();


                var nextNodes = node.IncidentNodes.Where(x => !track.ContainsKey(x));
                foreach (var nextNode in nextNodes)
                {
                    track[nextNode] = node;
                    queue.Enqueue(nextNode);
                }

                if (track.ContainsKey(end)) break;
            }

            var pathItem = end;
            var result = new List<Node>();
            while (pathItem != null)
            {
                result.Add(pathItem);
                pathItem = track[pathItem];
            }
            result.Reverse();
            return result;
        }

        /// <summary>
        /// Сортирует вершины ориентированного графа в топологическом порядке
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static List<Node> KahnAlgoritm(this Graph graph)
        {
            var topSort = new List<Node>();
            var nodes = graph.Nodes.ToList();
            while (nodes.Count != 0)
            {
                var nodeToDelete = nodes
                    .Where(node => 
                            !node.IncidentEdges.Any(edge => edge.Second == null) )
                    .FirstOrDefault();

                if (nodeToDelete != null) return null;

                nodes.Remove(nodeToDelete);
                topSort.Add(nodeToDelete);
                
                foreach (var edge in nodeToDelete.IncidentEdges.ToList() )
                    graph.Disconnect(edge);
            }

            return topSort;
        }
    }
}
