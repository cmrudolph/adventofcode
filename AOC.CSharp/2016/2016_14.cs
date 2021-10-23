using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AOC.CSharp
{
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
                ByteUtils.ConvertToBase16Fast2Lower(hashed, hashSb);
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

        private record HashResult(string Raw, string Triplet, HashSet<string> Fives);
    }
}