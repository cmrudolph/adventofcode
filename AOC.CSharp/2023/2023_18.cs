namespace AOC.CSharp;

public static class AOC2023_18
{
    public static long Solve1(string[] lines)
    {
        Parsed Parse(string line)
        {
            string[] splits = line.Split(" ");
            return new Parsed(long.Parse(splits[1]), splits[0]);
        }

        return Solve(lines, Parse);
    }

    public static long Solve2(string[] lines)
    {
        Parsed Parse(string line)
        {
            string[] splits = line.Split("#");
            string sub = splits[1].Substring(0, 6);
            string hexAmt = sub.Substring(0, 5);
            int dirNum = int.Parse(sub[5].ToString());

            string dir = dirNum switch
            {
                0 => "R",
                1 => "D",
                2 => "L",
                3 => "U",
            };

            long amount = Convert.ToInt64(hexAmt, 16);

            return new Parsed(amount, dir);
        }

        return Solve(lines, Parse);
    }

    public static long Solve(string[] lines, Func<string, Parsed> extract)
    {
        XY curr = new(0, 0);
        List<XY> points = new();
        points.Add(curr);
        long boundaryPointCount = 0;

        foreach (string line in lines)
        {
            Parsed parsed = extract(line);

            if (parsed.Direction == "U")
            {
                curr = curr with { Y = curr.Y + parsed.Amount };
            }

            if (parsed.Direction == "L")
            {
                curr = curr with { X = curr.X - parsed.Amount };
            }

            if (parsed.Direction == "R")
            {
                curr = curr with { X = curr.X + parsed.Amount };
            }

            if (parsed.Direction == "D")
            {
                curr = curr with { Y = curr.Y - parsed.Amount };
            }

            points.Add(curr);
            boundaryPointCount += parsed.Amount;
        }

        long shiftX = Math.Abs(Math.Min(points.Min(x => x.X), 0));
        long shiftY = Math.Abs(Math.Min(points.Min(y => y.Y), 0));

        for (int i = 0; i < points.Count; i++)
        {
            XY p = points[i];
            points[i] = p with { X = p.X + shiftX, Y = p.Y + shiftY };
        }

        long sum1 = 0;
        long sum2 = 0;

        for (int i = 0; i < points.Count - 1; i++)
        {
            long x1 = points[i].X;
            long y1 = points[i + 1].Y;

            long x2 = points[i + 1].X;
            long y2 = points[i].Y;

            sum1 += (x1 * y1);
            sum2 += (x2 * y2);
        }

        long area = Math.Abs(sum2 - sum1) / 2;

        return area + boundaryPointCount / 2 + 1;
    }

    public record Parsed(long Amount, string Direction);

    private record XY(long X, long Y);
}
