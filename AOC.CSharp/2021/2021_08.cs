namespace AOC.CSharp;

public static class AOC2021_08
{
    public static long Solve1(string[] lines)
    {
        int result = 0;
        HashSet<int> lengths = new() { 2, 3, 4, 7 };
        foreach (string line in lines)
        {
            var splits = line.Split(" | ");
            string[] digitStrings = splits[1].Split(' ').ToArray();
            result += digitStrings.Count(s => lengths.Contains(s.Length));
        }
        return result;
    }

    public static long Solve2(string[] lines)
    {
        return lines.Select(CalculateOutputValue).Sum();
    }

    private static int CalculateOutputValue(string line)
    {
        List<string> signals = line.Split(" | ")[0]
            .Split(' ')
            .Select(s => new string(s.OrderBy(c => c).ToArray()))
            .ToList();
        List<string> outputStrings = line.Split(" | ")[1]
            .Split(' ')
            .Select(s => new string(s.OrderBy(c => c).ToArray()))
            .ToList();

        Dictionary<int, List<Entry>> byLength = new();
        foreach (string s in signals)
        {
            List<Entry> list;
            if (!byLength.TryGetValue(s.Length, out list))
            {
                list = new();
                byLength.Add(s.Length, list);
            }
            list.Add(new Entry(s, s.ToCharArray().ToHashSet()));
        }

        Entry one = byLength[2][0];
        Entry seven = byLength[3][0];
        Entry four = byLength[4][0];
        Entry eight = byLength[7][0];

        Entry six = byLength[6].Single(x => x.Set.Except(seven.Set).Count() == 4);
        byLength[6].Remove(six);

        Entry nine = byLength[6].Single(x => x.Set.Except(four.Set).Count() == 2);
        byLength[6].Remove(nine);

        Entry zero = byLength[6].Single();
        byLength[6].Remove(zero);

        Entry three = byLength[5].Single(x => x.Set.Except(one.Set).Count() == 3);
        byLength[5].Remove(three);

        Entry five = byLength[5].Single(x => x.Set.Except(six.Set).Count() == 0);
        byLength[5].Remove(five);

        Entry two = byLength[5].Single();

        Dictionary<string, int> values = new();
        values.Add(zero.Value, 0);
        values.Add(one.Value, 1);
        values.Add(two.Value, 2);
        values.Add(three.Value, 3);
        values.Add(four.Value, 4);
        values.Add(five.Value, 5);
        values.Add(six.Value, 6);
        values.Add(seven.Value, 7);
        values.Add(eight.Value, 8);
        values.Add(nine.Value, 9);

        int outputValue = int.Parse(string.Join("", outputStrings.Select(s => values[s])));

        return outputValue;
    }

    private record Entry(string Value, HashSet<char> Set);
}
