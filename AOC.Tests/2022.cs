using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests.AOC2022;

public class Tests
{
    public class Day01
    {
        [Test, Category("Fast")]
        public void AOC2022_01_1_Sample() => Sample(24000, AOC2022_01.Solve1, "01");

        [Test, Category("Fast")]
        public void AOC2022_01_1_Actual() => Actual(71124, AOC2022_01.Solve1, "01");

        [Test, Category("Fast")]
        public void AOC2022_01_2_Sample() => Sample(45000, AOC2022_01.Solve2, "01");

        [Test, Category("Fast")]
        public void AOC2022_01_2_Actual() => Actual(204639, AOC2022_01.Solve2, "01");
    }

    private class Day02
    {
        [Test, Category("Fast")]
        public void AOC2022_02_1_Sample() => Sample(15, AOC2022_02.Solve1, "02");

        [Test, Category("Fast")]
        public void AOC2022_02_1_Actual() => Actual(11841, AOC2022_02.Solve1, "02");

        [Test, Category("Fast")]
        public void AOC2022_02_2_Sample() => Sample(12, AOC2022_02.Solve2, "02");

        [Test, Category("Fast")]
        public void AOC2022_02_2_Actual() => Actual(13022, AOC2022_02.Solve2, "02");
    }

    private class Day03
    {
        [Test, Category("Fast")]
        public void AOC2022_03_1_Sample() => Sample(157, AOC2022_03.Solve1, "03");

        [Test, Category("Fast")]
        public void AOC2022_03_1_Actual() => Actual(7917, AOC2022_03.Solve1, "03");

        [Test, Category("Fast")]
        public void AOC2022_03_2_Sample() => Sample(70, AOC2022_03.Solve2, "03");

        [Test, Category("Fast")]
        public void AOC2022_03_2_Actual() => Actual(2585, AOC2022_03.Solve2, "03");
    }

    private class Day04
    {
        [Test, Category("Fast")]
        public void AOC2022_04_1_Sample() => Sample(2, AOC2022_04.Solve1, "04");

        [Test, Category("Fast")]
        public void AOC2022_04_1_Actual() => Actual(580, AOC2022_04.Solve1, "04");

        [Test, Category("Fast")]
        public void AOC2022_04_2_Sample() => Sample(4, AOC2022_04.Solve2, "04");

        [Test, Category("Fast")]
        public void AOC2022_04_2_Actual() => Actual(895, AOC2022_04.Solve2, "04");
    }

    private class Day05
    {
        [Test, Category("Fast")]
        public void AOC2022_05_1_Sample() => Sample("CMZ", AOC2022_05.Solve1, "05");

        [Test, Category("Fast")]
        public void AOC2022_05_1_Actual() => Actual("RFFFWBPNS", AOC2022_05.Solve1, "05");

        [Test, Category("Fast")]
        public void AOC2022_05_2_Sample() => Sample("MCD", AOC2022_05.Solve2, "05");

        [Test, Category("Fast")]
        public void AOC2022_05_2_Actual() => Actual("CQQBBJFCS", AOC2022_05.Solve2, "05");
    }

    private class Day06
    {
        [Test, Category("Fast")]
        public void AOC2022_06_1_Sample() => Sample(7, AOC2022_06.Solve1, "06");

        [Test, Category("Fast")]
        public void AOC2022_06_1_Actual() => Actual(1965, AOC2022_06.Solve1, "06");

        [Test, Category("Fast")]
        public void AOC2022_06_2_Sample() => Sample(19, AOC2022_06.Solve2, "06");

        [Test, Category("Fast")]
        public void AOC2022_06_2_Actual() => Actual(2773, AOC2022_06.Solve2, "06");
    }

    private class Day07
    {
        [Test, Category("Fast")]
        public void AOC2022_07_1_Sample() => Sample(95437, AOC2022_07.Solve1, "07");

        [Test, Category("Fast")]
        public void AOC2022_07_1_Actual() => Actual(1491614, AOC2022_07.Solve1, "07");

