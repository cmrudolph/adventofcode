namespace AOC.CSharp;

public static class AOC2017_21
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines, 5);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, 18);
    }

    private static long Solve(string[] lines, int iterations)
    {
        Transformer transformer = new(lines);
        char[,] arr = Parse(".#./..#/###");
        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine("----------{0}----------", i);
            //Print(arr);
            Console.WriteLine();
            int dim = arr.GetLength(0);
            if (dim % 2 == 0)
            {
                List<char[,]> lst = Split(arr, 2);
                List<char[,]> transformed = lst.Select(transformer.Transform).ToList();
                arr = Combine(transformed);
            }
            else
            {
                List<char[,]> lst = Split(arr, 3);
                List<char[,]> transformed = lst.Select(transformer.Transform).ToList();
                arr = Combine(transformed);
            }
            //Print(arr);
            Console.WriteLine("----------{0}----------", i);
            Console.WriteLine();
        }

        return CountOn(arr);
    }

    private static long CountOn(char[,] arr)
    {
        long count = 0;

        for (int r = 0; r < arr.GetLength(0); r++)
        {
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                count += arr[r, c] == '#' ? 1 : 0;
            }
        }

        return count;
    }

    private static char[,] Parse(string raw)
    {
        string[] splits = raw.Split("/");
        int dim = splits.Length;
        char[,] arr = new char[dim, dim];

        for (int r = 0; r < dim; r++)
        {
            for (int c = 0; c < dim; c++)
            {
                arr[r, c] = splits[r][c];
            }
        }

        return arr;
    }

    private static List<char[,]> Split(char[,] arr, int size)
    {
        // Take a big 2D array and break it apart into a list of smaller arrays
        // (to evaluate for transformation)
        int rBlocks = arr.GetLength(0) / size;
        int cBlocks = arr.GetLength(0) / size;
        List<char[,]> results = new();

        for (int rMul = 0; rMul < rBlocks; rMul++)
        {
            for (int cMul = 0; cMul < cBlocks; cMul++)
            {
                char[,] newArr = new char[size, size];

                for (int newR = 0; newR < size; newR++)
                {
                    for (int newC = 0; newC < size; newC++)
                    {
                        int oldR = (rMul * size) + newR;
                        int oldC = (cMul * size) + newC;
                        newArr[newR, newC] = arr[oldR, oldC];
                    }
                }

                results.Add(newArr);
            }
        }

        return results;
    }

    private static char[,] Combine(List<char[,]> lst)
    {
        // Take a list of 2D arrays (broken apart) and consolidate them back into a single 2D array
        int dim = (int)Math.Sqrt(lst.Count);
        int listDim = lst[0].GetLength(0);
        int newDim = dim * listDim;
        char[,] newArr = new char[newDim, newDim];

        for (int rMul = 0; rMul < dim; rMul++)
        {
            for (int cMul = 0; cMul < dim; cMul++)
            {
                int lstIdx = (rMul * dim) + cMul;
                char[,] lstItem = lst[lstIdx];

                for (int oldR = 0; oldR < listDim; oldR++)
                {
                    for (int oldC = 0; oldC < listDim; oldC++)
                    {
                        int newR = (rMul * listDim) + oldR;
                        int newC = (cMul * listDim) + oldC;
                        newArr[newR, newC] = lstItem[oldR, oldC];
                    }
                }
            }
        }

        return newArr;
    }

    private static void Print(char[,] arr)
    {
        for (int r = 0; r < arr.GetLength(0); r++)
        {
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                Console.Write(arr[r, c]);
            }

            Console.WriteLine();
        }
    }

    private static bool AreSame(char[,] arr1, char[,] arr2)
    {
        int rows1 = arr1.GetLength(0);
        int cols1 = arr1.GetLength(1);
        int rows2 = arr2.GetLength(0);
        int cols2 = arr2.GetLength(1);

        if (rows1 != rows2 || cols1 != cols2)
        {
            return false;
        }

        for (int r = 0; r < rows1; r++)
        {
            for (int c = 0; c < cols1; c++)
            {
                if (arr1[r, c] != arr2[r, c])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private class Transformer
    {
        private readonly List<Mapping> _mappings = new();

        public Transformer(string[] rules)
        {
            foreach (string r in rules)
            {
                string[] splits = r.Split(" => ");
                string inputRaw = splits[0];
                string outputRaw = splits[1];

                List<char[,]> inputs = GenerateInputPermutations(inputRaw);
                char[,] output = Parse(outputRaw);

                _mappings.Add(new(inputs, output));
            }
        }

        public char[,] Transform(char[,] arr)
        {
            foreach (var mapping in _mappings)
            {
                char[,] output = mapping.GetOutput(arr);
                if (output != null)
                {
                    // Return an output only if we found a mapping that matches the input pattern
                    return output;
                }
            }

            return null;
        }

        private static List<char[,]> GenerateInputPermutations(string input)
        {
            char[,] Rotate90(char[,] arr)
            {
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                char[,] newArr = new char[rows, cols];

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int newC = cols - r - 1;
                        int newR = c;
                        newArr[newR, newC] = arr[r, c];
                    }
                }

                return newArr;
            }

            char[,] Flip180(char[,] arr)
            {
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                char[,] newArr = new char[rows, cols];

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int newC = c;
                        int newR = rows - r - 1;
                        newArr[newR, newC] = arr[r, c];
                    }
                }

                return newArr;
            }

            List<char[,]> results = new();

            char[,] a1 = Parse(input);
            results.Add(a1);
            char[,] a2 = Rotate90(a1);
            results.Add(a2);
            char[,] a3 = Rotate90(a2);
            results.Add(a3);
            char[,] a4 = Rotate90(a3);
            results.Add(a4);
            char[,] a5 = Flip180(a4);
            results.Add(a5);
            char[,] a6 = Rotate90(a5);
            results.Add(a6);
            char[,] a7 = Rotate90(a6);
            results.Add(a7);
            char[,] a8 = Rotate90(a7);
            results.Add(a8);

            return results;
        }

        private class Mapping
        {
            private readonly List<char[,]> _inputs;
            private readonly char[,] _output;

            public Mapping(List<char[,]> inputs, char[,] output)
            {
                _inputs = inputs;
                _output = output;
            }

            public char[,] GetOutput(char[,] arr)
            {
                foreach (char[,] input in _inputs)
                {
                    if (AreSame(arr, input))
                    {
                        return _output;
                    }
                }

                return null;
            }
        }
    }
}
