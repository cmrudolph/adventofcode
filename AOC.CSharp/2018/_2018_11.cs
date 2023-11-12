namespace AOC.CSharp;

public static class AOC2018_11
{
    public static string Solve1(string[] lines)
    {
        int input = int.Parse(lines[0]);
        var levels = CalculateLevels(1, 300, input);
        var gridLevels = CalculateGridLevels(levels, 1, 300);
        var biggest = gridLevels.OrderByDescending(kvp => kvp.Value).First().Key;
        
        return $"{biggest.X},{biggest.Y}";
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private static Dictionary<XY, long> CalculateLevels(int min, int max, int input)
    {
        Dictionary<XY, long> dict = new();
        
        for (int x = min; x <= max; x++)
        {
            for (int y = min; y <= max; y++)
            {
                XY xy = new(x, y);
                dict.Add(xy, CalculatePowerLevel(xy, input));
            }
        }

        return dict;
    }

    private static Dictionary<XY, long> CalculateGridLevels(Dictionary<XY, long> lookup, int min, int max)
    {
        Dictionary<XY, long> dict = new();
        
        for (int cornerX = min; cornerX <= max - 2; cornerX++)
        {
            for (int cornerY = min; cornerY <= max - 2; cornerY++)
            {
                XY cornerXY = new(cornerX, cornerY);
                long sum = 0;
                
                for (int x = cornerX; x <= cornerX + 2; x++)
                {
                    for (int y = cornerY; y <= cornerY + 2; y++)
                    {
                        XY xy = new(x, y);
                        sum += lookup[xy];
                    }
                }

                dict.Add(cornerXY, sum);
            }
        }

        return dict;
    }
    
    private static long CalculatePowerLevel(XY xy, int input)
    {
        long rackId = xy.X + 10;
        long power = rackId * xy.Y;
        power += input;
        power *= rackId;
        power /= 100;
        long digit = power % 10;

        return digit - 5;
    }
    
    private record XY(int X, int Y);
}
