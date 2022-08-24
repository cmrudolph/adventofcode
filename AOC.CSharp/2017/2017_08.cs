using System.Text.RegularExpressions;

namespace AOC.CSharp;

public static class AOC2017_08
{
    private static readonly Regex Re = new(@"(\w+) (\w+) (-?\d+) if (\w+) (.*) (-?\d+)");
    
    public static long Solve1(string[] lines)
    {
        Registers registers = Solve(lines);
        return registers.Max;
    }

    public static long Solve2(string[] lines)
    {
        Registers registers = Solve(lines);
        return registers.AllTimeMax;
    }

    private static Registers Solve(string[] lines)
    {
        Registers registers = new();
        List<Instruction> instructions = lines.Select(Parse).ToList();

        foreach (Instruction inst in instructions)
        {
            bool act = inst.TestOp switch
            {
                ">" => registers.Get(inst.TestReg) > inst.TestAmt,
                ">=" => registers.Get(inst.TestReg) >= inst.TestAmt,
                "<" => registers.Get(inst.TestReg) < inst.TestAmt,
                "<=" => registers.Get(inst.TestReg) <= inst.TestAmt,
                "==" => registers.Get(inst.TestReg) == inst.TestAmt,
                "!=" => registers.Get(inst.TestReg) != inst.TestAmt,
                _ => throw new NotSupportedException(inst.TestOp),
            };

            if (act)
            {
                registers.Change(inst.ChangeReg, inst.IncDec, inst.ChangeAmt);
            }
        }

        return registers;
    }

    private static Instruction Parse(string line)
    {
        Match m = Re.Match(line);
        string changeReg = m.Groups[1].Value;
        IncDec incDec = Enum.Parse<IncDec>(m.Groups[2].Value, true);
        int changeAmt = int.Parse(m.Groups[3].Value);
        string testReg = m.Groups[4].Value;
        string testOp = m.Groups[5].Value;
        int testAmt = int.Parse(m.Groups[6].Value);

        return new(changeReg, incDec, changeAmt, testReg, testOp, testAmt);
    }

    private class Registers
    {
        private int _allTimeMax = 0;
        private readonly Dictionary<string, int> _values = new();
        
        public int Get(string reg) => _values.TryGetValue(reg, out int found) ? found : 0;

        public void Change(string reg, IncDec incDec, int amt)
        {
            if (!_values.ContainsKey(reg))
            {
                _values.Add(reg, 0);
            }

            int changeAmt = incDec == IncDec.Inc ? amt : -amt;
            _values[reg] += changeAmt;
            _allTimeMax = Math.Max(_allTimeMax, _values[reg]);
        }

        public int Max => _values.Values.Max();

        public int AllTimeMax => _allTimeMax;
    }

    private record Instruction(string ChangeReg, IncDec IncDec, int ChangeAmt, string TestReg, string TestOp, int TestAmt);

    private enum IncDec
    {
        Inc,
        Dec,
    }
}
