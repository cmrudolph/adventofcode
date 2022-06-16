using System.Text;

namespace AOC.CSharp;

public static class AOC2021_23
{
    public const int Room1X = 2;
    public const int Room2X = 4;
    public const int Room3X = 6;
    public const int Room4X = 8;

    public const int HallwayY = 0;
    public const int UpperY = 1;
    public const int LowerY = 2;

    public static readonly List<int> HallXSpots = new() { 0, 1, 3, 5, 7, 9, 10 };

    public static long Solve1(string[] lines)
    {
        List<Antipode> antipodes = new();

        int idx = 0;
        for (int x = 2; x <= 8; x += 2)
        {
            for (int y = UpperY; y <= LowerY; y++)
            {
                Antipode a = new(idx++, lines[y + 1][x + 1], x, y);
                antipodes.Add(a);
            }
        }

        HashSet<string> seen = new();
        Dictionary<string, int?> bestCost = new();
        State state = new(antipodes);
        int? best = Recurse(state, seen, bestCost);

        return best.Value;
    }

    public static long Solve2(string[] lines)
    {
        return 0L;
    }

    private static int? Recurse(State s, HashSet<string> visited, Dictionary <string, int?> bestCost)
    {
        if (bestCost.ContainsKey(s.Key))
        {
            return bestCost[s.Key];
        }

        if (s.IsDone)
        {
            return 0;
        }

        visited.Add(s.Key);

        int? myBestCost = null;
        var nextStates = GetNextStates(s).Where(x => !visited.Contains(x.State.Key));
        foreach (var nextState in nextStates)
        {
            int? subCost = Recurse(nextState.State, visited, bestCost);
            if (subCost.HasValue)
            {
                int myNewCost = nextState.Cost + subCost.Value;
                if (!myBestCost.HasValue || myNewCost < myBestCost)
                {
                    myBestCost = myNewCost;
                }
            }
        }

        visited.Remove(s.Key);

        bestCost[s.Key] = myBestCost;
        return myBestCost;
    }

    private static List<NextState> GetNextStates(State s)
    {
        List<NextState> states = new();

        foreach (Antipode a in s.Antipodes)
        {
            if (s.IsInFinalSpot(a))
            {
                // Already in final resting place. No need to move this one ever again (so no next move exists)
                continue;
            }
            if (a.InRoom)
            {
                foreach (int x in HallXSpots)
                {
                    int? cost = s.GetMoveCost(a, x, HallwayY);
                    if (cost.HasValue)
                    {
                        State newState = s.Move(a, x, HallwayY);
                        states.Add(new(newState, cost.Value));
                    }
                }
            }
            else if (a.InHallway)
            {
                Antipode inLower = s.GetAtPos(a.HomeX, LowerY);
                if (inLower == null)
                {
                    int? cost = s.GetMoveCost(a, a.HomeX, LowerY);
                    if (cost.HasValue)
                    {
                        State newState = s.Move(a, a.HomeX, LowerY);
                        states.Add(new(newState, cost.Value));
                    }
                }

                Antipode inUpper = s.GetAtPos(a.HomeX, UpperY);
                if (inLower?.Letter == a.Letter && inUpper == null)
                {
                    int? cost = s.GetMoveCost(a, a.HomeX, UpperY);
                    if (cost.HasValue)
                    {
                        State newState = s.Move(a, a.HomeX, UpperY);
                        states.Add(new(newState, cost.Value));
                    }
                }
            }
        }

        return states;
    }

    private class State
    {
        private Antipode[,] _layout = new Antipode[11, 3];
        private List<Antipode> _antipodes;

        private readonly string _key;

        public State(List<Antipode> antipodes)
        {
            _antipodes = antipodes.ToList();

            for (int i = 0; i < 8; i++)
            {
                _layout[_antipodes[i].X, _antipodes[i].Y] = _antipodes[i];
            }

            _key = MakeKey();
        }

        public List<Antipode> Antipodes => _antipodes;

        public Antipode GetAtPos(int x, int y) => _layout[x, y];

        public State Move(Antipode a, int x, int y)
        {
            Antipode toMove = GetAtPos(a.X, a.Y);
            Antipode newA = toMove.At(x, y);

            List<Antipode> newAntipodes = _antipodes.ToList();
            newAntipodes[a.Idx] = newA;

            return new State(newAntipodes);
        }

