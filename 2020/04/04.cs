using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

HashSet<string> validKeys = new HashSet<string>
{
    "byr",
    "iyr",
    "eyr",
    "hgt",
    "hcl",
    "ecl",
    "pid"
};

var lines = File.ReadAllLines("04.txt");

int result1 = 0;
var foundFields = new HashSet<string>();
for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    if (string.IsNullOrWhiteSpace(line))
    {
        if (foundFields.Count == 7)
        {
            result1++;
        }
        foundFields.Clear();
    }
    else
    {
        line
            .Split(' ')
            .Select(s => s.Split(':'))
            .Select(s => s[0])
            .Where(validKeys.Contains)
            .ToList()
            .ForEach(key => foundFields.Add(key));
    }
}

if (foundFields.Count == 7)
{
    result1++;
}

int result2 = 0;
var foundKeyValuePairs = new Dictionary<string, string>();
for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    if (string.IsNullOrWhiteSpace(line))
    {
        if (foundKeyValuePairs.Count == 7 && foundKeyValuePairs.All(kvp => IsValid(kvp.Key, kvp.Value)))
        {
            result2++;
        }
        foundKeyValuePairs.Clear();
    }
    else
    {
        line
            .Split(' ')
            .Select(s => s.Split(':'))
            .Select(s => (s[0], s[1]))
            .Where(t => validKeys.Contains(t.Item1))
            .ToList()
            .ForEach(t => foundKeyValuePairs.Add(t.Item1, t.Item2));
    }
}

if (foundKeyValuePairs.Count == 7 && foundKeyValuePairs.All(kvp => IsValid(kvp.Key, kvp.Value)))
{
    result2++;
}

Console.WriteLine(result1);
Console.WriteLine(result2);

static bool IsValid(string key, string value)
{
    switch (key)
    {
        case "byr":
            {
                int asInt = int.Parse(value);
                return asInt >= 1920 && asInt <= 2002;
            }
        case "iyr":
            {
                int asInt = int.Parse(value);
                return asInt >= 2010 && asInt <= 2020;
            }
        case "eyr":
            {
                int asInt = int.Parse(value);
                return asInt >= 2020 && asInt <= 2030;
            }
        case "hgt":
            {
                if (value.EndsWith("cm"))
                {
                    int asInt = int.Parse(value.Substring(0, value.Length - 2));
                    return asInt >= 150 && asInt <= 193;
                }
                else if (value.EndsWith("in"))
                {
                    int asInt = int.Parse(value.Substring(0, value.Length - 2));
                    return asInt >= 59 && asInt <= 76;
                }
                return false;
            }
        case "hcl":
            {
                if (value.StartsWith("#") && value.Length == 7)
                {
                    return value.Substring(1).All(ch => Char.IsDigit(ch) || (ch >= 'a' && ch <= 'f'));
                }
                return false;
            }
        case "ecl":
            {
                var allowed = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                return allowed.Any(a => a == value);
            }
        case "pid":
            {
                return value.Length == 9 && value.All(ch => Char.IsDigit(ch));
            }
        default: return false;
    }
}