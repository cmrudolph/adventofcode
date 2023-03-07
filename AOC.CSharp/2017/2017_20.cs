using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2017_20
{
    public static long Solve1(string[] lines)
    {
        // Arbitrary number of iterations. Tried until result was stable. This is good enough to
        // get us to the answer
        List<Particle> particles = lines.Select((x, i) => new Particle(i, x)).ToList();
        for (int i = 0; i < 500; i++)
        {
            particles.ForEach(x => x.Update());
        }

        Particle closest = particles.OrderBy(p => p.Position.Dist).First();
        return closest.Num;
    }

    public static long Solve2(string[] lines)
    {
        void RemoveCollisions(List<Particle> particles)
        {
            var counts = particles
                .Select(p => p.Position)
                .GroupBy(p => p)
                .ToDictionary(x => x.Key, x => x.Count());
            foreach (var kvp in counts.Where(x => x.Value > 1))
            {
                particles.RemoveAll(p => p.Position.Equals(kvp.Key));
            }
        }

        List<Particle> particles = lines.Select((x, i) => new Particle(i, x)).ToList();
        RemoveCollisions(particles);

        // Arbitrary number of iterations. Tried until result was stable. This is good enough
        // to get us to the answer
        for (int i = 0; i < 500; i++)
        {
            particles.ForEach(x => x.Update());
            RemoveCollisions(particles);
        }

        return particles.Count;
    }

    private class Particle
    {
        private static readonly Regex Re =
            new("p=<(.*),(.*),(.*)>, v=<(.*),(.*),(.*)>, a=<(.*),(.*),(.*)>");

        public Particle(int num, string line)
        {
            Num = num;

            XYZ Extract(Match m, int startIdx)
            {
                long ExtractOne(Match m, int idx) => long.Parse(m.Groups[idx].Value);
                return new(
                    ExtractOne(m, startIdx),
                    ExtractOne(m, startIdx + 1),
                    ExtractOne(m, startIdx + 2)
                );
            }

            Match m = Re.Match(line);
            Position = Extract(m, 1);
            Velocity = Extract(m, 4);
            Acceleration = Extract(m, 7);
        }

        public int Num { get; }
        public XYZ Position { get; }
        public XYZ Velocity { get; }
        public XYZ Acceleration { get; }

        public void Update()
        {
            Velocity.Update(Acceleration);
            Position.Update(Velocity);
        }
    }

    private class XYZ
    {
        public long X { get; private set; }
        public long Y { get; private set; }
        public long Z { get; private set; }

        public XYZ(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Update(XYZ amount)
        {
            // Use mutability for performance
            X += amount.X;
            Y += amount.Y;
            Z += amount.Z;
        }

        public override bool Equals(object obj)
        {
            XYZ o = (XYZ)obj;
            return X == o.X && Y == o.Y && Z == o.Z;
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        public override string ToString() => $"<{X},{Y},{Z}>";

        public long Dist => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
    }
}
