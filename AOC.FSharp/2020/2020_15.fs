namespace AOC.FSharp

module AOC2020_15 =
    open System.Collections.Generic

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

    let solve1 (lines : string[]) =
        let starting = lines.[0].Split(',') |> Array.map int
        starting |> solveCase 2020

    let solve2 (lines : string[]) =
        let starting = lines.[0].Split(',') |> Array.map int
        starting |> solveCase 30000000