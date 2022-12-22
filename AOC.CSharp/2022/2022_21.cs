using System.Text.RegularExpressions;
using MoreLinq.Extensions;

namespace AOC.CSharp;

public static class AOC2022_21
{
    private static readonly Regex ExpressionRe = new(@"(\w+) (.) (\w+)");

    public static long Solve1(string[] lines)
    {
        Dictionary<string, string> raw = new();
        Dictionary<string, long> sums = new();

        foreach (string line in lines)
        {
            var splits = line.Split(": ");
            raw.Add(splits[0], splits[1]);
        }

        List<string> orderedKeys = new();

        Queue<string> q = new();
        q.Enqueue("root");
        while (q.Any())
        {
            string nextKey = q.Dequeue();
            orderedKeys.Add(nextKey);
            string nextVal = raw[nextKey];

            Match m = ExpressionRe.Match(nextVal);
            if (m.Success)
            {
                Expression e = new Expression(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
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
                Expression e = new Expression(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
                Func<long, long, long> op = e.Op switch
                {
                    "+" => (a, b) => a + b,
                    "-" => (a, b) => a - b,
                    "*" => (a, b) => a * b,
                    "/" => (a, b) => a / b,
                };

                long val1 = sums[e.Left];
                long val2 = sums[e.Right];
                long total = op(val1, val2);
                sums[key] = total;
            }

            long sum = sums[key];
        }

        return sums["root"];
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private record Expression(string Left, string Op, string Right);
}
