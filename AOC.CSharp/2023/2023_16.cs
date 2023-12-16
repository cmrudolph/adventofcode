using System.Data;

namespace AOC.CSharp;

public static class AOC2023_16
{
    public static long Solve1(string[] lines)
    {
        Solver s = new(lines);
        long result = s.Solve(new(0, 0, Direction.Right));
        s.Print();

        return result;
    }

    public static long Solve2(string[] lines)
    {
        List<MovingBeam> starts = new();
        for (int y = 0; y < lines.Length; y++)
        {
            starts.Add(new(0, y, Direction.Right));
            starts.Add(new(lines[0].Length - 1, y, Direction.Left));
        }
        for (int x = 0; x < lines[0].Length; x++)
        {
            starts.Add(new(x, 0, Direction.Down));
            starts.Add(new(x, lines.Length - 1, Direction.Up));
        }

        long best = 0;

        foreach (MovingBeam start in starts)
        {
            Solver s = new(lines);
            long result = s.Solve(start);
            best = Math.Max(best, result);
        }

        return best;
    }

    private class Solver
    {
        private char[,] _grid;
        private int _height;
        private int _width;
        private HashSet<XY> _energized = new();
        private HashSet<MovingBeam> _visited = new();

        public Solver(string[] lines)
        {
            _grid = Parse(lines);
            _height = _grid.GetLength(0);
            _width = _grid.GetLength(1);
        }

        public void Print()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_energized.Contains(new(x, y)))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }

        public long Solve(MovingBeam start)
        {
            Queue<MovingBeam> q = new();
            q.Enqueue(start);

            while (q.Count != 0)
            {
                MovingBeam deq = q.Dequeue();

                if (_visited.Contains(deq))
                {
                    continue;
                }

                if (deq.X < 0 || deq.X >= _width || deq.Y < 0 || deq.Y >= _height)
                {
                    continue;
                }

                char ch = _grid[deq.Y, deq.X];

                //Console.WriteLine($"{ch} : ({deq.X}, {deq.Y}) : {deq.Dir}");

                _energized.Add(new XY(deq.X, deq.Y));
                _visited.Add(deq);

                if (deq.Dir == Direction.Right)
                {
                    if (ch == '.' || ch == '-')
                    {
                        q.Enqueue(deq.GoRight());
                    }

                    if (ch == '|')
                    {
                        q.Enqueue(deq.GoUp());
                        q.Enqueue(deq.GoDown());
                    }

                    if (ch == '/')
                    {
                        q.Enqueue(deq.GoUp());
                    }

                    if (ch == '\\')
                    {
                        q.Enqueue(deq.GoDown());
                    }
                }

                if (deq.Dir == Direction.Left)
                {
                    if (ch == '.' || ch == '-')
                    {
                        q.Enqueue(deq.GoLeft());
                    }

                    if (ch == '|')
                    {
                        q.Enqueue(deq.GoUp());
                        q.Enqueue(deq.GoDown());
                    }

                    if (ch == '/')
                    {
                        q.Enqueue(deq.GoDown());
                    }

                    if (ch == '\\')
                    {
                        q.Enqueue(deq.GoUp());
                    }
                }

                if (deq.Dir == Direction.Up)
                {
                    if (ch == '.' || ch == '|')
                    {
                        q.Enqueue(deq.GoUp());
                    }

                    if (ch == '-')
                    {
                        q.Enqueue(deq.GoLeft());
                        q.Enqueue(deq.GoRight());
                    }

                    if (ch == '/')
                    {
                        q.Enqueue(deq.GoRight());
                    }

                    if (ch == '\\')
                    {
                        q.Enqueue(deq.GoLeft());
                    }
                }

                if (deq.Dir == Direction.Down)
                {
                    if (ch == '.' || ch == '|')
                    {
                        q.Enqueue(deq.GoDown());
                    }

                    if (ch == '-')
                    {
                        q.Enqueue(deq.GoLeft());
                        q.Enqueue(deq.GoRight());
                    }

                    if (ch == '/')
                    {
                        q.Enqueue(deq.GoLeft());
                    }

                    if (ch == '\\')
                    {
                        q.Enqueue(deq.GoRight());
                    }
                }
            }

            return _energized.Count;
        }

        private static char[,] Parse(string[] lines)
        {
            char[,] grid = new char[lines.Length, lines[0].Length];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    grid[y, x] = lines[y][x];
                }
            }

            return grid;
        }
    }

    private enum Direction
    {
        Up,
        Right,
        Down,
        Left,
    }

    private record MovingBeam(int X, int Y, Direction Dir)
    {
        public MovingBeam GoUp() => this with { Y = this.Y - 1, Dir = Direction.Up };

        public MovingBeam GoRight() => this with { X = this.X + 1, Dir = Direction.Right };

        public MovingBeam GoDown() => this with { Y = this.Y + 1, Dir = Direction.Down };

        public MovingBeam GoLeft() => this with { X = this.X - 1, Dir = Direction.Left };
    }

    private record XY(int X, int Y);
}
