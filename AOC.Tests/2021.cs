﻿using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests.AOC2021;

[Parallelizable(ParallelScope.All)]
public class Tests
{
    private class Day01
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(7L, AOC2021_01.Solve1, "01");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(1466L, AOC2021_01.Solve1, "01");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(5L, AOC2021_01.Solve2, "01");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1491L, AOC2021_01.Solve2, "01");
    }

    private class Day02
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(150L, AOC2021_02.Solve1, "02");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(2322630L, AOC2021_02.Solve1, "02");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(900L, AOC2021_02.Solve2, "02");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(2105273490L, AOC2021_02.Solve2, "02");
    }

    private class Day03
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(198L, AOC2021_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(3374136L, AOC2021_03.Solve1, "03");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(230L, AOC2021_03.Solve2, "03");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(4432698L, AOC2021_03.Solve2, "03");
    }

    private class Day04
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(4512L, AOC2021_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(10680L, AOC2021_04.Solve1, "04");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(1924L, AOC2021_04.Solve2, "04");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(31892L, AOC2021_04.Solve2, "04");
    }

    private class Day05
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(5L, AOC2021_05.Solve1, "05");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(6461L, AOC2021_05.Solve1, "05");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(12L, AOC2021_05.Solve2, "05");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(18065L, AOC2021_05.Solve2, "05");
    }

    private class Day06
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(5934L, AOC2021_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(359999L, AOC2021_06.Solve1, "06");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(26984457539L, AOC2021_06.Solve2, "06");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1631647919273L, AOC2021_06.Solve2, "06");
    }

    private class Day07
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(37L, AOC2021_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(344297L, AOC2021_07.Solve1, "07");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(168L, AOC2021_07.Solve2, "07");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(97164301L, AOC2021_07.Solve2, "07");
    }

    private class Day08
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(26L, AOC2021_08.Solve1, "08");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(519L, AOC2021_08.Solve1, "08");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(61229L, AOC2021_08.Solve2, "08");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1027483L, AOC2021_08.Solve2, "08");
    }

    private class Day09
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(15L, AOC2021_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(537L, AOC2021_09.Solve1, "09");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(1134L, AOC2021_09.Solve2, "09");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1142757L, AOC2021_09.Solve2, "09");
    }

    private class Day10
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(26397L, AOC2021_10.Solve1, "10");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(394647L, AOC2021_10.Solve1, "10");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(288957L, AOC2021_10.Solve2, "10");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(2380061249L, AOC2021_10.Solve2, "10");
    }

    private class Day11
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(1656L, AOC2021_11.Solve1, "11");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(1644L, AOC2021_11.Solve1, "11");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(195L, AOC2021_11.Solve2, "11");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(229L, AOC2021_11.Solve2, "11");
    }

    private class Day12
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(10L, AOC2021_12.Solve1, "12");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(4495L, AOC2021_12.Solve1, "12");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(36L, AOC2021_12.Solve2, "12");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(131254L, AOC2021_12.Solve2, "12");
    }

    private class Day13
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(17L, AOC2021_13.Solve1, "13");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(678L, AOC2021_13.Solve1, "13");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(0L, AOC2021_13.Solve2, "13");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(0L, AOC2021_13.Solve2, "13");
    }

    private class Day14
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(1588L, AOC2021_14.Solve1, "14");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(2947L, AOC2021_14.Solve1, "14");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2188189693529L, AOC2021_14.Solve2, "14");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(3232426226464L, AOC2021_14.Solve2, "14");
    }

    private class Day15
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(40L, AOC2021_15.Solve1, "15");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(698L, AOC2021_15.Solve1, "15");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(315L, AOC2021_15.Solve2, "15");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(3022L, AOC2021_15.Solve2, "15");
    }

    private class Day16
    {
        [TestCase("D2FE28", 6, "single packet")]
        [TestCase("38006F45291200", 9, "two sub packets using LT 0")]
        [TestCase("EE00D40C823060", 14, "three sub packets using LT 1")]
        [TestCase("8A004A801A8002F478", 16, "nested operators 3x")]
        [TestCase("620080001611562C8802118E34", 12, "operator with operators - complex")]
        [TestCase("C0015000016115A2E0802F182340", 23, "operator with operators - complex")]
        [TestCase("A0016C880162017C3686B18A3D4780", 31, "operator with operators - complex")]
        [Category("Fast")]
        public void _1_SampleCases(string input, int expected, string desc)
        {
            long result = AOC2021_16.Solve1(new string[] { input });
            result.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(847L, AOC2021_16.Solve1, "16");

        [TestCase("D2FE28", 2021, "literal")]
        [TestCase("C200B40A82", 3, "sum")]
        [TestCase("04005AC33890", 54, "product")]
        [TestCase("880086C3E88112", 7, "min")]
        [TestCase("CE00C43D881120", 9, "max")]
        [TestCase("D8005AC2A8F0", 1, "less")]
        [TestCase("F600BC2D8F", 0, "greater")]
        [TestCase("9C005AC2F8F0", 0, "equal")]
        [TestCase("9C0141080250320F1802104A08", 1, "complex")]
        [Category("Fast")]
        public void _2_SampleCases(string input, int expected, string desc)
        {
            long result = AOC2021_16.Solve2(new string[] { input });
            result.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(333794664059L, AOC2021_16.Solve2, "16");
    }

    private class Day17
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(45L, AOC2021_17.Solve1, "17");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(13041L, AOC2021_17.Solve1, "17");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(112L, AOC2021_17.Solve2, "17");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1031L, AOC2021_17.Solve2, "17");
    }

    private class Day18
    {
        [TestCase("[[1,2],[[3,4],5]]", 143)]
        [TestCase("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [TestCase("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [TestCase("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [TestCase("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [TestCase("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        [Category("Fast")]
        public void _Magnitude(string input, long expected)
        {
            var num = AOC2021_18.Number.Parse(input);
            long actual = AOC2021_18.Magnitude(num);
            actual.Should().Be(expected);
        }

        [TestCase("[1,1]", "[2,2]", "(1,2)|(1,2)|(2,2)|(2,2)")]
        [TestCase("[[1,1],[2,2]]", "[3,3]", "(1,3)|(1,3)|(2,3)|(2,3)|(3,2)|(3,2)")]
        [TestCase(
            "[[[1,1],[2,2]],[3,3]]",
            "[4,4]",
            "(1,4)|(1,4)|(2,4)|(2,4)|(3,3)|(3,3)|(4,2)|(4,2)"
        )]
        [Category("Fast")]
        public void _Add(string input1, string input2, string expected)
        {
            var num1 = AOC2021_18.Number.Parse(input1);
            var num2 = AOC2021_18.Number.Parse(input2);
            var added = AOC2021_18.Add(num1, num2);
            string actual = added.ToString();
            actual.Should().Be(expected);
        }

        [TestCase("[[[[[9,8],1],2],3],4]", "(0,4)|(9,4)|(2,3)|(3,2)|(4,1)")]
        [TestCase("[7,[6,[5,[4,[3,2]]]]]", "(7,1)|(6,2)|(5,3)|(7,4)|(0,4)")]
        [TestCase("[[6,[5,[4,[3,2]]]],1]", "(6,2)|(5,3)|(7,4)|(0,4)|(3,1)")]
        [TestCase(
            "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]",
            "(3,2)|(2,3)|(8,4)|(0,4)|(9,2)|(5,3)|(4,4)|(3,5)|(2,5)"
        )]
        [TestCase(
            "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]",
            "(3,2)|(2,3)|(8,4)|(0,4)|(9,2)|(5,3)|(7,4)|(0,4)"
        )]
        [Category("Fast")]
        public void _Explode(string input, string expected)
        {
            var num = AOC2021_18.Number.Parse(input);
            var exploded = AOC2021_18.Explode(num);
            string actual = exploded.ToString();
            actual.Should().Be(expected);
        }

        [TestCase(
            "[[[[0,7],4],[15,[0,13]]],[1,1]]",
            "(0,4)|(7,4)|(4,3)|(7,4)|(8,4)|(0,4)|(13,4)|(1,2)|(1,2)"
        )]
        [TestCase(
            "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]",
            "(0,4)|(7,4)|(4,3)|(7,4)|(8,4)|(0,4)|(6,5)|(7,5)|(1,2)|(1,2)"
        )]
        [Category("Fast")]
        public void _Split(string input, string expected)
        {
            var num = AOC2021_18.Number.Parse(input);
            var exploded = AOC2021_18.Split(num);
            string actual = exploded.ToString();
            actual.Should().Be(expected);
        }

        [TestCase(
            "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]",
            "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]",
            "(4,4)|(0,4)|(5,4)|(4,4)|(7,4)|(7,4)|(6,4)|(0,4)|(8,3)|(7,4)|(7,4)|(7,4)|(9,4)|(5,4)|(0,4)"
        )]
        [TestCase(
            "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]",
            "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]",
            "(6,4)|(7,4)|(6,4)|(7,4)|(7,4)|(7,4)|(0,4)|(7,4)|(8,4)|(7,4)|(7,4)|(7,4)|(8,4)|(8,4)|(8,4)|(0,4)"
        )]
        [Category("Fast")]
        public void _Reduce(string input1, string input2, string expected)
        {
            var num1 = AOC2021_18.Number.Parse(input1);
            var num2 = AOC2021_18.Number.Parse(input2);
            var added = AOC2021_18.Add(num1, num2);
            var reduced = AOC2021_18.Reduce(added);
            string actual = reduced.ToString();
            actual.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void _1_Sample() => Sample(4140L, AOC2021_18.Solve1, "18");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(3647L, AOC2021_18.Solve1, "18");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(3993L, AOC2021_18.Solve2, "18");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(4600L, AOC2021_18.Solve2, "18");
    }

    private class Day19
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(79L, AOC2021_19.Solve1, "19");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual(457L, AOC2021_19.Solve1, "19");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(3621L, AOC2021_19.Solve2, "19");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(13243L, AOC2021_19.Solve2, "19");
    }

    private class Day20
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(35L, AOC2021_20.Solve1, "20");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(5583L, AOC2021_20.Solve1, "20");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(3351L, AOC2021_20.Solve2, "20");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(19592L, AOC2021_20.Solve2, "20");
    }

    private class Day21
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(739785L, AOC2021_21.Solve1, "21");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(797160L, AOC2021_21.Solve1, "21");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(444356092776315L, AOC2021_21.Solve2, "21");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(27464148626406L, AOC2021_21.Solve2, "21");
    }

    private class Day22
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(474140L, AOC2021_22.Solve1, "22");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(647076L, AOC2021_22.Solve1, "22");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2758514936282235L, AOC2021_22.Solve2, "22");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(1233304599156793L, AOC2021_22.Solve2, "22");

        [Category("Fast")]
        [TestCase("on x=1..1,y=2..2,z=3..3", 1)]
        [TestCase("on x=0..2,y=0..2,z=0..2", 27)]
        [TestCase("on x=-2..0,y=-2..0,z=-2..0", 27)]
        [TestCase("on x=-1..1,y=-1..1,z=-1..1", 27)]
        [TestCase("on x=0..2,y=0..2,z=0..2|off x=0..2,y=0..2,z=0..2", 0)]
        [TestCase("on x=0..2,y=0..2,z=0..2|on x=0..2,y=0..2,z=0..2", 27)]
        [TestCase("on x=0..2,y=0..2,z=0..2|on x=0..2,y=0..2,z=0..2|on x=0..2,y=0..2,z=0..2", 27)]
        [TestCase("on x=0..2,y=0..2,z=0..2|off x=0..1,y=0..1,z=0..1", 19)]
        [TestCase("on x=0..1,y=0..1,z=0..0|on x=1..2,y=0..1,z=0..0", 6)]
        [TestCase("on x=0..1,y=0..1,z=0..0|on x=1..2,y=0..1,z=0..0|off x=1..2,y=0..1,z=0..0", 2)]
        public void _2_Cases(string lines, long expected)
        {
            string[] splits = lines.Split("|");
            long result = AOC2021_22.Solve2(splits);
            result.Should().Be(expected);
        }
    }

    private class Day23
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(12521L, AOC2021_23.Solve1, "23");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(14415L, AOC2021_23.Solve1, "23");

        [Test, Category("Slow")]
        public void _2_Sample() => Sample(44169L, AOC2021_23.Solve2, "23");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(41121L, AOC2021_23.Solve2, "23");
    }

    private class Day24
    {
        [Test, Category("Fast")]
        public void _1_Actual() => Actual("29599469991739", AOC2021_24.Solve1, "24");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual("17153114691118", AOC2021_24.Solve2, "24");
    }

    private class Day25
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(58L, AOC2021_25.Solve1, "25");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(429L, AOC2021_25.Solve1, "25");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "sample"));
    }
}
