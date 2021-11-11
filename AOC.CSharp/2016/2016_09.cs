using System.Text.RegularExpressions;

namespace AOC.CSharp;

public class AOC2016_09
{
    private static Regex MarkerRegex = new Regex(@"\((\d+)x(\d+)\)");

    public static long Solve1(string[] lines)
    {
        return lines.Select(CountDecompressed).Sum();
    }

    public static long Solve2(string[] lines)
    {
        return lines
            .Select(line => Recurse(line, 0, line.Length, 0))
            .Sum(r => r.Decompressed);
    }

    private static RecurseResult Recurse(string s, int start, int length, int depth)
    {
        long decompressed = 0;
        int charsProcessed = 0;

        int i = start;
        while (i < start + length)
        {
            if (s[i] == '(')
            {
                string remaining = s.Substring(i);
                Match m = MarkerRegex.Match(remaining);
                if (m.Success)
                {
                    int repeat = int.Parse(m.Groups[2].Value);
                    int nextStart = i + m.Groups[0].Length;
                    int nextLength = int.Parse(m.Groups[1].Value);

                    RecurseResult recurseResult = Recurse(s, nextStart, nextLength, depth + 1);
                    decompressed += recurseResult.Decompressed * repeat;
                    charsProcessed += (recurseResult.CharsProcessed + m.Groups[0].Length);

                    i += (m.Groups[0].Length + recurseResult.CharsProcessed);
                }
                else
                {
                    decompressed++;
                    charsProcessed++;
                    i++;
                }
            }
            else
            {
                decompressed++;
                charsProcessed++;
                i++;
            }
        }

        RecurseResult toReturn = new(decompressed, charsProcessed);

        return toReturn;
    }

    private static int CountDecompressed(string s)
    {
        int decompressed = 0;

        int i = 0;
        while (i < s.Length)
        {
            string remaining = s.Substring(i);
            if (remaining[0] == '(')
            {
                Match m = MarkerRegex.Match(remaining);
                if (m.Success)
                {
                    int charCount = int.Parse(m.Groups[1].Value);
                    int repeat = int.Parse(m.Groups[2].Value);
                    decompressed += charCount * repeat;

                    i += (m.Groups[0].Length + charCount);
                }
                else
                {
                    decompressed++;
                    i++;
                }
            }
            else
            {
                decompressed++;
                i++;
            }
        }

        return decompressed;
    }

    private record RecurseResult(long Decompressed, int CharsProcessed);
}
