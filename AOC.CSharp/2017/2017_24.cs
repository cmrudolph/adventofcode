namespace AOC.CSharp;

public static class AOC2017_24
{
    private static readonly List<Component> Empty = new();

    public static long Solve1(string[] lines)
    {
        var comps = lines.Select(x => new Component(x)).ToArray();
        var lookup = BuildLookup(comps);
        var starters = comps.Where(c => c.Ports.Contains(0)).ToList();

        int best = 0;
        foreach (Component starter in starters)
        {
            int? next = starter.TryUse(0);
            FindStrongest(comps, lookup, next.Value, ref best);
            starter.StopUsing();
        }

        return best;
    }

    public static long Solve2(string[] lines)
    {
        var comps = lines.Select(x => new Component(x)).ToArray();
        var lookup = BuildLookup(comps);
        var starters = comps.Where(c => c.Ports.Contains(0)).ToList();

        int bestLen = 0;
        int bestStrength = 0;
        foreach (Component starter in starters)
        {
            int? next = starter.TryUse(0);
            FindLongest(comps, lookup, next.Value, ref bestLen, ref bestStrength);
            starter.StopUsing();
        }

        return bestStrength;
    }

    private static void FindStrongest(Component[] comps, Dictionary<int, List<Component>> lookup, int searchVal, ref int best)
    {
        List<Component> candidates = lookup.TryGetValue(searchVal, out List<Component> found) ? found : Empty;
        foreach (Component c in candidates)
        {
            int? next = c.TryUse(searchVal);
            if (next != null)
            {
                FindStrongest(comps, lookup, next.Value, ref best);
                c.StopUsing();
            }

            int strength = comps.Where(c2 => c2.Used).Sum(c2 => c2.Strength);
            best = strength > best ? strength : best;
        }
    }

    private static void FindLongest(Component[] comps, Dictionary<int, List<Component>> lookup, int searchVal, ref int bestLen, ref int bestStrength)
    {
        List<Component> candidates = lookup.TryGetValue(searchVal, out List<Component> found) ? found : Empty;
        foreach (Component c in candidates)
        {
            int? next = c.TryUse(searchVal);
            if (next != null)
            {
                FindLongest(comps, lookup, next.Value, ref bestLen, ref bestStrength);
                c.StopUsing();
            }

            int length = comps.Count(c2 => c2.Used);
            int strength = comps.Where(c2 => c2.Used).Sum(c2 => c2.Strength);
            if (length == bestLen)
            {
                bestStrength = strength > bestStrength ? strength : bestStrength;
            }
            else if (length > bestLen)
            {
                bestLen = length;
                bestStrength = strength;
            }
        }
    }

    private static Dictionary<int, List<Component>> BuildLookup(Component[] comps)
    {
        Dictionary<int, List<Component>> lookup = new();

        foreach (Component c in comps)
        {
            foreach (int p in c.Ports)
            {
                if (!lookup.ContainsKey(p))
                {
                    lookup[p] = new();
                }
                lookup[p].Add(c);
            }
        }

        return lookup;
    }

    private class Component
    {
        private bool _used = false;

        public Component(string line)
        {
            Ports = line.Split("/").Select(int.Parse).ToArray();
            Strength = Ports[0] + Ports[1];
        }

        public int Strength { get; }

        public bool Used => _used;

        public int? TryUse(int useVal)
        {
            if (_used)
            {
                return null;
            }

            if (Ports[0] == useVal)
            {
                _used = true;
                return Ports[1];
            }

            if (Ports[1] == useVal)
            {
                _used = true;
                return Ports[0];
            }

            return null;
        }

        public void StopUsing()
        {
            _used = false;
        }

        public int[] Ports { get; }
    }
}
