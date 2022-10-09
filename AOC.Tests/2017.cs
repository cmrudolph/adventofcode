using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2017
{
    [TestCase("1122", 3)]
    [TestCase("1111", 4)]
    [TestCase("1234", 0)]
    [TestCase("91212129", 9)]
    [Category("Fast")]
    public void AOC2017_01_1_Cases(string input, int expected)
    {
        long result = AOC2017_01.Solve1(new[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_01_1_Sample() => Sample(9L, AOC2017_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2017_01_1_Actual() => Actual(1144L, AOC2017_01.Solve1, "01");

    [TestCase("1212", 6)]
    [TestCase("1221", 0)]
    [TestCase("123425", 4)]
    [TestCase("123123", 12)]
    [TestCase("12131415", 4)]
    [Category("Fast")]
    public void AOC2017_01_2_Cases(string input, int expected)
    {
        long result = AOC2017_01.Solve2(new[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_01_2_Sample() => Sample(6L, AOC2017_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2017_01_2_Actual() => Actual(1194L, AOC2017_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2017_02_1_Sample() => Sample(18L, AOC2017_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2017_02_1_Actual() => Actual(45972L, AOC2017_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2017_02_2_Sample() => Sample(9L, AOC2017_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2017_02_2_Actual() => Actual(326L, AOC2017_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2017_03_1_Sample() => Sample(31L, AOC2017_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2017_03_1_Actual() => Actual(438L, AOC2017_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2017_03_2_Sample() => Sample(1968L, AOC2017_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2017_03_2_Actual() => Actual(266330L, AOC2017_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2017_04_1_Sample() => Sample(2L, AOC2017_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2017_04_1_Actual() => Actual(325L, AOC2017_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2017_04_2_Sample() => Sample(2L, AOC2017_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2017_04_2_Actual() => Actual(119L, AOC2017_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2017_05_1_Sample() => Sample(5L, AOC2017_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2017_05_1_Actual() => Actual(374269L, AOC2017_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2017_05_2_Sample() => Sample(10L, AOC2017_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2017_05_2_Actual() => Actual(27720699L, AOC2017_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2017_06_1_Sample() => Sample(5L, AOC2017_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2017_06_1_Actual() => Actual(3156L, AOC2017_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2017_06_2_Sample() => Sample(4L, AOC2017_06.Solve2, "06");

    [Test, Category("Fast")]
    public void AOC2017_06_2_Actual() => Actual(1610L, AOC2017_06.Solve2, "06");

    [Test, Category("Fast")]
    public void AOC2017_07_1_Sample() => Sample("tknk", AOC2017_07.Solve1, "07");

    [Test, Category("Fast")]
    public void AOC2017_07_1_Actual() => Actual("vgzejbd", AOC2017_07.Solve1, "07");

    [Test, Category("Fast")]
    public void AOC2017_07_2_Sample() => Sample(60L, AOC2017_07.Solve2, "07");

    [Test, Category("Fast")]
    public void AOC2017_07_2_Actual() => Actual(1226L, AOC2017_07.Solve2, "07");

    [Test, Category("Fast")]
    public void AOC2017_08_1_Sample() => Sample(1L, AOC2017_08.Solve1, "08");

    [Test, Category("Fast")]
    public void AOC2017_08_1_Actual() => Actual(4647L, AOC2017_08.Solve1, "08");

    [Test, Category("Fast")]
    public void AOC2017_08_2_Sample() => Sample(10L, AOC2017_08.Solve2, "08");

    [Test, Category("Fast")]
    public void AOC2017_08_2_Actual() => Actual(5590L, AOC2017_08.Solve2, "08");

    [TestCase("{}", 1)]
    [TestCase("{{{}}}", 6)]
    [TestCase("{{},{}}", 5)]
    [TestCase("{{{},{},{{}}}}", 16)]
    [TestCase("{<a>,<a>,<a>,<a>}", 1)]
    [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
    [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
    [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
    [Category("Fast")]
    public void AOC2017_09_1_Cases(string input, int expected)
    {
        long result = AOC2017_09.Solve1(new[] { input });
        result.Should().Be(expected);
    }

    [TestCase("<>", 0)]
    [TestCase("<random characters>", 17)]
    [TestCase("<<<<>", 3)]
    [TestCase("<{!>}>", 2)]
    [TestCase("<!!>", 0)]
    [TestCase("<!!!>>", 0)]
    [TestCase("<{o\"i!a,<{i<a>", 10)]
    [Category("Fast")]
    public void AOC2017_09_2_Cases(string input, int expected)
    {
        long result = AOC2017_09.Solve2(new[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_09_1_Sample() => Sample(50L, AOC2017_09.Solve1, "09");

    [Test, Category("Fast")]
    public void AOC2017_09_1_Actual() => Actual(20530L, AOC2017_09.Solve1, "09");

    [Test, Category("Fast")]
    public void AOC2017_09_2_Sample() => Sample(29L, AOC2017_09.Solve2, "09");

    [Test, Category("Fast")]
    public void AOC2017_09_2_Actual() => Actual(9978L, AOC2017_09.Solve2, "09");

    [Test, Category("Fast")]
    public void AOC2017_10_1_Sample() => Sample(12L, x => AOC2017_10.Solve1(x, 5), "10");

    [Test, Category("Fast")]
    public void AOC2017_10_1_Actual() => Actual(826L, x => AOC2017_10.Solve1(x, 256), "10");

    [TestCase("", "a2582a3a0e66e6e86e3812dcb672a272")]
    [TestCase("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
    [TestCase("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
    [TestCase("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
    [Category("Fast")]
    public void AOC2017_10_2_Cases(string input, string expected)
    {
        string actual = AOC2017_10.Solve2(new[] { input });
        actual.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_10_2_Actual() => Actual("d067d3f14d07e09c2e7308c3926605c4", AOC2017_10.Solve2, "10");

    [TestCase("ne,ne,ne", 3)]
    [TestCase("ne,ne,sw,sw", 0)]
    [TestCase("ne,ne,s,s", 2)]
    [TestCase("se,sw,se,sw,sw", 3)]
    [Category("Fast")]
    public void AOC2017_11_1_Cases(string input, long expected)
    {
        long actual = AOC2017_11.Solve1(new[] { input });
        actual.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2017_11_1_Actual() => Actual(682L, AOC2017_11.Solve1, "11");

    [Test, Category("Fast")]
    public void AOC2017_11_2_Actual() => Actual(1406L, AOC2017_11.Solve2, "11");

    [Test, Category("Fast")]
    public void AOC2017_12_1_Sample() => Sample(6L, AOC2017_12.Solve1, "12");

    [Test, Category("Fast")]
    public void AOC2017_12_1_Actual() => Actual(115L, AOC2017_12.Solve1, "12");

    [Test, Category("Fast")]
    public void AOC2017_12_2_Sample() => Sample(2L, AOC2017_12.Solve2, "12");

    [Test, Category("Fast")]
    public void AOC2017_12_2_Actual() => Actual(221L, AOC2017_12.Solve2, "12");

    [Test, Category("Fast")]
    public void AOC2017_13_1_Sample() => Sample(24L, AOC2017_13.Solve1, "13");

    [Test, Category("Fast")]
    public void AOC2017_13_1_Actual() => Actual(632L, AOC2017_13.Solve1, "13");

    [Test, Category("Fast")]
    public void AOC2017_13_2_Sample() => Sample(10L, AOC2017_13.Solve2, "13");

    [Test, Category("Fast")]
    public void AOC2017_13_2_Actual() => Actual(3849742L, AOC2017_13.Solve2, "13");

    [Test, Category("Fast")]
    public void AOC2017_14_1_Sample() => Sample(8108L, AOC2017_14.Solve1, "14");

    [Test, Category("Fast")]
    public void AOC2017_14_1_Actual() => Actual(8304L, AOC2017_14.Solve1, "14");

    [Test, Category("Fast")]
    public void AOC2017_14_2_Sample() => Sample(1242L, AOC2017_14.Solve2, "14");

    [Test, Category("Fast")]
    public void AOC2017_14_2_Actual() => Actual(1018L, AOC2017_14.Solve2, "14");

    [Test, Category("Slow")]
    public void AOC2017_15_1_Sample() => Sample(588L, AOC2017_15.Solve1, "15");

    [Test, Category("Slow")]
    public void AOC2017_15_1_Actual() => Actual(567L, AOC2017_15.Solve1, "15");

    [Test, Category("Slow")]
    public void AOC2017_15_2_Sample() => Sample(309L, AOC2017_15.Solve2, "15");

    [Test, Category("Slow")]
    public void AOC2017_15_2_Actual() => Actual(323L, AOC2017_15.Solve2, "15");

    [Test, Category("Fast")]
    public void AOC2017_16_1_Sample() => Sample("baedc", x => AOC2017_16.Solve1(x, 5), "16");

    [Test, Category("Fast")]
    public void AOC2017_16_1_Actual() => Actual("nlciboghjmfdapek", x => AOC2017_16.Solve1(x, 16), "16");

    [Test, Category("Fast")]
    public void AOC2017_16_2_Actual() => Actual("nlciboghmkedpfja", x => AOC2017_16.Solve2(x, 16), "16");

    [Test, Category("Fast")]
    public void AOC2017_17_1_Sample() => Sample(638L, AOC2017_17.Solve1, "17");

    [Test, Category("Fast")]
    public void AOC2017_17_1_Actual() => Actual(1244L, AOC2017_17.Solve1, "17");

    [Test, Category("Fast")]
    public void AOC2017_17_2_Actual() => Actual(11162912L, AOC2017_17.Solve2, "17");

    [Test, Category("Fast")]
    public void AOC2017_18_1_Sample() => Sample(4L, AOC2017_18.Solve1, "18");

    [Test, Category("Fast")]
    public void AOC2017_18_1_Actual() => Actual(1187L, AOC2017_18.Solve1, "18");

    [Test, Category("Fast")]
    public void AOC2017_18_2_Actual() => Actual(5969L, AOC2017_18.Solve2, "18");

    [Test, Category("Fast")]
    public void AOC2017_19_1_Sample() => Sample("ABCDEF", AOC2017_19.Solve1, "19");

    [Test, Category("Fast")]
    public void AOC2017_19_1_Actual() => Actual("PBAZYFMHT", AOC2017_19.Solve1, "19");

    [Test, Category("Fast")]
    public void AOC2017_19_2_Sample() => Sample(38L, AOC2017_19.Solve2, "19");

    [Test, Category("Fast")]
    public void AOC2017_19_2_Actual() => Actual(16072L, AOC2017_19.Solve2, "19");

    [Test, Category("Fast")]
    public void AOC2017_20_1_Sample() => Sample(0L, AOC2017_20.Solve1, "20");

    [Test, Category("Fast")]
    public void AOC2017_20_1_Actual() => Actual(170L, AOC2017_20.Solve1, "20");

    [Test, Category("Fast")]
    public void AOC2017_20_2_Sample() => Sample(2L, AOC2017_20.Solve2, "20");

    [Test, Category("Fast")]
    public void AOC2017_20_2_Actual() => Actual(571L, AOC2017_20.Solve2, "20");

    [Test, Category("Fast")]
    public void AOC2017_21_1_Actual() => Actual(208L, AOC2017_21.Solve1, "21");

    [Test, Category("Slow")]
    public void AOC2017_21_2_Actual() => Actual(2480380L, AOC2017_21.Solve2, "21");

    [Test, Category("Fast")]
    public void AOC2017_22_1_Sample() => Sample(5587L, AOC2017_22.Solve1, "22");

    [Test, Category("Fast")]
    public void AOC2017_22_1_Actual() => Actual(5256L, AOC2017_22.Solve1, "22");

    [Test, Category("Slow")]
    public void AOC2017_22_2_Sample() => Sample(2511944L, AOC2017_22.Solve2, "22");

    [Test, Category("Slow")]
    public void AOC2017_22_2_Actual() => Actual(2511345L, AOC2017_22.Solve2, "22");

    [Test, Category("Fast")]
    public void AOC2017_23_1_Actual() => Actual(6724L, AOC2017_23.Solve1, "23");

    [Test, Category("Fast")]
    public void AOC2017_23_2_Actual() => Actual(903L, AOC2017_23.Solve2, "23");

    [Test, Category("Fast")]
    public void AOC2017_24_1_Sample() => Sample(31L, AOC2017_24.Solve1, "24");

    [Test, Category("VerySlow")]
    public void AOC2017_24_1_Actual() => Actual(1906L, AOC2017_24.Solve1, "24");

    [Test, Category("Fast")]
    public void AOC2017_24_2_Sample() => Sample(19L, AOC2017_24.Solve2, "24");

    [Test, Category("VerySlow")]
    public void AOC2017_24_2_Actual() => Actual(1824L, AOC2017_24.Solve2, "24");

    [Test, Category("Fast")]
    public void AOC2017_25_1_Actual() => Actual(5587L, AOC2017_25.Solve1, "22");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2017", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2017", day, "sample"));
    }
}
