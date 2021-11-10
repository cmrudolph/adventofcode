namespace AOC.CSharp
{
    public static class AOC2017_01
    {
        public static long Solve1(string[] lines)
        {
            string digits = lines[0];

            int sum = 0;
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                {
                    sum += digits[i] - '0';
                }
            }

            if (digits[digits.Length - 1] == digits[0])
            {
                sum += digits[0] - '0';
            }

            return sum;
        }

        public static long Solve2(string[] lines)
        {
            string digits = lines[0];
            int half = digits.Length / 2;

            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                int compareIdx = (i + half) % digits.Length;
                if (digits[i] == digits[compareIdx])
                {
                    sum += digits[i] - '0';
                }
            }
            return sum;
        }
    }
}