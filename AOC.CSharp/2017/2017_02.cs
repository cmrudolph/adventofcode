namespace AOC.CSharp;

public static class AOC2017_02
{
    public static long Solve1(string[] lines)
    {
        return lines.Select(x => ParseAndSort(x)).Sum(x => x.Last() - x.First());
    }

    public static long Solve2(string[] lines)
    {
        return lines.Select(x => ParseAndSort(x)).Sum(DivideEvenlyDivisible);
    }

    private static int DivideEvenlyDivisible(int[] ordered)
    {
        for (int i = ordered.Length - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                int bigger = ordered[i];
                int smaller = ordered[j];
                if (bigger % smaller == 0)
                {
                    return bigger / smaller;
                }
            }
        }
        return -1;
    }

    private static int[] ParseAndSort(string line)
    {
        return line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .OrderBy(i => i)
            .ToArray();
    }
}
