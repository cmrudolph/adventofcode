using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2018_10
{
    public static long Solve1(string[] lines)
    {
        var points = lines.Select(Point.Parse).ToList();

        // Set a reasonable cap in case we mess up our implementation and want to avoid an
        // infinite loop
        for (int i = 0; i < 1000000; i++)
        {
            if (IsSolution(points))
            {
                Print(points);
                return i;
            }

            points.ForEach(p => p.Move());
        }

        return -1;
    }

    public static bool IsSolution(List<Point> points)
    {
        // Assume any valid letter is going to have another character in one of the 8 neighboring
        // cells. Check neighbors and bail early if we find any case of a disconnected character.
        // This indicates that we have not yet reached the solution.
        var lookup = points.Select(p => p.Position).ToHashSet();

        foreach (Point p in points)
        {
            bool neighbor = false;
            XY pos = p.Position;
            neighbor |= lookup.Contains(new XY(pos.X, pos.Y - 1));
            neighbor |= lookup.Contains(new XY(pos.X + 1, pos.Y - 1));
            neighbor |= lookup.Contains(new XY(pos.X + 1, pos.Y));
            neighbor |= lookup.Contains(new XY(pos.X + 1, pos.Y + 1));
            neighbor |= lookup.Contains(new XY(pos.X, pos.Y + 1));
            neighbor |= lookup.Contains(new XY(pos.X - 1, pos.Y + 1));
            neighbor |= lookup.Contains(new XY(pos.X - 1, pos.Y));
            neighbor |= lookup.Contains(new XY(pos.X - 1, pos.Y - 1));

            if (!neighbor)
            {
                return false;
            }
        }

        return true;
    }

    public static void Print(List<Point> points)
    {
        int minX = points.Min(p => p.Position.X);
        int minY = points.Min(p => p.Position.Y);

        // Determine the adjustments needed to allow the output to start at 0, 0
        int adjX = -1 * minX;
        int adjY = -1 * minY;

        int maxX = points.Max(p => p.Position.X) + adjX;
        int maxY = points.Max(p => p.Position.Y) + adjY;

        char[,] grid = new char[maxX + 1, maxY + 1];
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y] = '.';
            }
        }

        foreach (var p in points)
        {
            int x = p.Position.X + adjX;
            int y = p.Position.Y + adjY;

            grid[x, y] = '#';
        }

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                Console.Write(grid[x, y]);
            }

            Console.WriteLine();
        }
    }

    public class Point
    {
        private static readonly Regex Regex = new(@"<(.*), (.*)> velocity=<(.*), (.*)>");

        private XY _position;
        private readonly XY _velocity;

        public static Point Parse(string line)
        {
            Match m = Regex.Match(line);

            int Extract(int idx)
            {
                return int.Parse(m.Groups[idx].Value);
            }

            int x = Extract(1);
            int y = Extract(2);
            int velX = Extract(3);
            int velY = Extract(4);

            return new Point(new XY(x, y), new XY(velX, velY));
        }

        private Point(XY position, XY velocity)
        {
            _position = position;
            _velocity = velocity;
        }

        public XY Position => _position;

        public void Move()
        {
            _position = new(X: _position.X + _velocity.X, Y: _position.Y + _velocity.Y);
        }
    }

    public record XY(int X, int Y);
}
