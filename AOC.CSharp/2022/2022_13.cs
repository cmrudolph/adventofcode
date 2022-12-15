using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AOC.CSharp;

public static class AOC2022_13
{
    public static long Solve1(string[] lines)
    {
        long result = 0;
        int index = 1;
        for (int i = 0; i < lines.Length; i += 3)
        {
            var left = Parse(JsonConvert.DeserializeObject<JArray>(lines[i]), false);
            var right = Parse(JsonConvert.DeserializeObject<JArray>(lines[i + 1]), false);

            var compareResult = Compare(left, right);
            if (compareResult == -1)
            {
                result += index;
            }

            index++;
        }

        return result;
    }

    public static long Solve2(string[] lines)
    {
        var parsed = lines
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => Parse(JsonConvert.DeserializeObject<JArray>(x), false))
            .ToList();

        parsed.Add(Parse(JsonConvert.DeserializeObject<JArray>("[[2]]"), true));
        parsed.Add(Parse(JsonConvert.DeserializeObject<JArray>("[[6]]"), true));

        parsed.Sort(Compare);

        int result = 1;
        for (int i = 0; i < parsed.Count; i++)
        {
            if (parsed[i].IsDivider)
            {
                result *= (i + 1);
            }
        }

        return result;
    }

    private static Element Parse(JToken jt, bool divider)
    {
        if (jt.Type == JTokenType.Array)
        {
            return new ListElement
            {
                IsDivider = divider,
                Elements = jt.Children().Select(x => Parse(x, false)).ToList()
            };
        }

        return new IntElement { Value = jt.Value<int>() };
    }

    private static int Compare(Element left, Element right)
    {
        ListElement MakeList(Element e)
        {
            if (e is IntElement)
            {
                return new ListElement { Elements = new() { e } };
            }

            return (ListElement)e;
        }

        if (left is IntElement l && right is IntElement r)
        {
            return l.Value.CompareTo(r.Value);
        }

        var leftList = MakeList(left);
        var rightList = MakeList(right);

        int minLength = Math.Min(leftList.Elements.Count, rightList.Elements.Count);
        for (int i = 0; i < minLength; i++)
        {
            int result = Compare(leftList.Elements[i], rightList.Elements[i]);
            if (result != 0)
            {
                return result;
            }
        }

        return leftList.Elements.Count.CompareTo(rightList.Elements.Count);
    }

    private abstract class Element
    {
        public bool IsDivider { get; set; }
    }

    private class IntElement : Element
    {
        public int Value { get; set; }
    }

    private class ListElement : Element
    {
        public List<Element> Elements { get; set; }
    }
}
