namespace AOC.CSharp;

public static class AOC2022_01
{
    public static long Solve1(string[] lines) => Sums(lines).Max();

    public static long Solve2(string[] lines) => Sums(lines).OrderByDescending(x => x).Take(3).Sum();

    private static int[] Sums(string[] lines) =>
        string.Join('|', lines)
            .Split("||")
            .Select(grp => grp.Split("|").Select(int.Parse).Sum())
            .ToArray();
}
