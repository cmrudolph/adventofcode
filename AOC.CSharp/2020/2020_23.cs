using System.Text;

namespace AOC.CSharp;

public static class AOC2020_23
{
    public static string Solve1(string[] lines)
    {
        int[] rawArr = lines[0].ToCharArray().Select(ch => ch - '0').ToArray();
        Node[] arr = InitArr(rawArr);

        Node start = arr[rawArr[0]];
        DoMoves(arr, start, 100);

        StringBuilder sb = new();
        Node resultCurr = arr[1].Next;
        while (resultCurr != arr[1])
        {
            sb.Append(resultCurr.Number);
            resultCurr = resultCurr.Next;
        }

        return sb.ToString();
    }

    public static long Solve2(string[] lines)
    {
        int[] rawArrStart = lines[0].ToCharArray().Select(ch => ch - '0').ToArray();
        int[] rawArr = new int[1000000];
        for (int i = 0; i < rawArrStart.Length; i++)
        {
            rawArr[i] = rawArrStart[i];
        }
        for (int i = rawArrStart.Length; i < 1000000; i++)
        {
            rawArr[i] = i + 1;
        }
        Node[] arr = InitArr(rawArr);

        Node start = arr[rawArr[0]];
        DoMoves(arr, start, 10000000);

        Node result1 = arr[1].Next;
        Node result2 = result1.Next;

        return result1.Number * result2.Number;
    }

    private static Node[] InitArr(int[] rawArr)
    {
        Node[] arr = new Node[rawArr.Length + 1];
        for (int i = 1; i < arr.Length; i++)
        {
            arr[i] = new Node { Number = i };
        }

        for (int i = 1; i < arr.Length; i++)
        {
            int currIdx = rawArr[i - 1];
            int nextIdx = i == arr.Length - 1 ? rawArr[0] : rawArr[i];
            int prevIdx = i == 1 ? rawArr[arr.Length - 2] : rawArr[i - 2];
            arr[currIdx].Next = arr[nextIdx];
            arr[currIdx].Prev = arr[prevIdx];
        }

        return arr;
    }

    private static void DoMoves(Node[] arr, Node start, int moves)
    {
        Node curr = start;
        for (int i = 0; i < moves; i++)
        {
            Node segment1 = curr.Next;
            Node segment2 = segment1.Next;
            Node segment3 = segment2.Next;

            int destIdx = (int)curr.Number - 1;
            while (destIdx < 1 || segment1.Number == destIdx || segment2.Number == destIdx || segment3.Number == destIdx)
            {
                if (destIdx < 1)
                {
                    destIdx = arr.Length - 1;
                }
                else
                {
                    destIdx--;
                }
            }
            Node dest = arr[destIdx];

            // Cut out the slice that is being moved
            curr.Next = segment3.Next;
            segment3.Next.Prev = curr;

            // Situate the tail end of the slice next to dest's next neighbor
            segment3.Next = dest.Next;
            dest.Next.Prev = segment3;

            // Situate the head of the slice immediately after dest
            segment1.Prev = dest;
            dest.Next = segment1;

            curr = curr.Next;
        }
    }

    private class Node
    {
        public long Number { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
}
