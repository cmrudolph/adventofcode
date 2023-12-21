namespace AOC.CSharp;

public static class AOC2023_19
{
    public static long Solve1(string[] lines)
    {
        Solver1 s = new(lines);

        return s.Solve();
    }

    public static long Solve2(string[] lines)
    {
        Solver2 s = new(lines);

        return s.Solve();
    }

    private class Solver1
    {
        private readonly Dictionary<string, Workflow> _wfLookup;
        private readonly List<Part> _parts;

        public Solver1(string[] lines)
        {
            (List<Workflow> workflows, _parts) = Parse(lines);

            _wfLookup = workflows.ToDictionary(r => r.Name);
        }

        public long Solve()
        {
            long sum = 0;

            foreach (var p in _parts)
            {
                string wf = "in";
                while (wf != "A" && wf != "R")
                {
                    wf = _wfLookup[wf].Evaluate(p);
                }

                if (wf == "A")
                {
                    sum += p.X + p.M + p.A + p.S;
                }
            }

            return sum;
        }

        private static (List<Workflow>, List<Part>) Parse(string[] lines)
        {
            List<Workflow> rules = new();
            List<Part> parts = new();

            string line = lines[0];
            int idx = 0;
            while (!string.IsNullOrWhiteSpace(line))
            {
                rules.Add(new Workflow(line));
                idx++;
                line = lines[idx];
            }

            foreach (string partLine in lines.Skip(idx + 1))
            {
                string[] splits = partLine.Replace("{", "").Replace("}", "").Split(",");
                int x = int.Parse(splits[0].Split("=")[1]);
                int m = int.Parse(splits[1].Split("=")[1]);
                int a = int.Parse(splits[2].Split("=")[1]);
                int s = int.Parse(splits[3].Split("=")[1]);

                parts.Add(new(x, m, a, s));
            }

            return (rules, parts);
        }

        public record Part(int X, int M, int A, int S);

        public class Workflow
        {
            private readonly List<Func<Part, string>> _evaluators = new();

            public Workflow(string line)
            {
                string[] splits = line.Split("{");
                Name = splits[0];
                string rest = splits[1].Replace("}", "");
                string[] cases = rest.Split(",");

                foreach (string c in cases)
                {
                    Rule rule = new Rule(c);

                    if (rule.Operator == null)
                    {
                        _evaluators.Add(_ => rule.Destination);
                    }
                    else
                    {
                        if (rule.PartProp == "x")
                        {
                            if (rule.Operator == ">")
                            {
                                _evaluators.Add(p => p.X > rule.Amount ? rule.Destination : null);
                            }
                            else
                            {
                                _evaluators.Add(p => p.X < rule.Amount ? rule.Destination : null);
                            }
                        }
                        if (rule.PartProp == "m")
                        {
                            if (rule.Operator == ">")
                            {
                                _evaluators.Add(p => p.M > rule.Amount ? rule.Destination : null);
                            }
                            else
                            {
                                _evaluators.Add(p => p.M < rule.Amount ? rule.Destination : null);
                            }
                        }
                        if (rule.PartProp == "a")
                        {
                            if (rule.Operator == ">")
                            {
                                _evaluators.Add(p => p.A > rule.Amount ? rule.Destination : null);
                            }
                            else
                            {
                                _evaluators.Add(p => p.A < rule.Amount ? rule.Destination : null);
                            }
                        }
                        if (rule.PartProp == "s")
                        {
                            if (rule.Operator == ">")
                            {
                                _evaluators.Add(p => p.S > rule.Amount ? rule.Destination : null);
                            }
                            else
                            {
                                _evaluators.Add(p => p.S < rule.Amount ? rule.Destination : null);
                            }
                        }
                    }
                }
            }

            public string Name { get; }

            public string Evaluate(Part p)
            {
                foreach (Func<Part, string> evaluator in _evaluators)
                {
                    string result = evaluator(p);
                    if (result != null)
                    {
                        return result;
                    }
                }

                throw new InvalidOperationException("Forgot a case");
            }
        }
    }

    private class Solver2
    {
        private readonly Dictionary<string, Workflow> _wfLookup;
        private readonly List<Range> _acceptedRanges = new();

        public Solver2(string[] lines)
        {
            List<Workflow> workflows = Parse(lines);

            _wfLookup = workflows.ToDictionary(x => x.Name);
        }

        private static List<Workflow> Parse(string[] lines)
        {
            List<Workflow> rules = new();

            string line = lines[0];
            int idx = 0;
            while (!string.IsNullOrWhiteSpace(line))
            {
                rules.Add(new Workflow(line));
                idx++;
                line = lines[idx];
            }

            return rules;
        }

        public long Solve()
        {
            Range range = new(1, 4000, 1, 4000, 1, 4000, 1, 4000);

            Recurse("in", range, 0);

            long sum = 0;
            foreach (var ar in _acceptedRanges)
            {
                long x = Math.Max(ar.MaxX - ar.MinX + 1, 1);
                long m = Math.Max(ar.MaxM - ar.MinM + 1, 1);
                long a = Math.Max(ar.MaxA - ar.MinA + 1, 1);
                long s = Math.Max(ar.MaxS - ar.MinS + 1, 1);

                Console.WriteLine("{0} = {1}", ar, (x * m * a * s));

                sum += (x * m * a * s);
            }

            return sum;
        }

