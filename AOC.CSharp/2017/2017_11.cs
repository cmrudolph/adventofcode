using MoreLinq;

namespace AOC.CSharp;

public static class AOC2017_11
{
    private static readonly List<Tuple<string, string>> CancelPairs =
        new() { Tuple.Create("ne", "sw"), Tuple.Create("nw", "se"), Tuple.Create("n", "s"), };

    private static readonly List<Tuple<string, string, string>> ChangePairs =
        new()
        {
            Tuple.Create("nw", "ne", "n"),
            Tuple.Create("sw", "se", "s"),
            Tuple.Create("ne", "s", "se"),
            Tuple.Create("se", "n", "ne"),
            Tuple.Create("nw", "s", "sw"),
            Tuple.Create("sw", "n", "nw"),
        };

    public static long Solve1(string[] lines)
    {
        List<string> directions = lines[0].Split(',').ToList();
        Dictionary<string, int> counts = InitCounts();

        var initialValues = directions.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        foreach (var kvp in initialValues)
        {
            counts[kvp.Key] = kvp.Value;
        }

        return Dist(counts);
    }

    public static long Solve2(string[] lines)
    {
        List<string> directions = lines[0].Split(',').ToList();
        Dictionary<string, int> counts = InitCounts();

        long max = 0;
        foreach (string d in directions)
        {
            counts[d]++;
            max = Math.Max(max, Dist(counts));
        }

        return max;
    }

    private static Dictionary<string, int> InitCounts()
    {
        return new Dictionary<string, int>
        {
            { "ne", 0 },
            { "se", 0 },
            { "s", 0 },
            { "sw", 0 },
            { "nw", 0 },
            { "n", 0 },
        };
    }

    private static long Dist(Dictionary<string, int> counts)
    {
        var countsCopy = counts.ToDictionary(x => x.Key, x => x.Value);

        bool changed = true;
        while (changed)
        {
            changed = false;
            foreach (var pair in CancelPairs)
            {
                int commonCount = Math.Min(countsCopy[pair.Item1], countsCopy[pair.Item2]);
                if (commonCount > 0)
                {
                    countsCopy[pair.Item1] -= commonCount;
                    countsCopy[pair.Item2] -= commonCount;
                    changed = true;
                }
            }

            foreach (var pair in ChangePairs)
            {
                int commonCount = Math.Min(countsCopy[pair.Item1], countsCopy[pair.Item2]);
                if (commonCount > 0)
                {
                    countsCopy[pair.Item1] -= commonCount;
                    countsCopy[pair.Item2] -= commonCount;
                    countsCopy[pair.Item3] += commonCount;
                    changed = true;
                }
            }
        }

        long dist = countsCopy.Values.Sum();
        return dist;
    }
}
