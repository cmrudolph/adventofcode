using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2018_03
{
    private static readonly Regex Re = new(@"#\d+ @ (\d+),(\d+): (\d+)x(\d+)");

    public static long Solve1(string[] lines)
    {
        return Solve(lines).Item1;
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines).Item2;
    }

    private static (long, long) Solve(string[] lines)
    {
        int[,] grid = new int[1000, 1000];

        List<Parsed> parsedLines = lines.Select(Parse).ToList();
        foreach (Parsed p in parsedLines)
        {
            for (int row = p.RowOffset; row < p.RowOffset + p.NumRows; row++)
            {
                for (int col = p.ColOffset; col < p.ColOffset + p.NumCols; col++)
                {
                    grid[row, col]++;
                }
            }
        }

        long overlapping = 0;
        for (int row = 0; row < 1000; row++)
        {
            for (int col = 0; col < 1000; col++)
            {
                overlapping += grid[row, col] > 1 ? 1 : 0;
            }
        }

        int solution2 = 0;
        foreach (Parsed p in parsedLines)
        {
            bool isTheOne = true;
            for (int row = p.RowOffset; isTheOne && row < p.RowOffset + p.NumRows; row++)
            {
                for (int col = p.ColOffset; isTheOne && col < p.ColOffset + p.NumCols; col++)
                {
                    if (grid[row, col] > 1)
                    {
                        isTheOne = false;
                    }
                }
            }

            solution2++;

            if (isTheOne)
            {
                return (overlapping, solution2);
            }
        }

        return (-1, -1);
    }

    private static Parsed Parse(string line)
    {
        Match m = Re.Match(line);
        return new(
            int.Parse(m.Groups[1].Value),
            int.Parse(m.Groups[2].Value),
            int.Parse(m.Groups[3].Value),
            int.Parse(m.Groups[4].Value)
        );
    }

    private record Parsed(int ColOffset, int RowOffset, int NumCols, int NumRows);
}
