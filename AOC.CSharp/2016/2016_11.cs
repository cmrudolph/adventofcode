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

            int best = int.MaxValue;
            HashSet<State> history = new();
            TraverseOptions(history, initialState, ref best);

            return best;
        }

        public static long Solve2(string[] lines)
        {
            return -1;
        }

        private static void TraverseOptions(HashSet<State> history, State curr, ref int best)
        {
            int steps = history.Count;
            if (steps >= best)
            {
                return;
            }

            curr.Print();
            Console.WriteLine();

            if (!curr.ItemsByFloor[0].Any() && !curr.ItemsByFloor[1].Any() && !curr.ItemsByFloor[2].Any())
            {
                // Everything on the top floor. We are done.
                best = steps;
                return;
            }

            var nextStates = GenerateNextValidStates(curr);
            nextStates.RemoveAll(s => history.Contains(s));

            foreach (State next in nextStates)
            {
                history.Add(curr);
                TraverseOptions(history, next, ref best);
                history.Remove(curr);
            }
        }

        private static List<State> GenerateNextValidStates(State curr)
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
                    possibilities.Add(next);

                    for (int j = i + 1; j < thisFloorItems.Count; j++)
                    {
                        State next2 = next.Clone();
                        Item toMove2 = curr.ItemsByFloor[curr.Elevator][j];
                        next2.ItemsByFloor[curr.Elevator].Remove(toMove2);
                        next2.AddItem(curr.Elevator + 1, toMove2);
                        possibilities.Add(next2);
                    }
                }

                if (curr.Elevator - 1 >= 0)
                {
                    State next = curr.Clone();
                    Item toMove = curr.ItemsByFloor[curr.Elevator][i];
                    next.Elevator--;
                    next.ItemsByFloor[curr.Elevator].Remove(toMove);
                    next.AddItem(curr.Elevator - 1, toMove);
                    possibilities.Add(next);

                    for (int j = i + 1; j < thisFloorItems.Count; j++)
                    {
                        State next2 = next.Clone();
                        Item toMove2 = curr.ItemsByFloor[curr.Elevator][j];
                        next2.ItemsByFloor[curr.Elevator].Remove(toMove2);
                        next2.AddItem(curr.Elevator - 1, toMove2);
                        possibilities.Add(next2);
                    }
                }
            }

            return possibilities.Where(p => p.IsValid).ToList();
        }

        private static State BuildInitialState(string[] lines)
        {
            State s = new();
            s.Elevator = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                var chipMatches = MicrochipRegex.Matches(line);
                foreach (Match m in chipMatches)
                {
                    string element = m.Groups[1].Value;
                    Item item = new Item(ItemType.Microchip, element);
                    s.AddItem(i, item);
                }

                var generatorMatches = GeneratorRegex.Matches(line);
                foreach (Match m in generatorMatches)
                {
                    string element = m.Groups[1].Value;
                    Item item = new Item(ItemType.Generator, element);
                    s.AddItem(i, item);
                }
            }

            return s;
        }

        private record Item(ItemType Type, string Element);

        private enum ItemType
        {
            Generator,
            Microchip,
        }

        private class State
        {
            public const int Floors = 4;

            public State()
            {
                ItemsByFloor = new List<Item>[Floors];
                for (int i = 0; i < Floors; i++)
                {
                    ItemsByFloor[i] = new();
                }
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
                            if (!thisFloorItems.Any(item => item.Type == ItemType.Generator && item.Element == chip.Element))
                            {
                                // A chip exists in the presence of other generators without its generator
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }

            public int Elevator { get; set; }

            public List<Item>[] ItemsByFloor { get; set; }

            public void Print()
            {
                for (int i = Floors - 1; i >= 0; i--)
                {
                    var floorItems = ItemsByFloor[i];
                    string printStr = "F" + i + " " + string.Join(" ", floorItems.Select(i => i.Element.Substring(0, 1).ToUpperInvariant() + i.Type.ToString().Substring(0, 1)));
                    Console.WriteLine(printStr);
                }
            }

            public void AddItem(int floorIdx, Item item)
            {
                ItemsByFloor[floorIdx].Add(item);
                ItemsByFloor[floorIdx] = ItemsByFloor[floorIdx].OrderBy(i => i.Type).ThenBy(i => i.Element).ToList();
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

                bool equal =
                    Elevator == other.Elevator
                    && ItemsByFloor[0].SequenceEqual(other.ItemsByFloor[0])
                    && ItemsByFloor[1].SequenceEqual(other.ItemsByFloor[1])
                    && ItemsByFloor[2].SequenceEqual(other.ItemsByFloor[2])
                    && ItemsByFloor[3].SequenceEqual(other.ItemsByFloor[3]);

                return equal;
            }
        }
    }
}