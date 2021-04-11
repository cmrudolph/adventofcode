namespace Year2020

module Day23 =
    open System
    open System.Collections.Generic
    open Utils
    open Xunit

    type MoveInfo = { OldCurr: int; NewCurr: int; DestStart: int; DestEnd: int; Slice: int list; }

    let parseInput (input : string[]) =
        // Split to chars, then convert chars to integers
        input.[0]
        |> List.ofSeq
        |> List.map int
        |> List.map (fun i -> i - 48)

    let constructDict1 values =
        let len = values |> List.length
        let dict = new Dictionary<int, int>()

        for i in 0..len-2 do
            dict.Add(values.[i], values.[i+1])

        dict.Add(values.[len-1], values.[0])

        dict

    let constructDict2 max values =
        let len = values |> List.length
        let next = (List.max values) + 1
        let dict = new Dictionary<int, int>()

        for i in 0..len-2 do
            dict.Add(values.[i], values.[i+1])

        dict.Add(values.[len-1], next)
        for i in next..max-1 do
            dict.Add(i, i+1)

        dict.Add(max, values.[0])
        
        dict

    let getMoveInfo (dict : Dictionary<int, int>) curr max =
        let v1 = dict.[curr]
        let v2 = dict.[v1]
        let v3 = dict.[v2]
        let next = dict.[v3]
        let slice = [v1;v2;v3]

        let destStart = (
            [curr-1; curr-2; curr-3; curr-4; max; max-1; max-2; max-3]
            |> List.filter (fun i -> i > 0)
            |> List.filter (fun i -> not (List.contains i slice))
            |> List.head)

        let destEnd = dict.[destStart]

        { OldCurr = curr; NewCurr = next; DestStart = destStart; DestEnd = destEnd; Slice = slice }

    let applyMoveInfo (dict : Dictionary<int, int>) moveInfo =
        dict.[moveInfo.OldCurr] <- moveInfo.NewCurr
        dict.[moveInfo.DestStart] <- moveInfo.Slice.[0]
        dict.[moveInfo.Slice.[2]] <- moveInfo.DestEnd

    let solve1 (input: int list) =
        let d = constructDict1 input
        let mutable curr = input.[0]

        for i in 1..100 do
            let moveInfo = getMoveInfo d curr 9
            applyMoveInfo d moveInfo
            curr <- moveInfo.NewCurr

        let result = new List<int>()
        curr <- d.[1]
        while curr <> 1 do
            result.Add(curr)
            curr <- d.[curr]

        let asStrings = result |> Seq.map (sprintf "%i")
        String.Join("", asStrings)

    let solve2 (input : int list) =
        let d = constructDict2 1000000 input
        let mutable curr = input.[0]

        for i in 1..10000000 do
            let moveInfo = getMoveInfo d curr 1000000
            applyMoveInfo d moveInfo
            curr <- moveInfo.NewCurr

        let cup1 = d.[1]
        let cup2 = d.[cup1]
        (int64 cup1) * (int64 cup2)

    let solve (lines : string[]) =
        let input = parseInput lines

        let ans1 = input |> solve1
        let ans2 = input |> solve2

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "23" "sample" |> solveAndValidateStrInt64 ("67384529", 149245887792L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "23" "actual" |> solveAndValidateStrInt64 ("98742365", 294320513093L) solve