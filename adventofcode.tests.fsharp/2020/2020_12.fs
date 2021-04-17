namespace Year2020

module Day12 =
    open Utils
    open Xunit

    [<Literal>]
    let North = 0

    [<Literal>]
    let East = 1

    [<Literal>]
    let South = 2

    [<Literal>]
    let West = 3

    type Instruction =
        { Direction: char;
          Amount: int }

    let dirIdx direction =
        match direction with
        | 'N' -> North
        | 'E' -> East
        | 'S' -> South
        | 'W' -> West
        | _ -> failwith $"Unsupported direction {direction}"

    let rotate amount arr =
        let rotateLeft (a : int array) =
            let tmp = a.[0]
            a.[0] <- a.[1]
            a.[1] <- a.[2]
            a.[2] <- a.[3]
            a.[3] <- tmp

        let rotateRight (a : int array) =
            let tmp = a.[3]
            a.[3] <- a.[2]
            a.[2] <- a.[1]
            a.[1] <- a.[0]
            a.[0] <- tmp

        let numMoves = amount / 90 |> abs
        let func = if amount < 0 then rotateLeft else rotateRight
        [1..numMoves] |> List.iter (fun _ -> func arr)

    let forward amount (dirs : int array) (pos : int array) =
        for i in 0..3 do
            pos.[i] <- (pos.[i] + (dirs.[i] * amount))

    let move amount dir (pos : int array) =
        let idx = dirIdx dir
        pos.[idx] <- pos.[idx] + amount

    let calcDistance (positions : int array) =
        let x = positions.[East] - positions.[West] |> abs
        let y = positions.[North] - positions.[South] |> abs
        x + y |> int64

    let parse (lines : string[]) =
        lines |> Array.map (fun line -> { Direction = line.[0]; Amount = line.[1..] |> int })

    let solve1 instructions =
        let mutable pos = [|0; 0; 0; 0|]
        let mutable dirs = [|0; 1; 0; 0|]

        for inst in instructions do
            match inst.Direction with
            | 'N' | 'E' | 'S' | 'W' -> move inst.Amount inst.Direction pos
            | 'L' -> rotate (inst.Amount * -1) dirs
            | 'R' -> rotate inst.Amount dirs
            | 'F' -> forward inst.Amount dirs pos
            | _ -> failwith $"Unknown instruction '{inst.Direction}'"
            |> ignore

        pos |> calcDistance |> int64

    let solve2 instructions =
        let mutable pos = [|0; 0; 0; 0|]
        let mutable wp = [|1; 10; 0; 0|]

        for inst in instructions do
            match inst.Direction with
            | 'N' | 'E' | 'S' | 'W' -> move inst.Amount inst.Direction wp
            | 'L' -> rotate (inst.Amount * -1) wp
            | 'R' -> rotate inst.Amount wp
            | 'F' -> forward inst.Amount wp pos
            | _ -> failwith $"Unknown instruction '{inst.Direction}'"
            |> ignore

        pos |> calcDistance |> int64

    let solve (lines : string[]) =
        let instructions = parse lines

        let ans1 = instructions |> solve1
        let ans2 = instructions |> solve2

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "12" "sample" |> solveAndValidate (25L, 286L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "12" "actual" |> solveAndValidate (998L, 71586L) solve