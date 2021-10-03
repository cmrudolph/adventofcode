using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public static class AOC2016_04
    {
        private static readonly Regex Regex = new(@"(\D+)(\d+)\[(\D+)\]");

        public static long Solve1(string[] lines)
        {
            int result = lines
                .Select(Parse)
                .Select(ToSumValue)
                .Sum();

            return result;
        }

        public static long Solve2(string[] lines)
        {
            int result = lines
                .Select(Parse)
                .Select(p => Tuple.Create(p, Decrypt(p)))
                .First(tup => tup.Item2.Contains("northpole object storage "))
                .Item1.SectorId;

            return result;
        }

        private static int ToSumValue(Parsed parsed)
        {
            bool valid = parsed.TopLetters == parsed.Checksum;
            return valid ? parsed.SectorId : 0;
        }

        private static string Decrypt(Parsed parsed)
        {
            int shiftAmount = parsed.SectorId % 26;
            char[] chars = parsed.Letters.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '-')
                {
                    chars[i] = ' ';
                }
                else
                {
                    int shifted = chars[i] + shiftAmount;
                    int overage = shifted - 'z';
                    if (overage > 0)
                    {
                        shifted = 'a' + overage - 1;
                    }

                    chars[i] = (char) shifted;
                }
            }

            return new string(chars);
        }

        private static Parsed Parse(string line)
        {
            Match m = Regex.Match(line);

            string letters = m.Groups[1].Value;
            int sectorId = int.Parse(m.Groups[2].Value);
            string checksum = m.Groups[3].Value;

            char[] topLetters = letters
                .Replace("-", "")
                .GroupBy(ch => ch)
                .Select(g => new LetterCount(g.Key, g.Count()))
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.Letter)
                .Take(5)
                .Select(c => c.Letter)
                .ToArray();

            return new Parsed(letters, new string(topLetters), sectorId, checksum);
        }

        private record Parsed(string Letters, string TopLetters, int SectorId, string Checksum);

        private record LetterCount(char Letter, int Count);
    }
}