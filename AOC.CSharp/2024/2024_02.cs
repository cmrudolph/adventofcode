namespace AOC.CSharp;

public static class AOC2024_02
{
    public static long Solve1(string[] lines)
    {
        int result = 0;

        foreach (string line in lines)
        {
            List<long> levels = line.Split(' ').Select(long.Parse).ToList();
            bool isSafe = IsSafe(levels);
            result += isSafe ? 1 : 0;
        }

        return result;
    }

    public static long Solve2(string[] lines)
    {
        int result = 0;

        foreach (string line in lines)
        {
            List<long> levels = line.Split(' ').Select(long.Parse).ToList();
            bool origIsSafe = IsSafe(levels);

            bool modIsSafe = false;
            for (int i = 0; i < levels.Count; i++)
            {
                List<long> copy = levels.ToList();
                copy.RemoveAt(i);
                bool isSafe = IsSafe(copy);
                if (isSafe)
                {
                    modIsSafe = true;
                }
            }

            result += (origIsSafe || modIsSafe) ? 1 : 0;
        }

        return result;
    }

    private static bool IsSafe(List<long> levels)
    {
        bool increasing = false;
        int issues = 0;

        for (int i = 1; i < levels.Count; i++)
        {
            long prev = levels[i - 1];
            long curr = levels[i];
            if (i == 1)
            {
                if (curr > prev)
                {
                    increasing = true;
                }
                else
                {
                    increasing = false;
                }
            }

            long difference = curr - prev;
            long absDifference = Math.Abs(difference);
            if (absDifference == 0 || absDifference > 3)
            {
                // No difference or gap is too big
                return false;
            }

            if (increasing && difference < 0)
            {
                // This pair is going in the opposite direction
                return false;
            }

            if (!increasing && difference > 0)
            {
                // This pair is going in the opposite direction
                return false;
            }
        }

        return true;
    }
}
