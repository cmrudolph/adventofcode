using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC.CSharp;

public static class AOC2015_12
{
    public static long Solve1(string[] lines)
    {
        JsonTextReader reader = CreateReader(lines);

        long total = 0;
        while (reader.Read())
        {
            // Leverage Json.NET to do all the parsing and just sum up everything numeric it finds
            total += reader.TokenType == JsonToken.Integer ? (long)reader.Value : 0;
        }

        return total;
    }

    public static long Solve2(string[] lines)
    {
        JsonTextReader reader = CreateReader(lines);

        List<Token?> tokens = new();

        // Preprocess the tokens to make them easier to deal with (strip out all the details we do not care about)
        while (reader.Read())
        {
            tokens.Add(MapToken(reader));
        }

        tokens.RemoveAll(t => t == null);

        Stack<Token> stack = new();
        foreach (Token t in tokens)
        {
            if (t.Type == JsonToken.EndArray)
            {
                // End of an array: The red value does not matter here. Simply sum up every integer contained
                // within the bounds of the array and push the result back onto the stack. Ignore any reds that
                // we encounter during the traversal
                long valuePopped = 0L;
                Token popped = stack.Pop();
                while (popped.Type != JsonToken.StartArray)
                {
                    if (popped.Type == JsonToken.Integer)
                    {
                        valuePopped += popped.Value.Value;
                    }

                    popped = stack.Pop();
                }

                stack.Push(new Token { Type = JsonToken.Integer, Value = valuePopped });
            }
            else if (t.Type == JsonToken.EndObject)
            {
                // End of an object. If we find a red value here, force the sum (that we push back onto the stack)
                // to zero. Pushing a zero will nullify any summing done in children and will also cause the
                // effects of this red instance to propagate back to callers (by having them include our zero
                // result in their sum calculation)
                long valuePopped = 0L;
                bool forceZero = false;
                Token popped = stack.Pop();
                while (popped.Type != JsonToken.StartObject)
                {
                    if (!forceZero && popped.Type == JsonToken.Integer)
                    {
                        valuePopped += popped.Value.Value;
                    }
                    else if (popped.IsRed)
                    {
                        valuePopped = 0;
                        forceZero = true;
                    }

                    popped = stack.Pop();
                }

                stack.Push(new Token { Type = JsonToken.Integer, Value = valuePopped });
            }
            else
            {
                stack.Push(t);
            }
        }

        // What remains at the end of the traversal is the final sum that we pushed onto the stack when processing
        // the final 'end' token
        Token final = stack.Pop();
        return final.Value.Value;
    }

    private static Token? MapToken(JsonTextReader reader)
    {
        switch (reader.TokenType)
        {
            case JsonToken.StartArray:
            case JsonToken.EndArray:
            case JsonToken.StartObject:
            case JsonToken.EndObject:
                return new Token { Type = reader.TokenType };
            case JsonToken.Integer:
                return new Token { Type = reader.TokenType, Value = (long)reader.Value };
            case JsonToken.String:
                return (string)reader.Value == "red"
                    ? new Token { Type = reader.TokenType, IsRed = true }
                    : null;
        }

        return null;
    }

    private struct Token
    {
        public JsonToken Type { get; set; }
        public long? Value { get; set; }
        public bool IsRed { get; set; }
    }

    private static JsonTextReader CreateReader(string[] lines)
    {
        string combined = string.Join(" ", lines);
        return new JsonTextReader(new StringReader(combined));
    }
}
