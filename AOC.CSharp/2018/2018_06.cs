namespace AOC.CSharp;

public static class AOC2018_06
{
    public static long Solve1(string[] lines)
    {
        List<Point> points = lines.Select(Parse).ToList();
        Bounds bounds = FindBounds(points);

        int width = bounds.MaxX + 1;
        int height = bounds.MaxY + 1;

        Point[,] grid = new Point[width, height];
        Dictionary<int, int> pointCounts = points.Select(p => p.Idx).ToDictionary(idx => idx, _ => 0);
        HashSet<Point> candidatePoints = points.ToHashSet();

        for (int x = -1; x <= width; x++)
        {
            for (int y = -1; y <= height; y++)
            {
                Point closest = ClosestTo(points, x, y);
                if (closest != null)
                {
                    if (bounds.IsOutside(x, y))
                    {
                        candidatePoints.Remove(closest);
                    }
                    else
                    {
                        grid[x, y] = closest;
                        pointCounts[closest.Idx]++;
                    }
                }
            }
        }

        HashSet<int> validIndexes = candidatePoints.Select(p => p.Idx).ToHashSet();
        int resultArea = pointCounts.Where(kvp => validIndexes.Contains(kvp.Key))
            .OrderByDescending(kvp => kvp.Value)
            .First()
            .Value;

        return resultArea;
    }

    public static long Solve2(string[] lines, int threshold)
    {
        List<Point> points = lines.Select(Parse).ToList();
        Bounds bounds = FindBounds(points);

        long result = 0;

        for (int x = 0; x <= bounds.MaxX; x++)
        {
            for (int y = 0; y < bounds.MaxY; y++)
            {
                int manhattanTotal = 0;

                foreach (Point p in points)
                {
                    manhattanTotal += Manhattan(p.X, p.Y, x, y);
                    if (manhattanTotal >= threshold)
                    {
                        break;
                    }
                }

                if (manhattanTotal < threshold)
                {
                    result++;
                }
            }
        }

        return result;
    }

    private static Point ClosestTo(List<Point> points, int x, int y)
    {
        int minDist = int.MaxValue;
        Point best = null;
        foreach (Point p in points)
        {
            int dist = Manhattan(p.X, p.Y, x, y);
            if (dist == minDist)
            {
                best = null;
            }
            if (dist < minDist)
            {
                best = p;
                minDist = dist;
            }
        }

        return best;
    }

    private static int Manhattan(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }

    private static Point Parse(string line, int idx)
    {
        string[] splits = line.Split(",");
        return new Point(idx, int.Parse(splits[0]), int.Parse(splits[1]));
    }

    private static Bounds FindBounds(List<Point> points)
    {
        int minX = points.Min(p => p.X);
        int maxX = points.Max(p => p.X);
        int minY = points.Min(p => p.Y);
        int maxY = points.Max(p => p.Y);

        return new Bounds(minX, maxX, minY, maxY);
    }

    private record Point(int Idx, int X, int Y);

    private record Bounds(int MinX, int MaxX, int MinY, int MaxY)
    {
        public bool IsOutside(int x, int y)
        {
            return x < MinX || x > MaxX || y < MinY || y > MaxY;
        }
    }
}