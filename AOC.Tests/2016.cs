﻿using AOC.CSharp;
using AOC.FSharp;
using Xunit;

namespace AOC.Tests
{
    public class Year2016
    {
        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Sample() => Utils.Test(8L, AOC2016_01.solve1, ReadSample("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_1_Actual() => Utils.Test(230L, AOC2016_01.solve1, ReadActual("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Sample() => Utils.Test(4L, AOC2016_01.solve2, ReadSample("01"));

        [Fact, Trait("Speed", "Fast")]
        public void Day01_2_Actual() => Utils.Test(154L, AOC2016_01.solve2, ReadActual("01"));

        private static string[] ReadSample(string day)
        {
            return Utils.ReadInput("2016", day, "sample");
        }

        private static string[] ReadActual(string day)
        {
            return Utils.ReadInput("2016", day, "actual");
        }
    }
}