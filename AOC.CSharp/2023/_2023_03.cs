namespace AOC.CSharp;

public static class AOC2023_03
{
    public static long Solve1(string[] lines)
    {
        List<int> digits = new();
        string currDigits = null;

        HashSet<char> neighborSymbols = new();

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines.Length; x++)
            {
                char ch = lines[y][x];
                if (char.IsDigit(ch))
                {
                    if (currDigits == null)
                    {
                        if (x > 0)
                        {
                            // LEFT
                            neighborSymbols.Add(lines[y][x - 1]);

                            if (y > 0)
                            {
                                // UP + LEFT
                                neighborSymbols.Add(lines[y - 1][x - 1]);
                            }
                            if (y < lines.Length - 1)
                            {
                                // DOWN + LEFT
                                neighborSymbols.Add(lines[y + 1][x - 1]);
                            }
                        }

                        if (y > 0)
                        {
                            // UP
                            neighborSymbols.Add(lines[y - 1][x]);
                        }
                        if (y < lines.Length - 1)
                        {
                            // DOWN
                            neighborSymbols.Add(lines[y + 1][x]);
                        }

                        if (!char.IsDigit(lines[y][x + 1]))
                        {
                            // RIGHT
                            neighborSymbols.Add(lines[y][x + 1]);

                            if (y > 0)
                            {
                                // UP + RIGHT
                                neighborSymbols.Add(lines[y - 1][x + 1]);
                            }
                            if (y < lines.Length - 1)
                            {
                                // DOWN + RIGHT
                                neighborSymbols.Add(lines[y + 1][x + 1]);
                            }
                        }
                    }
                    else
                    {
                        if (x < lines[y].Length - 1)
                        {
                            if (y > 0)
                            {
                                neighborSymbols.Add(lines[y - 1][x]);
                            }
                            if (y < lines.Length - 1)
                            {
                                neighborSymbols.Add(lines[y + 1][x]);
                            }

                            if (!char.IsDigit(lines[y][x + 1]))
                            {
                                neighborSymbols.Add(lines[y][x + 1]);
                                if (y > 0)
                                {
                                    neighborSymbols.Add(lines[y - 1][x + 1]);
                                }
                                if (y < lines.Length - 1)
                                {
                                    neighborSymbols.Add(lines[y + 1][x + 1]);
                                }
                            }
                        }
                    }
                    currDigits += ch;
                }
                else // Non digit
                {
                    if (currDigits != null)
                    {
                        bool isPart = neighborSymbols.Any(s => s != '.');
                        {
                            // Console.WriteLine(
                            //     "{0} {1} {2}",
                            //     currDigits,
                            //     isPart,
                            //     string.Join("|", neighborSymbols)
                            // );
                            if (isPart)
                            {
                                digits.Add(int.Parse(currDigits));
                            }
                        }

                        currDigits = null;
                        neighborSymbols.Clear();
                    }
                }
            }

            if (currDigits != null)
            {
                bool isPart = neighborSymbols.Any(s => s != '.');
                {
                    // Console.WriteLine(
                    //     "{0} {1} {2}",
                    //     currDigits,
                    //     isPart,
                    //     string.Join("|", neighborSymbols)
                    // );
                    if (isPart)
                    {
                        digits.Add(int.Parse(currDigits));
                    }
                }

                currDigits = null;
                neighborSymbols.Clear();
            }
        }

        return digits.Sum();
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }
}
