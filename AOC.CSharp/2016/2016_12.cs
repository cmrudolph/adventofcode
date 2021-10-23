using AOC.Utils;

namespace AOC.CSharp
{
    public class AOC2016_12
    {
        public static long Solve1(string[] lines)
        {
            CustomDictionary<string, int> registers = new(0);
            return Solve(registers, lines);
        }

        public static long Solve2(string[] lines)
        {
            CustomDictionary<string, int> registers = new(0);
            registers.Set("c", 1);
            return Solve(registers, lines);
        }

        private static long Solve(CustomDictionary<string, int> registers, string[] lines)
        {
            int i = 0;
            while (i < lines.Length)
            {
                string[] splits = lines[i].Split(" ");
                string inst = splits[0];
                switch (inst)
                {
                    case "cpy":
                        {
                            string src = splits[1];
                            string destReg = splits[2];
                            int value = char.IsDigit(src[0]) ? int.Parse(src) : registers.Get(src);
                            registers.Set(destReg, value);
                            i++;
                            break;
                        }
                    case "inc":
                        {
                            string reg = splits[1];
                            registers.Transform(reg, v => v + 1);
                            i++;
                            break;
                        }
                    case "dec":
                        {
                            string reg = splits[1];
                            registers.Transform(reg, v => v - 1);
                            i++;
                            break;
                        }
                    case "jnz":
                        {
                            string cmpValueRaw = splits[1];
                            int cmpValue = char.IsDigit(cmpValueRaw[0]) ? int.Parse(cmpValueRaw) : registers.Get(cmpValueRaw);
                            int jmpAmount = cmpValue == 0 ? 1 : int.Parse(splits[2]);
                            i += jmpAmount;
                            break;
                        }
                }
            }

            return registers.Get("a");
        }
    }
}