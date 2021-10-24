﻿using System;
using AOC.CSharp;
using AOC.FSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class Year2016
    {
        [Test, Property("Speed", "Fast")]
        public void Day01_1_Sample() => Sample(8L, AOC2016_01.solve1, "01");

        [Test, Property("Speed", "Fast")]
        public void Day01_1_Actual() => Actual(230L, AOC2016_01.solve1, "01");

        [Test, Property("Speed", "Fast")]
        public void Day01_2_Sample() => Sample(4L, AOC2016_01.solve2, "01");

        [Test, Property("Speed", "Fast")]
        public void Day01_2_Actual() => Actual(154L, AOC2016_01.solve2, "01");

        [Test, Property("Speed", "Fast")]
        public void Day02_1_Sample() => Sample("1985", AOC2016_02.solve1, "02");

        [Test, Property("Speed", "Fast")]
        public void Day02_1_Actual() => Actual("74921", AOC2016_02.solve1, "02");

        [Test, Property("Speed", "Fast")]
        public void Day02_2_Sample() => Sample("5DB3", AOC2016_02.solve2, "02");

        [Test, Property("Speed", "Fast")]
        public void Day02_2_Actual() => Actual("A6B35", AOC2016_02.solve2, "02");

        [Test, Property("Speed", "Fast")]
        public void Day03_1_Sample() => Sample(1L, AOC2016_03.Solve1, "03");

        [Test, Property("Speed", "Fast")]
        public void Day03_1_Actual() => Actual(862L, AOC2016_03.Solve1, "03");

        [Test, Property("Speed", "Fast")]
        public void Day03_2_Sample() => Sample(1L, AOC2016_03.Solve2, "03");

        [Test, Property("Speed", "Fast")]
        public void Day03_2_Actual() => Actual(1577L, AOC2016_03.Solve2, "03");

        [Test, Property("Speed", "Fast")]
        public void Day04_1_Sample() => Sample(1514L, AOC2016_04.Solve1, "04");

        [Test, Property("Speed", "Fast")]
        public void Day04_1_Actual() => Actual(278221L, AOC2016_04.Solve1, "04");

        [Test, Property("Speed", "Fast")]
        public void Day04_2_Actual() => Actual(267L, AOC2016_04.Solve2, "04");

        [Test, Property("Speed", "Slow")]
        public void Day05_1_Sample() => Sample("18f47a30", AOC2016_05.Solve1, "05");

        [Test, Property("Speed", "Slow")]
        public void Day05_1_Actual() => Actual("f97c354d", AOC2016_05.Solve1, "05");

        [Test, Property("Speed", "Slow")]
        public void Day05_2_Sample() => Sample("05ace8e3", AOC2016_05.Solve2, "05");

        [Test, Property("Speed", "Slow")]
        public void Day05_2_Actual() => Actual("863dde27", AOC2016_05.Solve2, "05");

        [Test, Property("Speed", "Fast")]
        public void Day06_1_Sample() => Sample("easter", AOC2016_06.Solve1, "06");

        [Test, Property("Speed", "Fast")]
        public void Day06_1_Actual() => Actual("dzqckwsd", AOC2016_06.Solve1, "06");

        [Test, Property("Speed", "Fast")]
        public void Day06_2_Sample() => Sample("advent", AOC2016_06.Solve2, "06");

        [Test, Property("Speed", "Fast")]
        public void Day06_2_Actual() => Actual("lragovly", AOC2016_06.Solve2, "06");

        [Test, Property("Speed", "Fast")]
        public void Day07_1_Sample() => Sample(2L, AOC2016_07.Solve1, "07");

        [Test, Property("Speed", "Fast")]
        public void Day07_1_Actual() => Actual(110L, AOC2016_07.Solve1, "07");

        [Test, Property("Speed", "Fast")]
        public void Day07_2_Sample() => Sample(3L, AOC2016_07.Solve2, "07");

        [Test, Property("Speed", "Fast")]
        public void Day07_2_Actual() => Actual(242L, AOC2016_07.Solve2, "07");

        [Test, Property("Speed", "Fast")]
        public void Day08_1_Sample() => Sample(6L, AOC2016_08.Solve, "08");

        [Test, Property("Speed", "Fast")]
        public void Day08_1_Actual() => Actual(116L, AOC2016_08.Solve, "08");

        [TestCase("(3x3)XYZ", 9)]
        [TestCase("X(8x2)(3x3)ABCY", 20)]
        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
        [TestCase("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
        [Property("Speed", "Fast")]
        public void Day09_Cases(string input, int expected)
        {
            long result = AOC2016_09.Solve2(new[] { input });
            result.Should().Be(expected);
        }

        [Test, Property("Speed", "Fast")]
        public void Day09_1_Sample() => Sample(57L, AOC2016_09.Solve1, "09");

        [Test, Property("Speed", "Fast")]
        public void Day09_1_Actual() => Actual(102239L, AOC2016_09.Solve1, "09");

        [Test, Property("Speed", "Fast")]
        public void Day09_2_Sample() => Sample(56L, AOC2016_09.Solve2, "09");

        [Test, Property("Speed", "Fast")]
        public void Day09_2_Actual() => Actual(10780403063L, AOC2016_09.Solve2, "09");

        [Test, Property("Speed", "Fast")]
        public void Day10_1_Sample() => Sample(2L, lines => AOC2016_10.Solve1(lines, "2,5"), "10");

        [Test, Property("Speed", "Fast")]
        public void Day10_1_Actual() => Actual(118L, lines => AOC2016_10.Solve1(lines, "17,61"), "10");

        [Test, Property("Speed", "Fast")]
        public void Day10_2_Sample() => Sample(30L, AOC2016_10.Solve2, "10");

        [Test, Property("Speed", "Fast")]
        public void Day10_2_Actual() => Actual(143153L, AOC2016_10.Solve2, "10");

        [Test, Property("Speed", "Fast")]
        public void Day11_1_Sample() => Sample(11L, AOC2016_11.Solve1, "11");

        [Test, Property("Speed", "Slow")]
        public void Day11_1_Actual() => Actual(33L, AOC2016_11.Solve1, "11");

        [Test, Property("Speed", "Slow")]
        public void Day11_2_Actual() => Actual(57L, AOC2016_11.Solve2, "11");

        [Test, Property("Speed", "Fast")]
        public void Day12_1_Sample() => Sample(42L, AOC2016_12.Solve1, "12");

        [Test, Property("Speed", "Fast")]
        public void Day12_1_Actual() => Actual(318007L, AOC2016_12.Solve1, "12");

        [Test, Property("Speed", "Fast")]
        public void Day12_2_Sample() => Sample(42L, AOC2016_12.Solve2, "12");

        [Test, Property("Speed", "VerySlow")]
        public void Day12_2_Actual() => Actual(9227661L, AOC2016_12.Solve2, "12");

        [Test, Property("Speed", "Fast")]
        public void Day13_1_Sample() => Sample(11L, lines => AOC2016_13.Solve1(lines, "7,4"), "13");

        [Test, Property("Speed", "Fast")]
        public void Day13_1_Actual() => Actual(96L, lines => AOC2016_13.Solve1(lines, "31,39"), "13");

        [Test, Property("Speed", "Fast")]
        public void Day13_2_Sample() => Sample(151L, AOC2016_13.Solve2, "13");

        [Test, Property("Speed", "Fast")]
        public void Day13_2_Actual() => Actual(141L, AOC2016_13.Solve2, "13");

        [Test, Property("Speed", "Fast")]
        public void Day14_1_Sample() => Sample(22728L, AOC2016_14.Solve1, "14");

        [Test, Property("Speed", "Fast")]
        public void Day14_1_Actual() => Actual(16106L, AOC2016_14.Solve1, "14");

        [Test, Property("Speed", "VerySlow")]
        public void Day14_2_Sample() => Sample(22551L, AOC2016_14.Solve2, "14");

        [Test, Property("Speed", "VerySlow")]
        public void Day14_2_Actual() => Actual(22423L, AOC2016_14.Solve2, "14");

        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 0, true)]
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 1, false)]
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 4, false)]
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 5, true)]
        [Property("Speed", "Fast")]
        public void Day15_Cases(string line, int t, bool expected)
        {
            var d = AOC2016_15.Disc.Parse(line);
            bool isOpen = d.IsOpenAt(t);
            isOpen.Should().Be(expected);
        }

        [Test, Property("Speed", "Fast")]
        public void Day15_1_Sample() => Sample(5L, AOC2016_15.Solve1, "15");

        [Test, Property("Speed", "Fast")]
        public void Day15_1_Actual() => Actual(203660L, AOC2016_15.Solve1, "15");

        [Test, Property("Speed", "Fast")]
        public void Day15_2_Sample() => Sample(85L, AOC2016_15.Solve2, "15");

        [Test, Property("Speed", "Fast")]
        public void Day15_2_Actual() => Actual(2408135L, AOC2016_15.Solve2, "15");

        private static void Actual<T>(T expected, Func<string[], T> solver, string day)
        {
            TestUtils.Test(expected, solver, TestUtils.ReadInput("2016", day, "actual"));
        }

        private static void Sample<T>(T expected, Func<string[], T> solver, string day)
        {
            TestUtils.Test(expected, solver, TestUtils.ReadInput("2016", day, "sample"));
        }
    }
}