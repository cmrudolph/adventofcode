using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2022_07
{
    private static readonly Regex CdCommand = new(@"\$ cd (.*)");
    private static readonly Regex FileResult = new(@"(\d+) (.*)");

    public static long Solve1(string[] lines)
    {
        List<Node> folders = BuildStructure(lines);
        CalcSizes(folders[0]);

        return folders.Where(f => f.Type == NodeType.Folder && f.Size <= 100000).Sum(f => f.Size);
    }

    public static long Solve2(string[] lines)
    {
        List<Node> folders = BuildStructure(lines);
        CalcSizes(folders[0]);

        long used = folders[0].Size;
        long unused = 70000000 - used;
        long needToFree = 30000000 - unused;
        var smallToBig = folders.OrderBy(f => f.Size);
        var smallestValid = smallToBig.First(f => f.Size >= needToFree);

        return smallestValid.Size;
    }

    private static void CalcSizes(Node curr)
    {
        // Recursively process the tree, calculating folder sizes as we go. Only file sizes were included during
        // the initial build step.
        foreach (Node c in curr.Children.Where(x => x.Type == NodeType.Folder))
        {
            CalcSizes(c);
        }

        long mySize = curr.Children.Sum(x => x.Size);
        curr.Size = mySize;
    }

    private static List<Node> BuildStructure(string[] lines)
    {
        List<Node> folders = new();
        Node curr = null;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            // Directory handling. We are either going up or down in the tree
            Match cdMatch = CdCommand.Match(line);
            if (cdMatch.Success)
            {
                string dir = cdMatch.Groups[1].Value;
                if (dir == "..")
                {
                    // Going back up
                    curr = curr.Parent;
                }
                else
                {
                    // Going down into a new folder. Ignore sizes for now - we will calculate them in a separate step
                    Node newNode =
                        new()
                        {
                            Type = NodeType.Folder,
                            Name = dir,
                            Parent = curr,
                            Size = 0
                        };
                    folders.Add(newNode);
                    curr?.Children.Add(newNode);
                    curr = newNode;
                }
            }

            // File handling. We only care about the size and putting the file under the proper parent
            Match fileMatch = FileResult.Match(line);
            if (fileMatch.Success)
            {
                int size = int.Parse(fileMatch.Groups[1].Value);
                string name = fileMatch.Groups[2].Value;
                var fileNode = new Node
                {
                    Type = NodeType.File,
                    Name = name,
                    Size = size,
                    Parent = curr
                };
                curr.Children.Add(fileNode);
            }
        }

        return folders;
    }

    private class Node
    {
        public Node()
        {
            Children = new();
        }

        public NodeType Type { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; }
    }

    private enum NodeType
    {
        Folder,
        File,
    }
}
