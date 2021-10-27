using System.Linq;

namespace AOC.CSharp
{
    public class AOC2016_18
    {
        public static long Solve(string[] lines, string extra)
        {
            int rowCount = int.Parse(extra);
            int[] prevRow = Parse(lines[0]);

            int safeCount = prevRow.Sum();
            for (int i = 0; i < rowCount - 1; i++)
            {
                RowAndSafeCount computed = MakeNextRow(prevRow);
                safeCount += computed.SafeCount;
                prevRow = computed.Row;
            }

            return safeCount;
        }

        public static int[] Parse(string line) => line.Select(x => x == '^' ? 0 : 1).ToArray();

        public static string ReverseParse(int[] row) => new string(row.Select(x => x == 1 ? '.' : '^').ToArray());

        public static RowAndSafeCount MakeNextRow(int[] prev)
        {
            int[] row = new int[prev.Length];
            int safeCount = 0;

            for (int i = 0; i < prev.Length; i++)
            {
                if (i == 0)
                {
                    if (prev[1] == 1)
                    {
                        // .^ or ^^ produce a trap
                        row[i] = 1;
                        safeCount++;
                    }
                }
                else if (i == prev.Length - 1)
                {
                    if (prev[i - 1] == 1)
                    {
                        // ^. or ^^ produce a trap
                        row[i] = 1;
                        safeCount++;
                    }
                }
                else
                {
                    if (!(
                        (prev[i - 1] == 0 && prev[i] == 0 && prev[i + 1] == 1) ||
                        (prev[i - 1] == 1 && prev[i] == 0 && prev[i + 1] == 0) ||
                        (prev[i - 1] == 0 && prev[i] == 1 && prev[i + 1] == 1) ||
                        (prev[i - 1] == 1 && prev[i] == 1 && prev[i + 1] == 0)))
                    {
                        row[i] = 1;
                        safeCount++;
                    }
                }
            }

            return new RowAndSafeCount(row, safeCount);
        }

        public record RowAndSafeCount(int[] Row, int SafeCount);
    }
}