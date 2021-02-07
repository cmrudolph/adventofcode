using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Year2020
{
    public static class AOC2020_18
    {
        private static List<string> Tokenize(string str)
        {
            return str
                .Replace(" ", "")
                .Replace("+", " + ")
                .Replace("*", " * ")
                .Replace("(", " ( ")
                .Replace(")", " ) ")
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }

        private static bool IsNumeric(string str)
        {
            return long.TryParse(str, out _);
        }

        private static bool IsOperator(string str)
        {
            return str == "+" || str == "*";
        }

        public static long SolveCase(string line, Func<string, string, bool> isHigherPrecedence)
        {
            Queue<string> queue = new();
            Stack<string> stack = new();

            List<string> tokens = Tokenize(line);
            while (tokens.Any())
            {
                string token = tokens[0];
                tokens.RemoveAt(0);
                if (IsNumeric(token))
                {
                    queue.Enqueue(token);
                }
                else if (IsOperator(token))
                {
                    while (stack.Any() && IsOperator(stack.Peek()) && isHigherPrecedence(token, stack.Peek()))
                    {
                        string popped = stack.Pop();
                        queue.Enqueue(popped);
                    }

                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        string popped = stack.Pop();
                        queue.Enqueue(popped);
                    }
                    stack.Pop();
                }
            }
            while (stack.Any())
            {
                string popped = stack.Pop();
                queue.Enqueue(popped);
            }

            while (queue.Any())
            {
                string dequed = queue.Dequeue();
                if (IsNumeric(dequed))
                {
                    stack.Push(dequed);
                }
                if (IsOperator(dequed))
                {
                    long val2 = long.Parse(stack.Pop());
                    long val1 = long.Parse(stack.Pop());

                    if (dequed == "+")
                    {
                        stack.Push((val1 + val2).ToString());
                    }
                    else if (dequed == "*")
                    {
                        stack.Push((val1 * val2).ToString());
                    }
                }
            }

            long ans = long.Parse(stack.Pop());
            if (stack.Any())
            {
                throw new InvalidOperationException("Stack still has data");
            }
            return ans;
        }

        private static bool IsHigherPrecedence2(string newToken, string stackToken)
        {
            if (stackToken == "+")
            {
                return true;
            }
            if (stackToken == "*" && newToken == "*")
            {
                return true;
            }

            return false;
        }

        public static Tuple<long, long> Solve(string[] lines)
        {
            long ans1 = lines.Aggregate(0L, (acc, line) => acc + SolveCase(line, (newToken, stackToken) => true));
            long ans2 = lines.Aggregate(0L, (acc, line) => acc + SolveCase(line, IsHigherPrecedence2));

            return Tuple.Create(ans1, ans2);
        }
    }

    public class Day18
    {
        [Fact]
        public void Sample()
        {
            var lines = Utils.ReadInput("2020", "18", "sample");
            Utils.SolveAndValidate(Tuple.Create(26335L, 693891L), AOC2020_18.Solve, lines);
        }

        [Fact]
        public void Actual()
        {
            var lines = Utils.ReadInput("2020", "18", "actual");
            Utils.SolveAndValidate(Tuple.Create(209335026987L, 33331817392479L), AOC2020_18.Solve, lines);
        }
    }
}
