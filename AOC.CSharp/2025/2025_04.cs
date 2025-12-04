namespace AOC.CSharp;

public static class AOC2025_04
{
    private static int CountNeighborRolls(char[,] grid, int r, int c)
    {
        List<char> vals = new();

        if (r > 0)
        {
            if (c > 0)
            {
                vals.Add(grid[r - 1, c - 1]); // NW
            }

            vals.Add(grid[r - 1, c]); // N

            if (c < grid.GetLength(1) - 1)
            {
                vals.Add(grid[r - 1, c + 1]); // NE
            }
        }

        if (c > 0)
        {
            vals.Add(grid[r, c - 1]); // W
        }

        if (c < grid.GetLength(1) - 1)
        {
            vals.Add(grid[r, c + 1]); // E
        }

        if (r < grid.GetLength(0) - 1)
        {
            if (c > 0)
            {
                vals.Add(grid[r + 1, c - 1]); // SW
            }

            vals.Add(grid[r + 1, c]); // S

            if (c < grid.GetLength(1) - 1)
            {
                vals.Add(grid[r + 1, c + 1]); // SE
            }
        }

        return vals.Count(x => x == '@');
    }

    public static long Solve1(string[] lines)
    {
        int sum = 0;

        int w = lines[0].Length;
        int h = lines.Length;
        char[,] grid = new char[h, w];

        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                grid[r, c] = lines[r][c];
            }
        }

        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                if (grid[r, c] == '@')
                {
                    int count = CountNeighborRolls(grid, r, c);
                    if (count <= 3)
                    {
                        sum++;
                    }
                }
            }
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        int sum = 0;

        int w = lines[0].Length;
        int h = lines.Length;
        char[,] grid = new char[h, w];

        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                grid[r, c] = lines[r][c];
            }
        }

        List<Coords> toRemove = new();

        do
        {
            foreach (var tr in toRemove)
            {
                grid[tr.R, tr.C] = '.';
            }

            toRemove.Clear();

            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    if (grid[r, c] == '@')
                    {
                        int count = CountNeighborRolls(grid, r, c);
                        if (count <= 3)
                        {
                            toRemove.Add(new(r, c));
                            sum++;
                        }
                    }
                }
            }
        } while (toRemove.Count > 0);

        return sum;
    }

    private record Coords(int R, int C);
}
