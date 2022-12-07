using System.Text.RegularExpressions;
using MoreLinq;

namespace AOC.CSharp;

public static class AOC2022_05
{
    public static string Solve1(string[] lines)
    {
        Solver solver = Solver.Parse(lines);
        var moves = lines.Where(x => x.StartsWith("move")).ToArray();
        moves.ForEach(x => solver.ProcessMove(x, false));

        return solver.BuildTopString();
    }

    public static string Solve2(string[] lines)
    {
        Solver solver = Solver.Parse(lines);
        var moves = lines.Where(x => x.StartsWith("move")).ToArray();
        moves.ForEach(x => solver.ProcessMove(x, true));

        return solver.BuildTopString();
    }

    private sealed class Solver
    {
        private readonly List<Stack<char>> _stacks;
        private static readonly Regex MoveRe = new(@"move (\d+) from (\d+) to (\d+)");

        private Solver(List<Stack<char>> stacks)
        {
            _stacks = stacks;
        }

        public static Solver Parse(string[] lines)
        {
            // Add an extra stack to make indexing easier (one-based)
            int numStacks = (lines[0].Length / 3) + 1;
            List<Stack<char>> stacks = new();
            Enumerable.Range(0, numStacks).ForEach(_ => stacks.Add(new()));

            // Find the line containing digits so we can walk backwards and push things onto the stacks naturally
            int numLineIdx = 0;
            while (!char.IsDigit(lines[numLineIdx][1]))
            {
                numLineIdx++;
            }

            // Walk from bottom to top to figure out the initial stack configurations
            for (int i = numLineIdx - 1; i >= 0; i--)
            {
                string line = lines[i];
                for (int j = 1; (j * 4) - 1 <= line.Length; j++)
                {
                    int charPos = j + ((j - 1) * 3);
                    char c = line[charPos];
                    if (char.IsLetter(c))
                    {
                        stacks[j].Push(c);
                    }
                }
            }

            return new Solver(stacks);
        }

        public void ProcessMove(string line, bool retainOrder)
        {
            Match m = MoveRe.Match(line);
            int count = int.Parse(m.Groups[1].Value);
            int from = int.Parse(m.Groups[2].Value);
            int to = int.Parse(m.Groups[3].Value);

            if (retainOrder)
            {
                // For part 2, move the crates onto a temporary stack, then from the temporary stack onto the final
                // stack. This additional step has the crates ending up in the same relative order they were in prior
                // to being moved.
                Stack<char> temp = new();
                for (int i = 0; i < count; i++)
                {
                    char c = _stacks[from].Pop();
                    temp.Push(c);
                }
                for (int i = 0; i < count; i++)
                {
                    char c = temp.Pop();
                    _stacks[to].Push(c);
                }
            }
            else
            {
                // For part 1 we want typical stack behavior where we pop directly onto the destination
                for (int i = 0; i < count; i++)
                {
                    char c = _stacks[from].Pop();
                    _stacks[to].Push(c);
                }
            }
        }

        public string BuildTopString()
        {
            List<char> chars = new();
            for (int i = 1; i < _stacks.Count; i++)
            {
                if (_stacks[i].Count > 0)
                {
                    chars.Add(_stacks[i].Peek());
                }
            }

            return new string(chars.ToArray());
        }
    }
}