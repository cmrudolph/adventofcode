using MoreLinq.Extensions;

namespace AOC.CSharp;

public static class AOC2021_19
{
    public static long Solve1(string[] lines)
    {
        Point[] origPoints =
        {
            new(0, 2),
            new(4, 1),
            new(3, 3)
        };
        
        Point[] otherSet =
        {
            new(-1, -1),
            new(-5, 0),
            new(-2, 1),
        };

        List<List<Point>> permuted = Permute(otherSet);
        var vectors = Compare(origPoints, permuted);
        var flat = vectors.SelectMany(v => v);
        var grouped = flat.GroupBy(v => v);
        foreach (var g in grouped.Where(x => x.Count() >= 3))
        {
            Console.WriteLine("{0} -> {1}", g.Key, g.Count());
        }
        
        return 0L;
    }

    public static long Solve2(string[] lines)
    {
        return 0L;
    }

    private static List<List<Point>> Permute(Point[] set)
    {
        List<List<Point>> permuted = new(4);

        for (int i = 0; i < 4; i++)
        {
            permuted.Add(new());
        }
        
        foreach (var p in set)
        {
            // permuted[0].Add(new(p.X, p.Y));
            // permuted[1].Add(new(p.X, -p.Y));
            // permuted[2].Add(new(-p.X, p.Y));
            // permuted[3].Add(new(-p.X, -p.Y));
            // permuted[4].Add(new(p.Y, p.X));
            // permuted[5].Add(new(p.Y, -p.X));
            // permuted[6].Add(new(-p.Y, p.X));
            // permuted[7].Add(new(-p.Y, -p.X));
            permuted[0].Add(new(p.X, p.Y));
            permuted[1].Add(new(-p.X, -p.Y));
            permuted[2].Add(new(-p.Y, p.X));
            permuted[3].Add(new(-p.Y, -p.X));
        }
        
        return permuted;
    }

    private static List<List<Vector>> Compare(Point[] set1, List<List<Point>> set2)
    {
        List<List<Vector>> results = new();
        
        foreach (Point p1 in set1)
        {
            List<Vector> vectors = new();
            
            Console.WriteLine("------{0}------", p1);
            foreach (List<Point> set in set2)
            {
                Console.WriteLine("---{0}---", string.Join(" | ", set.Select(x => x.ToString())));
                
                foreach (var p2 in set)
                {
                    Vector v = new(p1.X - p2.X, p1.Y - p2.Y);
                    Console.WriteLine("{0} {1} ==> {2}", p1, p2, v);
                    vectors.Add(v);
                }
            }
            
            vectors = vectors.Distinct().ToList();
            results.Add(vectors);
        }

        return results;
    }

    private record Point(int X, int Y)
    {
        public override string ToString() => $"({X}, {Y})";
    }

    private record Vector(int X, int Y)
    {
        public override string ToString() => $"<{X}, {Y}>";
    }
}
