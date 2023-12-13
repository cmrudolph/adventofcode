namespace AOC.CSharp;

public static class AOC2023_12
{
    public static long Solve1(string[] lines)
    {
        return 888;
    }

    public static long SolveLine(string line)
    {
        (string pattern, int[] groups) = Parse(line);

        Solver solver = new();
        List<char> progress = new();
        return solver.Recurse(pattern + ".", groups, 0, 0, progress);
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private class Solver
    {
        public long Recurse(
            string pattern,
            int[] groups,
            int length,
            int depth,
            List<char> progress
        )
        {
            Console.Write(
                "{0}{1} [{2}] {3} | {4} | ",
                new string(' ', depth),
                pattern,
                string.Join(",", groups),
                length,
                string.Join("", progress)
            );

            if (groups.Length == 0)
            {
                if (pattern.Contains("#"))
                {
                    // More required springs
                    Console.WriteLine("0 (more required springs");
                    return 0;
                }

                // Matched all groups + no more springs
                Console.WriteLine("1 (matched all groups + no more springs)");
                return 1;
            }

            if (pattern.Length == 0)
            {
                // Ran out of pattern with groups still to match
                Console.WriteLine("0 (ran out of pattern)");
                return 0;
            }

            if (length == groups[0])
            {
                if (pattern[0] == '#')
                {
                    Console.WriteLine("Finished group with springs remaining");
                    return 0;
                }

                // Finished a group. Continue only down the '.' path
                Console.WriteLine("Finished group (treat next as '.' path)");
                progress.Add('.');
                long rec = Recurse(pattern[1..], groups[1..], 0, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);

                return rec;
            }

            if (length > groups[0])
            {
                // Too many springs in the group. This is a dead end
                Console.WriteLine("0 (too many springs)");
                return 0;
            }

            if (pattern[0] == '.')
            {
                if (length > 0)
                {
                    Console.WriteLine("In progress, but group cannot be finished");
                    return 0;
                }

                Console.WriteLine("Go down '.' path");
                progress.Add('.');
                long rec = Recurse(pattern[1..], groups, 0, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);

                return rec;
            }

            if (pattern[0] == '#')
            {
                Console.WriteLine("Go down '#' path");
                progress.Add('#');
                long rec = Recurse(pattern[1..], groups, length + 1, depth + 1, progress);
                progress.RemoveAt(progress.Count - 1);

                return rec;
            }

            Console.WriteLine("Go down both paths");

            progress.Add('#');
            long rec1 = Recurse(pattern[1..], groups, length + 1, depth + 1, progress);
            progress.RemoveAt(progress.Count - 1);

            progress.Add('.');
            long rec2 = Recurse(pattern[1..], groups, length, depth + 1, progress);
            progress.RemoveAt(progress.Count - 1);

            return rec1 + rec2;
        }
    }

    private static (string, int[]) Parse(string line)
    {
        string[] splits = line.Split(" ");
        int[] lengths = splits[1].Split(",").Select(int.Parse).ToArray();

        return (splits[0], lengths);
    }
}
