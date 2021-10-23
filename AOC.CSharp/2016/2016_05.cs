using System.Security.Cryptography;
using System.Text;

namespace AOC.CSharp
{
    public static class AOC2016_05
    {
        public static string Solve1(string[] lines)
        {
            StringBuilder hashSb = new();
            MD5 md5 = MD5.Create();

            string prefix = lines[0];
            string password = "";
            int i = 0;

            while (password.Length < 8)
            {
                ValidHashResult result = TryGetHashResult(md5, hashSb, prefix + i, password.Length);
                if (result != null)
                {
                    password = password + result.Value;
                }
                i++;
            }
            return password;
        }

        public static string Solve2(string[] lines)
        {
            StringBuilder hashSb = new();
            MD5 md5 = MD5.Create();

            string prefix = lines[0];
            char[] password = new char[8];
            int passwordChars = 0;
            int i = 0;

            while (passwordChars < 8)
            {
                ValidHashResult result = TryGetHashResult(md5, hashSb, prefix + i, null);
                if (result != null)
                {
                    if (password[result.Position] == '\0')
                    {
                        password[result.Position] = result.Value;
                        passwordChars++;
                    }
                }
                i++;
            }
            return new string(password);
        }

        private static ValidHashResult TryGetHashResult(MD5 md5, StringBuilder hashSb, string toHash, int? pos)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(toHash);
            byte[] hashed = md5.ComputeHash(bytes);

            // Compute the hash as a hex string
            hashSb.Clear();
            for (int i = 0; i < hashed.Length; i++)
            {
                hashSb.Append(hashed[i].ToString("x2"));
            }

            string asStr = hashSb.ToString();
            if (asStr.StartsWith("00000"))
            {
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