using MoreLinq;

namespace AOC.CSharp;

public static class AOC2021_18
{
    public static long Solve1(string[] lines)
    {
        Number sum = Number.Parse(lines[0]);

        // For part 1 we just need to run through the numbers in the input file, add them together, and then
        // calculate the magnitude of the resulting sum
        for (int i = 1; i < lines.Length; i++)
        {
            Number n2 = Number.Parse(lines[i]);
            sum = Add(sum, n2);
            sum = Reduce(sum);
        }

        return Magnitude(sum);
    }

    public static long Solve2(string[] lines)
    {
        long maxMagnitude = -1;

        // For part 2 we need to test all pairs to figure out which pair yields the highest magnitude value
        for (int i = 0; i < lines.Length - 1; i++)
        {
            for (int j = i + 1; j < lines.Length; j++)
            {
                Number n1 = Number.Parse(lines[i]);
                Number n2 = Number.Parse(lines[j]);
                long mag1 = Magnitude(Reduce(Add(n1, n2)));

                n1 = Number.Parse(lines[i]);
                n2 = Number.Parse(lines[j]);
                long mag2 = Magnitude(Reduce(Add(n2, n1)));
                maxMagnitude = Math.Max(Math.Max(maxMagnitude, mag1), mag2);
            }
        }

        return maxMagnitude;
    }

    public static Number Add(Number num1, Number num2)
    {
        // Adds two numbers together by treating the combination as a new pair (first number being the left value
        // and the second number being the right)
        var nodes1 = num1.GetNodes();
        nodes1.AddRange(num2.GetNodes());

        // Increasing the depth of every node is an easy way of making everything into a pair. We are effectively
        // adding another set of parens, which pushes each node one level deeper
        nodes1.ForEach(n => n.IncreaseDepth());

        return Number.FromNodes(nodes1);
    }

    public static Number Explode(Number num)
    {
        var nodes = num.GetNodes();

        for (int i = 0; i < nodes.Count - 1; i++)
        {
            Node n1 = nodes[i];
            Node n2 = nodes[i + 1];
            if (n1.Depth > 4 && n1.Depth == n2.Depth)
            {
                if (i > 0)
                {
                    // Transfer the left value to the left neighbor (if one exists)
                    nodes[i - 1].ReceiveFromExplosion(n1.Value);
                }

                if (i < nodes.Count - 2)
                {
                    // Transfer the right value to the right neighbor (if one exists)
                    nodes[i + 2].ReceiveFromExplosion(n2.Value);
                }

                // Reduce the depth since we just flattened a pair into a regular value. We also no longer need
                // the right node from the original pair (two nodes are becoming one)
                nodes[i] = new Node(0, n1.Depth - 1);
                nodes.RemoveAt(i + 1);

                return Number.FromNodes(nodes);
            }
        }

        return num;
    }

    public static Number Split(Number num)
    {
        var nodes = num.GetNodes();

        for (int i = 0; i < nodes.Count; i++)
        {
            Node n = nodes[i];
            if (n.Value >= 10)
            {
                int val1 = (int)Math.Floor(n.Value / 2.0);
                int val2 = (int)Math.Ceiling(n.Value / 2.0);

                // We are creating a pair from what was a regular value. This pushes the two new values a level
                // deeper than the original
                nodes[i] = new Node(val1, n.Depth + 1);
                nodes.Insert(i + 1, new Node(val2, n.Depth + 1));

                return Number.FromNodes(nodes);
            }
        }

        return num;
    }

    public static Number Reduce(Number num)
    {
        Number result = num;

        bool changed;
        do
        {
            // Prioritize exploding. Only progress to splitting when there is nothing left to explode. Run the whole
            // process until there is nothing left to explode or split. At this point the number has been reduced
            Number orig = result;
            result = Explode(result);

            if (orig == result)
            {
                result = Split(result);
            }

            changed = orig != result;
        } while (changed);

        return result;
    }

    public static long Magnitude(Number num)
    {
        List<Node> nodes = num.GetNodes();

        // The magnitude calculation is done when there is only one node left in the set
        while (nodes.Count > 1)
        {
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                Node n1 = nodes[i];
                Node n2 = nodes[i + 1];

                // When we find the first occurrence of neighboring nodes at the same depth we can assume this is
                // a pair and can consolidate it into a single value. This keeps happening until all pairs have
                // been consolidated and only a single value remains
                if (n1.Depth == n2.Depth)
                {
                    long magnitude = (n1.Value * 3) + (n2.Value * 2);
                    nodes[i] = new Node(magnitude, n1.Depth - 1);
                    nodes.RemoveAt(i + 1);
                    break;
                }
            }
        }

        return nodes[0].Value;
    }

    public class Number
    {
        private readonly List<Node> _nodes = new();

        private Number(List<Node> nodes)
        {
            _nodes = nodes;
        }

        public static Number Parse(string raw)
        {
            // Represent the number as a simple list of nodes where each node tracks its value and depth. This is
            // sufficient for our purposes since we need to be able to:
            //   1. Remove at an index
            //   2. Insert at an index
            //   3. Find the left/right neighbors
            //   4. Find the next node
            //   5. Find neighboring nodes at the same depth
            List<Node> nodes = new();

            int depth = 0;
            for (int i = 0; i < raw.Length; i++)
            {
                char ch = raw[i];
                if (ch == '[')
                {
                    depth++;
                }
                else if (ch == ']')
                {
                    depth--;
                }
                else if (char.IsDigit(ch))
                {
                    int start = i;
                    while (i < raw.Length && char.IsDigit(raw[i + 1]))
                    {
                        i++;
                    }

                    int value = int.Parse(raw[start..(i + 1)]);
                    nodes.Add(new Node(value, depth));
                }
            }

            return new Number(nodes);
        }

        public static Number FromNodes(List<Node> nodes)
        {
            return new Number(nodes);
        }

        public List<Node> GetNodes()
        {
            return _nodes;
        }

        public override string ToString()
        {
            return string.Join("|", _nodes.Select(n => $"({n.Value},{n.Depth})"));
        }
    }

    public class Node
    {
        public Node(long value, int depth)
        {
            Value = value;
            Depth = depth;
        }

        public void IncreaseDepth()
        {
            Depth++;
        }

        public void ReceiveFromExplosion(long value)
        {
            Value += value;
        }

        public long Value { get; private set; }
        public int Depth { get; private set; }
    }
}
