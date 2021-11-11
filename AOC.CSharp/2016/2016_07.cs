using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp;

public static class AOC2016_07
{
    public static long Solve1(string[] lines)
    {
        int count = 0;
        foreach (string line in lines)
        {
            var inside = FindSequences(line, 4, true, GetAbbaSequence).ToList();
            var outside = FindSequences(line, 4, false, GetAbbaSequence).ToList();
            count += outside.Any() && !inside.Any() ? 1 : 0;
        }

        return count;
    }

    public static long Solve2(string[] lines)
    {
        int count = 0;
        foreach (string line in lines)
        {
            var insideTransformed = FindSequences(line, 3, true, GetAbaSequence)
                .Select(TransformAba)
                .ToHashSet();

            var outside = FindSequences(line, 3, false, GetAbaSequence).ToList();
            bool valid = outside.Any(o => insideTransformed.Contains(o));

            count += valid ? 1 : 0;
        }

        return count;
    }

    private static List<string> FindSequences(
        string s,
        int length,
        bool inside,
        Func<string, int, string> getSequence)
    {
        List<string> results = new();
        bool isInside = false;

        for (int i = 0; i < s.Length - (length - 1); i++)
        {
            if (s[i] == '[')
            {
                isInside = true;
            }
            if (s[i] == ']')
            {
                isInside = false;
            }

            string sequence = getSequence(s, i);
            if (sequence != null && inside == isInside)
            {
                results.Add(sequence);
            }
        }

        return results;
    }

    private static string GetAbbaSequence(string s, int start)
    {
        int end = start + 3;
        if (end < s.Length)
        {
            bool isSequence =
                s[start] == s[start + 3]
                && s[start + 1] == s[start + 2]
                && s[start] != s[start + 1];

            if (isSequence)
            {
                return s.Substring(start, 4);
            }
        }

        return null;
    }

    private static string GetAbaSequence(string s, int start)
    {
        int end = start + 2;
        if (end < s.Length)
        {
            bool isSequence =
                s[start] == s[start + 2]
                && s[start] != s[start + 1];

            if (isSequence)
            {
                Console.WriteLine(s.Substring(start, 3));
                return s.Substring(start, 3);
            }
        }

        return null;
    }

    private static string TransformAba(string aba)
    {
        return new string(new[] { aba[1], aba[0], aba[1] });
    }
}
