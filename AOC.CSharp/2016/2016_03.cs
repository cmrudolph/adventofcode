using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp;

public static class AOC2016_03
{
    public static long Solve1(string[] lines)
    {
        return lines
            .Select(Parse1)
            .Select(TestForValidTriangle)
            .Count(result => result);
    }

    public static long Solve2(string[] lines)
    {
        return Parse2(lines)
            .Select(TestForValidTriangle)
            .Count(result => result);
    }

    private static int[] Parse1(string line)
    {
        string[] splits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return splits.Select(int.Parse).ToArray();
    }

    private static int[][] Parse2(string[] lines)
    {
        int[][] splits = lines
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(splits => splits.Select(int.Parse).ToArray())
            .ToArray();

        List<int[]> allSides = new();
        for (int col = 0; col < 3; col++)
        {
            for (int row = 0; row < lines.Length; row += 3)
            {
                int[] sides = new int[3];
                sides[0] = splits[row][col];
                sides[1] = splits[row + 1][col];
                sides[2] = splits[row + 2][col];
                allSides.Add(sides);
            }
        }

        return allSides.ToArray();
    }

    private static bool TestForValidTriangle(int[] sides)
    {
        Console.WriteLine(string.Join(" ", sides));
        var ordered = sides.OrderBy(s => s).ToArray();
        return (ordered[0] + ordered[1]) > ordered[2];
    }
}
