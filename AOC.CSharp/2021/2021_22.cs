using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2021_22
{
    public static long Solve1(string[] lines)
    {
        int[,,] grid = new int[101, 101, 101];

        Change[] changes = lines.Select(Parse).ToArray();
        foreach (Change c in changes)
        {
            int minX = Math.Max(c.MinX, 0);
            int maxX = Math.Min(c.MaxX, 100);
            int minY = Math.Max(c.MinY, 0);
            int maxY = Math.Min(c.MaxY, 100);
            int minZ = Math.Max(c.MinZ, 0);
            int maxZ = Math.Min(c.MaxZ, 100);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    for (int z = minZ; z <= maxZ; z++)
                    {
                        grid[x, y, z] = c.On ? 1 : 0;
                    }
                }
            }
        }

        int endX = grid.GetLength(0);
        int endY = grid.GetLength(1);
        int endZ = grid.GetLength(2);

        int onCount = 0;
        for (int x = 0; x < endX; x++)
        {
            for (int y = 0; y < endY; y++)
            {
                for (int z = 0; z < endZ; z++)
                {
                    onCount += grid[x, y, z];
                }
            }
        }

        return onCount;
    }

    public static long Solve2(string[] lines)
    {
        return 0L;
    }

    private static Change Parse(string line)
    {
        Regex regex = new(@"(\w+) x=(-?\d+)\.\.(-?\d+),y=(-?\d+)\.\.(-?\d+),z=(-?\d+)\.\.(-?\d+)");
        Match m = regex.Match(line);

        bool on = m.Groups[1].Value == "on";
        int minX = int.Parse(m.Groups[2].Value) + 50;
        int maxX = int.Parse(m.Groups[3].Value) + 50;
        int minY = int.Parse(m.Groups[4].Value) + 50;
        int maxY = int.Parse(m.Groups[5].Value) + 50;
        int minZ = int.Parse(m.Groups[6].Value) + 50;
        int maxZ = int.Parse(m.Groups[7].Value) + 50;

        return new Change(on, minX, maxX, minY, maxY, minZ, maxZ);
    }

    private record Change(bool On, int MinX, int MaxX, int MinY, int MaxY, int MinZ, int MaxZ);
}
