using System.Text;

namespace AOC.CSharp;

public static class AOC2021_16
{
    public static long Solve1(string[] lines)
    {
        return Solve(lines[0]).versionSum;
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines[0]).expressionResult;
    }

    private static (long versionSum, long expressionResult) Solve(string line)
    {
        BinaryString b = new(line);
        List<long> versions = new();

        long result = ProcessPacket(b, versions);

        return (versions.Sum(), result);
    }

    private static long ProcessPacket(BinaryString b, List<long> versions)
    {
        long version = b.ReadBits(3);
        long type = b.ReadBits(3);
        versions.Add(version);

        if (type == 4)
        {
            // Base case. Literals contain no sub packets, so just calculate the value they represent and return
            return ProcessLiteral(b);
        }

        List<long> subResults = new();

        // Operator case. Determine how to read the sub packets
        long lengthTypeId = b.ReadBits(1);
        if (lengthTypeId == 0)
        {
            // Sub packet section is defined by the number of bits
            long subPacketBitLength = b.ReadBits(15);
            long positionBefore = b.Position;
            long goalPosition = positionBefore + subPacketBitLength;
            while (b.Position < goalPosition)
            {
                long subResult = ProcessPacket(b, versions);
                subResults.Add(subResult);
            }
        }
        else if (lengthTypeId == 1)
        {
            // Sub packet section is defined by the number of packets
            long numberOfSubPackets = b.ReadBits(11);
            for (int i = 0; i < numberOfSubPackets; i++)
            {
                long subResult = ProcessPacket(b, versions);
                subResults.Add(subResult);
            }
        }

        // Evaluate the different operators against the sub packet results
        return type switch
        {
            0 => subResults.Sum(),
            1 => subResults.Aggregate(1L, (acc, x) => acc * x),
            2 => subResults.Min(),
            3 => subResults.Max(),
            5 => subResults[0] > subResults[1] ? 1 : 0,
            6 => subResults[0] < subResults[1] ? 1 : 0,
            7 => subResults[0] == subResults[1] ? 1 : 0,
            _ => throw new NotSupportedException(type.ToString()),
        };
    }

    private static long ProcessLiteral(BinaryString b)
    {
        long literalValue = 0L;
        long literalChunk;
        do
        {
            literalChunk = b.ReadBits(5);
            literalValue <<= 4;
            literalValue |= literalChunk & 0xF;
        } while ((literalChunk & 0x10) != 0);

        return literalValue;
    }

    private class BinaryString
    {
        private readonly string _bin;
        private int _pos;

        public BinaryString(string hex)
        {
            _bin = HexToBinary(hex);
        }

        public long ReadBits(int length)
        {
            string slice = _bin[_pos..(_pos + length)];
            _pos += length;
            return Convert.ToInt64(slice, 2);
        }

        public int Position => _pos;

        private static string HexToBinary(string hex)
        {
            StringBuilder sb = new();
            foreach(char c in hex)
            {
                int asInt = Convert.ToInt32(c.ToString(), 16);
                string asBinary = Convert.ToString(asInt, 2).PadLeft(4, '0');
                sb.Append(asBinary);
            }

            return sb.ToString();
        }
    }
}
