namespace AOC.CSharp;

public static class AOC2022_24
{
    public static long Solve1(string[] lines)
    {
        (Board board, Blizzards blizzards) = Parse(lines);

        XY start = new(1, 0);
        XY end = new(board.MaxX - 1, board.MaxY);

        return Solve(board, blizzards, start, end);
    }

    public static long Solve2(string[] lines)
    {
        (Board board, Blizzards blizzards) = Parse(lines);

        XY start = new(1, 0);
        XY end = new(board.MaxX - 1, board.MaxY);

        List<Tuple<XY, XY>> trips = new()
        {
            Tuple.Create(start, end),
            Tuple.Create(end, start),
            Tuple.Create(start, end),
        };

        long total = 0;
        foreach (var t in trips)
        {
            long tripCost = Solve(board, blizzards, t.Item1, t.Item2);
            total += tripCost;
        }

        return total;
    }

    private static long Solve(Board board, Blizzards blizzards, XY start, XY end)
    {
        int minute = 1;
        Queue<QueueEntry> q = new();
        q.Enqueue(new QueueEntry(start, 0));
        while (true)
        {
            blizzards.AdvanceAll(board);

            HashSet<QueueEntry> newEntries = new();
            while (q.Any())
            {
                var curr = q.Dequeue();

                if (blizzards.GetCountAt(curr.Pos) == 0)
                {
                    // Can only stay put if there is not a blizzard occupying this space now
                    newEntries.Add(new QueueEntry(curr.Pos, minute));
                }

                // Check all four possible directions and queue them as options if they do not run off the board and
                // are not occupied by a blizzard
                foreach (Direction dir in Enum.GetValues<Direction>())
                {
                    var candidate = GetNextPos(curr.Pos, dir);
                    if (end == candidate)
                    {
                        return minute;
                    }

                    if (!IsOnEdgeOrOutOfBounds(board, candidate) && blizzards.GetCountAt(candidate) == 0)
                    {
                        newEntries.Add(new QueueEntry(candidate, minute));
                    }
                }
            }

            q = new Queue<QueueEntry>(newEntries);
            minute++;
        }
    }

    private static (Board, Blizzards) Parse(string[] lines)
    {
        int maxY = lines.Length - 1;
        int maxX = lines[0].Length - 1;
        List<Blizzard> blizzards = new();

        for (int row = 1; row < maxY; row++)
        {
            for (int col = 1; col < maxX; col++)
            {
                char ch = lines[row][col];
                if (ch != '.')
                {
                    XY pos = new XY(col, row);
                    Direction dir = ch switch
                    {
                        '^' => Direction.North,
                        '>' => Direction.East,
                        'v' => Direction.South,
                        '<' => Direction.West,
                    };

                    blizzards.Add(new Blizzard(pos, dir));
                }
            }
        }

        return (new Board(0, maxX, 0, maxY), new Blizzards(blizzards));
    }

    private static Blizzard GetNextBlizzard(Board board, Blizzard blizzard)
    {
        XY next = GetNextPos(blizzard.Pos, blizzard.Dir);
        if(IsOnEdgeOrOutOfBounds(board, next))
        {
            next = blizzard.Dir switch
            {
                Direction.North => next with { Y = board.MaxY - 1 },
                Direction.East => next with { X = board.MinX + 1 },
                Direction.South => next with { Y = board.MinY + 1 },
                Direction.West => next with { X = board.MaxX - 1 },
            };
        }

        return new Blizzard(next, blizzard.Dir);
    }

    private static XY GetNextPos(XY curr, Direction dir)
    {
        return dir switch
        {
            Direction.North => curr with { Y = curr.Y - 1 },
            Direction.East => curr with { X = curr.X + 1 },
            Direction.South => curr with { Y = curr.Y + 1 },
            Direction.West => curr with { X = curr.X - 1 },
        };
    }

    private static bool IsOnEdgeOrOutOfBounds(Board board, XY xy)
    {
        return (xy.X <= board.MinX || xy.X >= board.MaxX || xy.Y <= board.MinY || xy.Y >= board.MaxY);
    }

    private static void Print(Board board, Blizzards blizzards)
    {
        for (int y = board.MinY; y <= board.MaxY; y++)
        {
            for (int x = board.MinX; x <= board.MaxX; x++)
            {
                int blizCount = blizzards.GetCountAt(new XY(x, y));
                if (blizCount == 0)
                {
                    Console.Write('.');
                }
                else if (blizCount == 1)
                {
                    Direction? dir = blizzards.GetDirectionAt(new XY(x, y));
                    char toWrite = dir switch
                    {
                        Direction.North => '^',
                        Direction.East => '>',
                        Direction.South => 'v',
                        Direction.West => '<',
                    };
                    Console.Write(toWrite);
                }
                else
                {
                    Console.Write(blizCount.ToString());
                }
            }
        }
    }

    private record Board(int MinX, int MaxX, int MinY, int MaxY);

    private sealed class Blizzards
    {
        private List<Blizzard> _all;
        private Dictionary<XY, int> _counts;
        private Dictionary<XY, Direction> _dirs;

        public Blizzards(IEnumerable<Blizzard> blizzards)
        {
            _all = blizzards.ToList();
            _counts = _all.GroupBy(b => b.Pos).ToDictionary(g => g.Key, g => g.Count());
            _dirs = _all.Where(x => _counts[x.Pos] == 1).ToDictionary(x => x.Pos, x => x.Dir);
        }

        public void AdvanceAll(Board board)
        {
            _all = _all.Select(b => GetNextBlizzard(board, b)).ToList();
            _counts = _all.GroupBy(b => b.Pos).ToDictionary(g => g.Key, g => g.Count());
            _dirs = _all.Where(x => _counts[x.Pos] == 1).ToDictionary(x => x.Pos, x => x.Dir);
        }

        public int GetCountAt(XY pos) => _counts.TryGetValue(pos, out int found) ? found : 0;

        public Direction? GetDirectionAt(XY pos) => _dirs.TryGetValue(pos, out Direction found) ? found : null;
    }

    private record QueueEntry(XY Pos, int Minute);
    private record Blizzard(XY Pos, Direction Dir);
    private record XY(int X, int Y);

    private enum Direction
    {
        North,
        East,
        South,
        West,
    }
}
