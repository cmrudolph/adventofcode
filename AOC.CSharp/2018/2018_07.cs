using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2018_07
{
    private static Regex Re = new(@"Step (\w) must be finished before step (\w) can begin.");

    public static string Solve1(string[] lines)
    {
        return Solve(lines, 1, _ => 0).Item1;
    }

    public static long Solve2(string[] lines, int workers, int flatCost)
    {
        return Solve(lines, workers, c => c - 'A' + 1 + flatCost).Item2;
    }

    public static (string, long) Solve(string[] lines, int numWorkers, Func<char, int> getCost)
    {
        List<Link> links = lines.Select(Parse).ToList();

        // Get an ordered list of all the chars that are part of our input. This serves as our
        // priority ordering
        List<char> distinctChars = links
            .Select(x => x.From)
            .Concat(links.Select(x => x.To))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        // Keep track of the dependencies (what needs to be finished) of each character. Once all
        // dependencies have been visited, the character represented by the key is eligible
        // for processing
        Dictionary<char, List<char>> dependencies = distinctChars.ToDictionary(
            ch => ch,
            _ => new List<char>()
        );
        foreach (Link link in links)
        {
            dependencies[link.To].Add(link.From);
        }

        List<Worker> workers = new();
        long time = 0;
        List<char> results = new();

        while (results.Count < distinctChars.Count)
        {
            // Move time forward by one second. This means updating each worker and handling any
            // completion events that result
            for (int i = workers.Count - 1; i >= 0; i--)
            {
                Worker curr = workers[i];
                curr.Tick();
                if (curr.IsDone)
                {
                    results.Add(curr.Char);
                    foreach (char c2 in distinctChars)
                    {
                        dependencies[c2].Remove(curr.Char);
                    }
                    workers.RemoveAt(i);
                }
            }

            // Can skip everything below if our workers are still tied up
            bool hasCapacity = workers.Count < numWorkers;
            bool workerAdded = true;

            while (hasCapacity && workerAdded)
            {
                // We have room. Look for another character to start processing. This might not
                // be possible (due to unsatisfied dependencies), but we need to check
                workerAdded = false;
                int charIdx = 0;

                while (!workerAdded && charIdx < distinctChars.Count)
                {
                    // Look for the next char to try in priority order. Find the first one
                    // alphabetically that has not already been processed and is not actively
                    // being processed
                    char c1 = distinctChars[charIdx];
                    if (!results.Contains(c1) && !workers.Select(w => w.Char).Contains(c1))
                    {
                        List<char> deps = dependencies[c1];
                        if (!deps.Any())
                        {
                            // Found an unprocessed char with no outstanding dependencies
                            Worker proc = new(c1, getCost(c1));
                            workers.Add(proc);
                            workerAdded = true;
                        }
                    }

                    charIdx++;
                }

                hasCapacity = workers.Count < numWorkers;
            }

            time++;
        }

        return (new string(results.ToArray()), time - 1);
    }

    private static Link Parse(string line)
    {
        Match m = Re.Match(line);
        return new Link(m.Groups[1].Value[0], m.Groups[2].Value[0]);
    }

    private class Worker
    {
        public Worker(char c, int cost)
        {
            Char = c;
            Cost = cost;
        }

        public char Char { get; }
        public int Cost { get; private set; }

        public void Tick() => Cost--;

        public bool IsDone => Cost <= 0;
    }

    private record Link(char From, char To);
}
