namespace AOC.CSharp;

public static class AOC2022_25
{
    public static string Solve1(string[] lines)
    {
        return ToSnafu(lines.Select(ToDecimal).Sum());
    }

    public static string Solve2(string[] lines)
    {
        return null;
    }

    public static long ToDecimal(string line)
    {
        long total = 0;
        long multiplier = 1;
        for (int j = line.Length - 1; j >= 0; j--)
        {
            char ch = line[j];
            int decCharValue = ch switch
            {
                '=' => -2,
                '-' => -1,
                '0' => 0,
                '1' => 1,
                '2' => 2,
                _ => throw new NotSupportedException(),
            };

            long thisSpot = decCharValue * multiplier;
            total += thisSpot;
            multiplier *= 5;
        }

        return total;
    }

    public static string ToSnafu(long val)
    {
        string result = "";

        int place = 20;
        while (place >= 0)
        {
            long multiplier = place == 0 ? 1 : (long)Math.Pow(5, place);

            decimal quotient = ((decimal)val) / multiplier;
            long rounded = (long)Math.Round(quotient);
            long toReduce = rounded * multiplier;
            if (result.Length > 0 || rounded > 0)
            {
                char toAppend = rounded switch
                {
                    2 => '2',
                    1 => '1',
                    0 => '0',
                    -1 => '-',
                    -2 => '=',
                    _ => throw new NotSupportedException(),
                };

                result += toAppend;
                val -= toReduce;
            }

            place--;
        }

        return result;
    }
}
