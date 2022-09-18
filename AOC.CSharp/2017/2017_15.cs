namespace AOC.CSharp;

public static class AOC2017_15
{
    public static long Solve1(string[] lines)
    {
        (long a, long b) = Parse(lines);

        long matches = 0;
        for (int i = 0; i < 40000000; i++)
        {
            (a, b) = NextValues(a, b);
            bool match = Low16BitsMatch(a, b);
            matches += match ? 1 : 0;
        }

        return matches;
    }

    public static long Solve2(string[] lines)
    {
        (long a, long b) = Parse(lines);

        long matches = 0;
        for (int i = 0; i < 5000000; i++)
        {
            (a, b) = NextValues2(a, b);
            bool match = Low16BitsMatch(a, b);
            matches += match ? 1 : 0;
        }

        return matches;
    }

    private static (long, long) Parse(string[] lines)
    {
        long a = long.Parse(lines[0].Split(" with ")[1]);
        long b = long.Parse(lines[1].Split(" with ")[1]);

        return (a, b);
    }

    private static (long, long) NextValues(long a, long b)
    {
        long NextValue(long curr, long factor)
        {
            return (curr * factor) % 2147483647;
        }

        long nextA = NextValue(a, 16807);
        long nextB = NextValue(b, 48271);

        return (nextA, nextB);
    }

    private static (long, long) NextValues2(long a, long b)
    {
        long NextValue(long curr, long factor, int multipleOf)
        {
            long val = curr;
            do
            {
                val = (val * factor) % 2147483647;
            } while (val % multipleOf != 0);

            return val;
        }

        long nextA = NextValue(a, 16807, 4);
        long nextB = NextValue(b, 48271, 8);

        return (nextA, nextB);
    }

    private static bool Low16BitsMatch(long a, long b)
    {
        long lowA = a & 0xFFFF;
        long lowB = b & 0xFFFF;

        return lowA == lowB;
    }
}
