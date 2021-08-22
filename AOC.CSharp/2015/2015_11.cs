using System;
using System.Linq;

namespace AOC.CSharp
{
    public static class AOC2015_11
    {
        private static readonly int[] BannedDigits = new int[]
        {
            'i' - 'a',
            'l' - 'a',
            'o' - 'a',
        };

        public static string Solve1(string[] lines)
        {
            return FindNextPassword(lines[0]);
        }

        public static string Solve2(string[] lines)
        {
            return FindNextPassword(FindNextPassword(lines[0]));
        }

        private static string FindNextPassword(string password)
        {
            int[] numeric = StringToNumeric(password);

            bool isValid;
            do
            {
                Increment(numeric);
                isValid = IsValid(numeric);
            } while (!isValid);

            return NumericToString(numeric);
        }

        private static int[] StringToNumeric(string s)
        {
            return s.ToCharArray().Select(c => c - 'a').ToArray();
        }

        private static string NumericToString(int[] arr)
        {
            return new string(arr.Select(a => (char) ('a' + a)).ToArray());
        }

        private static bool IsValid(int[] arr)
        {
            if (!ContainsIncreasingStraight(arr))
            {
                return false;
            }

            if (CountDifferentNonOverlappingPairs(arr) < 2)
            {
                return false;
            }

            if (ContainsBannedDigit(arr))
            {
                return false;
            }

            return true;
        }

        private static void Increment(int[] arr)
        {
            int idx = arr.Length - 1;
            arr[idx]++;
            while (arr[idx] == 26)
            {
                arr[idx] = 0;
                arr[idx - 1]++;
                idx--;
            }
        }

        private static bool ContainsBannedDigit(int[] arr)
        {
            return BannedDigits.Any(d => arr.Contains(d));
        }

        private static int CountDifferentNonOverlappingPairs(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    count += 1;
                    i++;
                }
            }

            return count;
        }

        private static bool ContainsIncreasingStraight(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if ((arr[i] == arr[i + 1] - 1) && (arr[i + 1] == arr[i + 2] - 1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}