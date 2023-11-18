namespace AOC.CSharp;

public static class AOC2018_13
{
    public static string Solve1(string[] lines)
    {
        Cell[,] grid = Parse(lines);

        int i = 0;
        string crash = null;
        while (crash == null && i < 5000)
        {
            (grid, crash) = Advance(grid);
            i++;
        }

        return crash;
    }

    public static string Solve2(string[] lines)
    {
        return "BEYONCE";
    }

    private static (Cell[,], string) Advance(Cell[,] oldGrid)
    {
        string crash = null;

        int rows = oldGrid.GetLength(1);
        int cols = oldGrid.GetLength(0);
        Cell[,] newGrid = Clone(oldGrid);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Cell oldCell = oldGrid[x, y];
                Cell newCell = newGrid[x, y];

                if (oldCell.Cart != null)
                {
                    int? newDir = oldCell.Cart.Direction;
                    int newX = x;
                    int newY = y;

                    if (oldCell.Track == '+')
                    {
                        newDir = HandleIntersection(oldCell.Cart.Direction, oldCell.Cart.NextDir);
                        newCell.Cart.SetNextIntersectionDirection();
                    }
                    else if (oldCell.Track == '/')
                    {
                        newDir = oldCell.Cart.Direction switch
                        {
                            Up => Right,
                            Right => Up,
                            Down => Left,
                            Left => Down,
                        };
                    }
                    else if (oldCell.Track == '\\')
                    {
                        newDir = oldCell.Cart.Direction switch
                        {
                            Up => Left,
                            Left => Up,
                            Down => Right,
                            Right => Down,
                        };
                    }

                    (newX, newY) = newDir switch
                    {
                        Up => (x, y - 1),
                        Right => (x + 1, y),
                        Down => (x, y + 1),
                        Left => (x - 1, y)
                    };

                    newCell.Cart.Direction = newDir.Value;

                    if (crash == null && newGrid[newX, newY].Cart != null)
                    {
                        crash = $"{newX},{newY}";
                    }

                    newGrid[newX, newY].Cart = newCell.Cart;
                    newGrid[x, y].Cart = null;
                }
            }
        }

        return (newGrid, crash);
    }

    private static Cell[,] Parse(string[] lines)
    {
        Cell[,] grid = new Cell[lines[0].Length, lines.Length];

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                Cell cell = new();
                char c = line[x];

                char track = InitialCharToTrack(c);

                int? dir2 = InitialCharToCartDirection(c);

                cell.Track = track;
                if (dir2.HasValue)
                {
                    cell.Cart = new() { Direction = dir2.Value, };
                }
                grid[x, y] = cell;
            }
        }

        return grid;
    }

    private static void Print(Cell[,] grid)
    {
        int rows = grid.GetLength(1);
        int cols = grid.GetLength(0);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Cell cell = grid[x, y];
                char toPrint = cell.Track;
                if (cell.Cart != null)
                {
                    toPrint = cell.Cart.Direction switch
                    {
                        Down => 'v',
                        Left => '<',
                        Up => '^',
                        Right => '>',
                        _ => throw new InvalidOperationException(cell.Cart.Direction.ToString()),
                    };
                }

                Console.Write(toPrint);
            }

            Console.WriteLine();
        }
    }

    private static Cell[,] Clone(Cell[,] orig)
    {
        int rows = orig.GetLength(1);
        int cols = orig.GetLength(0);
        Cell[,] grid = new Cell[cols, rows];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Cell existing = orig[x, y];

                Cart cart =
                    existing.Cart == null
                        ? null
                        : new Cart()
                        {
                            Direction = existing.Cart.Direction,
                            NextDir = existing.Cart.NextDir,
                        };

                Cell cell = new() { Track = existing.Track, Cart = cart };
                grid[x, y] = cell;
            }
        }

        return grid;
    }

    private static int HandleIntersection(int dir, IntersectionDirection intDir)
    {
        int adjustment = intDir switch
        {
            IntersectionDirection.Left => -1,
            IntersectionDirection.Straight => 0,
            IntersectionDirection.Right => 1,
        };

        int newDir = (dir + adjustment) % 4;
        if (newDir < 0)
        {
            newDir += 4;
        }

        return newDir;
    }

    private static int? InitialCharToCartDirection(char c) =>
        c switch
        {
            '^' => Up,
            '>' => Right,
            'v' => Down,
            '<' => Left,
            _ => null,
        };

    private static char InitialCharToTrack(char c) =>
        c switch
        {
            '>' => '-',
            '<' => '-',
            'v' => '|',
            '^' => '|',
            _ => c,
        };

    private class Cell
    {
        public char Track { get; set; }
        public Cart Cart { get; set; }
    }

    private class Cart
    {
        public int Direction { get; set; }
        public IntersectionDirection NextDir { get; set; } = IntersectionDirection.Left;

        public void SetNextIntersectionDirection()
        {
            NextDir = (IntersectionDirection)((int)(NextDir + 1) % 3);
        }
    }

    private const int Up = 0;
    private const int Right = 1;
    private const int Down = 2;
    private const int Left = 3;

    private enum IntersectionDirection
    {
        Left = 0,
        Straight = 1,
        Right = 2,
    }
}
