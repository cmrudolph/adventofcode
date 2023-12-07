namespace AOC.CSharp;

public static class AOC2023_07
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines, false);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, true);
    }

    private static long Solve(string[] lines, bool joker)
    {
        var hands = lines.Select(x => Parse(x, joker)).ToList();
        var strengths = hands.Select(x => GetStrength(x, joker)).ToList();
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

    private static Strength GetStrength(Hand h, bool joker)
    {
        List<int[]> cardArrangements = new();
        if (joker)
        {
            for (int i = 2; i <= 14; i++)
            {
                // Try substituting each other card for each joker
                cardArrangements.Add(h.Cards.Select(x => x == 1 ? i : x).ToArray());
            }
        }
        else
        {
            cardArrangements.Add(h.Cards);
        }

        int bestType = 1;

        foreach (int[] ca in cardArrangements)
        {
            Dictionary<int, int> counts = ca.GroupBy(x => x)
                .ToDictionary(x2 => x2.Key, x2 => x2.Count());

            if (counts.Values.Any(c => c == 5))
            {
                return new(7, h);
            }

            if (bestType < 6 && counts.Values.Any(c => c == 4))
            {
                bestType = Math.Max(bestType, 6);
            }

            if (bestType < 5 && counts.Values.Any(c => c == 3) && counts.Values.Any(c => c == 2))
            {
                bestType = Math.Max(bestType, 5);
            }

            if (bestType < 4 && counts.Values.Any(c => c == 3))
            {
                bestType = Math.Max(bestType, 4);
            }

            if (bestType < 3 && counts.Values.Count(c => c == 2) == 2)
            {
                bestType = Math.Max(bestType, 3);
            }

            if (bestType < 2 && counts.Values.Any(c => c == 2))
            {
                bestType = Math.Max(bestType, 2);
            }
        }

        return new(bestType, h);
    }

    private static Hand Parse(string line, bool joker)
    {
        string[] splits = line.Split(" ");
        string cards = splits[0];
        int bid = int.Parse(splits[1]);

        int ToNum(char ch)
        {
            return ch switch
            {
                'T' => 10,
                'J' when !joker => 11,
                'J' when joker => 1,
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
