namespace AOC.CSharp;

public static class AOC2018_14
{
    public static long Solve1(string[] lines)
    {
        int input = int.Parse(lines[0]);
        int stopNum = input + 20;

        int[] nums = new int[1000000];
        nums[0] = 3;
        nums[1] = 7;

        int elf1Pos = 0;
        int elf2Pos = 1;
        int nextIdx = 2;

        while (nextIdx < stopNum)
        {
            int elf1 = nums[elf1Pos];
            int elf2 = nums[elf2Pos];
            int sum = elf1 + elf2;
            int[] newDigits = sum.ToString().Select(ch => int.Parse(ch.ToString())).ToArray();
            for (int i = 0; i < newDigits.Length; i++)
            {
                nums[nextIdx] = newDigits[i];
                nextIdx++;
            }

            for (int i = 0; i < elf1 + 1; i++)
            {
                elf1Pos++;
                if (elf1Pos == nextIdx)
                {
                    elf1Pos = 0;
                }
            }

            for (int i = 0; i < elf2 + 1; i++)
            {
                elf2Pos++;
                if (elf2Pos == nextIdx)
                {
                    elf2Pos = 0;
                }
            }
        }

        long final = 0;
        for (int i = input; i < input + 10; i++)
        {
            final *= 10;
            int num = nums[i];
            final += num;
        }

        return final;
    }

    public static long Solve2(string[] lines)
    {
        int input = int.Parse(lines[0]);
        int[] inputDigits = input.ToString().Select(x => int.Parse(x.ToString())).ToArray();

        int[] nums = new int[1000000000];
        nums[0] = 3;
        nums[1] = 7;

        int elf1Pos = 0;
        int elf2Pos = 1;
        int nextIdx = 2;

        int checkStart = 0;

        while (true)
        {
            int elf1 = nums[elf1Pos];
            int elf2 = nums[elf2Pos];
            int sum = elf1 + elf2;
            int[] newDigits = sum.ToString().Select(ch => int.Parse(ch.ToString())).ToArray();
            for (int i = 0; i < newDigits.Length; i++)
            {
                nums[nextIdx] = newDigits[i];
                nextIdx++;
            }

            for (int i = 0; i < elf1 + 1; i++)
            {
                elf1Pos++;
                if (elf1Pos == nextIdx)
                {
                    elf1Pos = 0;
                }
            }

            for (int i = 0; i < elf2 + 1; i++)
            {
                elf2Pos++;
                if (elf2Pos == nextIdx)
                {
                    elf2Pos = 0;
                }
            }

            while (checkStart < nextIdx - inputDigits.Length)
            {
                bool match = true;
                int inputDigitsIdx = 0;
                for (int i = checkStart; match && i < checkStart + inputDigits.Length; i++)
                {
                    match &= nums[i] == inputDigits[inputDigitsIdx];
                    inputDigitsIdx++;
                }

                if (match)
                {
                    return checkStart;
                }

                checkStart++;
            }
        }
    }
}
