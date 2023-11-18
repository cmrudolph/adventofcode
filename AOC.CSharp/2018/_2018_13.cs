namespace AOC.CSharp;

public static class AOC2018_13
{
    public static string Solve1(string[] lines)
    {
        (Cell[,] grid, Dictionary<(int, int), Cart> carts) = Parse(lines);

        int i = 0;
        string crash = null;
        while (crash == null && i < 5000)
        {
            (crash, carts) = Advance(grid, carts);
            i++;
        }

        return crash;
    }

    public static string Solve2(string[] lines)
    {
        return "BEYONCE";
    }

    private static (string, Dictionary<(int, int), Cart>) Advance(
        Cell[,] grid,
        Dictionary<(int, int), Cart> carts
    )
    {
        string crash = null;
        Dictionary<(int, int), Cart> newCarts = Clone(carts);

        var cartsToProcess = carts.Values.OrderBy(x => x.Y).ThenBy(x => x.X).ToList();
        foreach (Cart cart in cartsToProcess)
        {
            int x = cart.X;
            int y = cart.Y;

            Cell cell = grid[x, y];
            Cart oldCart = carts.GetValueOrDefault((x, y), null);
            Cart newCart = newCarts.GetValueOrDefault((x, y), null);

            if (oldCart != null)
            {
                int? newDir = oldCart.Direction;

                if (cell.Track == '+')
                {
                    newDir = HandleIntersection(oldCart.Direction, oldCart.NextDir);
                    newCart.SetNextIntersectionDirection();
                }
                else if (cell.Track == '/')
                {
                    newDir = oldCart.Direction switch
                    {
                        Up => Right,
                        Right => Up,
                        Down => Left,
                        Left => Down,
                    };
                }
                else if (cell.Track == '\\')
                {
                    newDir = oldCart.Direction switch
                    {
                        Up => Left,
                        Left => Up,
                        Down => Right,
                        Right => Down,
                    };
                }

                (int newX, int newY) = newDir switch
                {
                    Up => (x, y - 1),
                    Right => (x + 1, y),
                    Down => (x, y + 1),
                    Left => (x - 1, y)
                };

                newCart.Direction = newDir.Value;
                newCart.X = newX;
                newCart.Y = newY;

                if (crash == null && newCarts.ContainsKey((newX, newY)))
                {
                    crash = $"{newX},{newY}";
                    return (crash, newCarts);
                }

                newCarts.Remove((x, y));
                newCarts.Add((newX, newY), newCart);
            }
        }

        return (null, newCarts);
    }

    private static (Cell[,], Dictionary<(int, int), Cart>) Parse(string[] lines)
    {
        Cell[,] grid = new Cell[lines[0].Length, lines.Length];
        Dictionary<(int, int), Cart> carts = new();

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
                    Cart cart =
                        new()
                        {
                            Direction = dir2.Value,
                            X = x,
                            Y = y,
                        };
                    carts.Add((x, y), cart);
                }
                grid[x, y] = cell;
            }
        }

        return (grid, carts);
    }

    private static void Print(Cell[,] grid, Dictionary<(int, int), Cart> carts)
    {
        int rows = grid.GetLength(1);
        int cols = grid.GetLength(0);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Cell cell = grid[x, y];
                Cart cart = carts.GetValueOrDefault((x, y), null);
                char toPrint = cell.Track;
                if (cart != null)
                {
                    toPrint = cart.Direction switch
                    {
                        Down => 'v',
                        Left => '<',
                        Up => '^',
                        Right => '>',
                        _ => throw new InvalidOperationException(cart.Direction.ToString()),
                    };
                }

                Console.Write(toPrint);
            }

            Console.WriteLine();
        }
    }

    private static Dictionary<(int, int), Cart> Clone(Dictionary<(int, int), Cart> carts)
    {
        Dictionary<(int, int), Cart> newCarts = new();

        foreach (var kvp in carts)
        {
            var oldCart = kvp.Value;
            newCarts.Add(
                kvp.Key,
                new Cart { Direction = oldCart.Direction, NextDir = oldCart.NextDir }
            );
        }

        return newCarts;
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
    }

    private class Cart
    {
        public int X { get; set; }
        public int Y { get; set; }
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
