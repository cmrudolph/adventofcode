namespace AOC.CSharp;

public static class AOC2023_06
{
    public static long Solve1(string[] lines)
    {
        List<long> times = ParseLine(lines[0]);
        List<long> distances = ParseLine(lines[1]);

        return Solve(times, distances);
    }

    public static long Solve2(string[] lines)
    {
        List<long> times = ParseLine(lines[0]);
        List<long> distances = ParseLine(lines[1]);

        times = new() { long.Parse(string.Join("", times)) };
        distances = new() { long.Parse(string.Join("", distances)) };

        return Solve(times, distances);
    }

    private static long Solve(List<long> times, List<long> distances)
    {
        List<int> waysToBeatCounts = new();

        for (int i = 0; i < times.Count; i++)
        {
            int waysToBeatCount = 0;
            long time = times[i];
            long dist = distances[i];

            for (int j = 1; j < time; j++)
            {
                long travelTime = time - j;
                long travelDistance = travelTime * j;
                if (travelDistance > dist)
                {
                    waysToBeatCount++;
                }
            }

            waysToBeatCounts.Add(waysToBeatCount);
        }

        return waysToBeatCounts.Aggregate(1, (x, y) => x * y);
    }

    private static List<long> ParseLine(string line) =>
        line.Substring(10)
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();
}
