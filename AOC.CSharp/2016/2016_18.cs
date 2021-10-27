using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC.CSharp
{
    public class AOC2016_18
    {
        private static int MakeCount = 0;

        private static HashSet<string> TrapSet = new()
        {
            "^^.",
            ".^^",
            "^..",
            "..^",
        };

        public static long Solve(string[] lines, string extra)
        {
            int rowCount = int.Parse(extra);

            Dictionary<string, RowAndSafeCount> cache = new();
            string prevRow = lines[0];

            int safeCount = lines[0].Count(r => r == '.');
            for (int i = 0; i < rowCount - 1; i++)
            {
                if (cache.TryGetValue(prevRow, out RowAndSafeCount cached))
                {
                    safeCount += cached.SafeCount;
                    prevRow = cached.Row;
                }
                else
                {
                    RowAndSafeCount computed = MakeNextRow(prevRow);
                    cache.Add(prevRow, computed);
                    safeCount += computed.SafeCount;
                    prevRow = computed.Row;
                }
            }

            Console.WriteLine(MakeCount);

            return safeCount;
        }

        public static RowAndSafeCount MakeNextRow(string prevRow)
        {
            MakeCount++;
            int safeCount = 0;
            string paddedRow = '.' + prevRow + '.';
            StringBuilder sb = new();

            for (int i = 0; i < paddedRow.Length - 2; i++)
            {
                string slice = paddedRow.Substring(i, 3);
                if (slice == "^^." || slice == ".^^" || slice == "^.." || slice == "..^")
                {
                    sb.Append('^');
                }
                else
                {
                    safeCount++;
                    sb.Append('.');
                }
            }

            return new RowAndSafeCount(sb.ToString(), safeCount);
        }

        public record RowAndSafeCount(string Row, int SafeCount);
    }
}