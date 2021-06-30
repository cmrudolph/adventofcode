using System;

namespace AOC.CSharp
{
    public static class AOC2015_09
    {
        public static Tuple<long, long> Solve(string[] rawLines)
        {
            Permute(rawLines, 3, 0);
            return Tuple.Create(0L, 0L);
        }

        private static void Permute(string[] cities, int n, int i)
        {
            void Swap(string[] arr, int idx1, int idx2)
            {
                string temp = arr[idx1];
                arr[idx1] = arr[idx2];
                arr[idx2] = temp;
            }

            if (i >= (n - 1))
            {
                Console.WriteLine(string.Join(", ", cities));
            }
            else
            {
                Permute(cities, n, i + 1);
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        Swap(cities, i, j);
                        Permute(cities, n, i + 1);
                        Swap(cities, i, j);
                    }
                }
            }
        }
    }
}
