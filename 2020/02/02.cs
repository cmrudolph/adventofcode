using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("02.txt");

int result1 = 0;
foreach (string line in lines)
{
    var splits = line.Split(' ');
    var numSplits = splits[0].Split('-');
    int num1 = int.Parse(numSplits[0]);
    int num2 = int.Parse(numSplits[1]);
    char target = splits[1][0];
    string password = splits[2];

    int count = password.Count(ch => ch == target);
    if (count >= num1 && count <= num2)
    {
        result1++;
    }
}

int result2 = 0;
foreach (string line in lines)
{
    var splits = line.Split(' ');
    var numSplits = splits[0].Split('-');
    int num1 = int.Parse(numSplits[0]);
    int num2 = int.Parse(numSplits[1]);
    char target = splits[1][0];
    string password = splits[2];

    char ch1 = password[num1 - 1];
    char ch2 = password[num2 - 1];

    if ((ch1 == target || ch2 == target) && ch1 != ch2)
    {
        result2++;
    }
}

Console.WriteLine(result1);
Console.WriteLine(result2);