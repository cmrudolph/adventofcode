using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("06.txt");

int totalSum = 0;
HashSet<char> uniqueChars = new HashSet<char>();

foreach (string line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        totalSum += uniqueChars.Count;
        uniqueChars.Clear();
    }

    foreach (char ch in line)
    {
        uniqueChars.Add(ch);
    }
}

totalSum += uniqueChars.Count;

Console.WriteLine(totalSum);

var personCharLists = new List<List<char>>();

int phase2Sum = 0;

foreach (string line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        List<char> masterInner = personCharLists.First();
        foreach (var lst in personCharLists.Skip(1).ToList())
        {
            masterInner = masterInner.Intersect(lst).ToList();
        }

        phase2Sum += masterInner.Count;
        personCharLists.Clear();
    }
    else
    {
        List<char> chList = new List<char>();
        foreach (char ch in line)
        {
            chList.Add(ch);
        }
        personCharLists.Add(chList);
    }
}

List<char> master = personCharLists.First();
foreach (var lst in personCharLists.Skip(1).ToList())
{
    master = master.Intersect(lst).ToList();
}

phase2Sum += master.Count;
personCharLists.Clear();

Console.WriteLine(phase2Sum);