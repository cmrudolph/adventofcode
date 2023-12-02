using System.Globalization;

namespace AOC.CSharp;

public static class AOC2023_01
{
    private static Dictionary<string, int> Map =
        new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };

    public static long Solve1(string[] lines)
    {
        int GetLineValue(string line)
        {
            var digits = line.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToArray();
            return int.Parse($"{digits[0]}{digits[^1]}");
        }

        return lines.Select(GetLineValue).Sum();
    }

    public static long Solve2(string[] lines)
    {
        int GetLineValue(string line)
        {
            List<int> digits = new();

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];
                if (char.IsDigit(ch))
                {
                    digits.Add(int.Parse(ch.ToString()));
                }
                else
                {
                    string sub = line.Substring(i);
                    foreach (var kvp in Map)
                    {
                        if (sub.StartsWith(kvp.Key))
                        {
                            digits.Add(kvp.Value);
                        }
                    }
                }
            }

            return int.Parse($"{digits[0]}{digits[^1]}");
        }

        return lines.Select(GetLineValue).Sum();
    }
}
