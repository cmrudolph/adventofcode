namespace AOC.CSharp;

public class AOC2016_23
{
    public static long Solve1(string[] lines)
    {
        Registers registers = new();
        registers.Set("a", 7);
        return Solve(registers, lines);
    }

    public static long Solve2(string[] lines)
    {
        // Solve 7-10 to get answers we can use to infer a pattern
        //for (int i = 7; i <= 10; i++)
        //{
        //    Registers registers = new();
        //    registers.Set("a", 12);
        //    long result = Solve(registers, lines);
        //    Console.WriteLine("{0} -> {1}", i, result);
        //}

        Registers registers = new();
        registers.Set("a", 7);
        long solution = Solve(registers, lines);

        // Solve a fast and simple case and use the formula we derived to compute versions that get MUCH
        // more expensive to solve by going through the motions. The solution is easy to compute using the
        // previous solution and a bit of factorial math.
        for (int i = 8; i <= 12; i++)
        {
            long prevFact = Factorial(i - 1);
            long fact = Factorial(i);
            solution = solution + fact - prevFact;
        }

        return solution;
    }

    private static long Factorial(int n)
    {
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    private static long Solve(Registers registers, string[] lines)
    {
        List<Command> commands = lines.Select(Parse).ToList();

        int j = 0;
        int i = 0;
        while (i < commands.Count)
        {
            int iStart = i;
            j++;
            Command c = commands[i];

            switch (c.Type)
            {
                case CommandType.Copy:
                    {
                        int value = c.Arg1IsInt ? int.Parse(c.Arg1) : registers.Get(c.Arg1);
                        if (c.Arg2IsString)
                        {
                            registers.Set(c.Arg2, value);
                        }
                        i++;
                        break;
                    }
                case CommandType.Increment:
                    {
                        if (c.Arg1IsString)
                        {
                            registers.Transform(c.Arg1, v => v + 1);
                        }
                        i++;
                        break;
                    }
                case CommandType.Decrement:
                    {
                        if (c.Arg1IsString)
                        {
                            registers.Transform(c.Arg1, v => v - 1);
                        }
                        i++;
                        break;
                    }
                case CommandType.JumpNotZero:
                    {
                        int cmpValue = c.Arg1IsInt ? int.Parse(c.Arg1) : registers.Get(c.Arg1);
                        int jmpAmount = cmpValue == 0
                            ? 1
                            : c.Arg2IsInt
                                ? int.Parse(c.Arg2)
                                : registers.Get(c.Arg2);
                        i += jmpAmount;
                        break;
                    }
                case CommandType.Toggle:
                    {
                        int offsetValue = c.Arg1IsInt ? int.Parse(c.Arg1) : registers.Get(c.Arg1);
                        int targetIdx = i + offsetValue;
                        if (targetIdx >= 0 && targetIdx < commands.Count)
                        {
                            Command tgt = commands[targetIdx];
                            switch (tgt.Type)
                            {
                                case CommandType.Increment:
                                    commands[targetIdx] = new Command(CommandType.Decrement, tgt.Arg1);
                                    break;
                                case CommandType.Decrement:
                                case CommandType.Toggle:
                                    commands[targetIdx] = new Command(CommandType.Increment, tgt.Arg1);
                                    break;
                                case CommandType.Copy:
                                    commands[targetIdx] = new Command(CommandType.JumpNotZero, tgt.Arg1, tgt.Arg2);
                                    break;
                                case CommandType.JumpNotZero:
                                    commands[targetIdx] = new Command(CommandType.Copy, tgt.Arg1, tgt.Arg2);
                                    break;
                            }
                        }

                        i++;
                        break;
                    }
            }
        }

        return registers.Get("a");
    }

    private static Command Parse(string line)
    {
        string[] splits = line.Split(" ");
        string inst = splits[0];

        return inst switch
        {
            "cpy" => new Command(CommandType.Copy, splits[1], splits[2]),
            "inc" => new Command(CommandType.Increment, splits[1]),
            "dec" => new Command(CommandType.Decrement, splits[1]),
            "jnz" => new Command(CommandType.JumpNotZero, splits[1], splits[2]),
            "tgl" => new Command(CommandType.Toggle, splits[1]),
        };
    }

    private class Command
    {
        public Command(CommandType type, string arg1, string arg2 = null)
        {
            Type = type;
            Arg1 = arg1;
            Arg2 = arg2;
        }

        public CommandType Type { get; }

        public string Arg1 { get; }

        public string Arg2 { get; }

        public bool Arg1IsInt => int.TryParse(Arg1, out var _);

        public bool Arg2IsInt => int.TryParse(Arg2, out var _);

        public bool Arg1IsString => !Arg1IsInt;

        public bool Arg2IsString => !Arg2IsInt;

        public override string ToString()
        {
            string cmd = Type switch
            {
                CommandType.Copy => "cpy",
                CommandType.Increment => "inc",
                CommandType.Decrement => "dec",
                CommandType.JumpNotZero => "jnz",
                CommandType.Toggle => "tgl",
            };

            return $"{cmd} {Arg1} {Arg2}";
        }
    }

    private enum CommandType
    {
        Copy,
        Increment,
        Decrement,
        JumpNotZero,
        Toggle
    }

    private class Registers
    {
        private const int DefaultValue = 0;

        private readonly Dictionary<string, int> _dict = new();

        public void Set(string reg, int value)
        {
            _dict[reg] = value;
        }

        public int Get(string reg)
        {
            return _dict.TryGetValue(reg, out int existing) ? existing : DefaultValue;
        }

        public void Transform(string reg, Func<int, int> transformer)
        {
            int existing = Get(reg);
            int transformed = transformer(existing);
            Set(reg, transformed);
        }
    }
}
