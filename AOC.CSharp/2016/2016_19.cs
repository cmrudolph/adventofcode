namespace AOC.CSharp;

public class AOC2016_19
{
    public static long Solve1(string[] lines)
    {
        int numElves = int.Parse(lines[0]);
        LinkedList<int> lst = new();

        var curr = lst.AddFirst(1);
        for (int i = 2; i <= numElves; i++)
        {
            curr = lst.AddAfter(curr, i);
        }

        curr = lst.First;
        while (lst.Count > 1)
        {
            var next = curr.Next ?? lst.First;
            lst.Remove(next);
            curr = curr.Next ?? lst.First;
        }

        return lst.First.Value;
    }

    public static long Solve2(string[] lines)
    {
        int n = int.Parse(lines[0]);
        int pow = 1;

        // Find the largest value of 3^x beneath our target
        int powResult = (int)Math.Pow(3, pow);
        while (powResult < n)
        {
            pow++;
            powResult = (int)Math.Pow(3, pow);
        }

        powResult = (int)Math.Pow(3, pow - 1);

        // The result at 3^x is itself. The solutions then start over at 1 and go up by 1 until we reach
        // 3^x. Once we hit this point, we start going up by 2 until the next cube (or in our case until we
        // hit our target which we know is coming up before 3^(x+1))
        int result = 0;
        for (int i = powResult; i < n; i++)
        {
            if (i < powResult * 2)
            {
                result += 1;
            }
            else
            {
                result += 2;
            }
        }

        return result;
    }
}
