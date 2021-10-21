using System;
using AOC.CSharp;
using AOC.FSharp;
using Xunit;

namespace AOC.Tests
{
    public class Year2015
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Sample() => Sample(-1L, AOC2015_01.solve1, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Actual() => Actual(74L, AOC2015_01.solve1, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Sample() => Sample(5L, AOC2015_01.solve2, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Actual() => Actual(1795L, AOC2015_01.solve2, "01");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Sample() => Sample(58L, AOC2015_02.solve1, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Actual() => Actual(1598415L, AOC2015_02.solve1, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Sample() => Sample(34L, AOC2015_02.solve2, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Actual() => Actual(3812909L, AOC2015_02.solve2, "02");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Sample() => Sample(4L, AOC2015_03.solve1, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Actual() => Actual(2572L, AOC2015_03.solve1, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Sample() => Sample(3L, AOC2015_03.solve2, "03");

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Actual() => Actual(2631L, AOC2015_03.solve2, "03");

        [Fact, Trait("Speed", "Slow")]
        public void Day04_1_Sample() => Sample(609043L, AOC2015_04.solve1, "04");

        [Fact, Trait("Speed", "Fast")]
        public void Day04_1_Actual() => Actual(117946L, AOC2015_04.solve1, "04");

        [Fact, Trait("Speed", "Slow")]
        public void Day04_2_Sample() => Sample(6742839L, AOC2015_04.solve2, "04");

        [Fact, Trait("Speed", "Slow")]
        public void Day04_2_Actual() => Actual(3938038L, AOC2015_04.solve2, "04");

        [Fact, Trait("Speed", "Fast")]
        public void Day05_1_Sample() => Sample(2L, AOC2015_05.solve1, "05");

        [Fact, Trait("Speed", "Fast")]
        public void Day05_1_Actual() => Actual(258L, AOC2015_05.solve1, "05");

        [Fact, Trait("Speed", "Fast")]
        public void Day05_2_Sample() => Sample(0L, AOC2015_05.solve2, "05");

        [Fact, Trait("Speed", "Fast")]
        public void Day05_2_Actual() => Actual(53L, AOC2015_05.solve2, "05");

        [Fact, Trait("Speed", "Fast")]
        public void Day06_1_Sample() => Sample(998996L, AOC2015_06.solve1, "06");

        [Fact, Trait("Speed", "Slow")]
        public void Day06_1_Actual() => Actual(543903L, AOC2015_06.solve1, "06");

        [Fact, Trait("Speed", "Fast")]
        public void Day06_2_Sample() => Sample(1001996L, AOC2015_06.solve2, "06");

        [Fact, Trait("Speed", "Slow")]
        public void Day06_2_Actual() => Actual(14687245L, AOC2015_06.solve2, "06");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Sample() => Sample(114L, AOC2015_07.solve1, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Actual() => Actual(956L, AOC2015_07.solve1, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Sample() => Sample(114L, AOC2015_07.solve2, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Actual() => Actual(40149L, AOC2015_07.solve2, "07");

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Sample() => Sample(12L, AOC2015_08.solve1, "08");

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Actual() => Actual(1350L, AOC2015_08.solve1, "08");

        [Fact, Trait("Speed", "Fast")]
        public void Day08_2_Sample() => Sample(19L, AOC2015_08.solve2, "08");

        [Fact, Trait("Speed", "Fast")]
        public void Day08_2_Actual() => Actual(2085L, AOC2015_08.solve2, "08");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Sample() => Sample(605L, AOC2015_09.Solve1, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Actual() => Actual(117L, AOC2015_09.Solve1, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Sample() => Sample(982L, AOC2015_09.Solve2, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Actual() => Actual(909L, AOC2015_09.Solve2, "09");

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Sample() => Sample(6L, lines => AOC2015_10.Solve(lines, "5"), "10");

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Actual() => Actual(329356L, lines => AOC2015_10.Solve(lines, "40"), "10");

        [Fact, Trait("Speed", "Slow")]
        public void Day10_2_Actual() => Actual(4666278L, lines => AOC2015_10.Solve(lines, "50"), "10");

        [Fact, Trait("Speed", "Fast")]
        public void Day11_1_Sample() => Sample("abcdffaa", AOC2015_11.Solve1, "11");

        [Fact, Trait("Speed", "Fast")]
        public void Day11_1_Actual() => Actual("hxbxxyzz", AOC2015_11.Solve1, "11");

        [Fact, Trait("Speed", "Fast")]
        public void Day11_2_Actual() => Actual("hxcaabcc", AOC2015_11.Solve2, "11");

        [Fact, Trait("Speed", "Fast")]
        public void Day12_1_Sample() => Sample(18L, AOC2015_12.Solve1, "12");

        [Fact, Trait("Speed", "Fast")]
        public void Day12_1_Actual() => Actual(156366L, AOC2015_12.Solve1, "12");

        [Fact, Trait("Speed", "Fast")]
        public void Day12_2_Sample() => Sample(8L, AOC2015_12.Solve2, "12");

        [Fact, Trait("Speed", "Fast")]
        public void Day12_2_Actual() => Actual(96852L, AOC2015_12.Solve2, "12");

        [Fact, Trait("Speed", "Fast")]
        public void Day13_1_Sample() => Sample(330L, AOC2015_13.Solve1, "13");

        [Fact, Trait("Speed", "Fast")]
        public void Day13_1_Actual() => Actual(733L, AOC2015_13.Solve1, "13");

        [Fact, Trait("Speed", "Fast")]
        public void Day13_2_Sample() => Sample(286L, AOC2015_13.Solve2, "13");

        [Fact, Trait("Speed", "Slow")]
        public void Day13_2_Actual() => Actual(725L, AOC2015_13.Solve2, "13");

        [Fact, Trait("Speed", "Fast")]
        public void Day14_1_Sample() => Sample(1120L, lines => AOC2015_14.solve1(lines, "1000"), "14");

        [Fact, Trait("Speed", "Fast")]
        public void Day14_1_Actual() => Actual(2655L, lines => AOC2015_14.solve1(lines, "2503"), "14");

        [Fact, Trait("Speed", "Fast")]
        public void Day14_2_Sample() => Sample(689L, lines => AOC2015_14.solve2(lines, "1000"), "14");

        [Fact, Trait("Speed", "Fast")]
        public void Day14_2_Actual() => Actual(1059L, lines => AOC2015_14.solve2(lines, "2503"), "14");

        [Fact, Trait("Speed", "Fast")]
        public void Day15_1_Sample() => Sample(62842880L, AOC2015_15.Solve1, "15");

        [Fact, Trait("Speed", "Fast")]
        public void Day15_1_Actual() => Actual(222870L, AOC2015_15.Solve1, "15");

        [Fact, Trait("Speed", "Fast")]
        public void Day15_2_Sample() => Sample(57600000L, AOC2015_15.Solve2, "15");

        [Fact, Trait("Speed", "Fast")]
        public void Day15_2_Actual() => Actual(117936L, AOC2015_15.Solve2, "15");

        [Fact, Trait("Speed", "Fast")]
        public void Day16_1_Actual() => Actual(40L, AOC2015_16.Solve1, "16");

        [Fact, Trait("Speed", "Fast")]
        public void Day16_2_Actual() => Actual(241L, AOC2015_16.Solve2, "16");

        [Fact, Trait("Speed", "Fast")]
        public void Day17_1_Sample() => Sample(4L, lines => AOC2015_17.Solve1(lines, "25"), "17");

        [Fact, Trait("Speed", "Fast")]
        public void Day17_1_Actual() => Actual(1304L, lines => AOC2015_17.Solve1(lines, "150"), "17");

        [Fact, Trait("Speed", "Fast")]
        public void Day17_2_Sample() => Sample(3L, lines => AOC2015_17.Solve2(lines, "25"), "17");

        [Fact, Trait("Speed", "Fast")]
        public void Day17_2_Actual() => Actual(18L, lines => AOC2015_17.Solve2(lines, "150"), "17");

        [Fact, Trait("Speed", "Fast")]
        public void Day18_1_Sample() => Sample(4L, lines => AOC2015_18.Solve1(lines, "4"), "18");

        [Fact, Trait("Speed", "Fast")]
        public void Day18_1_Actual() => Actual(768L, lines => AOC2015_18.Solve1(lines, "100"), "18");

        [Fact, Trait("Speed", "Fast")]
        public void Day18_2_Sample() => Sample(17L, lines => AOC2015_18.Solve2(lines, "5"), "18");

        [Fact, Trait("Speed", "Fast")]
        public void Day18_2_Actual() => Actual(781L, lines => AOC2015_18.Solve2(lines, "100"), "18");

        [Fact, Trait("Speed", "Fast")]
        public void Day19_1_Sample() => Sample(4L, AOC2015_19.Solve1, "19");

        [Fact, Trait("Speed", "Fast")]
        public void Day19_1_Actual() => Actual(535L, AOC2015_19.Solve1, "19");

        [Fact, Trait("Speed", "Fast")]
        public void Day19_2_Sample() => Sample(3L, AOC2015_19.Solve2, "19");

        [Fact, Trait("Speed", "Fast")]
        public void Day19_2_Actual() => Actual(212L, AOC2015_19.Solve2, "19");

        [Fact, Trait("Speed", "Slow")]
        public void Day20_1_Actual() => Actual(776160L, AOC2015_20.Solve1, "20");

        [Fact, Trait("Speed", "Slow")]
        public void Day20_2_Actual() => Actual(786240L, AOC2015_20.Solve2, "20");

        [Fact, Trait("Speed", "Fast")]
        public void Day21_1_Actual() => Actual(121L, AOC2015_21.solve1, "21");

        [Fact, Trait("Speed", "Fast")]
        public void Day21_2_Actual() => Actual(201L, AOC2015_21.solve2, "21");

        [Fact, Trait("Speed", "Fast")]
        public void Day22_1_Sample() => Sample(226L, lines => AOC2015_22.Solve1(lines, "10,250"), "22");

        [Fact, Trait("Speed", "Fast")]
        public void Day22_1_Actual() => Actual(953L, lines => AOC2015_22.Solve1(lines, "50,500"), "22");

        [Fact, Trait("Speed", "Fast")]
        public void Day22_2_Actual() => Actual(1289L, lines => AOC2015_22.Solve2(lines, "50,500"), "22");

        [Fact, Trait("Speed", "Fast")]
        public void Day23_1_Sample() => Sample(2L, AOC2015_23.solve1, "23");

        [Fact, Trait("Speed", "Fast")]
        public void Day23_1_Actual() => Actual(255L, AOC2015_23.solve1, "23");

        [Fact, Trait("Speed", "Fast")]
        public void Day23_2_Sample() => Sample(2L, AOC2015_23.solve2, "23");

        [Fact, Trait("Speed", "Fast")]
        public void Day23_2_Actual() => Actual(334L, AOC2015_23.solve2, "23");

        [Fact, Trait("Speed", "Fast")]
        public void Day24_1_Sample() => Sample(99L, AOC2015_24.Solve1, "24");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day24_1_Actual() => Actual(10723906903L, AOC2015_24.Solve1, "24");

        [Fact, Trait("Speed", "Fast")]
        public void Day24_2_Sample() => Sample(44L, AOC2015_24.Solve2, "24");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day24_2_Actual() => Actual(74850409L, AOC2015_24.Solve2, "24");

        [Fact, Trait("Speed", "VerySlow")]
        public void Day25_1_Actual() => Actual(8997277L, AOC2015_25.Solve1, "25");

        private static void Actual<T>(T expected, Func<string[], T> solver, string day)
        {
            Utils.Test(expected, solver, Utils.ReadInput("2015", day, "actual"));
        }

        private static void Sample<T>(T expected, Func<string[], T> solver, string day)
        {
            Utils.Test(expected, solver, Utils.ReadInput("2015", day, "sample"));
        }
    }
}
