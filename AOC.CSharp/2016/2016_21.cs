using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC.CSharp;

public class AOC2016_21
{
    private static Regex SwapPosWithPos = new(@"swap position (\d+) with position (\d+)");
    private static Regex SwapLetterWithLetter = new(@"swap letter (\w) with letter (\w)");
    private static Regex RotateXSteps = new(@"rotate (.*) (\d+) step");
    private static Regex RotateBasedOnPosition = new(@"rotate based on position of letter (\w)");
    private static Regex ReversePositions = new(@"reverse positions (\d+) through (\d+)");
    private static Regex MovePosition = new(@"move position (\d+) to position (\d+)");

    public static string Solve1(string[] lines, string extra)
    {
        StringBuilder sb = new(extra);

        // Build up the transformations and apply them once to scramble the input value
        List<Action<StringBuilder>> transformations = BuildTransformList(lines);
        transformations.ForEach(t => t(sb));

        return sb.ToString();
    }

    public static string Solve2(string[] lines, string extra)
    {
        string target = extra;

        // Build up the transformations and then apply the transformation to all the permutations of the
        // target string (potential inputs) until we find the one that produces the desired result. I don't
        // think we can run the actual steps in reverse, but the length of the password is short enough
        // that we can brute force it quickly.
        List<Action<StringBuilder>> transformations = BuildTransformList(lines);
        Func<string, string> scramble = s =>
        {
            StringBuilder sb = new(s);
            transformations.ForEach(t => t(sb));
            return sb.ToString();
        };

        string result = FindWorkingPermutation(extra, 0, extra.Length - 1, scramble, target);

        return result;
    }

    private static List<Action<StringBuilder>> BuildTransformList(string[] lines)
    {
        List<Action<StringBuilder>> actions = new();

        foreach (string line in lines)
        {
            Match swapPosWithPos = SwapPosWithPos.Match(line);
            if (swapPosWithPos.Success)
            {
                int pos1 = int.Parse(swapPosWithPos.Groups[1].Value);
                int pos2 = int.Parse(swapPosWithPos.Groups[2].Value);

                Action<StringBuilder> a = sb =>
                {
                    Swap(sb, pos1, pos2);
                };

                actions.Add(a);
            }

            Match swapLetterWithLetter = SwapLetterWithLetter.Match(line);
            if (swapLetterWithLetter.Success)
            {
                char ch1 = swapLetterWithLetter.Groups[1].Value[0];
                char ch2 = swapLetterWithLetter.Groups[2].Value[0];

                Action<StringBuilder> a = sb =>
                {
                    int pos1 = sb.ToString().IndexOf(ch1);
                    int pos2 = sb.ToString().IndexOf(ch2);

                    Swap(sb, pos1, pos2);
                };

                actions.Add(a);
            }

            Match rotateXSteps = RotateXSteps.Match(line);
            if (rotateXSteps.Success)
            {
                string direction = rotateXSteps.Groups[1].Value;
                int amount = int.Parse(rotateXSteps.Groups[2].Value);

                actions.Add(sb =>
                {
                    if (direction == "right")
                    {
                        RotateRight(sb, amount);
                    }
                    else
                    {
                        RotateLeft(sb, amount);
                    }
                });
            }

            Match rotateBasedOnPosition = RotateBasedOnPosition.Match(line);
            if (rotateBasedOnPosition.Success)
            {
                char ch = rotateBasedOnPosition.Groups[1].Value[0];

                actions.Add(sb =>
                {
                    int pos = sb.ToString().IndexOf(ch);
                    int amount = pos >= 4 ? pos + 2 : pos + 1;
                    RotateRight(sb, amount);
                });
            }

            Match reversePositions = ReversePositions.Match(line);
            if (reversePositions.Success)
            {
                int pos1 = int.Parse(reversePositions.Groups[1].Value);
                int pos2 = int.Parse(reversePositions.Groups[2].Value);

                actions.Add(sb =>
                {
                    int j = pos2;
                    for (int i = pos1; i < j; i++)
                    {
                        char temp = sb[i];
                        sb[i] = sb[j];
                        sb[j] = temp;
                        j--;
                    }
                });
            }

            Match movePosition = MovePosition.Match(line);
            if (movePosition.Success)
            {
                int pos1 = int.Parse(movePosition.Groups[1].Value);
                int pos2 = int.Parse(movePosition.Groups[2].Value);

                actions.Add(sb =>
                {
                    char ch = sb[pos1];
                    sb.Remove(pos1, 1);
                    sb.Insert(pos2, ch);
                });
            }
        }

        return actions;
    }

    private static void Swap(StringBuilder sb, int pos1, int pos2)
    {
        char temp = sb[pos1];
        sb[pos1] = sb[pos2];
        sb[pos2] = temp;
    }

    private static void RotateRight(StringBuilder sb, int count)
    {
        for (int i = 0; i < count; i++)
        {
            char ch = sb[sb.Length - 1];
            sb.Remove(sb.Length - 1, 1);
            sb.Insert(0, ch);
        }
    }

    private static void RotateLeft(StringBuilder sb, int count)
    {
        for (int i = 0; i < count; i++)
        {
            char ch = sb[0];
            sb.Remove(0, 1);
            sb.Insert(sb.Length, ch);
        }
    }

    private static string FindWorkingPermutation(string s, int left, int right, Func<string, string> scramble, string target)
    {
        static string SwapInStr(string s, int pos1, int pos2)
        {
            char temp;
            char[] charArray = s.ToCharArray();
            temp = charArray[pos1];
            charArray[pos1] = charArray[pos2];
            charArray[pos2] = temp;
            return new string(charArray);
        }

        if (left == right)
        {
            string scrambled = scramble(s);
            if (scrambled == target)
            {
                return s;
            }
            return null;
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                s = SwapInStr(s, left, i);
                string solution = FindWorkingPermutation(s, left + 1, right, scramble, target);
                if (solution != null)
                {
                    return solution;
                }
                s = SwapInStr(s, left, i);
            }
            return null;
        }
    }
}
