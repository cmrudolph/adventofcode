using MoreLinq;

namespace AOC.CSharp;

public static class AOC2021_01
{
    public static long Solve1(string[] lines)
    {
        return lines.Select(int.Parse).Pairwise((x1, x2) => x2 > x1).Count(x => x == true);
    }

    public static long Solve2(string[] lines)
    {
        return lines
            .Select(int.Parse)
            .WindowLeft(3)
            .Select(l => l.Sum())
            .Pairwise((x1, x2) => x2 > x1)
            .Count(x => x == true);
    }
}
