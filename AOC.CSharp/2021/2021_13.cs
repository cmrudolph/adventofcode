namespace AOC.CSharp;

public static class AOC2021_13
{
    public static long Solve1(string[] lines)
    {
        (Map map, List<char> folds) = Parse(lines);
        DoFold(map, folds[0]);
        return CountMarked(map);
    }

    public static long Solve2(string[] lines)
    {
        (Map map, List<char> folds) = Parse(lines);
        foreach (char fold in folds)
        {
            DoFold(map, fold);
        }

        // Run and look at the letters in the output text
        PrintMap(map);
        return 0;
    }

    private static (Map, List<char>) Parse(string[] lines)
    {
        List<Point> points = new();

        string line = lines[0];
        int lineNum = 0;
        while (!string.IsNullOrWhiteSpace(line))
        {
            string[] splits = line.Split(',');
            points.Add(new Point(int.Parse(splits[0]), int.Parse(splits[1])));
            lineNum++;
            line = lines[lineNum];
        }

        int maxX = points.Select(p => p.X).Max();
        int maxY = points.Select(p => p.Y).Max();
        HashSet<int> lookup = points.Select(p => p.X << 16 | p.Y).ToHashSet();

        bool[,] marked = new bool[maxX + 1, maxY + 1];

        for (int x = 0; x <= maxX; x++)
        {
            for (int y = 0; y <= maxY; y++)
            {
                bool isMarked = lookup.Contains(x << 16 | y);
                marked[x, y] = isMarked;
            }
        }

        List<char> folds = new();
        for (lineNum += 1; lineNum < lines.Length; lineNum++)
        {
            string foldInfo = lines[lineNum].Replace("fold along ", "");
            string[] splits = foldInfo.Split('=');
            folds.Add(splits[0][0]);
        }

        return (new Map(marked, maxX + 1, maxY + 1), folds);
    }

    private static void DoFold(Map map, char along)
    {
        if (along == 'x')
        {
            for (int x = 0; x < map.Width / 2; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    bool m1 = map.Marked[x, y];
                    bool m2 = map.Marked[map.Width - x - 1, y];
                    map.Marked[x, y] = m1 || m2;
                }
            }
            map.Width /= 2;
        }
        else
        {
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height / 2; y++)
                {
                    bool m1 = map.Marked[x, y];
                    bool m2 = map.Marked[x, map.Height - y - 1];
                    map.Marked[x, y] = m1 || m2;
                }
            }
            map.Height /= 2;
        }
    }

    private static int CountMarked(Map map)
    {
        int total = 0;
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                total += map.Marked[x, y] ? 1 : 0;
            }
        }

        return total;
    }

    private static void PrintMap(Map map)
    {
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write(map.Marked[x, y] ? '#' : '.');
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private class Map
    {
        public Map(bool[,] marked, int width, int height)
        {
            Marked = marked;
            Width = width;
            Height = height;
        }

        public bool[,] Marked { get; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    private record Point(int X, int Y);
}
