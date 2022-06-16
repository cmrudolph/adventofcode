using System.Text;

namespace AOC.CSharp;

public static class AOC2021_23
{
    private const int HallwayY = 0;
    private static readonly int[] RoomX = { 2, 4, 6, 8 };
    private static readonly List<int> HallXSpots = new() { 0, 1, 3, 5, 7, 9, 10 };

    public static long Solve1(string[] lines)
    {
        List<Antipode> antipodes = new();

        int idx = 0;
        for (int x = 2; x <= 8; x += 2)
        {
            for (int y = 1; y <= 2; y++)
            {
                Antipode a = new(idx++, lines[y + 1][x + 1], x, y);
                antipodes.Add(a);
            }
        }

        HashSet<string> seen = new();
        Dictionary<string, int?> bestCost = new();
        State state = new(antipodes, 2);
        int? best = Recurse(state, seen, bestCost);

        return best.GetValueOrDefault();
    }

    public static long Solve2(string[] lines)
    {
        List<Antipode> antipodes = new();

        List<string> finalLines = lines.ToList();
        finalLines.Insert(3, "  #D#C#B#A#  ");
        finalLines.Insert(4, "  #D#B#A#C#  ");

        int idx = 0;
        for (int x = 2; x <= 8; x += 2)
        {
            for (int y = 1; y <= 4; y++)
            {
                Antipode a = new(idx++, finalLines[y + 1][x + 1], x, y);
                antipodes.Add(a);
            }
        }

        HashSet<string> seen = new();
        Dictionary<string, int?> bestCost = new();
        State state = new(antipodes, 4);
        int? best = Recurse(state, seen, bestCost);

        return best.GetValueOrDefault();
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
        IEnumerable<NextState> nextStates = s.GetNextStates().Where(x => !visited.Contains(x.State.Key));
        foreach (NextState nextState in nextStates)
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

    private class State
    {
        private readonly int _roomDepth;
        private readonly Antipode[,] _layout;
        private readonly List<Antipode> _antipodes;

        public State(List<Antipode> antipodes, int roomDepth)
        {
            _roomDepth = roomDepth;
            _antipodes = antipodes.ToList();
            _layout = new Antipode[11, roomDepth + 1];

            for (int i = 0; i < antipodes.Count; i++)
            {
                _layout[_antipodes[i].X, _antipodes[i].Y] = _antipodes[i];
            }

            Key = MakeKey();
        }
        
        public  List<NextState> GetNextStates()
        {
            List<NextState> states = new();

            foreach (Antipode a in _antipodes)
            {
                if (IsInFinalSpot(a))
                {
                    // Already in final resting place. No need to move this one ever again (so no next move exists)
                    continue;
                }
                if (a.InRoom)
                {
                    foreach (int x in HallXSpots)
                    {
                        int? cost = GetMoveCost(a, x, HallwayY);
                        if (cost.HasValue)
                        {
                            State newState = Move(a, x, HallwayY);
                            states.Add(new(newState, cost.Value));
                        }
                    }
                }
                else if (a.InHallway)
                {
                    for (int y = _roomDepth; y >= HallwayY; y--)
                    {
                        bool lowerOk = true;
                        for (int y2 = _roomDepth; y2 > y; y2--)
                        {
                            Antipode inLower = GetAtPos(a.HomeX, y2);
                            lowerOk &= inLower?.Letter == a.Letter;
                        }

                        Antipode inTarget = GetAtPos(a.HomeX, y);
                        if (inTarget == null && lowerOk)
                        {
                            int? cost = GetMoveCost(a, a.HomeX, y);
                            if (cost.HasValue)
                            {
                                State newState = Move(a, a.HomeX, y);
                                states.Add(new(newState, cost.Value));
                            }
                        }
                    }
                }
            }

            return states;
        }

        private Antipode GetAtPos(int x, int y) => _layout[x, y];

        private State Move(Antipode a, int x, int y)
        {
            Antipode toMove = GetAtPos(a.X, a.Y);
            Antipode newA = toMove.At(x, y);

            List<Antipode> newAntipodes = _antipodes.ToList();
            newAntipodes[a.Idx] = newA;

            return new State(newAntipodes, _roomDepth);
        }

        private bool IsInFinalSpot(Antipode a)
        {
            if (a.X != a.HomeX || a.InHallway)
            {
                return false;
            }
            
            for (int y2 = _roomDepth; y2 > a.Y; y2--)
            {
                Antipode inLower = GetAtPos(a.HomeX, y2);
                if (inLower?.Letter != a.Letter)
                {
                    return false;
                }
            }

            return true;
        }

        private int? GetMoveCost(Antipode a, int x, int y)
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

                for (int tempY = HallwayY + 1; tempY <= y; tempY++)
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

        public string Key { get; }

        public bool IsDone => _antipodes.All(a => a.InRoom && a.X == a.HomeX);

        private string MakeKey()
        {
            StringBuilder sb = new();
            for (int i = 0; i < 11; i++)
            {
                sb.Append(_layout[i, HallwayY]?.Letter ?? '.');
            }

            foreach (int x in RoomX)
            {
                for (int y = 1; y <= _roomDepth; y++)
                {
                    sb.Append(_layout[x, y]?.Letter ?? '.');                    
                }
            }

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

        public Antipode At(int x, int y) => new(Idx, Letter, x, y);

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
