namespace AOC.CSharp;

public static class AOC2023_21
{
    public static long Solve1(string[] lines)
    {
        int height = lines.Length;
        int width = lines[0].Length;

        char[,] grid = new char[height, width];

        XY start = null;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char ch = lines[y][x];
                grid[y, x] = ch;
                if (ch == 'S')
                {
                    start = new(x, y);
                }
            }
        }

        XY[] FindOptions(XY xy)
        {
            List<XY> candidates =
                new()
                {
                    xy with
                    {
                        Y = xy.Y - 1
                    },
                    xy with
                    {
                        Y = xy.Y + 1
                    },
                    xy with
                    {
                        X = xy.X - 1
                    },
                    xy with
                    {
                        X = xy.X + 1
                    },
                };

            for (int i = candidates.Count - 1; i >= 0; i--)
            {
                XY cand = candidates[i];
                if (cand.Y < 0 || cand.Y == height || cand.X < 0 || cand.X == width)
                {
                    candidates.RemoveAt(i);
                }
                else if (grid[cand.Y, cand.X] == '#')
                {
                    candidates.RemoveAt(i);
                }
            }

            return candidates.ToArray();
        }

        HashSet<XY> points = new();
        points.Add(start);
        for (int i = 0; i < 64; i++)
        {
            HashSet<XY> newPoints = new();
            foreach (XY point in points)
            {
                var opts = FindOptions(point);
                foreach (var opt in opts)
                {
                    newPoints.Add(opt);
                }
            }

            points = newPoints;
        }

        return points.Count;
    }

    public static long Solve2(string[] lines)
    {
        int height = lines.Length;
        int width = lines[0].Length;

        char[,] grid = new char[height, width];

        XY start = null;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char ch = lines[y][x];
                grid[y, x] = ch;
                if (ch == 'S')
                {
                    start = new((width * 100000) + x, (height * 100000 + y));
                }
            }
        }

        XY[] FindOptions(XY xy)
        {
            List<XY> candidates =
                new()
                {
                    xy with
                    {
                        Y = xy.Y - 1
                    },
                    xy with
                    {
                        Y = xy.Y + 1
                    },
                    xy with
                    {
                        X = xy.X - 1
                    },
                    xy with
                    {
                        X = xy.X + 1
                    },
                };

            for (int i = candidates.Count - 1; i >= 0; i--)
            {
                XY cand = candidates[i];
                int lookupX = cand.X % width;
                int lookupY = cand.Y % height;
                if (grid[lookupY, lookupX] == '#')
                {
                    candidates.RemoveAt(i);
                }
            }

            return candidates.ToArray();
        }

        HashSet<XY> points = new();
        points.Add(start);

        void Print(int iteration)
        {
            int minY = points.Min(x => x.Y);
            int maxY = points.Max(x => x.Y);
            int minX = points.Min(x => x.X);
            int maxX = points.Max(x => x.X);

            using (StreamWriter sw = new("C:\\Temp\\Day21_" + iteration + ".txt"))
            {
                for (int y = minY; y <= maxY; y++)
                {
                    for (int x = minX; x <= maxX; x++)
                    {
                        XY xy = new(x, y);
                        if (points.Contains(xy))
                        {
                            sw.Write("O");
                        }
                        else
                        {
                            sw.Write(".");
                        }
                    }

                    sw.WriteLine();
                }
            }
        }

        for (int i = 0; i < 1000; i++)
        {
            HashSet<XY> newPoints = new();
            foreach (XY point in points)
            {
                var opts = FindOptions(point);
                foreach (var opt in opts)
                {
                    newPoints.Add(opt);
                }
            }

            Console.WriteLine("{0}, {1}", i + 1, newPoints.Count);

            points = newPoints;

            Print(i + 1);
        }

        return points.Count;
    }

    private record XY(int X, int Y);
}
