using System;
using System.IO;

var lines = File.ReadAllLines("03.txt");

long result1 = CountThem(lines, 3, 1);

long result2 =
    CountThem(lines, 1, 1)
    * CountThem(lines, 3, 1)
    * CountThem(lines, 5, 1)
    * CountThem(lines, 7, 1)
    * CountThem(lines, 1, 2);

Console.WriteLine(result1);
Console.WriteLine(result2);

static long CountThem(string[] lines, int over, int step)
{
    int count = 0;
    for (int i = 0; i < lines.Length; i += step)
    {
        string line = lines[i];

        count += line[((i * over) / step) % line.Length] == '#' ? 1 : 0;
    }
    return count;
}