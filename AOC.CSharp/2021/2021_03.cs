namespace AOC.CSharp;

public static class AOC2021_03
{
    public static long Solve1(string[] lines)
    {
        int[] onesCounts = BuildOnesCounts(lines);

        string gammaStr = "";
        string epsilonStr = "";

        foreach (int count in onesCounts)
        {
            char gammaChar = count >= lines.Length / 2 ? '1' : '0';
            char epsilonChar = gammaChar == '1' ? '0' : '1';
            gammaStr += gammaChar;
            epsilonStr += epsilonChar;
        }

        int gamma = Convert.ToInt32(gammaStr, 2);
        int epsilon = Convert.ToInt32(epsilonStr, 2);

        return gamma * epsilon;
    }

    public static long Solve2(string[] lines)
    {
        int Calc(Func<int, int, char> calcRemoveChar)
        {
            int[] onesCounts = BuildOnesCounts(lines);

            HashSet<string> set = lines.ToHashSet();
            int i = 0;
            while (set.Count > 1)
            {
                int count = onesCounts[i];
                char removeCh = calcRemoveChar(count, set.Count);
                set.RemoveWhere(x => x[i] == removeCh);
                onesCounts = BuildOnesCounts(set);
                i++;
            }

            return Convert.ToInt32(set.Single(), 2);
        }

        int oxygen = Calc((count, setCount) => count * 2 >= setCount ? '0' : '1');
        int scrubber = Calc((count, setCount) => count * 2 >= setCount ? '1' : '0');

        return oxygen * scrubber;
    }

    private static int[] BuildOnesCounts(IEnumerable<string> lines)
    {
        int[] onesCounts = new int[lines.First().Length];

        foreach (string line in lines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                onesCounts[i] += line[i] == '1' ? 1 : 0;
            }
        }

        return onesCounts;
    }
}
