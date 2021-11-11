using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2015_09
{
    private class Data
    {
        // e.g. London to Belfast = 888
        private static readonly Regex LineRegex = new Regex("(.*) to (.*) = (.*)");

        // Lookup between two cities and the distance between them. Supports either direction
        private Dictionary<Tuple<string, string>, int> _cityDistances;

        // All the arrangements of possible cities. Because N is small, N! is manageable
        private List<string[]> _cityPermutations;

        public static Data Parse(string[] lines)
        {
            return new Data(lines);
        }

        private Data(string[] lines)
        {
            HashSet<string> uniqueCities = new();
            _cityDistances = new();

            foreach (string line in lines)
            {
                Match m = LineRegex.Match(line);
                string city1 = m.Groups[1].Value;
                string city2 = m.Groups[2].Value;
                int distance = int.Parse(m.Groups[3].Value);

                _cityDistances.Add(Tuple.Create(city1, city2), distance);
                _cityDistances.Add(Tuple.Create(city2, city1), distance);
                uniqueCities.Add(city1);
                uniqueCities.Add(city2);
            }

            _cityPermutations = new();
            Permute(uniqueCities.ToArray(), uniqueCities.Count, 0, _cityPermutations);
        }

        public int GetDistance(string city1, string city2)
        {
            return _cityDistances[Tuple.Create(city1, city2)];
        }

        public string[][] GetCityPermutationsCopy() => _cityPermutations.ToArray();

        private static void Permute(string[] cities, int n, int i, List<string[]> permutations)
        {
            void Swap(string[] arr, int idx1, int idx2)
            {
                string temp = arr[idx1];
                arr[idx1] = arr[idx2];
                arr[idx2] = temp;
            }

            if (i >= (n - 1))
            {
                permutations.Add(cities.ToArray());
            }
            else
            {
                Permute(cities, n, i + 1, permutations);
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        Swap(cities, i, j);
                        Permute(cities, n, i + 1, permutations);
                        Swap(cities, i, j);
                    }
                }
            }
        }
    }

    public static long Solve1(string[] lines)
    {
        Data d = Data.Parse(lines);
        long ans = FindByDistance(d, Enumerable.Min);

        return ans;
    }

    public static long Solve2(string[] lines)
    {
        Data d = Data.Parse(lines);
        long ans = FindByDistance(d, Enumerable.Max);

        return ans;
    }

    private static long FindByDistance(Data d, Func<IEnumerable<long>, long> chooser)
    {
        IEnumerable<long> distances = d
            .GetCityPermutationsCopy()
            .Select(perm => ComputeTotalDistance(d, perm));

        return chooser(distances);
    }

    private static long ComputeTotalDistance(Data d, string[] orderedCities)
    {
        long total = 0;

        for (int i = 0; i < orderedCities.Length - 1; i++)
        {
            total += d.GetDistance(orderedCities[i], orderedCities[i + 1]);
        }

        return total;
    }
}
