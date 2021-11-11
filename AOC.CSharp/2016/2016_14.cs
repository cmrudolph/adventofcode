using System.Security.Cryptography;
using System.Text;

namespace AOC.CSharp;

public class AOC2016_14
{
    // We know this is as far as we need to go (based on solving it). Bake this in as an optimization to
    // make it easier to parallelize things
    private const int MaxIndexToCalculateFor = 23744;

    public static long Solve1(string[] lines)
    {
        string salt = lines[0];
        return Solve(salt, 1);
    }

    public static long Solve2(string[] lines)
    {
        string salt = lines[0];
        return Solve(salt, 2017);
    }

    private static long Solve(string salt, int md5Count)
    {
        HashResult[] arr = new HashResult[MaxIndexToCalculateFor];
        ComputeHashResultsParallel(arr, salt, md5Count, 0, MaxIndexToCalculateFor, 8);

        int keyCount = 0;
        int j = -1;
        while (keyCount < 64)
        {
            j++;

            var curr = arr[j];
            if (curr.Triplet != null)
            {
                for (int k = j + 1; k < j + 1001; k++)
                {
                    if (arr[k].Fives != null && arr[k].Fives.Contains(curr.Triplet))
                    {
                        keyCount++;
                    }
                }
            }
        }

        return j;
    }

    private static void ComputeHashResultsParallel(
        HashResult[] arr,
        string salt,
        int md5Count,
        int startIdxInc,
        int endIdxExc,
        int parallel)
    {
        int totalToCalc = endIdxExc - startIdxInc;
        int workSize = totalToCalc / parallel;
        if (workSize * parallel != totalToCalc)
        {
            throw new InvalidOperationException("Make sure range is divisible by parallel");
        }

        List<Tuple<int, int>> ranges = new();
        for (int i = 0; i < parallel; i++)
        {
            int start = i * workSize;
            int end = start + workSize;
            ranges.Add(Tuple.Create(start, end));
        }

        Parallel.For(0, parallel, i =>
        {
            ComputeHashResultsSingleWorker(arr, salt, md5Count, ranges[i].Item1, ranges[i].Item2);
        });
    }

    private static void ComputeHashResultsSingleWorker(
        HashResult[] arr,
        string salt,
        int md5Count,
        int startIdxInc,
        int endIdxExc)
    {
        StringBuilder hashSb = new();
        MD5 md5 = MD5.Create();

        for (int i = startIdxInc; i < endIdxExc; i++)
        {
            arr[i] = GetHashResult(md5, hashSb, salt, i, md5Count);
        }
    }

    private static HashResult GetHashResult(MD5 md5, StringBuilder hashSb, string salt, int idx, int md5Count)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(salt + idx);
        string asStr = null;

        for (int i = 0; i < md5Count; i++)
        {
            byte[] hashed = md5.ComputeHash(bytes);

            // Compute the hash as a hex string
            hashSb.Clear();
            ConvertToBase16Fast2Lower(hashed, hashSb);
            asStr = hashSb.ToString();
            bytes = Encoding.ASCII.GetBytes(asStr);
        }

        string triplet = null;
        for (int j = 0; triplet == null && j < asStr.Length - 2; j++)
        {
            char ch = asStr[j];
            if (ch == asStr[j + 1] && ch == asStr[j + 2])
            {
                triplet = new string(asStr[j], 3);
            }
        }

        HashSet<string> fives = null;

        if (triplet != null)
        {
            fives = new();
            for (int j = 0; j < asStr.Length - 4; j++)
            {
                char ch = asStr[j];
                if (ch == asStr[j + 1] && ch == asStr[j + 2] && ch == asStr[j + 3] && ch == asStr[j + 4])
                {
                    fives.Add(new string(ch, 3));
                }
            }
        }

        return new HashResult(asStr, triplet, fives);
    }

    private static readonly string[] _base16CharTableLower = new[]
    {
            "00", "01", "02", "03", "04", "05", "06", "07",
            "08", "09", "0a", "0b", "0c", "0d", "0e", "0f",
            "10", "11", "12", "13", "14", "15", "16", "17",
            "18", "19", "1a", "1b", "1c", "1d", "1e", "1f",
            "20", "21", "22", "23", "24", "25", "26", "27",
            "28", "29", "2a", "2b", "2c", "2d", "2e", "2f",
            "30", "31", "32", "33", "34", "35", "36", "37",
            "38", "39", "3a", "3b", "3c", "3d", "3e", "3f",
            "40", "41", "42", "43", "44", "45", "46", "47",
            "48", "49", "4a", "4b", "4c", "4d", "4e", "4f",
            "50", "51", "52", "53", "54", "55", "56", "57",
            "58", "59", "5a", "5b", "5c", "5d", "5e", "5f",
            "60", "61", "62", "63", "64", "65", "66", "67",
            "68", "69", "6a", "6b", "6c", "6d", "6e", "6f",
            "70", "71", "72", "73", "74", "75", "76", "77",
            "78", "79", "7a", "7b", "7c", "7d", "7e", "7f",
            "80", "81", "82", "83", "84", "85", "86", "87",
            "88", "89", "8a", "8b", "8c", "8d", "8e", "8f",
            "90", "91", "92", "93", "94", "95", "96", "97",
            "98", "99", "9a", "9b", "9c", "9d", "9e", "9f",
            "a0", "a1", "a2", "a3", "a4", "a5", "a6", "a7",
            "a8", "a9", "aa", "ab", "ac", "ad", "ae", "af",
            "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7",
            "b8", "b9", "ba", "bb", "bc", "bd", "be", "bf",
            "c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7",
            "c8", "c9", "ca", "cb", "cc", "cd", "ce", "cf",
            "d0", "d1", "d2", "d3", "d4", "d5", "d6", "d7",
            "d8", "d9", "da", "db", "dc", "dd", "de", "df",
            "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7",
            "e8", "e9", "ea", "eb", "ec", "ed", "ee", "ef",
            "f0", "f1", "f2", "f3", "f4", "f5", "f6", "f7",
            "f8", "f9", "fa", "fb", "fc", "fd", "fe", "ff"
        };

    private static void ConvertToBase16Fast2Lower(byte[] input, StringBuilder sb)
    {
        for (var i = 0; i < input.Length; i++)
        {
            sb.Append(_base16CharTableLower[input[i]]);
        }
    }

    private record HashResult(string Raw, string Triplet, HashSet<string> Fives);
}
