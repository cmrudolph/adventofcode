namespace AOC.CSharp;

public static class AOC2017_09
{
    public static long Solve1(string[] lines)
    {
        (long score, _) = Solve(lines);
        return score;
    }

    public static long Solve2(string[] lines)
    {
        (_, long nonCanceled) = Solve(lines);
        return nonCanceled;
    }

    private static (long, long) Solve(string[] lines)
    {
        long score = 0;
        long currScore = 0;
        long nonCanceled = 0;
        
        List<char> chars = lines[0].ToList();
        for (int i = 0; i < chars.Count; i++)
        {
            char ch = chars[i];
            if (ch == '{')
            {
                currScore++;
            }
            else if (ch == '}')
            {
                score += currScore;
                currScore--;
            }
            else if (ch == '<')
            {
                i++;
                while (chars[i] != '>')
                {
                    if (chars[i] != '>' && chars[i] != '!')
                    {
                        nonCanceled++;
                    }
                    if (chars[i] == '!')
                    {
                        i++;
                    }
                    i++;
                }
            }
        }

        return (score, nonCanceled);
    }
}
