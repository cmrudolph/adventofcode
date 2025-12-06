using MoreLinq;

namespace AOC.CSharp;

public static class AOC2025_06
{
    public static long Solve1(string[] lines)
    {
        List<List<long>> numberLists = new();

        for (int i = 0; i < lines.Length - 1; i++)
        {
            List<long> numbers = new();
            string line = lines[i];
            string[] splits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            numbers.AddRange(splits.Select(long.Parse));
            numberLists.Add(numbers);
        }

        List<char> ops = lines[^1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(char.Parse)
            .ToList();
        long total = 0;

        for (int i = 0; i < ops.Count; i++)
        {
            char op = ops[i];
            long opTotal = op == '+' ? 0 : 1;

            for (int listIdx = 0; listIdx < numberLists.Count; listIdx++)
            {
                long num = numberLists[listIdx][i];
                if (op == '+')
                {
                    opTotal += num;
                }
                else
                {
                    opTotal *= num;
                }
            }

            total += opTotal;
        }

        return total;
    }

    public static long Solve2(string[] lines)
    {
        long total = 0;

        List<long> nums = new();
        for (int c = lines[0].Length - 1; c >= 0; c--)
        {
            string numStr = "";
            bool foundOp = false;

            for (int i = 0; i < lines.Length; i++)
            {
                char ch = lines[i][c];
                if (char.IsDigit(ch))
                {
                    numStr += ch;
                }
                else if (ch == '+')
                {
                    foundOp = true;
                    nums.Add(long.Parse(numStr));
                    long sum = nums.Sum();
                    nums.Clear();
                    Console.WriteLine("S: {0}", sum);
                    total += sum;
                }
                else if (ch == '*')
                {
                    foundOp = true;
                    nums.Add(long.Parse(numStr));
                    long product = 1;
                    foreach (long x in nums)
                    {
                        product *= x;
                    }
                    nums.Clear();
                    Console.WriteLine("P: {0}", product);
                    total += product;
                }
            }

            if (!foundOp && !string.IsNullOrWhiteSpace(numStr))
            {
                nums.Add(long.Parse(numStr));
            }
        }

        return total;
    }
}
