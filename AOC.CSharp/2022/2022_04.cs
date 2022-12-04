namespace AOC.CSharp;

public static class AOC2022_04
{
    public static long Solve1(string[] lines)
    {
        return lines.Select(Overlaps).ToList().Count(x => x == Overlap.Full);
    }

    public static long Solve2(string[] lines)
    {
        return lines.Select(Overlaps).ToList().Count(x => x is Overlap.Partial or Overlap.Full);
    }

    private static Overlap Overlaps(string line)
    {
        Endpoints Parse(string s)
        {
            string[] startEnd = s.Split('-');
            int start = int.Parse(startEnd[0]);
            int end = int.Parse(startEnd[1]);

            return new Endpoints(start, end);
        }

        string[] splits = line.Split(',');
        Endpoints range1 = Parse(splits[0]);
        Endpoints range2 = Parse(splits[1]);

        bool full =
            range1.Start >= range2.Start && range1.End <= range2.End
            || range2.Start >= range1.Start && range2.End <= range1.End;

        bool none = range1.End < range2.Start || range1.Start > range2.End;

        Overlap result = full
            ? Overlap.Full
            : none
                ? Overlap.None
                : Overlap.Partial;

        Console.WriteLine("{0} -- {1}", line, result);

        return result;
    }

    private record Endpoints(int Start, int End);

    private enum Overlap
    {
        None,
        Partial,
        Full,
    }
}
