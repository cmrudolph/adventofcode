using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public class AOC2016_11
    {
        private static readonly Regex MicrochipRegex = new Regex(@"(\w+)-compatible");
        private static readonly Regex GeneratorRegex = new Regex(@"(\w+) generator");

        public static long Solve1(string[] lines)
        {
            return Solve(lines);
        }

        public static long Solve2(string[] lines)
        {
            lines[0] = lines[0] + "elerium generator elerium-compatible dilithium generator dilithium-compatible";
            return Solve(lines);
        }

        private static long Solve(string[] lines)
        {
            var initialState = BuildInitialState(lines);

            Queue<State> queue = new();
            queue.Enqueue(initialState);

            int best = Bfs(queue);

            return best;
        }

        private static int Bfs(Queue<State> queue)
        {
            int level = 0;
            HashSet<State> seen = new();
            seen.Add(queue.Peek());

            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                Console.WriteLine("{0} {1} {2}", level, levelLength, seen.Count);

                while (levelLength > 0)
                {
                    State dequeued = queue.Dequeue();
                    if (dequeued.IsSolution)
                    {
                        return level;
                    }

                    var nextStates = GenerateNextValidStates(seen, dequeued);

                    foreach (var next in nextStates)
                    {
                        queue.Enqueue(next);
                    }

                    levelLength--;
                }

                level++;
            }

            return -1;
        }

        private static List<State> GenerateNextValidStates(HashSet<State> seen, State curr)
        {
            List<State> possibilities = new();
            List<Item> thisFloorItems = curr.ItemsByFloor[curr.Elevator];

            void ProcessForMove(int i, int floorShift)
            {
                // Process the state where we move just one item
                State next = curr.Clone();
                Item toMove = curr.ItemsByFloor[curr.Elevator][i];
                next.Elevator += floorShift;
                next.ItemsByFloor[curr.Elevator].Remove(toMove);
                next.AddItem(curr.Elevator + floorShift, toMove);
                if (next.IsValid && !seen.Contains(next))
                {
                    possibilities.Add(next);
                    seen.Add(next);
                }

                // Also consider the current item paired with each of the other items on the current floor
                for (int j = i + 1; j < thisFloorItems.Count; j++)
                {
                    State next2 = next.Clone();
                    Item toMove2 = curr.ItemsByFloor[curr.Elevator][j];
                    next2.ItemsByFloor[curr.Elevator].Remove(toMove2);
                    next2.AddItem(curr.Elevator + floorShift, toMove2);
                    if (next2.IsValid && !seen.Contains(next2))
                    {
                        possibilities.Add(next2);
                        seen.Add(next2);
                    }
                }
            }

            for (int i = 0; i < thisFloorItems.Count; i++)
            {
                // Check the floor above unless we are on the top floor
                if (curr.Elevator + 1 < State.Floors)
                {
                    ProcessForMove(i, 1);
                }

                // Check the floor below unless we are on the bottom floor
                if (curr.Elevator - 1 >= 0)
                {
                    ProcessForMove(i, -1);
                }
            }

            return possibilities;
        }

        private static State BuildInitialState(string[] lines)
        {
            Dictionary<string, int> elementToIdx = new();
            State s = new();
            s.Elevator = 0;

            int nextIdx = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                var chipMatches = MicrochipRegex.Matches(line);
                foreach (Match m in chipMatches)
                {
                    string element = m.Groups[1].Value;
                    if (!elementToIdx.ContainsKey(element))
                    {
                        elementToIdx.Add(element, nextIdx++);
                    }
                    Item item = new Item(ItemType.Microchip, elementToIdx[element]);
                    s.AddItem(i, item);
                }

                var generatorMatches = GeneratorRegex.Matches(line);
                foreach (Match m in generatorMatches)
                {
                    string element = m.Groups[1].Value;
                    if (!elementToIdx.ContainsKey(element))
                    {
                        elementToIdx.Add(element, nextIdx++);
                    }
                    Item item = new Item(ItemType.Generator, elementToIdx[element]);
                    s.AddItem(i, item);
                }
            }

            return s;
        }

        private record Item(ItemType Type, int ElementIdx)
        {
            public override string ToString()
            {
                return Type.ToString().Substring(0, 1) + ElementIdx;
            }
        }

        private enum ItemType
        {
            Generator,
            Microchip,
        }

        private class State
        {
            private Lazy<string> _equalityValue;

            public const int Floors = 4;

            public State()
            {
                ItemsByFloor = new List<Item>[Floors];
                for (int i = 0; i < Floors; i++)
                {
                    ItemsByFloor[i] = new();
                }

                // This equality representation is key to making the solution perform. For our purposes, we treat states
                // as equivalent if they have the same layout of paired generators and chips (the specific elements do not
                // matter except for identifying pairs). Doing this allows us to prune a LOT of states that would normally
                // need to be visited (they are technically distinct), which brings the execution time down to a manageable
                // level.
                _equalityValue = new(() =>
                {
                    Dictionary<Item, int> itemFloorLookup = new();
                    for (int i = 0; i < Floors; i++)
                    {
                        var floorItems = ItemsByFloor[i];
                        foreach (var floorItem in floorItems)
                        {
                            itemFloorLookup.Add(floorItem, i);
                        }
                    }

                    List<Item> flatItems = ItemsByFloor
                        .SelectMany(ibf => ibf)
                        .OrderBy(i => i.ElementIdx)
                        .ThenBy(i => i.Type)
                        .ToList();

                    List<Tuple<int, int>> pairs = new();
                    for (int i = 0; i < flatItems.Count; i += 2)
                    {
                        Item item1 = flatItems[i];
                        Item item2 = flatItems[i + 1];
                        var pair = Tuple.Create(itemFloorLookup[item1], itemFloorLookup[item2]);
                        pairs.Add(pair);
                    }

                    pairs = pairs.OrderBy(p => p).ToList();
                    string pairStr = string.Join("_", pairs).Replace(" ", "").Replace("(", "").Replace(")", "");

                    return $"{Elevator}_{pairStr}";
                });
            }

            public State Clone()
            {
                State s = new State();
                s.Elevator = Elevator;
                for (int i = 0; i < Floors; i++)
                {
                    s.ItemsByFloor[i] = ItemsByFloor[i].ToList();
                }

                return s;
            }

            public bool IsValid
            {
                get
                {
                    for (int i = 0; i < Floors; i++)
                    {
                        List<Item> thisFloorItems = ItemsByFloor[i];

                        if (!thisFloorItems.Any(item => item.Type == ItemType.Generator))
                        {
                            // No generators = safe for all chips
                            continue;
                        }

                        foreach (Item chip in thisFloorItems.Where(item => item.Type == ItemType.Microchip))
                        {
                            if (!thisFloorItems.Any(item => item.Type == ItemType.Generator && item.ElementIdx == chip.ElementIdx))
                            {
                                // A chip exists in the presence of other generators without its generator
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }

            public bool IsSolution
            {
                get
                {
                    return !ItemsByFloor[0].Any() && !ItemsByFloor[1].Any() && !ItemsByFloor[2].Any();
                }
            }

            public int Elevator { get; set; }

            public List<Item>[] ItemsByFloor { get; set; }

            public void AddItem(int floorIdx, Item item)
            {
                ItemsByFloor[floorIdx].Add(item);
                ItemsByFloor[floorIdx] = ItemsByFloor[floorIdx].OrderBy(i => i.Type).ThenBy(i => i.ElementIdx).ToList();
            }

            public override int GetHashCode()
            {
                return _equalityValue.Value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                State other = (State)obj;

                return other._equalityValue.Value == _equalityValue.Value;
            }
        }
    }
}