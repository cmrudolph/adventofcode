namespace AOC.CSharp;

public static class AOC2018_01
{
    public static long Solve1(string[] lines)
    {
        return lines.Select(int.Parse).Sum();
    }

    public static long Solve2(string[] lines)
    {
        var nums = lines.Select(int.Parse).ToList();
        HashSet<int> seen = new();
        int sum = 0;

        while (true)
        {
            foreach (int num in nums)
            {
                sum += num;
                if (seen.Contains(sum))
                {
                    return sum;
                }

                seen.Add(sum);
            }
        }
    }
}
