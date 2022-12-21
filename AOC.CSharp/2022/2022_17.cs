namespace AOC.CSharp;

public static class AOC2022_17
{
    public static long Solve1(string[] lines)
    {
        char[] pushes = lines[0].ToCharArray();
        var g = new Grid();
        int shapeNum = 1;
        int pushIdx = 0;

        for (int i = 0; i < 2022; i++)
        {
            bool settled = false;
            g.AddShape(shapeNum);

            // g.Print();
            // Console.WriteLine();

            while (!settled)
            {
                char push = pushes[pushIdx];
                if (push == '>')
                {
                    g.TryShiftRight();
                }
                else
                {
                    g.TryShiftLeft();
                }

                settled = !g.TryMoveDown();

                pushIdx++;
                if (pushIdx == pushes.Length)
                {
                    pushIdx = 0;
                }
            }

            shapeNum++;
            if (shapeNum == 6)
            {
                shapeNum = 1;
            }

            // g.Print();
            // Console.WriteLine();
        }

        g.TrimTop();

        return g.Rows - 1;
    }

    // public static long Solve2(string[] lines)
    // {
    //     long shapes = 300000;
    //     long total = 454289;
    //     int jumpIdx = 0;
    //     long[] jumpVals = { 75719, 75713, 75714, 75714, 75713, 75715, 75712 };
    //     while (shapes != 1000000000000)
    //     {
    //         total += jumpVals[jumpIdx];
    //         shapes += 50000;
    //         jumpIdx++;
    //         if (jumpIdx == jumpVals.Length)
    //         {
    //             jumpIdx = 0;
    //         }
    //
    //         if (shapes % 1000000000 == 0)
    //         {
    //             Console.WriteLine(shapes);
    //         }
    //     }
    //
    //     return total - 1;
    // }

    public static long Solve2(string[] lines)
    {
        char[] pushes = lines[0].ToCharArray();
        var g = new Grid();
        int shapeNum = 1;
        int pushIdx = 0;

        RepeatInfo repeatInfo = null;

        List<int> gaps = new();
        for (int i = 0; i < 1000000; i++)
        {
            g.TrimTop();
            int heightBefore = g.Rows - 1;

            bool settled = false;
            g.AddShape(shapeNum);

            while (!settled)
            {
                char push = pushes[pushIdx];
                if (push == '>')
                {
                    g.TryShiftRight();
                }
                else
                {
                    g.TryShiftLeft();
                }

                settled = !g.TryMoveDown();

                pushIdx++;
                if (pushIdx == pushes.Length)
                {
                    pushIdx = 0;
                }
            }

            shapeNum++;
            if (shapeNum == 6)
            {
                shapeNum = 1;
            }

            g.TrimTop();

            if (i > 0)
            {
                int heightAfter = g.Rows - 1;
                gaps.Add(heightAfter - heightBefore);
            }

            if (i % 10000 == 0)
            {
                repeatInfo = LookForRepeat(gaps);
                if (repeatInfo != null)
                {
                    long remainingShapes = 1000000000000 - repeatInfo.StartShapeIdx;
                    long fullJumps = remainingShapes / repeatInfo.ShapeJumpAmount;
                    long fullJumpIncrease = fullJumps * repeatInfo.HeightJumpAmount;

                    long heightUntilJumps = gaps.Take(repeatInfo.StartShapeIdx).Sum();
                    long heightWithJumps = heightUntilJumps + fullJumpIncrease;

                    long finalHeight = heightWithJumps;
                    long remainderShapes = remainingShapes - (fullJumps * repeatInfo.ShapeJumpAmount);
                    for (int j = 0; j < remainderShapes; j++)
                    {
                        int gapIdx = repeatInfo.StartShapeIdx + j;
                        finalHeight += gaps[gapIdx];
                    }

                    return finalHeight;
                }
            }
        }

        return g.Rows - 1;
    }

    private static RepeatInfo LookForRepeat(List<int> gaps)
    {
        int firstChunkStart = 10000;
        int sliceSize = 500;

        if (gaps.Count >= firstChunkStart * 3)
        {
            var firstChunk = gaps.Skip(firstChunkStart).Take(sliceSize).ToList();
            for (int i = firstChunkStart + 1; i < gaps.Count - sliceSize; i++)
            {
                var secondChunk = gaps.Skip(i).Take(sliceSize).ToList();
                if (firstChunk.SequenceEqual(secondChunk))
                {
                    int num = i - firstChunkStart;
                    RepeatInfo info = new(firstChunkStart + 1, num, gaps.Skip(firstChunkStart).Take(num).Sum());
                    return info;
                }
            }
        }

        return null;
    }

    private record RepeatInfo(int StartShapeIdx, long ShapeJumpAmount, long HeightJumpAmount);

    private sealed class Grid
    {
        private const int Cols = 9;

