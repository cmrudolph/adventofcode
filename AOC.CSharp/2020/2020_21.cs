using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.CSharp
{
    public static class AOC2020_21
    {
        public static Tuple<long, string> Solve(string[] rawLines, bool part1Only)
        {
            long ans1 = 0;

            Counter counter = new();
            IEnumerable<Line> lines = rawLines.Select(Line.Parse);

            HashSet<string> ingredients = lines.SelectMany(line => line.Ingredients).ToHashSet();
            HashSet<string> allergens = lines.SelectMany(line => line.Allergens).ToHashSet();

            foreach (var line in lines)
            {
                foreach (var allergen in line.Allergens)
                {
                    counter.Increment(allergen);

                    foreach (var ingredient in line.Ingredients)
                    {
                        string key = allergen + "_" + ingredient;
                        counter.Increment(key);
                    }
                }

                foreach (var ingredient in line.Ingredients)
                {
                    counter.Increment(ingredient);
                }
            }

            foreach (string ingredient in ingredients.ToArray())
            {
                bool valid = false;

                foreach (string allergen in allergens)
                {
                    string key = allergen + "_" + ingredient;

                    int allergenIngredientCount = counter.GetCount(key);
                    int allergenCount = counter.GetCount(allergen);
                    bool match = allergenIngredientCount == allergenCount;

                    valid |= match;
                }

                if (!valid)
                {
                    int ingredientCount = counter.GetCount(ingredient);
                    ans1 += ingredientCount;
                    ingredients.Remove(ingredient);
                }
            }

            if (part1Only)
            {
                return Tuple.Create<long, string>(ans1, null);
            }

            // Build part 2 matrix with only the valid ingredients
            ResolutionMatrix matrix = new(ingredients.ToArray(), allergens.ToArray());

            foreach (string ingredient in ingredients)
            {
                foreach (string allergen in allergens)
                {
                    string key = allergen + "_" + ingredient;

                    int allergenIngredientCount = counter.GetCount(key);
                    int allergenCount = counter.GetCount(allergen);
                    bool match = allergenIngredientCount == allergenCount;

                    if (match)
                    {
                        matrix.Set(ingredient, allergen);
                    }
                    else
                    {
                        matrix.Clear(ingredient, allergen);
                    }
                }
            }

            matrix.Resolve();

            string ans2 = string.Join(",", matrix.GetFinalPairs().OrderBy(p => p.Item2).Select(p => p.Item1));
            return Tuple.Create<long, string>(0L, ans2);
        }

        public static long Solve1(string[] lines)
        {
            return Solve(lines, true).Item1;
        }

        public static string Solve2(string[] lines)
        {
            return Solve(lines, false).Item2;
        }

        private class ResolutionMatrix
        {
            private bool[,] _matrix;

            private Dictionary<string, int> _ingredientIndices = new();
            private Dictionary<string, int> _allergenIndices = new();

            private Dictionary<int, string> _ingredientNames = new();
            private Dictionary<int, string> _allergenNames = new();

            public ResolutionMatrix(string[] ingredients, string[] allergens)
            {
                for (int i = 0; i < ingredients.Length; i++)
                {
                    _ingredientIndices[ingredients[i]] = i;
                    _ingredientNames[i] = ingredients[i];
                }

                for (int i = 0; i < allergens.Length; i++)
                {
                    _allergenIndices[allergens[i]] = i;
                    _allergenNames[i] = allergens[i];
                }

                _matrix = new bool[ingredients.Length, allergens.Length];
            }

            public void Clear(string ingredient, string allergen)
            {
                int ingredientIdx = _ingredientIndices[ingredient];
                int allergenIdx = _allergenIndices[allergen];

                _matrix[ingredientIdx, allergenIdx] = false;
            }

            public void Set(string ingredient, string allergen)
            {
                int ingredientIdx = _ingredientIndices[ingredient];
                int allergenIdx = _allergenIndices[allergen];

                _matrix[ingredientIdx, allergenIdx] = true;
            }

            public void Resolve()
            {
                bool changed = true;

                while (changed)
                {
                    changed = false;

                    for (int i = 0; i < _matrix.GetLength(0); i++)
                    {
                        int? onlyAllergen = FindOnlyAllergen(i);
                        if (onlyAllergen != null)
                        {
                            changed |= LockInAllergen(i, onlyAllergen.Value);
                        }
                    }
                }
            }

            public List<Tuple<string, string>> GetFinalPairs()
            {
                List<Tuple<string, string>> pairs = new();

                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        if (_matrix[i, j])
                        {
                            string ingredient = _ingredientNames[i];
                            string allergen = _allergenNames[j];
                            pairs.Add(Tuple.Create(ingredient, allergen));
                        }
                    }
                }

                return pairs;
            }

            private int? FindOnlyAllergen(int ingredientIdx)
            {
                int? foundIdx = null;
                for (int i = 0; i < _matrix.GetLength(1); i++)
                {
                    bool allergenValue = _matrix[ingredientIdx, i];
                    if (foundIdx == null && allergenValue)
                    {
                        foundIdx = i;
                    }
                    else if (allergenValue)
                    {
                        return null;
                    }
                }

                return foundIdx;
            }

            private bool LockInAllergen(int ingredientIdx, int allergenIdx)
            {
                bool changed = false;

                for (int i = 0; i < _matrix.GetLength(0); i++)
                {
                    if (i != ingredientIdx)
                    {
                        if (_matrix[i, allergenIdx] == true)
                        {
                            _matrix[i, allergenIdx] = false;
                            changed = true;
                        }
                    }
                }

                return changed;
            }
        }

        private class Counter
        {
            Dictionary<string, int> _counts = new Dictionary<string, int>();

            public void Increment(string key)
            {
                if (!_counts.TryGetValue(key, out _))
                {
                    _counts.Add(key, 1);
                }
                else
                {
                    _counts[key] = _counts[key] + 1;
                }
            }

            public int GetCount(string key)
            {
                return _counts.TryGetValue(key, out int value) ? value : 0;
            }
        }

        private class Line
        {
            public static Line Parse(string line)
            {
                var splits = line.Replace(")", "")
                    .Replace("(contains ", "|")
                    .Replace(",", "")
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                return new Line
                {
                    Ingredients = splits[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList(),
                    Allergens = splits[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList(),
                };
            }

            public List<string> Ingredients { get; init; }

            public List<string> Allergens { get; init; }
        }
    }
}