namespace AOC.CSharp;

public static class AOC2021_11
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines).Item1;
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines).Item2;
    }

    private static (long, long) Solve(string[] lines)
    {
        Cell[,] map = ParseMap(lines);

        int flashesFor1 = 0;
        int stepFor2 = 0;

        for (int i = 1; i <= 100; i++)
        {
            IncrementAllLevels(map);
            int stepFlashes = ProcessFlashes(map);
            flashesFor1 += stepFlashes;
            if (stepFlashes == map.GetLength(0) * map.GetLength(1))
            {
                stepFor2 = i;
            }
        }

        int j = 101;
        while (stepFor2 == 0)
        {
            IncrementAllLevels(map);
            int stepFlashes = ProcessFlashes(map);
            if (stepFlashes == map.GetLength(0) * map.GetLength(1))
            {
                stepFor2 = j;
            }
            j++;
        }
        return (flashesFor1, stepFor2);
    }

    private static void IncrementAllLevels(Cell[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j].Level++;
            }
        }
    }

    private static int ProcessFlashes(Cell[,] map)
    {
        int flashes = 0;
        bool hasFlashes;
        do
        {
            hasFlashes = false;
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Cell curr = map[x, y];
                    if (!curr.Flashed && curr.Level > 9)
                    {
                        flashes++;
                        curr.Flashed = true;
                        IncrementNeighbors(map, curr);
                        hasFlashes = true;
                    }
                }
            }
        } while (hasFlashes);

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                Cell curr = map[x, y];
                if (curr.Flashed)
                {
                    curr.Level = 0;
                    curr.Flashed = false;
                    hasFlashes = true;
                }
            }
        }

        return flashes;
    }

    private static void PrintMap(Cell[,] map)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                Console.Write(map[x, y].Level);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static void IncrementNeighbors(Cell[,] map, Cell curr)
    {
        List<Tuple<int, int>> neighbors =
            new()
            {
                Tuple.Create(curr.X - 1, curr.Y - 1), // NW
                Tuple.Create(curr.X, curr.Y - 1), // N
                Tuple.Create(curr.X + 1, curr.Y - 1), // NE
                Tuple.Create(curr.X + 1, curr.Y), // E
                Tuple.Create(curr.X + 1, curr.Y + 1), // SE
                Tuple.Create(curr.X, curr.Y + 1), // S
                Tuple.Create(curr.X - 1, curr.Y + 1), // SW
                Tuple.Create(curr.X - 1, curr.Y), // W
            };

        foreach (Tuple<int, int> neighbor in neighbors)
        {
            int x = neighbor.Item1;
            int y = neighbor.Item2;
            if (x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0))
            {
                map[x, y].Level++;
            }
        }
    }

    private static Cell[,] ParseMap(string[] lines)
    {
        Cell[,] map = new Cell[lines[0].Length, lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                map[x, y] = new Cell(x, y, line[x] - '0');
            }
        }

        return map;
    }

    private class Cell
    {
        public Cell(int x, int y, int level)
        {
            X = x;
            Y = y;
            Level = level;
            Flashed = false;
        }

        public int X { get; }
        public int Y { get; }
        public int Level { get; set; }
        public bool Flashed { get; set; }
    }
}
