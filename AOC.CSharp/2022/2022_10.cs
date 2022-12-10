using System.Text;

namespace AOC.CSharp;

public static class AOC2022_10
{
    private static readonly HashSet<int> ImportantIndices = new() { 20, 60, 100, 140, 180, 220 };

    public static long Solve1(string[] lines)
    {
        int x = 1;

        int? updateAfterCycle = null;
        int? pendingAdjustment = null;

        List<long> importantStrengths = new();

        int lineIdx = 0;

        for (int cycle = 1; cycle <= 220 && lineIdx < lines.Length; cycle++)
        {
            string line = lines[lineIdx];

            if (ImportantIndices.Contains(cycle))
            {
                // One of the special milestone cycles. Capture the signal strength for later
                importantStrengths.Add(cycle * x);
            }

            if (updateAfterCycle.HasValue && cycle < updateAfterCycle)
            {
                // Do not read another line - we are still busy processing an instruction
                continue;
            }

            if (updateAfterCycle.HasValue && cycle >= updateAfterCycle)
            {
                // Done processing instruction. Apply the new value, but do not process another line this cycle
                x += pendingAdjustment.Value;
                updateAfterCycle = null;
                pendingAdjustment = null;
                continue;
            }

            if (line == "noop")
            {
                // Just advance the cycle and look at the next line next time
                lineIdx++;
            }
            else if (line.StartsWith("addx"))
            {
                // Begin processing this long-running operation
                updateAfterCycle = cycle + 1;
                pendingAdjustment = int.Parse(line.Split(" ")[1]);
                lineIdx++;
            }
        }

        return importantStrengths.Sum();
    }

    public static long Solve2(string[] lines)
    {
        int x = 1;

        int? updateAfterCycle = null;
        int? pendingAdjustment = null;

        int lineIdx = 0;

        List<StringBuilder> toPrint = new();
        StringBuilder currStr = new();

        for (int cycle = 1; cycle <= 240 && lineIdx < lines.Length; cycle++)
        {
            // Start a new CRT row
            if ((cycle - 1) % 40 == 0)
            {
                currStr = new();
                toPrint.Add(currStr);
            }

            string line = lines[lineIdx];
            int spriteStart = x - 1;
            int spriteEnd = x + 1;
            int pos = cycle % 40 == 0 ? 39 : (cycle % 40) - 1;

            // Decide whether the sprite covers the current position we are filling
            currStr.Append(spriteStart <= pos && pos <= spriteEnd ? "#" : ".");

            if (updateAfterCycle.HasValue && cycle < updateAfterCycle)
            {
                // Do not read another line - we are still busy processing an instruction
                continue;
            }

            if (updateAfterCycle.HasValue && cycle >= updateAfterCycle)
            {
                // Done processing instruction. Apply the new value, but do not process another line this cycle
                x += pendingAdjustment.Value;
                updateAfterCycle = null;
                pendingAdjustment = null;
                continue;
            }

            if (line == "noop")
            {
                // Just advance the cycle and look at the next line next time
                lineIdx++;
            }
            else if (line.StartsWith("addx"))
            {
                // Begin processing this long-running operation
                updateAfterCycle = cycle + 1;
                pendingAdjustment = int.Parse(line.Split(" ")[1]);
                lineIdx++;
            }
        }

        foreach (StringBuilder sb in toPrint)
        {
            Console.WriteLine(sb.ToString());
        }

        return 0;
    }
}
