namespace AOC.CSharp;

public static class AOC2022_14
{
    private const char Open = '.';
    private const char Rock = '#';
    private const char Sand = 'O';

    private static Action<char[,]> PrintAction = _ => { };

    public static long Solve1(string[] lines)
    {
        var grid = Parse(lines, false);

        PrintAction(grid);

        int count = 0;
        while (DropSand(grid))
        {
            count++;
        }

        Console.WriteLine();
        PrintAction(grid);

        return count;
    }

    public static long Solve2(string[] lines)
    {
        var grid = Parse(lines, true);

        PrintAction(grid);

        int count = 0;
        while (DropSand(grid))
        {
            count++;
        }

        Console.WriteLine();
        PrintAction(grid);

        return count;
    }

    private static void PrintSample(char[,] grid) => Print(grid, 0, 11, 470, 530);
    private static void PrintActual(char[,] grid) => Print(grid, 13, 168, 460, 550);

    private static char[,] Parse(string[] lines, bool floor)
    {
        int overallMinRow = int.MaxValue;
        int overallMaxRow = 0;
        int overallMinCol = int.MaxValue;
        int overallMaxCol = 0;

        (int, int) SplitPoint(string s)
        {
            var xy = s.Split(',');
            int x = int.Parse(xy[0]);
            int y = int.Parse(xy[1]);

            return (x, y);
        }

        char[,] grid = new char[1000, 1000];
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                grid[i, j] = Open;
            }
        }

        foreach (string line in lines)
        {
            string[] splits = line.Split(" -> ");
            for (int i = 0; i < splits.Length - 1; i++)
            {
                string point1 = splits[i];
                string point2 = splits[i + 1];
                (int col1, int row1) = SplitPoint(point1);
                (int col2, int row2) = SplitPoint(point2);

                int minCol = Math.Min(col1, col2);
                int maxCol = Math.Max(col1, col2);
                int minRow = Math.Min(row1, row2);
                int maxRow = Math.Max(row1, row2);

                overallMinRow = Math.Min(minRow, overallMinRow);
                overallMaxRow = Math.Max(maxRow, overallMaxRow);
                overallMinCol = Math.Min(minCol, overallMinCol);
                overallMaxCol = Math.Max(maxCol, overallMaxCol);

                for (int row = minRow; row <= maxRow; row++)
                {
                    for (int col = minCol; col <= maxCol; col++)
                    {
                        grid[row, col] = Rock;
                    }
                }
            }
        }

        if (floor)
        {
            // Build the floor for part 2. Extension amount found via trial and error (increase numbers until the result
            // stopped growing.
            for (int col = overallMinCol - 200; col < overallMaxCol + 200; col++)
            {
                grid[overallMaxRow + 2, col] = Rock;
            }
        }

        Console.WriteLine("R:{0} to {1} | C:{2} to {3}", overallMinRow, overallMaxRow, overallMinCol, overallMaxCol);

        return grid;
    }

    private static bool DropSand(char[,] grid)
    {
        Cell start = new(0, 500);
        Cell curr = start;
        Cell prev = null;

        if (grid[start.Row, start.Col] == Sand)
        {
            return false;
        }

        while (curr != prev)
        {
            bool thisSearchDone = false;
            prev = curr;

            if (curr.Row == grid.GetLength(0) - 1)
            {
                // Fell off the bottom
                return false;
            }

            var candidates = GetCandidates(curr);
            for (int i = 0; i < candidates.Length && !thisSearchDone; i++)
            {
                var candidate = candidates[i];
                char ch = grid[candidate.Row, candidate.Col];

                if (ch == Open)
                {
                    // Go down this path
                    thisSearchDone = true;
                    curr = candidate;
                }
            }
        }

        // We did not move on the last loop iteration. We could not progress (hit sand or hit rock), so we need to stop
        grid[curr.Row, curr.Col] = Sand;
        return true;
    }

    private static Cell[] GetCandidates(Cell curr)
    {
        // Check in priority order (down, down-left, down-right)
        return new[]
        {
            new Cell(curr.Row + 1, curr.Col),
            new Cell(curr.Row + 1, curr.Col - 1),
            new Cell(curr.Row + 1, curr.Col + 1),
        };
    }

    private static void Print(char[,] grid, int rowStart, int rowEnd, int colStart, int colEnd)
    {
        for (int row = rowStart; row <= rowEnd; row++)
        {
            for (int col = colStart; col <= colEnd; col++)
            {
                char c = grid[row, col];
                Console.Write(c);
            }

            Console.WriteLine();
        }
    }

    private record Cell(int Row, int Col);
}
