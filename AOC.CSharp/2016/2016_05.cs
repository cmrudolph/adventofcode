using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AOC.CSharp
{
    public static class AOC2016_05
    {
        const int ChunkSize = 800000;
        const int ParallelWorkers = 8;

        public static string Solve1(string[] lines)
        {
            string prefix = lines[0];
            string password = "";
            int i = 0;

            while (password.Length < 8)
            {
                ValidHashResult[] results = TryGenerateResultsChunk(prefix, i, i + ChunkSize, password.Length, ParallelWorkers);
                for (int j = 0; password.Length < 8 && j < results.Length; j++)
                {
                    ValidHashResult result = results[j];
                    password = password + result.Value;
                }
                i += ChunkSize;
            }

            return password;
        }

        public static string Solve2(string[] lines)
        {
            const int ChunkSize = 800000;

            string prefix = lines[0];
            char[] password = new char[8];
            int passwordChars = 0;
            int i = 0;

            while (passwordChars < 8)
            {
                ValidHashResult[] results = TryGenerateResultsChunk(prefix, i, i + ChunkSize, null, ParallelWorkers);
                for (int j = 0; passwordChars < 8 && j < results.Length; j++)
                {
                    ValidHashResult result = results[j];
                    if (password[result.Position] == '\0')
                    {
                        password[result.Position] = result.Value;
                        passwordChars++;
                    }
                }
                i += ChunkSize;
            }

            return new string(password);
        }

        private static ValidHashResult[] TryGenerateResultsChunk(
            string prefix,
            int startIdxInc,
            int endIdxExc,
            int? pos,
            int parallel)
        {
            int totalToCalc = endIdxExc - startIdxInc;
            int workSize = totalToCalc / parallel;
            if (workSize * parallel != totalToCalc)
            {
                throw new InvalidOperationException("Make sure range is divisible by parallel");
            }

            ValidHashResult[] arr = new ValidHashResult[totalToCalc];
            List<Tuple<int, int>> ranges = new();
            for (int i = 0; i < parallel; i++)
            {
                int start = startIdxInc + (i * workSize);
                int end = start + workSize;
                ranges.Add(Tuple.Create(start, end));
            }

            Parallel.For(0, parallel, i =>
            {
                int arrOffset = i * workSize;
                ComputeHashResultsSingleWorker(arr, prefix, arrOffset, ranges[i].Item1, ranges[i].Item2, pos);
            });

            return arr.Where(a => a != null).ToArray();
        }

        private static void ComputeHashResultsSingleWorker(
            ValidHashResult[] arr,
            string prefix,
            int arrOffset,
            int startIdxInc,
            int endIdxExc,
            int? pos)
        {
            StringBuilder hashSb = new();
            MD5 md5 = MD5.Create();

            for (int i = startIdxInc; i < endIdxExc; i++)
            {
                string toHash = prefix + i;
                arr[arrOffset + i - startIdxInc] = TryGetHashResult(md5, hashSb, toHash, pos);
            }
        }

        private static ValidHashResult TryGetHashResult(MD5 md5, StringBuilder hashSb, string toHash, int? pos)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(toHash);
            byte[] hashed = md5.ComputeHash(bytes);

            if (hashed[0] == 0 && hashed[1] == 0 && (hashed[2] & 0xF0) == 0)
            {
                // Compute the hash as a hex string
                hashSb.Clear();
                for (int i = 0; i < hashed.Length; i++)
                {
                    hashSb.Append(hashed[i].ToString("x2"));
                }

                string asStr = hashSb.ToString();

                // If the position was passed in, use it. Otherwise derive it from the hash
                int finalPos = pos.HasValue
                    ? pos.Value
                    : (asStr[5] >= '0' && asStr[5] <= '7')
                        ? asStr[5] - '0'
                        : -1;

                // Vary where we find the password value based on whether or not we were passed a position
                if (finalPos > -1)
                {
                    char value = pos.HasValue
                        ? asStr[5]
                        : asStr[6];

                    return new ValidHashResult(finalPos, value);
                }
            }

            return null;
        }

        private record ValidHashResult(int Position, char Value);
    }
}