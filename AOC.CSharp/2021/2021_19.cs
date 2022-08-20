namespace AOC.CSharp;

public static class AOC2021_19
{
    public static long Solve1(string[] lines)
    {
        var result = Solve(lines);
        return result.Item1;
    }

    public static long Solve2(string[] lines)
    {
        var result = Solve(lines);
        List<Vector> allVectors = new List<Vector> { new(0, 0, 0) }.Concat(result.Item2).ToList();
        return MaxDistance(allVectors);
    }

    private static (long, List<Vector>) Solve(string[] lines)
    {
        List<List<Point>> originalScannerSets = new();

        List<Point> currentSet = new();
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
            }
            else if (line.StartsWith("---"))
            {
                if (currentSet.Any())
                {
                    originalScannerSets.Add(currentSet);
                    currentSet = new();
                }
            }
            else
            {
                currentSet.Add(Parse(line));
            }
        }
        if (currentSet.Any())
        {
            originalScannerSets.Add(currentSet);
        }

        // S0 will be the scanner we use as our absolute reference point
        List<Point> fixedPoints = originalScannerSets[0];
        originalScannerSets.RemoveAt(0);

        List<Vector> vectors = new();
        int idx = 0;
        
        // Continue until we have accounts for all scanners
        while (originalScannerSets.Any())
        {
            bool found = false;
            
            List<Point> currSet = originalScannerSets[idx];
            List<List<Point>> permutedSets = Permute(currSet);
            for (int i = 0; i < permutedSets.Count && !found; i++)
            {
                List<Point> permutedSet = permutedSets[i];
                Vector v = FindSolutionVector(fixedPoints, permutedSet);
                if (v != null)
                {
                    vectors.Add(v);
                    var normalizedPoints = permutedSet.Select(x => Transform(x, v)).ToList();
                    fixedPoints.AddRange(normalizedPoints);
                    fixedPoints = fixedPoints.Distinct().ToList();
                    originalScannerSets.RemoveAt(idx);
                    idx = 0;
                    found = true;
                }
            }

            if (!found)
            {
                idx++;
            }
        }

        return (fixedPoints.Count, vectors);
    }

    private static long MaxDistance(List<Vector> vectors)
    {
        long Manhattan(Vector v1, Vector v2)
        {
            return Math.Abs(v1.X - v2.X) + Math.Abs(v1.Y - v2.Y) + Math.Abs(v1.Z - v2.Z);
        }

        List<long> distances = new();
        for (int i = 0; i < vectors.Count; i++)
        {
            for (int j = i; j < vectors.Count; j++)
            {
                distances.Add(Manhattan(vectors[i], vectors[j]));
            }
        }

        return distances.Max();
    }

    private static Point Parse(string pointLine)
    {
        string[] splits = pointLine.Split(",");
        return new Point(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]));
    }

    private static Point Transform(Point p, Vector v)
    {
        return new Point(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    private static List<List<Point>> Permute(List<Point> points)
    {
        static Point Roll(Point p)
        {
            return new(p.X, p.Z, -p.Y);
        }

        static Point Turn(Point p)
        {
            return new(-p.Y, p.X, p.Z);
        }
        
        List<List<Point>> permuted = new(24);

        for (int i = 0; i < 24; i++)
        {
            permuted.Add(new());
        }
        
        foreach (var p in points)
        {
            int i = 0;
            
            Point curr = p;
            for (int j = 0; j < 3; j++)
            {
                curr = Roll(curr);
                permuted[i++].Add(curr);

                curr = Turn(curr);
                permuted[i++].Add(curr);

                curr = Turn(curr);
                permuted[i++].Add(curr);

                curr = Turn(curr);
                permuted[i++].Add(curr);
            }

            curr = Roll(curr);
            curr = Turn(curr);
            curr = Roll(curr);
            
            for (int j = 0; j < 3; j++)
            {
                curr = Roll(curr);
                permuted[i++].Add(curr);

                curr = Turn(curr);
                permuted[i++].Add(curr);

                curr = Turn(curr);
                permuted[i++].Add(curr);

                curr = Turn(curr);
                permuted[i++].Add(curr);
            }
        }
        
        return permuted;
    }
    
    private static Vector FindSolutionVector(List<Point> fixedPoints, List<Point> candidatePoints)
    {
        Dictionary<Vector, int> counts = new();
        
        foreach (Point fixedPoint in fixedPoints)
        {
            foreach (var candidate in candidatePoints)
            {
                Vector v = new(fixedPoint.X - candidate.X, fixedPoint.Y - candidate.Y, fixedPoint.Z - candidate.Z);
                if (counts.TryGetValue(v, out int count))
                {
                    if (count == 11)
                    {
                        return v;
                    }

                    counts[v]++;
                }
                else
                {
                    counts.Add(v, 1);
                }
            }
        }

        return null;
    }

    private record Point(int X, int Y, int Z)
    {
        public override string ToString() => $"({X},{Y},{Z})";
    }

    private record Vector(int X, int Y, int Z)
    {
        public override string ToString() => $"<{X},{Y},{Z}>";
    }
}
