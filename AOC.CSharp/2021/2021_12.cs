namespace AOC.CSharp;

public static class AOC2021_12
{
    public static long Solve1(string[] lines)
    {
        var graph = BuildGraph(lines);
        return CountPaths(graph, false);
    }

    public static long Solve2(string[] lines)
    {
        var graph = BuildGraph(lines);
        return CountPaths(graph, true);
    }

    private static long CountPaths(Dictionary<Node, List<Node>> graph, bool canVisitSmallTwice)
    {
        Node start = graph.Keys.Single(k => k.Type == NodeType.Start);
        List<Node> visited = new();
        int count = 0;

        Recurse(graph, start, visited, ref count, !canVisitSmallTwice);

        return count;
    }

    private static void Recurse(
        Dictionary<Node, List<Node>> graph,
        Node curr,
        List<Node> visited,
        ref int count,
        bool smallVisitedTwice
    )
    {
        visited.Add(curr);
        var graphEntry = graph[curr];
        foreach (Node next in graphEntry)
        {
            if (next.Type == NodeType.End)
            {
                count++;
            }
            else if (next.Type == NodeType.Large)
            {
                Recurse(graph, next, visited, ref count, smallVisitedTwice);
            }
            else if (next.Type == NodeType.Small && visited.Contains(next) && !smallVisitedTwice)
            {
                Recurse(graph, next, visited, ref count, true);
            }
            else if (next.Type == NodeType.Small && !visited.Contains(next))
            {
                Recurse(graph, next, visited, ref count, smallVisitedTwice);
            }
        }
        visited.RemoveAt(visited.Count - 1);
    }

    private static Dictionary<Node, List<Node>> BuildGraph(string[] lines)
    {
        Dictionary<Node, List<Node>> graph = new();

        void AddEdge(Node node1, Node node2)
        {
            if (!graph.TryGetValue(node1, out List<Node> nodes))
            {
                nodes = new List<Node>();
                graph.Add(node1, nodes);
            }
            nodes.Add(node2);
        }

        foreach (string line in lines)
        {
            string[] splits = line.Split('-');
            Node node1 = MakeNode(splits[0]);
            Node node2 = MakeNode(splits[1]);

            AddEdge(node1, node2);
            AddEdge(node2, node1);
        }

        return graph;
    }

    private static Node MakeNode(string token)
    {
        if (token == "start")
            return new Node(token, NodeType.Start);
        if (token == "end")
            return new Node(token, NodeType.End);
        if (char.IsUpper(token[0]))
            return new Node(token, NodeType.Large);

        return new Node(token, NodeType.Small);
    }

    private record Node(string Name, NodeType Type);

    private enum NodeType
    {
        Start,
        End,
        Large,
        Small
    }
}
