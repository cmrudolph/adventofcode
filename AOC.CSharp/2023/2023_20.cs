namespace AOC.CSharp;

public static class AOC2023_20
{
    public static long Solve1(string[] lines)
    {
        Dictionary<string, Module> modules = lines
            .Select(x => new Module(x))
            .ToDictionary(x => x.Name);

        foreach (Module m in modules.Values)
        {
            foreach (string output in m.Outputs)
            {
                if (modules.ContainsKey(output))
                {
                    modules[output].RegisterInput(m.Name);
                }
            }
        }

        long lowCount = 0;
        long highCount = 0;

        for (int i = 0; i < 1000; i++)
        {
            lowCount++; // Button
            Queue<Event> events = new();
            var broad = modules["broadcaster"];
            foreach (string output in broad.Outputs)
            {
                events.Enqueue(new(broad.Name, PulseType.Low, output));
                lowCount++;
            }

            while (events.Count > 0)
            {
                Event deq = events.Dequeue();

                //Console.WriteLine("{0} -{1}-> {2}", deq.Source, deq.Type, deq.Dest);

                Module dest = modules.GetValueOrDefault(deq.Dest, null);
                if (dest != null)
                {
                    PulseType? toSend = dest.ReceivePulse(deq.Source, deq.Type);
                    if (toSend.HasValue)
                    {
                        foreach (string output in dest.Outputs)
                        {
                            Event e = new(dest.Name, toSend.Value, output);
                            events.Enqueue(e);

                            if (toSend == PulseType.High)
                            {
                                highCount++;
                            }
                            else
                            {
                                lowCount++;
                            }
                        }
                    }
                }
            }
        }

        return lowCount * highCount;
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    public class Module
    {
        public Module(string line)
        {
            IsFlipFlop = line[0] == '%';
            IsConjunction = line[0] == '&';
            IsBroadcaster = line.StartsWith("broad");

            string[] splits = line.Split(" -> ");
            if (IsFlipFlop || IsConjunction)
            {
                Name = splits[0].Substring(1);
            }
            else
            {
                Name = splits[0];
            }

            Outputs = splits[1].Split(", ");
        }

        public string Name { get; }
        public string[] Outputs { get; }

        public bool IsBroadcaster { get; }

        public bool IsFlipFlop { get; }
        public bool FlipFlopOn { get; set; }

        public bool IsConjunction { get; }
        public Dictionary<string, PulseType> ConjunctionPulses { get; } = new();

        public void RegisterInput(string input)
        {
            if (IsConjunction)
            {
                ConjunctionPulses.Add(input, PulseType.Low);
            }
        }

        public PulseType? ReceivePulse(string from, PulseType type)
        {
            if (type == PulseType.High)
            {
                if (IsFlipFlop)
                {
                    return null;
                }

                if (IsConjunction)
                {
                    ConjunctionPulses[from] = PulseType.High;
                    if (ConjunctionPulses.All(x => x.Value == PulseType.High))
                    {
                        return PulseType.Low;
                    }

                    return PulseType.High;
                }

                return PulseType.High;
            }
            else
            {
                if (IsConjunction)
                {
                    ConjunctionPulses[from] = PulseType.Low;
                    return PulseType.High;
                }

                if (IsFlipFlop)
                {
                    FlipFlopOn = !FlipFlopOn;
                    return FlipFlopOn ? PulseType.High : PulseType.Low;
                }

                return PulseType.Low;
            }
        }
    }

    private record Event(string Source, PulseType Type, string Dest);

    public enum PulseType
    {
        High,
        Low,
    }
}
