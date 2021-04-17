namespace Year2020

open System.Collections.Generic

module Day15 =
    open Utils
    open Xunit

    let getList (lookup : Dictionary<int, int ResizeArray>) key =
        let found, lst = lookup.TryGetValue key
        if found then
            lst
        else
            let lst = ResizeArray([])
            lookup.[key] <- lst
            lst

    let solveCase target startingNums =
        let len = startingNums |> Array.length
        let lastSpokenLookup = new Dictionary<int, int ResizeArray>()

        [0..len-1] |> List.iter (fun i -> lastSpokenLookup.[startingNums.[i]] <- ResizeArray([i+1]))

        let mutable curr = startingNums |> Array.last

        for i in len..target-1 do
            let prev = curr
            let prevLst = getList lastSpokenLookup prev

            curr <-
                match prevLst.Count with
                | length when length <= 1 -> 0
                | length -> prevLst.[length-1] - prevLst.[length-2]

            let currLst = getList lastSpokenLookup curr
            currLst.Add(i+1)

        curr |> int64

    let solve (lines : string[]) =
        let starting = lines.[0].Split(',') |> Array.map int

        let ans1 = starting |> solveCase 2020
        let ans2 = starting |> solveCase 30000000

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "15" "sample" |> solveAndValidate (436L, 175594L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "15" "actual" |> solveAndValidate (249L, 41687L) solve