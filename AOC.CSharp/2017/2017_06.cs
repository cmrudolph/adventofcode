namespace AOC.CSharp;

public static class AOC2017_06
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines).ans1;
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines).ans2;
    }

    private static (long ans1, long ans2) Solve(string[] lines)
    {
        HashSet<string> seen = new();
        Dictionary<string, int> idxOfSeen = new();

        int[] values = lines[0]
            .Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        string asStr = ToString(values);
        int iteration = 0;
        seen.Add(asStr);

        do
        {
            seen.Add(asStr);
            idxOfSeen.Add(asStr, iteration);
            int pickedIdx = -1;
            int pickedVal = -1;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > pickedVal)
                {
                    pickedIdx = i;
                    pickedVal = values[i];
                }
            }
            values[pickedIdx] = 0;

            pickedIdx++;
            while (pickedVal > 0)
            {
                if (pickedIdx == values.Length)
                {
                    pickedIdx = 0;
                }
                values[pickedIdx]++;
                pickedIdx++;
                pickedVal--;
            }

            asStr = ToString(values);
            iteration++;
        }
        while (!seen.Contains(asStr));

        return (iteration, iteration - idxOfSeen[asStr]);
    }

    private static string ToString(int[] values)
    {
        return string.Join("|", values);
    }
}
