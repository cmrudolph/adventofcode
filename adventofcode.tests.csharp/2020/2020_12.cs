using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Year2020
{
    public static class AOC2020_12
    {
        private const int North = 0;
        private const int East = 1;
        private const int South = 2;
        private const int West = 3;

        static long CalcDist(int[] pos)
        {
            int x = Math.Abs(pos[East] - pos[West]);
            int y = Math.Abs(pos[South] - pos[North]);

            return x + y;
        }

        static int Forward(int[] pos, int[] dirs, int amount)
        {
            for (int i = 0; i < 4; i++)
            {
                pos[i] += dirs[i] * amount;
            }

            return 0;
        }

        static void Rotate(int[] dirs, int amount)
        {
            while (amount < 0)
            {
                int temp = dirs[3];
                dirs[3] = dirs[0];
                dirs[0] = dirs[1];
                dirs[1] = dirs[2];
                dirs[2] = temp;

                amount += 90;
            }

            while (amount > 0)
            {
                int temp = dirs[3];
                dirs[3] = dirs[2];
                dirs[2] = dirs[1];
                dirs[1] = dirs[0];
                dirs[0] = temp;

                amount -= 90;
            }
        }

        public static Tuple<long, long> Solve(string[] lines)
        {
            List<(char, int)> instructions = lines.Select(x => (x[0], int.Parse(x[1..]))).ToList();

            // N | E | S | W
            int[] pos1 = new[] { 0, 0, 0, 0 };
            int[] dirs1 = new[] { 0, 1, 0, 0 };

            foreach ((char, int) inst in instructions)
            {
                switch (inst.Item1)
                {
                    case 'N': { pos1[North] += inst.Item2; break; }
                    case 'E': { pos1[East] += inst.Item2; break; }
                    case 'S': { pos1[South] += inst.Item2; break; }
                    case 'W': { pos1[West] += inst.Item2; break; }
                    case 'L': { Rotate(dirs1, -1 * inst.Item2); break; }
                    case 'R': { Rotate(dirs1, inst.Item2); break; }
                    case 'F': { Forward(pos1, dirs1, inst.Item2); break; }
                };
            }

            // N | E | S | W
            int[] pos2 = new[] { 0, 0, 0, 0 };
            int[] wpRel = new[] { 1, 10, 0, 0 };

            foreach ((char, int) inst in instructions)
            {
                switch (inst.Item1)
                {
                    case 'N': { wpRel[North] += inst.Item2; break; }
                    case 'E': { wpRel[East] += inst.Item2; break; }
                    case 'S': { wpRel[South] += inst.Item2; break; }
                    case 'W': { wpRel[West] += inst.Item2; break; }
                    case 'L': { Rotate(wpRel, -1 * inst.Item2); break; }
                    case 'R': { Rotate(wpRel, inst.Item2); break; }
                    case 'F': { Forward(pos2, wpRel, inst.Item2); break; }
                };
            }

            long ans1 = CalcDist(pos1);
            long ans2 = CalcDist(pos2);

            return Tuple.Create(ans1, ans2);
        }
    }

    public class Day12
    {
        [Fact]
        public void Sample()
        {
            var lines = Utils.ReadInput("2020", "12", "sample");
            Utils.SolveAndValidate(Tuple.Create(25L, 286L), AOC2020_12.Solve, lines);
        }

        [Fact]
        public void Actual()
        {
            var lines = Utils.ReadInput("2020", "12", "actual");
            Utils.SolveAndValidate(Tuple.Create(998L, 71586L), AOC2020_12.Solve, lines);
        }
    }
}
