using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public static class AOC2015_19
    {
        private const int NonSolution = -1;

        private static readonly Regex Regex = new(@"(\w+) => (\w+)");

        public static long Solve1(string[] lines)
        {
            List<Tuple<string, string>> replacements = ParseReplacements(lines);
            string original = ParseOriginal(lines);

            var transformations = FindUniqueTransformations(original, replacements);

            return transformations.Count;
        }

        public static long Solve2(string[] lines)
        {
            List<Tuple<string, string>> replacements = ParseReplacements(lines);
            replacements = SwapReplacements(replacements);
            replacements = replacements.OrderByDescending(r => r.Item1.Length).ToList();

            string original = ParseOriginal(lines);

            int count = 0;
            while (original != "e")
            {
                foreach (var r in replacements)
                {
                    int index = original.IndexOf(r.Item1);
                    while (index != -1)
                    {
                        original = original.Remove(index, r.Item1.Length);
                        original = original.Insert(index, r.Item2);
                        index = original.IndexOf(r.Item1);
                        count++;
                    }
                }
            }

            return count;
        }

        private static HashSet<string> FindUniqueTransformations(
            string original,
            List<Tuple<string, string>> replacements)
        {
            HashSet<string> uniques = new();

            for (int i = 0; i < original.Length; i++)
            {
                foreach (var rep in replacements)
                {
                    string origVal = rep.Item1;
                    string replaceVal = rep.Item2;

                    if (original.Substring(i).StartsWith(origVal, StringComparison.Ordinal))
                    {
                        string result = original.Remove(i, origVal.Length).Insert(i, replaceVal);
                        uniques.Add(result);
                    }
                }
            }

            return uniques;
        }

        private static List<Tuple<string, string>> ParseReplacements(string[] lines)
        {
            List<Tuple<string, string>> replacements = new();

            for (int i = 0; i < lines.Length - 2; i++)
            {
                Match m = Regex.Match(lines[i]);
                replacements.Add(Tuple.Create(m.Groups[1].Value, m.Groups[2].Value));
            }

            return replacements;
        }

        private static List<Tuple<string, string>> SwapReplacements(List<Tuple<string, string>> replacements)
        {
            return replacements.Select(r => Tuple.Create(r.Item2, r.Item1)).ToList();
        }

        private static string ParseOriginal(string[] lines)
        {
            return lines[lines.Length - 1];
        }
    }
}