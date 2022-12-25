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
        [Test, Category("Fast")]
        public void AOC2022_12_1_Sample() => Sample(31, AOC2022_12.Solve1, "12");

        [Test, Category("Fast")]
        public void AOC2022_12_1_Actual() => Actual(490, AOC2022_12.Solve1, "12");

        [Test, Category("Fast")]
        public void AOC2022_12_2_Sample() => Sample(29, AOC2022_12.Solve2, "12");

        [Test, Category("Slow")]
        public void AOC2022_12_2_Actual() => Actual(488, AOC2022_12.Solve2, "12");
    }

    private class Day13
    {
        [TestCase("[1,1,3,1,1]", "[1,1,5,1,1]", 1)]
        [TestCase("[[1],[2,3,4]]", "[[1],4]", 1)]
        [TestCase("[9]", "[[8,7,6]]", 0)]
        [TestCase("[[4,4],4,4]", "[[4,4],4,4,4]", 1)]
        [TestCase("[7,7,7,7]", "[7,7,7]", 0)]
        [TestCase("[]", "[3]", 1)]
        [TestCase("[[[]]]", "[[]]", 0)]
        [TestCase("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", 0)]
        [TestCase("[[6],[7],[9,[0,[8,6]],[9]]]", "[[[[6],[],[2,10],0],[8,[4,10],[4,5,8,0,0]]],[3,1],[[10]]]", 1)]
        [TestCase(
            "[[6],[[8,[9],[3,6,0,8,6],7],9,4],[[],[[10,0],[9,3,8,10,1],[10,4]]]]",
            "[[6,[2,[0,0,0,5,5],[7,1,2,9],7],[],0,[8]],[],[6,9,6],[8,4,[[7,3,3],[3],6],0,0],[]]",
            1)]
        [TestCase(
            "[[],[9,[[4,6,9],[9,1,9,1,10],[0,0,5,10]]],[[],[[7],[7,6,4,1,4],7,[0],[10,3,5,0]],[]],[5]]",
            "[[[]],[],[[2,[0,8],9,6,[4]],[7,[3,7],[1,7,6,7,7],[6,9,7,3,8],[2]],[10,[5,3,1,8,8],2,8,[]],0],[4,[7,0,[]],6]]",
            1)]
        [Category("Fast")]
        public void AOC2022_13_1_Cases(string left, string right, int expected)
        {
            long result = AOC2022_13.Solve1(new[] { left, right });
            result.Should().Be(expected);
        }

        [Test, Category("Fast")]
        public void AOC2022_13_1_Sample() => Sample(13, AOC2022_13.Solve1, "13");

        [Test, Category("Fast")]
        public void AOC2022_13_1_Actual() => Actual(5682, AOC2022_13.Solve1, "13");

        [Test, Category("Fast")]
        public void AOC2022_13_2_Sample() => Sample(140, AOC2022_13.Solve2, "13");

        [Test, Category("Fast")]
        public void AOC2022_13_2_Actual() => Actual(20304, AOC2022_13.Solve2, "13");
    }

    private class Day14
    {
        [Test, Category("Fast")]
        public void AOC2022_14_1_Sample() => Sample(24, AOC2022_14.Solve1, "14");

        [Test, Category("Fast")]
        public void AOC2022_14_1_Actual() => Actual(768, AOC2022_14.Solve1, "14");

        [Test, Category("Fast")]
        public void AOC2022_14_2_Sample() => Sample(93, AOC2022_14.Solve2, "14");

        [Test, Category("Fast")]
        public void AOC2022_14_2_Actual() => Actual(26686, AOC2022_14.Solve2, "14");
    }

    private class Day15
    {
        [Test, Category("Fast")]
        public void AOC2022_15_1_Sample() => Sample(26, x => AOC2022_15.Solve1(x, 10), "15");

        [Test, Category("VerySlow")]
        public void AOC2022_15_1_Actual() => Actual(5525847, x => AOC2022_15.Solve1(x, 2000000), "15");

        [Test, Category("Fast")]
        public void AOC2022_15_2_Sample() => Sample(56000011, x => AOC2022_15.Solve2(x, 20), "15");

        [Test, Category("VerySlow")]
        public void AOC2022_15_2_Actual() => Actual(13340867187704, x => AOC2022_15.Solve2(x, 4000000), "15");
    }

    public class Day16
    {
        [Test, Category("Fast")]
        public void AOC2022_16_1_Sample() => Sample(1651, AOC2022_16.Solve1, "16");

        [Test, Category("Slow")]
        public void AOC2022_16_1_Actual() => Actual(2059, AOC2022_16.Solve1, "16");

        [Test, Category("Fast")]
        public void AOC2022_16_2_Sample() => Sample(1707, AOC2022_16.Solve2, "16");

        // Takes around 9 minutes. Found answer. Don't care to optimize it further.
        [Ignore("WayTooSlow")]
        [Test, Category("WayTooSlow")]
        public void AOC2022_16_2_Actual() => Actual(1194L, AOC2022_16.Solve2, "16");
    }

    public class Day17
    {
        [Test, Category("Fast")]
        public void AOC2022_17_1_Sample() => Sample(3068, AOC2022_17.Solve1, "17");

        [Test, Category("Fast")]
        public void AOC2022_17_1_Actual() => Actual(3184, AOC2022_17.Solve1, "17");

        [Test, Category("Fast")]
        public void AOC2022_17_2_Sample() => Sample(1514285714288L, AOC2022_17.Solve2, "17");

        [Test, Category("Fast")]
        public void AOC2022_17_2_Actual() => Actual(1577077363915L, AOC2022_17.Solve2, "17");
    }

    public class Day18
    {
        [Test, Category("Fast")]
        public void AOC2022_18_1_Sample() => Sample(64, AOC2022_18.Solve1, "18");

        [Test, Category("Fast")]
        public void AOC2022_18_1_Actual() => Actual(4536, AOC2022_18.Solve1, "18");

        [Test, Category("Slow")]
        public void AOC2022_18_2_Sample() => Sample(58, AOC2022_18.Solve2, "18");

        [Test, Category("Slow")]
        public void AOC2022_18_2_Actual() => Actual(2606, AOC2022_18.Solve2, "18");
    }

    public class Day19
    {
        [Test, Category("VerySlow")]
        public void AOC2022_19_1_Sample() => Sample(33, AOC2022_19.Solve1, "19");

        // Takes around 1 minute. Found answer. Don't care to optimize it further.
        [Ignore("WayTooSlow")]
        [Test, Category("WayTooSlow")]
        public void AOC2022_19_1_Actual() => Actual(1681, AOC2022_19.Solve1, "19");

        [Test, Category("VerySlow")]
        public void AOC2022_19_2_Sample() => Sample(3472, AOC2022_19.Solve2, "19");

        [Test, Category("VerySlow")]
        public void AOC2022_19_2_Actual() => Actual(5394, AOC2022_19.Solve2, "19");
    }

    public class Day20
    {
        [Test, Category("Fast")]
        public void AOC2022_20_1_Sample() => Sample(3, AOC2022_20.Solve1, "20");

        [Test, Category("Fast")]
        public void AOC2022_20_1_Actual() => Actual(14888, AOC2022_20.Solve1, "20");

        [Test, Category("Fast")]
        public void AOC2022_20_2_Sample() => Sample(1623178306L, AOC2022_20.Solve2, "20");

        [Test, Category("Slow")]
        public void AOC2022_20_2_Actual() => Actual(3760092545849L, AOC2022_20.Solve2, "20");
    }

    public class Day21
    {
        [Test, Category("Fast")]
        public void AOC2022_21_1_Sample() => Sample(152, AOC2022_21.Solve1, "21");

        [Test, Category("Fast")]
        public void AOC2022_21_1_Actual() => Actual(324122188240430L, AOC2022_21.Solve1, "21");

        [Test, Category("Fast")]
        public void AOC2022_21_2_Sample() => Sample(301, AOC2022_21.Solve2, "21");

        [Test, Category("Fast")]
        public void AOC2022_21_2_Actual() => Actual(3412650897405, AOC2022_21.Solve2, "21");
    }

    public class Day22
    {
        [Test, Category("Fast")]
        public void AOC2022_22_1_Sample() => Sample(6032, AOC2022_22.Solve1, "22");

        [Test, Category("Fast")]
        public void AOC2022_22_1_Actual() => Actual(73346, AOC2022_22.Solve1, "22");

        [Ignore("Sample Not Implemented")]
        [Test, Category("NotImplemented")]
        public void AOC2022_22_2_Sample() => Sample(6, AOC2022_22.Solve2, "22");

        [Test, Category("Fast")]
        public void AOC2022_22_2_Actual() => Actual(106392, AOC2022_22.Solve2, "22");
    }

    public class Day23
    {
        [Test, Category("Fast")]
        public void AOC2022_23_1_Sample() => Sample(110, AOC2022_23.Solve1, "23");

        [Test, Category("Fast")]
        public void AOC2022_23_1_Actual() => Actual(3849, AOC2022_23.Solve1, "23");

        [Test, Category("Fast")]
        public void AOC2022_23_2_Sample() => Sample(20, AOC2022_23.Solve2, "23");

        // Takes around 1 minute. Found answer. Don't care to optimize it further.
        [Ignore("WayTooSlow")]
        [Test, Category("WayTooSlow")]
        public void AOC2022_23_2_Actual() => Actual(995, AOC2022_23.Solve2, "23");
    }

    public class Day24
    {
        [Test, Category("Fast")]
        public void AOC2022_24_1_Sample() => Sample(18, AOC2022_24.Solve1, "24");

        [Test, Category("Slow")]
        public void AOC2022_24_1_Actual() => Actual(295, AOC2022_24.Solve1, "24");

        [Test, Category("Fast")]
        public void AOC2022_24_2_Sample() => Sample(54, AOC2022_24.Solve2, "24");

        [Test, Category("Slow")]
        public void AOC2022_24_2_Actual() => Actual(851, AOC2022_24.Solve2, "24");
    }

    public class Day25
    {
        [TestCase("1=", 3)]
        [TestCase("12", 7)]
        [TestCase("1=-0-2", 1747)]
        [Category("Fast")]
        public void AOC2022_25_RoundTrip(string snafu, long numeric)
        {
            long result = AOC2022_25.ToDecimal(snafu);
            result.Should().Be(numeric);

            string reversed = AOC2022_25.ToSnafu(result);
            reversed.Should().Be(snafu);
        }

        [TestCase("1=", 3)]
        [TestCase("12", 7)]
        [TestCase("1=-0-2", 1747)]
        [Category("Fast")]
        public void AOC2022_25_ToSnafu(string snafu, long expected)
        {
            long result = AOC2022_25.ToDecimal(snafu);
            result.Should().Be(expected);
        }

        [Test, Category("New")]
        public void AOC2022_25_1_Sample() => Sample("2=-1=0", AOC2022_25.Solve1, "25");

        [Test, Category("Fast")]
        public void AOC2022_25_1_Actual() => Actual("2-20=01--0=0=0=2-120", AOC2022_25.Solve1, "25");
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
