namespace AOC.CSharp;

public static class AOC2022_18
{
    public static long Solve1(string[] lines)
    {
        HashSet<string> seenSides = new();
        HashSet<string> multipleSides = new();

        var cubes = lines.Select(Parse).ToList();
        foreach (var c in cubes)
        {
            foreach (Side s in c.Sides)
            {
                if (seenSides.Contains(s.AsString))
                {
                    // Track sides seen multiple times. These are excluded from the count since they cannot be
                    // outside-facing.
                    multipleSides.Add(s.AsString);
                }

                seenSides.Add(s.AsString);
            }
        }

        return seenSides.Count - multipleSides.Count;
    }

    public static long Solve2(string[] lines)
    {
        HashSet<string> seenCubes = new();

        var cubes = lines.Select(Parse).ToList();
        foreach (var c in cubes)
        {
            seenCubes.Add(c.AsString);
        }

        Queue<Cube> outsideQ = new();

        // Pick an arbitrary point outside our input bounds (known to be big enough). This will definitely be an exterior
        // block
        Point outside = new(22, 22, 22);
        outsideQ.Enqueue(new Cube(outside));

        // Find all exterior by identifying all blocks connected to our starting exterior point. Constrain the search
        // to not look at values that are too big. Once done, we will have identified all the points that are not air
        // pockets
        while (outsideQ.Count > 0)
        {
            var curr = outsideQ.Dequeue();
            if (!seenCubes.Contains(curr.AsString))
            {
                seenCubes.Add(curr.AsString);
                var neighbors = GetNeighborCubes(curr.InitialCorner);
                foreach (var n in neighbors)
                {
                    if (!seenCubes.Contains(n.AsString))
                    {
                        // Process all neighbors that we have not seen yet
                        outsideQ.Enqueue(n);
                    }
                }
            }
        }

        // Scan the entire range of points. Any block we have not seen (either because it is part of the puzzle input
        // or because we found it in our recent exterior search) is an air pocket.
        List<Cube> air = new();
        for (int i = 0; i <= 22; i++)
        {
            for (int j = 0; j <= 22; j++)
            {
                for (int k = 0; k <= 22; k++)
                {
                    var asCube = new Cube(new Point(i, j, k));
                    if (!seenCubes.Contains(asCube.AsString))
                    {
                        air.Add(asCube);
                    }
                }
            }
        }

        // Run the part 1 logic since this is still the basis for our calculation
        HashSet<string> seenSides = new();
        HashSet<string> multipleSides = new();

        foreach (var c in cubes)
        {
            foreach (Side s in c.Sides)
            {
                if (seenSides.Contains(s.AsString))
                {
                    multipleSides.Add(s.AsString);
                }

                seenSides.Add(s.AsString);
            }
        }

        // Remove all air pockets from the list of sides. We do not want to count these
        foreach (var a in air)
        {
            foreach (var s in a.Sides)
            {
                seenSides.Remove(s.AsString);
            }
        }

        return seenSides.Count - multipleSides.Count;
    }

    private static List<Cube> GetNeighborCubes(Point p)
    {
        List<Cube> results = new();

        if (p.X > 0)
            results.Add(new Cube(p with { X = p.X - 1 }));
        if (p.X < 22)
            results.Add(new Cube(p with { X = p.X + 1 }));
        if (p.Y > 0)
            results.Add(new Cube(p with { Y = p.Y - 1 }));
        if (p.Y < 22)
            results.Add(new Cube(p with { Y = p.Y + 1 }));
        if (p.Z > 0)
            results.Add(new Cube(p with { Z = p.Z - 1 }));
        if (p.Z < 22)
            results.Add(new Cube(p with { Z = p.Z + 1 }));

        return results;
    }

    private static Cube Parse(string pointLine)
    {
        string[] splits = pointLine.Split(",");
        var p1 = new Point(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]));

        return new Cube(p1);
    }

    private class Cube
    {
        public Cube(Point initialCorner)
        {
            List<Side> sides = new();

            var p1 = initialCorner;
            var p2 = p1 with { Y = p1.Y + 1 };
            var p3 = p1 with { X = p1.X + 1 };
            var p4 = p1 with { X = p1.X + 1, Y = p1.Y + 1 };
            sides.Add(new Side(new List<Point> { p1, p2, p3, p4 }));

            p1 = p1 with { X = p1.X + 1 };
            p2 = p2 with { X = p2.X + 1 };
            p3 = p3 with { Z = p3.Z + 1 };
            p4 = p4 with { Z = p4.Z + 1 };
            sides.Add(new Side(new List<Point> { p1, p2, p3, p4 }));

            p1 = p1 with { Z = p1.Z + 1 };
            p2 = p2 with { Z = p2.Z + 1 };
            p3 = p3 with { X = p3.X - 1 };
            p4 = p4 with { X = p4.X - 1 };
            sides.Add(new Side(new List<Point> { p1, p2, p3, p4 }));

            p1 = p1 with { X = p1.X - 1 };
            p2 = p2 with { X = p2.X - 1 };
            p3 = p3 with { Z = p3.Z - 1 };
            p4 = p4 with { Z = p4.Z - 1 };
            sides.Add(new Side(new List<Point> { p1, p2, p3, p4 }));

            var pTop1 = p1 with { Y = p1.Y + 1 };
            var pTop2 = p2 with { Z = p2.Z + 1 };
            var pTop3 = p3 with { Y = p3.Y + 1 };
            var pTop4 = p4 with { Z = p4.Z + 1 };
            sides.Add(new Side(new List<Point> { pTop1, pTop2, pTop3, pTop4 }));

            var pBottom1 = p1 with { Z = p1.Z + 1 };
            var pBottom2 = p2 with { Y = p2.Y - 1 };
            var pBottom3 = p3 with { Z = p3.Z + 1 };
            var pBottom4 = p4 with { Y = p4.Y - 1 };
            sides.Add(new Side(new List<Point> { pBottom1, pBottom2, pBottom3, pBottom4 }));

            InitialCorner = initialCorner;
            AsString = string.Join("||", sides.Select(x => x.AsString));
            Sides = sides;
        }

        public Point InitialCorner { get; }
        public string AsString { get; }
        public List<Side> Sides { get; }

        public override string ToString()
        {
            var p = Sides[0].Points[0];
            return $"({p.X}, {p.Y}, {p.Z})";
        }
    }

    private class Side
    {
        public Side(List<Point> points)
        {
            Points = points.OrderBy(x => x.X).ThenBy(x => x.Y).ThenBy(x => x.Z).ToList();
            AsString = string.Join("|", Points.Select(p => $"{p.X},{p.Y},{p.Z}"));
        }

        public List<Point> Points { get; }
        public string AsString { get; }
    }

    private record Point(int X, int Y, int Z)
    {
        public override string ToString() => $"({X},{Y},{Z})";
    }
}
