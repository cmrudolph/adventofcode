namespace AOC.CSharp;

public static class AOC2022_03
{
    public static long Solve1(string[] lines)
    {
        return lines.Select(FindCommon1).Select(Cost).ToList().Sum();
    }

    public static long Solve2(string[] lines)
    {
        return lines.Chunk(3).Select(FindCommon2).Select(Cost).ToList().Sum();
    }

    private static int Cost(char c) => char.ToLower(c) - 'a' + 1 + (char.IsUpper(c) ? 26 : 0);

    private static char FindCommon1(string line)
    {
        string first = line.Substring(0, (line.Length / 2));
        string last = line.Substring(line.Length / 2);

        HashSet<char> firstChars = first.ToCharArray().ToHashSet();
        HashSet<char> lastChars = last.ToCharArray().ToHashSet();

        return firstChars.Intersect(lastChars).Single();
    }

    private static char FindCommon2(string[] lines)
    {
        return lines
            .Skip(1)
            .Aggregate(lines[0].ToHashSet(), (common, other) => common.Intersect(other).ToHashSet())
            .Single();
    }
}
