using AOC.CSharp;
using NUnit.Framework;

namespace AOC.Tests.AOC2025;

public class Tests2025
{
    public class Day01
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(3, AOC2025_01.Solve1, "01");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(1055, AOC2025_01.Solve1, "01");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(6, AOC2025_01.Solve2, "01");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(6386, AOC2025_01.Solve2, "01");
    }

    public class Day02
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(1227775554L, AOC2025_02.Solve1, "02");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(17077011375L, AOC2025_02.Solve1, "02");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(4174379265L, AOC2025_02.Solve2, "02");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(36037497037L, AOC2025_02.Solve2, "02");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2025", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2025", day, "sample"));
    }
}
