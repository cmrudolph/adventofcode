namespace AOC.CSharp;

public static class AOC2017_18
{
    public static long Solve1(string[] lines)
    {
        Line[] parsed = lines.Select(x => new Line(x)).ToArray();
        RegisterFacade reg = new();

        long lastPlayed = 0;
        long ip = 0;

        while (true)
        {
            Line line = parsed[ip];

            switch (line.Instruction)
            {
                case "snd":
                    lastPlayed = reg.Get(line.Arg1);
                    ip++;
                    break;
                case "set":
                    reg.Set(line.Arg1, line.Arg2);
                    ip++;
                    break;
                case "add":
                    reg.Add(line.Arg1, line.Arg2);
                    ip++;
                    break;
                case "mul":
                    reg.Mul(line.Arg1, line.Arg2);
                    ip++;
                    break;
                case "mod":
                    reg.Mod(line.Arg1, line.Arg2);
                    ip++;
                    break;
                case "rcv":
                    if (reg.Get(line.Arg1) != 0)
                    {
                        return lastPlayed;
                    }

                    ip++;
                    break;
                case "jgz":
                    long amount = reg.Get(line.Arg1) > 0 ? reg.Get(line.Arg2) : 1;
                    ip += amount;
                    break;
            }
        }
    }

    public static long Solve2(string[] lines)
    {
        Line[] parsed = lines.Select(x => new Line(x)).ToArray();

        // Maintain two copies of everything - one for each program
        RegisterFacade[] reg = new RegisterFacade[2];
        Queue<long>[] queues = new Queue<long>[2];
        long[] ip = new long[2];
        bool[] isWaiting = new bool[2];
        long[] sendCounts = new long[2];

        for (int i = 0; i <= 1; i++)
        {
            reg[i] = new();
            reg[i].Set("p", i.ToString());
            queues[i] = new();
        }

        // Keep track of which program index is executing and which one is waiting
        int running = 0;
        int waiting = 1;

        while (true)
        {
            Line line = parsed[ip[running]];

            switch (line.Instruction)
            {
                case "snd":
                    sendCounts[running]++;
                    queues[waiting].Enqueue(reg[running].Get(line.Arg1));
                    ip[running]++;
                    break;
                case "set":
                    reg[running].Set(line.Arg1, line.Arg2);
                    ip[running]++;
                    break;
                case "add":
                    reg[running].Add(line.Arg1, line.Arg2);
                    ip[running]++;
                    break;
                case "mul":
                    reg[running].Mul(line.Arg1, line.Arg2);
                    ip[running]++;
                    break;
                case "mod":
                    reg[running].Mod(line.Arg1, line.Arg2);
                    ip[running]++;
                    break;
                case "rcv":
                    if (queues[running].TryDequeue(out long result))
                    {
                        // Tried to receive and had something on the queue. We can continue executing this program
                        reg[running].Set(line.Arg1, result);
                        ip[running]++;
                        isWaiting[running] = false;
                    }
                    else if (isWaiting[waiting] && queues[waiting].Count == 0)
                    {
                        // Deadlock. Neither program is able to continue since both are waiting to receive and there
                        // is nothing on either queue.
                        return sendCounts[1];
                    }
                    else
                    {
                        // Tried to receive and had nothing on the queue (but did not land in the termination condition
                        // yet). Mark this program as waiting and do a context switch
                        isWaiting[running] = true;
                        (running, waiting) = (waiting, running);
                    }

                    break;
                case "jgz":
                    long amount = reg[running].Get(line.Arg1) > 0 ? reg[running].Get(line.Arg2) : 1;
                    ip[running] += amount;
                    break;
            }
        }
    }

    private class RegisterFacade
    {
        private readonly Dictionary<string, long> _values = new();

        public void Set(string name, string value) => _values[name] = GetRegOrLiteral(value);

        public void Set(string name, long value) => _values[name] = value;

        public void Add(string name, string value) => _values[name] = Get(name) + GetRegOrLiteral(value);

        public void Mul(string name, string value) => _values[name] = Get(name) * GetRegOrLiteral(value);

        public void Mod(string name, string value) => _values[name] = Get(name) % GetRegOrLiteral(value);

        // Get the value of the register or the literal if the argument is numeric (bypass the register lookup).
        // Encapsulating the key/literal decisions here eliminates conditionals in the instruction processing
        // logic above
        public long Get(string value) => GetRegOrLiteral(value);

        private long GetRegOrLiteral(string value) => long.TryParse(value, out long parsed) ? parsed : GetReg(value);

        private long GetReg(string name) => _values.TryGetValue(name, out long value) ? value : 0L;
    }

    private class Line
    {
        public Line(string line)
        {
            string[] splits = line.Split(" ");
            Instruction = splits[0];
            Arg1 = splits[1];
            Arg2 = splits.Length == 3 ? splits[2] : null;
        }

        public string Instruction { get; }

        public string Arg1 { get; }
        public string Arg2 { get; }
    }
}