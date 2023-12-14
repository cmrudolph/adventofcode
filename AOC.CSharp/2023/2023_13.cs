using System.Text;

namespace AOC.CSharp;

public static class AOC2023_13
{
    public static long Solve1(string[] lines)
    {
        long sum = 0;

        var input = Parse(lines);
        foreach (var grid in input)
        {
            long mirrorCol = FindMirrorCol(grid, 0);
            long mirrorRow = 0;
            if (mirrorCol == 0)
            {
                mirrorRow = FindMirrorRow(grid, 0);
            }

            sum += mirrorCol;
            sum += (mirrorRow * 100);
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        long sum = 0;

        var input = Parse(lines);
        foreach (var grid in input)
        {
            int origMirrorCol = FindMirrorCol(grid, 0);
            int origMirrorRow = 0;
            if (origMirrorCol == 0)
            {
                origMirrorRow = FindMirrorRow(grid, 0);
            }

            int finalMirrorCol = 0;
            int finalMirrorRow = 0;

            bool done = false;
            for (int y = 0; !done && y < grid.Count; y++)
            {
                for (int x = 0; !done && x < grid[0].Length; x++)
                {
                    Console.WriteLine("{0} {1}", y, x);
                    char ch = grid[y][x];
                    var asArr = grid[y].ToCharArray();
                    asArr[x] = ch == '#' ? '.' : '#';
                    grid[y] = new(asArr);

                    finalMirrorCol = FindMirrorCol(grid, origMirrorCol);
                    finalMirrorRow = FindMirrorRow(grid, origMirrorRow);
                    if (finalMirrorCol != 0 || finalMirrorRow != 0)
                    {
                        done = true;
                    }

                    asArr[x] = ch == '#' ? '#' : '.';
                    grid[y] = new(asArr);
                }
            }

            sum += finalMirrorCol;
            sum += (finalMirrorRow * 100);
        }

        return sum;
    }

    private static int FindMirrorCol(List<string> grid, int ignore)
    {
        int height = grid.Count;
        int width = grid[0].Length;

        bool Test(int ix1, int ix2, int len)
        {
            for (int i = 0; i < height; i++)
            {
                string line = grid[i];
                string sub1 = line.Substring(ix1, len);
                string sub2 = new(line.Substring(ix2, len).Reverse().ToArray());

                if (sub1 != sub2)
                {
                    return false;
                }
            }

            return true;
        }

        int maxSize = width / 2;

        for (int size = 1; size <= maxSize; size++)
        {
            int idx1A = 0;
            int idx1B = idx1A + size;

            int idx2A = width - size - size;
            int idx2B = width - size;

            bool valid1 = Test(idx1A, idx1B, size);
            if (valid1 && idx1B != ignore)
            {
                return idx1B;
            }

            bool valid2 = Test(idx2A, idx2B, size);
            if (valid2 && idx2B != ignore)
            {
                return idx2B;
            }
        }

        return 0;
    }

    private static int FindMirrorRow(List<string> grid, int ignore)
    {
        int height = grid.Count;
        int width = grid[0].Length;

        StringBuilder sb1 = new();
        StringBuilder sb2 = new();

        bool Test(int ix1, int ix2, int len)
        {
            for (int col = 0; col < width; col++)
            {
                sb1.Clear();
                sb2.Clear();

                for (int j = ix1; j < ix1 + len; j++)
                {
                    sb1.Append(grid[j][col]);
                }
                for (int j = ix2; j < ix2 + len; j++)
                {
                    sb2.Append(grid[j][col]);
                }

                string sub1 = sb1.ToString();
                string sub2 = new(sb2.ToString().Reverse().ToArray());

                if (sub1 != sub2)
                {
                    return false;
                }
            }

            return true;
        }

        int maxSize = height / 2;

        for (int size = 1; size <= maxSize; size++)
        {
            int idx1A = 0;
            int idx1B = idx1A + size;

            int idx2A = height - size - size;
            int idx2B = height - size;

            bool valid1 = Test(idx1A, idx1B, size);
            if (valid1 && idx1B != ignore)
            {
                return idx1B;
            }

            bool valid2 = Test(idx2A, idx2B, size);
            if (valid2 && idx2B != ignore)
            {
                return idx2B;
            }
        }

        return 0;
    }

    private static List<List<string>> Parse(string[] lines)
    {
        List<List<string>> results = new();

        List<string> curr = new();
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
            {
                results.Add(curr);
                curr = new();
            }
            else
            {
                curr.Add(line);
            }
        }

        results.Add(curr);

        return results;
    }
}
