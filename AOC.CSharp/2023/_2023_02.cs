using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2023_02
{
    private static Regex Regex = new(@"Game (\d+): (.*)");

    public static long Solve1(string[] lines)
    {
        static int GetGameValue(string line)
        {
            Match m = Regex.Match(line);
            int gameId = int.Parse(m.Groups[1].Value);
            string rest = m.Groups[2].Value;

            bool possible = true;

            string[] pulls = rest.Split(";");
            foreach (string pull in pulls)
            {
                string[] colorSplits = pull.Split(",");

                int red = 0;
                int blue = 0;
                int green = 0;

                foreach (string s in colorSplits)
                {
                    string[] colorAndNum = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int num = int.Parse(colorAndNum[0]);
                    string color = colorAndNum[1];

                    if (color == "red")
                    {
                        red = num;
                    }

                    if (color == "blue")
                    {
                        blue = num;
                    }

                    if (color == "green")
                    {
                        green = num;
                    }

                    if (red > 12 || green > 13 || blue > 14)
                    {
                        possible = false;
                    }
                }
            }

            return possible ? gameId : 0;
        }

        return lines.Select(GetGameValue).Sum();
    }

    public static long Solve2(string[] lines)
    {
        static int GetGameValue(string line)
        {
            int redMax = 0;
            int blueMax = 0;
            int greenMax = 0;

            Match m = Regex.Match(line);
            int gameId = int.Parse(m.Groups[1].Value);
            string rest = m.Groups[2].Value;

            string[] pulls = rest.Split(";");
            foreach (string pull in pulls)
            {
                string[] colorSplits = pull.Split(",");

                foreach (string s in colorSplits)
                {
                    string[] colorAndNum = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int num = int.Parse(colorAndNum[0]);
                    string color = colorAndNum[1];

                    if (color == "red")
                    {
                        redMax = Math.Max(num, redMax);
                    }

                    if (color == "blue")
                    {
                        blueMax = Math.Max(num, blueMax);
                    }

                    if (color == "green")
                    {
                        greenMax = Math.Max(num, greenMax);
                    }
                }
            }

            return redMax * blueMax * greenMax;
        }

        return lines.Select(GetGameValue).Sum();
    }
}
