﻿using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2022
{
    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_1_Sample() => Sample(9L, AOC2022_XX.Solve1, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_1_Actual() => Actual(24000L, AOC2022_XX.Solve1, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_2_Sample() => Sample(6L, AOC2022_XX.Solve2, "XX");

    [Ignore("TODO")]
    [Test, Category("New")]
    public void AOC2022_XX_2_Actual() => Actual(1194L, AOC2022_XX.Solve2, "XX");

    [Test, Category("Fast")]
    public void AOC2022_01_1_Sample() => Sample(24000, AOC2022_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2022_01_1_Actual() => Actual(71124, AOC2022_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2022_01_2_Sample() => Sample(45000, AOC2022_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2022_01_2_Actual() => Actual(204639, AOC2022_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2022_02_1_Sample() => Sample(15, AOC2022_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2022_02_1_Actual() => Actual(11841, AOC2022_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2022_02_2_Sample() => Sample(12, AOC2022_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2022_02_2_Actual() => Actual(13022, AOC2022_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2022_03_1_Sample() => Sample(157, AOC2022_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2022_03_1_Actual() => Actual(7917, AOC2022_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2022_03_2_Sample() => Sample(70, AOC2022_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2022_03_2_Actual() => Actual(2585, AOC2022_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2022_04_1_Sample() => Sample(2, AOC2022_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2022_04_1_Actual() => Actual(580, AOC2022_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2022_04_2_Sample() => Sample(4, AOC2022_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2022_04_2_Actual() => Actual(895, AOC2022_04.Solve2, "04");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2022", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2022", day, "sample"));
    }
}
