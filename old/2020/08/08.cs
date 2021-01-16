using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

const string Jmp = "jmp";
const string Acc = "acc";
const string Nop = "nop";

var rawLines = File.ReadAllLines("08.txt");

RunUntilEnd(rawLines.Select(Parse), false);

for (int i = 0; i < rawLines.Length; i++)
{
    var lines = rawLines.Select(Parse).ToList();
    lines[i].Instruction = lines[i].Instruction == Jmp ? Nop : lines[i].Instruction == Nop ? Jmp : lines[i].Instruction;
    RunUntilEnd(lines, true);
}

static LineEntry Parse(string line)
{
    var splits = line.Split(' ');

    return new LineEntry
    {
        Instruction = splits[0],
        Amount = int.Parse(splits[1]),
    };
}

void RunUntilEnd(IEnumerable<LineEntry> lines, bool printOnTerminate)
{
    int idx = 0;
    int acc = 0;

    var linesArr = lines.ToArray();
    while (idx < linesArr.Length)
    {
        LineEntry curr = linesArr[idx];
        if (curr.Visited)
        {
            if (!printOnTerminate)
            {
                Console.WriteLine(acc);
            }
            return;
        }

        curr.Visited = true;
        switch (curr.Instruction)
        {
            case Jmp:
                idx += curr.Amount;
                break;
            case Acc:
                acc += curr.Amount;
                idx++;
                break;
            case Nop:
                idx++;
                break;
        }
    }

    if (printOnTerminate)
    {
        Console.WriteLine(acc);
    }
}

public class LineEntry
{
    public string Instruction { get; set; }
    public int Amount { get; set; }
    public bool Visited { get; set; }
}
