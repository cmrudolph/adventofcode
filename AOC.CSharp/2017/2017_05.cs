namespace AOC.CSharp;

public static class AOC2017_05
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines, x => 1);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, x => x >= 3 ? -1 : 1);
    }

    private static long Solve(string[] lines, Func<int, int> calcAmount)
    {
        int[] values = lines.Select(x => int.Parse(x)).ToArray();
        int i = 0;
        int steps = 0;
        while (i >= 0 && i <= values.Length - 1)
        {
            int jmpAmount = values[i];
            int changeAmount = calcAmount(jmpAmount);
            values[i] += changeAmount;
            i += jmpAmount;
            steps++;
        }
        return steps;
    }
}
