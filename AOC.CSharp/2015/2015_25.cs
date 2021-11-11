using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2015_25
{
    private static readonly Regex RowColumnRegex = new(@"row (\d+), column (\d+)");

    public static long Solve1(string[] lines)
    {
        Match m = RowColumnRegex.Match(lines[0]);
        int row = int.Parse(m.Groups[1].Value);
        int col = int.Parse(m.Groups[2].Value);

        long code = GenerateCode(Tuple.Create(row, col));

        return code;
    }

    public static long Solve2(string[] lines)
    {
        return 0L;
    }

    private static long GenerateCode(Tuple<int, int> target)
    {
        long code = 20151125L;

        int i = 2;
        while (true)
        {
            int counter = i;

            for (int j = 1; j <= i; j++)
            {
                code *= 252533L;
                code %= 33554393L;
                if (Tuple.Create(counter, j).Equals(target))
                {
                    return code;
                }

                counter--;
            }

            i++;
        }
    }
}
