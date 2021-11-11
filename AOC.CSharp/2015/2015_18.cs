namespace AOC.CSharp;

public static class AOC2015_18
{
    private const char Stuck = 'S';
    private const char On = '#';
    private const char Off = '.';

    public static long Solve1(string[] lines, string extra)
    {
        var chars = Parse(lines, false);
        int iterations = int.Parse(extra);

        for (int i = 0; i < iterations; i++)
        {
            chars = Transform(chars);
        }

        long count = CountOn(chars);

        return count;
    }

    public static long Solve2(string[] lines, string extra)
    {
        var chars = Parse(lines, true);
        int iterations = int.Parse(extra);
        Print(chars);
        Console.WriteLine();

        for (int i = 0; i < iterations; i++)
        {
            chars = Transform(chars);
            Print(chars);
            Console.WriteLine();
        }

        long count = CountOn(chars);

        return count;
    }

    private static char[,] Parse(string[] lines, bool stuck)
    {
        char[,] chars = new char[lines.Length + 2, lines.Length + 2];

        for (int i = 0; i <= lines.Length + 1; i++)
        {
            for (int j = 0; j <= lines.Length + 1; j++)
            {
                chars[i, j] = Off;
            }
        }

        for (int i = 1; i <= lines.Length; i++)
        {
            char[] lineChars = lines[i - 1].ToCharArray();
            for (int j = 1; j <= lineChars.Length; j++)
            {
                if (stuck)
                {
                    if (i == 1 && j == 1)
                    {
                        chars[i, j] = Stuck;
                    }
                    else if (i == 1 && j == lineChars.Length)
                    {
                        chars[i, j] = Stuck;
                    }
                    else if (i == lineChars.Length && j == 1)
                    {
                        chars[i, j] = Stuck;
                    }
                    else if (i == lineChars.Length && j == lineChars.Length)
                    {
                        chars[i, j] = Stuck;
                    }
                    else
                    {
                        chars[i, j] = lineChars[j - 1];
                    }
                }
                else
                {
                    chars[i, j] = lineChars[j - 1];
                }
            }
        }

        return chars;
    }

    private static char[,] Transform(char[,] chars)
    {
        char[,] newChars = new char[chars.GetLength(0), chars.GetLength(1)];
        Array.Copy(chars, newChars, chars.Length);

        for (int i = 1; i < chars.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < chars.GetLength(1) - 1; j++)
            {
                char ch = chars[i, j];

                int neighborsOn = 0;

                for (int a = i - 1; a <= i + 1; a++)
                {
                    for (int b = j - 1; b <= j + 1; b++)
                    {
                        if (!(a == i && b == j))
                        {
                            neighborsOn += (chars[a, b] == On || chars[a, b] == Stuck) ? 1 : 0;
                        }
                    }
                }

                if (ch == On)
                {
                    newChars[i, j] = neighborsOn >= 2 && neighborsOn <= 3 ? On : Off;
                }
                else if (ch == Off)
                {
                    newChars[i, j] = neighborsOn == 3 ? On : Off;
                }
            }
        }

        return newChars;
    }

    private static long CountOn(char[,] chars)
    {
        long count = 0L;

        for (int i = 1; i < chars.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < chars.GetLength(1) - 1; j++)
            {
                count += (chars[i, j] == On || chars[i, j] == Stuck) ? 1 : 0;
            }
        }

        return count;
    }

    private static void Print(char[,] chars)
    {
        for (int i = 1; i < chars.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < chars.GetLength(1) - 1; j++)
            {
                Console.Write(chars[i, j]);
            }

            Console.WriteLine();
        }
    }
}
