namespace AOC.CSharp;

public static class AOC2022_08
{
    public static long Solve1(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        var grid = Parse(lines);

        // Just try looking from all directions. Mark stuff as visible as we traverse each line

        for (int row = 0; row < rows; row++)
        {
            // Left to right
            int biggest = -1;
            for (int col = 0; col < cols; col++)
            {
                Cell cell = grid[row, col];
                if (cell.Value > biggest)
                {
                    cell.Seen = true;
                    biggest = cell.Value;
                }
            }

            // Right to left
            biggest = -1;
            for (int col = cols - 1; col >= 0; col--)
            {
                Cell cell = grid[row, col];
                if (cell.Value > biggest)
                {
                    cell.Seen = true;
                    biggest = cell.Value;
                }
            }
        }

        for (int col = 0; col < cols; col++)
        {
            // Top to bottom
            int biggest = -1;
            for (int row = 0; row < rows; row++)
            {
                Cell cell = grid[row, col];
                if (cell.Value > biggest)
                {
                    cell.Seen = true;
                    biggest = cell.Value;
                }
            }

            // Bottom to top
            biggest = -1;
            for (int row = rows - 1; row >= 0; row--)
            {
                Cell cell = grid[row, col];
                if (cell.Value > biggest)
                {
                    cell.Seen = true;
                    biggest = cell.Value;
                }
            }
        }

        // Count all the distinct visible trees
        int totalSeen = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Cell cell = grid[row, col];
                totalSeen += cell.Seen ? 1 : 0;
            }
        }

        return totalSeen;
    }

    public static long Solve2(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        var grid = Parse(lines);

        List<int> scores = new();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                scores.Add(ScenicScore(grid, row, col));
            }
        }

        return scores.Max();
    }

    private static int ScenicScore(Cell[,] grid, int row, int col)
    {
        int targetVal = grid[row, col].Value;

        // Look up
        int rUpScore = 0;
        int r = row - 1;
        while (r >= 0)
        {
            rUpScore++;
            if (grid[r, col].Value >= targetVal)
            {
                break;
            }
            r--;
        }

        // Look down
        int rDownScore = 0;
        r = row + 1;
        while (r < grid.GetLength(0))
        {
            rDownScore++;
            if (grid[r, col].Value >= targetVal)
            {
                break;
            }
            r++;
        }

        // Look left
        int cLeftScore = 0;
        int c = col - 1;
        while (c >= 0)
        {
            cLeftScore++;
            if (grid[row, c].Value >= targetVal)
            {
                break;
            }
            c--;
        }

        // Look right
        int cRightScore = 0;
        c = col + 1;
        while (c < grid.GetLength(1))
        {
            cRightScore++;
            if (grid[row, c].Value >= targetVal)
            {
                break;
            }
            c++;
        }

        return rUpScore * rDownScore * cLeftScore * cRightScore;
    }

    private static Cell[,] Parse(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;

        Cell[,] grid = new Cell[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int val = int.Parse(lines[row][col].ToString());
                grid[row, col] = new Cell { Value = val, Seen = false };
            }
        }

        return grid;
    }

    private class Cell
    {
        public int Value { get; set; }
        public bool Seen { get; set; }
    }
}
