using System;
using System.Linq;
using Xunit;

namespace Year2020
{
    public static class AOC2020_13
    {
        public static Tuple<long, long> Solve(string[] lines)
        {
            long timestamp1 = long.Parse(lines[0]);
            var busInfos = lines[1].Split(',')
                .Select((id, idx) => Tuple.Create(id, idx))
                .Where(tup => tup.Item1 != "x")
                .Select(tup => new BusInfo(long.Parse(tup.Item1), tup.Item2))
                .ToArray();

            long minWait = long.MaxValue;
            long minId = long.MaxValue;
            foreach (int id in busInfos.Select(x => x.Id))
            {
                long mod = timestamp1 % id;
                long wait = mod == 0 ? 0 : id - mod;

                if (wait < minWait)
                {
                    minWait = wait;
                    minId = id;
                }
            }

            long ans1 = minId * minWait;

            long timestamp2 = 1;
            for (int i = 1; i <= busInfos.Length; i++)
            {
                // Increment amount = multiply together the IDs of the "locked in" buses. This is the gap we can jump each
                // time as we know everything inside this window is not a valid solution.
                long incAmt = busInfos.Take(i - 1).Aggregate(1L, (acc, b) => acc * b.Id);

                bool valid = false;
                while (!valid)
                {
                    valid = true;
                    for (int j = 0; j < i; j++)
                    {
                        // Check each potential timestamp to make sure it satisfies every bus under investigation.
                        long potentialTimestamp = timestamp2 + busInfos[j].Offset;
                        bool isMatch = potentialTimestamp % busInfos[j].Id == 0;
                        valid &= isMatch;
                    }
                    if (!valid)
                    {
                        // No match = skip the skippable gap and continue searching
                        timestamp2 += incAmt;
                    }
                }
            }

            long ans2 = timestamp2;

            return Tuple.Create(ans1, ans2);
        }

        record BusInfo(long Id, long Offset);
    }

    public class Day13
    {
        [Fact]
        public void Sample()
        {
            var lines = Utils.ReadInput("2020", "13", "sample");
            Utils.SolveAndValidate(Tuple.Create(295L, 1068781L), AOC2020_13.Solve, lines);
        }

        [Fact]
        public void Actual()
        {
            var lines = Utils.ReadInput("2020", "13", "actual");
            Utils.SolveAndValidate(Tuple.Create(104L, 842186186521918L), AOC2020_13.Solve, lines);
        }
    }
}
