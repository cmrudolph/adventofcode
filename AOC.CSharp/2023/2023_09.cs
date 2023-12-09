namespace AOC.CSharp;

public static class AOC2023_09
{
    public static long Solve1(string[] lines) => Solve(lines, false);

    public static long Solve2(string[] lines) => Solve(lines, true);

    private static long Solve(string[] lines, bool reversed)
    {
        List<long[]> parsed = lines.Select(x => Parse(x, reversed)).ToList();

        return parsed.Sum(FindNext);
    }

    private static long FindNext(long[] orig)
    {
        Recurse(orig);

        return orig[^1];
    }

    private static long[] Parse(string line, bool reversed)
    {
        long[] arr = line.Split(" ").Select(long.Parse).ToArray();

        return reversed
            ? arr.Reverse().Concat(new long[] { 0 }).ToArray()
            : arr.Concat(new long[] { 0 }).ToArray();
    }

    private static void Recurse(long[] curr)
    {
        if (curr.All(x => x == 0))
        {
            return;
        }

        long[] next = new long[curr.Length - 1];
        for (int i = 0; i < curr.Length - 2; i++)
        {
            next[i] = curr[i + 1] - curr[i];
        }

        Recurse(next);

        curr[^1] = curr[^2] + next[^1];
    }
}
