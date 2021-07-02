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
