namespace AOC.CSharp;

public static class AOC2017_03
{
    private static readonly Dictionary<Directions, DirectionInfo> DirectionLookup =
        new()
        {
            {
                Directions.Right,
                new DirectionInfo(Directions.Up, 0, xy => xy with { X = xy.X + 1 })
            },
            {
                Directions.Up,
                new DirectionInfo(Directions.Left, 1, xy => xy with { Y = xy.Y - 1 })
            },
            {
                Directions.Left,
                new DirectionInfo(Directions.Down, 0, xy => xy with { X = xy.X - 1 })
            },
            {
                Directions.Down,
                new DirectionInfo(Directions.Right, 1, xy => xy with { Y = xy.Y + 1 })
            },
        };

    public static long Solve1(string[] lines)
    {
        return SolveBoth(int.Parse(lines[0])).Item1;
    }

    public static long Solve2(string[] lines)
    {
        return SolveBoth(int.Parse(lines[0])).Item2;
    }

    private static (int, int) SolveBoth(int target)
    {
        int dimensions = (int)Math.Sqrt(target) + 10;
        int[,] a = new int[dimensions, dimensions];

        XY start = new(dimensions / 2, dimensions / 2);
        XY curr = start;

        int nextDirectionTravelAmount = 1;
        int remainingTravelAmount = 1;
        Directions direction = Directions.Right;

        int? part2Result = null;

        for (int i = 1; i < target; i++)
        {
            int neighborSum = Math.Max(1, SumNeighbors(a, curr));
            a[curr.X, curr.Y] = neighborSum;
            if (!part2Result.HasValue && neighborSum > target)
            {
                part2Result = neighborSum;
            }

            var initialInfo = DirectionLookup[direction];
            if (remainingTravelAmount == 0)
            {
                // Not going any further in this direction. Time to turn and reset the
                // steps we need to head in the next direction. This step count grows when
                // we make certain turns
                direction = initialInfo.Next;
                nextDirectionTravelAmount += initialInfo.StartAdjust;
                remainingTravelAmount = nextDirectionTravelAmount;
            }

            // Advance one in the proper direction and adjust our coordinates
            var revisedInfo = DirectionLookup[direction];
            curr = revisedInfo.PosAdjust(curr);
            remainingTravelAmount--;
        }

        return (Math.Abs(curr.X - start.X) + Math.Abs(curr.Y - start.Y), part2Result.Value);
    }

    private static int SumNeighbors(int[,] grid, XY curr)
    {
        int sum = 0;
        sum += grid[curr.X - 1, curr.Y - 1]; // NW
        sum += grid[curr.X, curr.Y - 1]; // N
        sum += grid[curr.X + 1, curr.Y - 1]; // NE
        sum += grid[curr.X + 1, curr.Y]; // E
        sum += grid[curr.X + 1, curr.Y + 1]; // SE
        sum += grid[curr.X, curr.Y + 1]; // S
        sum += grid[curr.X - 1, curr.Y + 1]; // SW
        sum += grid[curr.X - 1, curr.Y]; // W

        return sum;
    }

    private enum Directions
    {
        Right,
        Up,
        Left,
        Down,
    }

    private record DirectionInfo(Directions Next, int StartAdjust, Func<XY, XY> PosAdjust);

    private record XY(int X, int Y);
}
