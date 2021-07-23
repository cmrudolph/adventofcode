using AOC.CSharp;
using AOC.FSharp;
using Xunit;

namespace AOC.Tests
{
    public class Year2015
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Sample() => Utils.Test(-1L, AOC2015_01.solve1, ReadSample("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Actual() => Utils.Test(74L, AOC2015_01.solve1, ReadActual("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Sample() => Utils.Test(5L, AOC2015_01.solve2, ReadSample("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Actual() => Utils.Test(1795L, AOC2015_01.solve2, ReadActual("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Sample() => Utils.Test(58L, AOC2015_02.solve1, ReadSample("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Actual() => Utils.Test(1598415L, AOC2015_02.solve1, ReadActual("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Sample() => Utils.Test(34L, AOC2015_02.solve2, ReadSample("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Actual() => Utils.Test(3812909L, AOC2015_02.solve2, ReadActual("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Sample() => Utils.Test(4L, AOC2015_03.solve1, ReadSample("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Actual() => Utils.Test(2572L, AOC2015_03.solve1, ReadActual("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Sample() => Utils.Test(3L, AOC2015_03.solve2, ReadSample("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Actual() => Utils.Test(2631L, AOC2015_03.solve2, ReadActual("03"));

        [Fact, Trait("Speed", "Slow")]
        public void Day04_1_Sample() => Utils.Test(609043L, AOC2015_04.solve1, ReadSample("04"));

        [Fact, Trait("Speed", "Fast")]
        public void Day04_1_Actual() => Utils.Test(117946L, AOC2015_04.solve1, ReadActual("04"));

        [Fact, Trait("Speed", "Slow")]
        public void Day04_2_Sample() => Utils.Test(6742839L, AOC2015_04.solve2, ReadSample("04"));

        [Fact, Trait("Speed", "Slow")]
        public void Day04_2_Actual() => Utils.Test(3938038L, AOC2015_04.solve2, ReadActual("04"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_1_Sample() => Utils.Test(2L, AOC2015_05.solve1, ReadSample("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_1_Actual() => Utils.Test(258L, AOC2015_05.solve1, ReadActual("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_2_Sample() => Utils.Test(0L, AOC2015_05.solve2, ReadSample("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_2_Actual() => Utils.Test(53L, AOC2015_05.solve2, ReadActual("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day06_1_Sample() => Utils.Test(998996L, AOC2015_06.solve1, ReadSample("06"));

        [Fact, Trait("Speed", "Slow")]
        public void Day06_1_Actual() => Utils.Test(543903L, AOC2015_06.solve1, ReadActual("06"));

        [Fact, Trait("Speed", "Fast")]
        public void Day06_2_Sample() => Utils.Test(1001996L, AOC2015_06.solve2, ReadSample("06"));

        [Fact, Trait("Speed", "Slow")]
        public void Day06_2_Actual() => Utils.Test(14687245L, AOC2015_06.solve2, ReadActual("06"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Sample() => Utils.Test(114L, AOC2015_07.solve1, ReadSample("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Actual() => Utils.Test(956L, AOC2015_07.solve1, ReadActual("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Sample() => Utils.Test(114L, AOC2015_07.solve2, ReadSample("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Actual() => Utils.Test(40149L, AOC2015_07.solve2, ReadActual("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Sample() => Utils.Test(12L, AOC2015_08.solve1, ReadSample("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Actual() => Utils.Test(1350L, AOC2015_08.solve1, ReadActual("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_2_Sample() => Utils.Test(19L, AOC2015_08.solve2, ReadSample("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_2_Actual() => Utils.Test(2085L, AOC2015_08.solve2, ReadActual("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Sample() => Utils.Test(605L, AOC2015_09.Solve1, ReadSample("09"));

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Actual() => Utils.Test(117L, AOC2015_09.Solve1, ReadActual("09"));

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Sample() => Utils.Test(982L, AOC2015_09.Solve2, ReadSample("09"));

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Actual() => Utils.Test(909L, AOC2015_09.Solve2, ReadActual("09"));

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Sample() => Utils.Test(6L, lines => AOC2015_10.Solve(lines, 5), ReadSample("10"));

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Actual() => Utils.Test(329356L, lines => AOC2015_10.Solve(lines, 40), ReadActual("10"));

        [Fact, Trait("Speed", "Slow")]
        public void Day10_2_Actual() => Utils.Test(4666278L, lines => AOC2015_10.Solve(lines, 50), ReadActual("10"));

        [Fact, Trait("Speed", "Fast")]
        public void Day11_1_Sample() => Utils.Test("abcdffaa", AOC2015_11.Solve1, ReadSample("11"));

        [Fact, Trait("Speed", "Fast")]
        public void Day11_1_Actual() => Utils.Test("hxbxxyzz", AOC2015_11.Solve1, ReadActual("11"));

        [Fact, Trait("Speed", "Fast")]
        public void Day11_2_Actual() => Utils.Test("hxcaabcc", AOC2015_11.Solve2, ReadActual("11"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_1_Sample() => Utils.Test(18L, AOC2015_12.Solve1, ReadSample("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_1_Actual() => Utils.Test(156366L, AOC2015_12.Solve1, ReadActual("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_2_Sample() => Utils.Test(8L, AOC2015_12.Solve2, ReadSample("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_2_Actual() => Utils.Test(96852L, AOC2015_12.Solve2, ReadActual("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_1_Sample() => Utils.Test(330L, AOC2015_13.Solve1, ReadSample("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_1_Actual() => Utils.Test(733L, AOC2015_13.Solve1, ReadActual("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_2_Sample() => Utils.Test(286L, AOC2015_13.Solve2, ReadSample("13"));

        [Fact, Trait("Speed", "Slow")]
        public void Day13_2_Actual() => Utils.Test(725L, AOC2015_13.Solve2, ReadActual("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_1_Sample() => Utils.Test(1120L, lines => AOC2015_14.solve1(lines, 1000), ReadSample("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_1_Actual() => Utils.Test(2655L, lines => AOC2015_14.solve1(lines, 2503), ReadActual("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_2_Sample() => Utils.Test(689L, lines => AOC2015_14.solve2(lines, 1000), ReadSample("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_2_Actual() => Utils.Test(1059L, lines => AOC2015_14.solve2(lines, 2503), ReadActual("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day15_1_Sample() => Utils.Test(62842210L, AOC2015_15.Solve1, ReadSample("15"));

        [Fact, Trait("Speed", "Fast")]
        public void Day15_1_Actual() => Utils.Test(222870L, AOC2015_15.Solve1, ReadActual("15"));

        [Fact, Trait("Speed", "Fast")]
        public void Day15_2_Sample() => Utils.Test(57600000L, AOC2015_15.Solve2, ReadSample("15"));

        [Fact, Trait("Speed", "Fast")]
        public void Day15_2_Actual() => Utils.Test(117936L, AOC2015_15.Solve2, ReadActual("15"));

        [Fact, Trait("Speed", "Fast")]
        public void Day16_1_Actual() => Utils.Test(40L, AOC2015_16.Solve1, ReadActual("16"));

        [Fact, Trait("Speed", "Fast")]
        public void Day16_2_Actual() => Utils.Test(241L, AOC2015_16.Solve2, ReadActual("16"));

        [Fact, Trait("Speed", "Fast")]
        public void Day17_1_Sample() => Utils.Test(4L, lines => AOC2015_17.Solve1(lines, 25), ReadSample("17"));

        [Fact, Trait("Speed", "Fast")]
        public void Day17_1_Actual() => Utils.Test(1304L, lines => AOC2015_17.Solve1(lines, 150), ReadActual("17"));

        [Fact, Trait("Speed", "Fast")]
        public void Day17_2_Sample() => Utils.Test(3L, lines => AOC2015_17.Solve2(lines, 25), ReadSample("17"));

        [Fact, Trait("Speed", "Fast")]
        public void Day17_2_Actual() => Utils.Test(18L, lines => AOC2015_17.Solve2(lines, 150), ReadActual("17"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_1_Sample() => Utils.Test(4L, lines => AOC2015_18.Solve1(lines, 4), ReadSample("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_1_Actual() => Utils.Test(768L, lines => AOC2015_18.Solve1(lines, 100), ReadActual("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_2_Sample() => Utils.Test(17L, lines => AOC2015_18.Solve2(lines, 5), ReadSample("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_2_Actual() => Utils.Test(781L, lines => AOC2015_18.Solve2(lines, 100), ReadActual("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_1_Sample() => Utils.Test(4L, AOC2015_19.Solve1, ReadSample("19"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_1_Actual() => Utils.Test(535L, AOC2015_19.Solve1, ReadActual("19"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_2_Sample() => Utils.Test(3L, AOC2015_19.Solve2, ReadSample("19"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_2_Actual() => Utils.Test(212L, AOC2015_19.Solve2, ReadActual("19"));

        [Fact, Trait("Speed", "Slow")]
        public void Day20_1_Actual() => Utils.Test(776160L, AOC2015_20.Solve1, ReadActual("20"));

        [Fact, Trait("Speed", "Slow")]
        public void Day20_2_Actual() => Utils.Test(786240L, AOC2015_20.Solve2, ReadActual("20"));

        [Fact, Trait("Speed", "Fast")]
        public void Day21_1_Actual() => Utils.Test(121L, AOC2015_21.solve1, ReadActual("21"));

        [Fact, Trait("Speed", "Fast")]
        public void Day21_2_Actual() => Utils.Test(201L, AOC2015_21.solve2, ReadActual("21"));

        [Fact, Trait("Speed", "Fast")]
        public void Day22_1_Sample() => Utils.Test(226L, lines => AOC2015_22.Solve1(lines, 10, 250), ReadSample("22"));

        [Fact, Trait("Speed", "Fast")]
        public void Day22_1_Actual() => Utils.Test(953L, lines => AOC2015_22.Solve1(lines, 50, 500), ReadActual("22"));

        [Fact, Trait("Speed", "Fast")]
        public void Day22_2_Actual() => Utils.Test(1289L, lines => AOC2015_22.Solve2(lines, 50, 500), ReadActual("22"));

        private static string[] ReadSample(string day)
        {
            return Utils.ReadInput("2015", day, "sample");
        }

        private static string[] ReadActual(string day)
        {
            return Utils.ReadInput("2015", day, "actual");
        }
    }
}
