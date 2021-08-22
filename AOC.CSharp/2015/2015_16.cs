using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public static class AOC2015_16
    {
        private static readonly Regex Regex = new(@"Sue (\d+): (.*)");

        public static long Solve1(string[] lines)
        {
            var sues = lines.Select(Parse);

            foreach (Sue sue in sues)
            {
                if (sue.Children.HasValue && sue.Children.Value != 3) continue;
                if (sue.Cats.HasValue && sue.Cats.Value != 7) continue;
                if (sue.Samoyeds.HasValue && sue.Samoyeds.Value != 2) continue;
                if (sue.Pomeranians.HasValue && sue.Pomeranians.Value != 3) continue;
                if (sue.Akitas.HasValue && sue.Akitas.Value != 0) continue;
                if (sue.Vizslas.HasValue && sue.Vizslas.Value != 0) continue;
                if (sue.Goldfish.HasValue && sue.Goldfish.Value != 5) continue;
                if (sue.Trees.HasValue && sue.Trees.Value != 3) continue;
                if (sue.Cars.HasValue && sue.Cars.Value != 2) continue;
                if (sue.Perfumes.HasValue && sue.Perfumes.Value != 1) continue;

                return sue.Num;
            }

            return -1;
        }

        public static long Solve2(string[] lines)
        {
            var sues = lines.Select(Parse);

            foreach (Sue sue in sues)
            {
                if (sue.Children.HasValue && sue.Children.Value != 3) continue;
                if (sue.Cats.HasValue && sue.Cats.Value <= 7) continue;
                if (sue.Samoyeds.HasValue && sue.Samoyeds.Value != 2) continue;
                if (sue.Pomeranians.HasValue && sue.Pomeranians.Value >= 3) continue;
                if (sue.Akitas.HasValue && sue.Akitas.Value != 0) continue;
                if (sue.Vizslas.HasValue && sue.Vizslas.Value != 0) continue;
                if (sue.Goldfish.HasValue && sue.Goldfish.Value >= 5) continue;
                if (sue.Trees.HasValue && sue.Trees.Value <= 3) continue;
                if (sue.Cars.HasValue && sue.Cars.Value != 2) continue;
                if (sue.Perfumes.HasValue && sue.Perfumes.Value != 1) continue;

                return sue.Num;
            }

            return -1;
        }

        private static Sue Parse(string line)
        {
            Sue sue = new();

            Match m = Regex.Match(line);
            sue.Num = int.Parse(m.Groups[1].Value);

            string remaining = m.Groups[2].Value;
            string[] splits = remaining.Split(',');
            List<string[]> splitList = splits.Select(s => s.Split(':').Select(s => s.Trim()).ToArray()).ToList();

            foreach (string[] sp in splitList)
            {
                string category = sp[0];
                int value = int.Parse(sp[1]);

                switch (category)
                {
                    case "children":
                        sue.Children = value;
                        break;
                    case "cats":
                        sue.Cats = value;
                        break;
                    case "samoyeds":
                        sue.Samoyeds = value;
                        break;
                    case "pomeranians":
                        sue.Pomeranians = value;
                        break;
                    case "akitas":
                        sue.Akitas = value;
                        break;
                    case "vizslas":
                        sue.Vizslas = value;
                        break;
                    case "goldfish":
                        sue.Goldfish = value;
                        break;
                    case "trees":
                        sue.Trees = value;
                        break;
                    case "cars":
                        sue.Cars = value;
                        break;
                    case "perfumes":
                        sue.Perfumes = value;
                        break;
                }
            }

            return sue;
        }

        private class Sue
        {
            public int Num { get; set; }
            public int? Children { get; set; }
            public int? Cats { get; set; }
            public int? Samoyeds { get; set; }
            public int? Pomeranians { get; set; }
            public int? Akitas { get; set; }
            public int? Vizslas { get; set; }
            public int? Goldfish { get; set; }
            public int? Trees { get; set; }
            public int? Cars { get; set; }
            public int? Perfumes { get; set; }
        }
    }
}