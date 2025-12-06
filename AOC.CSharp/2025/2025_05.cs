namespace AOC.CSharp;

public static class AOC2025_05
{
    private record Range(long Start, long End);

    public static long Solve1(string[] lines)
    {
        bool part2 = false;
        List<Range> ranges = new();
        int count = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                part2 = true;
            }
            else
            {
                if (part2)
                {
                    long value = long.Parse(line);
                    foreach (var range in ranges)
                    {
                        if (value >= range.Start && value <= range.End)
                        {
                            count++;
                            break;
                        }
                    }
                }
                else
                {
                    string[] splits = line.Split("-");
                    ranges.Add(new Range(long.Parse(splits[0]), long.Parse(splits[1])));
                }
            }
        }

        return count;
    }

    public static long Solve2(string[] lines)
    {
        bool part2 = false;
        List<Range> ranges = new();
        List<Range> finalRanges = new();
        long count = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            string[] splits = line.Split("-");
            ranges.Add(new Range(long.Parse(splits[0]), long.Parse(splits[1])));

            ranges = ranges.OrderBy(x => x.Start).ToList();
        }

        finalRanges.Add(ranges[0]);

        for (int i = 1; i < ranges.Count; i++)
        {
            Range r = ranges[i];
            Range last = finalRanges.Last();
            if (r.Start <= last.End)
            {
                long newEnd = Math.Max(r.End, last.End);
                finalRanges[^1] = last with { End = newEnd };
            }
            else if (r.Start > last.End)
            {
                finalRanges.Add(r);
            }
        }

        foreach (Range range in finalRanges)
        {
            count += range.End - range.Start + 1;
            Console.WriteLine(range);
        }

        return count;
    }
}
