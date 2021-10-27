using CommandLine;

namespace AOC.Console
{
    public class CommandLineOptions
    {
        [Option('y', "year", Required = true, HelpText = "AOC Event Year")]
        public int Year { get; set; }

        [Option('d', "day", Required = true, HelpText = "AOC Day")]
        public int Day { get; set; }

        [Option('t', "type", Required = true, HelpText = "Sample or Actual")]
        public InputType InputType { get; set; }

        [Option('p', "part", Required = false, HelpText = "Part 1 or 2")]
        public string Part { get; set; }

        [Option('e', "extra", Required = false, HelpText = "Extra input data to pass")]
        public string Extra { get; set; }
    }
}
