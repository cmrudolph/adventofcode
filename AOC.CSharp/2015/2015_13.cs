using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2015_13
{
    private static readonly Regex regex =
        new(@"(\w+) would (\w+) (\d+) happiness units by sitting next to (\w+)\.");

    public static long Solve1(string[] lines)
    {
        Dictionary<Tuple<string, string>, int> lookup = BuildAmountLookup(lines);
        string[] names = GetNames(lookup);
        List<List<Tuple<string, string>>> permutations = GetAllPermutations(names);
        long max = FindMaximumHappiness(permutations, lookup);

        return max;
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<Tuple<string, string>, int> lookup = BuildAmountLookup(lines);
        string[] names = GetNames(lookup);

        foreach (string name in names)
        {
            lookup.Add(Tuple.Create(name, "Chris"), 0);
            lookup.Add(Tuple.Create("Chris", name), 0);
        }

        names = names.Concat(new[] { "Chris" }).ToArray();

        List<List<Tuple<string, string>>> permutations = GetAllPermutations(names);
        long max = FindMaximumHappiness(permutations, lookup);

        return max;
    }

    private static Dictionary<Tuple<string, string>, int> BuildAmountLookup(string[] lines)
    {
        return lines
            .Select(ParseLine)
            .SelectMany(p => p)
            .GroupBy(f => f.NamePair)
            .ToDictionary(g => g.Key, g => g.Select(p => p.Amount).Sum());
    }

    private static string[] GetNames(Dictionary<Tuple<string, string>, int> lookup)
    {
        HashSet<string> names = new();
        foreach (Tuple<string, string> key in lookup.Keys)
        {
            names.Add(key.Item1);
            names.Add(key.Item2);
        }

        return names.ToArray();
    }

    private static List<List<Tuple<string, string>>> GetAllPermutations(string[] names)
    {
        List<List<Tuple<string, string>>> permutations = new();
        Permute(names, names.Length, 0, permutations);

        return permutations;
    }

    private static long FindMaximumHappiness(
        List<List<Tuple<string, string>>> permutations,
        Dictionary<Tuple<string, string>, int> lookup
    )
    {
        return permutations.Select(perm => perm.Select(perm => lookup[perm]).Sum()).Max();
    }

    private static IEnumerable<Parsed> ParseLine(string line)
    {
        Match m = regex.Match(line);

        string name1 = m.Groups[1].Value;
        string name2 = m.Groups[4].Value;
        string gainLoss = m.Groups[2].Value;
        int parsedAmount = int.Parse(m.Groups[3].Value);
        int finalAmount = gainLoss == "gain" ? parsedAmount : -parsedAmount;

        return new[]
        {
            new Parsed { NamePair = Tuple.Create(name1, name2), Amount = finalAmount },
            new Parsed { NamePair = Tuple.Create(name2, name1), Amount = finalAmount }
        };
    }

    private static void Permute(
        string[] names,
        int n,
        int i,
        List<List<Tuple<string, string>>> permutations
    )
    {
        void Swap(string[] arr, int idx1, int idx2)
        {
            string temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }

        if (i >= (n - 1))
        {
            List<Tuple<string, string>> permutation = new();
            for (int j = 0; j < names.Length - 1; j++)
            {
                permutation.Add(Tuple.Create(names[j], names[j + 1]));
            }

            permutation.Add(Tuple.Create(names[names.Length - 1], names[0]));
            permutations.Add(permutation);
        }
        else
        {
            Permute(names, n, i + 1, permutations);
            {
                for (int j = i + 1; j < n; j++)
                {
                    Swap(names, i, j);
                    Permute(names, n, i + 1, permutations);
                    Swap(names, i, j);
                }
            }
        }
    }

    private class Parsed
    {
        public Tuple<string, string> NamePair { get; set; }

        public int Amount { get; set; }
    }
}
