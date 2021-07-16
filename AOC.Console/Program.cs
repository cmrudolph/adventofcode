using AOC.Console;
using AOC.CSharp;
using AOC.FSharp;

var lines = Utils.ReadInput("2015", "19", "Actual");
long result = AOC2015_19.Solve1(lines);
System.Console.WriteLine(result);

long result2 = AOC2015_19.Solve2(lines);
System.Console.WriteLine(result2);