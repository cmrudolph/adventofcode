using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp
{
    public static class AOC2015_17
    {
        public static long Solve1(string[] lines, int target)
        {
            int[] values = lines.Select(int.Parse).ToArray();
            Dictionary<int, int> counts = new();
            Recurse(values, counts, 0, 1, values.Length - 1, target);

            return counts.Values.Sum();
        }

        public static long Solve2(string[] lines, int target)
        {
            int[] values = lines.Select(int.Parse).ToArray();
            Dictionary<int, int> counts = new();
            Recurse(values, counts, 0, 1, values.Length - 1, target);

            int minKey = counts.Keys.Min();
            return counts[minKey];
        }

        private static void Recurse(int[] arr, Dictionary<int, int> counts, int total, int containers, int index, int target)
        {
            if (total == target)
            {
                counts[containers] = counts.TryGetValue(containers, out int v) ? v + 1 : 1;
                return;
            }
            if (total > target)
            {
                return;
            }
            if (index < 0)
            {
                return;
            }

            int currValue = arr[index];

            // Call with the current container added
            Recurse(arr, counts, total + currValue, containers + 1, index - 1, target);

            // Call without the current container added
            Recurse(arr, counts, total, containers, index - 1, target);
        }
    }
}