using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2022_16
{
    public static long Solve1(string[] lines)
    {
        return new Solver(lines).Solve();
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    public class Solver
    {
        private static Regex Re = new(@"Valve (.*) has flow rate=(\d+);.*valve.? (.*)");

        private long _tries;
        private long _curr;
        private long _best;
        private Dictionary<string, Dictionary<string, int>> _distances;
        private List<Valve> _visited = new();
        private HashSet<Valve> _unvisited = new();
        private Dictionary<string, Valve> _valves;

        public Solver(string[] lines)
        {
            _valves = Parse(lines).ToDictionary(v => v.Name, v => v);
            BuildDistanceLookup();
        }

        public long Solve()
        {
            var start = _valves["AA"];

            // Only visit all the meaningful valves (with contributions to the total)
            _unvisited = _valves.Values.Where(v => v.FlowRate > 0).ToHashSet();
            _visited.Add(start);

            var toVisit = _unvisited.ToList();
            foreach (var uv in toVisit)
            {
                // Process each potential path through the significant valves
                Recurse(start, uv, 30);
            }

            return _best;
        }

        private void BuildDistanceLookup()
        {
            _distances = new();

            foreach (Valve valve in _valves.Values)
            {
                HashSet<Valve> others = _valves.Values.ToHashSet();
                others.Remove(valve);

                Dictionary<string, int> dist = new();
                dist.Add(valve.Name, 0);

                Queue<Valve> q = new();
                q.Enqueue(valve);

                // Use BFS to find the minimum distance from each node to each other node
                while (q.Any())
                {
                    Valve curr = q.Dequeue();
                    foreach (Valve c in curr.Children)
                    {
                        if (others.Contains(c))
                        {
                            var matched = others.First(x => x.Equals(c));
                            var currDist = dist[curr.Name];
                            dist.Add(matched.Name, currDist + 1);
                            others.Remove(c);
                            q.Enqueue(c);
                        }
                    }
                }

                _distances.Add(valve.Name, dist);
            }
        }

        private void Recurse(Valve from, Valve to, int timeRemaining)
        {
            if (timeRemaining <= 0)
            {
                return;
            }

            _visited.Add(to);
            _unvisited.Remove(to);

            // Assume we will open a valve when we visit it. Account for the time to move there and the time to open
            // the valve
            int movementCost = _distances[from.Name][to.Name];
            timeRemaining -= (movementCost + 1);

            long contribution = Math.Max(to.FlowRate * (timeRemaining), 0);
            _curr += contribution;
            if (_curr > _best)
            {
                Console.WriteLine("{0} --> {1}", _curr, string.Join(" | ", _visited.Select(v => v.Name)));
                _best = _curr;
            }

            // Continue to visit all the other valves we haven't checked yet
            var toVisit = _unvisited.ToList();
            foreach (var next in toVisit)
            {
                Recurse(to, next, timeRemaining);
            }

            _curr -= contribution;

            _visited.Remove(to);
            _unvisited.Add(to);
        }

        private static List<Valve> Parse(string[] lines)
        {
            List<(Valve, string[])> valves = new();

            foreach (string line in lines)
            {
                Match m = Re.Match(line);
                string name = m.Groups[1].Value;
                int flow = int.Parse(m.Groups[2].Value);
                var children = m.Groups[3].Value.Split(",").Select(x => x.Trim()).ToArray();

                valves.Add((new Valve { Name = name, FlowRate = flow }, children));
            }

            foreach (var v in valves)
            {
                foreach (string child in v.Item2)
                {
                    var resolved = valves.First(x => x.Item1.Name == child).Item1;
                    v.Item1.Children.Add(resolved);
                }
            }

            return valves.Select(v => v.Item1).ToList();
        }

        private class Valve
        {
            public string Name { get; set; }
            public int FlowRate { get; set; }
            public List<Valve> Children { get; set; } = new();

            public override int GetHashCode() => Name.GetHashCode();

            public override bool Equals(object obj) => ((Valve)obj).Name == Name;
        }
    }
}
