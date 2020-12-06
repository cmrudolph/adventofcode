using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("05.txt");

int max = 0;

HashSet<int> ids = new HashSet<int>();

foreach (string line in lines)
{
    List<int> rows = Enumerable.Range(0, 128).ToList();
    List<int> seats = Enumerable.Range(0, 8).ToList();

    for (int i = 0; i < 8; i++)
    {
        char ch = line[i];

        if (ch == 'F')
        {
            rows = rows.Take(rows.Count / 2).ToList();
        }
        else
        {
            rows = rows.Skip(rows.Count / 2).ToList();
        }
    }

    for (int i = 0; i < 3; i++)
    {
        char ch = line[i+7];

        if (ch == 'L')
        {
            seats = seats.Take(seats.Count / 2).ToList();
        }
        else
        {
            seats = seats.Skip(seats.Count / 2).ToList();
        }
    }

    int row = rows.Single();
    int seat = seats.Single();
    int id = (row * 8) + seat;

    ids.Add(id);

    max = Math.Max(max, id);
}

Console.WriteLine(max);

bool foundSome = false;
int j = 0;

while(true)
{
    if (ids.Contains(j))
    {
        foundSome = true;
        j++;
    }
    else if (foundSome)
    {
        Console.WriteLine(j);
        break;
    }
    else
    {
        j++;
    }
}