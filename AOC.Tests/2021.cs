using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2021
{
    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_1_Sample() => Sample(7L, AOC2021_01.Solve1, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_1_Actual() => Actual(1466L, AOC2021_01.Solve1, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_2_Sample() => Sample(5L, AOC2021_01.Solve2, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_2_Actual() => Actual(1491L, AOC2021_01.Solve2, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_1_Sample() => Sample(150L, AOC2021_02.Solve1, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_1_Actual() => Actual(2322630L, AOC2021_02.Solve1, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_2_Sample() => Sample(900L, AOC2021_02.Solve2, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_2_Actual() => Actual(2105273490L, AOC2021_02.Solve2, "02");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2021_XX_1_Sample() => Sample(-1L, AOC2021_XX.Solve1, "XX");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2021_XX_1_Actual() => Actual(-1L, AOC2021_XX.Solve1, "XX");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2021_XX_2_Sample() => Sample(-1L, AOC2021_XX.Solve2, "XX");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2021_XX_2_Actual() => Actual(-1L, AOC2021_XX.Solve2, "XX");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "sample"));
    }
}
