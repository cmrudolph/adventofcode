namespace AOC.CSharp;

public static class AOC2025_07
{
    public static long Solve1(string[] lines)
    {
        int splits = 0;
        HashSet<Cell> beams = new();
        beams.Add(new(1, lines[0].Length / 2));

        for (int r = 1; r < lines.Length - 1; r++)
        {
            var rowBeams = beams.Where(x => x.R == r).ToList();
            foreach (var rowBeam in rowBeams)
            {
                Cell downLeft = new(r + 1, rowBeam.C - 1);
                Cell downCenter = new(r + 1, rowBeam.C);
                Cell downRight = new(r + 1, rowBeam.C + 1);

                if (lines[downCenter.R][downCenter.C] == '.')
                {
                    beams.Add(downCenter);
                }

                if (lines[downCenter.R][downCenter.C] == '^')
                {
                    beams.Add(downLeft);
                    beams.Add(downRight);
                    splits++;
                }
            }
        }

        return splits;
    }

    public static long Solve2(string[] lines)
    {
        Dictionary<Cell, long> solutions = new();
        List<Cell> path = new();

        Cell start = new(1, lines[0].Length / 2);
        Recurse(lines, path, start, solutions);

        return solutions[start];
    }

    private static long Recurse(
        string[] lines,
        List<Cell> path,
        Cell curr,
        Dictionary<Cell, long> solutions
    )
    {
        path.Add(curr);

        if (solutions.TryGetValue(curr, out long found))
        {
            return found;
        }

        if (curr.R == lines.Length - 1)
        {
            return 1;
        }

        long result = 0;

        Cell downLeft = new(curr.R + 1, curr.C - 1);
        Cell downCenter = new(curr.R + 1, curr.C);
        Cell downRight = new(curr.R + 1, curr.C + 1);

        if (lines[downCenter.R][downCenter.C] == '.')
        {
            result += Recurse(lines, path, downCenter, solutions);
        }

        if (lines[downCenter.R][downCenter.C] == '^')
        {
            result += Recurse(lines, path, downLeft, solutions);
            result += Recurse(lines, path, downRight, solutions);
        }

        solutions.Add(curr, result);

        return result;
    }

    private record Cell(int R, int C);
}
