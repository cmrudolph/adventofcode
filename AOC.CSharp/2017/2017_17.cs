namespace AOC.CSharp;

public static class AOC2017_17
{
    public static long Solve1(string[] lines)
    {
        int skipAmount = int.Parse(lines[0]);
        List<int> nums = new(2018) { 0 };

        // The number of iterations is small enough we can maintain a list and manipulate it during each step
        int curr = 0;
        for (int i = 1; i <= 2017; i++)
        {
            for (int j = 0; j < skipAmount; j++)
            {
                // Move around the circular buffer until we find the next insertion point
                curr = (curr + 1 == nums.Count) ? 0 : curr + 1;
            }

            curr++;
            nums.Insert(curr, i);
        }

        // Find the value after the final value we inserted
        int idx = nums.IndexOf(2017);
        int solutionIdx = (idx + 1) % nums.Count;

        return nums[solutionIdx];
    }

    public static long Solve2(string[] lines)
    {
        int skipAmount = int.Parse(lines[0]);

        // The number of iterations is too large to use a list like in the first solution
        int curr = 1;
        int result = 1;
        for (int i = 2; i <= 50000000; i++)
        {
            // We only need to maintain curr/next values - not the whole list. We only care about the value in list
            // position [1]. Walk through the circular buffer by advancing our tracking index values by the appropriate
            // amount
            int next = (curr + skipAmount) % i;
            next = next == 0 ? 1 : next + 1;
            if (next == 1)
            {
                // Inserting something new in position [1] - this becomes our new tentative solution
                result = i;
            }

            curr = next;
        }

        return result;
    }
}
