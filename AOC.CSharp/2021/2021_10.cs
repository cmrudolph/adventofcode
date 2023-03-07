namespace AOC.CSharp;

public static class AOC2021_10
{
    private static readonly Dictionary<char, char> Pairs =
        new() { { '(', ')' }, { '{', '}' }, { '[', ']' }, { '<', '>' }, };

    public static long Solve1(string[] lines)
    {
        return lines.Sum(ScoreLine1);
    }

    public static long Solve2(string[] lines)
    {
        var scores = lines
            .Select(ScoreLine2)
            .Where(s => s != null)
            .Select(s => s.Value)
            .OrderBy(s => s)
            .ToList();
        return scores[scores.Count / 2];
    }

    private static int ScoreLine1(string line)
    {
        Stack<char> stack = new();
        foreach (char c in line)
        {
            if (Pairs.ContainsKey(c))
            {
                stack.Push(c);
            }
            else
            {
                char popped = stack.Pop();
                if (c != Pairs[popped])
                {
                    return c switch
                    {
                        ')' => 3,
                        ']' => 57,
                        '}' => 1197,
                        '>' => 25137,
                        _ => throw new NotSupportedException(),
                    };
                }
            }
        }

        return 0;
    }

    private static long? ScoreLine2(string line)
    {
        Stack<char> stack = new();
        foreach (char c in line)
        {
            if (Pairs.ContainsKey(c))
            {
                stack.Push(c);
            }
            else
            {
                char popped = stack.Pop();
                if (c != Pairs[popped])
                {
                    return null;
                }
            }
        }

        long result = 0;
        while (stack.Count > 0)
        {
            char popped = stack.Pop();
            int toAdd = popped switch
            {
                '(' => 1,
                '[' => 2,
                '{' => 3,
                '<' => 4,
                _ => throw new NotSupportedException(),
            };
            result = (result * 5) + toAdd;
        }

        return result;
    }
}
