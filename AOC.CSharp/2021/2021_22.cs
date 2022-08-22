using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2021_22
{
    public static long Solve1(string[] lines)
    {
        int[,,] grid = new int[101, 101, 101];
        
        Change[] changes = lines.Select(Parse1).Where(x => x != null).ToArray();
        foreach (Change c in changes)
        {
            long minX = Math.Max(c.Cuboid.MinX, 0);
            long maxX = Math.Min(c.Cuboid.MaxX, 100);
            long minY = Math.Max(c.Cuboid.MinY, 0);
            long maxY = Math.Min(c.Cuboid.MaxY, 100);
            long minZ = Math.Max(c.Cuboid.MinZ, 0);
            long maxZ = Math.Min(c.Cuboid.MaxZ, 100);
        
            for (long x = minX; x <= maxX; x++)
            {
                for (long y = minY; y <= maxY; y++)
                {
                    for (long z = minZ; z <= maxZ; z++)
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
        return Solve(lines);
    }

    public static long Solve(string[] lines)
    {
        Change[] changes = lines.Select(Parse2).ToArray();

        Dictionary<Cuboid, long> state = new();
        foreach (Change newChange in changes)
        {
            Dictionary<Cuboid, long> newState = new();
            
            foreach (Cuboid known in state.Keys)
            {
                Cuboid intersection = newChange.Cuboid.IntersectWith(known);
                if (intersection != null)
                {
                    if (state.TryGetValue(known, out long intExisting))
                    {
                        if (!newState.ContainsKey(intersection))
                        {
                            long starterVal = state.TryGetValue(intersection, out long st) ? st : 0;
                            newState.Add(intersection, starterVal);
                        }

                        newState[intersection] -= intExisting;
                    }
                    else
                    {
                        if (!newState.ContainsKey(intersection))
                        {
                            newState.Add(intersection, 0);
                        }

                        newState[intersection] -= 1;
                    }
                }
            }

            if (newChange.On)
            {
                if (!newState.ContainsKey(newChange.Cuboid))
                {
                    newState.Add(newChange.Cuboid, 0);
                }

                newState[newChange.Cuboid] += 1;
            }

            foreach (var kvp in newState)
            {
                state[kvp.Key] = kvp.Value;
            }
        }

        long result = 0;
        foreach (var s in state)
        {
            result += (s.Key.Volume * s.Value);
            Console.WriteLine("{0} --> {1} {2}", result, s.Key.Volume, s.Value);
        }

        return result;
    }
    
    private static Change Parse1(string line)
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

        if (minX < 0 || maxX > 100 || minY < 0 || maxY > 100 || minZ < 0 || maxZ > 100)
        {
            return null;
        }

        Cuboid cuboid = new(minX, maxX, minY, maxY, minZ, maxZ);
        return new Change(on, cuboid);
    }

    private static Change Parse2(string line)
    {
        Regex regex = new(@"(\w+) x=(-?\d+)\.\.(-?\d+),y=(-?\d+)\.\.(-?\d+),z=(-?\d+)\.\.(-?\d+)");
        Match m = regex.Match(line);

        bool on = m.Groups[1].Value == "on";
        int minX = int.Parse(m.Groups[2].Value);
        int maxX = int.Parse(m.Groups[3].Value);
        int minY = int.Parse(m.Groups[4].Value);
        int maxY = int.Parse(m.Groups[5].Value);
        int minZ = int.Parse(m.Groups[6].Value);
        int maxZ = int.Parse(m.Groups[7].Value);

        Cuboid cuboid = new(minX, maxX, minY, maxY, minZ, maxZ);
        return new Change(on, cuboid);
    }

    private record Change(bool On, Cuboid Cuboid);
    
    public record Cuboid(long MinX, long MaxX, long MinY, long MaxY, long MinZ, long MaxZ)
    {
        public long Volume => (MaxX - MinX + 1) * (MaxY - MinY + 1) * (MaxZ - MinZ + 1);

        public Cuboid IntersectWith(Cuboid c2)
        {
            long smallerMaxX = Math.Min(MaxX, c2.MaxX);
            long biggerMinX = Math.Max(MinX, c2.MinX);
            if (smallerMaxX < biggerMinX)
            {
                return null;
            }
            
            long smallerMaxY = Math.Min(MaxY, c2.MaxY);
            long biggerMinY = Math.Max(MinY, c2.MinY);
            if (smallerMaxY < biggerMinY)
            {
                return null;
            }
            
            long smallerMaxZ = Math.Min(MaxZ, c2.MaxZ);
            long biggerMinZ = Math.Max(MinZ, c2.MinZ);
            if (smallerMaxZ < biggerMinZ)
            {
                return null;
            }

            return new(biggerMinX, smallerMaxX, biggerMinY, smallerMaxY, biggerMinZ, smallerMaxZ);
        }
    }
}
