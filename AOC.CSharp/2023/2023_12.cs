using System.Text;

namespace AOC.CSharp;

public static class AOC2023_12
{
    public static long Solve1(string[] lines)
    {
        long sum = lines.Select(Arrangements1).Sum();

        return sum;
    }

    public static long Arrangements1(string line)
    {
        (string pattern, int[] lengths) = Parse(line);
        string[] arrangements = FindArrangements(pattern);
        long result = arrangements.Select(x => Test(x, lengths)).Select(x => x ? 1 : 0).Sum();

        return result;
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private static (string, int[]) Parse(string line)
    {
        string[] splits = line.Split(" ");
        int[] lengths = splits[1].Split(",").Select(int.Parse).ToArray();

        return (splits[0], lengths);
    }

    private static string[] FindArrangements(string pattern)
    {
        int questions = pattern.Count(x => x == '?');
        int[] arr = new int[questions];
        List<int[]> intCombos = new();
        GenerateIntCombinations(0, arr, intCombos);

        List<string> arrangements = new();
        foreach (int[] intCombo in intCombos)
        {
            StringBuilder sb = new();
            int idx = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                char ch = pattern[i];
                if (ch == '?')
                {
                    sb.Append(intCombo[idx] == 1 ? '#' : '.');
                    idx++;
                }
                else
                {
                    sb.Append(ch);
                }
            }

            arrangements.Add(sb.ToString());
        }

        return arrangements.ToArray();
    }

    private static void GenerateIntCombinations(int index, int[] array, List<int[]> combinations)
    {
        if (index == array.Length)
        {
            combinations.Add((int[])array.Clone());
            return;
        }

        array[index] = 0;
        GenerateIntCombinations(index + 1, array, combinations);

        array[index] = 1;
        GenerateIntCombinations(index + 1, array, combinations);
    }

    private static bool Test(string arrangement, int[] lengths)
    {
        int[] arrangementLengths = arrangement
            .Split(".", StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Length)
            .ToArray();

        return arrangementLengths.SequenceEqual(lengths);
    }
}
