namespace Year2020

module Day03 =
    open Utils
    open Xunit

    let solveCase input (right, down) =
        let width = List.head input |> List.length

        input
        |> List.mapi (fun i s -> if (i % down) = 0 then s.[((i * right) / down) % width] else '.')
        |> List.filter (fun ch -> ch = '#')
        |> List.length

    let calculate input cases =
        cases
        |> List.map (solveCase input)
        |> List.map int64
        |> List.reduce (*)

    let solve lines =
        let parsedLines =
            lines
            |> Seq.map Seq.toList
            |> Seq.toList

        let ans1 = calculate parsedLines [(3,1)]
        let ans2 = calculate parsedLines [(1,1);(3,1);(5,1);(7,1);(1,2)]

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "03" "sample" |> solveAndValidate (7L, 336L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "03" "actual" |> solveAndValidate (211L, 3584591857L) solve