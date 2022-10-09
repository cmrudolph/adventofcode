namespace AOC.CSharp;

public static class AOC2017_25
{
    private const int Left = -1;
    private const int Right = 1;

    public static long Solve1(string[] lines)
    {
        // Converted instructions from input into code manually
        Dictionary<int, int> tape = new();
        int pos = 0;
        string state = "A";

        int GetTapeVal()
        {
            return tape.TryGetValue(pos, out int val) ? val : 0;
        }

        void Update(int newTapeVal, int posChange, string newState)
        {
            tape[pos] = newTapeVal;
            pos += posChange;
            state = newState;
        }

        void Handle(int val, Action zero, Action one)
        {
            if (val == 0)
            {
                zero();
            }
            else
            {
                one();
            }
        }

        for (int i = 0; i < 12919244; i++)
        {
            int val = GetTapeVal();

            switch (state)
            {
                case "A":
                    Handle(val, () => Update(1, Right, "B"), () => Update(0, Left, "C"));
                    break;
                case "B":
                    Handle(val, () => Update(1, Left, "A"), () => Update(1, Right, "D"));
                    break;
                case "C":
                    Handle(val, () => Update(1, Right, "A"), () => Update(0, Left, "E"));
                    break;
                case "D":
                    Handle(val, () => Update(1, Right, "A"), () => Update(0, Right, "B"));
                    break;
                case "E":
                    Handle(val, () => Update(1, Left, "F"), () => Update(1, Left, "C"));
                    break;
                case "F":
                    Handle(val, () => Update(1, Right, "D"), () => Update(1, Right, "A"));
                    break;
            }
        }

        return tape.Sum(t => t.Value);
    }
}