        private void Recurse(string dest, Range range, int depth)
        {
            Console.WriteLine("{0} {1} | {2}", new string(' ', depth), range, dest);

            // if (
            //     range.MinX > range.MaxX
            //     || range.MinM > range.MaxM
            //     || range.MinA > range.MaxA
            //     || range.MinS > range.MaxS
            // )
            // {
            //     Console.WriteLine("{0} :: CROSSOVER", new string(' ', depth + 1));
            //     return;
            // }

            if (dest == "R")
            {
                Console.WriteLine("{0} {1} | {2} = REJECT", new string(' ', depth), range, dest);
                return;
            }

            if (dest == "A")
            {
                Console.WriteLine("{0} {1} | {2} = ACCEPT", new string(' ', depth), range, dest);
                _acceptedRanges.Add(range);
                return;
            }

            Workflow wf = _wfLookup[dest];

            long sum = 0;
            Range newRange = range;
            foreach (Rule r in wf.Rules)
            {
                if (r.Operator == ">")
                {
                    if (r.PartProp == "x")
                    {
                        newRange = newRange with { MinX = r.Amount + 1 };
                    }
                    if (r.PartProp == "m")
                    {
                        newRange = newRange with { MinM = r.Amount + 1 };
                    }
                    if (r.PartProp == "a")
                    {
                        newRange = newRange with { MinA = r.Amount + 1 };
                    }
                    if (r.PartProp == "s")
                    {
                        newRange = newRange with { MinS = r.Amount + 1 };
                    }

                    Recurse(r.Destination, newRange, depth + 1);

                    // if (r.PartProp == "x")
                    // {
                    //     newRange = newRange with { MaxX = r.Amount };
                    // }
                    // if (r.PartProp == "m")
                    // {
                    //     newRange = newRange with { MaxM = r.Amount };
                    // }
                    // if (r.PartProp == "a")
                    // {
                    //     newRange = newRange with { MaxA = r.Amount };
                    // }
                    // if (r.PartProp == "s")
                    // {
                    //     newRange = newRange with { MaxS = r.Amount };
                    // }
                }
                else if (r.Operator == "<")
                {
                    if (r.PartProp == "x")
                    {
                        newRange = newRange with { MaxX = r.Amount - 1 };
                    }
                    if (r.PartProp == "m")
                    {
                        newRange = newRange with { MaxM = r.Amount - 1 };
                    }
                    if (r.PartProp == "a")
                    {
                        newRange = newRange with { MaxA = r.Amount - 1 };
                    }
                    if (r.PartProp == "s")
                    {
                        newRange = newRange with { MaxS = r.Amount - 1 };
                    }

                    Recurse(r.Destination, newRange, depth + 1);

                    // if (r.PartProp == "x")
                    // {
                    //     newRange = newRange with { MinX = r.Amount };
                    // }
                    // if (r.PartProp == "m")
                    // {
                    //     newRange = newRange with { MinM = r.Amount };
                    // }
                    // if (r.PartProp == "a")
                    // {
                    //     newRange = newRange with { MinA = r.Amount };
                    // }
                    // if (r.PartProp == "s")
                    // {
                    //     newRange = newRange with { MinS = r.Amount };
                    // }
                }
                else
                {
                    Recurse(r.Destination, newRange, depth + 1);
                }
            }
        }

        public class Workflow
        {
            public Workflow(string line)
            {
                string[] splits = line.Split("{");
                Name = splits[0];
                string rest = splits[1].Replace("}", "");

                Rules = rest.Split(",").Select(x => new Rule(x)).ToArray();
            }

            public string Name { get; }
            public Rule[] Rules { get; }
        }

        public record Range(
            long MinX,
            long MaxX,
            long MinM,
            long MaxM,
            long MinA,
            long MaxA,
            long MinS,
            long MaxS
        );
    }

    public class Rule
    {
        public Rule(string raw)
        {
            // a<2006:qkq
            string[] splits = raw.Split(":");
            if (splits.Length == 2)
            {
                string[] splitGreater = splits[0].Split(">");
                if (splitGreater.Length == 2)
                {
                    PartProp = splitGreater[0];
                    Operator = ">";
                    Amount = long.Parse(splitGreater[1]);
                }

                string[] splitLesser = splits[0].Split("<");
                if (splitLesser.Length == 2)
                {
                    PartProp = splitLesser[0];
                    Operator = "<";
                    Amount = long.Parse(splitLesser[1]);
                }

                Destination = splits[1];
            }
            else
            {
                Destination = raw;
            }
        }

        public string PartProp { get; set; }
        public string Operator { get; set; }
        public long Amount { get; set; }
        public string Destination { get; set; }
    }
}
