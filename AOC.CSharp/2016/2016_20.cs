namespace AOC.CSharp;

public class AOC2016_20
{
    public static long Solve1(string[] lines)
    {
        var ranges = lines.Select(Parse).ToList();
        var consolidated = ConsolidateRanges(ranges);
        var ordered = consolidated.OrderBy(r => r.End).First();

        return ordered.End + 1;
    }

    public static long Solve2(string[] lines)
    {
        var ranges = lines.Select(Parse).ToList();
        var consolidated = ConsolidateRanges(ranges);
        long totalBlocked = consolidated.Sum(c => c.CountIn);
        long totalUnblocked = uint.MaxValue - totalBlocked + 1;

        return totalUnblocked;
    }

    private static List<Range> ConsolidateRanges(List<Range> ranges)
    {
        List<Range> results = ranges.ToList();

        bool changed = true;
        while (changed)
        {
            changed = false;
            for (int i = 0; i < results.Count; i++)
            {
                int j = i + 1;
                while (j < results.Count)
                {
                    Range r1 = results[i];
                    Range r2 = results[j];
                    if (r1.CanMergeWith(r2))
                    {
                        Range rNew = r1.MergeWith(r2);
                        results[i] = rNew;
                        results.RemoveAt(j);
                        changed = true;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }

        return results;
    }

    private static Range Parse(string line)
    {
        string[] splits = line.Split('-');
        return new Range(long.Parse(splits[0]), long.Parse(splits[1]));
    }

    private record Range(long Start, long End)
    {
        public bool InRange(long n) => n >= Start && n <= End;

        public long NextOpen => End + 1;

        public bool CanMergeWith(Range r)
        {
            return
                Start < r.Start && End >= r.Start - 1
                || r.Start < Start && r.End >= Start - 1
                || End > r.End && Start <= r.End + 1
                || r.End > End && r.Start <= End + 1;
        }

        public Range MergeWith(Range r)
        {
            if (!CanMergeWith(r))
            {
                throw new InvalidOperationException("Can't merge these");
            }

            long newStart = Math.Min(Start, r.Start);
            long newEnd = Math.Max(End, r.End);

            return new Range(newStart, newEnd);
        }

        public long CountIn => End - Start + 1;
    }
}
