using AOC.CSharp;
using AOC.FSharp;
using System;
using Xunit;

namespace AOC.Tests
{
    public class Year2015
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_Sample()
        {
            var answer = Tuple.Create(-1L, 5L);
            Utils.SolveAndValidate(answer, AOC2015_01.solve, ReadSample("01"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day01_Actual()
        {
            var answer = Tuple.Create(74L, 1795L);
            Utils.SolveAndValidate(answer, AOC2015_01.solve, ReadActual("01"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day02_Sample()
        {
            var answer = Tuple.Create(58L, 34L);
            Utils.SolveAndValidate(answer, AOC2015_02.solve, ReadSample("02"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day02_Actual()
        {
            var answer = Tuple.Create(1598415L, 3812909L);
            Utils.SolveAndValidate(answer, AOC2015_02.solve, ReadActual("02"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day03_Sample()
        {
            var answer = Tuple.Create(4L, 3L);
            Utils.SolveAndValidate(answer, AOC2015_03.solve, ReadSample("03"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day03_Actual()
        {
            var answer = Tuple.Create(2572L, 2631L);
            Utils.SolveAndValidate(answer, AOC2015_03.solve, ReadActual("03"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day04_Sample()
        {
            var answer = Tuple.Create(609043L, 6742839L);
            Utils.SolveAndValidate(answer, AOC2015_04.solve, ReadSample("04"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day04_Actual()
        {
            var answer = Tuple.Create(117946L, 3938038L);
            Utils.SolveAndValidate(answer, AOC2015_04.solve, ReadActual("04"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day05_Sample()
        {
            var answer = Tuple.Create(2L, 0L);
            Utils.SolveAndValidate(answer, AOC2015_05.solve, ReadSample("05"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day05_Actual()
        {
            var answer = Tuple.Create(258L, 53L);
            Utils.SolveAndValidate(answer, AOC2015_05.solve, ReadActual("05"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day06_Sample()
        {
            var answer = Tuple.Create(998996L, 1001996L);
            Utils.SolveAndValidate(answer, AOC2015_06.solve, ReadSample("06"));
        }

        [Fact, Trait("Speed", "Slow")]
        public void Day06_Actual()
        {
            var answer = Tuple.Create(543903L, 14687245L);
            Utils.SolveAndValidate(answer, AOC2015_06.solve, ReadActual("06"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day07_Sample()
        {
            var answer = Tuple.Create(114L, 114L);
            Utils.SolveAndValidate(answer, AOC2015_07.solve, ReadSample("07"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day07_Actual()
        {
            var answer = Tuple.Create(956L, 40149L);
            Utils.SolveAndValidate(answer, AOC2015_07.solve, ReadActual("07"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day08_Sample()
        {
            var answer = Tuple.Create(12L, 19L);
            Utils.SolveAndValidate(answer, AOC2015_08.solve, ReadSample("08"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day08_Actual()
        {
            var answer = Tuple.Create(1350L, 2085L);
            Utils.SolveAndValidate(answer, AOC2015_08.solve, ReadActual("08"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day09_Sample()
        {
            var answer = Tuple.Create(605L, 982L);
            Utils.SolveAndValidate(answer, AOC2015_09.Solve, ReadSample("09"));
        }

        [Fact, Trait("Speed", "Fast")]
        public void Day09_Actual()
        {
            var answer = Tuple.Create(117L, 909L);
            Utils.SolveAndValidate(answer, AOC2015_09.Solve, ReadActual("09"));
        }

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
