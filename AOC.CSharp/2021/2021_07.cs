namespace AOC.CSharp;

public static class AOC2021_07
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines, max => Enumerable.Range(0, max + 1).Select(x => x).ToArray());
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, BuildCostLookup2);
    }

    private static long Solve(string[] lines, Func<int, int[]> buildCostLookup)
    {
        int[] positions = lines[0].Split(',').Select(int.Parse).OrderBy(x => x).ToArray();
        int min = positions[0];
        int max = positions[positions.Length - 1];

        int[] costLookup = buildCostLookup(max);
        int bestCost = int.MaxValue;
        for (int i = min; i <= max; i++)
        {
            int cost = positions.Select(x => costLookup[Math.Abs(x - i)]).Sum();
            bestCost = Math.Min(bestCost, cost);
        }
        return bestCost;
    }

    private static int[] BuildCostLookup2(int max)
    {
        List<int> lookup = new();
        int prevCost = 0;
        for (int i = 0; i <= max; i++)
        {
            int cost = prevCost + i;
            prevCost += i;
            lookup.Add(cost);
        }

        return lookup.ToArray();
    }
}
