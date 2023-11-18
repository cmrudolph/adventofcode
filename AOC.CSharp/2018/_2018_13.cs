namespace AOC.CSharp;

public static class AOC2018_13
{
    public static string Solve1(string[] lines)
    {
        (char[,] grid, CartLookup carts) = Parse(lines);

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

    private static (string, CartLookup) Advance(char[,] grid, CartLookup carts)
    {
        string crash = null;
        CartLookup newCarts = carts.Clone();

        var cartsToProcess = carts.InProcessOrder();
        foreach (Cart cart in cartsToProcess)
        {
            int x = cart.X;
            int y = cart.Y;

            char track = grid[x, y];
            Cart oldCart = carts.Get(x, y);
            Cart newCart = newCarts.Get(x, y);

            if (oldCart != null)
            {
                int? newDir = oldCart.Direction;

                if (track == '+')
                {
                    newDir = HandleIntersection(oldCart.Direction, oldCart.NextDir);
                    newCart.SetNextIntersectionDirection();
                }
                else if (track == '/')
                {
                    newDir = oldCart.Direction switch
                    {
                        Up => Right,
                        Right => Up,
                        Down => Left,
                        Left => Down,
                    };
                }
                else if (track == '\\')
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

                if (crash == null && newCarts.Has(newX, newY))
                {
                    crash = $"{newX},{newY}";
                    return (crash, newCarts);
                }

                newCarts.Remove(x, y);
                newCarts.Add(newX, newY, newCart);
            }
        }

        return (null, newCarts);
    }

    private static (char[,], CartLookup) Parse(string[] lines)
    {
        char[,] grid = new char[lines[0].Length, lines.Length];
        CartLookup carts = new();

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                char c = line[x];
                char track = InitialCharToTrack(c);
                int? dir2 = InitialCharToCartDirection(c);

                if (dir2.HasValue)
                {
                    Cart cart =
                        new()
                        {
                            Direction = dir2.Value,
                            X = x,
                            Y = y,
                        };
                    carts.Add(x, y, cart);
                }
                grid[x, y] = track;
            }
        }

        return (grid, carts);
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

    private class CartLookup
    {
        private readonly Dictionary<(int, int), Cart> _lookup = new();

        public void Add(int x, int y, Cart cart)
        {
            _lookup.Add((x, y), cart);
        }

        public void Remove(int x, int y)
        {
            _lookup.Remove((x, y));
        }

        public Cart Get(int x, int y)
        {
            return _lookup.GetValueOrDefault((x, y), null);
        }

        public bool Has(int x, int y)
        {
            return _lookup.ContainsKey((x, y));
        }

        public Cart[] InProcessOrder()
        {
            return _lookup.Values.OrderBy(x => x.Y).ThenBy(x => x.X).ToArray();
        }

        public CartLookup Clone()
        {
            CartLookup newLookup = new();

            foreach (var kvp in _lookup)
            {
                var oldCart = kvp.Value;
                var newCart = new Cart { Direction = oldCart.Direction, NextDir = oldCart.NextDir };
                newLookup.Add(kvp.Key.Item1, kvp.Key.Item2, newCart);
            }

            return newLookup;
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
