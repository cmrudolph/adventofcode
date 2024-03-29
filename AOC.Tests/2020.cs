﻿using AOC.CSharp;
using AOC.FSharp;
using NUnit.Framework;

namespace AOC.Tests.AOC2020;

[Parallelizable(ParallelScope.All)]
public class Tests
{
    private class Day01
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(514579L, AOC2020_01.solve1, "01");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(468051L, AOC2020_01.solve1, "01");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(241861950L, AOC2020_01.solve2, "01");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(272611658L, AOC2020_01.solve2, "01");
    }

    private class Day02
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(2L, AOC2020_02.solve1, "02");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(434L, AOC2020_02.solve1, "02");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(1L, AOC2020_02.solve2, "02");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(509L, AOC2020_02.solve2, "02");
    }

    private class Day03
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(7L, AOC2020_03.solve1, "03");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(211L, AOC2020_03.solve1, "03");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(336L, AOC2020_03.solve2, "03");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(3584591857L, AOC2020_03.solve2, "03");
    }

    private class Day04
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(2L, AOC2020_04.solve1, "04");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(226L, AOC2020_04.solve1, "04");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2L, AOC2020_04.solve2, "04");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(160L, AOC2020_04.solve2, "04");
    }

    private class Day05
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(3L, AOC2020_05.solve1, "05");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(933L, AOC2020_05.solve1, "05");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2L, AOC2020_05.solve2, "05");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(711L, AOC2020_05.solve2, "05");
    }

    private class Day06
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(11L, AOC2020_06.solve1, "06");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(6335L, AOC2020_06.solve1, "06");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(6L, AOC2020_06.solve2, "06");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(3392L, AOC2020_06.solve2, "06");
    }

    private class Day07
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(4L, AOC2020_07.solve1, "07");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual(139L, AOC2020_07.solve1, "07");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(32L, AOC2020_07.solve2, "07");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(58175L, AOC2020_07.solve2, "07");
    }

    private class Day08
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(5L, AOC2020_08.solve1, "08");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(2003L, AOC2020_08.solve1, "08");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(8L, AOC2020_08.solve2, "08");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(1984L, AOC2020_08.solve2, "08");
    }

    private class Day09
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(127L, lines => AOC2020_09.solve1(lines, "5"), "09");

        [Test, Category("Slow")]
        public void _1_Actual() =>
            Actual(1639024365L, lines => AOC2020_09.solve1(lines, "25"), "09");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(62L, lines => AOC2020_09.solve2(lines, "5"), "09");

        [Test, Category("Slow")]
        public void _2_Actual() =>
            Actual(219202240L, lines => AOC2020_09.solve2(lines, "25"), "09");
    }

    private class Day10
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(35L, AOC2020_10.solve1, "10");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(1876L, AOC2020_10.solve1, "10");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(8L, AOC2020_10.solve2, "10");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(14173478093824L, AOC2020_10.solve2, "10");
    }

    private class Day11
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(37L, AOC2020_11.solve1, "11");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual(2299L, AOC2020_11.solve1, "11");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(26L, AOC2020_11.solve2, "11");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(2047L, AOC2020_11.solve2, "11");
    }

    private class Day12
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(25L, AOC2020_12.solve1, "12");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(998L, AOC2020_12.solve1, "12");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(286L, AOC2020_12.solve2, "12");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(71586L, AOC2020_12.solve2, "12");
    }

    private class Day13
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(295L, AOC2020_13.solve1, "13");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(104L, AOC2020_13.solve1, "13");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(1068781L, AOC2020_13.solve2, "13");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(842186186521918L, AOC2020_13.solve2, "13");
    }

    private class Day14
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(51L, AOC2020_14.Solve1, "14");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(4297467072083L, AOC2020_14.Solve1, "14");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(208L, AOC2020_14.Solve2, "14");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(5030603328768L, AOC2020_14.Solve2, "14");
    }

    private class Day15
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(436L, AOC2020_15.solve1, "15");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(249L, AOC2020_15.solve1, "15");

        [Test, Category("VerySlow")]
        public void _2_Sample() => Sample(175594L, AOC2020_15.solve2, "15");

        [Test, Category("VerySlow")]
        public void _2_Actual() => Actual(41687L, AOC2020_15.solve2, "15");
    }

    private class Day16
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(71L, AOC2020_16.Solve1, "16");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(22977L, AOC2020_16.Solve1, "16");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(7L, AOC2020_16.Solve2, "16");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(998358379943L, AOC2020_16.Solve2, "16");
    }

    private class Day17
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(112L, AOC2020_17.solve1, "17");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(298L, AOC2020_17.solve1, "17");

        [Test, Category("Slow")]
        public void _2_Sample() => Sample(848L, AOC2020_17.solve2, "17");

        [Test, Category("VerySlow")]
        public void _2_Actual() => Actual(1792L, AOC2020_17.solve2, "17");
    }

    private class Day18
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(26335L, AOC2020_18.Solve1, "18");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(209335026987L, AOC2020_18.Solve1, "18");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(693891L, AOC2020_18.Solve2, "18");

        [Test, Category("Fast")]
        public void _2_Actual() => Actual(33331817392479L, AOC2020_18.Solve2, "18");
    }

    private class Day19
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(2L, AOC2020_19.solve1, "19");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(147L, AOC2020_19.solve1, "19");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(2L, AOC2020_19.solve2, "19");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(263L, AOC2020_19.solve2, "19");
    }

    private class Day20
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(20899048083289L, AOC2020_20.solve1, "20");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual(83775126454273L, AOC2020_20.solve1, "20");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(273L, AOC2020_20.solve2, "20");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(1993L, AOC2020_20.solve2, "20");
    }

    private class Day21
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(5L, AOC2020_21.Solve1, "21");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(2324L, AOC2020_21.Solve1, "21");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample("mxmxvkd,sqjhc,fvjkl", AOC2020_21.Solve2, "21");

        [Test, Category("Fast")]
        public void _2_Actual() =>
            Actual("bxjvzk,hqgqj,sp,spl,hsksz,qzzzf,fmpgn,tpnnkc", AOC2020_21.Solve2, "21");
    }

    private class Day22
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(306L, AOC2020_22.solve1, "22");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(34664L, AOC2020_22.solve1, "22");

        [Test, Category("Fast")]
        public void _2_Sample() => Sample(291L, AOC2020_22.solve2, "22");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(32018L, AOC2020_22.solve2, "22");
    }

    private class Day23
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample("67384529", AOC2020_23.Solve1, "23");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual("98742365", AOC2020_23.Solve1, "23");

        [Test, Category("Slow")]
        public void _2_Sample() => Sample(149245887792L, AOC2020_23.Solve2, "23");

        [Test, Category("Slow")]
        public void _2_Actual() => Actual(294320513093L, AOC2020_23.Solve2, "23");
    }

    private class Day24
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(10L, AOC2020_24.solve1, "24");

        [Test, Category("Fast")]
        public void _1_Actual() => Actual(400L, AOC2020_24.solve1, "24");

        [Test, Category("Slow")]
        public void _2_Sample() => Sample(2208L, AOC2020_24.solve2, "24");

        [Test, Category("VerySlow")]
        public void _2_Actual() => Actual(3768L, AOC2020_24.solve2, "24");
    }

    private class Day25
    {
        [Test, Category("Fast")]
        public void _1_Sample() => Sample(14897079L, AOC2020_25.solve1, "25");

        [Test, Category("Slow")]
        public void _1_Actual() => Actual(9177528L, AOC2020_25.solve1, "25");
    }

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2020", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2020", day, "sample"));
    }
}
