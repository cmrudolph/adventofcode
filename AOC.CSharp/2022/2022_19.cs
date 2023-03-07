using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2022_19
{
    private static Regex Re = new(@"Each (\w+) robot costs (.*)");

    public static long Solve1(string[] lines)
    {
        long final = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            int blueprintId = i + 1;
            var solver = new Solver(line);
            long result = solver.Solve(24, 80000);
            final += (result * blueprintId);
        }

        return final;
    }

    public static long Solve2(string[] lines)
    {
        long final = 1;
        foreach (var x in lines.Take(3))
        {
            var solver = new Solver(x);
            long result = solver.Solve(32, 50000);
            final *= result;
        }

        return final;
    }

    private class Solver
    {
        private static readonly Material[] OrderedMats = Enum.GetValues<Material>()
            .OrderByDescending(x => x)
            .ToArray();

        private static readonly int Geode = (int)Material.Geode;
        private static readonly int Obsidian = (int)Material.Obsidian;
        private static readonly int Clay = (int)Material.Clay;
        private static readonly int Ore = (int)Material.Ore;

        private Dictionary<Material, int> _maxRobotsToBuy;
        private Dictionary<Material, Robot> _templates;

        public Solver(string line)
        {
            Parse(line);
        }

        public long Solve(int minutes, int queueKeep)
        {
            long[] robotCounts = new long[4];
            robotCounts[Ore] = 1;

            long[] resources = new long[4];

            Queue<QueueEntry> q = new();
            q.Enqueue(new QueueEntry(robotCounts, resources, 0));

            int minute = 1;
            while (minute < minutes + 1)
            {
                var prioritized = q.OrderByDescending(qe => qe.RobotFitness)
                    .ThenByDescending(qe => qe.ResourceFitness)
                    .Take(queueKeep)
                    .ToList();
                q = new Queue<QueueEntry>(prioritized);

                while (q.Peek().Minute < minute)
                {
                    var curr = q.Dequeue();

                    foreach (var materialBuy in OrderedMats)
                    {
                        long ownedCount = curr.RobotCounts[(int)materialBuy];
                        if (ownedCount < _maxRobotsToBuy[materialBuy])
                        {
                            Robot tBuy = _templates[materialBuy];
                            if (tBuy.CanBuy(curr.Resources))
                            {
                                // Pay for the robot we are going to build (if we can afford it)
                                tBuy.Buy(curr.Resources);

                                foreach (var materialProduce in OrderedMats)
                                {
                                    long count = curr.RobotCounts[(int)materialProduce];
                                    Robot tProduce = _templates[materialProduce];

                                    // Have each of our existing robots produce their resources
                                    tProduce.ProduceResources(curr.Resources, count);
                                }

                                // Add the new robot we just built
                                curr.RobotCounts[(int)materialBuy]++;

                                QueueEntry newQEntry =
                                    new(curr.RobotCounts, curr.Resources, minute);
                                q.Enqueue(newQEntry);

                                // Revert the purchase
                                curr.RobotCounts[(int)materialBuy]--;

                                foreach (var mtProduce in OrderedMats)
                                {
                                    long count = curr.RobotCounts[(int)mtProduce];
                                    Robot tProduce = _templates[mtProduce];

                                    tProduce.RevertProduceResources(curr.Resources, count);
                                }

                                tBuy.RevertBuy(curr.Resources);
                            }
                        }
                    }

                    foreach (var materialProduce in OrderedMats)
                    {
                        long count = curr.RobotCounts[(int)materialProduce];
                        Robot t = _templates[materialProduce];

                        // Have each of our existing robots produce their resources
                        t.ProduceResources(curr.Resources, count);
                    }

                    QueueEntry newQEntry2 = new(curr.RobotCounts, curr.Resources, minute);
                    q.Enqueue(newQEntry2);

                    foreach (var materialProduce in OrderedMats)
                    {
                        long count = curr.RobotCounts[(int)materialProduce];
                        Robot t = _templates[materialProduce];

                        t.RevertProduceResources(curr.Resources, count);
                    }
                }

                minute++;
            }

            long best = q.Select(qe => qe.Resources[Geode]).Max();

            return best;
        }

        private class Robot
        {
            public Material Material { get; set; }
            public long[] Costs { get; set; }
            public long[] Produces { get; set; }

            public bool CanBuy(long[] current)
            {
                for (int i = 0; i < OrderedMats.Length; i++)
                {
                    if (current[i] < Costs[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            public void Buy(long[] current)
            {
                if (!CanBuy(current))
                {
                    throw new InvalidOperationException("Can't buy");
                }

                for (int i = 0; i < OrderedMats.Length; i++)
                {
                    current[i] -= Costs[i];
                }
            }

            public void RevertBuy(long[] current)
            {
                for (int i = 0; i < OrderedMats.Length; i++)
                {
                    current[i] += Costs[i];
                }
            }

            public void ProduceResources(long[] current, long count)
            {
                for (int i = 0; i < OrderedMats.Length; i++)
                {
                    current[i] += (count * Produces[i]);
                }
            }

            public void RevertProduceResources(long[] current, long count)
            {
                for (int i = 0; i < OrderedMats.Length; i++)
                {
                    current[i] -= (count * Produces[i]);
                }
            }
        }

        private void Parse(string line)
        {
            string[] mainSplits = line.Split(": ");
            int blueprint = int.Parse(mainSplits[0].Split(' ')[1]);

            List<Robot> robots = new();

            int maxCostOre = 0;
            int maxCostClay = 0;
            int maxCostObsidian = 0;

            string[] robotSplits = mainSplits[1].Split(".", StringSplitOptions.RemoveEmptyEntries);
            foreach (string robotSplit in robotSplits.Reverse())
            {
                Match m = Re.Match(robotSplit);

                Material robotMaterial = Enum.Parse<Material>(m.Groups[1].Value, true);

                int robotOre = robotMaterial == Material.Ore ? 1 : 0;
                int robotClay = robotMaterial == Material.Clay ? 1 : 0;
                int robotObsidian = robotMaterial == Material.Obsidian ? 1 : 0;
                int robotGeodes = robotMaterial == Material.Geode ? 1 : 0;
                long[] produces = { robotGeodes, robotObsidian, robotClay, robotOre };

                string rawCost = m.Groups[2].Value;
                string[] costSplits = rawCost.Split(" and ");

                int costOre = 0;
                int costClay = 0;
                int costObsidian = 0;

                foreach (string c in costSplits)
                {
                    string[] costItemSplits = c.Split(" ");
                    int costAmount = int.Parse(costItemSplits[0]);
                    string costType = costItemSplits[1];
                    if (costType == "ore")
                    {
                        costOre = costAmount;
                        maxCostOre = Math.Max(maxCostOre, costOre);
                    }

                    if (costType == "clay")
                    {
                        costClay = costAmount;
                        maxCostClay = Math.Max(maxCostClay, costClay);
                    }

                    if (costType == "obsidian")
                    {
                        costObsidian = costAmount;
                        maxCostObsidian = Math.Max(maxCostObsidian, costObsidian);
                    }
                }

                long[] cost = { 0, costObsidian, costClay, costOre };

                robots.Add(
                    new Robot
                    {
                        Material = robotMaterial,
                        Produces = produces,
                        Costs = cost,
                    }
                );
            }

            _templates = robots.ToDictionary(r => r.Material);

            _maxRobotsToBuy = new();
            _maxRobotsToBuy.Add(Material.Ore, maxCostOre);
            _maxRobotsToBuy.Add(Material.Clay, maxCostClay);
            _maxRobotsToBuy.Add(Material.Obsidian, maxCostObsidian);
            _maxRobotsToBuy.Add(Material.Geode, int.MaxValue);
        }

        private sealed class QueueEntry
        {
            public QueueEntry(long[] robotCounts, long[] resources, int minute)
            {
                RobotCounts = robotCounts.ToArray();
                Resources = resources.ToArray();
                Minute = minute;
            }

            public long[] RobotCounts { get; }
            public long[] Resources { get; }
            public int Minute { get; }

            // public long RobotFitness => RobotCounts.Sum();
            // public long ResourceFitness => Resources.Sum();

            // public long RobotFitness => RobotCounts[Geode] << 48 | RobotCounts[Obsidian] << 32 | RobotCounts[Clay] << 16 | RobotCounts[Ore];
            // public long ResourceFitness => Resources[Geode] << 48 | Resources[Obsidian] << 32 | Resources[Clay] << 16 | Resources[Ore];

            public long RobotFitness =>
                (RobotCounts[Geode] * 1000)
                | (RobotCounts[Obsidian] * 100)
                | (RobotCounts[Clay] * 10)
                | RobotCounts[Ore];
            public long ResourceFitness =>
                (Resources[Geode] * 1000)
                | (Resources[Obsidian] * 100)
                | (Resources[Clay] * 10)
                | Resources[Ore];
        }

        private enum Material
        {
            Geode = 0,
            Obsidian = 1,
            Clay = 2,
            Ore = 3,
        }
    }
}
