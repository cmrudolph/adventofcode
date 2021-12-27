namespace AOC.CSharp;

public static class AOC2021_21
{
    private static readonly List<Case> Cases = new()
    {
        new Case(3, 1),
        new Case(4, 3),
        new Case(5, 6),
        new Case(6, 7),
        new Case(7, 6),
        new Case(8, 3),
        new Case(9, 1),
    };

    private const int Target2 = 21;

    public static long Solve1(string[] lines)
    {
        int startPos1 = lines[0][28] - '0';
        int startPos2 = lines[1][28] - '0';

        int[] pos = { startPos1, startPos2 };
        long[] scores = { 0, 0 };
        int dice = 1;
        int playerIdx = 0;
        int totalRolls = 0;

        while (scores.All(s => s < 1000))
        {
            int toAdd = 0;
            for (int i = 0; i < 3; i++)
            {
                toAdd += dice;
                dice++;
                totalRolls++;
                if (dice % 101 == 0)
                {
                    dice = 1;
                }
            }

            pos[playerIdx] += toAdd;
            pos[playerIdx] %= 10;
            if (pos[playerIdx] == 0)
            {
                pos[playerIdx] = 10;
            }

            scores[playerIdx] += pos[playerIdx];
            playerIdx++;
            playerIdx %= 2;
        }

        return Math.Min(scores[0], scores[1]) * totalRolls;
    }

    public static long Solve2(string[] lines)
    {
        int startPos1 = lines[0][28] - '0';
        int startPos2 = lines[1][28] - '0';

        int[] pos = { startPos1, startPos2 };
        int[] scores = { 0, 0 };
        Dictionary<ulong, long[]> cache = new();

        long[] wins = Recurse(cache, pos, scores, 0);

        return Math.Max(wins[0], wins[1]);
    }

    private static long[] Recurse(Dictionary<ulong, long[]> cache, int[] pos, int[] scores, int idx)
    {
        // Use the memoized result if we have already seen it
        ulong key = MakeCacheKey(pos, scores, idx);
        if (cache.TryGetValue(key, out long[] cached))
        {
            return cached;
        }

        int scoreBefore = scores[idx];
        long[] wins = new long[2];

        // Process each possible next branch. We can "batch" these searches up since all we care about is the sum of
        // the 3 dice. We can count the possible sums and add/multiply by this value rather than walking through each
        // case explicitly
        foreach (var c in Cases)
        {
            int posAfterMove = Move(pos[idx], c.MoveAmount);

            if (scoreBefore + posAfterMove >= Target2)
            {
                // Base case. We arrived at or passed the target, so we simply count the number of occurrences of this
                // sum and add that many wins
                wins[idx] += c.Times;
            }
            else
            {
                // Recursive case. Update the positions and scores and proceed to the next roll. Once the recursion
                // returns to us, we can multiply the wins we get back by the number of times we need to go down
                // this path
                int oldScore = scores[idx];
                int oldPos = pos[idx];
                scores[idx] += posAfterMove;
                pos[idx] = posAfterMove;
                long[] recWins = Recurse(cache, pos, scores, idx == 0 ? 1 : 0);
                wins[0] += c.Times * recWins[0];
                wins[1] += c.Times * recWins[1];
                pos[idx] = oldPos;
                scores[idx] = oldScore;
            }
        }

        cache.Add(key, wins);
        return wins;
    }

    private static ulong MakeCacheKey(int[] pos, int[] scores, int idx)
    {
        ulong key = 0;
        key |= (ulong)pos[0] << 32;
        key |= (uint)pos[1] << 24;
        key |= (uint)scores[0] << 16;
        key |= (uint)scores[1] << 8;
        key |= (uint)idx;

        return key;
    }

    private static int Move(int startingPos, int moveAmount)
    {
        int posAfterMove = startingPos + moveAmount;
        posAfterMove %= 10;
        if (posAfterMove == 0)
        {
            posAfterMove = 10;
        }

        return posAfterMove;
    }

    private record Case(int MoveAmount, int Times);
}
