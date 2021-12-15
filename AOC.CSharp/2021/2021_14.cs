namespace AOC.CSharp;

public static class AOC2021_14
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines, 10);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, 40);
    }

    public static long Solve(string[] lines, int iterations)
    {
        var lookup = BuildLookup(lines.Skip(2));
        var counts = BuildInitialCounts(lines[0]);

        for (int i = 0; i < iterations; i++)
        {
            counts = UpdatePairCounts(counts, lookup);
        }

        (long min, long max) = FindCharCounts(counts, lines[0][0].ToString(), lines[0][^1].ToString());
        return max - min;
    }

    private static Dictionary<string, long> UpdatePairCounts(Dictionary<string, long> counts, Dictionary<string, string[]> lookup)
    {
        // Init the dictionary to avoid having to check for key existence. Use a new dictionary to avoid contaminating
        // state when performing the lookups below
        Dictionary<string, long> newCounts = lookup.Values
            .SelectMany(v => v)
            .Distinct()
            .ToDictionary(v => v, _ => 0L);

        // The number of times we have for pair ORIG is replicated into each of the new pairs that ORIG produces
        // when we perform our lookup
        foreach (var kvp in counts)
        {
            var newKeys = lookup[kvp.Key];
            newCounts[newKeys[0]] += kvp.Value;
            newCounts[newKeys[1]] += kvp.Value;
        }

        return newCounts;
    }

    private static (long min, long max) FindCharCounts(Dictionary<string, long> pairCounts, string first, string last)
    {
        // Init the dictionary to avoid having to check for key existence
        Dictionary<string, long> charCounts = pairCounts.Keys
            .SelectMany(k => new[] { k[0], k[1] })
            .Select(c => c.ToString())
            .Distinct()
            .ToDictionary(c => c, _ => 0L);

        // Special case the first and last chars of the template. They don't change and don't fit with the standard
        // "divide by two" logic for everything in the middle
        charCounts[first] = 1;
        charCounts[last] = 1;

        // Count all occurrences of each character. This will double count items since characters (except the first
        // and last ones) will occur in two pairs. We have already accounted for the special first and last cases and
        // will fix the double counting later
        foreach (var kvp in pairCounts)
        {
            string ch1 = kvp.Key[0].ToString();
            string ch2 = kvp.Key[1].ToString();
            charCounts[ch1] += kvp.Value;
            charCounts[ch2] += kvp.Value;
        }

        // Solve the double counting problem by cutting things in half. The first and last will have a legit
        // occurrence dropped, but we already started them off with +1 to compensate
        foreach (string key in charCounts.Keys)
        {
            charCounts[key] /= 2;
        }

        return (charCounts.Values.Min(), charCounts.Values.Max());
    }

    private static Dictionary<string, long> BuildInitialCounts(string template)
    {
        Dictionary<string, long> counts = new();

        for (int i = 0; i < template.Length - 1; i++)
        {
            string pair = template[i].ToString() + template[i + 1];
            if (!counts.ContainsKey(pair))
            {
                counts.Add(pair, 0);
            }
            counts[pair]++;
        }

        return counts;
    }

    private static Dictionary<string, string[]> BuildLookup(IEnumerable<string> lines)
    {
        Dictionary<string, string[]> results = new();

        // Build a lookup that determines which two pairs are built when a pair is processed. The raw data gives
        // us a pair -> char mapping, but by instead considering pair -> [pair1, pair2] we are able to simplify
        // our later counting task
        foreach (string line in lines)
        {
            string[] splits = line.Split(" -> ");
            string val1 = splits[0][0] + splits[1];
            string val2 = splits[1] + splits[0][1];
            results.Add(splits[0], new[] { val1, val2 });
        }

        return results;
    }
}
