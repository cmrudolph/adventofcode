using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2024_03
{
    public static long Solve1(string[] lines)
    {
        string input = string.Join("", lines);
        Regex re = new("mul\\((\\d{1,3}),(\\d{1,3})\\)");
        var products = GetProducts(re, input);

        return products.Sum();
    }

    public static long Solve2(string[] lines)
    {
        string input = string.Join("", lines);
        Regex re = new("mul\\((\\d{1,3}),(\\d{1,3})\\)");
        List<string> validChunks = new();

        string[] splits1 = input.Split("don't()");
        validChunks.Add(splits1[0]);

        foreach (string s in splits1[1..])
        {
            string[] splits2 = s.Split("do()");
            if (splits2.Length > 1)
            {
                validChunks.AddRange(splits2.Skip(1));
            }
        }

        int result = 0;

        foreach (var x in validChunks)
        {
            var products = GetProducts(re, x);
            result += products.Sum();
        }

        return result;
    }

    private static List<int> GetProducts(Regex re, string s)
    {
        List<int> products = new();

        var matches = re.Matches(s);
        foreach (Match m in matches)
        {
            int val1 = int.Parse(m.Groups[1].Value);
            int val2 = int.Parse(m.Groups[2].Value);

            products.Add(val1 * val2);
        }

        return products;
    }
}
