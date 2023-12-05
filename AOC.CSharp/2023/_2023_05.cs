namespace AOC.CSharp;

public static class AOC2023_05
{
    public static long Solve1(string[] lines)
    {
        var seedEntries = ParseSeedEntries(lines);
        var maps = ParseMaps(lines);

        List<long> finalValues = seedEntries.Select(x => GetLocationForSeed(maps, x)).ToList();

        return finalValues.Min();
    }

    public static long Solve2(string[] lines)
    {
        var seedEntries = ParseSeedEntries(lines);
        var maps = ParseMaps(lines);

        (long, long)? FindNewLeftRight(long left, long right, long gap)
        {
            if (right - left < gap)
            {
                return (left, right);
            }

            long atLeft = GetLocationForSeed(maps, left);

            // Try to find a range that needs a more granular search. Jump ahead by a certain amount
            // on each iteration and see if we get a smaller result. If we do, the seed we want to
            // take a closer look at is within this smaller range. Disregard the rest of the
            // original range and focus here.
            for (long j = left; j <= right; j += gap)
            {
                long atJ = GetLocationForSeed(maps, j);
                if (atJ < atLeft)
                {
                    return (left, j);
                }

                left = j;
            }

            return null;
        }

        // Multiple stages of filtering the search space down to a manageable size
        List<long> gaps = new() { 10000000, 100000, 1000 };

        long best = long.MaxValue;

        for (int i = 0; i < seedEntries.Count; i += 2)
        {
            long left = seedEntries[i];
            long right = left + seedEntries[i + 1];

            bool shrunk = false;
            foreach (long g in gaps)
            {
                var newLeftRight = FindNewLeftRight(left, right, g);
                if (newLeftRight.HasValue)
                {
                    (left, right) = newLeftRight.Value;
                    shrunk = true;
                }
            }

            // We were not successful in reducing the search space. This means the calculated
            // values grow continuously from left to right. The first value in the range is the
            // optimal one for this case
            if (!shrunk)
            {
                right = left;
            }

            for (long j = left; j <= right; j++)
            {
                long result = GetLocationForSeed(maps, j);
                best = Math.Min(result, best);
            }
        }

        return best;
    }

    private static long GetLocationForSeed(List<List<Transformation>> maps, long seed)
    {
        long result = seed;

        foreach (var map in maps)
        {
            foreach (var mapFunc in map)
            {
                long? transformed = mapFunc(result);
                if (transformed.HasValue)
                {
                    result = transformed.Value;
                    break;
                }
            }
        }

        return result;
    }

    private static List<List<Transformation>> ParseMaps(string[] lines)
    {
        List<List<Transformation>> maps = new();
        List<Transformation> mapEntries = new();

        Transformation ParseMapEntry(long dest, long source, long range) =>
            input =>
            {
                long adjustment = dest - source;
                long sourceEnd = source + range;

                if (input >= source && input <= sourceEnd)
                {
                    return input + adjustment;
                }

                return null;
            };

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.Contains("map:"))
            {
                if (mapEntries.Any())
                {
                    mapEntries.Add(IdentityTransformation);
                    maps.Add(mapEntries);
                }
                mapEntries = new();
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                string[] splits = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                long dest = long.Parse(splits[0]);
                long source = long.Parse(splits[1]);
                long range = long.Parse(splits[2]);

                mapEntries.Add(ParseMapEntry(dest, source, range));
            }
        }

        if (mapEntries.Any())
        {
            mapEntries.Add(IdentityTransformation);
            maps.Add(mapEntries);
        }

        return maps;
    }

    private static List<long> ParseSeedEntries(string[] lines)
    {
        List<long> seedEntries = lines[0]
            .Substring(7)
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();

        return seedEntries;
    }

    private delegate long? Transformation(long x);

    private static long? IdentityTransformation(long input) => input;
}
