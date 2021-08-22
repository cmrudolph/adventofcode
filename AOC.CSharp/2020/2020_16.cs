using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public static class AOC2020_16
    {
        private static long Solve(string[] lines, bool part1Only)
        {
            static bool IsValidForOne(int value, RuleDefinition rule)
            {
                return value >= rule.Min1 && value <= rule.Max1 || value >= rule.Min2 && value <= rule.Max2;
            }

            static bool IsValidForAll(int value, IEnumerable<RuleDefinition> rules)
            {
                return rules.Any(rule => IsValidForOne(value, rule));
            }

            Regex ruleRegex = new(@"(.*): (\d+)-(\d+) or (\d+)-(\d+)");
            var rules = lines
                .Select(line => ruleRegex.Match(line))
                .Where(m => m.Success)
                .Select(m => RuleDefinition.Create(m))
                .ToList();

            List<int> invalidValues = new();
            List<int[]> tickets = new();
            int[] yours = null;

            int line = 0;
            bool validating = false;
            while (line < lines.Length)
            {
                if (string.IsNullOrWhiteSpace(lines[line]))
                {
                    line++;
                    continue;
                }

                if (lines[line].StartsWith("your ticket:"))
                {
                    yours = lines[line + 1].Split(',').Select(int.Parse).ToArray();
                }
                else if (lines[line].StartsWith("nearby tickets:"))
                {
                    validating = true;
                }
                else if (yours != null || validating)
                {
                    int[] ticketValues = lines[line].Split(',').Select(int.Parse).ToArray();
                    var invalidForThisTicket = ticketValues.Where(value => !IsValidForAll(value, rules)).ToList();
                    if (validating)
                    {
                        invalidValues.AddRange(invalidForThisTicket);
                    }

                    if (!invalidForThisTicket.Any())
                    {
                        tickets.Add(ticketValues);
                    }
                }

                line++;
            }

            if (part1Only)
            {
                return invalidValues.Sum();
            }

            int cols = tickets[0].Length;
            List<ColumnValueSet> colValSets = new();
            for (int i = 0; i < cols; i++)
            {
                List<int> colValues = new();
                for (int j = 0; j < tickets.Count; j++)
                {
                    colValues.Add(tickets[j][i]);
                }

                colValSets.Add(new ColumnValueSet(i, colValues, rules));
            }

            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int idx = 0; idx < colValSets.Count; idx++)
                {
                    if (colValSets[idx].SingleRule != null)
                    {
                        for (int idx2 = 0; idx2 < colValSets.Count; idx2++)
                        {
                            changed |= colValSets[idx2].RemoveRule(colValSets[idx].SingleRule);
                        }
                    }
                }
            }

            long product = 1;
            foreach (int i in colValSets.Where(cvs => cvs.SingleRule.Name.StartsWith("departure"))
                .Select(cvs => cvs.Idx))
            {
                product *= yours[i];
            }

            return product;
        }

        public static long Solve1(string[] lines)
        {
            return Solve(lines, true);
        }

        public static long Solve2(string[] lines)
        {
            return Solve(lines, false);
        }

        record RuleDefinition(string Name, int Min1, int Max1, int Min2, int Max2)
        {
            public static RuleDefinition Create(Match match)
            {
                return new RuleDefinition(
                    Name: match.Groups[1].Value,
                    Min1: int.Parse(match.Groups[2].Value),
                    Max1: int.Parse(match.Groups[3].Value),
                    Min2: int.Parse(match.Groups[4].Value),
                    Max2: int.Parse(match.Groups[5].Value));
            }
        }

        private class ColumnValueSet
        {
            private readonly int _idx;
            private readonly List<int> _values;
            private readonly List<RuleDefinition> _rules;

            public ColumnValueSet(int idx, IEnumerable<int> values, IEnumerable<RuleDefinition> rules)
            {
                this._idx = idx;
                this._values = values.ToList();
                this._rules = rules.Where(r => values.All(v => IsValid(v, r))).ToList();
            }

            public int Idx => _idx;

            public RuleDefinition SingleRule => _rules.Count == 1 ? _rules.First() : null;

            public bool RemoveRule(RuleDefinition rule)
            {
                if (SingleRule == rule)
                {
                    return false;
                }

                return _rules.Remove(rule);
            }

            private static bool IsValid(int value, RuleDefinition rule)
            {
                return value >= rule.Min1 && value <= rule.Max1 || value >= rule.Min2 && value <= rule.Max2;
            }
        }
    }
}