namespace AOC.CSharp;

public static class AOC2017_13
{
    public static long Solve1(string[] lines)
    {
        List<Func<int, int?>> costFuncs = Parse(lines);

        return costFuncs.Select(f => f(0)).Where(x => x != null).Select(x => x.Value).Sum();
    }

    public static long Solve2(string[] lines)
    {
        List<Func<int, int?>> costFuncs = Parse(lines);

        int delay = 0;
        bool caught;
        do
        {
            caught = costFuncs.Select(f => f(delay)).Any(x => x != null);
            delay += caught ? 1 : 0;
        } while (caught);

        return delay;
    }

    private static List<Func<int, int?>> Parse(string[] lines)
    {
        List<Func<int, int?>> costFuncs = new();

        foreach (string line in lines)
        {
            string[] splits = line.Split(":");
            int layerNum = int.Parse(splits[0]);
            int depth = int.Parse(splits[1]);

            costFuncs.Add(BuildCostFunc(layerNum, depth));
        }

        return costFuncs;
    }

    private static Func<int, int?> BuildCostFunc(int layerNum, int depth)
    {
        int divBy = (depth - 1) * 2;
        return delay => (delay + layerNum) % divBy == 0 ? layerNum * depth : null;
    }
}
