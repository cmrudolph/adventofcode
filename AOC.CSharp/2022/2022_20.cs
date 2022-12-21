namespace AOC.CSharp;

public static class AOC2022_20
{
    public static long Solve1(string[] lines)
    {
        LinkedList<NodeVal> linked = new();
        LinkedListNode<NodeVal> head = null;
        LinkedListNode<NodeVal> curr = null;
        NodeVal zero = null;

        List<int> orig = lines.Select(int.Parse).ToList();

        for (int i = 0; i < orig.Count; i++)
        {
            int val = orig[i];
            if (val == 0)
            {
                zero = new NodeVal(i, 0);
            }

            if (linked.Count == 0)
            {
                head = linked.AddFirst(new NodeVal(i, val));
                curr = head;
            }
            else
            {
                curr = linked.AddAfter(curr, new NodeVal(i, val));
            }
        }

        for (int i = 0; i < orig.Count; i++)
        {
            int val = orig[i];
            var target = new NodeVal(i, val);
            var node = linked.Find(target);

            int moves = Math.Abs(val);
            bool forward = val > 0;
            for (int j = 0; j < moves; j++)
            {
                if (forward)
                {
                    var toAddAfter = node.Next;
                    if (toAddAfter == null)
                    {
                        toAddAfter = linked.First;
                    }
                    linked.Remove(node);
                    linked.AddAfter(toAddAfter, node);
                }
                else
                {
                    var toAddBefore = node.Previous;
                    if (toAddBefore == null)
                    {
                        toAddBefore = linked.Last;
                    }
                    linked.Remove(node);
                    linked.AddBefore(toAddBefore, node);
                }
            }
        }

        var zeroNode = linked.Find(zero);
        var finalCurr = zeroNode;
        int finalSum = 0;
        for (int i = 1; i <= 3000; i++)
        {
            var next = finalCurr.Next;
            if (next == null)
            {
                next = linked.First;
            }

            finalCurr = next;
            if (i % 1000 == 0)
            {
                finalSum += finalCurr.Value.Val;
            }
        }

        // List<int> shuffled = orig.ToList();
        // for (int i = 0; i < orig.Count; i++)
        // {
        //     // Console.WriteLine(string.Join(", ", shuffled));
        //     int val = orig[i];
        //     int oldPos = shuffled.FindIndex(x => x == val);
        //     int newPos = oldPos + val;
        //
        //     shuffled.RemoveAt(oldPos);
        //
        //     while (newPos < 0)
        //     {
        //         newPos += shuffled.Count;
        //     }
        //
        //     while (newPos >= shuffled.Count)
        //     {
        //         newPos -= shuffled.Count;
        //     }
        //
        //     shuffled.Insert(newPos, val);
        //     // Console.WriteLine(string.Join(", ", shuffled));
        //     // Console.WriteLine();
        // }
        //
        // int finalIdx = shuffled.FindIndex(x => x == 0);
        // int finalSum = 0;
        // for (int i = 1; i <= 3000; i++)
        // {
        //     finalIdx++;
        //     if (finalIdx == shuffled.Count)
        //     {
        //         finalIdx = 0;
        //     }
        //
        //     if (i > 0 && i % 1000 == 0)
        //     {
        //         Console.WriteLine("{0} | {1} | {2}", i, finalIdx, shuffled[finalIdx]);
        //         finalSum += shuffled[finalIdx];
        //     }
        // }

        return finalSum;
    }

    public static long Solve2(string[] lines)
    {
        return 888;
    }

    private record NodeVal(int Idx, int Val);
}
