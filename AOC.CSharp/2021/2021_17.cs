using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2021_17
{
    public static long Solve1(string[] lines)
    {
        // The first case is easy. Assume we can find an x to get us into the target area. We know the object will
        // pass through the y = 0 line and we can set up the velocity to ensure it lands on the bottom row of the
        // target area
        Target t = Parse(lines);
        return Enumerable.Range(1, Math.Abs(t.MinY) - 1).Sum();
    }

    public static long Solve2(string[] lines)
    {
        Target t = Parse(lines);
        int minSearchX = 1;
        int maxSearchX = t.MaxX;
        int minSearchY = t.MinY;
        int maxSearchY = Math.Abs(t.MinY);

        List<Tuple<int, int>> validCases = new();

        // The problem is easily brute forced. We can limit the search space to a reasonable set of values that
        // can be searched exhaustively in a reasonable amount of time.
        for (int x = minSearchX; x <= maxSearchX; x++)
        {
            for (int y = minSearchY; y <= maxSearchY; y++)
            {
                bool works = Works(t, x, y);
                if (works)
                {
                    validCases.Add(Tuple.Create(x, y));
                }
            }
        }

        return validCases.Count;
    }

    private static bool Works(Target target, int initialVelocityX, int initialVelocityY)
    {
        int velocityX = initialVelocityX;
        int velocityY = initialVelocityY;
        int x = 0;
        int y = 0;

        // Simulate the path of the object and see if it ends up in the target area. Stop looking when we are sure
        // it will end up outside
        while (x <= target.MaxX && y >= target.MinY)
        {
            x += velocityX;
            y += velocityY;

            if (IsInTarget(target, x, y))
            {
                return true;
            }

            velocityX = velocityX == 0 ? 0 : velocityX - 1;
            velocityY--;
        }

        return false;
    }

    private static bool IsInTarget(Target target, int x, int y)
    {
        return (x >= target.MinX && x<= target.MaxX) && (y >= target.MinY && y <= target.MaxY);
    }

    private static Target Parse(string[] lines)
    {
        Match m = Regex.Match(lines[0], @"x=(.*)\.\.(.*), y=(.*)\.\.(.*)");
        int minX = int.Parse(m.Groups[1].Value);
        int maxX = int.Parse(m.Groups[2].Value);
        int minY = int.Parse(m.Groups[3].Value);
        int maxY = int.Parse(m.Groups[4].Value);

        return new Target(minX, maxX, minY, maxY);
    }

    private record Target(int MinX, int MaxX, int MinY, int MaxY);
}
