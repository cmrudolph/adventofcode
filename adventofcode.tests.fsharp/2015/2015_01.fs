namespace Year2015

module Day01 =
    open Utils
    open Xunit

    let upOrDown symbol =
        match symbol with
        | '(' -> 1
        | ')' -> -1
        | _ -> 0

    let floor chars =
        chars |> Seq.sumBy upOrDown |> int64

    let rec basementPos currPos count chars =
        match chars with
        | [] -> -1L
        | x::xs ->
            let move = upOrDown x
            let newPos = currPos + move
            if newPos = -1 then
                (count + 1) |> int64
            else
                basementPos newPos (count + 1) xs

    let solve (lines : string[]) =
        let chars = lines.[0] |> Seq.toList
        let ans1 = floor chars
        let ans2 = basementPos 0 0 chars

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "01" "sample" |> solveAndValidate (-1L, 5L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "01" "actual" |> solveAndValidate (74L, 1795L) solve