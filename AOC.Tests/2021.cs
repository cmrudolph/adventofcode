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

    [Test, Category("Fast")]
    public void AOC2021_17_1_Sample() => Sample(45L, AOC2021_17.Solve1, "17");

    [Test, Category("Fast")]
    public void AOC2021_17_1_Actual() => Actual(13041L, AOC2021_17.Solve1, "17");

    [Test, Category("Fast")]
    public void AOC2021_17_2_Sample() => Sample(112L, AOC2021_17.Solve2, "17");

    [Test, Category("Fast")]
    public void AOC2021_17_2_Actual() => Actual(1031L, AOC2021_17.Solve2, "17");

    [TestCase("[[1,2],[[3,4],5]]", 143)]
    [TestCase("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
    [TestCase("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
    [TestCase("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
    [TestCase("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
    [TestCase("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
    [Category("Fast")]
    public void AOC2021_18_Magnitude(string input, long expected)
    {
        var num = AOC2021_18.Number.Parse(input);
        long actual = AOC2021_18.Magnitude(num);
        actual.Should().Be(expected);
    }

    [TestCase("[1,1]", "[2,2]", "(1,2)|(1,2)|(2,2)|(2,2)")]
    [TestCase("[[1,1],[2,2]]", "[3,3]", "(1,3)|(1,3)|(2,3)|(2,3)|(3,2)|(3,2)")]
    [TestCase("[[[1,1],[2,2]],[3,3]]", "[4,4]", "(1,4)|(1,4)|(2,4)|(2,4)|(3,3)|(3,3)|(4,2)|(4,2)")]
    [Category("Fast")]
    public void AOC2021_18_Add(string input1, string input2, string expected)
    {
        var num1 = AOC2021_18.Number.Parse(input1);
        var num2 = AOC2021_18.Number.Parse(input2);
        var added = AOC2021_18.Add(num1, num2);
        string actual = added.ToString();
        actual.Should().Be(expected);
    }

    [TestCase("[[[[[9,8],1],2],3],4]", "(0,4)|(9,4)|(2,3)|(3,2)|(4,1)")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "(7,1)|(6,2)|(5,3)|(7,4)|(0,4)")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "(6,2)|(5,3)|(7,4)|(0,4)|(3,1)")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "(3,2)|(2,3)|(8,4)|(0,4)|(9,2)|(5,3)|(4,4)|(3,5)|(2,5)")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "(3,2)|(2,3)|(8,4)|(0,4)|(9,2)|(5,3)|(7,4)|(0,4)")]
    [Category("Fast")]
    public void AOC2021_18_Explode(string input, string expected)
    {
        var num = AOC2021_18.Number.Parse(input);
        var exploded = AOC2021_18.Explode(num);
        string actual = exploded.ToString();
        actual.Should().Be(expected);
    }

    [TestCase("[[[[0,7],4],[15,[0,13]]],[1,1]]", "(0,4)|(7,4)|(4,3)|(7,4)|(8,4)|(0,4)|(13,4)|(1,2)|(1,2)")]
    [TestCase("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", "(0,4)|(7,4)|(4,3)|(7,4)|(8,4)|(0,4)|(6,5)|(7,5)|(1,2)|(1,2)")]
    [Category("Fast")]
    public void AOC2021_18_Split(string input, string expected)
    {
        var num = AOC2021_18.Number.Parse(input);
        var exploded = AOC2021_18.Split(num);
        string actual = exploded.ToString();
        actual.Should().Be(expected);
    }

    [TestCase(
        "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]",
        "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]",
        "(4,4)|(0,4)|(5,4)|(4,4)|(7,4)|(7,4)|(6,4)|(0,4)|(8,3)|(7,4)|(7,4)|(7,4)|(9,4)|(5,4)|(0,4)")]
    [TestCase(
        "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]",
        "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]",
        "(6,4)|(7,4)|(6,4)|(7,4)|(7,4)|(7,4)|(0,4)|(7,4)|(8,4)|(7,4)|(7,4)|(7,4)|(8,4)|(8,4)|(8,4)|(0,4)")]
    [Category("Fast")]
    public void AOC2021_18_Reduce(string input1, string input2, string expected)
    {
        var num1 = AOC2021_18.Number.Parse(input1);
        var num2 = AOC2021_18.Number.Parse(input2);
        var added = AOC2021_18.Add(num1, num2);
        var reduced = AOC2021_18.Reduce(added);
        string actual = reduced.ToString();
        actual.Should().Be(expected);
    }

    [Test, Category("Fast")]
    public void AOC2021_18_1_Sample() => Sample(4140L, AOC2021_18.Solve1, "18");

    [Test, Category("Fast")]
    public void AOC2021_18_1_Actual() => Actual(3647L, AOC2021_18.Solve1, "18");

    [Test, Category("Fast")]
    public void AOC2021_18_2_Sample() => Sample(3993L, AOC2021_18.Solve2, "18");

    [Test, Category("Fast")]
    public void AOC2021_18_2_Actual() => Actual(4600L, AOC2021_18.Solve2, "18");

    //[Test, Category("New")]
    //public void AOC2021_19_1_Sample() => Sample(-1L, AOC2021_19.Solve1, "19");

    //[Test, Category("New")]
    //public void AOC2021_19_1_Actual() => Actual(-1L, AOC2021_19.Solve1, "19");

    //[Test, Category("New")]
    //public void AOC2021_19_2_Sample() => Sample(-1L, AOC2021_19.Solve2, "19");

    //[Test, Category("New")]
    //public void AOC2021_19_2_Actual() => Actual(-1L, AOC2021_19.Solve2, "19");

    [Test, Category("Fast")]
    public void AOC2021_20_1_Sample() => Sample(35L, AOC2021_20.Solve1, "20");

    [Test, Category("Fast")]
    public void AOC2021_20_1_Actual() => Actual(5583L, AOC2021_20.Solve1, "20");

    [Test, Category("Fast")]
    public void AOC2021_20_2_Sample() => Sample(3351L, AOC2021_20.Solve2, "20");

    [Test, Category("Fast")]
    public void AOC2021_20_2_Actual() => Actual(19592L, AOC2021_20.Solve2, "20");

    [Test, Category("Fast")]
    public void AOC2021_21_1_Sample() => Sample(739785L, AOC2021_21.Solve1, "21");

    [Test, Category("Fast")]
    public void AOC2021_21_1_Actual() => Actual(797160L, AOC2021_21.Solve1, "21");

    [Test, Category("Fast")]
    public void AOC2021_21_2_Sample() => Sample(444356092776315L, AOC2021_21.Solve2, "21");

    [Test, Category("Fast")]
    public void AOC2021_21_2_Actual() => Actual(27464148626406L, AOC2021_21.Solve2, "21");

    //[Test, Category("New")]
    //public void AOC2021_22_1_Sample() => Sample(-1L, AOC2021_22.Solve1, "22");

    //[Test, Category("New")]
    //public void AOC2021_22_1_Actual() => Actual(-1L, AOC2021_22.Solve1, "22");

    //[Test, Category("New")]
    //public void AOC2021_22_2_Sample() => Sample(-1L, AOC2021_22.Solve2, "22");

    //[Test, Category("New")]
    //public void AOC2021_22_2_Actual() => Actual(-1L, AOC2021_22.Solve2, "22");

    [Test, Category("New")]
    public void AOC2021_23_1_Sample() => Sample(12521L, AOC2021_23.Solve1, "23");

    [Test, Category("New")]
    public void AOC2021_23_1_Actual() => Actual(14415L, AOC2021_23.Solve1, "23");

    //[Test, Category("New")]
    //public void AOC2021_23_2_Sample() => Sample(-1L, AOC2021_23.Solve2, "23");

    //[Test, Category("New")]
    //public void AOC2021_23_2_Actual() => Actual(-1L, AOC2021_23.Solve2, "23");

    //[Test, Category("New")]
    //public void AOC2021_24_1_Sample() => Sample(-1L, AOC2021_24.Solve1, "24");

    //[Test, Category("New")]
    //public void AOC2021_24_1_Actual() => Actual(-1L, AOC2021_24.Solve1, "24");

    //[Test, Category("New")]
    //public void AOC2021_24_2_Sample() => Sample(-1L, AOC2021_24.Solve2, "24");

    //[Test, Category("New")]
    //public void AOC2021_24_2_Actual() => Actual(-1L, AOC2021_24.Solve2, "24");

    //[Test, Category("New")]
    //public void AOC2021_25_1_Sample() => Sample(-1L, AOC2021_25.Solve1, "25");

    //[Test, Category("New")]
    //public void AOC2021_25_1_Actual() => Actual(-1L, AOC2021_25.Solve1, "25");

    //[Test, Category("New")]
    //public void AOC2021_25_2_Sample() => Sample(-1L, AOC2021_25.Solve2, "25");

    //[Test, Category("New")]
    //public void AOC2021_25_2_Actual() => Actual(-1L, AOC2021_25.Solve2, "25");

    private static void Actual<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "actual"));
    }

    private static void Sample<T>(T expected, Func<string[], T> solver, string day)
    {
        TestUtils.Test(expected, solver, TestUtils.ReadInput("2021", day, "sample"));
    }
}
