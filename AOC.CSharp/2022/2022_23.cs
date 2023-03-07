namespace AOC.CSharp;

public static class AOC2022_23
{
    public static long Solve1(string[] lines)
    {
        long result = Solve(lines, 1);
        return result;
    }

    public static long Solve2(string[] lines)
    {
        long result = Solve(lines, 2);
        return result;
    }

    public static long Solve(string[] lines, int part)
    {
        char[,] grid = Parse(lines);

        List<Func<char[,], XY, Direction?>> tryMoves =
            new() { TryMoveNorth, TryMoveSouth, TryMoveWest, TryMoveEast, };

        int minRow = int.MaxValue;
        int maxRow = 0;
        int minCol = int.MaxValue;
        int maxCol = 0;

        int round = 1;
        while (true)
        {
            Console.WriteLine(round);
            List<Move> moves = new();

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    XY curr = new(col, row);
                    if (grid[row, col] == '#')
                    {
                        minRow = Math.Min(minRow, row);
                        maxRow = Math.Max(maxRow, row);
                        minCol = Math.Min(minCol, col);
                        maxCol = Math.Max(maxCol, col);

                        bool isNeighbor = IsElfNeighbor(grid, curr);
                        if (isNeighbor)
                        {
                            Direction? toTry = null;
                            for (int i = 0; i < tryMoves.Count && toTry == null; i++)
                            {
                                toTry = tryMoves[i](grid, curr);
                                if (toTry.HasValue)
                                {
                                    XY other = FindOther(curr, toTry.Value);
                                    moves.Add(new Move(curr, other));
                                }
                            }
                        }
                    }
                }
            }

            Dictionary<XY, int> destCounts = moves
                .GroupBy(m => m.To)
                .ToDictionary(g => g.Key, g => g.Count());

            if (part == 2 && !moves.Any())
            {
                return round;
            }

            foreach (Move m in moves)
            {
                if (destCounts[m.To] == 1)
                {
                    minRow = Math.Min(minRow, m.To.Y);
                    maxRow = Math.Max(maxRow, m.To.Y);
                    minCol = Math.Min(minCol, m.To.X);
                    maxCol = Math.Max(maxCol, m.To.X);

                    grid[m.To.Y, m.To.X] = '#';
                    grid[m.From.Y, m.From.X] = '.';
                }
            }

            var newLast = tryMoves[0];
            tryMoves.Add(newLast);
            tryMoves.RemoveAt(0);

            if (part == 1 && round == 10)
            {
                long result = 0;
                (minRow, maxRow, minCol, maxCol) = Trim(grid, minRow, maxRow, minCol, maxCol);
                for (int row = minRow; row <= maxRow; row++)
                {
                    for (int col = minCol; col <= maxCol; col++)
                    {
                        result += grid[row, col] == '.' ? 1 : 0;
                    }
                }

                return result;
            }

            round++;
        }
    }

    private static Direction? TryMoveNorth(char[,] grid, XY curr)
    {
        bool canMove = true;
        canMove &= Get(grid, curr, Direction.NW) == '.';
        canMove &= Get(grid, curr, Direction.N) == '.';
        canMove &= Get(grid, curr, Direction.NE) == '.';

        return canMove ? Direction.N : null;
    }

    private static Direction? TryMoveSouth(char[,] grid, XY curr)
    {
        bool canMove = true;
        canMove &= Get(grid, curr, Direction.SW) == '.';
        canMove &= Get(grid, curr, Direction.S) == '.';
        canMove &= Get(grid, curr, Direction.SE) == '.';

        return canMove ? Direction.S : null;
    }

    private static Direction? TryMoveWest(char[,] grid, XY curr)
    {
        bool canMove = true;
        canMove &= Get(grid, curr, Direction.NW) == '.';
        canMove &= Get(grid, curr, Direction.W) == '.';
        canMove &= Get(grid, curr, Direction.SW) == '.';

        return canMove ? Direction.W : null;
    }

    private static Direction? TryMoveEast(char[,] grid, XY curr)
    {
        bool canMove = true;
        canMove &= Get(grid, curr, Direction.NE) == '.';
        canMove &= Get(grid, curr, Direction.E) == '.';
        canMove &= Get(grid, curr, Direction.SE) == '.';

        return canMove ? Direction.E : null;
    }

    private static char[,] Parse(string[] lines)
    {
        char[,] grid = new char[2500, 2500];

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = '.';
            }
        }

        for (int row = 0; row < lines.Length; row++)
        {
            for (int col = 0; col < lines[0].Length; col++)
            {
                int trueRow = row + 600;
                int trueCol = col + 600;

                grid[trueRow, trueCol] = lines[row][col];
            }
        }

        return grid;
    }

    private static bool IsElfNeighbor(char[,] grid, XY curr)
    {
        bool found = false;
        foreach (Direction d in Enum.GetValues<Direction>())
        {
            char val = Get(grid, curr, d);
            found |= val == '#';
        }

        return found;
    }

    private static char Get(char[,] grid, XY curr, Direction dir)
    {
        XY other = FindOther(curr, dir);
        return grid[other.Y, other.X];
    }

    private static (int, int, int, int) Trim(
        char[,] grid,
        int minRow,
        int maxRow,
        int minCol,
        int maxCol
    )
    {
        for (int row = minRow; row <= maxRow; row++)
        {
            bool empty = true;
            for (int col = minCol; col <= maxCol && empty; col++)
            {
                empty &= grid[row, col] == '.';
            }

            if (empty)
            {
                minRow++;
            }
            else
            {
                break;
            }
        }

        for (int row = maxRow; row >= minRow; row--)
        {
            bool empty = true;
            for (int col = minCol; col <= maxCol && empty; col++)
            {
                empty &= grid[row, col] == '.';
            }

            if (empty)
            {
                maxRow--;
            }
            else
            {
                break;
            }
        }

        for (int col = minCol; col <= maxCol; col++)
        {
            bool empty = true;
            for (int row = minRow; row <= maxRow; row++)
            {
                empty &= grid[row, col] == '.';
            }

            if (empty)
            {
                minCol++;
            }
            else
            {
                break;
            }
        }

        for (int col = minCol; col <= maxCol; col++)
        {
            bool empty = true;
            for (int row = maxRow; row >= minRow; row--)
            {
                empty &= grid[row, col] == '.';
            }

            if (empty)
            {
                maxCol--;
            }
            else
            {
                break;
            }
        }

        return (minRow, maxRow, minCol, maxCol);
    }

    private record Move(XY From, XY To);

    private enum Direction
    {
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW,
    }

    private static XY FindOther(XY curr, Direction dir)
    {
        return dir switch
        {
            Direction.N => curr with { Y = curr.Y - 1 },
            Direction.NE => curr with { X = curr.X + 1, Y = curr.Y - 1 },
            Direction.E => curr with { X = curr.X + 1 },
            Direction.SE => curr with { X = curr.X + 1, Y = curr.Y + 1 },
            Direction.S => curr with { Y = curr.Y + 1 },
            Direction.SW => curr with { X = curr.X - 1, Y = curr.Y + 1 },
            Direction.W => curr with { X = curr.X - 1 },
            Direction.NW => curr with { X = curr.X - 1, Y = curr.Y - 1 },
            _ => throw new NotSupportedException(),
        };
    }

    private record XY(int X, int Y);
}
