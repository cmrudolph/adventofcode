namespace AOC.CSharp;

public static class AOC2017_19
{
    public static string Solve1(string[] lines)
    {
        return Solve(lines).Item1;
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines).Item2;
    }

    private static (string, long) Solve(string[] lines)
    {
        List<char> letters = new();
        int steps = 0;

        char[,] map = Parse(lines);
        XY curr = FindStart(map);

        // Always start at the top moving down
        XY direction = new(0, 1);

        while (true)
        {
            XY next = curr.Move(direction);
            char nextChar = map[next.X, next.Y];

            if (nextChar != ' ')
            {
                // Always continue in the current direction whenever the next character is not
                // a blank
                if (char.IsLetter(nextChar))
                {
                    letters.Add(nextChar);
                }
                curr = next;
            }
            else
            {
                // Next character in the current direction is a blank. We need to change course.
                // There are only two options since backtracking is not allowed
                var options = curr.ChangeOptions(direction);

                XY changeNext = null;

                foreach (var opt in options)
                {
                    // Try both options (turn left or right) to see which one yields a valid path
                    // to follow
                    XY potentialNext = curr.Move(opt);
                    char potentialNextChar = map[potentialNext.X, potentialNext.Y];

                    if (potentialNextChar != ' ')
                    {
                        // Found a path to continue down. Stash the choice and new direction so
                        // we can adjust the current position later
                        if (char.IsLetter(potentialNextChar))
                        {
                            letters.Add(potentialNextChar);
                        }

                        changeNext = potentialNext;
                        direction = opt;
                    }
                }

                if (changeNext == null)
                {
                    // Special case where we reach the end of the puzzle. There is nowhere left
                    // to go, so return the progress info we accumulated along the journey
                    return (new string(letters.ToArray()), steps + 1);
                }

                curr = changeNext;
            }

            steps++;
        }
    }

    private static XY FindStart(char[,] map)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            if (map[x, 0] == '|')
            {
                return new(x, 0);
            }
        }

        return null;
    }

    private static char[,] Parse(string[] lines)
    {
        char[,] map = new char[lines[0].Length, lines.Length];

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];

            for (int x = 0; x < lines[0].Length; x++)
            {
                map[x, y] = line[x];
            }
        }

        return map;
    }

    private record XY(int X, int Y)
    {
        public XY Move(XY direction) => new(X + direction.X, Y + direction.Y);

        public XY[] ChangeOptions(XY direction)
        {
            return direction.X == 0
                ? new XY[] { new(-1, 0), new(1, 0) }
                : new XY[] { new(0, -1), new(0, 1) };
        }
    }
}
