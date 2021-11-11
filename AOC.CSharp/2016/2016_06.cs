using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AOC.CSharp;

public static class AOC2016_06
{
    public static string Solve1(string[] lines)
    {
        return FindPassword(lines, (newVal, oldVal) => newVal > oldVal);
    }

    public static string Solve2(string[] lines)
    {
        return FindPassword(lines, (newVal, oldVal) => newVal < oldVal);
    }

    private static string FindPassword(string[] lines, Func<int, int, bool> isBetterThan)
    {
        Dictionary<char, int>[] counts = new Dictionary<char, int>[lines[0].Length];
        for (int i = 0; i < lines[0].Length; i++)
        {
            counts[i] = new();
        }

        foreach (string line in lines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];
                if (counts[i].TryGetValue(ch, out int _))
                {
                    counts[i][ch]++;
                }
                else
                {
                    counts[i].Add(ch, 1);
                }
            }
        }

        List<char> result = new();
        for (int i = 0; i < lines[0].Length; i++)
        {
            int? bestCount = null;
            char? bestChar = null;

            foreach (var kvp in counts[i])
            {
                if (!bestCount.HasValue || isBetterThan(kvp.Value, bestCount.Value))
                {
                    bestCount = kvp.Value;
                    bestChar = kvp.Key;
                }
            }

            result.Add(bestChar.Value);
        }

        return new string(result.ToArray());
    }
}
