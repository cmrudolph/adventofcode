using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp
{
    public static class AOC2015_20
    {
        public static long Solve1(string[] lines)
        {
            int input = int.Parse(lines[0]);
            int i = 0;
            int presents = 0;

            do
            {
                i++;
                var factors = GetFactors(i);
                presents = factors.Select(f => f * 10).Sum();
            }
            while (presents < input);

            return i;
        }

        public static long Solve2(string[] lines)
        {
            int input = int.Parse(lines[0]);
            int i = 0;
            int presents = 0;

            Dictionary<int, int> elfCount = new();

            do
            {
                i++;
                presents = 0;
                var factors = GetFactors(i);

                foreach (int f in factors)
                {
                    int existingCount = elfCount.TryGetValue(f, out int c) ? c : 0;
                    int newCount = existingCount + 1;

                    elfCount[f] = newCount;
                    if (newCount <= 50)
                    {
                        presents += (f * 11);
                    }
                }
            }
            while (presents < input);

            return i;
        }

        private static List<int> GetFactors(int x)
        {
            int sqrt = (int)Math.Ceiling(Math.Sqrt(x));

            HashSet<int> factors = new();
            for (int i = 1; i <= sqrt; i++)
            {
                if (x % i == 0)
                {
                    factors.Add(i);
                    factors.Add(x / i);
                }
            }
            factors.Add(x);

            return factors.ToList();
        }
    }
}