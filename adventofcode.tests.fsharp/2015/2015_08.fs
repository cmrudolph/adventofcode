namespace Year2015

module Day08 =
    open Utils
    open Xunit

    type State =
         { InputCount: int;
           CharCount: int;
           Chars: char list; }

    let toCleanCharList (line : string) =
        let chars = line |> List.ofSeq
        let len = chars.Length
        chars.[1..len-2]

    let updateState state memAdd strAdd newChars =
        { InputCount = state.InputCount + memAdd; CharCount = state.CharCount + strAdd; Chars = newChars }

    let rec processState state =
        match state.Chars with
        | [] -> state
        | '\\' :: '\\' :: rest -> processState (updateState state 2 1 rest)
        | '\\' :: '"' :: rest -> processState (updateState state 2 1 rest)
        | '\\' :: 'x' :: _ :: _ :: rest -> processState (updateState state 4 1 rest)
        | _ :: rest -> processState (updateState state 1 1 rest)

    let solve (lines : string[]) =
        let ans1 =
            lines
            |> Array.map (fun line -> { InputCount = 2; CharCount = 0; Chars = (toCleanCharList line) })
            |> Array.map processState
            |> Array.map (fun state -> state.InputCount - state.CharCount)
            |> Array.sum
            |> int64

        (ans1, 0L)

    [<Fact>]
    let Sample () =
        readInput "2015" "08" "sample" |> solveAndValidate (12L, -1L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "08" "actual" |> solveAndValidate (1350L, -1L) solve
