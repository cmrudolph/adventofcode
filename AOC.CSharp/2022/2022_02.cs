namespace AOC.CSharp;

public static class AOC2022_02
{
    public static long Solve1(string[] lines)
    {
        return Cost(lines);
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<string, string> toWin = new() { { "A", "Y" }, { "B", "Z" }, { "C", "X" }, };
        Dictionary<string, string> toDraw = new() { { "A", "X" }, { "B", "Y" }, { "C", "Z" }, };
        Dictionary<string, string> toLose = new() { { "A", "Z" }, { "B", "X" }, { "C", "Y" }, };

        List<string> newLines = new();

        foreach (string line in lines)
        {
            string[] splits = line.Split(" ");
            string theirChoice = splits[0];
            string outcome = splits[1];

            string yourChoice = outcome switch
            {
                "X" => toLose[theirChoice],
                "Y" => toDraw[theirChoice],
                "Z" => toWin[theirChoice],
                _ => throw new NotSupportedException(),
            };

            newLines.Add($"{theirChoice} {yourChoice}");
        }

        return Cost(newLines.ToArray());
    }

    private static long Cost(string[] lines)
    {
        Dictionary<string, int> values =
            new()
            {
                { "A X", 4 },
                { "A Y", 8 },
                { "A Z", 3 },
                { "B X", 1 },
                { "B Y", 5 },
                { "B Z", 9 },
                { "C X", 7 },
                { "C Y", 2 },
                { "C Z", 6 },
            };

        return lines.Select(x => values[x]).Sum();
    }
}
