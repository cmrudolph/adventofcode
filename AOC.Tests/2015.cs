using System;
using AOC.CSharp;
using AOC.FSharp;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2015
{
    [Test, Property("Speed", "Fast")]
    public void AOC2015_01_1_Sample() => Sample(-1L, AOC2015_01.solve1, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_01_1_Actual() => Actual(74L, AOC2015_01.solve1, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_01_2_Sample() => Sample(5L, AOC2015_01.solve2, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_01_2_Actual() => Actual(1795L, AOC2015_01.solve2, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_02_1_Sample() => Sample(58L, AOC2015_02.solve1, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_02_1_Actual() => Actual(1598415L, AOC2015_02.solve1, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_02_2_Sample() => Sample(34L, AOC2015_02.solve2, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_02_2_Actual() => Actual(3812909L, AOC2015_02.solve2, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_03_1_Sample() => Sample(4L, AOC2015_03.solve1, "03");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_03_1_Actual() => Actual(2572L, AOC2015_03.solve1, "03");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_03_2_Sample() => Sample(3L, AOC2015_03.solve2, "03");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_03_2_Actual() => Actual(2631L, AOC2015_03.solve2, "03");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_04_1_Sample() => Sample(609043L, AOC2015_04.solve1, "04");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_04_1_Actual() => Actual(117946L, AOC2015_04.solve1, "04");

    [Test, Property("Speed", "VerySlow")]
    public void AOC2015_04_2_Sample() => Sample(6742839L, AOC2015_04.solve2, "04");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_04_2_Actual() => Actual(3938038L, AOC2015_04.solve2, "04");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_05_1_Sample() => Sample(2L, AOC2015_05.solve1, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_05_1_Actual() => Actual(258L, AOC2015_05.solve1, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_05_2_Sample() => Sample(0L, AOC2015_05.solve2, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_05_2_Actual() => Actual(53L, AOC2015_05.solve2, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_06_1_Sample() => Sample(998996L, AOC2015_06.solve1, "06");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_06_1_Actual() => Actual(543903L, AOC2015_06.solve1, "06");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_06_2_Sample() => Sample(1001996L, AOC2015_06.solve2, "06");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_06_2_Actual() => Actual(14687245L, AOC2015_06.solve2, "06");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_07_1_Sample() => Sample(114L, AOC2015_07.solve1, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_07_1_Actual() => Actual(956L, AOC2015_07.solve1, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_07_2_Sample() => Sample(114L, AOC2015_07.solve2, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_07_2_Actual() => Actual(40149L, AOC2015_07.solve2, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_08_1_Sample() => Sample(12L, AOC2015_08.solve1, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_08_1_Actual() => Actual(1350L, AOC2015_08.solve1, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_08_2_Sample() => Sample(19L, AOC2015_08.solve2, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_08_2_Actual() => Actual(2085L, AOC2015_08.solve2, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_09_1_Sample() => Sample(605L, AOC2015_09.Solve1, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_09_1_Actual() => Actual(117L, AOC2015_09.Solve1, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_09_2_Sample() => Sample(982L, AOC2015_09.Solve2, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_09_2_Actual() => Actual(909L, AOC2015_09.Solve2, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_10_1_Sample() => Sample(6L, lines => AOC2015_10.Solve(lines, "5"), "10");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_10_1_Actual() => Actual(329356L, lines => AOC2015_10.Solve(lines, "40"), "10");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_10_2_Actual() => Actual(4666278L, lines => AOC2015_10.Solve(lines, "50"), "10");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_11_1_Sample() => Sample("abcdffaa", AOC2015_11.Solve1, "11");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_11_1_Actual() => Actual("hxbxxyzz", AOC2015_11.Solve1, "11");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_11_2_Actual() => Actual("hxcaabcc", AOC2015_11.Solve2, "11");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_12_1_Sample() => Sample(18L, AOC2015_12.Solve1, "12");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_12_1_Actual() => Actual(156366L, AOC2015_12.Solve1, "12");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_12_2_Sample() => Sample(8L, AOC2015_12.Solve2, "12");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_12_2_Actual() => Actual(96852L, AOC2015_12.Solve2, "12");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_13_1_Sample() => Sample(330L, AOC2015_13.Solve1, "13");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_13_1_Actual() => Actual(733L, AOC2015_13.Solve1, "13");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_13_2_Sample() => Sample(286L, AOC2015_13.Solve2, "13");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_13_2_Actual() => Actual(725L, AOC2015_13.Solve2, "13");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_14_1_Sample() => Sample(1120L, lines => AOC2015_14.solve1(lines, "1000"), "14");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_14_1_Actual() => Actual(2655L, lines => AOC2015_14.solve1(lines, "2503"), "14");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_14_2_Sample() => Sample(689L, lines => AOC2015_14.solve2(lines, "1000"), "14");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_14_2_Actual() => Actual(1059L, lines => AOC2015_14.solve2(lines, "2503"), "14");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_15_1_Sample() => Sample(62842880L, AOC2015_15.Solve1, "15");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_15_1_Actual() => Actual(222870L, AOC2015_15.Solve1, "15");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_15_2_Sample() => Sample(57600000L, AOC2015_15.Solve2, "15");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_15_2_Actual() => Actual(117936L, AOC2015_15.Solve2, "15");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_16_1_Actual() => Actual(40L, AOC2015_16.Solve1, "16");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_16_2_Actual() => Actual(241L, AOC2015_16.Solve2, "16");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_17_1_Sample() => Sample(4L, lines => AOC2015_17.Solve1(lines, "25"), "17");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_17_1_Actual() => Actual(1304L, lines => AOC2015_17.Solve1(lines, "150"), "17");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_17_2_Sample() => Sample(3L, lines => AOC2015_17.Solve2(lines, "25"), "17");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_17_2_Actual() => Actual(18L, lines => AOC2015_17.Solve2(lines, "150"), "17");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_18_1_Sample() => Sample(4L, lines => AOC2015_18.Solve1(lines, "4"), "18");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_18_1_Actual() => Actual(768L, lines => AOC2015_18.Solve1(lines, "100"), "18");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_18_2_Sample() => Sample(17L, lines => AOC2015_18.Solve2(lines, "5"), "18");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_18_2_Actual() => Actual(781L, lines => AOC2015_18.Solve2(lines, "100"), "18");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_19_1_Sample() => Sample(4L, AOC2015_19.Solve1, "19");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_19_1_Actual() => Actual(535L, AOC2015_19.Solve1, "19");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_19_2_Sample() => Sample(3L, AOC2015_19.Solve2, "19");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_19_2_Actual() => Actual(212L, AOC2015_19.Solve2, "19");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_20_1_Actual() => Actual(776160L, AOC2015_20.Solve1, "20");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_20_2_Actual() => Actual(786240L, AOC2015_20.Solve2, "20");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_21_1_Actual() => Actual(121L, AOC2015_21.solve1, "21");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_21_2_Actual() => Actual(201L, AOC2015_21.solve2, "21");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_22_1_Sample() => Sample(226L, lines => AOC2015_22.Solve1(lines, "10,250"), "22");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_22_1_Actual() => Actual(953L, lines => AOC2015_22.Solve1(lines, "50,500"), "22");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_22_2_Actual() => Actual(1289L, lines => AOC2015_22.Solve2(lines, "50,500"), "22");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_23_1_Sample() => Sample(2L, AOC2015_23.solve1, "23");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_23_1_Actual() => Actual(255L, AOC2015_23.solve1, "23");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_23_2_Sample() => Sample(2L, AOC2015_23.solve2, "23");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_23_2_Actual() => Actual(334L, AOC2015_23.solve2, "23");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_24_1_Sample() => Sample(99L, AOC2015_24.Solve1, "24");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_24_1_Actual() => Actual(10723906903L, AOC2015_24.Solve1, "24");

    [Test, Property("Speed", "Fast")]
    public void AOC2015_24_2_Sample() => Sample(44L, AOC2015_24.Solve2, "24");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_24_2_Actual() => Actual(74850409L, AOC2015_24.Solve2, "24");

    [Test, Property("Speed", "Slow")]
    public void AOC2015_25_1_Actual() => Actual(8997277L, AOC2015_25.Solve1, "25");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2015", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2015", day, "sample"));
    }
}
