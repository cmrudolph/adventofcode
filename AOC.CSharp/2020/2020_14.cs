using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.CSharp
{
    public static class AOC2020_14
    {
        public static long Solve1(string[] lines)
        {
            static long ApplyMask(string mask, long x)
            {
                char[] valueChars = Util.ToBinaryString(x).ToCharArray();
                for (int i = 0; i < 36; i++)
                {
                    valueChars[i] = mask[i] switch
                    {
                        '0' => '0',
                        '1' => '1',
                        _ => valueChars[i],
                    };
                }

                string valueStr = new string(valueChars);
                return Util.FromBinaryString(valueStr);
            }

            Dictionary<long, long> memory = new();

            string mask = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line.Substring(7);
                }
                else
                {
                    Instruction inst = Util.Parse(line);
                    memory[inst.Address] = ApplyMask(mask, inst.Value);
                }
            }

            return memory.Values.Sum(v => v);
        }

        public static long Solve2(string[] lines)
        {
            static string ApplyMask(string mask, string address)
            {
                char[] memoryChars = address.ToCharArray();
                for (int i = 0; i < 36; i++)
                {
                    memoryChars[i] = mask[i] switch
                    {
                        '1' => '1',
                        'X' => 'X',
                        _ => memoryChars[i]
                    };
                }

                return new string(memoryChars);
            }

            Dictionary<long, long> memory = new();

            string mask = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line.Substring(7);
                }
                else
                {
                    Instruction inst = Util.Parse(line);
                    string addressStr = ApplyMask(mask, Util.ToBinaryString(inst.Address));

                    List<string> addresses = new();
                    addresses.Add(addressStr);
                    for (int i = 0; i < 36; i++)
                    {
                        if (mask[i] == 'X')
                        {
                            int count = addresses.Count;

                            for (int j = count - 1; j >= 0; j--)
                            {
                                char[] mutable = addresses[j].ToCharArray();
                                mutable[i] = '0';
                                addresses.Add(new string(mutable));
                                mutable[i] = '1';
                                addresses.Add(new string(mutable));
                                addresses.RemoveAt(j);
                            }
                        }
                    }

                    foreach (string address in addresses)
                    {
                        long addressNumeric = Util.FromBinaryString(address);
                        memory[addressNumeric] = inst.Value;
                    }
                }
            }

            return memory.Values.Sum(v => v);
        }

        public static class Util
        {
            private static readonly Regex ValueRegex = new Regex(@"mem\[(.*)\] = (.*)");

            public static string ToBinaryString(long x)
            {
                return Convert.ToString(x, 2).PadLeft(36, '0');
            }

            public static long FromBinaryString(string b)
            {
                return Convert.ToInt64(b, 2);
            }

            public static Instruction Parse(string line)
            {
                Match m = ValueRegex.Match(line);
                long address = long.Parse(m.Groups[1].Value);
                long value = long.Parse(m.Groups[2].Value);

                return new Instruction(address, value);
            }
        }

        public record Instruction(long Address, long Value);
    }
}