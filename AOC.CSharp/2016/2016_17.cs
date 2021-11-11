using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AOC.CSharp;

public class AOC2016_17
{
    public static string Solve1(string[] lines)
    {
        return Solve(lines, true);
    }

    public static long Solve2(string[] lines)
    {
        return Solve(lines, false).Length;
    }

    public static string Solve(string[] lines, bool shortest)
    {
        string prefix = lines[0];
        MD5 md5 = MD5.Create();

        XY target = new XY(3, 3);
        XY curr = new XY(0, 0);
        string path = "";
        string best = null;

        Recurse(md5, prefix, curr, target, path, shortest, ref best);
        return best;
    }

    private static void Recurse(MD5 md5, string prefix, XY curr, XY target, string path, bool shortest, ref string bestSolution)
    {
        if (shortest && path.Length > bestSolution?.Length)
        {
            // Path is not optimal for shortest solution
            return;
        }

        if (curr == target)
        {
            if (shortest)
            {
                bestSolution = path;
            }
            else if (bestSolution == null || path.Length > bestSolution?.Length)
            {
                bestSolution = path;
            }

            return;
        }

        var directions = GetDirections(md5, prefix, path);
        var potentials = GetPotentials(curr, directions);

        foreach (var potential in potentials)
        {
            path += potential.Letter;
            Recurse(md5, prefix, potential.XY, target, path, shortest, ref bestSolution);
            path = path[0..^1];
        }
    }

    private static List<Potential> GetPotentials(XY curr, Directions dir)
    {
        List<Potential> results = new(4);

        if (dir.HasFlag(Directions.Left) && curr.X > 0)
        {
            results.Add(new Potential(curr with { X = curr.X - 1 }, Directions.Left));
        }
        if (dir.HasFlag(Directions.Right) && curr.X < 3)
        {
            results.Add(new Potential(curr with { X = curr.X + 1 }, Directions.Right));
        }
        if (dir.HasFlag(Directions.Up) && curr.Y > 0)
        {
            results.Add(new Potential(curr with { Y = curr.Y - 1 }, Directions.Up));
        }
        if (dir.HasFlag(Directions.Down) && curr.Y < 3)
        {
            results.Add(new Potential(curr with { Y = curr.Y + 1 }, Directions.Down));
        }

        return results;
    }

    private record XY(int X, int Y);

    private record Potential(XY XY, Directions Direction)
    {
        public string Letter => Direction.ToString().Substring(0, 1);
    }

    private static Directions GetDirections(MD5 md5, string prefix, string path)
    {
        string toHash = prefix + path;
        byte[] bytes = Encoding.ASCII.GetBytes(toHash);
        byte[] hashed = md5.ComputeHash(bytes);
        string s1 = _base16CharTableLower[hashed[0]];
        string s2 = _base16CharTableLower[hashed[1]];

        Directions dir = Directions.None;
        if (s1[0] >= 'b' && s1[0] <= 'f')
        {
            dir |= Directions.Up;
        }
        if (s1[1] >= 'b' && s1[0] <= 'f')
        {
            dir |= Directions.Down;
        }
        if (s2[0] >= 'b' && s2[0] <= 'f')
        {
            dir |= Directions.Left;
        }
        if (s2[1] >= 'b' && s2[0] <= 'f')
        {
            dir |= Directions.Right;
        }

        return dir;
    }

    [Flags]
    private enum Directions
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
    }

    private static readonly string[] _base16CharTableLower = new[]
    {
            "00", "01", "02", "03", "04", "05", "06", "07",
            "08", "09", "0a", "0b", "0c", "0d", "0e", "0f",
            "10", "11", "12", "13", "14", "15", "16", "17",
            "18", "19", "1a", "1b", "1c", "1d", "1e", "1f",
            "20", "21", "22", "23", "24", "25", "26", "27",
            "28", "29", "2a", "2b", "2c", "2d", "2e", "2f",
            "30", "31", "32", "33", "34", "35", "36", "37",
            "38", "39", "3a", "3b", "3c", "3d", "3e", "3f",
            "40", "41", "42", "43", "44", "45", "46", "47",
            "48", "49", "4a", "4b", "4c", "4d", "4e", "4f",
            "50", "51", "52", "53", "54", "55", "56", "57",
            "58", "59", "5a", "5b", "5c", "5d", "5e", "5f",
            "60", "61", "62", "63", "64", "65", "66", "67",
            "68", "69", "6a", "6b", "6c", "6d", "6e", "6f",
            "70", "71", "72", "73", "74", "75", "76", "77",
            "78", "79", "7a", "7b", "7c", "7d", "7e", "7f",
            "80", "81", "82", "83", "84", "85", "86", "87",
            "88", "89", "8a", "8b", "8c", "8d", "8e", "8f",
            "90", "91", "92", "93", "94", "95", "96", "97",
            "98", "99", "9a", "9b", "9c", "9d", "9e", "9f",
            "a0", "a1", "a2", "a3", "a4", "a5", "a6", "a7",
            "a8", "a9", "aa", "ab", "ac", "ad", "ae", "af",
            "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7",
            "b8", "b9", "ba", "bb", "bc", "bd", "be", "bf",
            "c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7",
            "c8", "c9", "ca", "cb", "cc", "cd", "ce", "cf",
            "d0", "d1", "d2", "d3", "d4", "d5", "d6", "d7",
            "d8", "d9", "da", "db", "dc", "dd", "de", "df",
            "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7",
            "e8", "e9", "ea", "eb", "ec", "ed", "ee", "ef",
            "f0", "f1", "f2", "f3", "f4", "f5", "f6", "f7",
            "f8", "f9", "fa", "fb", "fc", "fd", "fe", "ff"
        };
}
