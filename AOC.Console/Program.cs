using AOC.Console;
using AOC.CSharp;
using AOC.FSharp;

var lines = Utils.ReadInput("2015", "21", "Actual");
long result1 = AOC2015_21.solve1(lines);
System.Console.WriteLine(result1);

long result2 = AOC2015_21.solve2(lines);
System.Console.WriteLine(result2);
