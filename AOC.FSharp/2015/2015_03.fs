namespace AOC.FSharp

module AOC2015_03 =
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

    let solve1 (lines : string[]) =
        lines.[0] |> Seq.toList |> calculate1

    let solve2 (lines : string[]) =
        lines.[0] |> Seq.toList |> calculate2