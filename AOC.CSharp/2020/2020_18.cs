using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp
{
    public static class AOC2020_18
    {
        private const string Plus = "+";
        private const string Times = "*";
        private const string LParen = "(";
        private const string RParen = ")";

        private static Queue<Token> Tokenize(string str)
        {
            return new Queue<Token>(
                str
                    .Replace(" ", "")
                    .Replace(Plus, " " + Plus + " ")
                    .Replace(Times, " " + Times + " ")
                    .Replace(LParen, " " + LParen + " ")
                    .Replace(RParen, " " + RParen + " ")
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => new Token(str)));
        }

        public static Queue<Token> InfixToPostfix(Queue<Token> infix, Func<Token, Token, bool> isHigherPrecedence)
        {
            Queue<Token> postfix = new();
            Stack<Token> stack = new();

            while (infix.Any())
            {
                Token currToken = infix.Dequeue();
                if (currToken.IsNumber)
                {
                    postfix.Enqueue(currToken);
                }
                else if (currToken.IsOperator)
                {
                    while (stack.Any() && stack.Peek().IsOperator && isHigherPrecedence(currToken, stack.Peek()))
                    {
                        Token popped = stack.Pop();
                        postfix.Enqueue(popped);
                    }

                    stack.Push(currToken);
                }
                else if (currToken.IsLeftParen)
                {
                    stack.Push(currToken);
                }
                else if (currToken.IsRightParen)
                {
                    while (!stack.Peek().IsLeftParen)
                    {
                        Token popped = stack.Pop();
                        postfix.Enqueue(popped);
                    }

                    stack.Pop();
                }
            }

            while (stack.Any())
            {
                Token popped = stack.Pop();
                postfix.Enqueue(popped);
            }

            return postfix;
        }

        public static long SolvePostfix(Queue<Token> postfix)
        {
            Stack<Token> stack = new();

            while (postfix.Any())
            {
                Token currToken = postfix.Dequeue();
                if (currToken.IsNumber)
                {
                    stack.Push(currToken);
                }

                if (currToken.IsOperator)
                {
                    long val2 = long.Parse(stack.Pop().Value);
                    long val1 = long.Parse(stack.Pop().Value);

                    if (currToken.Value == Plus)
                    {
                        stack.Push(new Token((val1 + val2).ToString()));
                    }
                    else if (currToken.Value == Times)
                    {
                        stack.Push(new Token((val1 * val2).ToString()));
                    }
                }
            }

            return long.Parse(stack.Pop().Value);
        }

        public static long SolveCase(string line, Func<Token, Token, bool> isHigherPrecedence)
        {
            Queue<Token> infix = Tokenize(line);
            Queue<Token> postfix = InfixToPostfix(infix, isHigherPrecedence);
            long ans = SolvePostfix(postfix);

            return ans;
        }

        private static bool IsHigherPrecedence1(Token newToken, Token stackToken) => true;

        private static bool IsHigherPrecedence2(Token newToken, Token stackToken)
        {
            if (stackToken.Value == Plus)
            {
                return true;
            }

            if (stackToken.Value == Times && newToken.Value == Times)
            {
                return true;
            }

            return false;
        }

        public static long Solve1(string[] lines)
        {
            return lines.Aggregate(0L, (acc, line) => acc + SolveCase(line, IsHigherPrecedence1));
        }

        public static long Solve2(string[] lines)
        {
            return lines.Aggregate(0L, (acc, line) => acc + SolveCase(line, IsHigherPrecedence2));
        }

        public class Token
        {
            public Token(string value)
            {
                Value = value;
            }

            public string Value { get; }

            public bool IsNumber => long.TryParse(Value, out _);

            public bool IsOperator => Value == Plus || Value == Times;

            public bool IsLeftParen => Value == LParen;

            public bool IsRightParen => Value == RParen;
        }
    }
}