        [Test, Category("Fast")]
        public void AOC2022_07_2_Sample() => Sample(24933642, AOC2022_07.Solve2, "07");

        [Test, Category("Fast")]
        public void AOC2022_07_2_Actual() => Actual(6400111, AOC2022_07.Solve2, "07");
    }

    private class Day08
    {
        [Test, Category("Fast")]
        public void AOC2022_08_1_Sample() => Sample(21, AOC2022_08.Solve1, "08");

        [Test, Category("Fast")]
        public void AOC2022_08_1_Actual() => Actual(1809, AOC2022_08.Solve1, "08");

        [Test, Category("Fast")]
        public void AOC2022_08_2_Sample() => Sample(8, AOC2022_08.Solve2, "08");

        [Test, Category("Fast")]
        public void AOC2022_08_2_Actual() => Actual(479400, AOC2022_08.Solve2, "08");
    }

    private class Day09
    {
        [Test, Category("Fast")]
        public void AOC2022_09_1_Sample() => Sample(88, AOC2022_09.Solve1, "09");

        [Test, Category("Fast")]
        public void AOC2022_09_1_Actual() => Actual(6271, AOC2022_09.Solve1, "09");

        [Test, Category("Fast")]
        public void AOC2022_09_2_Sample() => Sample(36, AOC2022_09.Solve2, "09");

        [Test, Category("Fast")]
        public void AOC2022_09_2_Actual() => Actual(2458, AOC2022_09.Solve2, "09");
    }

    private class Day10
    {
        [Test, Category("Fast")]
        public void AOC2022_10_1_Sample() => Sample(13140, AOC2022_10.Solve1, "10");

        [Test, Category("Fast")]
        public void AOC2022_10_1_Actual() => Actual(13860, AOC2022_10.Solve1, "10");

        // Run and inspect output
        [Test, Category("Fast")]
        public void AOC2022_10_2_Sample() => Sample(0, AOC2022_10.Solve2, "10");

        // Run and inspect output
        [Test, Category("Fast")]
        public void AOC2022_10_2_Actual() => Actual(0, AOC2022_10.Solve2, "10");
    }

    private class Day11
    {
        [Test, Category("Fast")]
        public void AOC2022_11_1_Sample() => Sample(10605, AOC2022_11.Solve1, "11");

        [Test, Category("Fast")]
        public void AOC2022_11_1_Actual() => Actual(151312, AOC2022_11.Solve1, "11");

        [Test, Category("Fast")]
        public void AOC2022_11_2_Sample() => Sample(2713310158, AOC2022_11.Solve2, "11");

        [Test, Category("Fast")]
        public void AOC2022_11_2_Actual() => Actual(51382025916, AOC2022_11.Solve2, "11");
    }

