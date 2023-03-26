namespace AOC.CSharp;

public static class AOC2018_05
{
    public static long Solve1(string[] lines)
    {
        return React(lines[0]);
    }

    public static long Solve2(string[] lines)
    {
        string line = lines[0];
        long best = long.MaxValue;

        for (char c = 'A'; c <= 'Z'; c++)
        {
            char c2 = (char)(c + 32);
            string changedLine = line.Replace(c.ToString(), "").Replace(c2.ToString(), "");
            int result = React(changedLine);
            best = result < best ? result : best;
        }

        return best;
    }

    private static int React(string s)
    {
        List<string> replacePairs = new();
        for (char c1 = 'A'; c1 <= 'Z'; c1++)
        {
            char c2 = (char)(c1 + 32);
            replacePairs.Add(new string(new[] { c1, c2 }));
            replacePairs.Add(new string(new[] { c2, c1 }));
        }

        bool changed = true;
        while (changed)
        {
            string orig = s;
            foreach (var rp in replacePairs)
            {
                s = s.Replace(rp, "");
            }

            changed = orig != s;
        }

        return s.Length;
    }
}
