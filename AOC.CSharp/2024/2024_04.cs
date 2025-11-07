namespace AOC.CSharp;

public static class AOC2024_04
{
    public static long Solve1(string[] lines)
    {
        char[,] grid = new char[lines.Length, lines[0].Length];
        for (int r = 0; r < lines.Length; r++)
        {
            for (int c = 0; c < lines[r].Length; c++)
            {
                grid[r, c] = lines[r][c];
            }
        }

        int sum = 0;

        for (int r = 0; r < lines.Length; r++)
        {
            for (int c = 0; c < lines[r].Length; c++)
            {
                sum += Check1(grid, r, c, -1, 0); // N
                sum += Check1(grid, r, c, -1, 1); // NE
                sum += Check1(grid, r, c, 0, 1); // E
                sum += Check1(grid, r, c, 1, 1); // SE
                sum += Check1(grid, r, c, 1, 0); // S
                sum += Check1(grid, r, c, 1, -1); // SW
                sum += Check1(grid, r, c, 0, -1); // W
                sum += Check1(grid, r, c, -1, -1); // NW
            }
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        char[,] grid = new char[lines.Length, lines[0].Length];
        for (int r = 0; r < lines.Length; r++)
        {
            for (int c = 0; c < lines[r].Length; c++)
            {
                grid[r, c] = lines[r][c];
            }
        }

        int sum = 0;

        for (int r = 0; r < lines.Length; r++)
        {
            for (int c = 0; c < lines[r].Length; c++)
            {
                sum += Check2(grid, r, c);
            }
        }

        return sum;
    }

    private static int Check1(char[,] grid, int rStart, int cStart, int rMove, int cMove)
    {
        int r = rStart;
        int c = cStart;

        for (int i = 0; i < 4; i++)
        {
            if (r < 0 || c < 0)
            {
                return 0;
            }

            if (r > grid.GetLength(0) || c > grid.GetLength(1))
            {
                return 0;
            }

            if (r < 0 || r >= grid.GetLength(0))
            {
                return 0;
            }

            if (c < 0 || c >= grid.GetLength(1))
            {
                return 0;
            }

            if (i == 0 && grid[r, c] != 'X')
            {
                return 0;
            }

            if (i == 1 && grid[r, c] != 'M')
            {
                return 0;
            }

            if (i == 2 && grid[r, c] != 'A')
            {
                return 0;
            }

            if (i == 3 && grid[r, c] != 'S')
            {
                return 0;
            }

            r += rMove;
            c += cMove;
        }

        return 1;
    }

    private static int Check2(char[,] grid, int r, int c)
    {
        if (r == 0 || (r + 1) >= grid.GetLength(0))
        {
            return 0;
        }

        if (c == 0 || (c + 1) >= grid.GetLength(1))
        {
            return 0;
        }

        if (grid[r, c] != 'A')
        {
            return 0;
        }

        int IsMas(char[,] grid, int r, int c, int rMove, int cMove)
        {
            if (grid[r, c] != 'A')
            {
                return 0;
            }

            if (grid[r + rMove, c + cMove] == 'M' && grid[r - rMove, c - cMove] == 'S')
            {
                return 1;
            }

            return 0;
        }

        int sums = 0;

        sums += IsMas(grid, r, c, -1, -1);
        sums += IsMas(grid, r, c, 1, -1);
        sums += IsMas(grid, r, c, 1, 1);
        sums += IsMas(grid, r, c, -1, 1);

        return sums == 2 ? 1 : 0;
    }
}
