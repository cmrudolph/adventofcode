namespace AOC.CSharp;

public static class AOC2018_08
{
    public static long Solve1(string[] lines)
    {
        List<int> nums = lines[0].Split(' ').Select(int.Parse).ToList();
        var result = Recurse(nums, 0);

        return result.MetadataSum;
    }

    public static long Solve2(string[] lines)
    {
        List<int> nums = lines[0].Split(' ').Select(int.Parse).ToList();
        var result = Recurse(nums, 0);

        return result.NodeValue;
    }

    private static Result Recurse(List<int> nums, int idx)
    {
        // Read the header
        int children = nums[idx];
        int metadataCount = nums[idx + 1];
        idx += 2;

        List<Result> childResults = new();
        while (children > 0)
        {
            // Process each child
            var childResult = Recurse(nums, idx);
            childResults.Add(childResult);

            idx = childResult.NewIdx;
            children--;
        }

        long myMetadataSum = 0;
        long nodeValue = 0;
        for (int i = 0; i < metadataCount; i++)
        {
            int metadataVal = nums[idx];

            // Part 1: sum up all the metadata entries for this node
            myMetadataSum += metadataVal;

            // Part 2: metadata value is an index into the children
            if (metadataVal > 0 && metadataVal <= childResults.Count)
            {
                nodeValue += childResults[metadataVal - 1].NodeValue;
            }

            idx++;
        }

        if (!childResults.Any())
        {
            nodeValue = myMetadataSum;
        }

        long childMetadataSum = childResults.Sum(x => x.MetadataSum);

        return new Result(idx, childMetadataSum + myMetadataSum, nodeValue);
    }

    private record Result(int NewIdx, long MetadataSum, long NodeValue);
}
