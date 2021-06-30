using AOC.CSharp;
using AOC.FSharp;
using System;
using Xunit;

namespace AOC.Tests
{
    public class Year2020
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_Sample()
        {
            var answer = Tuple.Create(514579L, 241861950L);
            Utils.SolveAndValidate(answer, AOC2020_01.solve, ReadSample("01"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day01_Actual()
        {
            var answer = Tuple.Create(468051L, 272611658L);
            Utils.SolveAndValidate(answer, AOC2020_01.solve, ReadActual("01"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day02_Sample()
        {
            var answer = Tuple.Create(2L, 1L);
            Utils.SolveAndValidate(answer, AOC2020_02.solve, ReadSample("02"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day02_Actual()
        {
            var answer = Tuple.Create(434L, 509L);
            Utils.SolveAndValidate(answer, AOC2020_02.solve, ReadActual("02"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day03_Sample()
        {
            var answer = Tuple.Create(7L, 336L);
            Utils.SolveAndValidate(answer, AOC2020_03.solve, ReadSample("03"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day03_Actual()
        {
            var answer = Tuple.Create(211L, 3584591857L);
            Utils.SolveAndValidate(answer, AOC2020_03.solve, ReadActual("03"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day04_Sample()
        {
            var answer = Tuple.Create(2L, 2L);
            Utils.SolveAndValidate(answer, AOC2020_04.solve, ReadSample("04"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day04_Actual()
        {
            var answer = Tuple.Create(226L, 160L);
            Utils.SolveAndValidate(answer, AOC2020_04.solve, ReadActual("04"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day05_Sample()
        {
            var answer = Tuple.Create(3L, 2L);
            Utils.SolveAndValidate(answer, AOC2020_05.solve, ReadSample("05"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day05_Actual()
        {
            var answer = Tuple.Create(933L, 711L);
            Utils.SolveAndValidate(answer, AOC2020_05.solve, ReadActual("05"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day06_Sample()
        {
            var answer = Tuple.Create(11L, 6L);
            Utils.SolveAndValidate(answer, AOC2020_06.solve, ReadSample("06"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day06_Actual()
        {
            var answer = Tuple.Create(6335L, 3392L);
            Utils.SolveAndValidate(answer, AOC2020_06.solve, ReadActual("06"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day07_Sample()
        {
            var answer = Tuple.Create(4L, 32L);
            Utils.SolveAndValidate(answer, AOC2020_07.solve, ReadSample("07"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day07_Actual()
        {
            var answer = Tuple.Create(139L, 58175L);
            Utils.SolveAndValidate(answer, AOC2020_07.solve, ReadActual("07"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day08_Sample()
        {
            var answer = Tuple.Create(5L, 8L);
            Utils.SolveAndValidate(answer, AOC2020_08.solve, ReadSample("08"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day08_Actual()
        {
            var answer = Tuple.Create(2003L, 1984L);
            Utils.SolveAndValidate(answer, AOC2020_08.solve, ReadActual("08"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day09_Sample()
        {
            var answer = Tuple.Create(127L, 62L);
            Utils.SolveAndValidate(answer, lines => AOC2020_09.solve(5, lines), ReadSample("09"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day09_Actual()
        {
            var answer = Tuple.Create(1639024365L, 219202240L);
            Utils.SolveAndValidate(answer, lines => AOC2020_09.solve(25, lines), ReadActual("09"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day10_Sample()
        {
            var answer = Tuple.Create(35L, 8L);
            Utils.SolveAndValidate(answer, AOC2020_10.solve, ReadSample("10"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day10_Actual()
        {
            var answer = Tuple.Create(1876L, 14173478093824L);
            Utils.SolveAndValidate(answer, AOC2020_10.solve, ReadActual("10"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day11_Sample()
        {
            var answer = Tuple.Create(37L, 26L);
            Utils.SolveAndValidate(answer, AOC2020_11.solve, ReadSample("11"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day11_Actual()
        {
            var answer = Tuple.Create(2299L, 2047L);
            Utils.SolveAndValidate(answer, AOC2020_11.solve, ReadActual("11"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day12_Sample()
        {
            var answer = Tuple.Create(25L, 286L);
            Utils.SolveAndValidate(answer, AOC2020_12.solve, ReadSample("12"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day12_Actual()
        {
            var answer = Tuple.Create(998L, 71586L);
            Utils.SolveAndValidate(answer, AOC2020_12.solve, ReadActual("12"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day13_Sample()
        {
            var answer = Tuple.Create(295L, 1068781L);
            Utils.SolveAndValidate(answer, AOC2020_13.solve, ReadSample("13"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day13_Actual()
        {
            var answer = Tuple.Create(104L, 842186186521918L);
            Utils.SolveAndValidate(answer, AOC2020_13.solve, ReadActual("13"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day14_Sample()
        {
            var answer = Tuple.Create(51L, 208L);
            Utils.SolveAndValidate(answer, AOC2020_14.Solve, ReadSample("14"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day14_Actual()
        {
            var answer = Tuple.Create(4297467072083L, 5030603328768L);
            Utils.SolveAndValidate(answer, AOC2020_14.Solve, ReadActual("14"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day15_Sample()
        {
            var answer = Tuple.Create(436L, 175594L);
            Utils.SolveAndValidate(answer, AOC2020_15.solve, ReadSample("15"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day15_Actual()
        {
            var answer = Tuple.Create(249L, 41687L);
            Utils.SolveAndValidate(answer, AOC2020_15.solve, ReadActual("15"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day16_Sample()
        {
            var answer = Tuple.Create(71L, 7L);
            Utils.SolveAndValidate(answer, AOC2020_16.Solve, ReadSample("16"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day16_Actual()
        {
            var answer = Tuple.Create(22977L, 998358379943L);
            Utils.SolveAndValidate(answer, AOC2020_16.Solve, ReadActual("16"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day17_Sample()
        {
            var answer = Tuple.Create(112L, 848L);
            Utils.SolveAndValidate(answer, AOC2020_17.solve, ReadSample("17"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day17_Actual()
        {
            var answer = Tuple.Create(298L, 1792L);
            Utils.SolveAndValidate(answer, AOC2020_17.solve, ReadActual("17"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day18_Sample()
        {
            var answer = Tuple.Create(26335L, 693891L);
            Utils.SolveAndValidate(answer, AOC2020_18.Solve, ReadSample("18"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day18_Actual()
        {
            var answer = Tuple.Create(209335026987L, 33331817392479L);
            Utils.SolveAndValidate(answer, AOC2020_18.Solve, ReadActual("18"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day19_Sample()
        {
            var answer = Tuple.Create(2L, 2L);
            Utils.SolveAndValidate(answer, AOC2020_19.solve, ReadSample("19"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day19_Actual()
        {
            var answer = Tuple.Create(147L, 263L);
            Utils.SolveAndValidate(answer, AOC2020_19.solve, ReadActual("19"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day20_Sample()
        {
            var answer = Tuple.Create(20899048083289L, 273L);
            Utils.SolveAndValidate(answer, AOC2020_20.solve, ReadSample("20"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day20_Actual()
        {
            var answer = Tuple.Create(83775126454273L, 1993L);
            Utils.SolveAndValidate(answer, AOC2020_20.solve, ReadActual("20"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day21_Sample()
        {
            var answer = Tuple.Create(5L, "mxmxvkd,sqjhc,fvjkl");
            Utils.SolveAndValidate(answer, AOC2020_21.Solve, ReadSample("21"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day21_Actual()
        {
            var answer = Tuple.Create(2324L, "bxjvzk,hqgqj,sp,spl,hsksz,qzzzf,fmpgn,tpnnkc");
            Utils.SolveAndValidate(answer, AOC2020_21.Solve, ReadActual("21"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day22_Sample()
        {
            var answer = Tuple.Create(306L, 291L);
            Utils.SolveAndValidate(answer, AOC2020_22.solve, ReadSample("22"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day22_Actual()
        {
            var answer = Tuple.Create(34664L, 32018L);
            Utils.SolveAndValidate(answer, AOC2020_22.solve, ReadActual("22"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day23_Sample()
        {
            var answer = Tuple.Create("67384529", 149245887792L);
            Utils.SolveAndValidate(answer, AOC2020_23.solve, ReadSample("23"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day23_Actual()
        {
            var answer = Tuple.Create("98742365", 294320513093L);
            Utils.SolveAndValidate(answer, AOC2020_23.solve, ReadActual("23"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day24_Sample()
        {
            var answer = Tuple.Create(10L, 2208L);
            Utils.SolveAndValidate(answer, AOC2020_24.solve, ReadSample("24"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day24_Actual()
        {
            var answer = Tuple.Create(400L, 3768L);
            Utils.SolveAndValidate(answer, AOC2020_24.solve, ReadActual("24"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day25_Sample()
        {
            var answer = Tuple.Create(14897079L, 0L);
            Utils.SolveAndValidate(answer, AOC2020_25.solve, ReadSample("25"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day25_Actual()
        {
            var answer = Tuple.Create(9177528L, 0L);
            Utils.SolveAndValidate(answer, AOC2020_25.solve, ReadActual("25"));
        }

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
