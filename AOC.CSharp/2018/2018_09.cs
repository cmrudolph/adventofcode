using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2018_09
{
    public static long Solve1(string[] lines) => Solve(lines[0], 1);

    public static long Solve2(string[] lines) => Solve(lines[0], 100);

    public static long Solve(string line, long multiplier)
    {
        (long players, long lastPoints) = Parse(line);
        lastPoints *= multiplier;

        long[] playerScores = new long[players];

        CircularList list = new();

        for (long i = 1; i <= lastPoints; i++)
        {
            if (i % 23 == 0)
            {
                long points = list.Remove();
                points += i;

                long scoringPlayer = i % players;
                playerScores[scoringPlayer] += points;
            }
            else
            {
                list.Add(i);
            }
        }

        return playerScores.Max();
    }

    private static (long, long) Parse(string line)
    {
        Regex re = new(@"(\d+) players; last marble is worth (\d+) points");
        Match m = re.Match(line);
        long players = long.Parse(m.Groups[1].Value);
        long points = long.Parse(m.Groups[2].Value);

        return (players, points);
    }

    private class CircularList
    {
        private CircularListNode _current;
        private List<CircularListNode> _nodes = new();

        public CircularList()
        {
            _current = new(0);
            _current.Next = _current;
            _current.Prev = _current;
            _nodes.Add(_current);
        }

        public void Add(long value)
        {
            CircularListNode newPrev = _current.Next;
            CircularListNode newNext = newPrev.Next;

            CircularListNode newCurr = new(value);
            newCurr.Prev = newPrev;
            newCurr.Next = newNext;

            newPrev.Next = newCurr;
            newNext.Prev = newCurr;
            _current = newCurr;
        }

        public long Remove()
        {
            CircularListNode toRemove = _current.Prev.Prev.Prev.Prev.Prev.Prev.Prev;
            CircularListNode before = toRemove.Prev;
            CircularListNode after = toRemove.Next;
            before.Next = after;
            after.Prev = before;
            _current = after;

            return toRemove.Value;
        }
    }

    private class CircularListNode
    {
        public CircularListNode(long value)
        {
            Value = value;
        }

        public long Value { get; }
        public CircularListNode Next { get; set; }
        public CircularListNode Prev { get; set; }
    }
}
