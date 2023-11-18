namespace AOC.CSharp;

public static class AOC2018_13
{
    public static string Solve1(string[] lines)
    {
        Cell[,] grid = Parse(lines);

        string crash = null;
        while (crash == null)
        {
            (grid, crash) = Advance(grid);
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
                    Direction? newDir = oldCell.Cart.Direction;
                    IntersectionDirection? newIntDir = oldCell.Cart.NextDir;
                    int newX = x;
                    int newY = y;

                    if (oldCell.Track == '+')
                    {
                        var pair = (oldCell.Cart.Direction, oldCell.Cart.NextDir);
                        var result = pair switch
                        {
                            (Direction.Up, IntersectionDirection.Left)
                                => (Direction.Left, IntersectionDirection.Straight, x - 1, y),
                            (Direction.Up, IntersectionDirection.Straight)
                                => (Direction.Up, IntersectionDirection.Right, x, y - 1),
                            (Direction.Up, IntersectionDirection.Right)
                                => (Direction.Right, IntersectionDirection.Left, x + 1, y),
                            (Direction.Left, IntersectionDirection.Left)
                                => (Direction.Down, IntersectionDirection.Straight, x, y + 1),
                            (Direction.Left, IntersectionDirection.Straight)
                                => (Direction.Left, IntersectionDirection.Right, x - 1, y),
                            (Direction.Left, IntersectionDirection.Right)
                                => (Direction.Up, IntersectionDirection.Left, x, y - 1),
                            (Direction.Down, IntersectionDirection.Left)
                                => (Direction.Right, IntersectionDirection.Straight, x + 1, y),
                            (Direction.Down, IntersectionDirection.Straight)
                                => (Direction.Down, IntersectionDirection.Right, x, y + 1),
                            (Direction.Down, IntersectionDirection.Right)
                                => (Direction.Left, IntersectionDirection.Left, x - 1, y),
                            (Direction.Right, IntersectionDirection.Left)
                                => (Direction.Up, IntersectionDirection.Straight, x, y - 1),
                            (Direction.Right, IntersectionDirection.Straight)
                                => (Direction.Right, IntersectionDirection.Right, x + 1, y),
                            (Direction.Right, IntersectionDirection.Right)
                                => (Direction.Down, IntersectionDirection.Left, x, y + 1),
                        };

                        newDir = result.Item1;
                        newIntDir = result.Item2;
                        newX = result.Item3;
                        newY = result.Item4;
                    }
                    else if (oldCell.Track == '-')
                    {
                        newX = oldCell.Cart.Direction switch
                        {
                            Direction.Left => x - 1,
                            Direction.Right => x + 1,
                            _
                                => throw new InvalidOperationException(
                                    oldCell.Cart.Direction.ToString()
                                ),
                        };
                    }
                    else if (oldCell.Track == '|')
                    {
                        newY = oldCell.Cart.Direction switch
                        {
                            Direction.Down => y + 1,
                            Direction.Up => y - 1,
                            _
                                => throw new InvalidOperationException(
                                    oldCell.Cart.Direction.ToString()
                                ),
                        };
                    }
                    else if (oldCell.Track == '/')
                    {
                        if (oldCell.Cart.Direction == Direction.Up)
                        {
                            newDir = Direction.Right;
                            newX = x + 1;
                        }
                        else if (oldCell.Cart.Direction == Direction.Left)
                        {
                            newDir = Direction.Down;
                            newY = y + 1;
                        }
                        else if (oldCell.Cart.Direction == Direction.Down)
                        {
                            newDir = Direction.Left;
                            newX = x - 1;
                        }
                        else // RIGHT
                        {
                            newDir = Direction.Up;
                            newY = y - 1;
                        }
                    }
                    else if (oldCell.Track == '\\')
                    {
                        if (oldCell.Cart.Direction == Direction.Up)
                        {
                            newDir = Direction.Left;
                            newX = x - 1;
                        }
                        else if (oldCell.Cart.Direction == Direction.Left)
                        {
                            newDir = Direction.Up;
                            newY = y - 1;
                        }
                        else if (oldCell.Cart.Direction == Direction.Down)
                        {
                            newDir = Direction.Right;
                            newX = x + 1;
                        }
                        else // RIGHT
                        {
                            newDir = Direction.Down;
                            newY = y + 1;
                        }
                    }

                    newCell.Cart.Direction = newDir.Value;
                    newCell.Cart.NextDir = newIntDir.Value;

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
                        Direction.Down => 'v',
                        Direction.Left => '<',
                        Direction.Up => '^',
                        Direction.Right => '>',
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

                char track = c switch
                {
                    '>' => '-',
                    '<' => '-',
                    'v' => '|',
                    '^' => '|',
                    _ => c,
                };

                Direction? dir = c switch
                {
                    '>' => Direction.Right,
                    '<' => Direction.Left,
                    'v' => Direction.Down,
                    '^' => Direction.Up,
                    _ => null,
                };

                cell.Track = track;
                if (dir.HasValue)
                {
                    cell.Cart = new() { Direction = dir.Value, };
                }
                grid[x, y] = cell;
            }
        }

        return grid;
    }

    private class Cell
    {
        public char Track { get; set; }
        public Cart Cart { get; set; }
    }

    private class Cart
    {
        public Direction Direction { get; set; }
        public IntersectionDirection NextDir { get; set; } = IntersectionDirection.Left;
    }

    private enum Direction
    {
        Up,
        Right,
        Down,
        Left,
    }

    private enum IntersectionDirection
    {
        Left,
        Straight,
        Right,
    }
}
