namespace AOC.FSharp

module AOC2020_08 =
    type InstructionType = Jmp | Acc | Nop

    type Instruction =
        { InstType: InstructionType;
          Amount : int;
          Visited : bool }

    type Completion = Success | Failure | Incomplete

    let parseLine (line : string) =
        let splits = line.Split(' ')

        let instType =
            match splits.[0] with
            | "nop" -> Some InstructionType.Nop
            | "acc" -> Some InstructionType.Acc
            | "jmp" -> Some InstructionType.Jmp
            | _ -> None

        let amount = splits.[1] |> int32

        match instType with
        | Some x -> Some { InstType = x; Amount = amount; Visited = false }
        | None -> None

    let parseLines (lines : string[]) =
        lines
        |> Array.map parseLine
        |> Array.choose id
        |> Array.mapi (fun i inst -> (i, inst))
        |> Map.ofArray

    let visit inst =
        match inst with
        | Some x -> Some { x with Visited = true }
        | None -> None

    let swapInst inst =
        match inst with
        | Some x ->
            let newInstType =
                match x.InstType with
                | InstructionType.Jmp -> InstructionType.Nop
                | InstructionType.Nop -> InstructionType.Jmp
                | InstructionType.Acc -> InstructionType.Acc
            Some { x with InstType = newInstType }
        | None -> None

    let completion1 (instructions : Map<int,Instruction>) idx =
        let instruction = instructions.[idx]
        match instruction.Visited with
        | true -> Completion.Success
        | false -> Completion.Incomplete

    let completion2 instructions idx =
        match idx = Map.count instructions with
            | true -> Completion.Success
            | false ->
                let instruction = instructions.[idx]
                match instruction.Visited with
                | true -> Completion.Failure
                | false -> Completion.Incomplete

    let rec processInstruction (instructions : Map<int,Instruction>) completion (idx : int) acc =
        match completion instructions idx with
        | Completion.Success -> Some acc
        | Completion.Failure -> None
        | Completion.Incomplete ->
            let newInstructions = instructions |> Map.change idx visit
            let instruction = instructions.[idx]
            match instruction.InstType with
            | InstructionType.Acc ->
                let newIdx = idx + 1
                processInstruction newInstructions completion (newIdx) (acc + instruction.Amount)
            | InstructionType.Jmp ->
                let newIdx = idx + instruction.Amount
                processInstruction newInstructions completion (newIdx) acc
            | InstructionType.Nop ->
                let newIdx = idx + 1
                processInstruction newInstructions completion (newIdx) acc

    let solve (lines : string[]) =
        let instructions = lines |> parseLines

        let ans1 = processInstruction instructions completion1 0 0 |> (fun x -> defaultArg x -1) |> int64

        let ans2 = ([0..(Map.count instructions) - 1]
        |> List.map (fun i -> Map.change i swapInst instructions)
        |> List.map (fun changed -> processInstruction changed completion2 0 0 |> (fun x -> defaultArg x -1) |> int64)
        |> List.filter (fun x -> x > 0L)
        |> List.head)

        (ans1, ans2)