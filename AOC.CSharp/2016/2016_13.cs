using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp;

public class AOC2016_13
{
    public static long Solve1(string[] lines, string extra)
    {
        int favorite = int.Parse(lines[0]);
        Layout layout = new(favorite);
        HashSet<XY> seen = new();
        Queue<XY> queue = new();

        string[] targetSplits = extra.Split(",");
        int targetX = int.Parse(targetSplits[0]);
        int targetY = int.Parse(targetSplits[1]);
        XY target = new(targetX, targetY);

        // Perform BFS to find the optimal path
        int steps = 0;
        queue.Enqueue(new XY(1, 1));
        while (queue.Count > 0)
        {
            int levelLength = queue.Count;
            while (levelLength > 0)
            {
                XY curr = queue.Dequeue();
                seen.Add(curr);

                if (curr == target)
                {
                    // Search until we arrive at the target cell
                    return steps;
                }

                List<XY> moves = layout.GetMovesFrom(curr, seen);
                foreach (XY move in moves)
                {
                    queue.Enqueue(move);
                }

                levelLength--;
            }

            steps++;
        }

        return 0L;
    }

    public static long Solve2(string[] lines)
    {
        int favorite = int.Parse(lines[0]);
        Layout layout = new(favorite);
        HashSet<XY> seen = new();
        Queue<XY> queue = new();

        // Perform BFS to fully explore the graph to a certain depth
        int steps = 0;
        queue.Enqueue(new XY(1, 1));
        while (steps <= 50)
        {
            int levelLength = queue.Count;
            while (levelLength > 0)
            {
                XY curr = queue.Dequeue();
                seen.Add(curr);

                List<XY> moves = layout.GetMovesFrom(curr, seen);
                foreach (XY move in moves)
                {
                    queue.Enqueue(move);
                }

                levelLength--;
            }

            steps++;
        }

        // Exhaustively search to a certain number of steps and note every distinct spot we visited
        return seen.Count;
    }

    private static State CalcState(XY xy, long favorite)
    {
        long x = xy.X;
        long y = xy.Y;
        long result = (x * x) + (3 * x) + (2 * x * y) + y + (y * y) + favorite;
        long bits = 0;

        while (result > 0)
        {
            bits += result & 1L;
            result >>= 1;
        }

        return bits % 2 == 0 ? State.Open : State.Wall;
    }

    private class Layout
    {
        private readonly Dictionary<XY, State> _dict = new();
        private readonly long _favorite;

        public Layout(long favorite)
        {
            _favorite = favorite;
        }

        public State Get(XY xy)
        {
            if (_dict.TryGetValue(xy, out State cached))
            {
                return cached;
            }

            State calculated = CalcState(xy, _favorite);
            _dict.Add(xy, calculated);

            return calculated;
        }

        public List<XY> GetMovesFrom(XY xy, HashSet<XY> seen)
        {
            XY[] options = new[]
            {
                    xy with { Y = xy.Y - 1 },
                    xy with { X = xy.X + 1 },
                    xy with { Y = xy.Y + 1 },
                    xy with { X = xy.X - 1 },
                };

            return options
                .Where(o => o.IsInBounds && Get(o) == State.Open && !seen.Contains(o))
                .ToList();
        }
    }

    private record XY(long X, long Y)
    {
        public bool IsInBounds => X >= 0 && Y >= 0;
    }

    private enum State
    {
        Open,
        Wall,
    }
}
