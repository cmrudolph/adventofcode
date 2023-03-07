namespace AOC.CSharp;

public static class AOC2021_02
{
    public static long Solve1(string[] lines)
    {
        Position1 pos = lines
            .Select(Parse)
            .Aggregate(new Position1(0, 0), (acc, inst) => acc.Move(inst));

        return pos.X * pos.Y;
    }

    public static long Solve2(string[] lines)
    {
        Position2 pos = lines
            .Select(Parse)
            .Aggregate(new Position2(0, 0, 0), (acc, inst) => acc.Move(inst));

        return pos.X * pos.Y;
    }

    private static Instruction Parse(string line)
    {
        var splits = line.Split(' ');
        return new Instruction(splits[0], int.Parse(splits[1]));
    }

    private record Instruction(string Direction, int Amount);

    private record Position1(int X, int Y)
    {
        public Position1 Move(Instruction inst)
        {
            return inst.Direction switch
            {
                "forward" => this with { X = X + inst.Amount },
                "down" => this with { Y = Y + inst.Amount },
                "up" => this with { Y = Y - inst.Amount },
                _ => throw new NotSupportedException(),
            };
        }
    }

    private record Position2(int X, int Y, int Aim)
    {
        public Position2 Move(Instruction inst)
        {
            return inst.Direction switch
            {
                "forward" => this with { X = X + inst.Amount, Y = Y + (inst.Amount * Aim) },
                "down" => this with { Aim = Aim + inst.Amount },
                "up" => this with { Aim = Aim - inst.Amount },
                _ => throw new NotSupportedException(),
            };
        }
    }
}
