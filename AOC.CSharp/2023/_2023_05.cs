namespace AOC.CSharp;

public static class AOC2023_05
{
    public static long Solve1(string[] lines)
    {
        List<long> seeds = lines[0]
            .Substring(7)
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();

        List<List<Func<long, long?>>> maps = new();
        List<Func<long, long?>> mapEntries = new();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.Contains("map:"))
            {
                if (mapEntries.Any())
                {
                    mapEntries.Add(Identity);
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
            mapEntries.Add(Identity);
            maps.Add(mapEntries);
        }

        List<long> finalValues = new();

        foreach (long seed in seeds)
        {
            Console.Write("{0} -> ", seed);
            long value = seed;
            foreach (var map in maps)
            {
                foreach (var mapFunc in map)
                {
                    long? transformed = mapFunc(value);
                    if (transformed.HasValue)
                    {
                        Console.Write("{0} -> ", transformed.Value);
                        value = transformed.Value;
                        break;
                    }
                }
            }

            finalValues.Add(value);
            Console.WriteLine("{0}", value);
        }

        return finalValues.Min();
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private static Func<long, long?> ParseMapEntry(long dest, long source, long range) =>
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

    private static long? Identity(long input) => input;
}
