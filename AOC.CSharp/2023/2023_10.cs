namespace AOC.CSharp;

public static class AOC2023_10
{
    public static long Solve1(string[] lines)
    {
        var solver = new Solver(lines);

        return solver.Solve1();
    }

    public static long Solve2(string[] lines)
    {
        var solver = new Solver(lines);

        solver.Solve1();
        solver.RemoveNonLoop();
        var expanded = solver.BuildExpanded();
        solver.FillOutside(expanded);

        int count = 0;

        for (int y = 0; y < expanded.GetLength(0); y += 3)
        {
            for (int x = 0; x < expanded.GetLength(1); x += 3)
            {
                bool isValid = true;

                for (int y2 = y; y2 < y + 3; y2++)
                {
                    for (int x2 = x; x2 < x + 3; x2++)
                    {
                        isValid &= expanded[y2, x2] == '.';
                    }
                }

                count += isValid ? 1 : 0;
            }
        }

        return count;
    }

    private class Solver
    {
        private readonly char[,] _grid;
        private readonly int _height;
        private readonly int _width;
        private readonly HashSet<XY> _inLoop = new();
        private Dictionary<XY, Node> _graph;
        private XY _start;

        public Solver(string[] lines)
        {
            _grid = new char[lines.Length, lines[0].Length];
            _height = lines.Length;
            _width = lines[0].Length;
            BuildGraph(lines);
        }

        public long Solve1()
        {
            int level = 0;

            HashSet<XY> visited = new();
            visited.Add(_start);

            Queue<XY> q = new();
            q.Enqueue(_start);

            while (q.Count > 0)
            {
                int levelLength = q.Count;
                while (levelLength > 0)
                {
                    XY dequeued = q.Dequeue();
                    visited.Add(dequeued);
                    _inLoop.Add(dequeued);

                    var neighbors = _graph[dequeued].Neighbors;
                    foreach (var n in neighbors)
                    {
                        if (!visited.Contains(n))
                        {
                            q.Enqueue(n);
                        }
                    }

                    levelLength--;
                }

                level++;
            }

            return level - 1;
        }

        [Flags]
        private enum Directions
        {
            None = 0,
            Up = 1,
            Right = 2,
            Down = 4,
            Left = 8,
        }

        private static Directions GetDirections(char ch) =>
            ch switch
            {
                '|' => Directions.Up | Directions.Down,
                '-' => Directions.Left | Directions.Right,
                'L' => Directions.Up | Directions.Right,
                'J' => Directions.Up | Directions.Left,
                '7' => Directions.Down | Directions.Left,
                'F' => Directions.Down | Directions.Right,
                'S' => Directions.Up | Directions.Right | Directions.Down | Directions.Left,
                '.' => Directions.None,
            };

        private bool IsConnected(XY xy, Directions requiredDir)
        {
            char ch = At(xy);
            Directions dirs = GetDirections(ch);
            bool connected = dirs.HasFlag(requiredDir);

            return connected;
        }

        private char At(XY xy)
        {
            if (xy.X < 0 || xy.X >= _width || xy.Y < 0 || xy.Y >= _height)
            {
                return '.';
            }

            return _grid[xy.Y, xy.X];
        }

