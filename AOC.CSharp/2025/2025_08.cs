namespace AOC.CSharp;

public static class AOC2025_08
{
    public static long Solve1(string[] lines)
    {
        List<Point> allPoints = new();
        Dictionary<Point, int> groups = new();
        int nextGroupNum = 1;

        foreach (string line in lines)
        {
            string[] splits = line.Split(",");
            int x = int.Parse(splits[0]);
            int y = int.Parse(splits[1]);
            int z = int.Parse(splits[2]);

            Point pt = new(x, y, z);
            allPoints.Add(pt);
            groups.Add(pt, nextGroupNum);
            nextGroupNum++;
        }

        List<Pair> pairs = new();

        for (int i = 0; i < allPoints.Count; i++)
        {
            Point p1 = allPoints[i];

            for (int j = i; j < allPoints.Count; j++)
            {
                Point p2 = allPoints[j];
                double dist = Dist(p1, p2);
                if (p1 != p2)
                {
                    Pair pair = new(p1, p2, dist);
                    pairs.Add(pair);
                }
            }
        }

        pairs = pairs.OrderBy(x => x.Dist).ToList();

        int connections = 0;
        int idx = 0;
        int maxConnections = allPoints.Count == 20 ? 10 : 1000;

        while (connections < maxConnections)
        {
            Pair pair = pairs[idx];
            int p1GroupNum = groups[pair.P1];
            int p2GroupNum = groups[pair.P2];

            int minGroupNum = Math.Min(p1GroupNum, p2GroupNum);
            int maxGroupNum = Math.Max(p1GroupNum, p2GroupNum);

            foreach (var kvp in groups)
            {
                if (kvp.Value == maxGroupNum)
                {
                    groups[kvp.Key] = minGroupNum;
                }
            }

            groups[pair.P1] = minGroupNum;
            groups[pair.P2] = minGroupNum;

            connections++;

            idx++;
        }

        Dictionary<int, int> groupCounts = new();
        foreach (var kvp in groups)
        {
            groupCounts.TryAdd(kvp.Value, 0);
            groupCounts[kvp.Value] += 1;
        }

        long result = 1;
        List<int> toMultiply = groupCounts.Values.OrderByDescending(x => x).Take(3).ToList();
        foreach (int count in toMultiply)
        {
            result *= count;
        }

        return result;
    }

    public static long Solve2(string[] lines)
    {
        List<Point> allPoints = new();
        Dictionary<Point, int> groups = new();
        int nextGroupNum = 1;

        foreach (string line in lines)
        {
            string[] splits = line.Split(",");
            int x = int.Parse(splits[0]);
            int y = int.Parse(splits[1]);
            int z = int.Parse(splits[2]);

            Point pt = new(x, y, z);
            allPoints.Add(pt);
            groups.Add(pt, nextGroupNum);
            nextGroupNum++;
        }

        List<Pair> pairs = new();

        for (int i = 0; i < allPoints.Count; i++)
        {
            Point p1 = allPoints[i];

            for (int j = i; j < allPoints.Count; j++)
            {
                Point p2 = allPoints[j];
                double dist = Dist(p1, p2);
                if (p1 != p2)
                {
                    Pair pair = new(p1, p2, dist);
                    pairs.Add(pair);
                }
            }
        }

        pairs = pairs.OrderBy(x => x.Dist).ToList();

        int idx = 0;

        Point lastP1 = null;
        Point lastP2 = null;
        int largestGroup = 0;

        while (largestGroup != allPoints.Count)
        {
            Pair pair = pairs[idx];
            int p1GroupNum = groups[pair.P1];
            int p2GroupNum = groups[pair.P2];

            int minGroupNum = Math.Min(p1GroupNum, p2GroupNum);
            int maxGroupNum = Math.Max(p1GroupNum, p2GroupNum);

            foreach (var kvp in groups)
            {
                if (kvp.Value == maxGroupNum)
                {
                    groups[kvp.Key] = minGroupNum;
                }
            }

            groups[pair.P1] = minGroupNum;
            groups[pair.P2] = minGroupNum;

            lastP1 = pair.P1;
            lastP2 = pair.P2;

            Dictionary<int, int> groupCounts = new();
            foreach (var kvp in groups)
            {
                groupCounts.TryAdd(kvp.Value, 0);
                groupCounts[kvp.Value] += 1;
            }

            largestGroup = groupCounts.OrderByDescending(x => x.Value).First().Value;

            idx++;
        }

        return lastP1.X * lastP2.X;
    }

    private record Pair(Point P1, Point P2, double Dist);

    private static double Dist(Point p1, Point p2)
    {
        long xDiff = p1.X - p2.X;
        long yDiff = p1.Y - p2.Y;
        long zDiff = p1.Z - p2.Z;

        return Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff) + (zDiff * zDiff));
    }

    private record Point(int X, int Y, int Z);
}