    private class Day12
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_12_1_Sample() => Sample(9L, AOC2022_12.Solve1, "12");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_12_1_Actual() => Actual(24000L, AOC2022_12.Solve1, "12");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_12_2_Sample() => Sample(6L, AOC2022_12.Solve2, "12");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_12_2_Actual() => Actual(1194L, AOC2022_12.Solve2, "12");
    }

    private class Day13
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_13_1_Sample() => Sample(9L, AOC2022_13.Solve1, "13");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_13_1_Actual() => Actual(24000L, AOC2022_13.Solve1, "13");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_13_2_Sample() => Sample(6L, AOC2022_13.Solve2, "13");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_13_2_Actual() => Actual(1194L, AOC2022_13.Solve2, "13");
    }

    private class Day14
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_14_1_Sample() => Sample(9L, AOC2022_14.Solve1, "14");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_14_1_Actual() => Actual(24000L, AOC2022_14.Solve1, "14");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_14_2_Sample() => Sample(6L, AOC2022_14.Solve2, "14");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_14_2_Actual() => Actual(1194L, AOC2022_14.Solve2, "14");
    }

    private class Day15
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_15_1_Sample() => Sample(9L, AOC2022_15.Solve1, "15");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_15_1_Actual() => Actual(24000L, AOC2022_15.Solve1, "15");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_15_2_Sample() => Sample(6L, AOC2022_15.Solve2, "15");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_15_2_Actual() => Actual(1194L, AOC2022_15.Solve2, "15");
    }

    public class Day16
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_16_1_Sample() => Sample(9L, AOC2022_16.Solve1, "16");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_16_1_Actual() => Actual(24000L, AOC2022_16.Solve1, "16");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_16_2_Sample() => Sample(6L, AOC2022_16.Solve2, "16");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_16_2_Actual() => Actual(1194L, AOC2022_16.Solve2, "16");
    }

    public class Day17
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_17_1_Sample() => Sample(9L, AOC2022_17.Solve1, "17");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_17_1_Actual() => Actual(24000L, AOC2022_17.Solve1, "17");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_17_2_Sample() => Sample(6L, AOC2022_17.Solve2, "17");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_17_2_Actual() => Actual(1194L, AOC2022_17.Solve2, "17");
    }

    public class Day18
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_18_1_Sample() => Sample(9L, AOC2022_18.Solve1, "18");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_18_1_Actual() => Actual(24000L, AOC2022_18.Solve1, "18");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_18_2_Sample() => Sample(6L, AOC2022_18.Solve2, "18");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_18_2_Actual() => Actual(1194L, AOC2022_18.Solve2, "18");
    }

    public class Day19
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_19_1_Sample() => Sample(9L, AOC2022_19.Solve1, "19");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_19_1_Actual() => Actual(24000L, AOC2022_19.Solve1, "19");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_19_2_Sample() => Sample(6L, AOC2022_19.Solve2, "19");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_19_2_Actual() => Actual(1194L, AOC2022_19.Solve2, "19");
    }

    public class Day20
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_20_1_Sample() => Sample(9L, AOC2022_20.Solve1, "20");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_20_1_Actual() => Actual(24000L, AOC2022_20.Solve1, "20");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_20_2_Sample() => Sample(6L, AOC2022_20.Solve2, "20");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_20_2_Actual() => Actual(1194L, AOC2022_20.Solve2, "20");
    }

    public class Day21
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_21_1_Sample() => Sample(9L, AOC2022_21.Solve1, "21");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_21_1_Actual() => Actual(24000L, AOC2022_21.Solve1, "21");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_21_2_Sample() => Sample(6L, AOC2022_21.Solve2, "21");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_21_2_Actual() => Actual(1194L, AOC2022_21.Solve2, "21");
    }

    public class Day22
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_22_1_Sample() => Sample(9L, AOC2022_22.Solve1, "22");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_22_1_Actual() => Actual(24000L, AOC2022_22.Solve1, "22");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_22_2_Sample() => Sample(6L, AOC2022_22.Solve2, "22");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_22_2_Actual() => Actual(1194L, AOC2022_22.Solve2, "22");
    }

    public class Day23
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_23_1_Sample() => Sample(9L, AOC2022_23.Solve1, "23");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_23_1_Actual() => Actual(24000L, AOC2022_23.Solve1, "23");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_23_2_Sample() => Sample(6L, AOC2022_23.Solve2, "23");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_23_2_Actual() => Actual(1194L, AOC2022_23.Solve2, "23");
    }

    public class Day24
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_24_1_Sample() => Sample(9L, AOC2022_24.Solve1, "24");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_24_1_Actual() => Actual(24000L, AOC2022_24.Solve1, "24");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_24_2_Sample() => Sample(6L, AOC2022_24.Solve2, "24");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_24_2_Actual() => Actual(1194L, AOC2022_24.Solve2, "24");
    }

    public class Day25
    {
        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_25_1_Sample() => Sample(9L, AOC2022_25.Solve1, "25");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_25_1_Actual() => Actual(24000L, AOC2022_25.Solve1, "25");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_25_2_Sample() => Sample(6L, AOC2022_25.Solve2, "25");

        [Ignore("TODO")]
        [Test, Category("New")]
        public void AOC2022_25_2_Actual() => Actual(1194L, AOC2022_25.Solve2, "25");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2022", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2022", day, "sample"));
    }
}
