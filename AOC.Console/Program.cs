using AOC.Console;
using AOC.CSharp;
using AOC.FSharp;

var lines = Utils.ReadInput("2016", "10", "Sample");
long result1 = AOC2016_10.Solve1(lines, new[] { 2, 5 });
System.Console.WriteLine(result1);