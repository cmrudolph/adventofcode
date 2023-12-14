namespace AOC.CSharp;

public static class AOC2023_12
{
    public static long Solve1(string[] lines)
    {
        long sum = 0;

        foreach (string line in lines)
        {
            (string pattern, int[] groups) = Parse(line, false);
            List<char> progress = new();

            Solver solver = new();
            long result = solver.Recurse(pattern + ".", groups, 0, 0, progress);
            sum += result;
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        long sum = 0;

        foreach (string line in lines)
        {
            (string pattern, int[] groups) = Parse(line, true);
            List<char> progress = new();

            Solver solver = new();
            long result = solver.Recurse(pattern + ".", groups, 0, 0, progress);
            sum += result;
        }

        return sum;
    }

    public static long SolveLine(string line)
    {
        (string pattern, int[] groups) = Parse(line, false);

        Solver solver = new();
        List<char> progress = new();
        return solver.Recurse(pattern + ".", groups, 0, 0, progress);
    }

    private class Solver
    {
        private Dictionary<string, long> _cache = new();

        public long Recurse(
            string pattern,
            int[] groups,
            int length,
            int depth,
            List<char> progress
        )
        {
            string key = MakeKey(pattern, groups, length);
            if (_cache.TryGetValue(key, out long cached))
            {
                return cached;
            }

            // Console.Write(
            //     "{0}{1} [{2}] {3} | {4} | ",
            //     new string(' ', depth),
            //     pattern,
            //     string.Join(",", groups),
            //     length,
            //     string.Join("", progress)
            // );

            if (groups.Length == 0)
            {
                if (pattern.Contains("#"))
                {
                    // Console.WriteLine("0 (more required springs");
                    _cache.Add(key, 0);
                    return 0;
                }

                // Console.WriteLine("1 (matched all groups + no more springs)");
                _cache.Add(key, 1);
                return 1;
            }

            if (pattern.Length == 0)
            {
                // Console.WriteLine("0 (ran out of pattern)");
                _cache.Add(key, 0);
                return 0;
            }

            if (length == groups[0])
            {
                if (pattern[0] == '#')
                {
                    // Console.WriteLine("Finished group with springs remaining");
                    _cache.Add(key, 0);
                    return 0;
                }

                // Console.WriteLine("Finished group (treat next as '.' path)");
                progress.Add('.');
                long rec = Recurse(pattern[1..], groups[1..], 0, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);

                _cache.Add(key, rec);
                return rec;
            }

            if (length > groups[0])
            {
                // Console.WriteLine("0 (too many springs)");
                _cache.Add(key, 0);
                return 0;
            }

            if (pattern[0] == '.')
            {
                if (length > 0)
                {
                    // Console.WriteLine("In progress, but group cannot be finished");
                    _cache.Add(key, 0);
                    return 0;
                }

                // Console.WriteLine("Go down '.' path");
                progress.Add('.');
                long rec = Recurse(pattern[1..], groups, 0, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);
                _cache.Add(key, rec);

                return rec;
            }

            if (pattern[0] == '#')
            {
                // Console.WriteLine("Go down '#' path");
                progress.Add('#');
                long rec = Recurse(pattern[1..], groups, length + 1, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);
                _cache.Add(key, rec);

                return rec;
            }

            // Console.WriteLine("Go down '?' as '#' path");
            progress.Add('#');
            long rec1 = Recurse(pattern[1..], groups, length + 1, depth + 1, progress);
            progress.RemoveAt(progress.Count - 1);

            long rec2 = 0;
            if (length == 0)
            {
                // Console.WriteLine("Go down '?' as '.' path");
                progress.Add('.');
                rec2 = Recurse(pattern[1..], groups, length, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);
            }

            long result = rec1 + rec2;
            _cache.Add(key, result);

            return result;
        }
    }

    private static (string, int[]) Parse(string line, bool unfold)
    {
        string[] splits = line.Split(" ");
        string pattern = splits[0];
        int[] lengths = splits[1].Split(",").Select(int.Parse).ToArray();

        if (!unfold)
        {
            return (pattern, lengths);
        }

        List<string> finalPatterns = new();
        List<int> finalLengths = new();
        {
            for (int i = 0; i < 5; i++)
            {
                finalPatterns.Add(pattern);
                finalLengths.AddRange(lengths);
            }
        }

        return (string.Join('?', finalPatterns), finalLengths.ToArray());
    }

    private static string MakeKey(string pattern, int[] lengths, int length) =>
        $"{pattern}|{string.Join(",", lengths)}|{length}";
}
