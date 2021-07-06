using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public static class AOC2015_15
    {
        private static readonly Regex Regex = new(@"capacity (.+), durability (.+), flavor (.+), texture (.+), calories (.+)");

        public static long Solve1(string[] lines)
        {
            var ingredients = lines.Select(Parse).ToArray();

            long max = FindMax(ingredients, 100, cal => true);

            return max;
        }

        public static long Solve2(string[] lines)
        {
            var ingredients = lines.Select(Parse).ToArray();

            long max = FindMax(ingredients, 100, cal => cal == 500);

            return max;
        }

        private static Ingredient Parse(string line)
        {
            Match m = Regex.Match(line);
            return new Ingredient(
                new[]
                {
                    int.Parse(m.Groups[1].Value),
                    int.Parse(m.Groups[2].Value),
                    int.Parse(m.Groups[3].Value),
                    int.Parse(m.Groups[4].Value),
                    int.Parse(m.Groups[5].Value)
                });
        }

        private static long FindMax(IEnumerable<Ingredient> ingredients, int teaspoons, Func<long, bool> caloriePredicate)
        {
            State state = new(ingredients, teaspoons);
            Recurse(state, caloriePredicate);

            return state.Max;
        }

        private static void Recurse(State state, Func<long, bool> caloriePredicate)
        {
            int idx = state.Ingredients.Length - state.DepthRemaining;
            state.DepthRemaining--;
            for (int i = state.TeaspoonsRemaining; (state.DepthRemaining > 0 && i >= 0) || i == state.TeaspoonsRemaining; i--)
            {
                state.Distribution[idx] = i;
                state.TeaspoonsRemaining -= i;

                if (state.DepthRemaining > 0)
                {
                    Recurse(state, caloriePredicate);
                }
                else
                {
                    (long newMax, long calories) = Calculate(state.Ingredients, state.Distribution);
                    if (caloriePredicate(calories))
                    {
                        state.Max = Math.Max(state.Max, newMax);
                    }
                }

                state.TeaspoonsRemaining += i;
                state.Distribution[idx] = 0;
            }
            state.DepthRemaining++;
        }

        private static (long total, long calories) Calculate(Ingredient[] ingredients, int[] distribution)
        {
            long[] weightTotals = new long[] { 0L, 0L, 0L, 0L };
            long calories = 0L;

            for (int i = 0; i < ingredients.Length; i++)
            {
                Ingredient ing = ingredients[i];
                int numIng = distribution[i];

                for (int j = 0; j < weightTotals.Length; j++)
                {
                    weightTotals[j] += (numIng * ing.Weights[j]);
                }
                calories += (numIng * ing.Weights[4]);
            }

            for (int j = 0; j < weightTotals.Length; j++)
            {
                weightTotals[j] = Math.Max(weightTotals[j], 0);
            }

            long total = weightTotals.Aggregate(1L, (acc, value) => acc * value);

            return (total, calories);
        }

        private class State
        {
            public State(IEnumerable<Ingredient> ingredients, int teaspoons)
            {
                Ingredients = ingredients.ToArray();
                DepthRemaining = Ingredients.Length;
                Max = 0L;
                Distribution = new int[Ingredients.Length];
                TeaspoonsRemaining = teaspoons;
            }

            public Ingredient[] Ingredients { get; }

            public int DepthRemaining { get; set; }

            public long Max { get; set; }

            public int[] Distribution { get; }

            public int TeaspoonsRemaining { get; set; }
        }

        record Ingredient(int[] Weights);
    }
}