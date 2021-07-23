using AOC.Console;
using AOC.CSharp;
using AOC.FSharp;

var lines = Utils.ReadInput("2015", "22", "Actual");
long result1 = AOC2015_22.Solve1(lines, 50, 500);
System.Console.WriteLine(result1);

long result2 = AOC2015_22.Solve2(lines, 50, 500);
System.Console.WriteLine(result2);