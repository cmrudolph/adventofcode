namespace AOC.CSharp;

public static class AOC2017_12
{
    public static long Solve1(string[] lines)
    {
        Dictionary<int, int[]> graph = ParseLines(lines);
        HashSet<int> visited = new();
        int result = FindConnected(graph, 0, visited);

        return result;
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<int, int[]> graph = ParseLines(lines);
        HashSet<int> visited = new();

        int groups = 0;
        foreach (int start in graph.Keys)
        {
            int connectedCount = FindConnected(graph, start, visited);
            groups += connectedCount > 0 ? 1 : 0;
        }

        return groups;
    }

    private static int FindConnected(Dictionary<int, int[]> graph, int curr, HashSet<int> visited)
    {
        if (visited.Contains(curr))
        {
            return 0;
        }

        int result = 1;
        visited.Add(curr);

        int[] connections = graph[curr];
        foreach (int connection in connections)
        {
            int recurseResult = FindConnected(graph, connection, visited);
            result += recurseResult;
        }

        return result;
    }

    private static (int, int[]) ParseLine(string line)
    {
        string[] splits = line.Split("<->");
        int left = int.Parse(splits[0]);
        int[] rightSplits = splits[1].Split(",").Select(int.Parse).ToArray();

        return (left, rightSplits);
    }

    private static Dictionary<int, int[]> ParseLines(string[] lines)
    {
        return lines.Select(ParseLine).ToDictionary(x => x.Item1, x => x.Item2);
    }
}
