module Utils

open Xunit

let readInput year problem suffix =
    System.IO.File.ReadAllLines($"../../../../input/{year}/{problem}-{suffix}.txt")

let solveAndValidate (expected : (int64 * int64)) solver lines =
    let result = solver lines
    Assert.Equal(expected, result)

let solveAndValidateStrInt64 (expected : (string * int64)) solver lines =
    let result = solver lines
    Assert.Equal(expected, result)