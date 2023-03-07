namespace AOC.CSharp;

public static class AOC2022_17
{
    public static long Solve1(string[] lines)
    {
        char[] pushes = lines[0].ToCharArray();
        var heights = GetHeights(2022, pushes);
        return heights.Last();
    }

    public static long Solve2(string[] lines)
    {
        char[] pushes = lines[0].ToCharArray();

        // Build up a large enough sample to find the repeat info
        var heights = GetHeights(50000, pushes);

        List<int> gaps = new();
        for (int i = 0; i < heights.Count - 1; i++)
        {
            // We care about the gaps between subsequent levels. This is where we will look for a pattern
            gaps.Add(heights[i + 1] - heights[i]);
        }

        // Arbitrary values that work
        int firstChunkStart = 10000;
        int sliceSize = 500;

        var firstChunk = gaps.Skip(firstChunkStart).Take(sliceSize).ToList();
        for (
            int secondStartIdx = firstChunkStart + 1;
            secondStartIdx < gaps.Count - sliceSize;
            secondStartIdx++
        )
        {
            var secondChunk = gaps.Skip(secondStartIdx).Take(sliceSize).ToList();
            if (firstChunk.SequenceEqual(secondChunk))
            {
                int startShapeIdx = firstChunkStart + 1;
                int shapeJumpAmount = secondStartIdx - firstChunkStart;
                long heightJumpAmount = gaps.Skip(firstChunkStart).Take(shapeJumpAmount).Sum();

                long remainingShapes = 1000000000000 - startShapeIdx;
                long fullJumps = remainingShapes / shapeJumpAmount;
                long fullJumpIncrease = fullJumps * heightJumpAmount;

                long heightUntilJumps = gaps.Take(startShapeIdx).Sum();
                long heightWithJumps = heightUntilJumps + fullJumpIncrease;

                long finalHeight = heightWithJumps;
                long remainderShapes = remainingShapes - (fullJumps * shapeJumpAmount);

                for (int j = 0; j < remainderShapes; j++)
                {
                    int gapIdx = startShapeIdx + j;
                    finalHeight += gaps[gapIdx];
                }

                return finalHeight;
            }
        }

        return -1;
    }

    private static List<int> GetHeights(int shapeCount, char[] pushes)
    {
        var g = new Grid();
        int shapeNum = 1;
        int pushIdx = 0;
        List<int> heights = new();

        for (int i = 0; i < shapeCount; i++)
        {
            // Push the next shape onto the top
            bool settled = false;
            g.AddShape(shapeNum);

            while (!settled)
            {
                // First handle L-R movement
                char push = pushes[pushIdx];
                if (push == '>')
                {
                    g.TryShiftRight();
                }
                else
                {
                    g.TryShiftLeft();
                }

                // Go down until we hit something
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

            // Remove empty rows because these should not count as height
            g.TrimTop();
            heights.Add(g.Rows - 1);
        }

        return heights;
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
                    return new[] { new[] { '|', '.', '.', '@', '@', '@', '@', '.', '|' }, };
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
                    return new[]
                    {
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                        new[] { '|', '.', '.', '@', '.', '.', '.', '.', '|' },
                    };
                default:
                    return new[]
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
            _data.Add(new[] { '|', '.', '.', '.', '.', '.', '.', '.', '|' });
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
