using System.Reflection;
using System.Text;

namespace AOC.ReadmeGenerator;

class Program
{
    static void Main(string[] args)
    {
        string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string titlePath = Path.Combine(exeDir, "Titles.txt");
        var searchRoot = Path.Combine(exeDir, @"..\..\..\..");

        Console.WriteLine(Assembly.GetExecutingAssembly().Location);
        Console.WriteLine(exeDir);

        var titles = File.ReadAllLines(titlePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(CreateTitleRecord)
            .ToList();

        var groups = Directory.GetFiles(searchRoot, "*_*.cs", SearchOption.AllDirectories)
            .Concat(Directory.GetFiles(searchRoot, "*_*.fs", SearchOption.AllDirectories))
            .Concat(Directory.GetFiles(searchRoot, "aoc*_*.py", SearchOption.AllDirectories))
            .Concat(Directory.GetFiles(searchRoot, "*_*.go", SearchOption.AllDirectories))
            .Where(f => !f.Contains("XX"))
            .Where(f => !f.Contains("test"))
            .Select(f => Create(searchRoot, f))
            .OrderBy(f => f.SortName)
            .GroupBy(f => f.Year)
            .ToList();

        StringBuilder sb = new();

        foreach (var group in groups)
        {
            sb.AppendLine($"# {group.Key}");
            foreach (var file in group)
            {
                var title = titles.First(t => t.Year == file.Year && t.Day == file.Day);
                sb.AppendLine(file.ToMarkdown(title));
            }
            sb.AppendLine("</br>");
        }

        string readmePath = Path.Combine(searchRoot, "README.md");
        File.WriteAllText(readmePath, sb.ToString());
    }

    private static TitleRecord CreateTitleRecord(string line)
    {
        string[] mainSplits = line.Split(" | ");
        string[] dateSplits = mainSplits[0].Split('-');

        int year = int.Parse(dateSplits[0]);
        int day = int.Parse(dateSplits[1]);
        string title = mainSplits[1];

        return new TitleRecord(year, day, title);
    }

    private static SourceFile Create(string searchRoot, string rawPath)
    {
        string readmePath = rawPath.Replace(searchRoot, "");
        string sortName = Path.GetFileNameWithoutExtension(readmePath).Replace("aoc", "");
        string extension = Path.GetExtension(readmePath);
        string markdownReadmePath = readmePath.Replace("\\", "/");

        Console.WriteLine(sortName);
        string[] splits = sortName.Split("_");
        int year = int.Parse(splits[0]);
        int day = int.Parse(splits[1]);

        string language = extension switch
        {
            ".cs" => "C#",
            ".fs" => "F#",
            ".py" => "Python",
            ".go" => "Go",
            _ => throw new NotSupportedException()
        };

        return new(sortName, markdownReadmePath, year, day, language);
    }

    private record TitleRecord(int Year, int Day, string Title);

    private record SourceFile(string SortName, string ReadmePath, int Year, int Day, string Language)
    {
        public string ToMarkdown(TitleRecord title)
        {
            return $"**Day {Day}** | [{title.Title}]({ReadmePath}) | {Language}</br>";
        }
    }
}
