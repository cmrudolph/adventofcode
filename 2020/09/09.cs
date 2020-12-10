using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

long[] values = File.ReadAllLines("09.txt").Select(line => long.Parse(line)).ToArray();
long magicValue = 0;
for (int i = 25; i < values.Length; i++)
{
    HashSet<long> sums = new();

    for (int j = i; j < i + 25; j++)
    {
        for (int k = j; k < i + 25; k++)
        {
            sums.Add(values[j - 25] + values[k - 25]);
        }
    }

    if (!sums.Contains(values[i]))
    {
        magicValue = values[i];
        Console.WriteLine(magicValue);
        break;
    }
}

for (int i = 0; i < values.Length; i++)
{
    int idx = i;
    long sum = 0;

    while (sum <= magicValue)
    {
        if (sum == magicValue)
        {
            var slice = values.Skip(i).Take(idx - i + 1).ToList();
            Console.WriteLine(slice.Min() + slice.Max());
            return;
        }
        else
        {
            sum += values[idx];
            idx++;
        }
    }
}