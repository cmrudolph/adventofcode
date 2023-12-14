namespace AOC.CSharp;

public static class AOC2023_14
{
    public static long Solve1(string[] lines)
    {
        char[,] grid = Parse(lines);
        while (Move(grid, Direction.North)) { }

        long result = MathIt(grid);

        return result;
    }

    public static long Solve2(string[] lines)
    {
        char[,] grid = Parse(lines);
        long[] lookup = new long[7];
        const long offsetBase = 300;

        // Run long enough to get into a rut (repeating pattern of 7 values)
        for (int i = 1; i < 307; i++)
        {
            while (Move(grid, Direction.North)) { }
            while (Move(grid, Direction.West)) { }
            while (Move(grid, Direction.South)) { }
            while (Move(grid, Direction.East)) { }

            long result = MathIt(grid);

            //Console.WriteLine("{0} | {1}", i, result);

            if (i >= offsetBase)
            {
                lookup[i - offsetBase] = result;
            }
        }

        // Figure out where the target falls in the repeat and look it up
        long target = 1000000000;
        long shiftedTarget = target - offsetBase;
        long bucket = shiftedTarget % lookup.Length;
        long finalResult = lookup[bucket];

        return finalResult;
    }

    private static long MathIt(char[,] grid)
    {
        int height = grid.GetLength(0);
        int width = grid.GetLength(1);

        long sum = 0;
        for (int y = 0; y < height; y++)
        {
            long rowVal = height - y;

            for (int x = 0; x < width; x++)
            {
                if (grid[y, x] == 'O')
                {
                    sum += rowVal;
                }
            }
        }

        return sum;
    }

    private static void Print(char[,] grid)
    {
        int height = grid.GetLength(0);
        int width = grid.GetLength(1);

        long sum = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(grid[y, x]);
            }

            Console.WriteLine();
        }
    }

    private static bool Move(char[,] grid, Direction dir)
    {
        bool moved = false;

        int height = grid.GetLength(0);
        int width = grid.GetLength(1);

        if (dir == Direction.North)
        {
            for (int y = 1; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char destCh = grid[y - 1, x];
                    char srcCh = grid[y, x];
                    if (srcCh == 'O' && destCh == '.')
                    {
                        grid[y - 1, x] = srcCh;
                        grid[y, x] = '.';
                        moved = true;
                    }
                }
            }
        }
        else if (dir == Direction.South)
        {
            for (int y = height - 2; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    char destCh = grid[y + 1, x];
                    char srcCh = grid[y, x];
                    if (srcCh == 'O' && destCh == '.')
                    {
                        grid[y + 1, x] = srcCh;
                        grid[y, x] = '.';
                        moved = true;
                    }
                }
            }
        }
        else if (dir == Direction.West)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 1; x < width; x++)
                {
                    char destCh = grid[y, x - 1];
                    char srcCh = grid[y, x];
                    if (srcCh == 'O' && destCh == '.')
                    {
                        grid[y, x - 1] = srcCh;
                        grid[y, x] = '.';
                        moved = true;
                    }
                }
            }
        }
        else if (dir == Direction.East)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = width - 2; x >= 0; x--)
                {
                    char destCh = grid[y, x + 1];
                    char srcCh = grid[y, x];
                    if (srcCh == 'O' && destCh == '.')
                    {
                        grid[y, x + 1] = srcCh;
                        grid[y, x] = '.';
                        moved = true;
                    }
                }
            }
        }

        return moved;
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

    private enum Direction
    {
        North,
        West,
        South,
        East,
    }
}
