namespace AOC.CSharp;

public static class AOC2017_16
{
    public static string Solve1(string[] lines, int programCount)
    {
        List<string> programs = Enumerable
            .Range(0, programCount)
            .Select(x => ((char)('a' + x)).ToString())
            .ToList();
        string[] instructions = lines[0].Split(",");
        Dance(programs, instructions);

        return string.Join("", programs);
    }

    public static string Solve2(string[] lines, int programCount)
    {
        List<string> programs = Enumerable
            .Range(0, programCount)
            .Select(x => ((char)('a' + x)).ToString())
            .ToList();
        string[] instructions = lines[0].Split(",");
        HashSet<string> seen = new();

        // Dance until we see a result repeat. This tells us how many iterations need to
        // be done before we start cycling through the same results
        int repeatNum = 0;
        while (!seen.Contains(string.Join("", programs)))
        {
            seen.Add(string.Join("", programs));
            repeatNum++;
            Dance(programs, instructions);
        }

        // Now that we know the repeat frequency, we can eliminate most of the iterations
        // by removing all the repetitive cycles until just before the target iteration.
        // Once we get close, we can continue dancing again in a loop until we hit the exact
        // target we are aiming for.
        int newStart = (1000000000 / repeatNum) * repeatNum;
        programs = Enumerable
            .Range(0, programCount)
            .Select(x => ((char)('a' + x)).ToString())
            .ToList();
        for (repeatNum = newStart; repeatNum < 1000000000; repeatNum++)
        {
            Dance(programs, instructions);
        }

        return string.Join("", programs);
    }

    private static void Dance(List<string> programs, string[] instructions)
    {
        foreach (string instruction in instructions)
        {
            char firstCh = instruction[0];
            switch (firstCh)
            {
                case 's':
                {
                    int amount = int.Parse(instruction[1..]);
                    for (int i = 0; i < amount; i++)
                    {
                        programs.Insert(0, programs[^1]);
                        programs.RemoveAt(programs.Count - 1);
                    }
                    break;
                }
                case 'x':
                {
                    string[] splits = instruction[1..].Split("/");
                    int idx1 = int.Parse(splits[0]);
                    int idx2 = int.Parse(splits[1]);
                    (programs[idx1], programs[idx2]) = (programs[idx2], programs[idx1]);
                    break;
                }
                case 'p':
                {
                    string[] splits = instruction[1..].Split("/");
                    string prog1 = splits[0];
                    string prog2 = splits[1];
                    int idx1 = programs.IndexOf(prog1);
                    int idx2 = programs.IndexOf(prog2);
                    (programs[idx1], programs[idx2]) = (programs[idx2], programs[idx1]);
                    break;
                }
            }
        }
    }
}
