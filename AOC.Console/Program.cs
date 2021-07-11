using AOC.Console;
using AOC.CSharp;
using AOC.FSharp;

var lines = Utils.ReadInput("2015", "17", "Actual");
long result = AOC2015_17.Solve1(lines, 150);
System.Console.WriteLine(result);

long result2 = AOC2015_17.Solve2(lines, 150);
System.Console.WriteLine(result2);
