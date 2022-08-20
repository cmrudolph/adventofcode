namespace AOC.CSharp;

public static class AOC2021_25
{
    public static long Solve1(string[] lines)
    {
        char[,] grid = Parse(lines);
        Print(grid);

        int transformCount = 0;
        while (true)
        {
            transformCount++;
            char[,] newGrid = Transform(grid);
            if (Same(grid, newGrid))
            {
                return transformCount;
            }
        }
    }

    public static long Solve2(string[] lines)
    {
        return 0L;
    }

    private static char[,] Parse(string[] lines)
    {
        int height = lines.Length;
        int width = lines[0].Length;
        char[,] grid = new char[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = lines[y][x];
            }
        }

        return grid;
    }

    private static void Print(char[,] grid)
    {
        int height = grid.GetLength(1);
        int width = grid.GetLength(0);
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(grid[x, y]);
            }

            Console.WriteLine();
        }
    }

    private static char[,] Transform(char[,] grid)
    {
        // TODO
        return grid;
    }
    
    private static bool Same(char[,] grid1, char[,] grid2)
    {
        for (int y = 0; y < grid1.GetLength(1); y++)
        {
            for (int x = 0; x < grid1.GetLength(0); x++)
            {
                if (grid1[x, y] != grid2[x, y])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
