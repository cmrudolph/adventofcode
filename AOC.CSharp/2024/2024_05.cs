namespace AOC.CSharp;

public static class AOC2024_05
{
    public static long Solve1(string[] lines)
    {
        bool firstHalf = true;
        Dictionary<int, HashSet<int>> deps = new();
        int sum = 0;

        foreach (string line in lines)
        {
            if (line == "")
            {
                firstHalf = false;
            }
            else if (firstHalf)
            {
                int[] splits = line.Split("|").Select(int.Parse).ToArray();
                int val1 = splits[0];
                int val2 = splits[1];

                HashSet<int> set;
                if (!deps.TryGetValue(val2, out set))
                {
                    set = new();
                    deps.Add(val2, set);
                }

                set.Add(val1);
            }
            else
            {
                int[] splits = line.Split(",").Select(int.Parse).ToArray();
                bool valid = true;

                // Need a fresh copy for each case
                var depsCopy = deps.ToDictionary(x => x.Key, x => x.Value.ToHashSet());

                HashSet<int> caseValues = splits.ToHashSet();
                foreach (var kvp in depsCopy)
                {
                    foreach (var depVal in kvp.Value)
                    {
                        if (!caseValues.Contains(depVal))
                        {
                            // Remove dependency values that do not matter for this case
                            kvp.Value.Remove(depVal);
                        }
                    }
                }

                foreach (int val in splits)
                {
                    var myDeps = depsCopy.GetValueOrDefault(val) ?? new HashSet<int>();
                    if (myDeps?.Count != 0)
                    {
                        Console.WriteLine("V:{0} | DEPS:[{1}]", val, string.Join(",", myDeps));
                        valid = false;
                    }

                    foreach (var kvp in depsCopy)
                    {
                        kvp.Value.Remove(val);
                    }
                }

                if (valid)
                {
                    sum += splits[splits.Length / 2];
                }
            }
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        return -1;
    }
}
