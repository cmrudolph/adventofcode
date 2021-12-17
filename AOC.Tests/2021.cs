using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2021
{
    [Test, Category("Fast")]
    public void AOC2021_01_1_Sample() => Sample(7L, AOC2021_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2021_01_1_Actual() => Actual(1466L, AOC2021_01.Solve1, "01");

    [Test, Category("Fast")]
    public void AOC2021_01_2_Sample() => Sample(5L, AOC2021_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2021_01_2_Actual() => Actual(1491L, AOC2021_01.Solve2, "01");

    [Test, Category("Fast")]
    public void AOC2021_02_1_Sample() => Sample(150L, AOC2021_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2021_02_1_Actual() => Actual(2322630L, AOC2021_02.Solve1, "02");

    [Test, Category("Fast")]
    public void AOC2021_02_2_Sample() => Sample(900L, AOC2021_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2021_02_2_Actual() => Actual(2105273490L, AOC2021_02.Solve2, "02");

    [Test, Category("Fast")]
    public void AOC2021_03_1_Sample() => Sample(198L, AOC2021_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2021_03_1_Actual() => Actual(3374136L, AOC2021_03.Solve1, "03");

    [Test, Category("Fast")]
    public void AOC2021_03_2_Sample() => Sample(230L, AOC2021_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2021_03_2_Actual() => Actual(4432698L, AOC2021_03.Solve2, "03");

    [Test, Category("Fast")]
    public void AOC2021_04_1_Sample() => Sample(4512L, AOC2021_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2021_04_1_Actual() => Actual(10680L, AOC2021_04.Solve1, "04");

    [Test, Category("Fast")]
    public void AOC2021_04_2_Sample() => Sample(1924L, AOC2021_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2021_04_2_Actual() => Actual(31892L, AOC2021_04.Solve2, "04");

    [Test, Category("Fast")]
    public void AOC2021_05_1_Sample() => Sample(5L, AOC2021_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2021_05_1_Actual() => Actual(6461L, AOC2021_05.Solve1, "05");

    [Test, Category("Fast")]
    public void AOC2021_05_2_Sample() => Sample(12L, AOC2021_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2021_05_2_Actual() => Actual(18065L, AOC2021_05.Solve2, "05");

    [Test, Category("Fast")]
    public void AOC2021_06_1_Sample() => Sample(5934L, AOC2021_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2021_06_1_Actual() => Actual(359999L, AOC2021_06.Solve1, "06");

    [Test, Category("Fast")]
    public void AOC2021_06_2_Sample() => Sample(26984457539L, AOC2021_06.Solve2, "06");

    [Test, Category("Fast")]
    public void AOC2021_06_2_Actual() => Actual(1631647919273L, AOC2021_06.Solve2, "06");

    [Test, Category("Fast")]
    public void AOC2021_07_1_Sample() => Sample(37L, AOC2021_07.Solve1, "07");

    [Test, Category("Fast")]
    public void AOC2021_07_1_Actual() => Actual(344297L, AOC2021_07.Solve1, "07");

    [Test, Category("Fast")]
    public void AOC2021_07_2_Sample() => Sample(168L, AOC2021_07.Solve2, "07");

    [Test, Category("Fast")]
    public void AOC2021_07_2_Actual() => Actual(97164301L, AOC2021_07.Solve2, "07");

    [Test, Category("Fast")]
    public void AOC2021_08_1_Sample() => Sample(26L, AOC2021_08.Solve1, "08");

    [Test, Category("Fast")]
    public void AOC2021_08_1_Actual() => Actual(519L, AOC2021_08.Solve1, "08");

    [Test, Category("Fast")]
    public void AOC2021_08_2_Sample() => Sample(61229L, AOC2021_08.Solve2, "08");

    [Test, Category("Fast")]
    public void AOC2021_08_2_Actual() => Actual(1027483L, AOC2021_08.Solve2, "08");

    [Test, Category("Fast")]
    public void AOC2021_09_1_Sample() => Sample(15L, AOC2021_09.Solve1, "09");

    [Test, Category("Fast")]
    public void AOC2021_09_1_Actual() => Actual(537L, AOC2021_09.Solve1, "09");

    [Test, Category("Fast")]
    public void AOC2021_09_2_Sample() => Sample(1134L, AOC2021_09.Solve2, "09");

    [Test, Category("Fast")]
    public void AOC2021_09_2_Actual() => Actual(1142757L, AOC2021_09.Solve2, "09");

    [Test, Category("Fast")]
    public void AOC2021_10_1_Sample() => Sample(26397L, AOC2021_10.Solve1, "10");

    [Test, Category("Fast")]
    public void AOC2021_10_1_Actual() => Actual(394647L, AOC2021_10.Solve1, "10");

    [Test, Category("Fast")]
    public void AOC2021_10_2_Sample() => Sample(288957L, AOC2021_10.Solve2, "10");

    [Test, Category("Fast")]
    public void AOC2021_10_2_Actual() => Actual(2380061249L, AOC2021_10.Solve2, "10");

    [Test, Category("Fast")]
    public void AOC2021_11_1_Sample() => Sample(1656L, AOC2021_11.Solve1, "11");

    [Test, Category("Fast")]
    public void AOC2021_11_1_Actual() => Actual(1644L, AOC2021_11.Solve1, "11");

    [Test, Category("Fast")]
    public void AOC2021_11_2_Sample() => Sample(195L, AOC2021_11.Solve2, "11");

    [Test, Category("Fast")]
    public void AOC2021_11_2_Actual() => Actual(229L, AOC2021_11.Solve2, "11");

    [Test, Category("Fast")]
    public void AOC2021_12_1_Sample() => Sample(10L, AOC2021_12.Solve1, "12");

    [Test, Category("Fast")]
    public void AOC2021_12_1_Actual() => Actual(4495L, AOC2021_12.Solve1, "12");

    [Test, Category("Fast")]
    public void AOC2021_12_2_Sample() => Sample(36L, AOC2021_12.Solve2, "12");

    [Test, Category("Fast")]
    public void AOC2021_12_2_Actual() => Actual(131254L, AOC2021_12.Solve2, "12");

    [Test, Category("Fast")]
    public void AOC2021_13_1_Sample() => Sample(17L, AOC2021_13.Solve1, "13");

    [Test, Category("Fast")]
    public void AOC2021_13_1_Actual() => Actual(678L, AOC2021_13.Solve1, "13");

    [Test, Category("Fast")]
    public void AOC2021_13_2_Sample() => Sample(0L, AOC2021_13.Solve2, "13");

    [Test, Category("Fast")]
    public void AOC2021_13_2_Actual() => Actual(0L, AOC2021_13.Solve2, "13");

    [Test, Category("Fast")]
    public void AOC2021_14_1_Sample() => Sample(1588L, AOC2021_14.Solve1, "14");

    [Test, Category("Fast")]
    public void AOC2021_14_1_Actual() => Actual(2947L, AOC2021_14.Solve1, "14");

    [Test, Category("Fast")]
    public void AOC2021_14_2_Sample() => Sample(2188189693529L, AOC2021_14.Solve2, "14");

    [Test, Category("Fast")]
    public void AOC2021_14_2_Actual() => Actual(3232426226464L, AOC2021_14.Solve2, "14");

    [Test, Category("Fast")]
    public void AOC2021_15_1_Sample() => Sample(40L, AOC2021_15.Solve1, "15");

    [Test, Category("Fast")]
    public void AOC2021_15_1_Actual() => Actual(698L, AOC2021_15.Solve1, "15");

    [Test, Category("Fast")]
    public void AOC2021_15_2_Sample() => Sample(315L, AOC2021_15.Solve2, "15");

    [Test, Category("Fast")]
    public void AOC2021_15_2_Actual() => Actual(3022L, AOC2021_15.Solve2, "15");

    [TestCase("D2FE28", 6, "single packet")]
    [TestCase("38006F45291200", 9, "two sub packets using LT 0")]
    [TestCase("EE00D40C823060", 14, "three sub packets using LT 1")]
    [TestCase("8A004A801A8002F478", 16, "nested operators 3x")]
    [TestCase("620080001611562C8802118E34", 12, "operator with operators - complex")]
    [TestCase("C0015000016115A2E0802F182340", 23, "operator with operators - complex")]
    [TestCase("A0016C880162017C3686B18A3D4780", 31, "operator with operators - complex")]
    [Category("Fast")]
    public void AOC2021_16_1_SampleCases(string input, int expected, string desc)
    {
        long result = AOC2021_16.Solve1(new string[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2021_16_1_Actual() => Actual(847L, AOC2021_16.Solve1, "16");

    [TestCase("D2FE28", 2021, "literal")]
    [TestCase("C200B40A82", 3, "sum")]
    [TestCase("04005AC33890", 54, "product")]
    [TestCase("880086C3E88112", 7, "min")]
    [TestCase("CE00C43D881120", 9, "max")]
    [TestCase("D8005AC2A8F0", 1, "less")]
    [TestCase("F600BC2D8F", 0, "greater")]
    [TestCase("9C005AC2F8F0", 0, "equal")]
    [TestCase("9C0141080250320F1802104A08", 1, "complex")]
    [Category("Fast")]
    public void AOC2021_16_2_SampleCases(string input, int expected, string desc)
    {
        long result = AOC2021_16.Solve2(new string[] { input });
        result.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2021_16_2_Actual() => Actual(333794664059L, AOC2021_16.Solve2, "16");

    // [Test, Category("New")]
    //public void AOC2021_XX_1_Sample() => Sample(-1L, AOC2021_XX.Solve1, "XX");

    //[Test, Category("New")]
    //public void AOC2021_XX_1_Actual() => Actual(-1L, AOC2021_XX.Solve1, "XX");

    //[Test, Category("New")]
    //public void AOC2021_XX_2_Sample() => Sample(-1L, AOC2021_XX.Solve2, "XX");

    //[Test, Category("New")]
    //public void AOC2021_XX_2_Actual() => Actual(-1L, AOC2021_XX.Solve2, "XX");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "sample"));
    }
}
