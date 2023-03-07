namespace AOC.CSharp;

public static class AOC2022_22
{
    private static XY Up = new(0, -1);
    private static XY Right = new(1, 0);
    private static XY Down = new(0, 1);
    private static XY Left = new(-1, 0);

    /// <summary>
    /// I am sure there is a proper way to do this for arbitrary inputs. However, I found it easier to fold up a paper
    /// cube and identify the relationships and necessary transformations. When we move across an edge, this tells us
    /// how to translate our position and direction so we can continue moving across the new cube.
    /// </summary>
    private static readonly List<Part2Wrap> Part2Wraps =
        new()
        {
            new Part2Wrap("A to E (L)", 50, 50, 0, 49, Left, Right, old => new XY(0, 149 - old.Y)),
            new Part2Wrap("A to F (U)", 50, 99, 0, 0, Up, Right, old => new XY(0, 100 + old.X)),
            new Part2Wrap(
                "B to C (D)",
                100,
                149,
                49,
                49,
                Down,
                Left,
                old => new XY(99, old.X - 50)
            ),
            new Part2Wrap(
                "B to D (R)",
                149,
                149,
                0,
                49,
                Right,
                Left,
                old => new XY(99, 149 - old.Y)
            ),
            new Part2Wrap("B to F (U)", 100, 149, 0, 0, Up, Up, old => new XY(old.X - 100, 199)),
            new Part2Wrap("C to B (R)", 99, 99, 50, 99, Right, Up, old => new XY(old.Y + 50, 49)),
            new Part2Wrap("C to E (L)", 50, 50, 50, 99, Left, Down, old => new XY(old.Y - 50, 100)),
            new Part2Wrap(
                "E to B (R)",
                99,
                99,
                100,
                149,
                Right,
                Left,
                old => new XY(149, 149 - old.Y)
            ),
            new Part2Wrap(
                "D to F (D)",
                50,
                99,
                149,
                149,
                Down,
                Left,
                old => new XY(49, 100 + old.X)
            ),
            new Part2Wrap(
                "E to A (L)",
                0,
                0,
                100,
                149,
                Left,
                Right,
                old => new XY(50, 149 - old.Y)
            ),
            new Part2Wrap("E to C (U)", 0, 49, 100, 100, Up, Right, old => new XY(50, 50 + old.X)),
            new Part2Wrap("F to A (L)", 0, 0, 150, 199, Left, Down, old => new XY(old.Y - 100, 0)),
            new Part2Wrap("F to B (D)", 0, 49, 199, 199, Down, Down, old => new XY(old.X + 100, 0)),
            new Part2Wrap(
                "F to D (R)",
                49,
                49,
                150,
                199,
                Right,
                Up,
                old => new XY(old.Y - 100, 149)
            ),
        };

