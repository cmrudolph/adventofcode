using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("07.txt");
Dictionary<string, BagEntry[]> adjLists = new();

Regex regexNonLeaf = new("(.*) bags contain (.*)\\.");
Regex regexLeaf = new("(.*) bags contain no other bags.");
Regex regexUnpackContents = new("(\\d+) (.*) bag");

foreach (string line in lines)
{
    Match m1 = regexNonLeaf.Match(line);
    Match m2 = regexLeaf.Match(line);

    if (m2.Success)
    {
        string source = m1.Groups[1].Value;
        adjLists[source] = new BagEntry[0];
    }
    else if (m1.Success)
    {
        string source = m1.Groups[1].Value;
        adjLists[source] = m1.Groups[2].Value
            .Split(',')
            .Select(s => regexUnpackContents.Match(s))
            .Select(c => new BagEntry(c.Groups[2].Value, int.Parse(c.Groups[1].Value)))
            .ToArray();
    }
}

int paths = adjLists.Keys.Where(k => k != "shiny gold").Count(k => FindShinyGold(adjLists, k));
Console.WriteLine(paths);

int countInside = adjLists["shiny gold"].Sum(bagEntry => CountInside(adjLists, bagEntry));
Console.WriteLine(countInside);

static bool FindShinyGold(Dictionary<string, BagEntry[]> adjLists, string root)
{
    if (root == "shiny gold")
    {
        return true;
    }
    if (!adjLists.ContainsKey(root))
    {
        return false;
    }

    return adjLists[root].Any(bagEntry => FindShinyGold(adjLists, bagEntry.Color));
}

static int CountInside(Dictionary<string, BagEntry[]> adjLists, BagEntry root)
{
    if (!adjLists.ContainsKey(root.Color))
    {
        return root.Quantity;
    }

    int countInsideEach = adjLists[root.Color].Sum(bagEntry => CountInside(adjLists, bagEntry));
    return root.Quantity + (root.Quantity * countInsideEach);
}

public record BagEntry(string Color, int Quantity);
