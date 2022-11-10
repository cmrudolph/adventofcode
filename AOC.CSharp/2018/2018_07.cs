using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2018_07
{
    private static Regex Re = new(@"Step (\w) must be finished before step (\w) can begin.");

    public static string Solve1(string[] lines)
    {
        List<Link> links = lines.Select(Parse).ToList();

        // Get an ordered list of all the chars that are part of our input. This serves as our priority ordering
        List<char> distinctChars = links
            .Select(x => x.From)
            .Concat(links.Select(x => x.To))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        // Keep track of the dependencies (what needs to be finished) of each character. Once all dependencies have
        // been visited, the character represented by the key is eligible for processing
        Dictionary<char, List<char>> dependencies = distinctChars.ToDictionary(ch => ch, _ => new List<char>());
        foreach (Link link in links)
        {
            dependencies[link.To].Add(link.From);
        }

        List<char> results = new();
        while (results.Count < distinctChars.Count)
        {
            bool done = false;
            int charIdx = 0;
            while (!done && charIdx < distinctChars.Count)
            {
                char c1 = distinctChars[charIdx];
                if (!results.Contains(c1))
                {
                    List<char> deps = dependencies[c1];
                    if (!deps.Any())
                    {
                        // Found an unvisited char that has no dependencies. Since we repeatedly search based on
                        // our initial sorted list, we know we found the next eligible character based on priority.
                        // Process it and remove it from all the dependency lists that contain it
                        results.Add(c1);
                        foreach (char c2 in distinctChars)
                        {
                            dependencies[c2].Remove(c1);
                        }

                        // Break out because we need to return to the outer while. If we continue the inner loop we
                        // will not process things in priority order. We need to start over from the beginning of
                        // our character list to find items that might have just become eligible
                        done = true;
                    }
                }

                charIdx++;
            }
        }

        return new string(results.ToArray());
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private static Link Parse(string line)
    {
        Match m = Re.Match(line);
        return new Link(m.Groups[1].Value[0], m.Groups[2].Value[0]);
    }

    private record Link(char From, char To);
}
