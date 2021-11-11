using System;
using System.Collections.Generic;

namespace AOC.CSharp;

public class AOC2016_25
{
    public static long Solve1(string[] lines)
    {
        int i = 0;
        while (true)
        {
            Registers registers = new();
            registers.Set("a", i);
            int lastOutValue = 1;
            int outSequenceCount = 0;

            int j = 0;
            bool fail = false;
            while (!fail && j < lines.Length)
            {
                string[] splits = lines[j].Split(" ");
                string inst = splits[0];
                switch (inst)
                {
                    case "cpy":
                        {
                            string src = splits[1];
                            string destReg = splits[2];
                            int value = char.IsDigit(src[0]) ? int.Parse(src) : registers.Get(src);
                            registers.Set(destReg, value);
                            j++;
                            break;
                        }
                    case "inc":
                        {
                            string reg = splits[1];
                            registers.Transform(reg, v => v + 1);
                            j++;
                            break;
                        }
                    case "dec":
                        {
                            string reg = splits[1];
                            registers.Transform(reg, v => v - 1);
                            j++;
                            break;
                        }
                    case "jnz":
                        {
                            string cmpValueRaw = splits[1];
                            int cmpValue = char.IsDigit(cmpValueRaw[0]) ? int.Parse(cmpValueRaw) : registers.Get(cmpValueRaw);
                            int jmpAmount = cmpValue == 0 ? 1 : int.Parse(splits[2]);
                            j += jmpAmount;
                            break;
                        }
                    case "out":
                        {
                            string src = splits[1];
                            int value = char.IsDigit(src[0]) ? int.Parse(src) : registers.Get(src);
                            if ((value == 0 && lastOutValue == 1) || (value == 1 && lastOutValue == 0))
                            {
                                lastOutValue = value;
                                outSequenceCount++;
                            }
                            else
                            {
                                fail = true;
                            }
                            j++;
                            break;
                        }
                }

                // Enough to assume the sequence will go on forever
                if (outSequenceCount == 200)
                {
                    return i;
                }
            }
            i++;
        }
    }

    private class Registers
    {
        private const int DefaultValue = 0;

        private readonly Dictionary<string, int> _dict = new();

        public void Set(string reg, int value)
        {
            _dict[reg] = value;
        }

        public int Get(string reg)
        {
            return _dict.TryGetValue(reg, out int existing) ? existing : DefaultValue;
        }

        public void Transform(string reg, Func<int, int> transformer)
        {
            int existing = Get(reg);
            int transformed = transformer(existing);
            Set(reg, transformed);
        }
    }
}
