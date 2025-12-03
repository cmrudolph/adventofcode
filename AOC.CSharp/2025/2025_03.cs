namespace AOC.CSharp;

public static class AOC2025_03
{
    public static long Solve1(string[] lines)
    {
        int total = 0;
        
        foreach (string line in lines)
        {
            int best = 0;
            for (int i = 0; i < line.Length - 1; i++)
            {
                for (int j = i + 1; j < line.Length; j++)
                {
                    char c1 = line[i];
                    char c2 = line[j];

                    int val = int.Parse(new string([c1, c2]));
                    best = Math.Max(best, val);
                }
            }

            total += best;
        }
        
        return total;
    }

    public static long Solve2(string[] lines)
    {
        long total = 0;

        foreach (string line in lines)
        {
            long best = 0;

            List<int> digits = new();
            
            for (int i = 0; i < line.Length; i++)
            {
                int remaining = line.Length - i - 1;
                int startPos = Math.Max(12 - remaining - 1, 0);
                int newVal = int.Parse(line[i].ToString());

//                Console.WriteLine("I:{0}; R:{1}; SP:{2}; NV:{3}: DG:{4}", i, remaining, startPos, newVal, string.Join("", digits));

                bool handled = false;
                for (int j = startPos; j < digits.Count; j++)
                {
                    if (digits[j] < newVal)
                    {
                        digits[j] = newVal;
                        for (int k = digits.Count -1; k > j; k--)
                        {
                            digits.RemoveAt(k);
                        }
                        
                        handled = true;
                        break;
                    }
                }

                if (!handled && digits.Count < 12)
                {
                    digits.Add(newVal);
                }
            }

            string combined = string.Join("", digits);
            Console.WriteLine(combined);
            total += long.Parse(combined);
        }
        
        return total;
    }
}
