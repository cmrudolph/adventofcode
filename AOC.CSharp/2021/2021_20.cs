namespace AOC.CSharp;

public static class AOC2021_20
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines, 2);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, 50);
    }

    private static long Solve(string[] lines, int iterations)
    {
        int[] enhancement = lines[0].Select(ch => ch == '#' ? 1 : 0).ToArray();

        // Pad things enough that the algorithm works. We can't model a truly infinite canvas, but we can include
        // enough extra space around the edges to know what values would extend infinitely. We also know that most
        // of the cells need to end up as zero (since the problem wants a finite number of 1s), so all the extra
        // cells will either remain 0 indefinitely or flip back to zero (even iterations)
        int padding = iterations * 5;
        int halfPadding = padding / 2;

        int height = lines.Length - 2;
        int width = lines[2].Length;
        int paddedHeight = height + padding;
        int paddedWidth = width + padding;

        // First read the image, sticking it in the middle of the image array (padding all sides)
        int[,] image = new int[width + padding, height + padding];
        for (int y = 0; y < height; y++)
        {
            int adjustedY = y + halfPadding;
            string line = lines[y + 2];

            for (int x = 0; x < width; x++)
            {
                int adjustedX = x + halfPadding;
                image[adjustedX, adjustedY] = line[x] == '#' ? 1 : 0;
            }
        }

        // Next, perform the transformation N times. Each time strip off the outer edge of the image since we don't
        // technically have correct neighbors for those pixels (nor do we care because we have enough padding to
        // be able to discard some along the way)
        int[,] transformed = null;
        int[,] previous = image;
        for (int i = 1; i <= iterations; i++)
        {
            transformed = new int[width + padding, height + padding];
            for (int y = 1 + i; y < paddedHeight - i; y++)
            {
                for (int x = 1 + i; x < paddedWidth - i; x++)
                {
                    int enhancementIdx = FindEnhancementIndex(previous, x, y);
                    transformed[x, y] = enhancement[enhancementIdx];
                }
            }

            Array.Copy(transformed, previous, paddedHeight * paddedWidth);
        }

        // Finally, see how many pixels are lit when all the transformations are done
        long litCount = 0;
        for (int y = 1 + iterations; y < paddedHeight - iterations; y++)
        {
            for (int x = 1 + iterations; x < paddedWidth - iterations; x++)
            {
                litCount += transformed[x, y];
            }
        }

        return litCount;
    }

    private static int FindEnhancementIndex(int[,] image, int x, int y)
    {
        int idx = 0;

        // Construct the index by looking at the 3x3 area around the target cell and interpreting each value as a
        // bit that makes up the final 9 bit integer value
        idx |= image[x - 1, y - 1] << 8;
        idx |= image[x, y - 1] << 7;
        idx |= image[x + 1, y - 1] << 6;
        idx |= image[x - 1, y] << 5;
        idx |= image[x, y] << 4;
        idx |= image[x + 1, y] << 3;
        idx |= image[x - 1, y + 1] << 2;
        idx |= image[x, y + 1] << 1;
        idx |= image[x + 1, y + 1];

        return idx;
    }

    private static void PrintImage(int[,] image)
    {
        int width = image.GetLength(0);
        int height = image.GetLength(1);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(image[x, y]);
            }

            Console.WriteLine();
        }
    }
}
