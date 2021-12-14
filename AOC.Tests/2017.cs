using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2017
{
    [TestCase("1122", 3)]
    [TestCase("1111", 4)]
    [TestCase("1234", 0)]
    [TestCase("91212129", 9)]
    [Category("Fast")]
    public void AOC2017_01_1_Cases(string input, int expected)
    {
        long result = AOC2017_01.Solve1(new[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_01_1_Sample() => Sample(9L, AOC2017_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2017_01_1_Actual() => Actual(1144L, AOC2017_01.Solve1, "01");

    [TestCase("1212", 6)]
    [TestCase("1221", 0)]
    [TestCase("123425", 4)]
    [TestCase("123123", 12)]
    [TestCase("12131415", 4)]
    [Category("Fast")]
    public void AOC2017_01_2_Cases(string input, int expected)
    {
        long result = AOC2017_01.Solve2(new[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_01_2_Sample() => Sample(6L, AOC2017_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2017_01_2_Actual() => Actual(1194L, AOC2017_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2017_02_1_Sample() => Sample(18L, AOC2017_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2017_02_1_Actual() => Actual(45972L, AOC2017_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2017_02_2_Sample() => Sample(9L, AOC2017_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2017_02_2_Actual() => Actual(326L, AOC2017_02.Solve2, "02");

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
