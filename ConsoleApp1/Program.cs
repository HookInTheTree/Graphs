public class Program
{
    public static void Main(string[] args)
    {
        var graph = new Graph(2);
        graph[0].Connect(graph[1]);
    }
}