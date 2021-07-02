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

        public static void Test(long expected, Func<string[], long> solver, string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }

        public static void Test(string expected, Func<string[], string> solver, string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }
    }
}