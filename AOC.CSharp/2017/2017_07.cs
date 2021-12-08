using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2017_07
{
    private static Regex CommonRegex = new(@"(\w+) \((\d+)\)");
    private static Regex NonLeafRegex = new(@"(\w+) \((\d+)\) -> (.*)");

    public static string Solve1(string[] lines)
    {
        Dictionary<string, Node> nodes = Parse(lines);
        return FindRoot(nodes).Name;
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<string, Node> nodes = Parse(lines);
        Node root = FindRoot(nodes);
        return 0L;
    }

    //private static long FindWrongWeight(Node curr, ref long wrong)
    //{
    //    if (!curr.SubNodes.Any())
    //    {
    //        return curr.Weight;
    //    }

    //    List<long> subWeights = new();
    //    foreach (Node sub in curr.SubNodes)
    //    {
    //        subWeights.Add(FindWrongWeight(sub, ref wrong));
    //    }

    //    var subDict = subWeights.ToDictionary()
    //    if (subWeights.Distinct().Count > 1)
    //    {

    //    }

    //    long currTotalWeight = 
    //}

    private static Node FindRoot(Dictionary<string, Node> nodes)
    {
        HashSet<string> all = nodes.Select(n => n.Key).ToHashSet();
        HashSet<string> notRoot = nodes.SelectMany(kvp => kvp.Value.SubNodes).Select(x => x.Name).ToHashSet();

        return nodes[all.Except(notRoot).Single()];
    }

    private static Dictionary<string, Node> Parse(string[] lines)
    {
        Dictionary<string, Node> nodes = new();

        foreach (var line in lines)
        {
            Match m = CommonRegex.Match(line);
            string name = m.Groups[1].Value;
            int weight = int.Parse(m.Groups[2].Value);
            nodes.Add(name, new Node(name, weight, new Node[0]));
        }

        foreach (var line in lines)
        {
            Match m = NonLeafRegex.Match(line);
            if (m.Success)
            {
                string name = m.Groups[1].Value;
                int weight = int.Parse(m.Groups[2].Value);
                Node[] childNodes = m.Groups[3].Value.Split(", ").Select(x => nodes[x]).ToArray();
                nodes[name] = new Node(name, weight, childNodes);
            }
        }

        return nodes;
    }

    private record Node(string Name, int Weight, Node[] SubNodes);
}
