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
            var initialState = BuildInitialState(lines);

            Queue<State> queue = new();
            queue.Enqueue(initialState);

            int best = Bfs(queue);

            return best;
        }

        public static long Solve2(string[] lines)
        {
            lines[0] = lines[0] + "elerium generator elerium-compatible dilithium generator dilithium-compatible";
            var initialState = BuildInitialState(lines);

            Queue<State> queue = new();
            queue.Enqueue(initialState);

            int best = Bfs(queue);

            return best;
        }

        private static int Bfs(Queue<State> queue)
        {
            int i = 0;
            int level = 0;
            HashSet<State> seen = new();
            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                Console.WriteLine("{0} {1} {2}", level, levelLength, seen.Count);

                while (levelLength > 0)
                {
                    i++;
                    State dequeued = queue.Dequeue();
                    if (dequeued.IsSolution)
                    {
                        return level;
                    }

                    seen.Add(dequeued);
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
            // TODO: Find all possible transition state
            // If the state is not in the history, recursively visit it

            List<State> possibilities = new();

            List<Item> thisFloorItems = curr.ItemsByFloor[curr.Elevator];
            for (int i = 0; i < thisFloorItems.Count; i++)
            {
                if (curr.Elevator + 1 < State.Floors)
                {
                    State next = curr.Clone();
                    Item toMove = curr.ItemsByFloor[curr.Elevator][i];
                    next.Elevator++;
                    next.ItemsByFloor[curr.Elevator].Remove(toMove);
                    next.AddItem(curr.Elevator + 1, toMove);
                    if (next.IsValid && !seen.Contains(next))
                    {
                        possibilities.Add(next);
                        seen.Add(next);
                    }

                    for (int j = i + 1; j < thisFloorItems.Count; j++)
                    {
                        State next2 = next.Clone();
                        Item toMove2 = curr.ItemsByFloor[curr.Elevator][j];
                        next2.ItemsByFloor[curr.Elevator].Remove(toMove2);
                        next2.AddItem(curr.Elevator + 1, toMove2);
                        if (next2.IsValid && !seen.Contains(next2))
                        {
                            possibilities.Add(next2);
                            seen.Add(next2);
                        }
                    }
                }

                if (curr.Elevator - 1 >= 0)
                {
                    State next = curr.Clone();
                    Item toMove = curr.ItemsByFloor[curr.Elevator][i];
                    next.Elevator--;
                    next.ItemsByFloor[curr.Elevator].Remove(toMove);
                    next.AddItem(curr.Elevator - 1, toMove);
                    if (next.IsValid && !seen.Contains(next))
                    {
                        possibilities.Add(next);
                        seen.Add(next);
                    }

                    for (int j = i + 1; j < thisFloorItems.Count; j++)
                    {
                        State next2 = next.Clone();
                        Item toMove2 = curr.ItemsByFloor[curr.Elevator][j];
                        next2.ItemsByFloor[curr.Elevator].Remove(toMove2);
                        next2.AddItem(curr.Elevator - 1, toMove2);
                        if (next2.IsValid && !seen.Contains(next2))
                        {
                            possibilities.Add(next2);
                            seen.Add(next2);
                        }
                    }
                }
            }

            return possibilities;
        }

        private static State BuildInitialState(string[] lines)
        {
            Dictionary<string, int> elementToIdx = new();
            State s = new();
            s.Elevator = 0;

            int nextIdx = 1;
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

                _equalityValue = new(() =>
                {
                    List<string> itemStrs = new();
                    foreach (var floorItems in ItemsByFloor)
                    {
                        int pairs = 0;
                        bool onlyPairs = true;
                        var distinctElementsOnFloor = floorItems.Select(fi => fi.ElementIdx).Distinct();
                        foreach (var distinct in distinctElementsOnFloor)
                        {
                            if (floorItems.Count(fi => fi.ElementIdx == distinct) == 2)
                            {
                                pairs++;
                            }
                            else
                            {
                                onlyPairs = false;
                                break;
                            }
                        }

                        if (onlyPairs && pairs > 0)
                        {
                            itemStrs.Add($"PAIR{pairs}");
                        }
                        else
                        {
                            string itemStr = string.Join("|", floorItems.Select(item => item.ToString()));
                            itemStrs.Add(itemStr);
                        }
                    }
                    return $"{Elevator}_{string.Join("_", itemStrs)}";
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

            public void Print()
            {
                for (int i = Floors - 1; i >= 0; i--)
                {
                    string elevatorStr = Elevator == i ? "E" : " ";
                    var floorItems = ItemsByFloor[i];
                    string printStr = $"{elevatorStr} F" + i + " " + string.Join(" ", floorItems.Select(i => i.ElementIdx + i.Type.ToString().Substring(0, 1)));
                    Console.WriteLine(printStr);
                }
            }

            public void AddItem(int floorIdx, Item item)
            {
                ItemsByFloor[floorIdx].Add(item);
                ItemsByFloor[floorIdx] = ItemsByFloor[floorIdx].OrderBy(i => i.Type).ThenBy(i => i.ElementIdx).ToList();
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(
                    Elevator,
                    ItemsByFloor[0].Count,
                    ItemsByFloor[1].Count,
                    ItemsByFloor[2].Count,
                    ItemsByFloor[3].Count);
            }

            public override bool Equals(object obj)
            {
                State other = (State)obj;

                return other._equalityValue.Value == _equalityValue.Value;

                //bool equal =
                //    Elevator == other.Elevator
                //    && ItemsByFloor[0].SequenceEqual(other.ItemsByFloor[0])
                //    && ItemsByFloor[1].SequenceEqual(other.ItemsByFloor[1])
                //    && ItemsByFloor[2].SequenceEqual(other.ItemsByFloor[2])
                //    && ItemsByFloor[3].SequenceEqual(other.ItemsByFloor[3]);

                //return equal;
            }
        }
    }
}