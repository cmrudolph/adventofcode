namespace AOC.CSharp;

public static class AOC2023_03
{
    public static int Solve1(string[] lines)
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

    public static int Solve2(string[] lines)
    {
        int sum = 0;

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines.Length; x++)
            {
                char ch = lines[y][x];
                if (ch == '*')
                {
                    HashSet<YX> toCheck = new();
                    if (x > 0)
                    {
                        // LEFT
                        toCheck.Add(new(y, x - 1));

                        if (y > 0)
                        {
                            // LEFT + UP
                            toCheck.Add(new(y - 1, x - 1));
                        }

                        if (y < lines.Length - 1)
                        {
                            // LEFT + DOWN
                            toCheck.Add(new(y + 1, x - 1));
                        }
                    }

                    if (y > 0)
                    {
                        // UP
                        toCheck.Add(new(y - 1, x));
                    }
                    if (y < lines.Length - 1)
                    {
                        // DOWN
                        toCheck.Add(new(y + 1, x));
                    }

                    if (x < lines[y].Length - 1)
                    {
                        if (y > 0)
                        {
                            // RIGHT + UP
                            toCheck.Add(new(y - 1, x + 1));
                        }
                        if (y < lines.Length - 1)
                        {
                            // RIGHT + DOWN
                            toCheck.Add(new(y + 1, x + 1));
                        }

                        // RIGHT
                        toCheck.Add(new(y, x + 1));
                    }

                    int ratio = FindGearRatio(lines, toCheck);
                    sum += ratio;
                }
            }
        }

        return sum;
    }

    private static int FindGearRatio(string[] lines, HashSet<YX> toCheck)
    {
        List<int> values = new();

        while (toCheck.Count > 0)
        {
            YX yx = toCheck.First();
            toCheck.Remove(yx);

            if (!char.IsDigit(lines[yx.Y][yx.X]))
            {
                continue;
            }

            int numStartX = yx.X;
            int numEndX = yx.X;

            int x = yx.X;
            while (x - 1 >= 0 && char.IsDigit(lines[yx.Y][x - 1]))
            {
                x--;
                toCheck.RemoveWhere(a => a.Y == yx.Y && a.X == x);
            }

            numStartX = x;

            x = yx.X;
            while (x + 1 < lines[yx.Y].Length && char.IsDigit(lines[yx.Y][x + 1]))
            {
                x++;
                toCheck.RemoveWhere(a => a.Y == yx.Y && a.X == x);
            }

            numEndX = x;

            string sub = lines[yx.Y].Substring(numStartX, numEndX - numStartX + 1);
            values.Add(int.Parse(sub));
        }

        if (values.Count == 2)
        {
            //Console.WriteLine("{0} * {1} = {2}", values[0], values[1], values[0] * values[1]);
            return values[0] * values[1];
        }

        return 0;
    }

    private record YX(int Y, int X);
}
