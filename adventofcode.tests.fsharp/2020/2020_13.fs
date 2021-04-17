namespace Year2020

module Day13 =
    open Utils
    open Xunit

    type BusInfo =
        { Id: int64
          Offset: int64 }

    let parseBusInfos (line : string) =
        line.Split(',')
        |> Array.mapi (fun offset id -> (offset, id))
        |> Array.filter (fun (_, id) -> id <> "x")
        |> Array.map (fun (offset, id) -> { Offset = int64 offset; Id = int64 id })

    let solve1 timestamp busInfos =
        let mutable minWait = System.Int64.MaxValue
        let mutable minId = System.Int64.MaxValue

        for info in busInfos do
            let modResult = timestamp % info.Id
            let wait = if modResult = 0L then 0L else info.Id - modResult

            if wait < minWait then
                minWait <- wait
                minId <- info.Id

        minId * minWait

    let solve2 busInfos =
        let len = Array.length busInfos
        let mutable timestamp = 1L

        for i in 1..len do
            // Increment amount = multiply together the IDs of the "locked in" buses. This is the gap we can jump
            // each time as we know everything inside this window is not a valid solution.
            let incAmt = (1L, busInfos |> Array.take (i-1)) ||> Array.fold (fun acc b -> acc * b.Id)

            let mutable valid = false
            while (not valid) do
                valid <- true;
                for j in 0..i-1 do
                    // Check each potential timestamp to make sure it satisfies every bus under investigation.
                    let potentialTimestamp = timestamp + busInfos.[j].Offset
                    let isMatch = potentialTimestamp % busInfos.[j].Id = 0L
                    valid <- valid && isMatch
                if not valid then
                    // No match = skip the skippable gap and continue searching
                    timestamp <- timestamp + incAmt
        timestamp

    let solve (lines : string[]) =
        let timestamp = lines.[0] |> int64
        let busInfos = lines.[1] |> parseBusInfos

        let ans1 = solve1 timestamp busInfos
        let ans2 = solve2 busInfos

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "13" "sample" |> solveAndValidate (295L, 1068781L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "13" "actual" |> solveAndValidate (104L, 842186186521918L) solve