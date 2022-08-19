using System.Text;
using MoreLinq;

namespace AOC.CSharp;

public static class AOC2021_24
{
    public static long Solve1(string[] lines)
    {
        Vars vars = new();

        List<PartialResults> results = new();

        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    for (int l = 1; l <= 9; l++)
                    {
                        string model = $"11111111{i}{j}{k}{l}";
                        var pr = Process(model, vars, lines, 12);
                        results.Add(pr);
                    }
                }
            }
        }

        File.WriteAllLines(@"c:\temp\202124dbg.txt", results.OrderByDescending(r => r.Z).Select(r => string.Join(",", r.W) + " -> " + ToBase26(r.Z) + " -> " + r.Z));

        // Process("21111111111111", vars, lines);
        // Process("31111111111111", vars, lines);
        // Process("41111111111111", vars, lines);
        // Process("51111111111111", vars, lines);
        // Process("61111111111111", vars, lines);
        // Process("71111111111111", vars, lines);
        // Process("81111111111111", vars, lines);
        // Process("91111111111111", vars, lines);
        // Process("13579246899999", vars, lines);

        return 0L;
    }

    public static long Solve2(string[] lines)
    {
        return 0L;
    }

    private static string ToBase26(long value)
    {
        StringBuilder sb = new();
        while (value > 0)
        {
            long remainder = value % 26;
            value /= 26;
            if (remainder <= 9)
            {
                sb.Append(remainder);
            }
            else
            {
                sb.Append((char)('A' + (remainder - 10)));
            }
        }

        return sb.ToString();
    }

    private static PartialResults Process(string model, Vars vars, string[] lines, int depth)
    {
        int modelIdx = 0;
        List<long> w = new();

        foreach (string line in lines)
        {
            string[] splits = line.Split(' ');
            string inst = splits[0];
            string target = splits[1];
            switch (inst)
            {
                case "inp":
                {
                    long value = model[modelIdx++] - '0';
                    w.Add(value);
                    vars.Set(target, value);
                    if (modelIdx == depth)
                    {
                        return new(w.ToArray(), vars.Get("z"));
                    }
                    break;
                }
                case "add":
                {
                    long toAdd = InterpretValue(splits[2], vars);
                    vars.Transform(target, old => old + toAdd);
                    break;
                }
                case "mul":
                {
                    long toMul = InterpretValue(splits[2], vars);
                    vars.Transform(target, old => old * toMul);
                    break;
                }
                case "div":
                {
                    long toDivBy = InterpretValue(splits[2], vars);
                    vars.Transform(target, old => old / toDivBy);
                    break;
                }
                case "mod":
                {
                    long toModBy = InterpretValue(splits[2], vars);
                    vars.Transform(target, old => old % toModBy);
                    break;
                }
                case "eql":
                {
                    long toCompare1 = vars.Get(target);
                    long toCompare2 = InterpretValue(splits[2], vars);
                    int result = toCompare1 == toCompare2 ? 1 : 0;
                    vars.Transform(target, _ => result);
                    break;
                }
            }
        }

        return null;
    }

    private static long InterpretValue(string raw, Vars vars)
    {
        return char.IsLetter(raw[0])
            ? vars.Get(raw)
            : long.Parse(raw);
    }

    public class Vars
    {
        public Vars()
        {
            Set("w", 0);
            Set("x", 0);
            Set("y", 0);
            Set("z", 0);
        }

        private Dictionary<string, long> _values = new();

        public long Get(string target)
        {
            return _values[target];
        }

        public void Set(string target, long value)
        {
            _values[target] = value;
        }

        public void Transform(string target, Func<long, long> transformer)
        {
            _values[target] = transformer(_values[target]);
        }
    }

    private record PartialResults(long[] W, long Z);
}
