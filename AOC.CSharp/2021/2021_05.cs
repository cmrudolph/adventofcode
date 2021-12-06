using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2021_05
{
    private static Regex Regex = new(@"(\d+),(\d+) -\> (\d+),(\d+)");

    public static long Solve1(string[] lines)
    {
        return Solve(lines, false);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, true);
    }

    private static long Solve(string[] lines, bool doDiagonal)
    {
        var pairs = lines.Select(Parse).ToList();
        int[,] grid = new int[1000, 1000];

        foreach (var pair in pairs.Where(p => p.IsHorizontal))
        {
            int y = pair.Point1.Y;
            for (int x = pair.Point1.X; x <= pair.Point2.X; x++)
            {
                grid[x, y]++;
            }
        }
        foreach (var pair in pairs.Where(p => p.IsVertical))
        {
            int x = pair.Point1.X;
            for (int y = pair.Point1.Y; y <= pair.Point2.Y; y++)
            {
                grid[x, y]++;
            }
        }

        if (doDiagonal)
        {
            foreach (var pair in pairs.Where(p => p.IsDiagnoal))
            {
                int y = pair.Point1.Y;
                int yChange = pair.Point2.Y > pair.Point1.Y ? 1 : -1;

                for (int x = pair.Point1.X; x <= pair.Point2.X; x++)
                {
                    grid[x, y]++;
                    y += yChange;
                }
            }
        }

        return CountGreaterThan2(grid);
    }

    private static Pair Parse(string line)
    {
        Match m = Regex.Match(line);

        int a = int.Parse(m.Groups[1].Value);
        int b = int.Parse(m.Groups[2].Value);
        int c = int.Parse(m.Groups[3].Value);
        int d = int.Parse(m.Groups[4].Value);

        Point p1 = new Point(a, b);
        Point p2 = new Point(c, d);
        if (p1.X < p2.X)
        {
            return new Pair(p1, p2);
        }
        else if (p2.X < p1.X)
        {
            return new Pair(p2, p1);
        }
        else if (p1.Y < p2.Y)
        {
            return new Pair(p1, p2);
        }
        return new Pair(p2, p1);
    }

    private static int CountGreaterThan2(int[,] grid)
    {
        int count = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                count += grid[i, j] >= 2 ? 1 : 0;
            }
        }
        return count;
    }

    private record Pair(Point Point1, Point Point2)
    {
        public bool IsHorizontal => Point1.Y == Point2.Y;
        public bool IsVertical => Point1.X == Point2.X;
        public bool IsDiagnoal => !IsHorizontal && !IsVertical;
        public bool IsHorizontalOrVertical => IsHorizontal || IsVertical;
    }

    private record Point(int X, int Y);
}
