namespace AOC.CSharp;

public static class AOC2017_14
{
    private const int Set = -1;
    private const int NotSet = 0;

    public static long Solve1(string[] lines)
    {
        int[,] map = BuildMap(lines[0]);
        return CountSetCells(map);
    }

    public static long Solve2(string[] lines)
    {
        int[,] map = BuildMap(lines[0]);
        return CountRegions(map);
    }

    private static long CountRegions(int[,] map)
    {
        int currRegion = 1;
        int[,] copy = new int[128, 128];
        Array.Copy(map, copy, map.Length);

        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 128; y++)
            {
                Queue<XY> q = new();
                if (copy[x, y] == Set)
                {
                    q.Enqueue(new(x, y));
                    while (q.Count > 0)
                    {
                        XY deq = q.Dequeue();
                        if (copy[deq.X, deq.Y] == Set)
                        {
                            copy[deq.X, deq.Y] = currRegion;
                            List<XY> neighbors = GetNeighbors(deq.X, deq.Y);
                            neighbors.ForEach(n => q.Enqueue(n));
                        }
                    }

                    currRegion++;
                }
            }
        }

        return currRegion - 1;
    }

    private static long CountSetCells(int[,] map)
    {
        long count = 0;

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                count += map[x, y] != NotSet ? 1 : 0;
            }
        }

        return count;
    }

    private static int[,] BuildMap(string key)
    {
        int[,] map = new int[128, 128];

        for (int y = 0; y < 128; y++)
        {
            string rowKey = key + "-" + y;
            string hash = AOC2017_10.CalculateKnotHash(rowKey);
            byte[] bytes = Convert.FromHexString(hash);
            for (int j = 0; j < bytes.Length; j++)
            {
                byte b = bytes[j];
                for (int k = 0; k <= 7; k++)
                {
                    int mask = 1 << (7 - k);
                    int x = (j * 8) + k;
                    map[x, y] = (b & mask) > 0 ? Set : NotSet;
                }
            }
        }

        return map;
    }

    private static List<XY> GetNeighbors(int x, int y)
    {
        List<XY> results = new();
        if (x > 0)
        {
            results.Add(new(x - 1, y));
        }

        if (x < 127)
        {
            results.Add(new(x + 1, y));
        }

        if (y > 0)
        {
            results.Add(new(x, y - 1));
        }

        if (y < 127)
        {
            results.Add(new(x, y + 1));
        }

        return results;
    }

    private record XY(int X, int Y);
}
