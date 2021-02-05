using System;
using Xunit;

public static class Utils
{
    public static string[] ReadInput(string year, string problem, string suffix)
    {
        return System.IO.File.ReadAllLines($"../../../../input/{year}/{problem}-{suffix}.txt");
    }

    public static void SolveAndValidate(
        Tuple<long, long> expected,
        Func<string[], Tuple<long, long>> solver,
        string[] lines)
    {
        var result = solver(lines);
        Assert.Equal(expected, result);
    }
}
