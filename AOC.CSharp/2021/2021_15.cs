namespace AOC.CSharp;

public static class AOC2021_15
{
    public static long Solve1(string[] lines)
    {
        // Build the map, which is just the array cells (x,y) with the cost of moving there
        Cell[,] map = ParseMap(lines);
        return FindShortestPath(map);
    }

    public static long Solve2(string[] lines)
    {
        // Build the map, which is just the array cells (x,y) with the cost of moving there
        Cell[,] map = ParseMap2(lines);
        return FindShortestPath(map);
    }

    private static long FindShortestPath(Cell[,] map)
    {
        Cell curr = map[0, 0];
        Cell end = map[map.GetLength(0) - 1, map.GetLength(1) - 1];

        // Everything starts off unvisited with an infinite cost (except the start cell, which is accounted
        // for as a special case)
        HashSet<Cell> unvisited = MapToHashSet(map);
        Dictionary<Cell, int> costs = unvisited.ToDictionary(c => c, _ => int.MaxValue);
        costs[curr] = 0;

        // A set of candidates to visit next. Whenever we store a new cost for an unvisited cell we want to consider
        // it as the potential next place to explore. Whenever we visit a node we can remove it from this set since
        // we never need to visit it again. We intend to visit the unvisited cell with the lowest cost, so just
        // having this set is not enough to tell us exactly where to go.
        PriorityQueue<Cell, int> nextQ = new();

        // We need to fully explore the graph. It is not enough to reach the end because there might still be a better
        // solution to discover
        while (unvisited.Any())
        {
            unvisited.Remove(curr);

            // Calculate the distance from the current cell to each of its neighbors. If this cost is less than the
            // cost we already know about, we have found a new shortest path to that cell
            var neighbors = GetNeighbors(map, curr);
            foreach (var n in neighbors.Where(n => unvisited.Contains(n)))
            {
                int newCost = costs[curr] + n.Weight;
                costs[n] = Math.Min(costs[n], newCost);

                nextQ.Enqueue(n, costs[n]);
            }

            // Pick the lowest cost unvisited node to visit next
            if (nextQ.TryDequeue(out curr, out _))
            {
                while (curr != null && !unvisited.Contains(curr))
                {
                    nextQ.TryDequeue(out curr, out _);
                }
            }
        }

        return costs[end];
    }

    private static HashSet<Cell> MapToHashSet(Cell[,] map)
    {
        // Flatten the 2D map into a single HashSet containing all cells
        HashSet<Cell> results = new();
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                results.Add(map[x, y]);
            }
        }

        return results;
    }

    private static Cell[,] ParseMap(string[] lines)
    {
        Cell[,] map = new Cell[lines[0].Length, lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                map[x, y] = new Cell(x, y, line[x] - '0');
            }
        }

        return map;
    }

    private static Cell[,] ParseMap2(string[] lines)
    {
        // Variation on map parsing that reads the input and then scales the map to be 5x larger with a change to the
        // weights of cells in blocks beyond the initial grid. This is for part 2
        int width = lines[0].Length;
        int height = lines.Length;

        Cell[,] map = new Cell[width * 5, height * 5];
        for (int y = 0; y < height; y++)
        {
            string line = lines[y];
            for (int x = 0; x < width; x++)
            {
                map[x, y] = new Cell(x, y, line[x] - '0');
            }
        }

        void SetNewWeight(int x, int y, int comparisonX, int comparisonY)
        {
            if (map[x, y] == null)
            {
                int comparisonWeight = map[comparisonX, comparisonY].Weight;

                // The new weight is one greater than the weight of the corresponding cell (10 to the left or
                // up). The weight wraps back to 1 after 9
                int newWeight = comparisonWeight + 1;
                if (newWeight == 10)
                {
                    newWeight = 1;
                }

                map[x, y] = new Cell(x, y, newWeight);
            }
        }

        for (int y = height; y < height * 5; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (map[x, y] == null)
                {
                    int comparisonY = y - height >= 0 ? y - height : y;
                    SetNewWeight(x, y, x, comparisonY);
                }
            }
        }

        for (int y = 0; y < height * 5; y++)
        {
            for (int x = 0; x < width * 5; x++)
            {
                if (map[x, y] == null)
                {
                    int comparisonX = x - width >= 0 ? x - width : x;
                    SetNewWeight(x, y, comparisonX, y);
                }
            }
        }

        return map;
    }

    private static List<Cell> GetNeighbors(Cell[,] map, Cell curr)
    {
        List<Cell> results = new();

        List<Tuple<int, int>> neighbors =
            new()
            {
                Tuple.Create(curr.X, curr.Y - 1), // N
                Tuple.Create(curr.X + 1, curr.Y), // E
                Tuple.Create(curr.X, curr.Y + 1), // S
                Tuple.Create(curr.X - 1, curr.Y), // W
            };

        foreach (Tuple<int, int> neighbor in neighbors)
        {
            int x = neighbor.Item1;
            int y = neighbor.Item2;
            if (x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0))
            {
                results.Add(map[x, y]);
            }
        }

        return results;
    }

    private record Cell(int X, int Y, int Weight);
}
