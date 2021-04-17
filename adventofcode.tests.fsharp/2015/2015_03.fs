namespace Year2015

module Day03 =
    open Utils
    open Xunit

    let move (x,y) ch =
        match ch with
        | '^' -> (x, y-1)
        | '>' -> (x+1, y)
        | 'v' -> (x, y+1)
        | '<' -> (x-1, y)
        | _ -> (x, y)

    let visit filter chars =
        chars
        |> Seq.indexed
        |> Seq.filter filter
        |> Seq.map (fun (_, x) -> x)
        |> Seq.scan move (0,0)
        |> Seq.distinct

    let distinctLength seq =
        seq
        |> Seq.distinct
        |> Seq.length
        |> int64

    let calculate1 chars =
        chars
        |> visit (fun (_, _) -> true)
        |> distinctLength

    let calculate2 chars =
        let visited1 = chars |> visit (fun (idx, _) -> idx % 2 = 0)
        let visited2 = chars |> visit (fun (idx, _) -> idx % 2 = 1)

        Seq.append visited1 visited2 |> distinctLength

    let solve (lines : string[]) =
        let chars = lines.[0] |> Seq.toList

        let ans1 = chars |> calculate1
        let ans2 = chars |> calculate2

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "03" "sample" |> solveAndValidate (4L, 3L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "03" "actual" |> solveAndValidate (2572L, 2631L) solve