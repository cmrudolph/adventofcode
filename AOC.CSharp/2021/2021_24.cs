namespace AOC.CSharp;

public static class AOC2021_24
{
    public static string Solve1(string[] lines)
    {
        return Solve(lines, true);
    }

    public static string Solve2(string[] lines)
    {
        return Solve(lines, false);
    }

    private static string Solve(string[] lines, bool largest)
    {
        // Build the simplified instructions by parsing the lines, looking for known markers, and extracting only
        // the pieces of important information.
        var steps = MakeSteps(lines);

        int[] wOrder = Enumerable.Range(1, 9).ToArray();
        if (largest)
        {
            wOrder = wOrder.Reverse().ToArray();
        }

        string[] solutionBuffer = new string[14];
        foreach (int w in wOrder)
        {
            string solution = ProcessLevel(w, 0, steps, 0, solutionBuffer, wOrder);
            if (solution != null)
            {
                return solution;
            }
        }

        return null;
    }

    private static string ProcessLevel(
        int w,
        int z,
        List<Func<int, int, StepResult>> steps,
        int depth,
        string[] buf,
        int[] wOrder
    )
    {
        if (depth == 14)
        {
            // Successfully reaching this depth means we did not abort early. This guarantees that we found a valid
            // solution since any failure along the way would have terminated the search already.
            return string.Join("", buf);
        }

        StepResult sr = steps[depth](w, z);
        if (!sr.Ok)
        {
            // Found a path that will not succeed. Skip searching all paths based on this one.
            return null;
        }

        buf[depth] = w.ToString();
        foreach (int nextW in wOrder)
        {
            string result = ProcessLevel(nextW, sr.Z, steps, depth + 1, buf, wOrder);
            if (result != null)
            {
                return result;
            }
        }

        buf[depth] = "";

        return null;
    }

    record StepResult(bool Ok, int Z);

    private static List<Func<int, int, StepResult>> MakeSteps(string[] lines)
    {
        List<Func<int, int, StepResult>> steps = new();

        for (int i = 0; i < lines.Length; i += 18)
        {
            if (lines[i + 4] == "div z 1")
            {
                // Half of the lines increase z. These are identifiable by this divide by 1 instruction. The line-specific
                // input into the increase formula can be parsed from a specific instruction line.
                int magicNum = int.Parse(lines[i + 15].Replace("add y ", ""));
                steps.Add(MakeIncreaseStep(magicNum));
            }
            else
            {
                // The other half can decrease z. These are identifiable by a "div z 26" instruction. The line-specific
                // input into the decrease formula can be parsed from a specific instruction line.
                int magicNum = -1 * int.Parse(lines[i + 5].Replace("add x ", ""));
                steps.Add(MakeDecreaseStep(magicNum));
            }
        }

        return steps;
    }

    private static Func<int, int, StepResult> MakeIncreaseStep(int magicNum)
    {
        // Simplification of the "z is increased" code sections. They always produce this result.
        return (w, z) => new StepResult(true, (26 * z) + w + magicNum);
    }

    private static Func<int, int, StepResult> MakeDecreaseStep(int magicNum)
    {
        // Simplification of the "z is decreased" code sections. They sometimes decrease z. If z is not decreased, we
        // do not care about the result since we need every possible decrease step to succeed for z to get back to
        // zero. Returning an explicit failure allows us to stop searching the current path since we know it cannot
        // get us to a valid final result.
        return (w, z) =>
            ((z % 26) - magicNum == w) ? new StepResult(true, (z / 26)) : new StepResult(false, -1);
    }
}
