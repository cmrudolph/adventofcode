module Utils

open Xunit

let readInput year problem =
    System.IO.File.ReadAllLines($"../../../../input/{year}/{problem}.txt")

let solveAndValidate year problem (expected : (int64 * int64)) solver =
    let lines = readInput year problem
    let result = solver lines
    Assert.Equal(expected, result);