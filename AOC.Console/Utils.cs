namespace AOC.Console;

public static class Utils
{
    public static string[] ReadInput(string year, string problem, string suffix)
    {
        return File.ReadAllLines($"../../../../input/{year}/{problem}-{suffix}.txt");
    }
}
