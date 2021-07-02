using AOC.CSharp;
using AOC.FSharp;
using Xunit;

namespace AOC.Tests
{
    public class Year2020
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Sample() => Utils.Test(514579L, AOC2020_01.solve1, ReadSample("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Actual() => Utils.Test(468051L, AOC2020_01.solve1, ReadActual("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Sample() => Utils.Test(241861950L, AOC2020_01.solve2, ReadSample("01"));

        [Fact, Trait("Speed", "Slow")]
        public void Day01_2_Actual() => Utils.Test(272611658L, AOC2020_01.solve2, ReadActual("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Sample() => Utils.Test(2L, AOC2020_02.solve1, ReadSample("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_1_Actual() => Utils.Test(434L, AOC2020_02.solve1, ReadActual("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Sample() => Utils.Test(1L, AOC2020_02.solve2, ReadSample("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day02_2_Actual() => Utils.Test(509L, AOC2020_02.solve2, ReadActual("02"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Sample() => Utils.Test(7L, AOC2020_03.solve1, ReadSample("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_1_Actual() => Utils.Test(211L, AOC2020_03.solve1, ReadActual("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Sample() => Utils.Test(336L, AOC2020_03.solve2, ReadSample("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day03_2_Actual() => Utils.Test(3584591857L, AOC2020_03.solve2, ReadActual("03"));

        [Fact, Trait("Speed", "Fast")]
        public void Day04_1_Sample() => Utils.Test(2L, AOC2020_04.solve1, ReadSample("04"));

        [Fact, Trait("Speed", "Fast")]
        public void Day04_1_Actual() => Utils.Test(226L, AOC2020_04.solve1, ReadActual("04"));

        [Fact, Trait("Speed", "Fast")]
        public void Day04_2_Sample() => Utils.Test(2L, AOC2020_04.solve2, ReadSample("04"));

        [Fact, Trait("Speed", "Fast")]
        public void Day04_2_Actual() => Utils.Test(160L, AOC2020_04.solve2, ReadActual("04"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_1_Sample() => Utils.Test(3L, AOC2020_05.solve1, ReadSample("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_1_Actual() => Utils.Test(933L, AOC2020_05.solve1, ReadActual("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_2_Sample() => Utils.Test(2L, AOC2020_05.solve2, ReadSample("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day05_2_Actual() => Utils.Test(711L, AOC2020_05.solve2, ReadActual("05"));

        [Fact, Trait("Speed", "Fast")]
        public void Day06_1_Sample() => Utils.Test(11L, AOC2020_06.solve1, ReadSample("06"));

        [Fact, Trait("Speed", "Fast")]
        public void Day06_1_Actual() => Utils.Test(6335L, AOC2020_06.solve1, ReadActual("06"));

        [Fact, Trait("Speed", "Fast")]
        public void Day06_2_Sample() => Utils.Test(6L, AOC2020_06.solve2, ReadSample("06"));

        [Fact, Trait("Speed", "Fast")]
        public void Day06_2_Actual() => Utils.Test(3392L, AOC2020_06.solve2, ReadActual("06"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_1_Sample() => Utils.Test(4L, AOC2020_07.solve1, ReadSample("07"));

        [Fact, Trait("Speed", "Slow")]
        public void Day07_1_Actual() => Utils.Test(139L, AOC2020_07.solve1, ReadActual("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Sample() => Utils.Test(32L, AOC2020_07.solve2, ReadSample("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day07_2_Actual() => Utils.Test(58175L, AOC2020_07.solve2, ReadActual("07"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Sample() => Utils.Test(5L, AOC2020_08.solve1, ReadSample("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_1_Actual() => Utils.Test(2003L, AOC2020_08.solve1, ReadActual("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day08_2_Sample() => Utils.Test(8L, AOC2020_08.solve2, ReadSample("08"));

        [Fact, Trait("Speed", "Slow")]
        public void Day08_2_Actual() => Utils.Test(1984L, AOC2020_08.solve2, ReadActual("08"));

        [Fact, Trait("Speed", "Fast")]
        public void Day09_1_Sample() => Utils.Test(127L, lines => AOC2020_09.solve1(5, lines), ReadSample("09"));

        [Fact, Trait("Speed", "Slow")]
        public void Day09_1_Actual() => Utils.Test(1639024365L, lines => AOC2020_09.solve1(25, lines), ReadActual("09"));

        [Fact, Trait("Speed", "Fast")]
        public void Day09_2_Sample() => Utils.Test(62L, lines => AOC2020_09.solve2(5, lines), ReadSample("09"));

        [Fact, Trait("Speed", "Slow")]
        public void Day09_2_Actual() => Utils.Test(219202240L, lines => AOC2020_09.solve2(25, lines), ReadActual("09"));

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Sample() => Utils.Test(35L, AOC2020_10.solve1, ReadSample("10"));

        [Fact, Trait("Speed", "Fast")]
        public void Day10_1_Actual() => Utils.Test(1876L, AOC2020_10.solve1, ReadActual("10"));

        [Fact, Trait("Speed", "Fast")]
        public void Day10_2_Sample() => Utils.Test(8L, AOC2020_10.solve2, ReadSample("10"));

        [Fact, Trait("Speed", "Fast")]
        public void Day10_2_Actual() => Utils.Test(14173478093824L, AOC2020_10.solve2, ReadActual("10"));

        [Fact, Trait("Speed", "Fast")]
        public void Day11_1_Sample() => Utils.Test(37L, AOC2020_11.solve1, ReadSample("11"));

        [Fact, Trait("Speed", "Slow")]
        public void Day11_1_Actual() => Utils.Test(2299L, AOC2020_11.solve1, ReadActual("11"));

        [Fact, Trait("Speed", "Fast")]
        public void Day11_2_Sample() => Utils.Test(26L, AOC2020_11.solve2, ReadSample("11"));

        [Fact, Trait("Speed", "Slow")]
        public void Day11_2_Actual() => Utils.Test(2047L, AOC2020_11.solve2, ReadActual("11"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_1_Sample() => Utils.Test(25L, AOC2020_12.solve1, ReadSample("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_1_Actual() => Utils.Test(998L, AOC2020_12.solve1, ReadActual("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_2_Sample() => Utils.Test(286L, AOC2020_12.solve2, ReadSample("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day12_2_Actual() => Utils.Test(71586L, AOC2020_12.solve2, ReadActual("12"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_1_Sample() => Utils.Test(295L, AOC2020_13.solve1, ReadSample("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_1_Actual() => Utils.Test(104L, AOC2020_13.solve1, ReadActual("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_2_Sample() => Utils.Test(1068781L, AOC2020_13.solve2, ReadSample("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day13_2_Actual() => Utils.Test(842186186521918L, AOC2020_13.solve2, ReadActual("13"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_1_Sample() => Utils.Test(51L, AOC2020_14.Solve1, ReadSample("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_1_Actual() => Utils.Test(4297467072083L, AOC2020_14.Solve1, ReadActual("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_2_Sample() => Utils.Test(208L, AOC2020_14.Solve2, ReadSample("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day14_2_Actual() => Utils.Test(5030603328768L, AOC2020_14.Solve2, ReadActual("14"));

        [Fact, Trait("Speed", "Fast")]
        public void Day15_1_Sample() => Utils.Test(436L, AOC2020_15.solve1, ReadSample("15"));

        [Fact, Trait("Speed", "Fast")]
        public void Day15_1_Actual() => Utils.Test(249L, AOC2020_15.solve1, ReadActual("15"));

        [Fact, Trait("Speed", "VerySlow")]
        public void Day15_2_Sample() => Utils.Test(175594L, AOC2020_15.solve2, ReadSample("15"));

        [Fact, Trait("Speed", "VerySlow")]
        public void Day15_2_Actual() => Utils.Test(41687L, AOC2020_15.solve2, ReadActual("15"));

        [Fact, Trait("Speed", "Fast")]
        public void Day16_1_Sample() => Utils.Test(71L, AOC2020_16.Solve1, ReadSample("16"));

        [Fact, Trait("Speed", "Fast")]
        public void Day16_1_Actual() => Utils.Test(22977L, AOC2020_16.Solve1, ReadActual("16"));

        [Fact, Trait("Speed", "Fast")]
        public void Day16_2_Sample() => Utils.Test(7L, AOC2020_16.Solve2, ReadSample("16"));

        [Fact, Trait("Speed", "Fast")]
        public void Day16_2_Actual() => Utils.Test(998358379943L, AOC2020_16.Solve2, ReadActual("16"));

        [Fact, Trait("Speed", "Fast")]
        public void Day17_1_Sample() => Utils.Test(112L, AOC2020_17.solve1, ReadSample("17"));

        [Fact, Trait("Speed", "Fast")]
        public void Day17_1_Actual() => Utils.Test(298L, AOC2020_17.solve1, ReadActual("17"));

        [Fact, Trait("Speed", "Slow")]
        public void Day17_2_Sample() => Utils.Test(848L, AOC2020_17.solve2, ReadSample("17"));

        [Fact, Trait("Speed", "Slow")]
        public void Day17_2_Actual() => Utils.Test(1792L, AOC2020_17.solve2, ReadActual("17"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_1_Sample() => Utils.Test(26335L, AOC2020_18.Solve1, ReadSample("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_1_Actual() => Utils.Test(209335026987L, AOC2020_18.Solve1, ReadActual("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_2_Sample() => Utils.Test(693891L, AOC2020_18.Solve2, ReadSample("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day18_2_Actual() => Utils.Test(33331817392479L, AOC2020_18.Solve2, ReadActual("18"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_1_Sample() => Utils.Test(2L, AOC2020_19.solve1, ReadSample("19"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_1_Actual() => Utils.Test(147L, AOC2020_19.solve1, ReadActual("19"));

        [Fact, Trait("Speed", "Fast")]
        public void Day19_2_Sample() => Utils.Test(2L, AOC2020_19.solve2, ReadSample("19"));

        [Fact, Trait("Speed", "Slow")]
        public void Day19_2_Actual() => Utils.Test(263L, AOC2020_19.solve2, ReadActual("19"));

        [Fact, Trait("Speed", "Fast")]
        public void Day20_1_Sample() => Utils.Test(20899048083289L, AOC2020_20.solve1, ReadSample("20"));

        [Fact, Trait("Speed", "Slow")]
        public void Day20_1_Actual() => Utils.Test(83775126454273L, AOC2020_20.solve1, ReadActual("20"));

        [Fact, Trait("Speed", "Fast")]
        public void Day20_2_Sample() => Utils.Test(273L, AOC2020_20.solve2, ReadSample("20"));

        [Fact, Trait("Speed", "Slow")]
        public void Day20_2_Actual() => Utils.Test(1993L, AOC2020_20.solve2, ReadActual("20"));

        [Fact, Trait("Speed", "Fast")]
        public void Day21_1_Sample() => Utils.Test(5L, AOC2020_21.Solve1, ReadSample("21"));

        [Fact, Trait("Speed", "Fast")]
        public void Day21_1_Actual() => Utils.Test(2324L, AOC2020_21.Solve1, ReadActual("21"));

        [Fact, Trait("Speed", "Fast")]
        public void Day21_2_Sample() => Utils.Test("mxmxvkd,sqjhc,fvjkl", AOC2020_21.Solve2, ReadSample("21"));

        [Fact, Trait("Speed", "Fast")]
        public void Day21_2_Actual() => Utils.Test("bxjvzk,hqgqj,sp,spl,hsksz,qzzzf,fmpgn,tpnnkc", AOC2020_21.Solve2, ReadActual("21"));

        [Fact, Trait("Speed", "Fast")]
        public void Day22_1_Sample() => Utils.Test(306L, AOC2020_22.solve1, ReadSample("22"));

        [Fact, Trait("Speed", "Fast")]
        public void Day22_1_Actual() => Utils.Test(34664L, AOC2020_22.solve1, ReadActual("22"));

        [Fact, Trait("Speed", "Fast")]
        public void Day22_2_Sample() => Utils.Test(291L, AOC2020_22.solve2, ReadSample("22"));

        [Fact, Trait("Speed", "Slow")]
        public void Day22_2_Actual() => Utils.Test(32018L, AOC2020_22.solve2, ReadActual("22"));

        [Fact, Trait("Speed", "Fast")]
        public void Day23_1_Sample() => Utils.Test("67384529", AOC2020_23.solve1, ReadSample("23"));

        [Fact, Trait("Speed", "Fast")]
        public void Day23_1_Actual() => Utils.Test("98742365", AOC2020_23.solve1, ReadActual("23"));

        [Fact, Trait("Speed", "VerySlow")]
        public void Day23_2_Sample() => Utils.Test(149245887792L, AOC2020_23.solve2, ReadSample("23"));

        [Fact, Trait("Speed", "VerySlow")]
        public void Day23_2_Actual() => Utils.Test(294320513093L, AOC2020_23.solve2, ReadActual("23"));

        [Fact, Trait("Speed", "Fast")]
        public void Day24_1_Sample() => Utils.Test(10L, AOC2020_24.solve1, ReadSample("24"));

        [Fact, Trait("Speed", "Fast")]
        public void Day24_1_Actual() => Utils.Test(400L, AOC2020_24.solve1, ReadActual("24"));

        [Fact, Trait("Speed", "Slow")]
        public void Day24_2_Sample() => Utils.Test(2208L, AOC2020_24.solve2, ReadSample("24"));

        [Fact, Trait("Speed", "VerySlow")]
        public void Day24_2_Actual() => Utils.Test(3768L, AOC2020_24.solve2, ReadActual("24"));

        [Fact, Trait("Speed", "Fast")]
        public void Day25_1_Sample() => Utils.Test(14897079L, AOC2020_25.solve1, ReadSample("25"));

        [Fact, Trait("Speed", "Slow")]
        public void Day25_1_Actual() => Utils.Test(9177528L, AOC2020_25.solve1, ReadActual("25"));

        private static string[] ReadSample(string day)
        {
            return Utils.ReadInput("2020", day, "sample");
        }

        private static string[] ReadActual(string day)
        {
            return Utils.ReadInput("2020", day, "actual");
        }
    }
}
