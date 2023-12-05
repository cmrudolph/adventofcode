using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2023_04
{
    private static Regex Regex = new(@"Card\s*(\d+): (.*) \| (.*)");

    public static long Solve1(string[] lines)
    {
        Dictionary<int, int> values = new();

        var matches = GetMatches(lines);
        for (int i = 1; i <= lines.Length; i++)
        {
            int cardValue = (int)Math.Floor(Math.Pow(2, matches[i] - 1));
            values.Add(i, cardValue);
        }

        int sum = values.Values.Sum();

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        var values = GetMatches(lines);
        Dictionary<int, long> cardCounts = new();

        for (int i = 1; i <= values.Count; i++)
        {
            cardCounts[i] = 1;
        }

        for (int i = 1; i <= values.Count; i++)
        {
            int countAt = values[i];
            int end = i + countAt;
            for (int j = i + 1; j <= values.Count && j <= end; j++)
            {
                cardCounts[j] += cardCounts[i];
            }

            //Console.WriteLine("{0} {1}", i, string.Join(" | ", cardCounts));
        }

        long totalCount = cardCounts.Values.Sum();

        return totalCount;
    }

    private static Dictionary<int, int> GetMatches(string[] lines)
    {
        Dictionary<int, int> values = new();

        foreach (string line in lines)
        {
            Match m = Regex.Match(line);
            int cardNum = int.Parse(m.Groups[1].Value);

            HashSet<int> winners = m.Groups[2].Value
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            List<int> yours = m.Groups[3].Value
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int matchCount = 0;
            foreach (int x in yours)
            {
                matchCount += winners.Contains(x) ? 1 : 0;
            }

            values.Add(cardNum, matchCount);
        }

        return values;
    }
}
