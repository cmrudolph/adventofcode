namespace AOC.CSharp;

public static class AOC2023_11
{
    public static long Solve1(string[] lines)
    {
        Universe u = new(lines, 2);
        u.Print();

        return u.Solve();
    }

    public static long Solve2(string[] lines)
    {
        Universe u = new(lines, 1000000);
        u.Print();

        return u.Solve();
    }

    private class Universe
    {
        private readonly int _gapSize;
        private readonly List<List<char>> _grid = new();
        private readonly HashSet<int> _emptyRows = new();
        private readonly HashSet<int> _emptyCols = new();

        public Universe(string[] lines, int gapSize)
        {
            _gapSize = gapSize;
            for (int y = 0; y < lines.Length; y++)
            {
                List<char> row = new();
                for (int x = 0; x < lines[0].Length; x++)
                {
                    row.Add(lines[y][x]);
                }

                _grid.Add(row);
            }

            ExpandRows();
            ExpandColumns();
        }

        private void ExpandRows()
        {
            bool IsRowEmpty(int row)
            {
                bool empty = true;
                for (int x = 0; empty && x < _grid[row].Count; x++)
                {
                    empty &= _grid[row][x] == '.';
                }

                return empty;
            }

            for (int y = 0; y < _grid.Count; y++)
            {
                if (IsRowEmpty(y))
                {
                    _emptyRows.Add(y);
                }
            }
        }

        private void ExpandColumns()
        {
            bool IsColEmpty(int col)
            {
                bool empty = true;
                for (int y = 0; empty && y < _grid.Count; y++)
                {
                    empty &= _grid[y][col] == '.';
                }

                return empty;
            }

            for (int x = 0; x < _grid[0].Count; x++)
            {
                if (IsColEmpty(x))
                {
                    _emptyCols.Add(x);
                }
            }
        }

        public long Solve()
        {
            List<XY> points = new();
            for (int y = 0; y < _grid.Count; y++)
            {
                for (int x = 0; x < _grid[0].Count; x++)
                {
                    char ch = _grid[y][x];
                    if (ch == '#')
                    {
                        XY xy = new(x, y);
                        points.Add(xy);
                    }
                }
            }

            long sum = 0;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    XY p1 = points[i];
                    XY p2 = points[j];

                    long dist = Manhattan(p1, p2);
                    sum += dist;
                }
            }

            return sum;
        }

        private long Manhattan(XY p1, XY p2)
        {
            int smallX = Math.Min(p1.X, p2.X);
            int bigX = Math.Max(p1.X, p2.X);
            int smallY = Math.Min(p1.Y, p2.Y);
            int bigY = Math.Max(p1.Y, p2.Y);

            long result = 0;

            for (int x = smallX; x <= bigX; x++)
            {
                if (_emptyCols.Contains(x))
                {
                    result += (_gapSize - 1);
                }
            }

            for (int y = smallY; y <= bigY; y++)
            {
                if (_emptyRows.Contains(y))
                {
                    result += (_gapSize - 1);
                }
            }

            result += (bigX - smallX);
            result += (bigY - smallY);

            return result;
        }

        public void Print()
        {
            for (int y = 0; y < _grid.Count; y++)
            {
                for (int x = 0; x < _grid[0].Count; x++)
                {
                    Console.Write(_grid[y][x]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private record XY(int X, int Y)
        {
            public override string ToString() => $"{(X, Y)}";
        }
    }
}