        private int _currShapeBottom;
        private List<char[]> _data = new();

        public Grid()
        {
            _data.Add(new[] { '+', '-', '-', '-', '-', '-', '-', '-', '+' });
        }

        public bool IsRowEmpty(int row)
        {
            for (int c = 1; c < Cols - 1; c++)
            {
                if (_data[row][c] != '.')
                {
                    return false;
                }
            }

            return true;
        }

        public void TryShiftLeft()
        {
            for (int i = _currShapeBottom; i < Rows; i++)
            {
                for (int j = 0; j < Cols - 1; j++)
                {
                    if (_data[i][j + 1] == '@' && (_data[i][j] == '|' || _data[i][j] == '#'))
                    {
                        // Blocked
                        return;
                    }
                }
            }

            for (int i = _currShapeBottom; i < Rows; i++)
            {
                for (int j = 1; j < Cols - 1; j++)
                {
                    if (_data[i][j + 1] == '@')
                    {
                        _data[i][j] = '@';
                        _data[i][j + 1] = '.';
                    }
                }
            }
        }

        public void TryShiftRight()
        {
            for (int i = _currShapeBottom; i < Rows; i++)
            {
                for (int j = Cols - 1; j > 0; j--)
                {
                    if (_data[i][j - 1] == '@' && (_data[i][j] == '|' || _data[i][j] == '#'))
                    {
                        // Blocked
                        return;
                    }
                }
            }

            for (int i = _currShapeBottom; i < Rows; i++)
            {
                for (int j = Cols - 1; j > 0; j--)
                {
                    if (_data[i][j - 1] == '@')
                    {
                        _data[i][j] = '@';
                        _data[i][j - 1] = '.';
                    }
                }
            }
        }

        public bool TryMoveDown()
        {
            bool blocked = false;
            for (int i = _currShapeBottom; i < Rows; i++)
            {
                for (int j = 1; j < Cols - 1; j++)
                {
                    if (_data[i][j] == '@' && (_data[i - 1][j] == '-' || _data[i - 1][j] == '#'))
                    {
                        blocked = true;
                    }
                }
            }

            if (blocked)
            {
                for (int i = _currShapeBottom; i < Rows; i++)
                {
                    for (int j = 1; j < Cols - 1; j++)
                    {
                        if (_data[i][j] == '@')
                        {
                            _data[i][j] = '#';
                        }
                    }
                }

                return false;
            }

            for (int i = _currShapeBottom; i < Rows; i++)
            {
                for (int j = 1; j < Cols - 1; j++)
                {
                    if (_data[i][j] == '@')
                    {
                        _data[i - 1][j] = _data[i][j];
                        _data[i][j] = '.';
                    }
                }
            }

            _currShapeBottom--;

            return true;
        }

        public void AddShape(int num)
        {
            AdjustTopPadding();
            _currShapeBottom = Rows;

            var shape = MakeShape(num);
            for (int i = shape.GetLength(0) - 1; i >= 0; i--)
            {
                _data.Add(shape[i]);
            }
        }

        private static char[][] MakeShape(int num)
        {
            switch (num)
            {
                case 1:
                    return new[]
                    {
                        new[] { '|', '.', '.', '@', '@', '@', '@', '.', '|' },
                    };
                case 2:
                    return new[]
                    {
                        new[] { '|', '.', '.', '.', '@', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '@', '@', '.', '.', '|' },
                        new[] { '|', '.', '.', '.', '@', '.', '.', '.', '|' },
                    };
                case 3:
                    return new[]
                    {
                        new[] { '|', '.', '.', '.', '.', '@', '.', '.', '|' },
                        new[] { '|', '.', '.', '.', '.', '@', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '@', '@', '.', '.', '|' },
                    };
                case 4:
                    return new []
                    {
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                    };
                default:
                    return new []
                    {
                        new[] { '|', '.', '.', '@', '@', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '@', '.', '.', '.', '|' },
                    };
            }
        }

        public void AdjustTopPadding()
        {
            int empties = 0;
            int r = Rows - 1;
            while (r > 0 && IsRowEmpty(r))
            {
                empties++;
                r--;
            }

            while (empties < 3)
            {
                AddEmpty();
                empties++;
            }

            while (empties > 3)
            {
                _data.RemoveAt(Rows - 1);
                empties--;
            }
        }

        public void AddEmpty()
        {
            _data.Add(new [] { '|', '.', '.', '.', '.', '.', '.', '.', '|' });
        }

        public void TrimTop()
        {
            int r = Rows - 1;
            while (r > 0 && IsRowEmpty(r))
            {
                _data.RemoveAt(r);
                r--;
            }
        }

        public void Print()
        {
            for (int i = Rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(_data[i][j]);
                }

                Console.WriteLine();
            }
        }

        public int Rows => _data.Count;
    }
}