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

    public class Day03
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(357, AOC2025_03.Solve1, "03");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(16973, AOC2025_03.Solve1, "03");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(3121910778619, AOC2025_03.Solve2, "03");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(168027167146027L, AOC2025_03.Solve2, "03");
    }

    public class Day04
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(13, AOC2025_04.Solve1, "04");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(1464, AOC2025_04.Solve1, "04");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(43, AOC2025_04.Solve2, "04");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(8409, AOC2025_04.Solve2, "04");
    }

    public class Day05
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(3, AOC2025_05.Solve1, "05");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(720, AOC2025_05.Solve1, "05");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(14, AOC2025_05.Solve2, "05");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(357608232770687L, AOC2025_05.Solve2, "05");
    }

    public class Day06
    {
        [Test, Property("Speed", "Fast")]
        public void _1_Sample() => Sample(4277556, AOC2025_06.Solve1, "06");

        [Test, Property("Speed", "Fast")]
        public void _1_Actual() => Actual(3525371263915L, AOC2025_06.Solve1, "06");

        [Test, Property("Speed", "Fast")]
        public void _2_Sample() => Sample(3263827, AOC2025_06.Solve2, "06");

        [Test, Property("Speed", "Fast")]
        public void _2_Actual() => Actual(6846480843636L, AOC2025_06.Solve2, "06");
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
