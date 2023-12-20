namespace AOC.CSharp;

public static class AOC2023_17
{
    public static long Solve1(string[] lines)
    {
        Solver s = new(lines);

        return s.Solve();
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private class Solver
    {
        private readonly int[,] _grid;
        private readonly int _height;
        private readonly int _width;
        private HashSet<XY> _visited = new();

        public Solver(string[] lines)
        {
            _grid = Parse(lines);
            _height = _grid.GetLength(0);
            _width = _grid.GetLength(1);
        }

        public long Solve()
        {
            Queue<Move> q = new();
            q.Enqueue(new(1, 0, Direction.Right, 1, 0, new HashSet<XY>()));
            q.Enqueue(new(0, 1, Direction.Down, 1, 0, new HashSet<XY>()));

            long bestSolution = long.MaxValue;

            while (q.Count != 0)
            {
                Move deq = q.Dequeue();
                XY deqXY = new(deq.X, deq.Y);
                if (deq.Seen.Contains(deqXY))
                {
                    continue;
                }

                if (deq.X == _width - 1 && deq.Y == _height - 1)
                {
                    bestSolution = Math.Min(deq.CostSoFar, bestSolution);
                    continue;
                }

                var newSeen = deq.Seen.ToHashSet();
                newSeen.Add(deqXY);

                List<Option> options =
                    new()
                    {
                        new(deq.X, deq.Y - 1, Direction.Up),
                        new(deq.X + 1, deq.Y, Direction.Right),
                        new(deq.X, deq.Y + 1, Direction.Down),
                        new(deq.X - 1, deq.Y, Direction.Left),
                    };

                foreach (Option opt in options)
                {
                    if (opt.X < 0 || opt.X >= _width || opt.Y < 0 || opt.Y >= _height)
                    {
                        continue;
                    }

                    int stepsInSame = opt.Dir == deq.Dir ? deq.StepsInSame + 1 : 1;
                    if (stepsInSame > 3)
                    {
                        continue;
                    }

                    int costForNew = _grid[opt.Y, opt.X];
                    int newTotalCost = deq.CostSoFar + costForNew;

                    Move next = new(opt.X, opt.Y, opt.Dir, stepsInSame, newTotalCost, newSeen);
                    Console.WriteLine("NEXT: {0}", next);
                    q.Enqueue(next);
                }
            }

            return bestSolution;
        }

        private static int[,] Parse(string[] lines)
        {
            int[,] grid = new int[lines.Length, lines[0].Length];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    grid[y, x] = int.Parse(lines[y][x].ToString());
                }
            }

            return grid;
        }

        private record XY(int X, int Y);

        private record Option(int X, int Y, Direction Dir);

        private record Move(
            int X,
            int Y,
            Direction Dir,
            int StepsInSame,
            int CostSoFar,
            HashSet<XY> Seen
        );

        private enum Direction
        {
            Up,
            Right,
            Down,
            Left,
        }
    }
}
