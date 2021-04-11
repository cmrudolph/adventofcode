namespace Year2020

module Day23 =
    open System
    open Utils
    open Xunit

    let parseInput (input : string[]) =
        // Split to chars, then convert chars to integers
        input.[0]
        |> List.ofSeq
        |> List.map int
        |> List.map (fun i -> i - 48)

    let takeSlice (values : int list) =
        // Pick the next three items into a new list and return the two artifacts
        let remaining = [values.[0]] @ values.[4..]
        let slice = values.[1..3]
        (remaining, slice)

    let insertSlice values slice target =
        // Put the removed slice back into the list at a different spot
        let idx = values |> List.findIndex (fun i -> i = target)
        values.[0..idx] @ slice @ values.[idx+1..]

    let findDest values target =
        let max = List.max values
        
        // Find the destination where we are going to insert the slice (first number lower than the
        // current value - wrap if we hit zero)
        [target..(-1)..1] @ [max..(-1)..target+1]
        |> List.map (fun i -> values |> List.tryFind (fun j -> i = j))
        |> List.choose id
        |> List.head

    let shiftForNewHead newHead values =
        // Reorient the list so the specific value is now at the head. Makes things easier because we can
        // always assume everything takes place relative to the first item (current)
        let oldIdx = values |> List.findIndex (fun i -> i = newHead)
        values.[oldIdx..] @ values.[0..oldIdx-1]

    let performMove values =
        // Orchestrate the steps. Represents one move action.
        let remaining, slice = takeSlice values
        let newCurrent = remaining.[1]
        let insertAfterTarget = findDest remaining (values.[0] - 1)
        let afterMutation = insertSlice remaining slice insertAfterTarget
        shiftForNewHead newCurrent afterMutation

    let solve (lines : string[]) =
        let input = parseInput lines

        // Repeat 100 times and report the final state after all the moves are done
        let asStrings = ([0..99]
            |> List.fold (fun acc _ -> performMove acc) input
            |> shiftForNewHead 1
            |> List.skip 1
            |> List.map (sprintf "%i"))
        let ans1 = String.Join("", asStrings)
        (ans1, "TODO")

    [<Fact>]
    let Sample () =
        readInput "2020" "23" "sample" |> solveAndValidateStr ("67384529", "BAR") solve

    [<Fact>]
    let Actual () =
        readInput "2020" "23" "actual" |> solveAndValidateStr ("98742365", "BAR") solve