using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2017
{
    [Test, Category("Fast")]
    public void AOC2017_03_1_Sample() => Sample(31L, AOC2017_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2017_03_1_Actual() => Actual(438L, AOC2017_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2017_03_2_Sample() => Sample(1968L, AOC2017_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2017_03_2_Actual() => Actual(266330L, AOC2017_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2017_04_1_Sample() => Sample(2L, AOC2017_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2017_04_1_Actual() => Actual(325L, AOC2017_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2017_04_2_Sample() => Sample(2L, AOC2017_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2017_04_2_Actual() => Actual(119L, AOC2017_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2017_05_1_Sample() => Sample(5L, AOC2017_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2017_05_1_Actual() => Actual(374269L, AOC2017_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2017_05_2_Sample() => Sample(10L, AOC2017_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2017_05_2_Actual() => Actual(27720699L, AOC2017_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2017_06_1_Sample() => Sample(5L, AOC2017_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2017_06_1_Actual() => Actual(3156L, AOC2017_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2017_06_2_Sample() => Sample(4L, AOC2017_06.Solve2, "06");

    [Test, Category("Fast")]
    public void AOC2017_06_2_Actual() => Actual(1610L, AOC2017_06.Solve2, "06");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2017_XX_1_Sample() => Sample(-1L, AOC2017_XX.Solve1, "XX");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2017_XX_1_Actual() => Actual(-1L, AOC2017_XX.Solve1, "XX");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2017_XX_2_Sample() => Sample(-1L, AOC2017_XX.Solve2, "XX");

    //[Test, Property("Speed", "New")]
    //[Ignore("Future")]
    //public void AOC2017_XX_2_Actual() => Actual(-1L, AOC2017_XX.Solve2, "XX");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2017", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2017", day, "sample"));
    }
}