        public void RemoveNonLoop()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    XY xy = new(x, y);
                    if (!_inLoop.Contains(xy))
                    {
                        _grid[y, x] = '.';
                    }
                }
            }
        }

        public char[,] BuildExpanded()
        {
            char[,] final = new char[_height * 3, _width * 3];

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    char[] expanded = GetExpandedChars(At(new(x, y)));
                    int idx = 0;

                    for (int y2 = y * 3; y2 < (y * 3) + 3; y2++)
                    {
                        for (int x2 = x * 3; x2 < (x * 3) + 3; x2++)
                        {
                            final[y2, x2] = expanded[idx];
                            idx++;
                        }
                    }
                }
            }

            //PrintGrid(final);

            return final;
        }

        public void FillOutside(char[,] grid)
        {
            XY curr = new(0, 0);
            HashSet<XY> visited = new();
            Queue<XY> q = new();
            q.Enqueue(curr);

            while (q.Count > 0)
            {
                void EnqueueIfNewAndNotWall(XY next)
                {
                    if (!visited.Contains(next))
                    {
                        if (
                            next.X >= 0
                            && next.X < grid.GetLength(1)
                            && next.Y >= 0
                            && next.Y < grid.GetLength(0)
                        )
                        {
                            char ch = grid[next.Y, next.X];
                            if (ch == '.')
                            {
                                q.Enqueue(next);
                            }
                        }
                    }
                }

                curr = q.Dequeue();
                if (visited.Contains(curr))
                {
                    continue;
                }
                visited.Add(curr);
                grid[curr.Y, curr.X] = ' ';

                EnqueueIfNewAndNotWall(Up(curr));
                EnqueueIfNewAndNotWall(Right(curr));
                EnqueueIfNewAndNotWall(Down(curr));
                EnqueueIfNewAndNotWall(Left(curr));
            }

            //PrintGrid(grid);
        }

        private char[] GetExpandedChars(char ch)
        {
            if (ch == '.')
            {
                return new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            }
            if (ch == '-')
            {
                return new[] { '.', '.', '.', '#', '#', '#', '.', '.', '.' };
            }
            if (ch == '|')
            {
                return new[] { '.', '#', '.', '.', '#', '.', '.', '#', '.' };
            }
            if (ch == 'J')
            {
                return new[] { '.', '#', '.', '#', '#', '.', '.', '.', '.' };
            }
            if (ch == 'L')
            {
                return new[] { '.', '#', '.', '.', '#', '#', '.', '.', '.' };
            }
            if (ch == 'F')
            {
                return new[] { '.', '.', '.', '.', '#', '#', '.', '#', '.' };
            }
            if (ch == '7')
            {
                return new[] { '.', '.', '.', '#', '#', '.', '.', '#', '.' };
            }

            throw new NotSupportedException(ch.ToString());
        }

        private static void PrintGrid(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    Console.Write(grid[y, x]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void BuildGraph(string[] lines)
        {
            _graph = new();

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    char ch = lines[y][x];
                    _grid[y, x] = ch;
                }
            }

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    XY xy = new(x, y);
                    char ch = At(xy);

                    if (ch == 'S')
                    {
                        _start = xy;
                    }

                    List<XY> connected = new();
                    Directions dirs = GetDirections(At(xy));

                    XY up = Up(xy);
                    if (dirs.HasFlag(Directions.Up) && IsConnected(up, Directions.Down))
                    {
                        connected.Add(up);
                    }

                    XY right = Right(xy);
                    if (dirs.HasFlag(Directions.Right) && IsConnected(right, Directions.Left))
                    {
                        connected.Add(right);
                    }

                    XY down = Down(xy);
                    if (dirs.HasFlag(Directions.Down) && IsConnected(down, Directions.Up))
                    {
                        connected.Add(down);
                    }

                    XY left = Left(xy);
                    if (dirs.HasFlag(Directions.Left) && IsConnected(left, Directions.Right))
                    {
                        connected.Add(left);
                    }

                    if (ch == 'S')
                    {
                        if (connected.Contains(up) && connected.Contains(down))
                        {
                            _grid[xy.Y, xy.X] = '|';
                        }
                        if (connected.Contains(left) && connected.Contains(right))
                        {
                            _grid[xy.Y, xy.X] = '-';
                        }
                        if (connected.Contains(up) && connected.Contains(right))
                        {
                            _grid[xy.Y, xy.X] = 'L';
                        }
                        if (connected.Contains(up) && connected.Contains(left))
                        {
                            _grid[xy.Y, xy.X] = 'J';
                        }
                        if (connected.Contains(down) && connected.Contains(left))
                        {
                            _grid[xy.Y, xy.X] = '7';
                        }
                        if (connected.Contains(down) && connected.Contains(right))
                        {
                            _grid[xy.Y, xy.X] = 'F';
                        }
                    }

                    if (connected.Count == 2)
                    {
                        Node node = new(connected);
                        _graph.Add(xy, node);
                    }
                }
            }
        }

        private XY Up(XY curr) => curr with { Y = curr.Y - 1 };

        private XY Right(XY curr) => curr with { X = curr.X + 1 };

        private XY Down(XY curr) => curr with { Y = curr.Y + 1 };

        private XY Left(XY curr) => curr with { X = curr.X - 1 };
    }

    private record Node(List<XY> Neighbors);

    private record XY(int X, int Y);
}
