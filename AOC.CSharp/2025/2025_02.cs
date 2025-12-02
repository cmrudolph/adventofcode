namespace AOC.CSharp;

public static class AOC2025_02
{
    public static long Solve1(string[] lines)
    {
        long sum = 0;
        string[] ranges = lines[0].Split(",", StringSplitOptions.RemoveEmptyEntries);

        foreach (string range in ranges)
        {
            string[] ends = range.Split("-");
            long start = long.Parse(ends[0]);
            long end = long.Parse(ends[1]);

            for (long i = start; i <= end; i++)
            {
                string asStr = i.ToString();
                string firstHalf = asStr.Substring(0, asStr.Length / 2);
                string secondHalf = asStr.Substring(asStr.Length / 2);

                if (firstHalf == secondHalf)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        HashSet<long> allDistinct = new();

        long sum = 0;
        string[] ranges = lines[0].Split(",", StringSplitOptions.RemoveEmptyEntries);

        foreach (string range in ranges)
        {
            string[] ends = range.Split("-");
            long start = long.Parse(ends[0]);
            long end = long.Parse(ends[1]);

            for (long i = start; i <= end; i++)
            {
                string asStr = i.ToString();

                for (int j = 1; j <= asStr.Length / 2; j++)
                {
                    var chunks = asStr.Chunk(j).Select(x => new string(x));
                    HashSet<string> uniques = new(chunks);
                    if (uniques.Count == 1)
                    {
                        allDistinct.Add(i);
                        Console.WriteLine(i);
                    }
                }
            }
        }

        return allDistinct.Sum();
    }
}
