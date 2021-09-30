using System;
using System.IO;
using Xunit;

namespace AOC.Tests
{
    public static class Utils
    {
        public static string[] ReadInput(string year, string problem, string suffix)
        {
            return File.ReadAllLines($"../../../../input/{year}/{problem}-{suffix}.txt");
        }

        public static void Test<T>(T expected, Func<string[], T> solver, string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }
    }
}