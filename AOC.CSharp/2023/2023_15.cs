namespace AOC.CSharp;

public static class AOC2023_15
{
    public static long Solve1(string[] lines) => lines[0].Split(',').Select(ComputeHash).Sum();

    public static long Solve2(string[] lines)
    {
        List<List<Step>> boxes = new(256);
        for (int i = 0; i < boxes.Capacity; i++)
        {
            boxes.Add(new List<Step>());
        }

        string[] steps = lines[0].Split(',');

        foreach (string s in steps)
        {
            Step typed = new(s);
            if (typed.Operation == '=')
            {
                var box = boxes[typed.Hash];
                int idx = box.FindIndex(x => x.Label == typed.Label);

                if (idx > -1)
                {
                    box[idx] = typed;
                }
                else
                {
                    box.Add(typed);
                }
            }
            else
            {
                var box = boxes[typed.Hash];
                int idx = box.FindIndex(x => x.Label == typed.Label);

                if (idx > -1)
                {
                    box.RemoveAt(idx);
                }
            }
        }

        long result = 0;
        for (int i = 0; i < boxes.Count; i++)
        {
            for (int j = 0; j < boxes[i].Count; j++)
            {
                Step s = boxes[i][j];
                long stepResult = (1 + i) * (1 + j) * s.FocalLength;
                result += stepResult;
            }
        }

        return result;
    }

    private static int ComputeHash(string step)
    {
        int result = 0;
        foreach (char ch in step)
        {
            result += ch;
            result *= 17;
            result %= 256;
        }

        return result;
    }

    private class Step
    {
        public Step(string str)
        {
            Operation = str.Contains("=") ? '=' : '-';

            string[] splits = str.Split(Operation);
            Label = splits[0];

            if (Operation == '=')
            {
                FocalLength = int.Parse(splits[1]);
            }

            Hash = ComputeHash(Label);
        }

        public string Label { get; }
        public char Operation { get; }
        public int FocalLength { get; }
        public int Hash { get; }
    }
}
