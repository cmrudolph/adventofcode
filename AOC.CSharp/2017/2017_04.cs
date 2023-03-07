namespace AOC.CSharp;

public static class AOC2017_04
{
    public static long Solve1(string[] lines)
    {
        return lines.Count(
            x =>
                x.Split(' ')
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, x => x.Count())
                    .All(kvp => kvp.Value == 1)
        );
    }

    public static long Solve2(string[] lines)
    {
        return lines.Count(
            x =>
                x.Split(' ')
                    .Select(x => new string(x.OrderBy(s => s).ToArray()))
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, x => x.Count())
                    .All(kvp => kvp.Value == 1)
        );
    }
}
