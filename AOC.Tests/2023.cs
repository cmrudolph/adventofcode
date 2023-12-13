using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests.AOC2023;

public class Tests
{
    private class Day01
    {
        [Test, Category("Fast")]
        public void _1_Actual() => Actual(55712, AOC2023_01.Solve1, "01");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(281, AOC2023_01.Solve2, "01");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(55413, AOC2023_01.Solve2, "01");
    }

    private class Day02
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(8, AOC2023_02.Solve1, "02");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(3035, AOC2023_02.Solve1, "02");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2286, AOC2023_02.Solve2, "02");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(66027, AOC2023_02.Solve2, "02");
    }

    private class Day03
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(4361, AOC2023_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(525181, AOC2023_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(467835, AOC2023_03.Solve2, "03");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(84289137, AOC2023_03.Solve2, "03");
    }

    private class Day04
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(13, AOC2023_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(24706, AOC2023_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(30, AOC2023_04.Solve2, "04");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(13114317, AOC2023_04.Solve2, "04");
    }

    private class Day05
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(35, AOC2023_05.Solve1, "05");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(251346198, AOC2023_05.Solve1, "05");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(46, AOC2023_05.Solve2, "05");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(72263011, AOC2023_05.Solve2, "05");
    }

    private class Day06
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(288, AOC2023_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(170000, AOC2023_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(71503, AOC2023_06.Solve2, "06");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(20537782, AOC2023_06.Solve2, "06");
    }

    private class Day07
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(6440, AOC2023_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(245794640, AOC2023_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(5905, AOC2023_07.Solve2, "07");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(247899149, AOC2023_07.Solve2, "07");
    }

    private class Day08
    {
        [Test, Category("Fast")]
        public void _1_Actual() => Actual(19783, AOC2023_08.Solve1, "08");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(6, AOC2023_08.Solve2, "08");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(9177460370549L, AOC2023_08.Solve2, "08");
    }

    private class Day09
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(114, AOC2023_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(2175229206, AOC2023_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2, AOC2023_09.Solve2, "09");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(942, AOC2023_09.Solve2, "09");
    }

    private class Day10
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(22, AOC2023_10.Solve1, "10");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(6856, AOC2023_10.Solve1, "10");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(4, AOC2023_10.Solve2, "10");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(501, AOC2023_10.Solve2, "10");
    }

    private class Day11
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(374, AOC2023_11.Solve1, "11");

        [Test, Category("New")]
        public void _1_Actual() => Actual(9957702, AOC2023_11.Solve1, "11");

        [Test, Category("New")]
        public void _2_Sample() => Sample(82000210, AOC2023_11.Solve2, "11");

        [Test, Category("New")]
        public void _2_Actual() => Actual(512240933238, AOC2023_11.Solve2, "11");
    }

    private class Day12
    {
        [TestCase("???.### 1,1,3", 1)]
        [TestCase(".??..??...?##. 1,1,3", 4)]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
        [TestCase("????.#...#... 4,1,1", 1)]
        [TestCase("????.######..#####. 1,6,5", 4)]
        [TestCase("?###???????? 3,2,1", 10)]
        public void _1_Cases(string line, long expected)
        {
            long result = AOC2023_12.SolveLine(line);
            result.Should().Be(expected);
        }

        [Test, Category("New")]
        public void _1_Sample() => Sample(21, AOC2023_12.Solve1, "12");

        [Test, Category("VerySlow")]
        public void _1_Actual() => Actual(7857, AOC2023_12.Solve1, "12");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_12.Solve2, "12");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_12.Solve2, "12");
    }

    [Ignore("TODO")]
    private class Day13
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_13.Solve1, "13");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_13.Solve1, "13");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_13.Solve2, "13");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_13.Solve2, "13");
    }

    [Ignore("TODO")]
    private class Day14
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_14.Solve1, "14");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_14.Solve1, "14");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_14.Solve2, "14");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_14.Solve2, "14");
    }

    [Ignore("TODO")]
    private class Day15
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_15.Solve1, "15");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_15.Solve1, "15");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_15.Solve2, "15");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_15.Solve2, "15");
    }

    [Ignore("TODO")]
    public class Day16
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_16.Solve1, "16");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_16.Solve1, "16");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_16.Solve2, "16");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_16.Solve2, "16");
    }

    [Ignore("TODO")]
    public class Day17
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_17.Solve1, "17");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_17.Solve1, "17");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_17.Solve2, "17");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_17.Solve2, "17");
    }

    [Ignore("TODO")]
    public class Day18
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_18.Solve1, "18");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_18.Solve1, "18");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_18.Solve2, "18");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_18.Solve2, "18");
    }

    [Ignore("TODO")]
    public class Day19
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_19.Solve1, "19");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_19.Solve1, "19");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_19.Solve2, "19");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_19.Solve2, "19");
    }

    [Ignore("TODO")]
    public class Day20
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_20.Solve1, "20");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_20.Solve1, "20");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_20.Solve2, "20");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_20.Solve2, "20");
    }

    [Ignore("TODO")]
    public class Day21
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_21.Solve1, "21");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_21.Solve1, "21");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_21.Solve2, "21");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_21.Solve2, "21");
    }

    [Ignore("TODO")]
    public class Day22
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_22.Solve1, "22");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_22.Solve1, "22");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_22.Solve2, "22");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_22.Solve2, "22");
    }

    [Ignore("TODO")]
    public class Day23
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_23.Solve1, "23");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_23.Solve1, "23");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_23.Solve2, "23");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_23.Solve2, "23");
    }

    [Ignore("TODO")]
    public class Day24
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_24.Solve1, "24");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_24.Solve1, "24");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_24.Solve2, "24");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_24.Solve2, "24");
    }

    [Ignore("TODO")]
    public class Day25
    {
        [Test, Category("New")]
        public void _1_Sample() => Sample(-1, AOC2023_25.Solve1, "25");

        [Test, Category("New")]
        public void _1_Actual() => Actual(-1, AOC2023_25.Solve1, "25");

        [Test, Category("New")]
        public void _2_Sample() => Sample(-1, AOC2023_25.Solve2, "25");

        [Test, Category("New")]
        public void _2_Actual() => Actual(-1, AOC2023_25.Solve2, "25");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2023", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2023", day, "sample"));
    }
}
