namespace AOC.FSharp

module AOC2016_01 =
    type Instruction = { Rotation: int; Amount: int }

    type Position = { X: int; Y: int; Direction: int }

    let makeInstruction (raw: string) =
        let rotation =
            match raw.[0] with
            | 'R' -> 90
            | 'L' -> -90
            | _ -> failwith $"Unsupported direction {raw.[0]}"

        let amount = raw.[1..] |> int

        { Rotation = rotation; Amount = amount }

    let parse (line: string) = line.Split(", ") |> Array.map makeInstruction

    let step pos newDir =
        match newDir with
        | 0 -> { pos with Direction = newDir; Y = pos.Y + 1 }
        | 90 -> { pos with Direction = newDir; X = pos.X + 1 }
        | 180 -> { pos with Direction = newDir; Y = pos.Y - 1 }
        | 270 -> { pos with Direction = newDir; X = pos.X - 1 }
        | _ -> failwith $"Unsupported direction value {newDir}"

    let move allPos inst =
        let pos = allPos |> List.last
        let newDirRaw = pos.Direction + inst.Rotation

        let newDir =
            match newDirRaw with
            | -90 -> 270
            | 360 -> 0
            | x -> x

        let mutable currPos = pos
        let mutable newPos = []

        for _ in [ 1 .. inst.Amount ] do
            let nextPos = step currPos newDir
            newPos <- List.append newPos [ nextPos ]
            currPos <- nextPos

        allPos @ newPos

    let travel pos instructions = ([ pos ], instructions) ||> Array.fold move

    let getAllPositions (lines: string []) =
        let pos = { Direction = 0; X = 0; Y = 0 }
        let instructions = parse lines.[0]
        travel pos instructions

    let solve1 (lines: string []) =
        let pos = getAllPositions lines |> List.last
        (abs pos.X) + (abs pos.Y) |> int64

    let solve2 (lines: string []) =
        let allPos = getAllPositions lines

        let (x, y), _ =
            allPos
            |> List.groupBy (fun p -> (p.X, p.Y))
            |> List.filter (fun (_, set) -> set.Length > 1)
            |> List.head

        (abs x) + (abs y) |> int64
