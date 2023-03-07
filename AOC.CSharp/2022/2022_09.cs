using MoreLinq;

namespace AOC.CSharp;

public static class AOC2022_09
{
    private static readonly XY Right = new(1, 0);
    private static readonly XY Left = new(-1, 0);
    private static readonly XY Up = new(0, -1);
    private static readonly XY Down = new(0, 1);

    public static long Solve1(string[] lines) => Solve(lines, 2);

    public static long Solve2(string[] lines) => Solve(lines, 10);

    private static long Solve(string[] lines, int numNodes)
    {
        // Use a HashSet with a record for each distinct counting
        HashSet<XY> tailVisited = new();
        int lastIdx = numNodes - 1;

        // All nodes begin stacked on the same point
        List<XY> nodes = new();
        Enumerable.Range(0, numNodes).ForEach(x => nodes.Add(new XY(0, 0)));

        tailVisited.Add(nodes[lastIdx]);

        foreach (string line in lines)
        {
            (XY direction, int amount) = Parse(line);

            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < lastIdx; j++)
                {
                    if (j == 0)
                    {
                        // The head node case. This is the only node that moves explicitly based on the line's
                        // instruction. Every other node moves in response to its parent
                        nodes[j] = nodes[j].Move(direction);
                    }

                    // Determine if/where the next node needs to move based on the position of its parent
                    nodes[j + 1] = FindNextPos(nodes[j], nodes[j + 1]);

                    if (j + 1 == lastIdx)
                    {
                        // The tail node case. This is the only node whose history we need to track for the solution
                        tailVisited.Add(nodes[j + 1]);
                    }
                }
            }
        }

        return tailVisited.Count;
    }

    private static bool IsConnected(XY curr, XY next)
    {
        // Nodes are connected if they touch at an edge or corner. Check all 8 options
        List<XY> toCheck =
            new()
            {
                curr.Move(Up),
                curr.Move(Up).Move(Right),
                curr.Move(Right),
                curr.Move(Right).Move(Down),
                curr.Move(Down),
                curr.Move(Down).Move(Left),
                curr.Move(Left),
                curr.Move(Left).Move(Up),
            };

        return toCheck.Any(x => x.Equals(next));
    }

    private static XY FindNextPos(XY curr, XY next)
    {
        // Only need to move the next node if the nodes are not currently touching (any sides or corners)
        if (!IsConnected(curr, next))
        {
            // Exhaustively consider all 8 moves the other node might need to make
            if (next.Y == curr.Y && next.X == curr.X - 2)
            {
                // Tail is left by 2 -> move right 1
                next = next.Move(Right);
            }
            else if (next.Y == curr.Y && next.X == curr.X + 2)
            {
                // Tail is right by 2 -> move left 1
                next = next.Move(Left);
            }
            else if (next.X == curr.X && next.Y == curr.Y - 2)
            {
                // Tail is up by 2 -> move down 1
                next = next.Move(Down);
            }
            else if (next.X == curr.X && next.Y == curr.Y + 2)
            {
                // Tail is down by 2 -> move up 1
                next = next.Move(Up);
            }
            else if (next.X < curr.X && next.Y > curr.Y)
            {
                // Tail is down + left -> move up + right
                next = next.Move(Up).Move(Right);
            }
            else if (next.X > curr.X && next.Y > curr.Y)
            {
                // Tail is down + right -> move up + left
                next = next.Move(Up).Move(Left);
            }
            else if (next.X < curr.X && next.Y < curr.Y)
            {
                // Tail is up + left -> move down + right
                next = next.Move(Down).Move(Right);
            }
            else if (next.X > curr.X && next.Y < curr.Y)
            {
                // Tail is up + right -> move down + left
                next = next.Move(Down).Move(Left);
            }
        }

        return next;
    }

    private static (XY, int) Parse(string line)
    {
        string[] splits = line.Split(" ");

        XY direction = splits[0] switch
        {
            "U" => Up,
            "D" => Down,
            "L" => Left,
            "R" => Right,
            _ => throw new NotSupportedException(),
        };

        int amount = int.Parse(splits[1]);

        return (direction, amount);
    }

    private record XY(int X, int Y)
    {
        public XY Move(XY change) => new(X + change.X, Y + change.Y);
    }
}
