namespace AOC.CSharp;

public static class AOC2022_22
{
    private static XY North = new(0, -1);
    private static XY East = new(1, 0);
    private static XY South = new(0, 1);
    private static XY West = new(-1, 0);

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
        XY direction = East;

        string instructions = GetInstructionLine(lines).Replace("L", " L ").Replace("R", " R ");
        string[] splits = instructions.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string split in splits)
        {
            if (int.TryParse(split, out int steps))
            {
                XY old = curr;
                curr = Move(grid, curr, direction, steps);
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

        int dirValue = 0;
        if (direction == South)
        {
            dirValue = 1;
        }

        if (direction == West)
        {
            dirValue = 2;
        }

        if (direction == North)
        {
            dirValue = 3;
        }

        int row = curr.Y + 1;
        int col = curr.X + 1;

        Console.WriteLine("{0} facing {1} | {2} {3} {4}", curr, direction, row, col, dirValue);
        long result = (1000 * row) + (4 * col) + dirValue;

        return result;
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private static XY Move(char[,] grid, XY curr, XY direction, int steps)
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
                if (direction == East)
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
                    if (grid[curr.Y, curr.X] != '.') throw new InvalidOperationException("oops");
                }
                if (direction == West)
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
                    if (grid[curr.Y, curr.X] != '.') throw new InvalidOperationException("oops");
                }
                if (direction == North)
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
                    if (grid[curr.Y, curr.X] != '.') throw new InvalidOperationException("oops");
                }
                if (direction == South)
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
                    if (grid[curr.Y, curr.X] != '.') throw new InvalidOperationException("oops");
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

    private record XY(int X, int Y)
    {
        public override string ToString() => $"({X}, {Y})";
    }
}
