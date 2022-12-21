namespace AOC.CSharp;

public static class AOC2022_20
{
    public static long Solve1(string[] lines)
    {
        List<long> orig = lines.Select(long.Parse).ToList();
        return Solve1Efficient(orig, 1);
    }

    public static long Solve2(string[] lines)
    {
        List<long> orig = lines.Select(x => long.Parse(x) * 811589153L).ToList();
        return Solve1Efficient(orig, 10);
    }

    private static long Solve1Efficient(List<long> orig, int mixes)
    {
        // Use a record with the index and value because searching for just the value is not good enough (the input
        // can contain duplicates)
        List<NodeVal> shuffled = orig.Select((val, i) => new NodeVal(i, val)).ToList();
        NodeVal zeroVal = null;

        for (int j = 0; j < mixes; j++)
        {
            for (int i = 0; i < orig.Count; i++)
            {
                NodeVal val = new(i, orig[i]);
                if (orig[i] == 0)
                {
                    zeroVal = val;
                }

                int oldPos = shuffled.FindIndex(x => x.Equals(val));
                long newPos = oldPos + val.Val;

                shuffled.RemoveAt(oldPos);

                // Account for the final destination being out of range in either direction. The trick is to use the
                // little mod formulas below to get into the target range. Repeated addition or subtraction works for
                // part 1, but is too slow for the large numbers in part 2
                if (newPos < 0)
                {
                    newPos = shuffled.Count - (Math.Abs(newPos) % shuffled.Count);
                }
                else if (newPos >= shuffled.Count)
                {
                    newPos %= shuffled.Count;
                }

                shuffled.Insert((int)newPos, val);
            }
        }

        int finalIdx = shuffled.FindIndex(x => x.Equals(zeroVal));
        long finalSum = 0;
        for (int i = 1; i <= 3000; i++)
        {
            finalIdx++;
            if (finalIdx == shuffled.Count)
            {
                finalIdx = 0;
            }

            if (i > 0 && i % 1000 == 0)
            {
                finalSum += shuffled[finalIdx].Val;
            }
        }

        return finalSum;
    }

    private record NodeVal(int Idx, long Val);
}
