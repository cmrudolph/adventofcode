namespace AOC.CSharp;

public static class AOC2021_09
{
    public static long Solve1(string[] lines)
    {
        int[,] map = ParseMap(lines);
        List<Point> lowSpots = FindLowSpots(map);
        return lowSpots.Sum(spot => map[spot.X, spot.Y] + 1);
    }

    public static long Solve2(string[] lines)
    {
        int[,] map = ParseMap(lines);
        List<Point> lowSpots = FindLowSpots(map);

        List<int> basinSizes = new();
        foreach (Point low in lowSpots)
        {
            HashSet<Point> visited = new();
            Queue<Point> toVisit = new();
            toVisit.Enqueue(low);

            int basinSize = 0;
            while (toVisit.Count > 0)
            {
                basinSize++;
                var curr = toVisit.Dequeue();
                var currHeight = map[curr.X, curr.Y];
                visited.Add(curr);
                var neighbors = FindNeighbors(map, curr);
                foreach (var neighbor in neighbors)
                {
                    int neighborHeight = map[neighbor.X, neighbor.Y];
                    if (neighborHeight < 9 && neighborHeight > currHeight && !visited.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            basinSizes.Add(basinSize);
        }

        return basinSizes.OrderByDescending(bs => bs).Take(3).Aggregate(1, (acc, bs) => acc * bs);
    }

    private static int[,] ParseMap(string[] lines)
    {
        int[,] map = new int[lines[0].Length, lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                map[j, i] = line[j] - '0';
            }
        }

        return map;
    }

    private static List<Point> FindLowSpots(int[,] map)
    {
        List<Point> lowSpots = new();
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                var neighborHeights = FindNeighbors(map, new Point(i, j)).Select(n => map[n.X, n.Y]);
                if (neighborHeights.All(nh => nh > map[i, j]))
                {
                    lowSpots.Add(new Point(i, j));
                }
            }
        }

        return lowSpots;
    }

    private static List<Point> FindNeighbors(int[,] map, Point p)
    {
        List<Point> results = new();

        if (p.X > 0)
            results.Add(p with { X = p.X - 1, Y = p.Y });
        if (p.Y > 0)
            results.Add(p with { X = p.X, Y = p.Y - 1 });
        if (p.X < map.GetLength(0) - 1)
            results.Add(p with { X = p.X + 1, Y = p.Y });
        if (p.Y < map.GetLength(1) - 1)
            results.Add(p with { X = p.X, Y = p.Y + 1 });

        return results;
    }

    private record Point(int X, int Y);
}
