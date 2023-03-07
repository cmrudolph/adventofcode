using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2016_08
{
    private static Regex RectRegex = new Regex(@"rect (\d+)x(\d+)");
    private static Regex RotateColRegex = new Regex(@"rotate column x=(\d+) by (\d+)");
    private static Regex RotateRowRegex = new Regex(@"rotate row y=(\d+) by (\d+)");

    public static long Solve(string[] lines)
    {
        int[,] arr = new int[6, 50];

        foreach (string line in lines)
        {
            Match rectMatch = RectRegex.Match(line);
            if (rectMatch.Success)
            {
                int rows = int.Parse(rectMatch.Groups[2].Value);
                int cols = int.Parse(rectMatch.Groups[1].Value);
                TurnOn(arr, rows, cols);
                continue;
            }

            Match rotateColMatch = RotateColRegex.Match(line);
            if (rotateColMatch.Success)
            {
                int col = int.Parse(rotateColMatch.Groups[1].Value);
                int amount = int.Parse(rotateColMatch.Groups[2].Value);
                RotateColumn(arr, col, amount);
                continue;
            }

            Match rotateRowMatch = RotateRowRegex.Match(line);
            if (rotateRowMatch.Success)
            {
                int row = int.Parse(rotateRowMatch.Groups[1].Value);
                int amount = int.Parse(rotateRowMatch.Groups[2].Value);
                RotateRow(arr, row, amount);
                continue;
            }
        }

        int count = CountOn(arr);

        // Visually verify this output for part two
        Print(arr);

        return count;
    }

    public static void TurnOn(int[,] arr, int rows, int cols)
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                arr[r, c] = 1;
            }
        }
    }

    public static void RotateColumn(int[,] arr, int col, int amount)
    {
        int[] oldValues = new int[arr.GetLength(0)];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            oldValues[i] = arr[i, col];
        }

        for (int copyToIdx = 0; copyToIdx < arr.GetLength(0); copyToIdx++)
        {
            int copyFromIdx =
                copyToIdx < amount ? copyToIdx + arr.GetLength(0) - amount : copyToIdx - amount;

            arr[copyToIdx, col] = oldValues[copyFromIdx];
        }
    }

    public static void RotateRow(int[,] arr, int row, int amount)
    {
        int[] oldValues = new int[arr.GetLength(1)];
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            oldValues[i] = arr[row, i];
        }

        for (int copyToIdx = 0; copyToIdx < arr.GetLength(1); copyToIdx++)
        {
            int copyFromIdx =
                copyToIdx < amount ? copyToIdx + arr.GetLength(1) - amount : copyToIdx - amount;

            arr[row, copyToIdx] = oldValues[copyFromIdx];
        }
    }

    public static int CountOn(int[,] arr)
    {
        int count = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                count += arr[i, j];
            }
        }

        return count;
    }

    public static void Print(int[,] arr)
    {
        for (int r = 0; r < arr.GetLength(0); r++)
        {
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                Console.Write(arr[r, c] == 1 ? '#' : ' ');
            }
            Console.WriteLine();
        }
    }
}
