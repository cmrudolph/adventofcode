using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2018
{
    [Ignore("TODO")]
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [Category("New")]
    public void AOC2018_XX_1_Cases(string input, int expected)
    {
        long result = AOC2018_XX.Solve1(new[] { input });
        result.Should().Be(expected);
    }

    [Ignore("TODO")]
    [TestCase("3", 3)]
    [TestCase("4", 4)]
    [Category("New")]
    public void AOC2018_XX_2_Cases(string input, int expected)
    {
        long result = AOC2018_XX.Solve2(new[] { input });
        result.Should().Be(expected);
    }

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2018_XX_1_Sample() => Sample(9L, AOC2018_XX.Solve1, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2018_XX_1_Actual() => Actual(1144L, AOC2018_XX.Solve1, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2018_XX_2_Sample() => Sample(6L, AOC2018_XX.Solve2, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2018_XX_2_Actual() => Actual(1194L, AOC2018_XX.Solve2, "XX");

    [Test, Category("Fast")]
    public void AOC2018_01_1_Sample() => Sample(3L, AOC2018_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2018_01_1_Actual() => Actual(576L, AOC2018_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2018_01_2_Sample() => Sample(2L, AOC2018_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2018_01_2_Actual() => Actual(77674L, AOC2018_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2018_02_1_Sample() => Sample(12L, AOC2018_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2018_02_1_Actual() => Actual(8892L, AOC2018_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2018_02_2_Sample() => Sample("abcde", AOC2018_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2018_02_2_Actual() => Actual("zihwtxagifpbsnwleydukjmqv", AOC2018_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2018_03_1_Sample() => Sample(4L, AOC2018_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2018_03_1_Actual() => Actual(104126L, AOC2018_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2018_03_2_Sample() => Sample(3L, AOC2018_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2018_03_2_Actual() => Actual(695L, AOC2018_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2018_04_1_Sample() => Sample(240L, AOC2018_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2018_04_1_Actual() => Actual(39698L, AOC2018_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2018_04_2_Sample() => Sample(4455L, AOC2018_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2018_04_2_Actual() => Actual(14920L, AOC2018_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2018_05_1_Sample() => Sample(10L, AOC2018_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2018_05_1_Actual() => Actual(10584L, AOC2018_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2018_05_2_Sample() => Sample(4L, AOC2018_05.Solve2, "05");

    [Test, Category("Slow")]
    public void AOC2018_05_2_Actual() => Actual(6968L, AOC2018_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2018_06_1_Sample() => Sample(17L, AOC2018_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2018_06_1_Actual() => Actual(3238L, AOC2018_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2018_06_2_Sample() => Sample(16L, x => AOC2018_06.Solve2(x, 32), "06");

    [Test, Category("Fast")]
    public void AOC2018_06_2_Actual() => Actual(45046L, x => AOC2018_06.Solve2(x, 10000), "06");

    [Test, Category("New")]
    public void AOC2018_07_1_Sample() => Sample("CABDFE", AOC2018_07.Solve1, "07");

    [Test, Category("New")]
    public void AOC2018_07_1_Actual() => Actual("AHJDBEMNFQUPVXGCTYLWZKSROI", AOC2018_07.Solve1, "07");

    [Test, Category("New")]
    public void AOC2018_07_2_Sample() => Sample(6L, AOC2018_07.Solve2, "07");

    [Test, Category("New")]
    public void AOC2018_07_2_Actual() => Actual(1194L, AOC2018_07.Solve2, "07");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2018", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2018", day, "sample"));
    }
}
