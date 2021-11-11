using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp;

public class AOC2016_15
{
    public static long Solve1(string[] lines)
    {
        Disc[] discs = lines.Select(Disc.Parse).ToArray();
        return Solve(discs);
    }

    public static long Solve2(string[] lines)
    {
        Disc[] discs = lines.Select(Disc.Parse).ToArray();
        Disc extra = new Disc(discs.Length + 1, 11, 0);
        return Solve(discs.Concat(new[] { extra }).ToArray());
    }

    private static long Solve(Disc[] discs)
    {
        int t = 0;
        while (true)
        {
            if (discs.All(d => d.IsOpenAt(t)))
            {
                return t;
            }
            t++;
        }
    }

    public class Disc
    {
        private int _timeAdjustment;
        private int _numPositions;

        public Disc(int discNum, int numPositions, int posAtZero)
        {
            _timeAdjustment = posAtZero - numPositions + discNum;
            _numPositions = numPositions;
        }

        public static Disc Parse(string line)
        {
            Regex re = new(@"Disc #(\d+) has (\d+) positions; at time=0, it is at position (\d+)");
            Match m = re.Match(line);

            int discNum = int.Parse(m.Groups[1].Value);
            int numPositions = int.Parse(m.Groups[2].Value);
            int posAtZero = int.Parse(m.Groups[3].Value);

            return new Disc(discNum, numPositions, posAtZero);
        }

        public bool IsOpenAt(int t)
        {
            return (t + _timeAdjustment) % _numPositions == 0;
        }
    }
}
