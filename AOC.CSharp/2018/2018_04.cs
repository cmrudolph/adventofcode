using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2018_04
{
    private static Regex GuardRe = new(@"Guard #(\d+)");
    private static Regex SleepRe = new(@":(\d\d)] falls");
    private static Regex WakeRe = new(@":(\d\d)] wakes");

    public static long Solve1(string[] lines)
    {
        var infos = BuildInfos(lines);
        var most = infos.MaxBy(kvp => kvp.Value.TotalMins).Value;
        int best = most.MinuteCounts.Select((count, idx) => (count, idx)).MaxBy(x => x.count).idx;

        return most.Id * best;
    }

    public static long Solve2(string[] lines)
    {
        var infos = BuildInfos(lines);

        Part2Result best = null;

        foreach (var info in infos.Values)
        {
            for (int i = 0; i < 60; i++)
            {
                if (best == null || info.MinuteCounts[i] > best.Count)
                {
                    best = new Part2Result(info.Id, i, info.MinuteCounts[i]);
                }
            }
        }

        return best.Id * best.Minute;
    }

    private static Dictionary<int, GuardInfo> BuildInfos(string[] lines)
    {
        Dictionary<int, GuardInfo> infos = new();

        GuardInfo currGuard = null;
        int currSleep = 0;
        foreach (var line in lines.OrderBy(x => x))
        {
            Match guardMatch = GuardRe.Match(line);
            Match sleepMatch = SleepRe.Match(line);
            Match wakeMatch = WakeRe.Match(line);

            if (guardMatch.Success)
            {
                int num = int.Parse(guardMatch.Groups[1].Value);
                currGuard = infos.TryGetValue(num, out GuardInfo g) ? g : null;
                if (currGuard == null)
                {
                    currGuard = new() { Id = num, TotalMins = 0, };
                    infos.Add(num, currGuard);
                }
            }
            else if (sleepMatch.Success)
            {
                currSleep = int.Parse(sleepMatch.Groups[1].Value);
            }
            else if (wakeMatch.Success)
            {
                int wake = int.Parse(wakeMatch.Groups[1].Value);
                int mins = wake - currSleep;
                currGuard.TotalMins += mins;

                for (int i = currSleep; i < wake; i++)
                {
                    currGuard.MinuteCounts[i]++;
                }
            }
        }

        return infos;
    }

    private record Part2Result(int Id, int Minute, int Count);

    private class GuardInfo
    {
        public int Id { get; set; }
        public int TotalMins { get; set; }
        public int[] MinuteCounts { get; } = new int[60];
    }
}
