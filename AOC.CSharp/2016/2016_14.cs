using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AOC.CSharp
{
    public class AOC2016_14
    {
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
            StringBuilder hashSb = new();
            MD5 md5 = MD5.Create();

            // Generate the first 1000 hashes right away. Each iteration will generate one more so we always have
            // 1000 future results to work with.
            List<HashResult> results = new();
            for (int i = 0; i < 1000; i++)
            {
                results.Add(GetHashResult(md5, hashSb, salt, i, md5Count));
            }

            int keyCount = 0;
            int j = -1;
            while (keyCount < 64)
            {
                j++;
                var nextGen = GetHashResult(md5, hashSb, salt, j + 1000, md5Count);
                results.Add(nextGen);

                var curr = results[j];
                if (curr.Triplet != null)
                {
                    for (int k = j + 1; k < j + 1001; k++)
                    {
                        if (results[k].Fives.Contains(curr.Triplet))
                        {
                            keyCount++;
                        }
                    }
                }
            }

            return j;
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
                for (int j = 0; j < hashed.Length; j++)
                {
                    hashSb.Append(hashed[j].ToString("x2"));
                }
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

            HashSet<string> fives = new();
            for (int j = 0; j < asStr.Length - 4; j++)
            {
                char ch = asStr[j];
                if (ch == asStr[j + 1] && ch == asStr[j + 2] && ch == asStr[j + 3] && ch == asStr[j + 4])
                {
                    fives.Add(new string(ch, 3));
                }
            }

            return new HashResult(asStr, triplet, fives);
        }

        private record HashResult(string Raw, string Triplet, HashSet<string> Fives);
    }
}