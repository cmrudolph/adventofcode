using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests.AOC2018;

[Parallelizable(ParallelScope.All)]
public class Tests
{
    [Ignore("TODO")]
    private class DayXX
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

        [Test, Category("New")]
        public void AOC2018_XX_2_Actual() => Actual(1194L, AOC2018_XX.Solve2, "XX");
    }

    private class Day01
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(3L, AOC2018_01.Solve1, "01");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(576L, AOC2018_01.Solve1, "01");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2L, AOC2018_01.Solve2, "01");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(77674L, AOC2018_01.Solve2, "01");
    }

    private class Day02
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(12L, AOC2018_02.Solve1, "02");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(8892L, AOC2018_02.Solve1, "02");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample("abcde", AOC2018_02.Solve2, "02");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual("zihwtxagifpbsnwleydukjmqv", AOC2018_02.Solve2, "02");
    }

    private class Day03
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(4L, AOC2018_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(104126L, AOC2018_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(3L, AOC2018_03.Solve2, "03");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(695L, AOC2018_03.Solve2, "03");
    }

    private class Day04
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(240L, AOC2018_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(39698L, AOC2018_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(4455L, AOC2018_04.Solve2, "04");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(14920L, AOC2018_04.Solve2, "04");
    }

    private class Day05
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(10L, AOC2018_05.Solve1, "05");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(10584L, AOC2018_05.Solve1, "05");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(4L, AOC2018_05.Solve2, "05");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(6968L, AOC2018_05.Solve2, "05");
    }

    private class Day06
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(17L, AOC2018_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(3238L, AOC2018_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(16L, x => AOC2018_06.Solve2(x, 32), "06");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(45046L, x => AOC2018_06.Solve2(x, 10000), "06");
    }

    private class Day07
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample("CABDFE", AOC2018_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual("AHJDBEMNFQUPVXGCTYLWZKSROI", AOC2018_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(15L, x => AOC2018_07.Solve2(x, 2, 0), "07");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1031L, x => AOC2018_07.Solve2(x, 5, 60), "07");
    }

    private class Day08
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(138, AOC2018_08.Solve1, "08");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(49426, AOC2018_08.Solve1, "08");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(66, AOC2018_08.Solve2, "08");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(40688, AOC2018_08.Solve2, "08");
    }

    private class Day09
    {
        [TestCase("10 players; last marble is worth 1618 points", 8317)]
        [TestCase("13 players; last marble is worth 7999 points", 146373)]
        [TestCase("17 players; last marble is worth 1104 points", 2764)]
        [TestCase("21 players; last marble is worth 6111 points", 54718)]
        [TestCase("30 players; last marble is worth 5807 points", 37305)]
        [Category("Fast")]
        public void _1_Cases(string input, int expected)
        {
            long result = AOC2018_09.Solve1(new[] { input });
            result.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _1_Sample() => Sample(32, AOC2018_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(408679, AOC2018_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(22563L, AOC2018_09.Solve2, "09");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(3443939356L, AOC2018_09.Solve2, "09");
    }

    private class Day10
    {
        // Look at console output to see part 1 message
        [Test, Category("Fast")]
        public void AOC2018_10_1_Sample() => Sample(3L, AOC2018_10.Solve1, "10");

        // Look at console output to see part 1 message
        [Test, Category("Fast")]
        public void AOC2018_10_1_Actual() => Actual(10831L, AOC2018_10.Solve1, "10");
    }

    private class Day11
    {
        [Test, Category("Fast")]
        public void _1_Actual() => Actual("19,17", AOC2018_11.Solve1, "11");

        [Test, Category("New")]
        public void _2_Actual() => Actual("BEYONCE", AOC2018_11.Solve2, "11");
    }

    [Ignore("TODO")]
    private class Day12
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_12.Solve1, "12");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_12.Solve1, "12");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_12.Solve2, "12");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_12.Solve2, "12");
    }

    [Ignore("TODO")]
    private class Day13
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_13.Solve1, "13");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_13.Solve1, "13");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_13.Solve2, "13");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_13.Solve2, "13");
    }

    [Ignore("TODO")]
    private class Day14
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_14.Solve1, "14");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_14.Solve1, "14");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_14.Solve2, "14");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_14.Solve2, "14");
    }

    [Ignore("TODO")]
    private class Day15
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_15.Solve1, "15");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_15.Solve1, "15");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_15.Solve2, "15");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_15.Solve2, "15");
    }

    [Ignore("TODO")]
    public class Day16
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_16.Solve1, "16");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_16.Solve1, "16");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_16.Solve2, "16");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_16.Solve2, "16");
    }

    [Ignore("TODO")]
    public class Day17
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_17.Solve1, "17");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_17.Solve1, "17");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_17.Solve2, "17");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_17.Solve2, "17");
    }

    [Ignore("TODO")]
    public class Day18
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_18.Solve1, "18");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_18.Solve1, "18");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_18.Solve2, "18");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_18.Solve2, "18");
    }

    [Ignore("TODO")]
    public class Day19
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_19.Solve1, "19");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_19.Solve1, "19");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_19.Solve2, "19");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_19.Solve2, "19");
    }

    [Ignore("TODO")]
    public class Day20
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_20.Solve1, "20");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_20.Solve1, "20");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_20.Solve2, "20");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_20.Solve2, "20");
    }

    [Ignore("TODO")]
    public class Day21
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_21.Solve1, "21");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_21.Solve1, "21");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_21.Solve2, "21");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_21.Solve2, "21");
    }

    [Ignore("TODO")]
    public class Day22
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_22.Solve1, "22");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_22.Solve1, "22");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_22.Solve2, "22");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_22.Solve2, "22");
    }

    [Ignore("TODO")]
    public class Day23
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_23.Solve1, "23");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_23.Solve1, "23");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_23.Solve2, "23");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_23.Solve2, "23");
    }

    [Ignore("TODO")]
    public class Day24
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_24.Solve1, "24");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_24.Solve1, "24");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_24.Solve2, "24");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_24.Solve2, "24");
    }

    [Ignore("TODO")]
    public class Day25
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2018_25.Solve1, "25");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2018_25.Solve1, "25");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2018_25.Solve2, "25");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2018_25.Solve2, "25");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2018", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2018", day, "sample"));
    }
}
