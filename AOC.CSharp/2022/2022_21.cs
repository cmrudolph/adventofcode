using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2022_21
{
    private static readonly Regex ExpressionRe = new(@"(\w+) (.) (\w+)");

    public static long Solve1(string[] lines)
    {
        Dictionary<string, string> raw = Parse(lines);
        Dictionary<string, decimal> sums = new();
        List<string> orderedKeys = new();
        Queue<string> q = new();

        // Use a queue to put things in the proper dependency order
        q.Enqueue("root");
        while (q.Any())
        {
            string nextKey = q.Dequeue();
            orderedKeys.Add(nextKey);
            string nextVal = raw[nextKey];

            Match m = ExpressionRe.Match(nextVal);
            if (m.Success)
            {
                Expression e = new(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
                q.Enqueue(e.Left);
                q.Enqueue(e.Right);
            }
            else
            {
                long val = long.Parse(nextVal);
                sums[nextKey] = val;
            }
        }

        for (int i = orderedKeys.Count - 1; i >= 0; i--)
        {
            string key = orderedKeys[i];
            string nextVal = raw[key];
            Match m = ExpressionRe.Match(nextVal);
            if (m.Success)
            {
                // If the node references an expression, evaluate the expression
                Expression e = new(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
                Eval(sums, e, key);
            }
        }

        // Since we processed things in dependency order, we know we can ask for the root and it will have been totaled
        return (long)sums["root"];
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<string, string> raw = Parse(lines);
        Dictionary<string, decimal> sums = new();
        List<string> orderedKeys = new();
        Queue<string> q = new();

        // Use a queue to put things in the proper dependency order
        q.Enqueue("root");
        while (q.Any())
        {
            string nextKey = q.Dequeue();
            orderedKeys.Add(nextKey);
            string nextVal = raw[nextKey];

            Match m = ExpressionRe.Match(nextVal);
            if (m.Success)
            {
                Expression e = new(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
                q.Enqueue(e.Left);
                q.Enqueue(e.Right);
            }
            else
            {
                long val = long.Parse(nextVal);
                sums[nextKey] = val;
            }
        }

        long low = 0;
        long high = long.MaxValue;
        long humn = high / 2;

        // We need to bisect our way to a solution. Consider the entire set of long integers since we are cutting
        // the search space in half each time.
        while (true)
        {
            // Set the humn node to our guess and take a fresh copy of the dictionary to work against (contains all the
            // static values from parsing)
            var sumsCopy = sums.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            sumsCopy["humn"] = humn;

            for (int i = orderedKeys.Count - 1; i >= 0; i--)
            {
                string key = orderedKeys[i];
                string nextVal = raw[key];
                Match m = ExpressionRe.Match(nextVal);
                if (m.Success)
                {
                    Expression e = new(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);

                    if (key == "root")
                    {
                        decimal leftVal = sumsCopy[e.Left];
                        decimal rightVal = sumsCopy[e.Right];

                        Console.WriteLine(
                            "HUM:{0} L:{1} H:{2} LF:{3} RT:{4} DF:{5}",
                            humn,
                            low,
                            high,
                            leftVal,
                            rightVal,
                            leftVal - rightVal
                        );

                        if (leftVal == rightVal)
                        {
                            // We made it to the root and things are equal. This is our solution.
                            return humn;
                        }

                        if (leftVal > rightVal)
                        {
                            // Need to go lower. Reset the boundaries, pick a new guess in the middle, and continue
                            high = humn;
                            humn = (high + low) / 2L;
                        }
                        else if (leftVal < rightVal)
                        {
                            // Need to go higher. Reset the boundaries, pick a new guess in the middle, and continue
                            low = humn;
                            humn = (high + low) / 2L;
                        }
                    }

                    Eval(sumsCopy, e, key);
                }
            }
        }
    }

    private static void Eval(Dictionary<string, decimal> sums, Expression e, string key)
    {
        // It is important that we use decimal here for part 2 since integer-based division will result in the wrong answer
        Func<decimal, decimal, decimal> op = e.Op switch
        {
            "+" => (a, b) => a + b,
            "-" => (a, b) => a - b,
            "*" => (a, b) => a * b,
            "/" => (a, b) => a / b,
            _ => throw new NotSupportedException(),
        };

        decimal val1 = sums[e.Left];
        decimal val2 = sums[e.Right];
        decimal total = op(val1, val2);
        sums[key] = total;
    }

    private static Dictionary<string, string> Parse(string[] lines)
    {
        Dictionary<string, string> raw = new();

        foreach (string line in lines)
        {
            var splits = line.Split(": ");
            raw.Add(splits[0], splits[1]);
        }

        return raw;
    }

    private record Expression(string Left, string Op, string Right);
}
