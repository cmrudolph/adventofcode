using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Solve(2020);
Solve(30000000);

static void Solve(int target)
{
    Dictionary<int, List<int>> lastSpokenLookup = new();

    int[] startingNumbers = File.ReadAllText("15.txt").Split(',').Select(int.Parse).ToArray();
    for (int i = 0; i < startingNumbers.Length; i++)
    {
        lastSpokenLookup[startingNumbers[i]] = new List<int> { i + 1 };
    }

    int curr = startingNumbers.Last();

    for (int i = startingNumbers.Length; i < target; i++)
    {
        int prev = curr;
        List<int> listForPrev = GetListForValue(lastSpokenLookup, prev);

        curr = listForPrev.Count <= 1
            ? 0
            : listForPrev[listForPrev.Count - 1] - listForPrev[listForPrev.Count - 2];

        List<int> listForCurr = GetListForValue(lastSpokenLookup, curr);
        listForCurr.Add(i + 1);
    }

    Console.WriteLine(curr);
}

static List<int> GetListForValue(Dictionary<int, List<int>> lookup, int value)
{
    List<int> list;
    if (!lookup.TryGetValue(value, out list))
    {
        list = new List<int>();
        lookup.Add(value, list);
    }

    return list;
}