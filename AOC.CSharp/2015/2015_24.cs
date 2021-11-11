namespace AOC.CSharp;

public static class AOC2015_24
{
    private const int MaxCount = 6;

    public static long Solve1(string[] lines)
    {
        return Solve(lines, 3);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, 4);
    }

    private static long Solve(string[] lines, int numGroups)
    {
        List<long> values = Parse(lines).OrderByDescending(v => v).ToList();

        List<HashSet<long>> rawSumGroups = new();
        HashSet<long> group = new();
        long target = values.Sum() / numGroups;
        FindGroups(values, group, rawSumGroups, target, MaxCount);

        List<Group> groups = rawSumGroups.Select(g => new Group(g.ToList())).ToList();
        List<Solution> solutions = groups.Select(
                g => new Solution
                { Group1Count = g.Count, QuantumEntanglement = g.QuantumEntanglement })
            .ToList();
        var first = groups.OrderBy(s => s.Count).ThenBy(s => s.QuantumEntanglement).First();

        return first.QuantumEntanglement;
    }

    private static long[] Parse(string[] lines)
    {
        return lines.Select(long.Parse).ToArray();
    }

    private static void FindGroups(
        List<long> values,
        HashSet<long> group,
        List<HashSet<long>> results,
        long sumTarget,
        int maxCount)
    {
        if (group.Count > maxCount)
        {
            return;
        }

        if (group.Sum() > sumTarget)
        {
            return;
        }

        if (group.Sum() == sumTarget)
        {
            if (!results.Any(r => r.SequenceEqual(group)))
            {
                results.Add(new HashSet<long>(group));
            }

            return;
        }

        if (!values.Any())
        {
            return;
        }

        long currVal = values[values.Count - 1];
        group.Add(currVal);
        values.Remove(currVal);
        FindGroups(values, group, results, sumTarget, maxCount);
        group.Remove(currVal);
        FindGroups(values, group, results, sumTarget, maxCount);
        values.Add(currVal);
    }

    private class Group
    {
        public Group(List<long> values)
        {
            Values = values;
        }

        public List<long> Values { get; }

        public int Count => Values.Count;

        public long Weight => Values.Sum();

        public long QuantumEntanglement => Values.Aggregate(1L, (acc, v) => acc * v);
    }

    private class Solution
    {
        public int Group1Count { get; set; }
        public long QuantumEntanglement { get; set; }
    }
}
