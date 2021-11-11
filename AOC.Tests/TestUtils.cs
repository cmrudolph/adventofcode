using FluentAssertions;

namespace AOC.Tests;

public static class TestUtils
{
    public static string[] ReadInput(string year, string problem, string suffix)
    {
        return File.ReadAllLines($"../../../../input/{year}/{problem}-{suffix}.txt");
    }

    public static void Test<T>(T expected, Func<string[], T> solver, string[] lines)
    {
        var result = solver(lines);
        result.Should().Be(expected);
    }
}
