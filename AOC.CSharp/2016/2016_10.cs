using System.Text.RegularExpressions;

namespace AOC.CSharp;

public class AOC2016_10
{
    private static Regex InitialValueRegex = new Regex(@"value (\d+) goes to bot (\d+)");
    private static Regex AssignRegex = new Regex(@"bot (\d+) gives low to (\w+) (\d+) and high to (\w+) (\d+)");

    public static long Solve1(string[] lines, string extra)
    {
        int[] targets = extra.Split(',').Select(int.Parse).ToArray();
        (long result, _) = SolveBoth(lines, targets);

        return result;
    }

    public static long Solve2(string[] lines)
    {
        (_, long result) = SolveBoth(lines, new[] { 0, 0 });

        return result;
    }

    private static (long result1, long result2) SolveBoth(string[] lines, int[] targets)
    {
        var initials = lines.Select(TryParseInitial).Where(i => i != null).ToList();
        var assigns = lines.Select(TryParseAssign).Where(i => i != null).ToList();

        // Figure out how big our bot and output collections need to be based on the data we are working with
        int maxBot = Math.Max(initials.Max(i => i.Bot), assigns.Max(a => a.Bot));
        int maxOutput = Math.Max(
            assigns.Where(a => a.LowType == AssignType.Output).Max(a => a.Low),
            assigns.Where(a => a.HighType == AssignType.Output).Max(a => a.High));

        Bot[] bots = new Bot[maxBot + 1];
        int[] outputs = new int[maxOutput + 1];
        Enumerable.Range(0, maxBot + 1).ToList().ForEach(i => bots[i] = new(i));

        // Process all the initial values first
        initials.ForEach(i => bots[i.Bot].GiveValue(i.Value));

        // Now repeatedly process the assignments until they are all processed
        while (assigns.Count > 0)
        {
            for (int i = assigns.Count - 1; i >= 0; i--)
            {
                Assign a = assigns[i];
                Bot giver = bots[a.Bot];
                if (giver.Complete && !giver.Processed)
                {
                    // Give values once a bot has two chips. Only process each giver bot once.
                    if (a.LowType == AssignType.Bot)
                    {
                        Bot lowReceiver = bots[a.Low];
                        lowReceiver.GiveValue(giver.Low);
                    }
                    else
                    {
                        outputs[a.Low] = giver.Low;
                    }

                    if (a.HighType == AssignType.Bot)
                    {
                        Bot highReceiver = bots[a.High];
                        highReceiver.GiveValue(giver.High);
                    }
                    else
                    {
                        outputs[a.High] = giver.High;
                    }

                    assigns.RemoveAt(i);
                }
            }
        }

        var result1 = bots.FirstOrDefault(b => b.Low == targets[0] && b.High == targets[1])?.Num ?? 0L;
        var result2 = outputs[0] * outputs[1] * outputs[2];

        return (result1, result2);
    }

    private record InitialValue(int Bot, int Value);

    private record Assign(int Bot, AssignType LowType, int Low, AssignType HighType, int High);

    private static InitialValue TryParseInitial(string line)
    {
        Match m = InitialValueRegex.Match(line);
        if (m.Success)
        {
            int bot = int.Parse(m.Groups[2].Value);
            int value = int.Parse(m.Groups[1].Value);
            return new InitialValue(bot, value);
        }

        return null;
    }

    private static Assign TryParseAssign(string line)
    {
        Match m = AssignRegex.Match(line);
        if (m.Success)
        {
            int bot = int.Parse(m.Groups[1].Value);
            AssignType lowType = Enum.Parse<AssignType>(m.Groups[2].Value, true);
            int lowValue = int.Parse(m.Groups[3].Value);
            AssignType highType = Enum.Parse<AssignType>(m.Groups[4].Value, true);
            int highValue = int.Parse(m.Groups[5].Value);
            return new Assign(bot, lowType, lowValue, highType, highValue);
        }

        return null;
    }

    private enum AssignType
    {
        Bot,
        Output,
    }

    private class Bot
    {
        public Bot(int num)
        {
            Num = num;
        }

        List<int> _values = new(2);

        public void GiveValue(int value)
        {
            _values.Add(value);

            if (_values.Count > 2)
            {
                throw new InvalidOperationException("Tried to assign > 2 values to a bot");
            }

            if (_values.Count == 2)
            {
                _values.Sort();
                Low = _values[0];
                High = _values[1];
            }
        }

        public int Num { get; }
        public int Low { get; private set; }
        public int High { get; private set; }

        public bool Processed { get; set; }

        public bool Complete => _values.Count == 2;
    }
}
