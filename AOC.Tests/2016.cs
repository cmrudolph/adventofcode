using System;
using AOC.CSharp;
using AOC.FSharp;
using Xunit;

namespace AOC.Tests
{
    public class Year2016
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Sample() => Sample(8L, AOC2016_01.solve1, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Actual() => Actual(230L, AOC2016_01.solve1, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Sample() => Sample(4L, AOC2016_01.solve2, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Actual() => Actual(154L, AOC2016_01.solve2, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Sample() => Sample("1985", AOC2016_02.solve1, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Actual() => Actual("74921", AOC2016_02.solve1, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Sample() => Sample("5DB3", AOC2016_02.solve2, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Actual() => Actual("A6B35", AOC2016_02.solve2, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Sample() => Sample(1L, AOC2016_03.Solve1, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Actual() => Actual(862L, AOC2016_03.Solve1, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Sample() => Sample(1L, AOC2016_03.Solve2, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Actual() => Actual(1577L, AOC2016_03.Solve2, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day04_1_Sample() => Sample(1514L, AOC2016_04.Solve1, "04");

        [Fact, Trait("Speed", "Fast")]
        public void Day04_1_Actual() => Actual(278221L, AOC2016_04.Solve1, "04");

        [Fact, Trait("Speed", "Fast")]
        public void Day04_2_Actual() => Actual(267L, AOC2016_04.Solve2, "04");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day05_1_Sample() => Sample("18f47a30", AOC2016_05.Solve1, "05");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day05_1_Actual() => Actual("f97c354d", AOC2016_05.Solve1, "05");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day05_2_Sample() => Sample("05ace8e3", AOC2016_05.Solve2, "05");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day05_2_Actual() => Actual("863dde27", AOC2016_05.Solve2, "05");

        [Fact, Trait("Speed", "Fast")]
        public void Day06_1_Sample() => Sample("easter", AOC2016_06.Solve1, "06");

        [Fact, Trait("Speed", "Fast")]
        public void Day06_1_Actual() => Actual("dzqckwsd", AOC2016_06.Solve1, "06");

        [Fact, Trait("Speed", "Fast")]
        public void Day06_2_Sample() => Sample("advent", AOC2016_06.Solve2, "06");

        [Fact, Trait("Speed", "Fast")]
        public void Day06_2_Actual() => Actual("lragovly", AOC2016_06.Solve2, "06");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Sample() => Sample(2L, AOC2016_07.Solve1, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Actual() => Actual(110L, AOC2016_07.Solve1, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Sample() => Sample(3L, AOC2016_07.Solve2, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Actual() => Actual(242L, AOC2016_07.Solve2, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Sample() => Sample(6L, AOC2016_08.Solve, "08");

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Actual() => Actual(116L, AOC2016_08.Solve, "08");

        [Theory]
        [InlineData("(3x3)XYZ", 9)]
        [InlineData("X(8x2)(3x3)ABCY", 20)]
        [InlineData("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
        [InlineData("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
        [Trait("Speed", "Fast")]
        public void Day09_Cases(string input, int expected)
        {
            long result = AOC2016_09.Solve2(new[] { input });
            Assert.Equal(expected, result);
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Sample() => Sample(57L, AOC2016_09.Solve1, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Actual() => Actual(102239L, AOC2016_09.Solve1, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Sample() => Sample(56L, AOC2016_09.Solve2, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Actual() => Actual(10780403063L, AOC2016_09.Solve2, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Sample() => Sample(2L, lines => AOC2016_10.Solve1(lines, "2,5"), "10");

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Actual() => Actual(118L, lines => AOC2016_10.Solve1(lines, "17,61"), "10");

        [Fact, Trait("Speed", "Fast")]
        public void Day10_2_Sample() => Sample(30L, AOC2016_10.Solve2, "10");

        [Fact, Trait("Speed", "Fast")]
        public void Day10_2_Actual() => Actual(143153L, AOC2016_10.Solve2, "10");

        [Fact, Trait("Speed", "Fast")]
        public void Day11_1_Sample() => Sample(11L, AOC2016_11.Solve1, "11");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day11_1_Actual() => Actual(33L, AOC2016_11.Solve1, "11");

        [Fact, Trait("Speed", "Fast")]
        public void Day11_2_Actual() => Actual(143153L, AOC2016_11.Solve2, "11");

        private static void Actual<T>(T expected, Func<string[], T> solver, string day)
        {
            Utils.Test(expected, solver, Utils.ReadInput("2016", day, "actual"));
        }

        private static void Sample<T>(T expected, Func<string[], T> solver, string day)
        {
            Utils.Test(expected, solver, Utils.ReadInput("2016", day, "sample"));
        }
    }
}