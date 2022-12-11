namespace AOC.CSharp;

public static class AOC2022_11
{
    public static long Solve1(string[] lines)
    {
        var monkeys = Monkey.Parse(lines);

        // Always reduce by dividing by 3
        return Solve(monkeys, x => x / 3, 20);
    }

    public static long Solve2(string[] lines)
    {
        var monkeys = Monkey.Parse(lines);
        long product = monkeys.Select(x => x.TestVal).Aggregate(1, (acc, x) => acc * x);

        // Manage worry by taking the mod of the product of all the individual test values. This means we will not lose
        // any correctness in our divisibility checks. However, we will keep the number small enough to be manageable.
        return Solve(monkeys, x => x % product, 10000);
    }

    private static long Solve(List<Monkey> monkeys, Func<long, long> manage, int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            for (int j = 0; j < monkeys.Count; j++)
            {
                Monkey m = monkeys[j];
                for (int k = 0; k < m.Items.Count; k++)
                {
                    long val = m.Items[k];
                    m.InspectionCount++;

                    // Apply the modification operation to the item
                    val = m.Operation(val);

                    // Apply the worry management strategy
                    val = manage(val);

                    // Pass the item to the proper recipient
                    int target = m.Test(val) ? m.TrueSendTo : m.FalseSendTo;
                    monkeys[target].Items.Add(val);
                }

                // All items have been passed off
                m.Items.Clear();
            }
        }

        var topTwo = monkeys.Select(x => x.InspectionCount).OrderByDescending(x => x).Take(2).ToList();

        return topTwo[0] * topTwo[1];
    }

    private class Monkey
    {
        public static List<Monkey> Parse(string[] lines)
        {
            List<Monkey> monkeys = new();

            Monkey m = new();
            for (int i = 0; i < lines.Length; i += 7)
            {
                string starting = lines[i + 1];
                string op = lines[i + 2];
                string test = lines[i + 3];
                string ifTrue = lines[i + 4];
                string ifFalse = lines[i + 5];

                m = new Monkey
                {
                    Items = starting.Split(":")[1].Split(",").Select(long.Parse).ToList(),
                    Operation = old =>
                    {
                        if (op.Contains("+ old"))
                        {
                            return old + old;
                        }

                        if (op.Contains("* old"))
                        {
                            return old * old;
                        }

                        if (op.Contains("+"))
                        {
                            return old + long.Parse(op.Split("+")[1]);
                        }

                        if (op.Contains("*"))
                        {
                            return old * long.Parse(op.Split("*")[1]);
                        }

                        throw new InvalidOperationException();
                    },
                    TestVal = int.Parse(test.Split("by")[1]),
                    Test = old =>
                    {
                        long divBy = long.Parse(test.Split("by")[1]);
                        return old % divBy == 0;
                    },
                    TrueSendTo = int.Parse(ifTrue.Split("monkey")[1]),
                    FalseSendTo = int.Parse(ifFalse.Split("monkey")[1]),
                };

                monkeys.Add(m);
            }

            return monkeys;
        }

        public List<long> Items { get; set; }
        public Func<long, long> Operation { get; set; }
        public Func<long, bool> Test { get; set; }
        public int TrueSendTo { get; set; }
        public int FalseSendTo { get; set; }
        public long InspectionCount { get; set; }
        public int TestVal { get; set; }
    }
}
