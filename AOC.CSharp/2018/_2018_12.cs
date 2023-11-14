using System.Text;

namespace AOC.CSharp;

public static class AOC2018_12
{
    public static long Solve1(string[] lines)
    {
        int padding = 40;

        string state = lines[0].Replace("initial state: ", "");
        state = new string('.', padding) + state + new string('.', padding);

        Dictionary<string, string> rules = new();

        for (int i = 2; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] splits = line.Split(" => ");
            string match = splits[0];
            string result = splits[1];

            rules.Add(match, result);
        }

        Console.WriteLine(state);

        for (int gen = 0; gen < 20; gen++)
        {
            StringBuilder nextState = new();
            nextState.Append("..");
            for (int i = 2; i < state.Length - 2; i++)
            {
                string sub = state.Substring(i - 2, 5);
                string result = rules.GetValueOrDefault(sub, ".");
                nextState.Append(result);
            }
            nextState.Append("..");

            state = nextState.ToString();

            Console.WriteLine(state);
        }

        long sum = 0;
        for (int i = 0; i < state.Length; i++)
        {
            int potNum = i - padding;
            sum += state[i] == '#' ? potNum : 0;
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        int padding = 4000;

        string state = lines[0].Replace("initial state: ", "");
        state = new string('.', padding) + state + new string('.', padding);

        Dictionary<string, string> rules = new();

        for (int i = 2; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] splits = line.Split(" => ");
            string match = splits[0];
            string result = splits[1];

            rules.Add(match, result);
        }

        for (int gen = 0; gen < 500; gen++)
        {
            StringBuilder nextState = new();
            nextState.Append("..");
            for (int i = 2; i < state.Length - 2; i++)
            {
                string sub = state.Substring(i - 2, 5);
                string result = rules.GetValueOrDefault(sub, ".");
                nextState.Append(result);
            }
            nextState.Append("..");

            state = nextState.ToString();

            long sum = 0;
            for (int i = 0; i < state.Length; i++)
            {
                int potNum = i - padding;
                sum += state[i] == '#' ? potNum : 0;
            }

            // Look at the last 10 or so generations. Find the pattern. Reverse engineer
            // the formula. Calculate for the 50 billion case
            Console.WriteLine("{0}: {1}", gen + 1, sum);
        }

        return -1;
    }
}
