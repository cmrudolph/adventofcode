using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("07.txt");

Regex regexNonLeaf = new("(.*) bags contain (.*)\\.");
Regex regexLeaf = new("(.*) bags contain no other bags.");
Regex regexUnpackContents = new("(\\d+) (.*) bag");

Dictionary<string, BagEntry[]> adjLists = new();


foreach (string line in lines)
{
    Match m1 = regexNonLeaf.Match(line);
    Match m2 = regexLeaf.Match(line);

    if (m2.Success)
    {
        string source = m1.Groups[1].Value.Replace(" ", "");
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

int paths = 0;
foreach (string start in adjLists.Keys.Where(k => k != "shiny gold"))
{
    bool found = FindShinyGold(adjLists, start);
    paths += found ? 1 : 0;
}
Console.WriteLine(paths);

int countInside = 0;
foreach (BagEntry bagEntry in adjLists["shiny gold"])
{
    countInside += CountInside(adjLists, bagEntry);
}
Console.WriteLine(countInside);

static bool FindShinyGold(Dictionary<string, BagEntry[]> adjLists, string root)
{
    bool found = false;
    if (!adjLists.ContainsKey(root) || !adjLists[root].Any())
    {
        return false;
    }
    if (root == "shiny gold")
    {
        return true;
    }
    foreach (BagEntry next in adjLists[root])
    {
        found |= FindShinyGold(adjLists, next.Color);
    }
    return found;
}

static int CountInside(Dictionary<string, BagEntry[]> adjLists, BagEntry root)
{
    if (!adjLists.ContainsKey(root.Color) || !adjLists[root.Color].Any())
    {
        return root.Quantity;
    }

    int countInsideEach = 0;
    foreach (BagEntry next in adjLists[root.Color])
    {
        countInsideEach += CountInside(adjLists, next);
    }

    return root.Quantity + (root.Quantity * countInsideEach);
}

public record BagEntry(string Color, int Quantity);
