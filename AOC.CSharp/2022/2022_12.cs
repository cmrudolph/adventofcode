namespace AOC.CSharp;

public static class AOC2022_12
{
    public static long Solve1(string[] lines)
    {
        var grid = Parse(lines);
        GridCell start = null;
        bool done = false;

        // Part 1 has a single start location
        for (int row = 0; !done && row < grid.GetLength(0); row++)
        {
            for (int col = 0; !done && col < grid.GetLength(1); col++)
            {
                if (grid[row, col].Char == 'S')
                {
                    start = grid[row, col];
                    done = true;
                }
            }
        }
        return FindShortestPath(start, grid, long.MaxValue);
    }

    public static long Solve2(string[] lines)
    {
        var grid = Parse(lines);
        List<GridCell> starts = new();

        // Part 2 considers multiple start locations
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[row, col].Char is 'a' or 'S')
                {
                    starts.Add(grid[row, col]);
                }
            }
        }

        long bestSoFar = long.MaxValue;
        foreach (GridCell start in starts)
        {
            long result = FindShortestPath(start, grid, bestSoFar);
            if (result < bestSoFar)
            {
                bestSoFar = result;
            }
        }

        return bestSoFar;
    }

    private static long FindShortestPath(GridCell start, GridCell[,] grid, long bestSoFar)
    {
        Dictionary<Location, long> distances = new();
        Queue<Location> q = new();

        distances.Add(start.Loc, 0);
        q.Enqueue(start.Loc);

        while (q.Any())
        {
            Location loc = q.Dequeue();
            var possible = FindPossibleMoves(grid, loc);
            long locDist = distances[loc];

            foreach (var p in possible)
            {
                long dist;

                bool seen = distances.TryGetValue(p, out dist);
                if (!seen)
                {
                    // Visit any node that we have not yet added to the distance lookup (not seen yet)
                    dist = locDist + 1;
                    distances.Add(p, dist);
                    q.Enqueue(p);
                }

                if (dist >= bestSoFar)
                {
                    // Short circuit if the route is already too expensive
                    return bestSoFar;
                }

                GridCell pCell = grid[p.Row, p.Col];
                if (pCell.Char == 'E')
                {
                    // Check for success. The first time we reach this will be the optimal route since we are
                    // traversing things in a breadth-first fashion
                    return dist;
                }
            }
        }

        return long.MaxValue;
    }

    private static List<Location> FindPossibleMoves(GridCell[,] grid, Location curr)
    {
        List<Location> results = new();

        int currHeight = grid[curr.Row, curr.Col].Height;

        Location left = curr with { Row = curr.Row - 1 };
        if (curr.Row > 0 && grid[left.Row, left.Col].Height <= currHeight + 1)
        {
            results.Add(left);
        }

        Location up = curr with { Col = curr.Col - 1 };
        if (curr.Col > 0 && grid[up.Row, up.Col].Height <= currHeight + 1)
        {
            results.Add(up);
        }

        Location right = curr with { Col = curr.Col + 1 };
        if (curr.Col < grid.GetLength(1) - 1 && grid[right.Row, right.Col].Height <= currHeight + 1)
        {
            results.Add(right);
        }

        Location down = curr with { Row = curr.Row + 1 };
        if (curr.Row < grid.GetLength(0) - 1 && grid[down.Row, down.Col].Height <= currHeight + 1)
        {
            results.Add(down);
        }

        return results;
    }


    private static GridCell[,] Parse(string[] lines)
    {
        int height = lines.Length;
        int width = lines[0].Length;
        GridCell[,] grid = new GridCell[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Location loc = new(row, col);
                char c = lines[row][col];
                if (c == 'S')
                {
                    // Start has a special elevation
                    grid[row, col] = new GridCell(loc, c, 'a');
                }
                else if (c == 'E')
                {
                    // End has a special elevation
                    grid[row, col] = new GridCell(loc, c, 'z');
                }
                else
                {
                    grid[row, col] = new GridCell(loc, c, c);
                }
            }
        }

        return grid;
    }

    private record Location(int Row, int Col);

    private record GridCell(Location Loc, char Char, int Height);
}
