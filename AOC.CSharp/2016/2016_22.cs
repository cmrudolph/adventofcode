namespace AOC.CSharp;

public class AOC2016_22
{
    public static long Solve1(string[] lines)
    {
        int viablePairs = 0;

        Node[] nodes = lines.Select(Parse).ToArray();
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            for (int j = i; j < nodes.Length; j++)
            {
                Node n1 = nodes[i];
                Node n2 = nodes[j];
                bool viable =
                    n1.Used != 0 && n1.Used <= n2.Avail || n2.Used != 0 && n2.Used <= n1.Avail;
                viablePairs += viable ? 1 : 0;

                if (viable)
                {
                    Console.WriteLine("{0} {1}", n1, n2);
                }
            }
        }

        return viablePairs;
    }

    public static long Solve2(string[] lines)
    {
        Node[] nodes = lines.Select(Parse).ToArray();
        var groups = nodes.OrderBy(n => n.X).GroupBy(n => n.Y);
        foreach (var g in groups)
        {
            foreach (var n in g)
            {
                Console.Write(n);
            }
            Console.WriteLine();
        }

        // Solve by hand based on the printed maze

        return 0;
    }

    private static Node Parse(string line)
    {
        string[] splits = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] nameSplits = splits[0].Split("-");
        int x = int.Parse(nameSplits[1].Replace("x", ""));
        int y = int.Parse(nameSplits[2].Replace("y", ""));
        int size = int.Parse(splits[1].Replace("T", ""));
        int used = int.Parse(splits[2].Replace("T", "").Replace("T", ""));
        int avail = int.Parse(splits[3].Replace("T", ""));
        int percent = int.Parse(splits[4].Replace("%", ""));

        return new Node(x, y, size, used, avail, percent);
    }

    private record Node(int X, int Y, int Size, int Used, int Avail, int Percent)
    {
        public override string ToString()
        {
            if (X == 0 && Y == 0)
            {
                return "S";
            }
            else if (X == 34 && Y == 0)
            {
                return "G";
            }
            else if (Percent >= 95)
            {
                return "#";
            }
            else if (Used != 0)
            {
                return ".";
            }
            else
            {
                return "_";
            }
        }
    }
}
