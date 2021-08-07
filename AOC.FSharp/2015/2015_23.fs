namespace AOC.FSharp

module AOC2015_23 =
    open System.Collections.Generic
    open System.Linq

    type Instruction =
        | Half of int
        | Triple of int
        | Increment of int
        | Jump of int
        | JumpEven of (int * int)
        | JumpOdd of (int * int)

    let mapRegister ch =
        if ch = 'a' then 0 else 1

    let parseLine (line : string) =
        let clean = line.Replace(",", "")
        let splits = clean.Split(' ')

        match splits.[0] with
        | "hlf" -> Instruction.Half (mapRegister splits.[1].[0])
        | "tpl" -> Instruction.Triple (mapRegister splits.[1].[0])
        | "inc" -> Instruction.Increment (mapRegister splits.[1].[0])
        | "jmp" -> Instruction.Jump (splits.[1] |> int)
        | "jie" -> Instruction.JumpEven ((mapRegister splits.[1].[0]), (splits.[2] |> int))
        | "jio" -> Instruction.JumpOdd ((mapRegister splits.[1].[0]), (splits.[2] |> int))
        | _ -> failwith $"Unknown instruction {splits.[0]}"

    let solve (lines : string[]) (registers : int[]) =
        let instructions = lines |> Array.map parseLine
        let mutable idx = 0

        while idx < lines.Length do
            let inst = instructions.[idx]
            idx <-
                match inst with
                    | Half r ->
                        registers.[r] <- registers.[r] / 2
                        idx + 1
                    | Triple r ->
                        registers.[r] <- registers.[r] * 3
                        idx + 1
                    | Increment r ->
                        registers.[r] <- registers.[r] + 1
                        idx + 1
                    | Jump offset ->
                        idx + offset
                    | JumpEven (r, offset) ->
                        if registers.[r] % 2 = 0 then idx + offset else idx + 1
                    | JumpOdd (r, offset) ->
                        if registers.[r] = 1 then idx + offset else idx + 1

        registers.[1] |> int64

    let solve1 (lines : string[]) =
        let registers = [|0;0|]
        solve lines registers

    let solve2 (lines : string[]) =
        let registers = [|1;0|]
        solve lines registers