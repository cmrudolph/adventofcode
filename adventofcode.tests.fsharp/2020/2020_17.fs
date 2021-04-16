namespace Year2020

module Day17 =
    open Utils
    open Xunit

    [<Literal>]
    let InactiveChar = '.'

    [<Literal>]
    let ActiveChar = '#'

    let getNeighbors pos adjustments =
        let a, b, c, d = pos
        adjustments |> List.map (fun (i, j, k, m) -> (a + i, b + j, c + k, d + m))

    let getNewState pos adjustments activeSet =
        let getCharValue pos activeSet =
            let active = activeSet |> Set.contains pos
            match active with
            | true -> 1
            | false -> 0

        let neighbors = adjustments |> getNeighbors pos
        let currActive = activeSet |> Set.contains pos
        let neighborSum = neighbors |> Seq.sumBy (fun n -> getCharValue n activeSet)

        match currActive, neighborSum with
        | true, 2 | true, 3 | false, 3 -> Some pos
        | _ -> None

    let getSearchTargets adjustments activeSet =
        activeSet
        |> Set.toSeq
        |> Seq.collect (fun pos -> [pos] @ (getNeighbors pos adjustments))
        |> Set.ofSeq

    let cycleActiveSet targets adjustments activeSet =
        targets
        |> Set.toSeq
        |> Seq.map (fun pos -> getNewState pos adjustments activeSet)
        |> Seq.choose id
        |> Set.ofSeq

    let solve (lines : string[]) =
        let adjustments3 =
            let mutable temp = []
            for i in [-1..1] do
                for j in [-1..1] do
                    for k in [-1..1] do
                        temp <- List.append [(i, j, k, 0)] temp
            temp |> List.filter (fun (i, j, k, m) -> (i, j, k, m) <> (0, 0, 0, 0))

        let adjustments4 =
            let mutable temp = []
            for i in [-1..1] do
                for j in [-1..1] do
                    for k in [-1..1] do
                        for m in [-1..1] do
                            temp <- List.append [(i, j, k, m)] temp
            temp |> List.filter (fun (i, j, k, m) -> (i, j, k, m) <> (0, 0, 0, 0))

        let makeActiveSet (lines : string[]) =
            let origSize = Array.length lines
            let endIdx = origSize - 1

            [0..endIdx]
            |> List.collect (fun i -> [0..endIdx] |> List.map (fun j -> (i, j)))
            |> List.map (fun (i, j) -> if lines.[i].[j] = ActiveChar then Some (i, j, 0, 0) else None)
            |> List.choose id
            |> Set.ofList

        let mutable activeSet3 = makeActiveSet lines
        for _ in [1..6] do
            let targets3 = activeSet3 |> getSearchTargets adjustments3
            activeSet3 <- cycleActiveSet targets3 adjustments3 activeSet3
        let ans1 = activeSet3 |> Set.count |> int64

        let mutable activeSet4 = makeActiveSet lines
        for _ in [1..6] do
            let targets4 = activeSet4 |> getSearchTargets adjustments4
            activeSet4 <- cycleActiveSet targets4 adjustments4 activeSet4
        let ans2 = activeSet4 |> Set.count |> int64

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "17" "sample" |> solveAndValidate (112L, 848L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "17" "actual" |> solveAndValidate (298L, 1792L) solve