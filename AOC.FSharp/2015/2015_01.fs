namespace AOC.FSharp

module AOC2015_01 =
    let upOrDown symbol =
        match symbol with
        | '(' -> 1
        | ')' -> -1
        | _ -> 0

    let floor chars = chars |> Seq.sumBy upOrDown |> int64

    let rec basementPos currPos count chars =
        match chars with
        | [] -> -1L
        | x :: xs ->
            let move = upOrDown x
            let newPos = currPos + move

            if newPos = -1 then
                (count + 1) |> int64
            else
                basementPos newPos (count + 1) xs

    let solve1 (lines: string []) =
        let chars = lines.[0] |> Seq.toList
        floor chars

    let solve2 (lines: string []) =
        let chars = lines.[0] |> Seq.toList
        basementPos 0 0 chars
