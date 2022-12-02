using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2022
{
    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_1_Sample() => Sample(9L, AOC2022_XX.Solve1, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_1_Actual() => Actual(24000L, AOC2022_XX.Solve1, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_2_Sample() => Sample(6L, AOC2022_XX.Solve2, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_2_Actual() => Actual(1194L, AOC2022_XX.Solve2, "XX");

    [Test, Category("Fast")]
    public void AOC2022_01_1_Sample() => Sample(24000, AOC2022_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2022_01_1_Actual() => Actual(71124, AOC2022_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2022_01_2_Sample() => Sample(45000L, AOC2022_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2022_01_2_Actual() => Actual(204639, AOC2022_01.Solve2, "01");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2022", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2022", day, "sample"));
    }
}
