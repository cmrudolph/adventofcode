using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp
{
    public class AOC2016_24
    {
        public static long Solve1(string[] lines)
        {
            return Solve(lines, Array.Empty<int>());
        }

        public static long Solve2(string[] lines)
        {
            return Solve(lines, new int[] { 0 });
        }

        private static long Solve(string[] lines, int[] rearPad)
        {
            Cell[,] maze = ReadMaze(lines);
            List<NumberedLocation> numbered = FindNumbered(maze);

            var pairwiseCosts = FindPairwiseCosts(maze, numbered);
            long best = long.MaxValue;
            int[] numbers = numbered.Where(n => n.Number != 0).OrderBy(n => n.Number).Select(n => n.Number).ToArray();
            FindShortestPath(numbers, rearPad, 0, numbers.Length - 1, pairwiseCosts, ref best);

            return best;
        }

        private static Cell[,] ReadMaze(string[] lines)
        {
            int width = lines[0].Length;
            int height = lines.Length;

            Cell[,] maze = new Cell[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    maze[x, y] = new Cell(x, y, lines[y][x]);
                }
            }

            return maze;
        }

        private static List<NumberedLocation> FindNumbered(Cell[,] maze)
        {
            List<NumberedLocation> results = new();

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Cell cell = maze[x, y];
                    if (char.IsDigit(cell.Char))
                    {
                        results.Add(new NumberedLocation(cell.Char - '0', cell));
                    }
                }
            }

            return results;
        }

        private record NumberedLocation(int Number, Cell Cell);

        private record Cell(int X, int Y, char Char);

        private record NumberPair(int Num1, int Num2);

        private static Dictionary<NumberPair, int> FindPairwiseCosts(Cell[,] maze, List<NumberedLocation> numbered)
        {
            Dictionary<NumberPair, int> best = new();

            // Run BFS starting from each numbered location to find the best path between each pair of numbered
            // locations in the maze. This gives us the building blocks necessary to find the overall best path
            // later on by brute force.
            foreach (NumberedLocation start in numbered)
            {
                HashSet<Cell> visited = new();
                Queue<Cell> q = new();
                int depth = 0;

                q.Enqueue(start.Cell);
                visited.Add(start.Cell);

                while (q.Count > 0)
                {
                    int cellsInCurrentLevel = q.Count;
                    while (cellsInCurrentLevel > 0)
                    {
                        Cell curr = q.Dequeue();

                        if (depth > 0 && char.IsDigit(curr.Char))
                        {
                            NumberPair pair = new NumberPair(start.Number, curr.Char - '0');
                            best[pair] = depth;
                        }

                        List<Cell> neighbors = FindNeighbors(maze, curr, visited);
                        neighbors.ForEach(n => visited.Add(n));
                        neighbors.ForEach(n => q.Enqueue(n));

                        cellsInCurrentLevel--;
                    }
                    depth++;
                }
            }

            return best;
        }

        private static List<Cell> FindNeighbors(Cell[,] maze, Cell curr, HashSet<Cell> visited)
        {
            List<Cell> neighbors = new();

            Cell up = maze[curr.X, curr.Y - 1];
            Cell down = maze[curr.X, curr.Y + 1];
            Cell left = maze[curr.X - 1, curr.Y];
            Cell right = maze[curr.X + 1, curr.Y];

            if (up.Char != '#' && !visited.Contains(up))
                neighbors.Add(up);
            if (down.Char != '#' && !visited.Contains(down))
                neighbors.Add(down);
            if (left.Char != '#' && !visited.Contains(left))
                neighbors.Add(left);
            if (right.Char != '#' && !visited.Contains(right))
                neighbors.Add(right);

            return neighbors;
        }

        private static void FindShortestPath(
            int[] numbers,
            int[] rearPad,
            int start,
            int end,
            Dictionary<NumberPair, int> pairwiseCosts,
            ref long best)
        {
            // Use recursion to discover all permutations of the numbered locations. Compute the cost of each path by
            // using the optimal location-to-location mapping generated during the earlier BFS stage. This is a naive
            // traveling salesman approach, but N is small enough that the execution time stays under control.
            if (start == end)
            {
                // Accommodate the fact that we always want zero at the front and sometimes want zero at the end (part 2)
                int[] finalArr = new int[] { 0 }.Concat(numbers).Concat(rearPad).ToArray();
                int pathCost = 0;
                for (int i = 0; i < finalArr.Length - 1; i++)
                {
                    NumberPair pair = new(finalArr[i], finalArr[i + 1]);
                    int segmentCost = pairwiseCosts[pair];
                    pathCost += segmentCost;
                }

                if (pathCost < best)
                {
                    best = pathCost;
                }
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(numbers, start, i);
                    FindShortestPath(numbers, rearPad, start + 1, end, pairwiseCosts, ref best);
                    Swap(numbers, start, i);
                }
            }
        }

        private static void Swap(int[] arr, int pos1, int pos2)
        {
            int temp;
            temp = arr[pos1];
            arr[pos1] = arr[pos2];
            arr[pos2] = temp;
        }
    }
}