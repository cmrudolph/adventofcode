namespace Year2015

module Day02 =
    open Utils
    open Xunit

    let dimensions (line : string) =
        line.Split('x')
        |> Seq.map int
        |> Seq.toList
        |> List.sort

    let paper (dims : int list) =
        (3 * dims.[0] * dims.[1]) +
        (2 * dims.[1] * dims.[2]) +
        (2 * dims.[0] * dims.[2])

    let ribbon (dims : int list) =
        (2 * dims.[0]) +
        (2 * dims.[1]) +
        (dims.[0] * dims.[1] * dims.[2])

    let calculate allDimensions valueFunc =
        allDimensions
        |> Seq.map valueFunc
        |> Seq.sumBy int64

    let solve (lines : string[]) =
        let allDimensions = Seq.map dimensions lines
        let ans1 = calculate allDimensions paper
        let ans2 = calculate allDimensions ribbon

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "02" "sample" |> solveAndValidate (58L, 34L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "02" "actual" |> solveAndValidate (1598415L, 3812909L) solve