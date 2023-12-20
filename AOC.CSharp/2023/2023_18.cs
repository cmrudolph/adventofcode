namespace AOC.CSharp;

public static class AOC2023_18
{
    public static long Solve1(string[] lines)
    {
        Solver s = new(lines);
        s.PrintTrench();
        Console.WriteLine();
        s.PrintFilled();

        return s.Solve();
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private class Solver
    {
        private Dictionary<XY, int> _trench = new();
        private HashSet<XY> _dug = new();

        public Solver(string[] lines)
        {
            XY curr = new(0, 0);
            _trench.Add(curr, 1);

            foreach (string line in lines)
            {
                string[] splits = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string dir = splits[0];
                int amount = int.Parse(splits[1]);

                for (int i = 0; i < amount; i++)
                {
                    if (dir == "U")
                    {
                        curr = curr with { Y = curr.Y - 1 };
                        int val = _trench.GetValueOrDefault(curr, 0);
                        _trench[curr] = val + 1;
                    }

                    if (dir == "L")
                    {
                        curr = curr with { X = curr.X - 1 };
                        int val = _trench.GetValueOrDefault(curr, 0);
                        _trench[curr] = val + 1;
                    }

                    if (dir == "R")
                    {
                        curr = curr with { X = curr.X + 1 };
                        int val = _trench.GetValueOrDefault(curr, 0);
                        _trench[curr] = val + 1;
                    }

                    if (dir == "D")
                    {
                        curr = curr with { Y = curr.Y + 1 };
                        int val = _trench.GetValueOrDefault(curr, 0);
                        _trench[curr] = val + 1;
                    }
                }
            }

            int minX = _trench.Keys.Min(x => x.X);
            int maxX = _trench.Keys.Max(x => x.X);
            int minY = _trench.Keys.Min(x => x.Y);
            int maxY = _trench.Keys.Max(x => x.Y);

            HashSet<XY> checkedOut = new();

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    // Treat every square in the rectangle as dug up initially. We will identify
                    // the exceptions and remove them.
                    _dug.Add(new(x, y));
                }
            }

            // Go around the outer edge and find everything that is connected to empty spaces
            Queue<XY> q = new();
            for (int x = minX; x <= maxX; x++)
            {
                q.Enqueue(new(x, minY));
                q.Enqueue(new(x, maxY));
            }

            for (int y = minY; y <= maxY; y++)
            {
                q.Enqueue(new(minX, y));
                q.Enqueue(new(maxX, y));
            }

            while (q.Count > 0)
            {
                XY deq = q.Dequeue();
                if (checkedOut.Contains(deq))
                {
                    // Already inspected this location and potentially its neighbors
                    continue;
                }

                checkedOut.Add(deq);

                if (_trench.Keys.Contains(deq))
                {
                    // Only look further if we are on an empty space
                    continue;
                }

                // Found an empty space. Remove it from the thing tracking our final count
                _dug.Remove(deq);

                if (deq.X > minX)
                {
                    // Left
                    q.Enqueue(new(deq.X - 1, deq.Y));
                }

                if (deq.X < maxX)
                {
                    // Right
                    q.Enqueue(new(deq.X + 1, deq.Y));
                }

                if (deq.Y > minY)
                {
                    // Up
                    q.Enqueue(new(deq.X, deq.Y - 1));
                }

                if (deq.Y < maxY)
                {
                    // Down
                    q.Enqueue(new(deq.X, deq.Y + 1));
                }
            }
        }

        public void PrintTrench()
        {
            int minX = _trench.Keys.Min(x => x.X);
            int maxX = _trench.Keys.Max(x => x.X);
            int minY = _trench.Keys.Min(x => x.Y);
            int maxY = _trench.Keys.Max(x => x.Y);

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    XY xy = new(x, y);
                    char ch = _trench.Keys.Contains(xy) ? '#' : '.';
                    Console.Write(ch);
                }

                Console.WriteLine();
            }
        }

        public void PrintFilled()
        {
            int minX = _trench.Keys.Min(x => x.X);
            int maxX = _trench.Keys.Max(x => x.X);
            int minY = _trench.Keys.Min(x => x.Y);
            int maxY = _trench.Keys.Max(x => x.Y);

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    XY xy = new(x, y);
                    char ch = _dug.Contains(xy) ? '#' : '.';
                    Console.Write(ch);
                }

                Console.WriteLine();
            }
        }

        public long Solve() => _dug.Count;
    }

    private record XY(int X, int Y);
}
