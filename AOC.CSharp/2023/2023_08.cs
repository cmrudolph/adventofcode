using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2023_08
{
    private static Regex Regex = new(@"(.*) = \((.*), (.*)\)", RegexOptions.Compiled);

    public static long Solve1(string[] lines)
    {
        List<char> directions = lines[0].ToList();
        var nodes = lines[2..].Select(Parse).ToList();
        var nodesDict = nodes.ToDictionary(x => x.Label);

        string currLabel = "AAA";
        int dirIdx = 0;
        int steps = 0;

        while (currLabel != "ZZZ")
        {
            Node currNode = nodesDict[currLabel];
            char dir = directions[dirIdx];
            currLabel = dir == 'L' ? currNode.Left : currNode.Right;

            dirIdx++;
            steps++;
            dirIdx %= directions.Count;
        }

        return steps;
    }

    public static long Solve2(string[] lines)
    {
        List<char> directions = lines[0].ToList();
        var nodes = lines[2..].Select(Parse).ToList();
        var nodesDict = nodes.ToDictionary(x => x.Label);

        List<string> currLabels = nodes.Select(x => x.Label).Where(x => x.EndsWith("A")).ToList();

        long[] successfulSteps = new long[currLabels.Count];

        int dirIdx = 0;
        int steps = 0;
        int iterations = 20000;

        // Go far enough to find out how often each path will end up finding a Z ending (the
        // sequence repeats)
        while (steps < iterations)
        {
            for (int i = 0; i < currLabels.Count; i++)
            {
                Node currNode = nodesDict[currLabels[i]];
                char dir = directions[dirIdx];
                currLabels[i] = dir == 'L' ? currNode.Left : currNode.Right;

                if (currLabels[i].EndsWith("Z") && successfulSteps[i] == 0)
                {
                    successfulSteps[i] = steps + 1;
                }
            }

            dirIdx++;
            steps++;
            dirIdx %= directions.Count;
        }

        return successfulSteps.Aggregate(LCM);
    }

    private static long LCM(long a, long b) => (a * b) / GCD(a, b);

    private static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static Node Parse(string line)
    {
        Match m = Regex.Match(line);

        return new(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
    }

    private record Node(string Label, string Left, string Right);
}
