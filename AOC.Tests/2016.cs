﻿using System.Text;
using AOC.CSharp;
using AOC.FSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests.AOC2016;

[Parallelizable(ParallelScope.All)]
public class Tests
{
    private class Day01
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(8L, AOC2016_01.solve1, "01");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(230L, AOC2016_01.solve1, "01");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(4L, AOC2016_01.solve2, "01");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(154L, AOC2016_01.solve2, "01");
    }

    private class Day02
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample("1985", AOC2016_02.solve1, "02");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual("74921", AOC2016_02.solve1, "02");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample("5DB3", AOC2016_02.solve2, "02");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual("A6B35", AOC2016_02.solve2, "02");
    }

    private class Day03
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(1L, AOC2016_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(862L, AOC2016_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(1L, AOC2016_03.Solve2, "03");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1577L, AOC2016_03.Solve2, "03");
    }

    private class Day04
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(1514L, AOC2016_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(278221L, AOC2016_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(267L, AOC2016_04.Solve2, "04");
    }

    private class Day05
    {
        [Test, Category("Slow")]
        public void _1_Sample() => Sample("18f47a30", AOC2016_05.Solve1, "05");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual("f97c354d", AOC2016_05.Solve1, "05");

        [Test, Category("Slow")]
        public void _2_Sample() => Sample("05ace8e3", AOC2016_05.Solve2, "05");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual("863dde27", AOC2016_05.Solve2, "05");
    }

    private class Day06
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample("easter", AOC2016_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual("dzqckwsd", AOC2016_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample("advent", AOC2016_06.Solve2, "06");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual("lragovly", AOC2016_06.Solve2, "06");
    }

    private class Day07
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(2L, AOC2016_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(110L, AOC2016_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(3L, AOC2016_07.Solve2, "07");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(242L, AOC2016_07.Solve2, "07");
    }

    private class Day08
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(6L, AOC2016_08.Solve, "08");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(116L, AOC2016_08.Solve, "08");

        [TestCase("(3x3)XYZ", 9)]
        [TestCase("X(8x2)(3x3)ABCY", 20)]
        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
        [TestCase("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
        [Category("Fast")]
        public void _Cases(string input, int expected)
        {
            long result = AOC2016_09.Solve2(new[] { input });
            result.Should().Be(expected);
        }
    }

    private class Day09
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(57L, AOC2016_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(102239L, AOC2016_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(56L, AOC2016_09.Solve2, "09");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(10780403063L, AOC2016_09.Solve2, "09");
    }

    private class Day10
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(2L, lines => AOC2016_10.Solve1(lines, "2,5"), "10");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(118L, lines => AOC2016_10.Solve1(lines, "17,61"), "10");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(30L, AOC2016_10.Solve2, "10");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(143153L, AOC2016_10.Solve2, "10");
    }

    private class Day11
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(11L, AOC2016_11.Solve1, "11");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual(33L, AOC2016_11.Solve1, "11");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(57L, AOC2016_11.Solve2, "11");
    }

    private class Day12
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(42L, AOC2016_12.Solve1, "12");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(318007L, AOC2016_12.Solve1, "12");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(42L, AOC2016_12.Solve2, "12");

        [Test, Category("VerySlow")]
        public void _2_Actual() => Actual(9227661L, AOC2016_12.Solve2, "12");
    }

    private class Day13
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(11L, lines => AOC2016_13.Solve1(lines, "7,4"), "13");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(96L, lines => AOC2016_13.Solve1(lines, "31,39"), "13");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(151L, AOC2016_13.Solve2, "13");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(141L, AOC2016_13.Solve2, "13");
    }

    private class Day14
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(22728L, AOC2016_14.Solve1, "14");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(16106L, AOC2016_14.Solve1, "14");

        [Test, Category("VerySlow")]
        public void _2_Sample() => Sample(22551L, AOC2016_14.Solve2, "14");

        [Test, Category("VerySlow")]
        public void _2_Actual() => Actual(22423L, AOC2016_14.Solve2, "14");
    }

    private class Day15
    {
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 0, true)]
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 1, false)]
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 4, false)]
        [TestCase("Disc #1 has 5 positions; at time=0, it is at position 4.", 5, true)]
        [Category("Fast")]
        public void _Cases(string line, int t, bool expected)
        {
            var d = AOC2016_15.Disc.Parse(line);
            bool isOpen = d.IsOpenAt(t);
            isOpen.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _1_Sample() => Sample(5L, AOC2016_15.Solve1, "15");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(203660L, AOC2016_15.Solve1, "15");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(85L, AOC2016_15.Solve2, "15");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(2408135L, AOC2016_15.Solve2, "15");
    }

    private class Day16
    {
        [TestCase("1", "100")]
        [TestCase("0", "001")]
        [TestCase("11111", "11111000000")]
        [TestCase("111100001010", "1111000010100101011110000")]
        [Category("Fast")]
        public void _Transform(string input, string expected)
        {
            byte[] arr = input
                .Select(ch => ch == '1' ? (byte)1 : (byte)0)
                .Concat(new byte[input.Length + 1])
                .ToArray();
            int size = AOC2016_16.Transform(arr, input.Length);
            size.Should().Be(input.Length * 2 + 1);

            StringBuilder sb = new();
            for (int i = 0; i < size; i++)
            {
                sb.Append(arr[i] == 1 ? '1' : '0');
            }

            sb.ToString().Should().Be(expected);
        }

        [TestCase("110010110100", "100")]
        [TestCase("10000011110010000111", "01100")]
        [Category("Fast")]
        public void _Checksum(string input, string expected)
        {
            byte[] byteInput = input.Select(ch => ch == '1' ? (byte)1 : (byte)0).ToArray();
            string actual = AOC2016_16.CalculateChecksum(byteInput, byteInput.Length);
            actual.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _1_Sample() => Sample("01100", x => AOC2016_16.Solve(x, "20"), "16");

        [Test, Category("Fast")]
        public void _1_Actual() =>
            Actual("10010010110011010", x => AOC2016_16.Solve(x, "272"), "16");

        [Test, Category("Fast")]
        public void _2_Actual() =>
            Actual("01010100101011100", x => AOC2016_16.Solve(x, "35651584"), "16");
    }

    private class Day17
    {
        [Test, Category("Fast")]
        [TestCase("ihgpwlah", "DDRRRD")]
        [TestCase("kglvqrro", "DDUDRLRRUDRD")]
        [TestCase("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
        public void _1_Samples(string passcode, string expected)
        {
            string actual = AOC2016_17.Solve1(new[] { passcode });
            actual.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _1_Actual() => Actual("RLRDRDUDDR", AOC2016_17.Solve1, "17");

        [Test, Category("Fast")]
        [TestCase("ihgpwlah", 370)]
        [TestCase("kglvqrro", 492)]
        [TestCase("ulqzkmiv", 830)]
        public void _2_Sample(string passcode, int expected)
        {
            long actual = AOC2016_17.Solve2(new[] { passcode });
            actual.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(420L, AOC2016_17.Solve2, "17");
    }

    private class Day18
    {
        [Test, Category("Fast")]
        [TestCase("^^", "^^", 0)]
        [TestCase("^.", ".^", 1)]
        [TestCase(".^", "^.", 1)]
        [TestCase("..^^.", ".^^^^", 1)]
        [TestCase(".^^^^", "^^..^", 2)]
        [TestCase(".^^.^.^^^^", "^^^...^..^", 5)]
        [TestCase(".^^^..^.^^", "^^.^^^..^^", 3)]
        [TestCase("^^^...^..^", "^.^^.^.^^.", 4)]
        public void _MakeNextRow(string prevRow, string expectedRow, int expectedCount)
        {
            int[] prevRowInt = AOC2016_18.Parse(prevRow);

            var actual = AOC2016_18.MakeNextRow(prevRowInt);
            string asStr = AOC2016_18.ReverseParse(actual.Row);
            asStr.Should().BeEquivalentTo(expectedRow);
            actual.SafeCount.Should().Be(expectedCount);
        }

        [Test, Category("Fast")]
        public void _1_Sample() => Sample(38L, x => AOC2016_18.Solve(x, "10"), "18");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(1974L, x => AOC2016_18.Solve(x, "40"), "18");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(19991126L, x => AOC2016_18.Solve(x, "400000"), "18");
    }

    private class Day19
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(3L, AOC2016_19.Solve1, "19");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(1808357L, AOC2016_19.Solve1, "19");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2L, AOC2016_19.Solve2, "19");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1407007L, AOC2016_19.Solve2, "19");
    }

    private class Day20
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(3L, AOC2016_20.Solve1, "20");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(23923783L, AOC2016_20.Solve1, "20");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(4294967288L, AOC2016_20.Solve2, "20");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(125L, AOC2016_20.Solve2, "20");
    }

    private class Day21
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample("decab", x => AOC2016_21.Solve1(x, "abcde"), "21");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual("gbhafcde", x => AOC2016_21.Solve1(x, "abcdefgh"), "21");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual("bcfaegdh", x => AOC2016_21.Solve2(x, "fbgdceah"), "21");
    }

    private class Day22
    {
        [Test, Category("Fast")]
        public void _1_Actual() => Actual(981L, AOC2016_22.Solve1, "22");
    }

    private class Day23
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(3L, AOC2016_23.Solve1, "23");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(12492L, AOC2016_23.Solve1, "23");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(479009052L, AOC2016_23.Solve2, "23");
    }

    private class Day24
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(14L, AOC2016_24.Solve1, "24");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(500L, AOC2016_24.Solve1, "24");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(748L, AOC2016_24.Solve2, "24");
    }

    private class Day25
    {
        [Test, Category("Fast")]
        public void _1_Actual() => Actual(158L, AOC2016_25.Solve1, "25");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2016", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2016", day, "sample"));
    }
}
