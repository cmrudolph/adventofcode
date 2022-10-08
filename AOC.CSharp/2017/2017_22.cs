namespace AOC.CSharp;

public static class AOC2017_22
{
    public static long Solve1(string[] lines)
    {
        Map map = new(lines);
        int sum = 0;
        for (int i = 0; i < 10000; i++)
        {
            sum += map.Evaluate1();
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        Map map = new(lines);
        int sum = 0;
        for (int i = 0; i < 10000000; i++)
        {
            sum += map.Evaluate2();
        }

        return sum;
    }

    private class Map
    {
        private readonly Dictionary<XY, Status> _nodes = new();
        private XY _pos = new(0, 0);
        private XY _dir = new(0, 1);

        public Map(string[] lines)
        {
            int edge = lines.Length / 2;
            for (int row = 0; row < lines.Length; row++)
            {
                string line = lines[row];

                for (int col = 0; col < lines.Length; col++)
                {
                    char ch = line[col];
                    if (ch == '#')
                    {
                        XY xy = new(col - edge, edge - row);
                        SetStatus(xy, Status.Infected);
                    }
                }
            }
        }

        private void SetStatus(XY xy, Status status) => _nodes[xy] = status;

        private Status GetStatus(XY xy) => _nodes.TryGetValue(xy, out Status s) ? s : Status.Clean;

        private record XY(int X, int Y);

        public int Evaluate1()
        {
            int result = 0;

            Status s = GetStatus(_pos);
            if (s == Status.Infected)
            {
                // Turn right
                _dir = new(_dir.Y, -1 * _dir.X);

                SetStatus(_pos, Status.Clean);
            }
            else
            {
                // Turn left
                _dir = new(-1 * _dir.Y, _dir.X);

                SetStatus(_pos, Status.Infected);
                result = 1;
            }

            _pos = new(_pos.X + _dir.X, _pos.Y + _dir.Y);

            return result;
        }

        public int Evaluate2()
        {
            int result = 0;

            Status s = GetStatus(_pos);
            if (s == Status.Infected)
            {
                // Turn right
                _dir = new(_dir.Y, -1 * _dir.X);

                SetStatus(_pos, Status.Flagged);
            }
            else if (s == Status.Clean)
            {
                // Turn left
                _dir = new(-1 * _dir.Y, _dir.X);

                SetStatus(_pos, Status.Weakened);
            }
            else if (s == Status.Weakened)
            {
                SetStatus(_pos, Status.Infected);
                result = 1;
            }
            else if (s == Status.Flagged)
            {
                // Reverse
                _dir = new(-1 * _dir.X, -1 * _dir.Y);
                SetStatus(_pos, Status.Clean);
            }

            _pos = new(_pos.X + _dir.X, _pos.Y + _dir.Y);

            return result;
        }

        private enum Status
        {
            Clean,
            Weakened,
            Infected,
            Flagged,
        }
    }
}
