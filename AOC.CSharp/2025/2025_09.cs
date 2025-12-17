namespace AOC.CSharp;

public static class AOC2025_09
{
    public static long Solve1(string[] lines)
    {
        List<Point> points = new();

        foreach (string line in lines)
        {
            string[] splits = line.Split(',');
            points.Add(new(long.Parse(splits[0]), long.Parse(splits[1])));
        }

        long best = 0;

        for (int i = 0; i < points.Count; i++)
        {
            Point p1 = points[i];
            for (int j = i; j < points.Count; j++)
            {
                Point p2 = points[j];
                long xDiff = Math.Abs(p2.X - p1.X) + 1;
                long yDiff = Math.Abs(p2.Y - p1.Y) + 1;
                long area = xDiff * yDiff;

                Console.WriteLine("{0} | {1} | {2}", p1, p2, area);
                best = Math.Max(best, area);
            }
        }

        return best;
    }

    public static long Solve2(string[] lines)
    {
        return -1;
    }

    private record Point(long X, long Y);
}
