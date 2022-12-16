using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2022_15
{
    private static Regex Re = new(@"x=(.*), y=(.*):.* x=(.*), y=(.*)");

    public static long Solve1(string[] lines, int searchRow)
    {
        var parsed = lines.Select(Parse).ToList();
        var sensors = parsed.Select(p => p.Item1).ToList();
        var beacons = parsed.Select(p => p.Item2).ToList();
        int smallestX = sensors.Select(s => s.P.X - s.Range).Min();
        int biggestX = sensors.Select(s => s.P.X + s.Range).Max();

        int cannotBeBeaconCount = 0;

        HashSet<Point> beaconLookup = beacons.ToHashSet();

        for (int x = smallestX; x < biggestX; x++)
        {
            // We only need to scan across a single row, checking all potential X values
            Point searchPoint = new(x, searchRow);
            bool nonBeaconSpotSeenBySensor = false;

            for (int i = 0; i < sensors.Count && !nonBeaconSpotSeenBySensor; i++)
            {
                Sensor s = sensors[i];

                if (Manhattan(s.P, searchPoint) <= s.Range)
                {
                    if (!beaconLookup.Contains(searchPoint))
                    {
                        // Any point within the range of a sensor that is not a beacon location cannot be a beacon
                        // location (it would be picked up by one of the sensors)
                        nonBeaconSpotSeenBySensor = true;
                    }
                }
            }

            if (nonBeaconSpotSeenBySensor)
            {
                cannotBeBeaconCount++;
            }
        }

        return cannotBeBeaconCount;
    }

    public static long Solve2(string[] lines, int biggestDimension)
    {
        var parsed = lines.Select(Parse).ToList();
        var sensors = parsed.Select(p => p.Item1).ToList();

        Range GetSensorRange(Sensor s, int targetRow)
        {
            // Given a target row, figure out how much of the X range a given sensor can cover. The X reach deteriorates
            // by one with each step in the Y direction. Based on this, we can find the reachable x range for the
            // scanner using some simple math
            int distToTarget = Math.Abs(s.P.Y - targetRow);
            if (distToTarget > s.Range)
            {
                return null;
            }

            int xOffset = Math.Abs(s.Range - distToTarget);
            int minX = s.P.X - xOffset;
            int maxX = s.P.X + xOffset;

            return new(minX, maxX);
        }

        for (int row = 0; row <= biggestDimension; row++)
        {
            int minX = int.MaxValue;
            int maxX = 0;

            // It is too expensive to brute force all coordinates. Instead, collapse the X search into ranges so we can
            // enumerate a much smaller set of values (just the number of sensors * each row).
            var ranges = sensors.Select(s => GetSensorRange(s, row)).Where(s => s != null).OrderBy(x => x.MinX).ToList();

            for (int i = 0; i < ranges.Count; i++)
            {
                // The ranges are sorted, so we can walk them in order looking for gaps
                Range curr = ranges[i];
                minX = Math.Min(curr.MinX, minX);
                maxX = Math.Max(curr.MaxX, maxX);

                if (i < ranges.Count - 1)
                {
                    Range next = ranges[i + 1];
                    if (maxX < next.MinX - 1)
                    {
                        // We found a gap between x ranges. Since there is only one valid point in the search, this
                        // must be it.
                        long resultX = next.MinX - 1;
                        return (resultX * 4000000L + row);
                    }
                }
            }
        }

        return -1;
    }

    private static (Sensor, Point) Parse(string line)
    {
        Match m = Re.Match(line);

        int sensorX = int.Parse(m.Groups[1].Value);
        int sensorY = int.Parse(m.Groups[2].Value);
        int beaconX = int.Parse(m.Groups[3].Value);
        int beaconY = int.Parse(m.Groups[4].Value);

        Point sensorPoint = new(sensorX, sensorY);
        Point beaconPoint = new(beaconX, beaconY);

        Sensor s = new(sensorPoint, Manhattan(sensorPoint, beaconPoint));

        return (s, beaconPoint);
    }

    private record Range(int MinX, int MaxX);

    private record Sensor(Point P, int Range);

    private record Point(int X, int Y);

    private static int Manhattan(Point p1, Point p2) => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
}