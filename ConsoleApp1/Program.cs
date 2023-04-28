using Graphs.Entities;
using Graphs.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var graph = Graph.CreateGraph(
                Tuple.Create(0, 1),
                Tuple.Create(0, 2),
                Tuple.Create(1, 3),
                Tuple.Create(1, 4),
                Tuple.Create(2, 3),
                Tuple.Create(2, 4)
            );

        var breadthSearch = graph[0].DepthSearch();

        foreach (var item in breadthSearch )
            Console.WriteLine( item );

        var graph2 = Graph.CreateGraph(
                Tuple.Create(1, 2),
                Tuple.Create(3, 4),
                Tuple.Create(3, 5)
                );

        var connectedComponents = graph2.FindConnectedComponents().ToList();
        
        Console.WriteLine(connectedComponents
            .Select(x => x.Select( y => y.ToString() )
                        .Aggregate((a, b) => a + "-" + b)
            )
            .Aggregate((z, v) => z + "\n" + v)
        );
    }
}