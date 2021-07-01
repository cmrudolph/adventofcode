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

        public static void SolveAndValidate(
            Tuple<long, long> expected,
            Func<string[], Tuple<long, long>> solver,
            string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }

        public static void SolveAndValidate(
            long expected,
            Func<string[], long> solver,
            string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }

        public static void SolveAndValidate(
            Tuple<long, string> expected,
            Func<string[], Tuple<long, string>> solver,
            string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }

        public static void SolveAndValidate(
            Tuple<string, long> expected,
            Func<string[], Tuple<string, long>> solver,
            string[] lines)
        {
            var result = solver(lines);
            Assert.Equal(expected, result);
        }
    }
}