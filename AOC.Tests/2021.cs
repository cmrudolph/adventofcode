using AOC.CSharp;
using FluentAssertions;
using NUnit.Framework;

namespace AOC.Tests;

[Parallelizable(ParallelScope.All)]
public class AOC2021
{
    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_1_Sample() => Sample(7L, AOC2021_01.Solve1, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_1_Actual() => Actual(1466L, AOC2021_01.Solve1, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_2_Sample() => Sample(5L, AOC2021_01.Solve2, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_01_2_Actual() => Actual(1491L, AOC2021_01.Solve2, "01");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_1_Sample() => Sample(150L, AOC2021_02.Solve1, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_1_Actual() => Actual(2322630L, AOC2021_02.Solve1, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_2_Sample() => Sample(900L, AOC2021_02.Solve2, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_02_2_Actual() => Actual(2105273490L, AOC2021_02.Solve2, "02");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_03_1_Sample() => Sample(198L, AOC2021_03.Solve1, "03");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_03_1_Actual() => Actual(3374136L, AOC2021_03.Solve1, "03");

    [Test, Property("Speed", "Fast")] 
    public void AOC2021_03_2_Sample() => Sample(230L, AOC2021_03.Solve2, "03");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_03_2_Actual() => Actual(4432698L, AOC2021_03.Solve2, "03");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_04_1_Sample() => Sample(4512L, AOC2021_04.Solve1, "04");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_04_1_Actual() => Actual(10680L, AOC2021_04.Solve1, "04");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_04_2_Sample() => Sample(1924L, AOC2021_04.Solve2, "04");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_04_2_Actual() => Actual(31892L, AOC2021_04.Solve2, "04");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_05_1_Sample() => Sample(5L, AOC2021_05.Solve1, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_05_1_Actual() => Actual(6461L, AOC2021_05.Solve1, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_05_2_Sample() => Sample(12L, AOC2021_05.Solve2, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_05_2_Actual() => Actual(18065L, AOC2021_05.Solve2, "05");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_06_1_Sample() => Sample(5934L, AOC2021_06.Solve1, "06");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_06_1_Actual() => Actual(359999L, AOC2021_06.Solve1, "06");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_06_2_Sample() => Sample(26984457539L, AOC2021_06.Solve2, "06");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_06_2_Actual() => Actual(1631647919273L, AOC2021_06.Solve2, "06");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_07_1_Sample() => Sample(37L, AOC2021_07.Solve1, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_07_1_Actual() => Actual(344297L, AOC2021_07.Solve1, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_07_2_Sample() => Sample(168L, AOC2021_07.Solve2, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_07_2_Actual() => Actual(97164301L, AOC2021_07.Solve2, "07");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_08_1_Sample() => Sample(26L, AOC2021_08.Solve1, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_08_1_Actual() => Actual(519L, AOC2021_08.Solve1, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_08_2_Sample() => Sample(61229L, AOC2021_08.Solve2, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_08_2_Actual() => Actual(1027483L, AOC2021_08.Solve2, "08");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_09_1_Sample() => Sample(15L, AOC2021_09.Solve1, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_09_1_Actual() => Actual(537L, AOC2021_09.Solve1, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_09_2_Sample() => Sample(1134L, AOC2021_09.Solve2, "09");

    [Test, Property("Speed", "Fast")]
    public void AOC2021_09_2_Actual() => Actual(1142757L, AOC2021_09.Solve2, "09");

    //[Test, Property("Speed", "New")]
    //public void AOC2021_XX_1_Sample() => Sample(-1L, AOC2021_XX.Solve1, "XX");

    //[Test, Property("Speed", "New")]
    //public void AOC2021_XX_1_Actual() => Actual(-1L, AOC2021_XX.Solve1, "XX");

    //[Test, Property("Speed", "New")]
    //public void AOC2021_XX_2_Sample() => Sample(-1L, AOC2021_XX.Solve2, "XX");

    //[Test, Property("Speed", "New")]
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
