using System.Text;

namespace AOC.CSharp;

public static class AOC2015_10
{
    public static string PerformIteration(string s)
    {
        int curr = 0;

        StringBuilder sb = new();

        while (curr < s.Length)
        {
            char digit = s[curr];
            int start = curr;

            while (curr < s.Length && s[curr] == digit)
            {
                curr++;
            }

            int count = curr - start;
            sb.Append($"{count}{digit}");
        }

        return sb.ToString();
    }

    public static long Solve(string[] lines, string extra)
    {
        string result = lines[0];
        int iterations = int.Parse(extra);

        for (int i = 0; i < iterations; i++)
        {
            result = PerformIteration(result);
        }

        return result.Length;
    }
}
