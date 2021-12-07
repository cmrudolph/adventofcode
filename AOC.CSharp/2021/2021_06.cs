namespace AOC.CSharp;

public static class AOC2021_06
{
    public static long Solve1(string[] lines) => Solve(lines, 80);

    public static long Solve2(string[] lines) => Solve(lines, 256);

    private static long Solve(string[] lines, int rounds)
    {
        long[] counts = new long[9];
        foreach (int i in lines[0].Split(',').Select(int.Parse))
        {
            counts[i]++;
        }

        for (int i = 0; i < rounds; i++)
        {
            long[] newCounts = new long[9];

            for (int j = 1; j < 9; j++)
            {
                newCounts[j - 1] = counts[j];
            }

            // Fish formerly at zero produce another fish that begins at 8
            newCounts[8] = counts[0];

            // Fish formerly at zero get reset to 6
            newCounts[6] += counts[0];

            counts = newCounts;
        }

        return counts.Sum();
    }
}
