using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Year2020
{
    public static class AOC2020_15
    {
        public static long SolveCase(string[] lines, int target)
        {
            Dictionary<int, List<int>> lastSpokenLookup = new();

            int[] startingNumbers = lines[0].Split(',').Select(int.Parse).ToArray();
            for (int i = 0; i < startingNumbers.Length; i++)
            {
                lastSpokenLookup[startingNumbers[i]] = new List<int> { i + 1 };
            }

            int curr = startingNumbers.Last();

            for (int i = startingNumbers.Length; i < target; i++)
            {
                int prev = curr;
                List<int> listForPrev = GetListForValue(lastSpokenLookup, prev);

                curr = listForPrev.Count <= 1
                    ? 0
                    : listForPrev[listForPrev.Count - 1] - listForPrev[listForPrev.Count - 2];

                List<int> listForCurr = GetListForValue(lastSpokenLookup, curr);
                listForCurr.Add(i + 1);
            }

            return curr;
        }

        static List<int> GetListForValue(Dictionary<int, List<int>> lookup, int value)
        {
            List<int> list;
            if (!lookup.TryGetValue(value, out list))
            {
                list = new List<int>();
                lookup.Add(value, list);
            }

            return list;
        }

        public static Tuple<long, long> Solve(string[] lines)
        {
            long ans1 = SolveCase(lines, 2020);
            long ans2 = SolveCase(lines, 30000000);

            return Tuple.Create(ans1, ans2);
        }
    }

    public class Day15
    {
        [Fact]
        public void Sample()
        {
            var lines = Utils.ReadInput("2020", "15", "sample");
            Utils.SolveAndValidate(Tuple.Create(436L, 175594L), AOC2020_15.Solve, lines);
        }

        [Fact]
        public void Actual()
        {
            var lines = Utils.ReadInput("2020", "15", "actual");
            Utils.SolveAndValidate(Tuple.Create(249L, 41687L), AOC2020_15.Solve, lines);
        }
    }
}
