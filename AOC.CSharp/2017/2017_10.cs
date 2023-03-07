namespace AOC.CSharp;

public static class AOC2017_10
{
    public static long Solve1(string[] lines, int numCount)
    {
        List<int> nums = Enumerable.Range(0, numCount).ToList();
        List<int> lengths = lines[0].Split(',').Select(int.Parse).ToList();
        int curr = 0;
        int skip = 0;

        DoRound(nums, lengths, curr, skip);

        return nums[0] * nums[1];
    }

    public static string Solve2(string[] lines)
    {
        return CalculateKnotHash(lines[0]);
    }

    public static string CalculateKnotHash(string input)
    {
        List<int> nums = Enumerable.Range(0, 256).ToList();
        List<int> lengths = input
            .Select(ch => (int)ch)
            .Concat(new[] { 17, 31, 73, 47, 23 })
            .ToList();
        int curr = 0;
        int skip = 0;

        for (int i = 0; i < 64; i++)
        {
            (curr, skip) = DoRound(nums, lengths, curr, skip);
        }

        byte[] xorBytes = new byte[16];
        for (int i = 0; i < 16; i++)
        {
            int start = i * 16;
            int end = start + 15;

            int xor = nums[start];
            for (int j = start + 1; j <= end; j++)
            {
                xor ^= nums[j];
            }

            xorBytes[i] = (byte)xor;
        }

        string hex = Convert.ToHexString(xorBytes).ToLowerInvariant();

        return hex;
    }

    private static (int curr, int skip) DoRound(
        List<int> nums,
        List<int> lengths,
        int curr,
        int skip
    )
    {
        foreach (int length in lengths)
        {
            Reverse(nums, curr, length);
            curr += (skip + length);
            curr %= nums.Count;
            skip++;
        }

        return (curr, skip);
    }

    private static void Reverse(List<int> nums, int start, int length)
    {
        int swaps = length / 2;
        int end = (start + length - 1) % nums.Count;

        for (int i = 0; i < swaps; i++)
        {
            (nums[start], nums[end]) = (nums[end], nums[start]);

            start++;
            if (start == nums.Count)
            {
                start = 0;
            }

            end--;
            if (end < 0)
            {
                end = nums.Count - 1;
            }
        }
    }
}
