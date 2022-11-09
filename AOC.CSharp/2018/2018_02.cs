namespace AOC.CSharp;

public static class AOC2018_02
{
    public static long Solve1(string[] lines)
    {
        int twos = 0;
        int threes = 0;

        foreach (string line in lines)
        {
            var charCounts = line.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            twos += charCounts.Any(kvp => kvp.Value == 2) ? 1 : 0;
            threes += charCounts.Any(kvp => kvp.Value == 3) ? 1 : 0;
        }

        return twos * threes;
    }

    public static string Solve2(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = i + 1; j < lines.Length; j++)
            {
                string line1 = lines[i];
                string line2 = lines[j];
                int diffs = 0;
                List<char> common = new();
                for (int k = 0; k < line1.Length; k++)
                {
                    if (line1[k] == line2[k])
                    {
                        common.Add(line1[k]);
                    }
                    else
                    {
                        diffs++;
                    }
                }

                if (diffs == 1)
                {
                    return new string(common.ToArray());
                }
            }
        }

        return null;
    }
}
