namespace AOC.CSharp;

public static class AOC2018_11
{
    public static string Solve1(string[] lines)
    {
        var result = Solve(lines, new[] { 3 });

        return $"{result.X},{result.Y}";
    }

    public static string Solve2(string[] lines)
    {
        var sizes = Enumerable.Range(2, 300).ToArray();
        var result = Solve(lines, sizes);

        return $"{result.X},{result.Y},{result.Grid}";
    }

    private static Result Solve(string[] lines, int[] sizes)
    {
        int input = int.Parse(lines[0]);
        var levels = CalculateLevels(1, 300, input);

        long best = 0;
        int bestX = 0;
        int bestY = 0;
        int bestGrid = 0;

        foreach (int grid in sizes)
        {
            long[] colSums = new long[301];

            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x < grid; x++)
                {
                    colSums[y] += levels[x, y];
                }
            }

            for (int x = grid; x <= 301 - grid; x++)
            {
                for (int y = grid; y <= 301 - grid; y++)
                {
                    colSums[y] -= levels[x - grid, y];
                    colSums[y] += levels[x, y];
                }

                long sum = 0;
                for (int y = 1; y < grid; y++)
                {
                    sum += colSums[y];
                }

                if (sum > best)
                {
                    best = sum;
                    bestX = 1;
                    bestY = 1;
                    bestGrid = grid;
                }

                for (int y = grid; y <= 301 - grid; y++)
                {
                    sum -= colSums[y - grid];
                    sum += colSums[y];

                    if (sum > best)
                    {
                        best = sum;
                        bestX = x - grid + 1;
                        bestY = y - grid + 1;
                        bestGrid = grid;
                    }
                }
            }
        }

        return new Result(bestX, bestY, bestGrid, best);
    }

    private static long[,] CalculateLevels(int min, int max, int input)
    {
        long[,] levels = new long[301, 301];

        for (int x = min; x <= max; x++)
        {
            for (int y = min; y <= max; y++)
            {
                levels[x, y] = CalculatePowerLevel(x, y, input);
            }
        }

        return levels;
    }

    private static long CalculatePowerLevel(int x, int y, int input)
    {
        long rackId = x + 10;
        long power = rackId * y;
        power += input;
        power *= rackId;
        power /= 100;
        long digit = power % 10;

        return digit - 5;
    }

    private record Result(int X, int Y, int Grid, long Best);
}