        public bool IsInFinalSpot(Antipode a)
        {
            bool inHomeLower = a.X == a.HomeX && a.Y == LowerY;
            if (inHomeLower)
            {
                return true;
            }

            bool inHomeUpper = a.X == a.HomeX && a.Y == UpperY;
            Antipode atLower = GetAtPos(a.HomeX, LowerY);

            return inHomeUpper && atLower?.Letter == a.Letter;
        }

        public int? GetMoveCost(Antipode a, int x, int y)
        {
            int cost = 0;

            if (a.InHallway)
            {
                if (x > a.X)
                {
                    // Moving right
                    for (int tempX = a.X + 1; tempX <= x; tempX++)
                    {
                        Antipode inSpot = GetAtPos(tempX, HallwayY);
                        if (inSpot != null)
                        {
                            // Ran into something on the way
                            return null;
                        }

                        cost += a.MoveCost;
                    }
                }
                else
                {
                    // Moving left
                    for (int tempX = a.X - 1; tempX >= x; tempX--)
                    {
                        Antipode inSpot = GetAtPos(tempX, HallwayY);
                        if (inSpot != null)
                        {
                            // Ran into something on the way
                            return null;
                        }

                        cost += a.MoveCost;
                    }
                }

                for (int tempY = UpperY; tempY <= y; tempY++)
                {
                    // Moving down
                    Antipode inSpot = GetAtPos(x, tempY);
                    if (inSpot != null)
                    {
                        // Ran into something on the way
                        return null;
                    }

                    cost += a.MoveCost;
                }
            }
            else
            {
                for (int tempY = a.Y - 1; tempY >= HallwayY; tempY--)
                {
                    // Moving up
                    Antipode inSpot = GetAtPos(a.X, tempY);
                    if (inSpot != null)
                    {
                        // Ran into something on the way
                        return null;
                    }

                    cost += a.MoveCost;
                }

                if (x > a.X)
                {
                    // Moving right
                    for (int tempX = a.X + 1; tempX <= x; tempX++)
                    {
                        Antipode inSpot = GetAtPos(tempX, HallwayY);
                        if (inSpot != null)
                        {
                            // Ran into something on the way
                            return null;
                        }

                        cost += a.MoveCost;
                    }
                }
                else
                {
                    // Moving left
                    for (int tempX = a.X - 1; tempX >= x; tempX--)
                    {
                        Antipode inSpot = GetAtPos(tempX, HallwayY);
                        if (inSpot != null)
                        {
                            // Ran into something on the way
                            return null;
                        }

                        cost += a.MoveCost;
                    }
                }
            }

            return cost;
        }

        public string Key => _key;

        public bool IsDone => _antipodes.All(a => a.InRoom && a.X == a.HomeX);

        private string MakeKey()
        {
            StringBuilder sb = new();
            for (int i = 0; i < 11; i++)
            {
                sb.Append(_layout[i, HallwayY]?.Letter ?? '.');
            }

            sb.Append(_layout[Room1X, UpperY]?.Letter ?? '.');
            sb.Append(_layout[Room1X, LowerY]?.Letter ?? '.');
            sb.Append(_layout[Room2X, UpperY]?.Letter ?? '.');
            sb.Append(_layout[Room2X, LowerY]?.Letter ?? '.');
            sb.Append(_layout[Room3X, UpperY]?.Letter ?? '.');
            sb.Append(_layout[Room3X, LowerY]?.Letter ?? '.');
            sb.Append(_layout[Room4X, UpperY]?.Letter ?? '.');
            sb.Append(_layout[Room4X, LowerY]?.Letter ?? '.');

            return sb.ToString();
        }
    }

    private class Antipode
    {
        public int Idx { get; }
        public char Letter { get; }
        public int X { get; }
        public int Y { get; }

        public Antipode(int idx, char letter, int x, int y)
        {
            Idx = idx;
            Letter = letter;
            X = x;
            Y = y;
        }

        public Antipode At(int x, int y) => new Antipode(Idx, Letter, x, y);

        public bool InHallway => Y == HallwayY;
        public bool InRoom => !InHallway;

        public int HomeX =>
            this.Letter switch
            {
                'A' => 2,
                'B' => 4,
                'C' => 6,
                'D' => 8,
                _ => throw new NotSupportedException(this.Letter.ToString()),
            };

        public int MoveCost =>
            this.Letter switch
            {
                'A' => 1,
                'B' => 10,
                'C' => 100,
                'D' => 1000,
                _ => throw new NotSupportedException(this.Letter.ToString()),
            };
    }

    private record NextState(State State, int Cost);
}
