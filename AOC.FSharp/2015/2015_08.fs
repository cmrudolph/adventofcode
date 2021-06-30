namespace AOC.FSharp

module AOC2015_08 =
    type State =
         { InputCount: int;
           Calculated: int;
           Chars: char list; }

    let toCleanCharList (line : string) =
        let chars = line |> List.ofSeq
        let len = chars.Length
        chars.[1..len-2]

    let updateState state inputAdd calcAdd newChars =
        { InputCount = state.InputCount + inputAdd; Calculated = state.Calculated + calcAdd; Chars = newChars }

    let getNewState1 state =
        match state.Chars with
        | [] -> state
        | '\\' :: '\\' :: rest -> updateState state 2 1 rest
        | '\\' :: '"' :: rest -> updateState state 2 1 rest
        | '\\' :: 'x' :: _ :: _ :: rest -> updateState state 4 1 rest
        | _ :: rest -> updateState state 1 1 rest

    let getNewState2 state =
        match state.Chars with
        | [] -> state
        | '\\' :: '\\' :: rest -> updateState state 2 4 rest
        | '\\' :: '"' :: rest -> updateState state 2 4 rest
        | '\\' :: 'x' :: _ :: _ :: rest -> updateState state 4 5 rest
        | _ :: rest -> updateState state 1 1 rest

    let rec processState newStateGetter state =
        let newState = newStateGetter state

        match state.Chars with
        | [] -> state
        | _ -> processState newStateGetter newState

    let solve (lines : string[]) =
        let ans1 =
            lines
            |> Array.map (fun line -> { InputCount = 2; Calculated = 0; Chars = (toCleanCharList line) })
            |> Array.map (processState getNewState1)
            |> Array.map (fun state -> state.InputCount - state.Calculated)
            |> Array.sum
            |> int64

        let ans2 =
            lines
            |> Array.map (fun line -> { InputCount = 2; Calculated = 6; Chars = (toCleanCharList line) })
            |> Array.map (processState getNewState2)
            |> Array.map (fun state -> state.Calculated - state.InputCount)
            |> Array.sum
            |> int64

        (ans1, ans2)