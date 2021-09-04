namespace AOC.FSharp

module AOC2016_02 =

    let move1 curr dir =
        match (curr, dir) with
        | '1', 'D' -> '4'
        | '1', 'R' -> '2'
        | '2', 'L' -> '1'
        | '2', 'D' -> '5'
        | '2', 'R' -> '3'
        | '3', 'L' -> '2'
        | '3', 'D' -> '6'
        | '4', 'U' -> '1'
        | '4', 'D' -> '7'
        | '4', 'R' -> '5'
        | '5', 'L' -> '4'
        | '5', 'U' -> '2'
        | '5', 'D' -> '8'
        | '5', 'R' -> '6'
        | '6', 'L' -> '5'
        | '6', 'U' -> '3'
        | '6', 'D' -> '9'
        | '7', 'U' -> '4'
        | '7', 'R' -> '8'
        | '8', 'L' -> '7'
        | '8', 'U' -> '5'
        | '8', 'R' -> '9'
        | '9', 'L' -> '8'
        | '9', 'U' -> '6'
        | _ -> curr

    let move2 curr dir =
        match (curr, dir) with
        | '1', 'D' -> '3'
        | '2', 'D' -> '6'
        | '2', 'R' -> '3'
        | '3', 'L' -> '2'
        | '3', 'U' -> '1'
        | '3', 'D' -> '7'
        | '3', 'R' -> '4'
        | '4', 'L' -> '3'
        | '4', 'D' -> '8'
        | '5', 'R' -> '6'
        | '6', 'L' -> '5'
        | '6', 'U' -> '2'
        | '6', 'D' -> 'A'
        | '6', 'R' -> '7'
        | '7', 'L' -> '6'
        | '7', 'U' -> '3'
        | '7', 'D' -> 'B'
        | '7', 'R' -> '8'
        | '8', 'L' -> '7'
        | '8', 'U' -> '4'
        | '8', 'D' -> 'C'
        | '8', 'R' -> '9'
        | '9', 'L' -> '8'
        | 'A', 'U' -> '6'
        | 'A', 'R' -> 'B'
        | 'B', 'L' -> 'A'
        | 'B', 'U' -> '7'
        | 'B', 'D' -> 'D'
        | 'B', 'R' -> 'C'
        | 'C', 'L' -> 'B'
        | 'C', 'U' -> '8'
        | 'D', 'U' -> 'B'
        | _ -> curr

    let solveLine start line move =
        let chars = Seq.toList line
        (start, chars) ||> List.fold move

    let solve move lines =
        let mutable code = []
        let mutable start = '5'

        for line in lines do
            start <- solveLine start line move
            code <- code @ [ start ]

        code |> List.map string |> List.reduce (+)

    let solve1 (lines: string []) =
        let solver = solve move1
        lines |> solver

    let solve2 (lines: string []) =
        let solver = solve move2
        lines |> solver
