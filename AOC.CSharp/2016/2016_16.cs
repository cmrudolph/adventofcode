using System.Text;

namespace AOC.CSharp;

public class AOC2016_16
{
    public static string Solve(string[] lines, string extra)
    {
        int targetLength = int.Parse(extra);

        byte[] arr = new byte[targetLength * 2];
        for (int i = 0; i < lines[0].Length; i++)
        {
            arr[i] = lines[0][i] == '1' ? (byte)1 : (byte)0;
        }

        int size = lines[0].Length;
        while (size < targetLength)
        {
            size = Transform(arr, size);
        }

        string checksum = CalculateChecksum(arr, targetLength);

        return checksum;
    }

    public static int Transform(byte[] a, int size)
    {
        a[size] = 0;
        int j = size + 1;
        for (int i = size - 1; i >= 0; i--)
        {
            a[j++] = a[i] == 1 ? (byte)0 : (byte)1;
        }

        return (size * 2) + 1;
    }

    public static string CalculateChecksum(byte[] value, int size)
    {
        do
        {
            for (int i = 0; i < size; i += 2)
            {
                bool areSame = value[i] == value[i + 1];
                value[i / 2] = areSame ? (byte)1 : (byte)0;
            }
            size /= 2;
        }
        while (size % 2 == 0);

        StringBuilder sb = new();
        for (int i = 0; i < size; i++)
        {
            sb.Append(value[i] == 1 ? '1' : '0');
        }

        return sb.ToString();
    }
}
