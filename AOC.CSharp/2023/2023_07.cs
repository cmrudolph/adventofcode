namespace AOC.CSharp;

public static class AOC2023_07
{
    public static long Solve1(string[] lines)
    {
        var hands = lines.Select(Parse).ToList();
        var strengths = hands.Select(GetStrength).ToList();
        var ordered = strengths.Order(new StrengthComparer()).ToList();

        long sum = 0;

        for (int i = 0; i < ordered.Count; i++)
        {
            Strength s = ordered[i];
            int rank = i + 1;
            sum += rank * s.Hand.Bid;
        }

        return sum;
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private static Strength GetStrength(Hand h)
    {
        Dictionary<int, int> counts = h.Cards
            .GroupBy(x => x)
            .ToDictionary(x2 => x2.Key, x2 => x2.Count());

        if (counts.Values.Any(c => c == 5))
        {
            return new(7, h);
        }

        if (counts.Values.Any(c => c == 4))
        {
            return new(6, h);
        }

        if (counts.Values.Any(c => c == 3) && counts.Values.Any(c => c == 2))
        {
            return new(5, h);
        }

        if (counts.Values.Any(c => c == 3))
        {
            return new(4, h);
        }

        if (counts.Values.Count(c => c == 2) == 2)
        {
            return new(3, h);
        }

        if (counts.Values.Any(c => c == 2))
        {
            return new(2, h);
        }

        return new(1, h);
    }

    private static Hand Parse(string line)
    {
        string[] splits = line.Split(" ");
        string cards = splits[0];
        int bid = int.Parse(splits[1]);

        int ToNum(char ch)
        {
            return ch switch
            {
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => int.Parse(ch.ToString())
            };
        }

        int[] cardsAsNums = cards.Select(ToNum).ToArray();

        return new(cardsAsNums, bid);
    }

    private class StrengthComparer : IComparer<Strength>
    {
        public int Compare(Strength x, Strength y)
        {
            if (x.Type < y.Type)
            {
                return -1;
            }

            if (x.Type > y.Type)
            {
                return 1;
            }

            for (int i = 0; i < x.Hand.Cards.Length; i++)
            {
                int cardX = x.Hand.Cards[i];
                int cardY = y.Hand.Cards[i];

                if (cardX < cardY)
                {
                    return -1;
                }

                if (cardX > cardY)
                {
                    return 1;
                }
            }

            return 0;
        }
    }

    private record Strength(int Type, Hand Hand)
    {
        public override string ToString() =>
            $"{Type} | {string.Join(", ", Hand.Cards)} | {Hand.Bid}";
    }

    private record Hand(int[] Cards, int Bid);
}
