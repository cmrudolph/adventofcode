using static MoreLinq.Extensions.SliceExtension;

namespace AOC.CSharp;

public static class AOC2021_04
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines).first;
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines).last;
    }

    public static (int first, int last) Solve(string[] lines)
    {
        Queue<int> callValues = new(lines[0].Split(',').Select(int.Parse).ToArray());
        List<BingoBoard> boards = new();

        int i = 2;
        while (i < lines.Length)
        {
            string[] boardLines = lines.Slice(i, 5).ToArray();
            boards.Add(new BingoBoard(boardLines));
            i += 6;
        }

        int? firstWinningScore = null;
        int? lastWinningScore = null;

        while (callValues.Any())
        {
            int value = callValues.Dequeue();
            Console.WriteLine(value);

            for (int j = boards.Count - 1; j >= 0; j--)
            {
                BingoBoard board = boards[j];
                board.Mark(value);
                int? winningScore = board.GetWinningScore();
                if (winningScore.HasValue)
                {
                    boards.RemoveAt(j);
                    if (!firstWinningScore.HasValue)
                    {
                        firstWinningScore = winningScore;
                    }
                    if (boards.Count == 0)
                    {
                        lastWinningScore = winningScore;
                    }
                }
            }
        }

        return (firstWinningScore.Value, lastWinningScore.Value);
    }

    private class BingoBoard
    {
        private int _lastMarked = -1;
        private List<HashSet<int>> _winningSets = new();
        private HashSet<int> _unmarked = new();

        public BingoBoard(string[] lines)
        {
            int[] numbers = string
                .Join(' ', lines)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < 5; i++)
            {
                var row = numbers.Slice(i * 5, 5).ToHashSet();
                var col = Enumerable.Range(0, 5).Select(j => numbers[(j * 5) + i]).ToHashSet();

                _winningSets.Add(row);
                _winningSets.Add(col);
            }

            _unmarked = numbers.ToHashSet();
        }

        public void Mark(int value)
        {
            if (_unmarked.Remove(value))
            {
                _lastMarked = value;
                _winningSets.ForEach(set => set.Remove(value));
            }
        }

        public int? GetWinningScore()
        {
            return _winningSets.Any(set => set.Count == 0)
                ? _unmarked.Sum() * _lastMarked
                : null;
        }
    }
}