    private static void Print(char[,] grid)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Console.Write(grid[row, col]);
            }

            Console.WriteLine();
        }
    }

    public static long Solve1(string[] lines)
    {
        var grid = ParseMap(lines);
        XY curr = FindStart(grid);
        XY direction = Right;

        string instructions = GetInstructionLine(lines).Replace("L", " L ").Replace("R", " R ");
        string[] splits = instructions.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string split in splits)
        {
            if (int.TryParse(split, out int steps))
            {
                XY old = curr;
                curr = Move1(grid, curr, direction, steps);
                if (grid[curr.Y, curr.X] != '.')
                {
                    throw new InvalidOperationException("oops");
                }
                Console.WriteLine("{0,-3} in {1} | {2} -> {3}", split, direction, old, curr);
            }
            else
            {
                direction = Rotate(direction, split);
            }
        }

        return ComputePassword(curr, direction);
    }

    public static long Solve2(string[] lines)
    {
        var grid = ParseMap(lines);
        XY curr = FindStart(grid);
        XY direction = Right;

        string instructions = GetInstructionLine(lines).Replace("L", " L ").Replace("R", " R ");
        string[] splits = instructions.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string split in splits)
        {
            if (int.TryParse(split, out int steps))
            {
                XY old = curr;
                var moveResult = Move2(grid, curr, direction, steps);
                curr = moveResult.Pos;
                direction = moveResult.Direction;

                if (grid[curr.Y, curr.X] != '.')
                {
                    throw new InvalidOperationException("oops");
                }
                Console.WriteLine("{0,-3} in {1} | {2} -> {3}", split, direction, old, curr);
            }
            else
            {
                direction = Rotate(direction, split);
            }
        }

        return ComputePassword(curr, direction);
    }

    private static long ComputePassword(XY pos, XY direction)
    {
        int dirValue = 0;
        if (direction == Down)
        {
            dirValue = 1;
        }

        if (direction == Left)
        {
            dirValue = 2;
        }

        if (direction == Up)
        {
            dirValue = 3;
        }

        int row = pos.Y + 1;
        int col = pos.X + 1;

        long password = (1000 * row) + (4 * col) + dirValue;

        return password;
    }

    private static bool InRange(XY curr, int minX, int maxX, int minY, int maxY)
    {
        return curr.X >= minX && curr.X <= maxX && curr.Y >= minY && curr.Y <= maxY;
    }

    private class Part2Wrap
    {
        public string Desc { get; }
        public int MinX { get; }
        public int MaxX { get; }
        public int MinY { get; }
        public int MaxY { get; }
        public XY OldDirection { get; }
        public XY NewDirection { get; }
        public Func<XY, XY> Transform { get; }

        public Part2Wrap(
            string desc,
            int minX,
            int maxX,
            int minY,
            int maxY,
            XY oldDirection,
            XY newDirection,
            Func<XY, XY> transform
        )
        {
            Desc = desc;
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
            OldDirection = oldDirection;
            NewDirection = newDirection;
            Transform = transform;
        }
    };

    private static XY Move1(char[,] grid, XY curr, XY direction, int steps)
    {
        XY MakeNext(XY point, XY dir)
        {
            XY next = new(point.X + dir.X, point.Y + dir.Y);
            if (next.X < 0)
            {
                next = next with { X = grid.GetLength(1) - 1 };
            }
            else if (next.X == grid.GetLength(1))
            {
                next = next with { X = 0 };
            }
            else if (next.Y < 0)
            {
                next = next with { Y = grid.GetLength(0) - 1 };
            }
            else if (next.Y == grid.GetLength(0))
            {
                next = next with { Y = 0 };
            }

            return next;
        }

        int taken = 0;
        while (taken < steps)
        {
            XY next = MakeNext(curr, direction);
            char nextCh = grid[next.Y, next.X];
            if (nextCh == '.')
            {
                curr = next;
            }
            else if (nextCh == ' ')
            {
                if (direction == Right)
                {
                    int x = 0;
                    while (grid[curr.Y, x] == ' ')
                    {
                        x++;
                    }

                    if (grid[curr.Y, x] == '#')
                    {
                        return curr;
                    }

                    curr = new(x, curr.Y);
                    if (grid[curr.Y, curr.X] != '.')
                        throw new InvalidOperationException("oops");
                }
                if (direction == Left)
                {
                    int x = grid.GetLength(1) - 1;
                    while (grid[curr.Y, x] == ' ')
                    {
                        x--;
                    }

                    if (grid[curr.Y, x] == '#')
                    {
                        return curr;
                    }

                    curr = new(x, curr.Y);
                    if (grid[curr.Y, curr.X] != '.')
                        throw new InvalidOperationException("oops");
                }
                if (direction == Up)
                {
                    int y = grid.GetLength(0) - 1;
                    while (grid[y, curr.X] == ' ')
                    {
                        y--;
                    }

                    if (grid[y, curr.X] == '#')
                    {
                        return curr;
                    }

                    curr = new(curr.X, y);
                    if (grid[curr.Y, curr.X] != '.')
                        throw new InvalidOperationException("oops");
                }
                if (direction == Down)
                {
                    int y = 0;
                    while (grid[y, curr.X] == ' ')
                    {
                        y++;
                    }

                    if (grid[y, curr.X] == '#')
                    {
                        return curr;
                    }

                    curr = new(curr.X, y);
                    if (grid[curr.Y, curr.X] != '.')
                        throw new InvalidOperationException("oops");
                }
            }
            else if (nextCh == '#')
            {
                return curr;
            }

            taken++;
        }

        return curr;
    }

    private static MoveResult Move2(char[,] grid, XY curr, XY direction, int steps)
    {
        XY MakeNext(XY point, XY dir)
        {
            XY next = new(point.X + dir.X, point.Y + dir.Y);
            if (next.X < 0)
            {
                next = next with { X = grid.GetLength(1) - 1 };
            }
            else if (next.X == grid.GetLength(1))
            {
                next = next with { X = 0 };
            }
            else if (next.Y < 0)
            {
                next = next with { Y = grid.GetLength(0) - 1 };
            }
            else if (next.Y == grid.GetLength(0))
            {
                next = next with { Y = 0 };
            }

            return next;
        }

        int taken = 0;
        while (taken < steps)
        {
            XY next = MakeNext(curr, direction);
            char nextCh = grid[next.Y, next.X];
            if (nextCh == '.')
            {
                curr = next;
            }
            else if (nextCh == ' ')
            {
                var wrapToApply = Part2Wraps.Single(
                    w =>
                        InRange(curr, w.MinX, w.MaxX, w.MinY, w.MaxY) && direction == w.OldDirection
                );
                XY wrappedPos = wrapToApply.Transform(curr);

                char charAfterWrap = grid[wrappedPos.Y, wrappedPos.X];
                if (charAfterWrap == '#')
                {
                    return new MoveResult(curr, direction);
                }
                if (charAfterWrap == '.')
                {
                    curr = wrappedPos;
                    direction = wrapToApply.NewDirection;
                }
                else
                {
                    throw new InvalidOperationException("oops");
                }
            }
            else if (nextCh == '#')
            {
                return new MoveResult(curr, direction);
            }

            taken++;
        }

        return new MoveResult(curr, direction);
    }

    private static XY Rotate(XY curr, string direction)
    {
        if (direction == "L")
        {
            return new XY(curr.Y, curr.X * -1);
        }

        return new XY(curr.Y * -1, curr.X);
    }

    private static XY FindStart(char[,] grid)
    {
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            if (grid[0, col] == '.')
            {
                return new XY(col, 0);
            }
        }

        return null;
    }

    private static char[,] ParseMap(string[] lines)
    {
        var nonBlank = lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        nonBlank.RemoveAt(nonBlank.Count - 1);

        int height = nonBlank.Count;
        int maxWidth = 0;
        foreach (string line in nonBlank)
        {
            maxWidth = Math.Max(maxWidth, line.Length);
        }

        char[,] grid = new char[height, maxWidth];
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            string line = nonBlank[row].PadRight(maxWidth, ' ');
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = line[col];
            }
        }

        return grid;
    }

    public static string GetInstructionLine(string[] lines)
    {
        var nonBlank = lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        return nonBlank.Last();
    }

    private record MoveResult(XY Pos, XY Direction);

    private record XY(int X, int Y)
    {
        public override string ToString() => $"({X}, {Y})";
    }
}
