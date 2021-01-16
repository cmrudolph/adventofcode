using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var values = new[] { 0 }.Concat(File.ReadAllLines("10.txt").Select(line => int.Parse(line)).OrderBy(v => v)).ToList();
values.Add(values[values.Count - 1] + 3);

int[] diffs = new[] { 0, 0, 0 };
Dictionary<int, long> numPathsFrom = new();
numPathsFrom.Add(values[values.Count - 1], 1);

for (int i = values.Count - 2; i >= 0; i--)
{
    diffs[values[i + 1] - values[i] - 1]++;
    numPathsFrom[values[i]] = Enumerable.Range(1, 3)
        .Select(j => values[i] + j)
        .Sum(v => numPathsFrom.TryGetValue(v, out long result) ? result : 0);
}

Console.WriteLine(diffs[0] * diffs[2]);
Console.WriteLine(numPathsFrom[values[0]]);
