using AOC.CSharp;
using NUnit.Framework;

namespace AOC.Tests.AOC2024;

public class Tests2024
{
    public class Day01
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(11, AOC2024_01.Solve1, "01");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(1970720, AOC2024_01.Solve1, "01");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(31, AOC2024_01.Solve2, "01");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(17191599, AOC2024_01.Solve2, "01");
    }

    public class Day02
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(2, AOC2024_02.Solve1, "02");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(591, AOC2024_02.Solve1, "02");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(4, AOC2024_02.Solve2, "02");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(621, AOC2024_02.Solve2, "02");
    }

    public class Day03
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(161, AOC2024_03.Solve1, "03");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(178538786, AOC2024_03.Solve1, "03");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(48, AOC2024_03.Solve2, "03");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(102467299, AOC2024_03.Solve2, "03");
    }

    public class Day04
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(18, AOC2024_04.Solve1, "04");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(2536, AOC2024_04.Solve1, "04");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(9, AOC2024_04.Solve2, "04");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(1875, AOC2024_04.Solve2, "04");
    }

    public class Day05
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(143, AOC2024_05.Solve1, "05");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(4135, AOC2024_05.Solve1, "05");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(9, AOC2024_05.Solve2, "05");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(1875, AOC2024_05.Solve2, "05");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2024", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2024", day, "sample"));
    }
}
