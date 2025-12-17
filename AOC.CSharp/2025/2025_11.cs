namespace AOC.CSharp;

public static class AOC2025_11
{
    public static long Solve1(string[] lines)
    {
        Dictionary<string, Node> nodes = new();

        foreach (string line in lines)
        {
            string[] splits = line.Split(" ");
            string name = splits[0].Replace(":", "");
            Node node = new(name, splits.Skip(1).ToArray());
            nodes.Add(node.Name, node);
        }

        Node start = nodes["you"];
        int result = Recurse1(nodes, start);

        return result;
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<string, Node> nodes = new();

        foreach (string line in lines)
        {
            string[] splits = line.Split(" ");
            string name = splits[0].Replace(":", "");
            Node node = new(name, splits.Skip(1).ToArray());
            nodes.Add(node.Name, node);
        }

        Node start = nodes["svr"];
        List<string> path = new();
        Dictionary<string, int> solutions = new();
        int result = Recurse2(nodes, start, path, solutions);

        return result;
    }

    private static int Recurse1(Dictionary<string, Node> nodes, Node curr)
    {
        int result = 0;
        foreach (string output in curr.OutputNames)
        {
            if (output == "out")
            {
                result++;
            }
            else
            {
                Node newCurr = nodes[output];
                result += Recurse1(nodes, newCurr);
            }
        }

        return result;
    }

    private static int Recurse2(
        Dictionary<string, Node> nodes,
        Node curr,
        List<string> path,
        Dictionary<string, int> solutions
    )
    {
        // if (solutions.TryGetValue(curr.Name, out int val))
        // {
        //     if (path.Contains("fft") && path.Contains("dac"))
        //     {
        //         return val;
        //     }
        //
        //     return 0;
        // }

        path.Add(curr.Name);

        var cycle = path.GroupBy(x => x).Any(x => x.Count() > 1);
        if (cycle)
        {
            throw new InvalidOperationException("CYCLE: " + string.Join(",", path));
        }

        int result = 0;
        foreach (string output in curr.OutputNames)
        {
            if (output == "out")
            {
                Console.WriteLine(string.Join(",", path));
                if (path.Contains("fft") && path.Contains("dac"))
                {
                    result++;
                }
            }
            else
            {
                Node newCurr = nodes[output];
                result += Recurse2(nodes, newCurr, path, solutions);
            }
        }

        // solutions.Add(curr.Name, result);

        path.RemoveAt(path.Count - 1);

        return result;
    }

    private record Node(string Name, string[] OutputNames);
}
