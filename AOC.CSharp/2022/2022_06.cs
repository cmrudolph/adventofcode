namespace AOC.CSharp;

public static class AOC2022_06
{
    public static long Solve1(string[] lines) => Solve(lines[0], 4);

    public static long Solve2(string[] lines) => Solve(lines[0], 14);

    private static long Solve(string line, int continuous)
    {
        for (int i = 0; i < line.Length - continuous + 1; i++)
        {
            if (line[i..(i + continuous)].ToHashSet().Count == continuous)
            {
                return i + continuous;
            }
        }

        return -1;
    }
}
