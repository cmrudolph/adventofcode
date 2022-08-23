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
        Dictionary<string, AggregatedWeight> aggregatedWeights = new();
        BuildAggregatedWeights(root, nodes, aggregatedWeights);
        long? result = FindWeightCorrection(root, nodes, aggregatedWeights);
        
        return result.Value;
    }

    private static void BuildAggregatedWeights(Node curr, Dictionary<string, Node> nodes, Dictionary<string, AggregatedWeight> weights)
    {
        if (!curr.SubNames.Any())
        {
            // Leaf node. Record its own weight with a fixed zero value for its subtree (not applicable)
            weights.Add(curr.Name, new(curr.Weight, 0));
            return;
        }

        foreach (var subName in curr.SubNames)
        {
            // Recursively build the weights of the tree
            Node subNode = nodes[subName];
            BuildAggregatedWeights(subNode, nodes, weights);
        }

        // Separate out the node's own weight from the weight of its subtree. Together these constitute the total
        // weight of the node (necessary for finding the imbalance). However, the node's own weight is essential
        // for calculating the correction once the imbalance is located.
        long subSum = curr.SubNames.Sum(sub => weights[sub].Total);
        weights.Add(curr.Name, new AggregatedWeight(curr.Weight, subSum));
    }

    private static long? FindWeightCorrection(Node curr, Dictionary<string, Node> nodes, Dictionary<string, AggregatedWeight> aggregated)
    {
        if (curr.SubNames.Any())
        {
            // Prioritize continuing deeper down the tree. We need to work backwards from the leaf nodes to discover the
            // defunct node since the error will propagate all the way back to the root, potentially affecting multiple
            // nodes on the way.
            foreach (string subName in curr.SubNames)
            {
                Node nextNode = nodes[subName];
                long? result = FindWeightCorrection(nextNode, nodes, aggregated);
                if (result.HasValue)
                {
                    return result;
                }
            }
        }
        
        if (!curr.SubNames.Any())
        {
            // Base case. We will never find the solution when inspecting a leaf since we need to be looking at a node with
            // children to find the imbalance.
            return null;
        }

        var subWeights = curr.SubNames.Select(n => aggregated[n]).ToList();
        var subCounts = subWeights.GroupBy(s => s.Total).ToDictionary(s => s.Key, s => s.Count());
        
        if (subCounts.Count == 2)
        {
            // We found an imbalance! There are two distinct total weights found in the subtrees we are inspecting.
            // Find the outlier and then calculate the difference.
            long mismatchWeight = subCounts.Single(kvp => kvp.Value == 1).Key;
            long correctWeight = subCounts.First(kvp => kvp.Value > 1).Key;
            long diff = correctWeight - mismatchWeight;
            
            // Apply the difference to the problem node''s own weight to figure out the weight it ought to have to
            // balance things out.
            AggregatedWeight toCorrect = subWeights.Single(w => w.Total == mismatchWeight);
            long? result = toCorrect.Self + diff;
            
            return result;
        }

        return null;
    }

    private static Node FindRoot(Dictionary<string, Node> nodes)
    {
        HashSet<string> all = nodes.Select(n => n.Key).ToHashSet();
        HashSet<string> notRoot = nodes.SelectMany(kvp => kvp.Value.SubNames).ToHashSet();

        // The root is the only node whose name does not appear in the complete list of sub node names
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
            nodes.Add(name, new Node(name, weight, new string[0]));
        }

        foreach (var line in lines)
        {
            Match m = NonLeafRegex.Match(line);
            if (m.Success)
            {
                string name = m.Groups[1].Value;
                int weight = int.Parse(m.Groups[2].Value);
                string[] childNames = m.Groups[3].Value.Split(", ").ToArray();
                nodes[name] = new Node(name, weight, childNames);
            }
        }

        return nodes;
    }

    private record Node(string Name, int Weight, string[] SubNames);

    private record AggregatedWeight(long Self, long Subtree)
    {
        public long Total => Self + Subtree;
    }
}
