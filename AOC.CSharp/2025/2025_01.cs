namespace AOC.CSharp;

public static class AOC2025_01
{
    public static long Solve1(string[] lines)
    {
        int pos = 50;
        int count = 0;

        foreach (string line in lines)
        {
            int multiplier = line[0] == 'L' ? -1 : 1;
            int rawAmount = int.Parse(line[1..]);
            int cappedAmount = rawAmount % 100;
            int finalAmount = cappedAmount * multiplier;

            pos += finalAmount;
            if (pos < 0)
            {
                pos += 100;
            }

            if (pos >= 100)
            {
                pos -= 100;
            }

            if (pos == 0)
            {
                count++;
            }

            Console.WriteLine("{0} : {1}", line, pos);
        }

        return count;
    }

    public static long Solve2(string[] lines)
    {
        int pos = 50;
        int count = 0;

        foreach (string line in lines)
        {
            int step = line[0] == 'L' ? -1 : 1;
            int rawAmount = int.Parse(line[1..]);

            while (rawAmount > 0)
            {
                pos += step;
                if (pos == 0)
                {
                    count++;
                }
                else if (pos == 100)
                {
                    count++;
                    pos = 0;
                }
                else if (pos == -100)
                {
                    count++;
                    pos = 0;
                }

                rawAmount--;
            }
        }

        return count;
    }
}
