namespace AOC.CSharp;

public static class AOC2024_01
{
    public static long Solve1(string[] lines)
    {
        var lineValues = lines
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        List<long> left = lineValues.Select(x => long.Parse(x[0])).OrderBy(x => x).ToList();
        List<long> right = lineValues.Select(x => long.Parse(x[1])).OrderBy(x => x).ToList();

        long totalDiff = 0;
        for (int i = 0; i < left.Count; i++)
        {
            long diff = Math.Abs(left[i] - right[i]);
            totalDiff += diff;
        }

        return totalDiff;
    }

    public static long Solve2(string[] lines)
    {
        var lineValues = lines
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        List<long> left = lineValues.Select(x => long.Parse(x[0])).OrderBy(x => x).ToList();
        Dictionary<long, long> rightCounts = lineValues
            .Select(x => long.Parse(x[1]))
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => (long)x.Count());

        long result = 0;
        foreach (long val in left)
        {
            long count = rightCounts.GetValueOrDefault(val);
            result += val * count;
        }

        return result;
    }
}
